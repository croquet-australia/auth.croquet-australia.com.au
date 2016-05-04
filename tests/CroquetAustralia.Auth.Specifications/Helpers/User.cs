namespace CroquetAustralia.Auth.Specifications.Helpers
{
    public class User
    {
        public User(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public string EmailAddress { get; }
        public string Password { get; }
    }
}