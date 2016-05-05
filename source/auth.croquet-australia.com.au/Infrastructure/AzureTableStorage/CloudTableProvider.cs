using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CroquetAustralia.Auth.Infrastructure.AzureTableStorage
{
    internal class CloudTableProvider
    {
        private readonly CloudTableClient _cloudTableClient;
        private readonly ITableNameProvider _tableNameProvider;

        public CloudTableProvider(CloudStorageAccount cloudStorageAccount)
            : this(cloudStorageAccount.CreateCloudTableClient(), new TableNameProvider())
        {
        }

        public CloudTableProvider(CloudTableClient cloudTableClient, ITableNameProvider tableNameProvider)
        {
            _cloudTableClient = cloudTableClient;
            _tableNameProvider = tableNameProvider;
        }

        public CloudTable GetTable<TEntity>()
        {
            return GetTable<TEntity>(true);
        }

        public CloudTable GetTable<TEntity>(bool createIfNotExists)
        {
            var tableName = _tableNameProvider.GetTableName<TEntity>();
            var table = _cloudTableClient.GetTableReference(tableName);

            if (createIfNotExists)
            {
                table.CreateIfNotExists();
            }

            return table;
        }
    }
}