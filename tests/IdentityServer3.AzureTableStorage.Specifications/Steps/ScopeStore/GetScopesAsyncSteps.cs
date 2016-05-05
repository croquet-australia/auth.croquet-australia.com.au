using System;
using TechTalk.SpecFlow;

namespace IdentityServer3.AzureTableStorage.Specifications.Steps.ScopeStore
{
    [Binding]
    public class GetScopesAsyncSteps
    {
        [Given(@"scope table has scopes:")]
        public void GivenScopeTableHasScopes(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"publicOnly is true")]
        public void GivenPublicOnlyIsTrue()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"todo")]
        public void GivenTodo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"ScopeStore\.GetScopesAsync\((.*)\) is called")]
        public void WhenScopeStore_GetScopesAsyncIsCalled(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should scopes:")]
        public void ThenTheResultShouldScopes(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
