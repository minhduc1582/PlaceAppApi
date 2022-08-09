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
    public class MongoDbPlaceTypeRepository : MongoDbRepository<PlaceAppMongoDbContext, PlaceType, Guid>,
        IPlaceTypeRepository
    {
        public MongoDbPlaceTypeRepository(
           IMongoDbContextProvider<PlaceAppMongoDbContext> dbContextProvider
           ) : base(dbContextProvider)
        {
        }

        public async Task<PlaceType> FindByName(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(place=>place.TypeName.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<List<PlaceType>> GetListAsync(string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<PlaceType, IMongoQueryable<PlaceType>>(
                    !filter.IsNullOrWhiteSpace(),
                    placetype => placetype.TypeName.Contains(filter)
                )

                .ToListAsync();
        }
    }
}
