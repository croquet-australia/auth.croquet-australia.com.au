using IdentityServer3.Core.Configuration;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    public class Factory
    {
        public static IdentityServerServiceFactory Create()
        {
            // todo: compare to "C:\Users\Tim\Code\open-source\IdentityServer3.Samples\source\WebHost (minimal)"
            // todo: replace with ServiceContainer
            return new IdentityServerServiceFactory()
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryScopes(Scopes.Get())
                .UseInMemoryUsers(Users.Get());
        }
    }
}