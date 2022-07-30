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
    public class PlaceAppService : PlaceAppAppService, IPlaceAppService
    {
        private readonly IPlaceRepository _placeRepository;
        public PlaceAppService(
            IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<PlaceReponseDto> Create(PlaceRequestDto place)
        {
            var places = ObjectMapper.Map<PlaceRequestDto, Place>(place);
            Check.NotNullOrWhiteSpace(place.Name, nameof(place.Name));
            var existing = await _placeRepository.FindByName(place.Name);
            if (existing != null)
            {
                throw new PlaceAlreadyExistsException(place.Name);
            }
            place.Status = 0;
            await _placeRepository.InsertAsync(places);
            return places == null ? null : ObjectMapper.Map<Place, PlaceReponseDto>(places);
        }

        public async Task<PagedResultDto<PlaceDto>> GetListAsync(GetListPlace input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Place.Name);
            }

            var authors = await _placeRepository.GetListAsync(

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
    }
}
