using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sprint.SESAT.IDMSample.WebApi.Controller
{
    public class SampleController : ApiController
    {
        [Authorize]
        // GET: api/Sample
        public IEnumerable<string> Get()
        {
            var isAuth = User.Identity.IsAuthenticated;
            var userName = User.Identity.Name;

            return new string[] { "value1", "value2" };
        }
    }
}
