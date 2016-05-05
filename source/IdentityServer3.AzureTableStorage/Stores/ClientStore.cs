using System;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Microsoft.WindowsAzure.Storage.Table;

namespace IdentityServer3.AzureTableStorage.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly CloudTable _table;

        public ClientStore(CloudTable table)
        {
            _table = table;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            throw new NotImplementedException("todo");
        }
    }
}