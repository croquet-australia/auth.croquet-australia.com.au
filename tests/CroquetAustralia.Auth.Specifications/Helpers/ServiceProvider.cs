using CroquetAustralia.Auth.Infrastructure.AzureTableStorage;
using Ninject.Modules;

namespace CroquetAustralia.Auth.Specifications.Helpers
{
    internal class ServiceProvider : Infrastructure.IdentityServer.ServiceProvider
    {
        private static readonly NinjectModule[] NinjectModules = Settings.IntegrationTests ?
            new NinjectModule[] {new AzureTableStorageModule()} :
            new NinjectModule[] {new InMemoryStorageModule()};

        internal ServiceProvider()
            : base(NinjectModules)
        {
        }
    }
}