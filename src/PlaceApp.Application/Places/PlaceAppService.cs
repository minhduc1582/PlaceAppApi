using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace PlaceApp.Places
{
    public class PlaceAppService : PlaceAppAppService, IPlaceAppService
    {

        private readonly IPlaceRepository _placeRepository;
        public PlaceAppService(
            IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;

        }
        //[AllowAnonymous]
        public async Task<PlaceRequestReponseDto> CreateAsync(PlaceRequestReponseDto place)
        {
            var places = ObjectMapper.Map<PlaceRequestReponseDto, Place>(place);
            Check.NotNullOrWhiteSpace(place.Name, nameof(place.Name));
            var existing = await _placeRepository.FindByNameAsync(place.Name);
            if (existing != null)
            {
                throw new PlaceAlreadyExistsException(place.Name);
            }
            place.Status = 0;
            await _placeRepository.InsertAsync(places);
            return places == null ? null : ObjectMapper.Map<Place, PlaceRequestReponseDto>(places);
        }
        //[Authorize(Roles = "admin")]
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
        //[Authorize(Roles = "admin")]
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
        //[Authorize(Roles = "admin")]
        public async Task<PlaceDto> UpdateAsync(Guid id,StatusType statusType)
        {
            var place = await _placeRepository.GetAsync(id);
            place.Status = statusType;
            var placeUpdated = await _placeRepository.UpdateAsync(place);
            return ObjectMapper.Map<Place,PlaceDto>(placeUpdated);
        }
    }
}
