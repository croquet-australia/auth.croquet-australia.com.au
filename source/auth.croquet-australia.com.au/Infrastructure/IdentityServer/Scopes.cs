using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    internal class Scopes
    {
        /// <summary>
        ///     Get the <see cref="Scope">scopes</see> this identity server serves.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Scopes are identifiers for resources that a client wants to access.
        ///         This identifier is sent to the OP during an authentication or token
        ///         request.
        ///     </para>
        ///     <para>
        ///         By default every client is allowed to request tokens for every
        ///         scope, but you can restrict that.
        ///     </para>
        ///     <para>
        ///         They come in two flavours.
        ///     </para>
        ///     <para>
        ///         Identity scopes
        ///         ---------------
        ///         Requesting identity information (aka claims) about a user, e.g. his
        ///         name or email address is modeled as a scope in OpenID Connect.
        ///         There is e.g. a scope called profile that includes first name,
        ///         last name, preferred username, gender, profile picture and more.
        ///         You can read about the standard scopes here and you can create your
        ///         own scopes in IdentityServer to model your own requirements.
        ///     </para>
        ///     <para>
        ///         Resource scopes
        ///         ---------------
        ///         Resource scopes identify web APIs (also called resource servers)
        ///         - you could have e.g. a scope named calendar that represents your
        ///         calendar API.
        ///     </para>
        /// </remarks>
        internal static IEnumerable<Scope> Get()
        {
            yield return StandardScopes.Email;

            yield return new Scope
            {
                Name = "read",
                DisplayName = "Read data",
                Type = ScopeType.Resource,
                Emphasize = false,
                ScopeSecrets = new List<Secret>
                {
                    new Secret("secret".Sha256()) // todo: make it a real secret and keep it secret
                }
            };
        }
    }
}