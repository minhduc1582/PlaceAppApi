using System;
using System.Collections.Generic;
using System.Text;
using PlaceApp.Localization;
using Volo.Abp.Application.Services;

namespace PlaceApp;

/* Inherit your application services from this class.
 */
public abstract class PlaceAppAppService : ApplicationService
{
    protected PlaceAppAppService()
    {
        LocalizationResource = typeof(PlaceAppResource);
    }
}
