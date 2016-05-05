namespace CroquetAustralia.Auth.Infrastructure.AzureTableStorage
{
    internal class TableNameProvider : ITableNameProvider
    {
        public string GetTableName<TEntity>()
        {
            return typeof(TEntity).Name;
        }
    }
}