namespace CroquetAustralia.Auth.Infrastructure.AzureTableStorage
{
    internal interface ITableNameProvider
    {
        string GetTableName<TEntity>();
    }
}