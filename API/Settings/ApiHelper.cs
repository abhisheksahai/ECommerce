namespace API.Settings
{
    public static class ApiHelper
    {
        public static ApiConfiguration ApiConfiguration { get; set; }

        public static string GetDefaultConnection()
        {
            return ApiConfiguration.DefaultConnection;
        }
    }
}
