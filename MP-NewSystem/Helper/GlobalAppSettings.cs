namespace MP_NewSystem.Helper
{
    /// <summary>
    /// App Settings
    /// </summary>
    public class GlobalAppSettings
    {
        public static string ApiName;
        public static string AppMode;
        public static bool IsMorning()
        {
            return AppMode.Equals("morning");
        }
        public static bool IsAfternoon()
        {
            return AppMode.Equals("afternoon");
        }

        public static bool IsEvening()
        {
            return AppMode.Equals("evening");
        }

    }
}
