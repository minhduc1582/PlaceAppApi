using MongoDB.Driver;
using PlaceApp.Groups;
using PlaceApp.Places;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace PlaceApp.MongoDB;

[ConnectionStringName("Default")]
public class PlaceAppMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<Group> Groups => Collection<Group>();
    public IMongoCollection<PlaceType> PlaceTypes => Collection<PlaceType>();
    public IMongoCollection<Place> Places => Collection<Place>();
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
