using System.Security.Cryptography.X509Certificates;

namespace CroquetAustralia.Auth.Infrastructure.IdentityServer
{
    public interface ICertificateProvider
    {
        X509Certificate2 GetSigningCertificate();
    }
}