using ProbandoAPIRest.Models;
using ProbandoAPIRest.Sql;
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
        private DTO_Tema DTO = new DTO_Tema();

        [HttpGet]
        [Route("temas-controller")]
        public List<Tema> getTemas()
        {
            return DTO.getTemas();
        }
        [HttpPost]
        [Route("temas-controller")]
        public string putTema()
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
