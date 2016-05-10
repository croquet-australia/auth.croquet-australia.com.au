﻿using FluentAssertions;
using IdentityServer3.AzureTableStorage.Infrastructure.Serializers;
using IdentityServer3.AzureTableStorage.Specifications.Helpers;
using IdentityServer3.Core.Models;
using OpenMagic.Azure.Storage.Table;
using TechTalk.SpecFlow;

namespace IdentityServer3.AzureTableStorage.Specifications.Steps.ScopeSerializer
{
    [Binding]
    public class DeserializeSteps
    {
        private readonly Actual _actual;
        private readonly DummyFactory _dummy;
        private readonly Given _given;
        private readonly IDynamicTableEntitySerializer<Scope> _serializer;

        public DeserializeSteps(Given given, Actual actual, DummyFactory dummy)
        {
            _given = given;
            _actual = actual;
            _dummy = dummy;
            _serializer = DynamicTableEntitySerializers.ScopeSerializer;
        }

        [Given(@"a DynamicTableEntity object from the Scopes table")]
        public void GivenADynamicTableEntityObjectFromTheScopesTable()
        {
            _given.Scope = _dummy.Object<Scope>();
            _given.DynamicTableEntity = _serializer.Serialize(_given.Scope);
        }

        [When(@"ScopeSerializer\.Deserialize\(row\) is called")]
        public void WhenScopeSerializer_DeserializeRowIsCalled()
        {
            _actual.Scope = _serializer.Deserialize(_given.DynamicTableEntity);
        }

        [Then(@"a Scope object should be returned")]
        public void ThenAScopeObjectShouldBeReturned()
        {
            _actual.Scope.Should().NotBeNull();
        }

        [Then(@"the Scope properties should be initialized from the DynamicTableEntity")]
        public void ThenTheScopePropertiesShouldBeInitializedFromTheDynamicTableEntity()
        {
            _actual.Scope.ShouldBeEquivalentTo(_given.Scope);
        }
    }
}