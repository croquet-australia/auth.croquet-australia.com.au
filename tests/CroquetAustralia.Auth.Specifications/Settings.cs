namespace CroquetAustralia.Auth.Specifications
{
    internal static class Settings
    {
        internal static readonly bool IntegrationTests = IsDebug();

        private static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}