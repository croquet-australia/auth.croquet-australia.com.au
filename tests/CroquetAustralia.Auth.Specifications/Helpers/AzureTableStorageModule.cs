using CroquetAustralia.Auth.Specifications.Helpers.IdentityServer;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;
using Ninject.Modules;

namespace CroquetAustralia.Auth.Specifications.Helpers
{
    internal class InMemoryStorageModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IClientStore>().ToConstant(new InMemoryClientStore(Clients.Get()));
            Bind<IScopeStore>().ToConstant(new InMemoryScopeStore(Scopes.Get()));
            Bind<IUserService>().ToConstant(new InMemoryUserService(Users.Get()));
        }
    }
}