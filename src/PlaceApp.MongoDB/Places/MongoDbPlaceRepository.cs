using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaceApp.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace PlaceApp.Places
{
    public class MongoDbPlaceRepository
        : MongoDbRepository<PlaceAppMongoDbContext, Place, Guid>,
        IPlaceRepository
    {
        public MongoDbPlaceRepository(
            IMongoDbContextProvider<PlaceAppMongoDbContext> dbContextProvider
            ) : base(dbContextProvider)
        {
        }

        public async Task<Place> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(place => place.Name.Trim().ToUpper() == name.Trim().ToUpper());
        }

        public async Task<List<Place>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Place, IMongoQueryable<Place>>(
                    !filter.IsNullOrWhiteSpace(),
                    place => place.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<Place>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
        public async Task<List<Place>> GetListByStatusTypeAsync(
            StatusType statusType,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Place, IMongoQueryable<Place>>(
                    !filter.IsNullOrWhiteSpace(),
                    place => place.Name.Contains(filter)
                )
                .WhereIf<Place, IMongoQueryable<Place>>(
                    true,
                    place => place.Status == statusType

                )
                .OrderBy(sorting)
                .As<IMongoQueryable<Place>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
