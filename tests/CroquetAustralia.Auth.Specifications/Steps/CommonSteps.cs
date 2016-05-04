using TechTalk.SpecFlow;

namespace CroquetAustralia.Auth.Specifications.Steps
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