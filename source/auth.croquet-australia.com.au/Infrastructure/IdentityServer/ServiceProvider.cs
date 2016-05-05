using System;
using System.Collections.Generic;
using CroquetAustralia.Auth.Infrastructure.AzureTableStorage;
using Ninject;
using Ninject.Modules;
using NullGuard;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    internal class ServiceProvider : IServiceProvider
    {
        private readonly StandardKernel _kernel;

        internal ServiceProvider()
            : this(new[] {new AzureTableStorageModule()})
        {
        }

        internal ServiceProvider(IEnumerable<NinjectModule> ninjectModules)
        {
            var kernel = new StandardKernel();

            kernel.Bind<ICertificateProvider>().To<CertificateProvider>();
            kernel.Load(ninjectModules);

            _kernel = kernel;
        }

        [return: AllowNull]
        object IServiceProvider.GetService(Type serviceType)
        {
            return _kernel.Get(serviceType);
        }
    }
}