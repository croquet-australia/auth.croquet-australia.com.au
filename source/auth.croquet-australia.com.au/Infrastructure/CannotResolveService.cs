using System;

namespace CroquetAustralia.Auth.Infrastructure
{
    internal class CannotResolveService : InvalidOperationException
    {
        internal CannotResolveService(Type serviceType)
            : base($"Cannot resolve service '{serviceType}'. Register service with service provider defined in '{typeof(Startup)}'.")
        {
        }
    }
}