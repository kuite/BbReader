using System.Web.Http;
using System.Web.Http.Cors;
using BetReader.Api.Models.Repositores;
using BetReader.Api.Models.Services;
using Microsoft.Practices.Unity;

namespace BetReader.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCrossSiteRequests(config);
            config.Filters.Add(new AuthorizeAttribute());

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

        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(
                origins: "*",
                headers: "*",
                methods: "*");
            config.EnableCors(cors);
        }
    }
}
