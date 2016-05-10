using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using OpenMagic.Azure.Storage.Table;

namespace IdentityServer3.AzureTableStorage.Infrastructure.Serializers
{
    public class DynamicTableEntitySerializer<TEntity> : IDynamicTableEntitySerializer<TEntity>
    {
        private readonly Func<string, string, TEntity> _entityFactory;
        private readonly Dictionary<string, Func<TEntity, EntityProperty>> _entityPropertyFactories;
        private readonly Func<TEntity, string> _partitionKeyFactory;
        private readonly Dictionary<string, Action<TEntity, EntityProperty>> _propertyWriters;
        private readonly Func<TEntity, string> _rowKeyFactory;

        public DynamicTableEntitySerializer(Func<string, string, TEntity> entityFactory, Func<TEntity, string> partitionKeyFactory, Func<TEntity, string> rowKeyFactory, IEnumerable<string> ignoreProperties)
        {
            _entityFactory = entityFactory;
            _partitionKeyFactory = partitionKeyFactory;
            _rowKeyFactory = rowKeyFactory;

            var properties = typeof(TEntity).GetProperties()
                .Where(p => !ignoreProperties.Contains(p.Name))
                .ToArray();

            _propertyWriters = properties.ToDictionary(p => p.Name, GetPropertyWriter);
            _entityPropertyFactories = properties.ToDictionary(p => p.Name, GetEntityPropertyFactory);
        }

        public TEntity Deserialize(DynamicTableEntity row)
        {
            var entity = _entityFactory(row.PartitionKey, row.RowKey);

            foreach (var column in row.Properties)
            {
                Action<TEntity, EntityProperty> propertyWriter;

                if (_propertyWriters.TryGetValue(column.Key, out propertyWriter))
                {
                    propertyWriter(entity, column.Value);
                }
            }

            return entity;
        }

        public DynamicTableEntity Serialize(TEntity entity)
        {
            return new DynamicTableEntity
            {
                PartitionKey = _partitionKeyFactory(entity),
                RowKey = _rowKeyFactory(entity),
                Properties = _entityPropertyFactories.ToDictionary(e => e.Key, e => e.Value(entity))
            };
        }

        private static Func<TEntity, EntityProperty> GetEntityPropertyFactory(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.IsGenericType && (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                return entity => EntityProperty.GeneratePropertyForString(JsonConvert.SerializeObject(propertyInfo.GetValue(entity)));
            }
            return entity => EntityProperty.CreateEntityPropertyFromObject(propertyInfo.GetValue(entity));
        }

        private static Action<TEntity, EntityProperty> GetPropertyWriter(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.IsEnum)
            {
                return (entity, column) => propertyInfo.SetValue(entity, Enum.Parse(propertyInfo.PropertyType, column.StringValue));
            }
            if (propertyInfo.PropertyType.IsGenericType && (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                return (entity, column) => propertyInfo.SetValue(entity, JsonConvert.DeserializeObject(column.StringValue, propertyInfo.PropertyType));
            }
            return (entity, column) => propertyInfo.SetValue(entity, column.PropertyAsObject);
        }
    }
}