namespace GameZone.Settings
{
    public static class Filesettings
    {
       public const string ImagesPath = "/assets/Images/games";
       public const string AllowedExctentions = ".jpg,.jpeg,.png,.jfif";
       public const int MaxFillSizeInMB = 10;
       public const int MaxFileSizeInBytes = MaxFillSizeInMB * 1024 * 1024;
    }
}
