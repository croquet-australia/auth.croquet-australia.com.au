using System;
using Anotar.NLog;
using CroquetAustralia.Auth.Infrastructure;
using IdentityModel.Client;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Owin;

namespace CroquetAustralia.Auth.Specifications.Helpers
{
    public static class AuthServer
    {
        public const string BaseUrl = "http://localhost:9000/";
        private const string ConnectUrl = BaseUrl + "connect";

        public const string AuthorizeEndpoint = ConnectUrl + "/authorize";
        public const string LogoutEndpoint = ConnectUrl + "/endsession";
        public const string TokenEndpoint = ConnectUrl + "/token";
        public const string UserInfoEndpoint = ConnectUrl + "/userinfo";
        public const string IdentityTokenValidationEndpoint = ConnectUrl + "/identitytokenvalidation";
        public const string TokenRevocationEndpoint = ConnectUrl + "/revocation";

        private static IDisposable _webApp;

        public static TokenClient GetTokenClient(string clientId, string clientSecret)
        {
            // todo: create and use IClientRepository
            try
            {
                return new TokenClient(TokenEndpoint, clientId, clientSecret);
            }
            catch (Exception exception)
            {
                var message = $"Could not get token client for clientId '{clientId}', clientSecret '{clientSecret}'.";
                var innerException = exception.UnwrapException();
                throw new Exception(message, innerException);
            }
        }

        public static TokenResponse GetTokenResponse(TokenClient client, string emailAddress, string password, string scope)
        {
            LogTo.Debug($"{BaseUrl} Requesting token for emailAddress: '{emailAddress}', password: '{password}', scope: '{scope}'.");
            StartServerIfNotRunning();

            try
            {
                var response = client.RequestResourceOwnerPasswordAsync(emailAddress, password, scope).Result;

                LogTo.Debug($"{BaseUrl} Token resposne for emailAddress: '{emailAddress}', password: '{password}', scope: '{scope}':\n\n{JsonConvert.SerializeObject(response, Formatting.Indented)}");
                return response;
            }
            catch (Exception exception)
            {
                var message = $"{BaseUrl} Could not get token response for emailAddress '{emailAddress}', password '{password}', scope '{scope}'.";
                var innerException = exception.UnwrapException();

                throw new Exception(message, innerException);
            }
        }

        public static void StartServerIfNotRunning()
        {
            if (IsRunning())
            {
                return;
            }
            Start();
        }

        private static void Start()
        {
            _webApp = WebApp.Start(BaseUrl, ConfigureWebApp);
        }

        private static void ConfigureWebApp(IAppBuilder appBuilder)
        {
            const bool requireSsl = false;

            var startup = new Startup();
            var serviceProvider = new ServiceProvider();
            var identityServerOptions = serviceProvider.CreateIdentityServerOptions(requireSsl);

            startup.Configuration(appBuilder, identityServerOptions);
        }

        private static bool IsRunning()
        {
            return _webApp != null;
        }
    }
}