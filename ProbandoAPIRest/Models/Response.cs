using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbandoAPIRest.Models
{
    public class Response
    {
        public String OK { get; set; }
        public String Error { get; set; }
        public Object Data { get; set; }
    }
}