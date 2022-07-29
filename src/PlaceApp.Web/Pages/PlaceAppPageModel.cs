using PlaceApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace PlaceApp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class PlaceAppPageModel : AbpPageModel
{
    protected PlaceAppPageModel()
    {
        LocalizationResourceType = typeof(PlaceAppResource);
    }
}
