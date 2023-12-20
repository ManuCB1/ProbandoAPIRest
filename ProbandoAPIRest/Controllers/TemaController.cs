using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProbandoAPIRest.Controllers
{
    [RoutePrefix("api/tema")]
    public class TemaController : ApiController
    {
        [HttpGet]
        [Route("getTemas")]
        public List<string> get()
        {
            return new List<string> { "Terror", "Romance", "Aventura"};
        }

    }
}
