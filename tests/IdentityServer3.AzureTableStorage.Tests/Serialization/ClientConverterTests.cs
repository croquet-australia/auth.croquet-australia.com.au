using System;
using Xunit;

namespace IdentityServer3.AzureTableStorage.Tests.Serialization
{
    public class ClientConverterTests
    {
        [Fact]
        public void CanSerializeAndDeserializeAClient()
        {
            throw new NotImplementedException("todo");
            //var client = new Client{
            //    ClientId = "123", 
            //    Enabled = true,
            //    AbsoluteRefreshTokenLifetime = 5, 
            //    AccessTokenLifetime = 10, 
            //    AccessTokenType = AccessTokenType.Jwt, 
            //    AllowRememberConsent = true, 
            //    RedirectUris = new List<string>{"http://foo.com"}
            //};
            //var clientStore = new InMemoryClientStore(new Client[]{client});
            //var converter = new ClientConverter(clientStore);

            //var settings = new JsonSerializerSettings();
            //settings.Converters.Add(converter);
            //var json = JsonConvert.SerializeObject(client, settings);

            //var result = JsonConvert.DeserializeObject<Client>(json, settings);
            //Assert.Same(client, result);
        }
    }
}