using Volo.Abp.Settings;

namespace PlaceApp.Settings;

public class PlaceAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PlaceAppSettings.MySetting1));
    }
}
