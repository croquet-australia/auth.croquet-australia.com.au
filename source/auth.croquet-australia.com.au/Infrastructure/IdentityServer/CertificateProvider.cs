using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    internal class CertificateProvider : ICertificateProvider
    {
        public X509Certificate2 GetSigningCertificate()
        {
            const string password = "idsrv3test";

            var certificateProvider = typeof(CertificateProvider);
            var resourceName = $"{GetNamespace(certificateProvider)}.idsrv3test.pfx";
            var assembly = Assembly.GetAssembly(certificateProvider);

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new Exception($"Could not read certificate '{resourceName}'.");
                }

                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return new X509Certificate2(buffer, password);
            }
        }

        private static string GetNamespace(Type type)
        {
            return type.FullName.Substring(0, type.FullName.Length - type.Name.Length - 1);
        }
    }
}