using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace PlaceApp.Web;

[Dependency(ReplaceServices = true)]
public class PlaceAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "PlaceApp";
}
