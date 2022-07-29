using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace PlaceApp.MongoDB;

[DependsOn(
    typeof(PlaceAppTestBaseModule),
    typeof(PlaceAppMongoDbModule)
    )]
public class PlaceAppMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = PlaceAppMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
