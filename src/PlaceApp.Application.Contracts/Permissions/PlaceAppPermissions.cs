namespace PlaceApp.Permissions;

public static class PlaceAppPermissions
{
    public const string GroupName = "PlaceApp";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Places
    {
        public const string Default = GroupName + ".Books";
        public const string Get = Default + ".Get";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
