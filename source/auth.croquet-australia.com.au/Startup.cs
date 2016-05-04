using CroquetAustralia.Auth;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CroquetAustralia.Auth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configuration(app, new StartupOptions());
        }

        public void Configuration(IAppBuilder appBuilder, StartupOptions options)
        {
            appBuilder.UseIdentityServer(options.IdentityServerOptions);
        }
    }
}