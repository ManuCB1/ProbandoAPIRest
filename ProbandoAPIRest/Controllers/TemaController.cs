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
        //Peticiones a https://localhost:44371/api/tema/temas-controller
        [HttpGet]
        [Route("temas-controller")]
        public string putTemas()
        {
            return "Insertando Tema con su EndPoint";
        }
        [HttpPost]
        [Route("temas-controller")]
        public string getTema()
        {
            return "Actualizar Temas";
        }

        [HttpDelete]
        [Route("temas-controller")]
        public string deleteTema()
        {
            return "Borrar Tema";
        }

    }
}
