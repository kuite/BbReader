using System.Web.Http;
using BetReader.Api.Models.Repositores;
using BetReader.Api.Models.Services;
using BetReader.Web;
using Microsoft.Practices.Unity;

namespace BetReader.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RegisterServices(config);
        }

        private static void RegisterServices(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<CouponService, CouponService>();
            container.RegisterType<ICouponRepository, CouponRepository>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
