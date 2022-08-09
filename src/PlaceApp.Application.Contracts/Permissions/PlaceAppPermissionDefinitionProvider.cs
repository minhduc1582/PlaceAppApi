using PlaceApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PlaceApp.Permissions;

public class PlaceAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PlaceAppPermissions.MyPermission1, L("Permission:MyPermission1"));
        var PlaceAppGroup = context.AddGroup(PlaceAppPermissions.GroupName, L("Permission:PlaceApp"));

        var placesPermission = PlaceAppGroup.AddPermission(PlaceAppPermissions.Places.Default, L("Permission:Places"));
        placesPermission.AddChild(PlaceAppPermissions.Places.Get, L("Permission:Places.Get"));
        placesPermission.AddChild(PlaceAppPermissions.Places.Edit, L("Permission:Places.Edit"));
        placesPermission.AddChild(PlaceAppPermissions.Places.Delete, L("Permission:Places.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PlaceAppResource>(name);
    }
}
