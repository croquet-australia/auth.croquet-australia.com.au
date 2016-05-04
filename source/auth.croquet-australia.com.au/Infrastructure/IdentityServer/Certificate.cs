using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    public class Certificate
    {
        public static X509Certificate2 Get()
        {
            const string password = "idsrv3test";
            var resourceName = $"{GetNamespace()}.idsrv3test.pfx";

            var assembly = Assembly.GetAssembly(typeof(Certificate));

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

        private static string GetNamespace()
        {
            var type = typeof(Certificate);
            return type.FullName.Substring(0, type.FullName.Length - type.Name.Length - 1);
        }
    }
}