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
    [RoutePrefix("api/autor")]
    public class AutorController : ApiController
    {
        //Peticiones a https://localhost:44371/api/autor/autor-controller
        private DTO_Autor DTO = new DTO_Autor();

        [HttpGet]
        [Route("autor-controller")]
        public List<Autor> getAutores()
        {
            return DTO.getAutores();
        }

        [HttpPut]
        [Route("autor-controller")]
        public Response putAutor(Request request)
        {
            return DTO.putAutor(request);
        }

        [HttpPost]
        [Route("autor-controller")]
        public Response postAutor(Request request)
        {
            return DTO.postAutor(request);
        }

        [HttpDelete]
        [Route("autor-controller")]
        public Response deleteAutor(Request request)
        {
            return DTO.deleteAutor(request);
        }

    }
    }
