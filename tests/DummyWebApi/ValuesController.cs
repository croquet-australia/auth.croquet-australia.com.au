using System.Collections.Generic;
using System.Web.Http;

namespace DummyWebApi
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET <controller>
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET <controller>/5
        public string Get(int id)
        {
            return "value";
        }
    }
}