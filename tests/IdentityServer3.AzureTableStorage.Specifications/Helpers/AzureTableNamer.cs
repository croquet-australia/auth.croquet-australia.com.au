namespace IdentityServer3.AzureTableStorage.Specifications.Helpers
{
    internal static class AzureTableNamer
    {
        internal static string GetTableName<TEntity>()
        {
            return $"is3{typeof(TEntity).Name}s";
        }
    }
}