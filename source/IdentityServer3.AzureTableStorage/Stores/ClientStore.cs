using System.Linq;
using System.Threading.Tasks;
using Anotar.LibLog;
using AzureMagic.Storage.Table;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using NullGuard;

namespace IdentityServer3.AzureTableStorage.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly ITable<Client> _table;

        public ClientStore(ITable<Client> table)
        {
            _table = table;
        }

        [return: AllowNull]
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var clients = await _table.FindAsync(clientId);
            var client = clients.SingleOrDefault();

            if (client == null)
            {
                LogTo.Warn($"Cannot find {nameof(clientId)} '{clientId}'.");
            }

            return client;
        }
    }
}