using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer3.Azure.Storage.Table.Infrastructure.Serializers;
using IdentityServer3.Azure.Storage.Table.Models;
using IdentityServer3.Azure.Storage.Table.Services;
using IdentityServer3.Azure.Storage.Table.Stores;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Microsoft.WindowsAzure.Storage;
using Ninject.Modules;
using OpenMagic.Azure.Storage.Table;

namespace CroquetAustralia.Auth.Infrastructure.AzureTableStorage
{
    internal class AzureTableStorageModule : NinjectModule
    {
        public override void Load()
        {
            var connectionString = "UseDevelopmentStorage=true;"; // todo
            var cloudStorage = CloudStorageAccount.DevelopmentStorageAccount; // todo
            var cloudTableProvider = new CloudTableProvider(cloudStorage);
            var tableNameProvider = new TableNameProvider();

            Bind<IClientStore>().ToConstructor(ctx => new ClientStore(new Table<Client>(connectionString, tableNameProvider.GetTableName<Client>(), new ClientSerializer())));
            Bind<IScopeStore>().ToConstructor(ctx => new ScopeStore(new Table<Scope>(connectionString, tableNameProvider.GetTableName<Scope>(), DynamicTableEntitySerializers.ScopeSerializer)));
            Bind<IUserService>().ToConstructor(ctx => new UserService(cloudTableProvider.GetTable<User>()));
        }
    }
}