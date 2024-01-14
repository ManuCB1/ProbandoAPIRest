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
    [RoutePrefix("api/libro")]
    public class LibrosController : ApiController
    {
        //Peticiones a https://localhost:44371/api/libro/libro-controller
        private DAO_Libro DAO = new DAO_Libro();

        [HttpGet]
        [Route("libro-controller")]
        public List<Libro> getLibros()
        {
            return DAO.getLibros();
        }

        [HttpPut]
        [Route("libro-controller")]
        public Response putLibro(Request request)
        {
            return DAO.putLibro(request);
        }

        [HttpPost]
        [Route("libro-controller")]
        public Response postLibro(Request request)
        {
            return DAO.postLibro(request);
        }

        [HttpDelete]
        [Route("libro-controller")]
        public Response deleteLibro(Request request)
        {
            return DAO.deleteLibro(request);
        }
    }
}
