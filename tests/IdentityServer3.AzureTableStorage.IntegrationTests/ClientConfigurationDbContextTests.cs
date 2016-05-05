using System;
using Xunit;

namespace IdentityServer3.AzureTableStorage.IntegrationTests
{
    public class ClientConfigurationDbContextTests
    {
        private const string ConfigConnectionStringName = "Config";

        [Fact]
        public void CanAddAndDeleteClientRedirectUri()
        {
            throw new NotImplementedException("todo");
            //using (var db = new ClientConfigurationDbContext(ConfigConnectionStringName))
            //{
            //    db.Clients.Add(new Client
            //    {
            //        ClientId = "test-client",
            //        ClientName = "Test Client"
            //    });

            //    db.SaveChanges();
            //}

            //using (var db = new ClientConfigurationDbContext(ConfigConnectionStringName))
            //{
            //    var client = db.Clients.First();

            //    client.RedirectUris.Add(new ClientRedirectUri
            //    {
            //        Uri = "https://redirect-uri-1"
            //    });

            //    db.SaveChanges();
            //}

            //using (var db = new ClientConfigurationDbContext(ConfigConnectionStringName))
            //{
            //    var client = db.Clients.First();
            //    var redirectUri = client.RedirectUris.First();

            //    client.RedirectUris.Remove(redirectUri);

            //    db.SaveChanges();
            //}

            //using (var db = new ClientConfigurationDbContext(ConfigConnectionStringName))
            //{
            //    var client = db.Clients.First();

            //    Assert.Equal(0, client.RedirectUris.Count());
            //}
        }

        [Fact]
        public void CanAddAndDeleteClientScopes()
        {
            throw new NotImplementedException("todo");
            //using (var db = new ClientConfigurationDbContext(ConfigConnectionStringName))
            //{
            //    db.Clients.Add(new Client
            //    {
            //        ClientId = "test-client-scopes",
            //        ClientName = "Test Client"
            //    });

            //    db.SaveChanges();
            //}

            //using (var db = new ClientConfigurationDbContext(ConfigConnectionStringName))
            //{
            //    var client = db.Clients.First();

            //    client.AllowedScopes.Add(new ClientScope
            //    {
            //        Scope = "test"
            //    });

            //    db.SaveChanges();
            //}

            //using (var db = new ClientConfigurationDbContext(ConfigConnectionStringName))
            //{
            //    var client = db.Clients.First();
            //    var scope = client.AllowedScopes.First();

            //    client.AllowedScopes.Remove(scope);

            //    db.SaveChanges();
            //}

            //using (var db = new ClientConfigurationDbContext(ConfigConnectionStringName))
            //{
            //    var client = db.Clients.First();

            //    Assert.Equal(0, client.AllowedScopes.Count());
            //}
        }
    }
}