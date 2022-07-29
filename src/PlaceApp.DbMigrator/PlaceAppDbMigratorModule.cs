using PlaceApp.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace PlaceApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PlaceAppMongoDbModule),
    typeof(PlaceAppApplicationContractsModule)
    )]
public class PlaceAppDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
