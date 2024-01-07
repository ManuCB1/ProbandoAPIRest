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
        private DTO_Edicion DTO = new DTO_Edicion();

        [HttpGet]
        [Route("edicion-controller")]
        public List<Edicion> getEdiciones()
        {
            return DTO.getEdiciones();
        }

        [HttpPut]
        [Route("edicion-controller")]
        public Response putEdicion(Request request)
        {
            return DTO.putEdicion(request);
        }

        [HttpPost]
        [Route("edicion-controller")]
        public Response postEdicion(Request request)
        {
            return DTO.postEdicion(request);
        }

        [HttpDelete]
        [Route("edicion-controller")]
        public Response deleteEdicion(Request request)
        {
            return DTO.deleteEdicion(request);
        }
    }
}
