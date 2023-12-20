using ProbandoAPIRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbandoAPIRest.Sql
{
    public class DTO_Tema : GetConnectionDAO
    {
        public DTO_Tema()
        {
            
        }

        public List<Tema> getTemas()
        {
            var listaTemas = new List<Tema>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getTemas()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var tema = new Tema();
                    tema.Id = reader.GetFieldValue<int>(0);
                    tema.Nombre = reader.GetFieldValue<string>(1);
                    listaTemas.Add(tema);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
            return listaTemas;
        }
    }
}