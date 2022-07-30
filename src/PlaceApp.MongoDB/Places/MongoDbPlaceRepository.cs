using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PlaceApp.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace PlaceApp.Places
{
    public class MongoDbPlaceRepository : MongoDbRepository<PlaceAppMongoDbContext, Place, Guid>,
        IPlaceRepository
    {
        public MongoDbPlaceRepository(
           IMongoDbContextProvider<PlaceAppMongoDbContext> dbContextProvider
           ) : base(dbContextProvider)
        {
        }

        public async Task<Place> FindByName(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(place => place.Name == name);
        }

        public async Task<List<Place>> GetListAsync(string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Place, IMongoQueryable<Place>>(
                    !filter.IsNullOrWhiteSpace(),
                    place => place.Name.Contains(filter)
                )

                .ToListAsync();
        }
    }
}
