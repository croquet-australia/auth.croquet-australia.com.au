using System;
using System.Collections.Generic;
using CroquetAustralia.Auth.Infrastructure;
using CroquetAustralia.Auth.Specifications.Helpers.IdentityServer;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;

namespace CroquetAustralia.Auth.Specifications.Helpers
{
    internal class ServiceProvider : IServiceProvider
    {
        private readonly Dictionary<Type, Func<object>> _services;

        public ServiceProvider()
        {
            _services = new Dictionary<Type, Func<object>>
            {
                {typeof(ICertificateProvider), () => new CertificateProvider()},
                {typeof(IClientStore), () => new InMemoryClientStore(Clients.Get())},
                {typeof(IScopeStore), () => new InMemoryScopeStore(Scopes.Get())},
                {typeof(IUserService), () => new InMemoryUserService(Users.Get())}
            };
        }

        public object GetService(Type serviceType)
        {
            Func<object> serviceFactory;

            return _services.TryGetValue(serviceType, out serviceFactory) ? serviceFactory() : null;
        }
    }
}