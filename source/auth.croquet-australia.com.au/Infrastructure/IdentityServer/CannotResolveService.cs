using System;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    internal class CannotResolveService : InvalidOperationException
    {
        internal CannotResolveService(Type serviceType)
            : base($"Cannot resolve service '{serviceType}'. Register service with service provider defined in '{typeof(Startup)}'.")
        {
        }
    }
}