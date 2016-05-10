using System;
using IdentityServer3.Core.Models;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using OpenMagic.Azure.Storage.Table;

namespace IdentityServer3.AzureTableStorage.Infrastructure.Serializers
{
    public class ScopeSerializer : IDynamicTableEntitySerializer<Scope>
    {
        //public static Scope FromTableEntity(DynamicTableEntity tableEntity)
        //{
        //    return JsonConvert.DeserializeObject<Scope>(tableEntity.Properties["Scope"].StringValue);
        //}
        public Scope Deserialize(DynamicTableEntity row)
        {
            throw new NotImplementedException();
        }

        public DynamicTableEntity Serialize(Scope row)
        {
            throw new System.NotImplementedException();
        }
    }
}