using TechTalk.SpecFlow;

namespace IdentityServer3.AzureTableStorage.Specifications.Steps.ScopeStore
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"todo")]
        public void GivenTodo()
        {
            ScenarioContext.Current.Pending();
        }
    }
}