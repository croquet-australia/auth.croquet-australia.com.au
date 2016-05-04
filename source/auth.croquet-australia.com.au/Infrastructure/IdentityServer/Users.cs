using System.Collections.Generic;
using IdentityServer3.Core.Services.InMemory;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    internal static class Users
    {
        /// <summary>
        ///     Get the list of registered users.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         A user is a human that is using a registered client to access his or her data.
        ///     </para>
        ///     <para>
        ///         Source: https://identityserver.github.io/Documentation/docsv2/overview/terminology.html
        ///     </para>
        /// </remarks>
        internal static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>(new[]
            {
                new InMemoryUser
                {
                    Subject = "dummy@example.com",
                    Username = "dummy@example.com",
                    Password = "dummy password"
                }
            });
        }
    }
}