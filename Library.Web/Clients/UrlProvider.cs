using System.Configuration;

namespace Library.Web.Clients
{
    /// <summary>
    /// The url provider.
    /// </summary>
    public static class UrlProvider
    {
        public static string WebApiHost = ConfigurationManager.AppSettings["WebApiHost"];

        public static string WebApiCategory = ConfigurationManager.AppSettings["WebApiCategory"];

        public static string WebApiBook = ConfigurationManager.AppSettings["WebApiBook"];

        public static string WebApiReport = ConfigurationManager.AppSettings["WebApiReport"];
    }
}