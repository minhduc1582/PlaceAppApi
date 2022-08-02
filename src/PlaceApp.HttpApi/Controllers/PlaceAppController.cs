using PlaceApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PlaceApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PlaceAppController : AbpControllerBase
{   
    protected PlaceAppController()
    {
        LocalizationResource = typeof(PlaceAppResource);
    }
}