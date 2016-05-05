using System;
using Xunit;

namespace IdentityServer3.AzureTableStorage.Tests.Serialization
{
    public class ClaimConverterTests
    {
        [Fact]
        public void CanSerializeAndDeserializeAClaim()
        {
            throw new NotImplementedException("todo");
            //var claim = new Claim(Constants.ClaimTypes.Subject, "alice");

            //var settings = new JsonSerializerSettings();
            //settings.Converters.Add(new ClaimConverter());
            //var json = JsonConvert.SerializeObject(claim, settings);

            //claim = JsonConvert.DeserializeObject<Claim>(json, settings);
            //Assert.Equal(Constants.ClaimTypes.Subject, claim.Type);
            //Assert.Equal("alice", claim.Value);
        }
    }
}