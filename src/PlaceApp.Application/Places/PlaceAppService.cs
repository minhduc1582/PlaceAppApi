using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlaceApp.Permissions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
namespace PlaceApp.Places
{
    [Authorize(PlaceAppPermissions.Places.Default)]
    public class PlaceAppService : PlaceAppAppService, IPlaceAppService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PlaceAppService(
            IPlaceRepository placeRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _placeRepository = placeRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        [AllowAnonymous]
        //[RemoteService(IsEnabled = false)]
        public async Task<PlaceDto> CreateAsync(PlaceRequestDto place)
        {
            return await CreateModeSourceAsync(place);
        }
        [RemoteService(IsEnabled = false)]
        public async Task<PlaceDto> CreateModeSourceAsync(PlaceRequestDto place, int mode = 0)
        {
            string source = "";
            if (mode == 0) {
                source = _httpContextAccessor.HttpContext.User.Identity.Name != null ? _httpContextAccessor.HttpContext.User.Identity.Name : "Anonymous"; }
            else if (mode == 1) { source = "auto"; }
            Place placeReponseDto = new Place();
            placeReponseDto.PlaceType = place.PlaceType;
            placeReponseDto.Name = place.Name;
            placeReponseDto.Source = source;
            Check.NotNullOrWhiteSpace(place.Name, nameof(place.Name));
            var existing = await _placeRepository.FindByNameAsync(place.Name);
            if (existing != null)
            {
                throw new PlaceAlreadyExistsException(place.Name);
            }
            var placeResult = await _placeRepository.InsertAsync(placeReponseDto);
            return ObjectMapper.Map<Place, PlaceDto>(placeResult);

        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(PlaceAppPermissions.Places.Get)]
        public async Task<PagedResultDto<PlaceDto>> GetListAsync(GetListPlace input)
        {

            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Place.Name);
            }

            var authors = await _placeRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _placeRepository.CountAsync()
                : await _placeRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<PlaceDto>(
                totalCount,
                ObjectMapper.Map<List<Place>, List<PlaceDto>>(authors)
            );
        }
        [AllowAnonymous]
        public async Task<List<String>> GetPlaceTypeName(GetListPlace input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Place.Name);
            }

            var places = await _placeRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount = int.MaxValue,
                input.Sorting,
                input.Filter
            );
            List<string> results = new List<string>();
            return places.Select(item => item.Name.Trim()).ToList();
        }
        [Authorize(PlaceAppPermissions.Places.Get)]
  //      [AllowAnonymous]
        public async Task<PagedResultDto<PlaceDto>> GetListByStatusTypeAsync(GetListPlace input,StatusType statusType)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Place.Name);
            }

            var authors = await _placeRepository.GetListByStatusTypeAsync(
                statusType,
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = authors.Count();

            return new PagedResultDto<PlaceDto>(
                totalCount,
                ObjectMapper.Map<List<Place>, List<PlaceDto>>(authors)
            );
        }

        [AllowAnonymous]
        [RemoteService(IsEnabled = false)]
        public async Task<List<PlaceDto>> ExportData()
        {
            GetListPlace input = new GetListPlace();
            var places = await _placeRepository.GetListByStatusTypeAsync(
                StatusType.Approval,
                0,
                int.MaxValue,
                "Name",
                input.Filter
            );
            return ObjectMapper.Map<List<Place>, List<PlaceDto>>(places);
        }


        [Authorize(PlaceAppPermissions.Places.Edit)]
        public async Task<PlaceDto> UpdateAsync(Guid id,StatusType statusType)
        {
            var place = await _placeRepository.GetAsync(id);
            place.Status = statusType;
            var placeUpdated = await _placeRepository.UpdateAsync(place);
            return ObjectMapper.Map<Place,PlaceDto>(placeUpdated);
        }
        
    }
}
