using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    internal static class Clients
    {
        /// <summary>
        ///     Get the list clients (applications) this identity server serves
        ///     tokens.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         A client is a piece of software that requests tokens from
        ///         IdentityServer - either for authenticating a user or for accessing
        ///         a resource (also often called a relying party or RP). A client
        ///         must be registered with the OpenID Connect Provider (OP).
        ///     </para>
        ///     <para>
        ///         Examples for clients are web applications, native mobile or desktop
        ///         applications, SPAs, server processes etc.
        ///     </para>
        ///     <para>
        ///         Source: https://identityserver.github.io/Documentation/docsv2/overview/terminology.html
        ///     </para>
        /// </remarks>
        internal static IEnumerable<Client> Get()
        {
            yield return new Client
            {
                ClientId = "api.croquet-australia.com.au",
                ClientSecrets = new List<Secret> {new Secret("secret".Sha256())}, // todo: create real secret and keep it secret!
                AllowedScopes = new List<string> {"email", "read"},
                Enabled = true,
                Flow = Flows.ResourceOwner
            };
        }
    }
}