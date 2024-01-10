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
        private DAO_Tema DAO = new DAO_Tema();

        [HttpGet]
        [Route("temas-controller")]
        public List<Tema> getTemas()
        {
            return DAO.getTemas();
        }

        [HttpPut]
        [Route("temas-controller")]
        public Response putTema(Request request)
        {
            return DAO.putTemas(request);
        }

        [HttpPost]
        [Route("temas-controller")]
        public Response postTema(Request request)
        {
            return DAO.postTema(request);
        }

        [HttpDelete]
        [Route("temas-controller")]
        public Response deleteTema(Request request)
        {
            return DAO.deleteTema(request);
        }

    }
}
