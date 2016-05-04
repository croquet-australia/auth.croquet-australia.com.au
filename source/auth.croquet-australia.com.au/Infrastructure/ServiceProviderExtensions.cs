using System;
using System.Diagnostics;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Ninject;

namespace CroquetAustralia.Auth.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static IdentityServerOptions CreateIdentityServerOptions(this IServiceProvider serviceProvider, bool requireSsl = true)
        {
            var options = new IdentityServerOptions
            {
                Factory = new IdentityServerServiceFactory
                {
                    ClientStore = serviceProvider.CreateRegistration<IClientStore>(),
                    ScopeStore = serviceProvider.CreateRegistration<IScopeStore>(),
                    UserService = serviceProvider.CreateRegistration<IUserService>()
                },
                RequireSsl = requireSsl,
                SigningCertificate = serviceProvider.Resolve<ICertificateProvider>().GetSigningCertificate()
            };

            return options;
        }

        internal static Registration<TService> CreateRegistration<TService>(this IServiceProvider serviceProvider) where TService : class
        {
            serviceProvider.EnsureServiceCanBeResolvedWhenBuildConfigurationIsDebug<TService>();

            return new Registration<TService>(dependencyResolver => serviceProvider.Resolve<TService>());
        }

        [Conditional("DEBUG")]
        private static void EnsureServiceCanBeResolvedWhenBuildConfigurationIsDebug<TService>(this IServiceProvider serviceProvider)
        {
            var kernel = serviceProvider as IKernel;
            var canResolve = kernel?.CanResolve<TService>() ?? serviceProvider.GetService(typeof(TService)) != null;

            if (canResolve)
            {
                return;
            }

            throw new CannotResolveService(typeof(TService));
        }

        internal static TService Resolve<TService>(this IServiceProvider serviceProvider) where TService : class
        {
            var service = serviceProvider.GetService(typeof(TService));

            if (service == null)
            {
                throw new CannotResolveService(typeof(TService));
            }

            return (TService) service;
        }
    }
}