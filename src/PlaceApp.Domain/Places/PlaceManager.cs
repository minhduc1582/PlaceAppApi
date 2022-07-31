using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;


namespace PlaceApp.Places
{
    public class PlaceManager : DomainService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceManager(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<Place> CreateAsync(
            [NotNull] string name,
            [NotNull] string source,
            [NotNull] StatusType status,
            [NotNull] string PlaceType)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _placeRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new PlaceAlreadyExistsException(name);
            }

            return new Place (
                name,
                source,
                status,
                PlaceType
            );
        }
    }
}
