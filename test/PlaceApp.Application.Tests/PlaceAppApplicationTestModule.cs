using Volo.Abp.Modularity;

namespace PlaceApp;

[DependsOn(
    typeof(PlaceAppApplicationModule),
    typeof(PlaceAppDomainTestModule)
    )]
public class PlaceAppApplicationTestModule : AbpModule
{

}
