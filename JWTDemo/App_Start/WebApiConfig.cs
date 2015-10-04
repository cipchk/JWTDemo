using System.Web.Http;

namespace JWTDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            // config.SuppressDefaultHostAuthentication();

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
