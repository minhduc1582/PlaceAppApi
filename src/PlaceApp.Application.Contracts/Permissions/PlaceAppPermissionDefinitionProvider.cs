using PlaceApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PlaceApp.Permissions;

public class PlaceAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PlaceAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PlaceAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PlaceAppResource>(name);
    }
}
