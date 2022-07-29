using PlaceApp.MongoDB;
using Volo.Abp.Modularity;

namespace PlaceApp;

[DependsOn(
    typeof(PlaceAppMongoDbTestModule)
    )]
public class PlaceAppDomainTestModule : AbpModule
{

}
