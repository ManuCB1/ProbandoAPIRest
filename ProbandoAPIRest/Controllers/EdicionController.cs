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
    [RoutePrefix("api/edicion")]
    public class EdicionController : ApiController
    {
        //Peticiones a https://localhost:44371/api/edicion/edicion-controller
        private DAO_Edicion DAO = new DAO_Edicion();

        [HttpGet]
        [Route("edicion-controller")]
        public List<Edicion> getEdiciones()
        {
            return DAO.getEdiciones();
        }

        [HttpPut]
        [Route("edicion-controller")]
        public Response putEdicion(Request request)
        {
            return DAO.putEdicion(request);
        }

        [HttpPost]
        [Route("edicion-controller")]
        public Response postEdicion(Request request)
        {
            return DAO.postEdicion(request);
        }

        [HttpDelete]
        [Route("edicion-controller")]
        public Response deleteEdicion(Request request)
        {
            return DAO.deleteEdicion(request);
        }
    }
}
