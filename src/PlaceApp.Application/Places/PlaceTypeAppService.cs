using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace PlaceApp.Places
{
    [EnableCors("AnotherPolicy")]
    public class PlaceTypeAppService:PlaceAppAppService,IPlaceTypeAppService
    {
        private readonly IPlaceTypeRepository _placeTypeRepository;
        public PlaceTypeAppService(IPlaceTypeRepository placeTypeRepository)
        {
            _placeTypeRepository = placeTypeRepository;
        }
        public async Task<PagedResultDto<PlaceTypeDto>> GetListAsync(GetListPlaceType input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Place.Name);
            }

            var places = await _placeTypeRepository.GetListAsync(

                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _placeTypeRepository.CountAsync()
                : await _placeTypeRepository.CountAsync(
                    place=>place.TypeName.Contains(input.Filter));

            return new PagedResultDto<PlaceTypeDto>(
                totalCount,
                ObjectMapper.Map<List<PlaceType>, List<PlaceTypeDto>>(places)
            );
        }
        public async Task<PlaceTypeReponseDto> CreateAsync(PlaceTypeRequestDto place)
        {
            var p = ObjectMapper.Map<PlaceTypeRequestDto, PlaceType>(place);
            Check.NotNullOrWhiteSpace(place.TypeName, nameof(place.TypeName));
            var existing = await _placeTypeRepository.FindByName(place.TypeName);
            if (existing != null)
            {
                throw new PlaceTypeAlreadyExistsException(place.TypeName);
            }
            await _placeTypeRepository.InsertAsync(p);
            return p == null ? null : ObjectMapper.Map<PlaceType, PlaceTypeReponseDto>(p);
        }
    }
}
