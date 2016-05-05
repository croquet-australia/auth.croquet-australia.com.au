using System;
using Xunit;

namespace IdentityServer3.AzureTableStorage.Tests
{
    public class NameLengthTests
    {
        [Fact]
        public void NamesAreNotMoreThan30Chars()
        {
            throw new NotImplementedException("todo");

            //var assembly = Assembly.GetAssembly(typeof(ClientConfigurationDbContext));
            //var query =
            //    from t in assembly.GetTypes()
            //    where t.Namespace == "IdentityServer3.EntityFramework.Entities"
            //    select t;
            //foreach(var type in query)
            //{
            //    Assert.True(type.Name.Length <= 30, type.Name);

            //    foreach(var prop in type.GetProperties())
            //    {
            //        Assert.True(prop.Name.Length <= 30, type.Name + ". " + prop.Name);
            //    }
            //}
        }
    }
}