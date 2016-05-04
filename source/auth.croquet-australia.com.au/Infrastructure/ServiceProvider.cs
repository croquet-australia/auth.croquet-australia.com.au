using System;
using Ninject;
using NullGuard;

namespace CroquetAustralia.Auth.Infrastructure
{
    internal class ServiceProvider : IServiceProvider
    {
        private readonly StandardKernel _kernel;

        internal ServiceProvider()
        {
            var kernel = new StandardKernel();

            kernel.Bind<ICertificateProvider>().To<CertificateProvider>();

            _kernel = kernel;
        }

        [return: AllowNull]
        object IServiceProvider.GetService(Type serviceType)
        {
            return _kernel.Get(serviceType);
        }
    }
}