using System.Collections.Generic;

namespace CroquetAustralia.Auth.Specifications.Helpers
{
    public class Given
    {
        public Given()
        {
            Users = new List<User>();
            Scope = "read";
        }

        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public IList<User> Users { get; }
        public string Scope { get; set; }
    }
}