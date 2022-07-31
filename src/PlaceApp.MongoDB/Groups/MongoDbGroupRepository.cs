using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PlaceApp.MongoDB;
using PlaceApp.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace PlaceApp.Groups
{
    public class MongoDbGroupRepository : MongoDbRepository<PlaceAppMongoDbContext, Group, Guid>,
        IGroupRepository
    {
        public MongoDbGroupRepository(
           IMongoDbContextProvider<PlaceAppMongoDbContext> dbContextProvider
           ) : base(dbContextProvider)
        { }
        public async Task<List<Group>> GetListAsync(string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Group, IMongoQueryable<Group>>(
                    !filter.IsNullOrWhiteSpace(),
                    group => group.Name.Contains(filter)
                )

                .ToListAsync();
        }
    }
}
