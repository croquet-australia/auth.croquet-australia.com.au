using System;
using System.Net.Http;
using Anotar.LibLog;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;

namespace CroquetAustralia.Auth.Specifications.Helpers
{
    public static class DummyWebApiServer
    {
        public const string BaseAddress = "http://localhost:9001";

        private static IDisposable _webApp;

        public static HttpClient GetClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri(BaseAddress)
            };
        }

        public static HttpResponseMessage GetResponseMessage(string requestUri)
        {
            return GetResponseMessage(null, requestUri);
        }

        public static HttpResponseMessage GetResponseMessage(string token, string requestUri)
        {
            LogTo.Debug($"{BaseAddress}{requestUri} Getting response message with token '{token}'.");

            StartServerIfNotRunning();

            var client = GetClient();

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("todo: ready for future use");
            }

            client.SetBearerToken(token);

            var response = client.GetAsync(requestUri).Result;

            LogTo.Debug($"{BaseAddress}{requestUri} Got response message with token '{token}':\n\n{JsonConvert.SerializeObject(response, Formatting.Indented)}");
            return response;
        }

        public static void StartServerIfNotRunning()
        {
            if (IsRunning())
            {
                return;
            }
            Start();
        }

        private static bool IsRunning()
        {
            return _webApp != null;
        }

        private static void Start()
        {
            _webApp = WebApp.Start(
                BaseAddress,
                appBuilder => { new DummyWebApi.Startup().Configuration(appBuilder, AuthServer.BaseUrl); });
        }
    }
}