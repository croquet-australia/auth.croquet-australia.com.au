using CroquetAustralia.Auth;
using CroquetAustralia.Auth.Infrastructure.IdentityServer;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CroquetAustralia.Auth
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var serviceProvider = new ServiceProvider();

            Configuration(appBuilder, serviceProvider.CreateIdentityServerOptions());
        }

        public void Configuration(IAppBuilder appBuilder, IdentityServerOptions identityServerOptions)
        {
            appBuilder.UseIdentityServer(identityServerOptions);
        }
    }
}