using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;
using System.Web.Http.OData.Builder;
using tpo10_rest.Models;
using System.Web.Http.OData.Extensions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace tpo10_rest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Enable CORS
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Formaters
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new FormUrlEncodedMediaTypeFormatter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // OData v4
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<ApplicationUser>("ApplicationUsers");
            builder.EntitySet<IdentityUserClaim>("IdentityUserClaims");
            builder.EntitySet<IdentityUserLogin>("IdentityUserLogins");
            builder.EntitySet<IdentityUserRole>("IdentityUserRoles");
            builder.EntitySet<DoctorProfile>("DoctorProfile");
            builder.EntitySet<PatientProfile>("PatientProfile");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
