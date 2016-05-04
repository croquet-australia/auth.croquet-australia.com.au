using CroquetAustralia.Auth.Infrastructure.IdentityServer;
using IdentityServer3.Core.Configuration;

namespace CroquetAustralia.Auth
{
    public class StartupOptions
    {
        public StartupOptions()
        {
            IdentityServerOptions = new IdentityServerOptions
            {
                SigningCertificate = Certificate.Get(),
                Factory = Factory.Create()
            };
        }

        public IdentityServerOptions IdentityServerOptions { get; set; }
    }
}