using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IdentityServer3.Core.Models;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using OpenMagic.Azure.Storage.Table;

namespace IdentityServer3.AzureTableStorage.Infrastructure.Serializers
{
    public class ScopeSerializer : IDynamicTableEntitySerializer<Scope>
    {
        private static readonly PropertyInfo[] ScopeProperties;

        static ScopeSerializer()
        {
            ScopeProperties = typeof(Scope).GetProperties();
        }

        public Scope Deserialize(DynamicTableEntity row)
        {
            var scope = new Scope
            {
                Name = row.PartitionKey
            };

            var ignoreProperties = new[] { "Type", "Claims", "ScopeSecrets" };
            var entityProperties = row.Properties.Where(p => !ignoreProperties.Contains(p.Key));

            foreach (var entityProperty in entityProperties)
            {
                var propertyInfo = ScopeProperties.SingleOrDefault(p => p.Name == entityProperty.Key);

                propertyInfo?.SetValue(scope, entityProperty.Value.PropertyAsObject);
            }

            EntityProperty property;

            if (row.Properties.TryGetValue("Type", out property))
            {
                scope.Type = (ScopeType)Enum.Parse(typeof(ScopeType), property.StringValue);
            }

            if (row.Properties.TryGetValue("Claims", out property))
            {
                scope.Claims = JsonConvert.DeserializeObject<List<ScopeClaim>>(property.StringValue);
            }

            if (row.Properties.TryGetValue("ScopeSecrets", out property))
            {
                scope.ScopeSecrets = JsonConvert.DeserializeObject<List<Secret>>(property.StringValue);
            }

            return scope;
        }

        public DynamicTableEntity Serialize(Scope scope)
        {
            var row = new DynamicTableEntity(scope.Name, "");
            var ignoreProperties = new[] { "Name", "Claims", "ScopeSecrets" };
            var properties = scope.GetType().GetProperties().Where(p => !ignoreProperties.Contains(p.Name));

            row.Properties = properties.ToDictionary(
                p => p.Name,
                p => EntityProperty.CreateEntityPropertyFromObject(p.GetValue(scope)));

            row.Properties.Add("Claims", EntityProperty.GeneratePropertyForString(JsonConvert.SerializeObject(scope.Claims)));
            row.Properties.Add("ScopeSecrets", EntityProperty.GeneratePropertyForString(JsonConvert.SerializeObject(scope.ScopeSecrets)));

            return row;
        }
    }
}