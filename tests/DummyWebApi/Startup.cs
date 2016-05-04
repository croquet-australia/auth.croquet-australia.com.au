using System.IdentityModel.Tokens;
using System.Web.Http;
using Anotar.NLog;
using DummyWebApi;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace DummyWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder, string authorityUrl)
        {
            LogTo.Trace($"{nameof(Configuration)}({nameof(appBuilder)}, {nameof(authorityUrl)}: '{authorityUrl}')");

            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            ConfigureIdentityServer(appBuilder, authorityUrl);
            ConfigureWebApi(appBuilder);
        }

        private static void ConfigureIdentityServer(IAppBuilder appBuilder, string authorityUrl)
        {
            LogTo.Trace($"{nameof(ConfigureIdentityServer)}({nameof(appBuilder)}, {nameof(authorityUrl)})");

            var options = new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = authorityUrl,
                RequiredScopes = new[] {"read"}
            };

            appBuilder.UseIdentityServerBearerTokenAuthentication(options);
        }

        private static void ConfigureWebApi(IAppBuilder appBuilder)
        {
            LogTo.Trace($"{nameof(ConfigureWebApi)}({nameof(appBuilder)})");

            var httpConfiguration = new HttpConfiguration();

            httpConfiguration.Routes.MapHttpRoute(
                "API Default",
                "{controller}/{id}",
                new {id = RouteParameter.Optional});

            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}