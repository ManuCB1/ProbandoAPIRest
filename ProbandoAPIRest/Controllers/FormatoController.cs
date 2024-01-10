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
    [RoutePrefix("api/formato")]
    public class FormatoController : ApiController
    {
        //Peticiones a https://localhost:44371/api/formato/formato-controller
        private DAO_Formato DAO = new DAO_Formato();


        [HttpGet]
        [Route("formato-controller")]
        public List<Formato> getFormatos()
        {
            return DAO.getFormatos();
        }

        [HttpPut]
        [Route("formato-controller")]
        public Response putFormato(Request request)
        {
            return DAO.putFormato(request);
        }

        [HttpPost]
        [Route("formato-controller")]
        public Response postFormato(Request request)
        {
            return DAO.postFormato(request);
        }

        [HttpDelete]
        [Route("formato-controller")]
        public Response deleteFormato(Request request)
        {
            return DAO.deleteFormato(request);
        }
    }
}
