using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbandoAPIRest.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Edicion { get; set; }
        public string Formato { get; set; }
        public string Tema { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
    }
}