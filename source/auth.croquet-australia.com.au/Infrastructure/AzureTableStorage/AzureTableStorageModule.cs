using IdentityServer3.AzureTableStorage.Models;
using IdentityServer3.AzureTableStorage.Services;
using IdentityServer3.AzureTableStorage.Stores;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Microsoft.WindowsAzure.Storage;
using Ninject.Modules;

namespace CroquetAustralia.Auth.Infrastructure.AzureTableStorage
{
    internal class AzureTableStorageModule : NinjectModule
    {
        public override void Load()
        {
            var cloudStorage = CloudStorageAccount.DevelopmentStorageAccount; // todo
            var cloudTableProvider = new CloudTableProvider(cloudStorage);

            Bind<IClientStore>().ToConstructor(ctx => new ClientStore(cloudTableProvider.GetTable<Client>()));
            Bind<IScopeStore>().ToConstructor(ctx => new ScopeStore(cloudTableProvider.GetTable<Scope>()));
            Bind<IUserService>().ToConstructor(ctx => new UserService(cloudTableProvider.GetTable<User>()));
        }
    }
}