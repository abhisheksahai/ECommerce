namespace API.Settings
{
    public static class ApiHelper
    {
        public static ApiConfiguration ApiConfiguration { get; set; }

        public static string GetECommerceConnectionString()
        {
            return ApiConfiguration.ECommerceConnectionString;
        }

        public static string GetFileUploadPath()
        {
            return ApiConfiguration.FileUploadPath;
        }
    }
}