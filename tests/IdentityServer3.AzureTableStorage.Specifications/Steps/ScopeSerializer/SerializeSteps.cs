using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using IdentityServer3.AzureTableStorage.Infrastructure.Serializers;
using IdentityServer3.AzureTableStorage.Specifications.Helpers;
using IdentityServer3.Core.Models;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace IdentityServer3.AzureTableStorage.Specifications.Steps.ScopeSerializer
{
    [Binding]
    public class SerializeSteps
    {
        private readonly Actual _actual;
        private readonly DummyFactory _dummy;
        private readonly Given _given;

        public SerializeSteps(Given given, Actual actual, DummyFactory dummy)
        {
            _given = given;
            _actual = actual;
            _dummy = dummy;
        }

        [Given(@"a Scope object")]
        public void GivenAScopeObject()
        {
            _given.Scope = _dummy.Object<Scope>();
        }

        [When(@"ScopeSerializer\.Serialize\(scope\) is called")]
        public void WhenScopeSerializer_SerializeScopeIsCalled()
        {
            _actual.DynamicTableEntity = DynamicTableEntitySerializers.ScopeSerializer.Serialize(_given.Scope);
        }

        [Then(@"a DynamicTableEntity should be returned")]
        public void ThenADynamicTableEntityShouldBeReturned()
        {
            _actual.DynamicTableEntity.Should().NotBeNull();
        }

        [Then(@"DynamicTableEntity\.PartitionKey should be Scope\.Name")]
        public void ThenDynamicTableEntity_PartitionKeyShouldBeScope_Name()
        {
            _actual.DynamicTableEntity.PartitionKey
                .Should().Be(_given.Scope.Name);
        }

        [Then(@"DynamicTableEntity\.RowKey should be empty string")]
        public void ThenDynamicTableEntity_RowKeyShouldBeEmptyString()
        {
            _actual.DynamicTableEntity.RowKey
                .Should().BeEmpty();
        }

        [Then(@"DynamicTableEntity\.Properties should include all Scope properties except Scope\.Name")]
        public void ThenDynamicTableEntity_PropertiesShouldIncludeAllScopePropertiesExceptScope_Name()
        {
            var ignoreProperties = new[] {"Name", "Type", "Claims", "ScopeSecrets"};
            var properties = _given.Scope.GetType().GetProperties().Where(p => !ignoreProperties.Contains(p.Name));
            var expectedValues = properties.Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(_given.Scope)));
            var dynamicTableEntity = _actual.DynamicTableEntity;
            var actualValues = dynamicTableEntity.Properties.Where(p => !ignoreProperties.Contains(p.Key)).Select(p => new KeyValuePair<string, object>(p.Key, p.Value.PropertyAsObject));

            actualValues.ShouldAllBeEquivalentTo(expectedValues);

            dynamicTableEntity.Properties["Type"].StringValue.Should().Be(_given.Scope.Type.ToString());
            JsonConvert.DeserializeObject<List<ScopeClaim>>(dynamicTableEntity.Properties["Claims"].StringValue).ShouldAllBeEquivalentTo(_given.Scope.Claims);
            JsonConvert.DeserializeObject<List<Secret>>(dynamicTableEntity.Properties["ScopeSecrets"].StringValue).ShouldAllBeEquivalentTo(_given.Scope.ScopeSecrets);
        }
    }
}