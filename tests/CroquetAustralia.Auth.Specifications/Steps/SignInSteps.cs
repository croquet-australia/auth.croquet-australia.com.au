using System.Net;
using CroquetAustralia.Auth.Specifications.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CroquetAustralia.Auth.Specifications.Steps
{
    [Binding]
    public class SignInSteps
    {
        private readonly Actual _actual;
        private readonly Given _given;

        public SignInSteps(Given given, Actual actual)
        {
            _given = given;
            _actual = actual;
        }

        [Given(@"email address '(.*)'")]
        public void GivenEmailAddress(string emailAddress)
        {
            _given.EmailAddress = emailAddress;
        }

        [Given(@"password '(.*)'")]
        public void GivenPassword(string password)
        {
            _given.Password = password;
        }

        [Given(@"is registered user")]
        public void GivenIsRegisteredUser()
        {
            _given.Users.Add(new User(_given.EmailAddress, _given.Password));
        }

        [When(@"user signs in with email address and password")]
        public void WhenUserSignsInWithEmailAddressAndPassword()
        {
            const string clientId = "api.croquet-australia.com.au";
            const string clientSecret = "secret";

            var tokenClient = AuthServer.GetTokenClient(clientId, clientSecret);
            _actual.TokenResponse = AuthServer.GetTokenResponse(tokenClient, _given.EmailAddress, _given.Password, _given.Scope);
        }

        [Then(@"the user can successfully get results from a secure webapi endpoint")]
        public void ThenTheUserCanSuccessfullyGetResultsFromASecureWebapiEndpoint()
        {
            var response = DummyWebApiServer.GetResponseMessage(_actual.TokenResponse.AccessToken, "/values");
            var statusCode = response.StatusCode;

            statusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}