using System;
using AzureMagic.Storage.Table;
using IdentityServer3.Core.Models;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace IdentityServer3.AzureTableStorage.Infrastructure.Serializers
{
    public class ClientSerialier : IDynamicTableEntitySerializer<Client>
    {
        public Client Deserialize(DynamicTableEntity row)
        {
            return JsonConvert.DeserializeObject<Client>(row["Client"].StringValue);
        }

        public DynamicTableEntity Serialize(Client row)
        {
            throw new NotImplementedException();
        }
    }
}