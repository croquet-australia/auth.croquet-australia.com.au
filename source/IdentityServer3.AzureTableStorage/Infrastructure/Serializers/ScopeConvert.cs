using IdentityServer3.Core.Models;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace IdentityServer3.AzureTableStorage.Infrastructure.Serializers
{
    internal static class ScopeConvert
    {
        public static Scope FromTableEntity(DynamicTableEntity tableEntity)
        {
            return JsonConvert.DeserializeObject<Scope>(tableEntity.Properties["Scope"].StringValue);
        }
    }
}