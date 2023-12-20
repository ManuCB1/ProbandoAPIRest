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

        public Response putTemas(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call putTema('@nombre')";
                sql = sql.Replace("@nombre", request.Nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Tema añadido correctamente.";
            }
            catch (Exception ex)
            { 
                response.Error = "Error al insertar: " + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }

        public Response postTema(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call postTema(@id, '@nombre')";
                sql = sql.Replace("@id", request.Id.ToString());
                sql = sql.Replace("@nombre", request.Nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Tema actualizado correctamente.";

                var tema = new Tema();
                tema.Id = request.Id;
                tema.Nombre = request.Nombre;
                response.Data = tema;

            }
            catch(Exception ex)
            {
                response.Error = "Error al actualizar." + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }

        public Response deleteTema(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call deleteTema(@id)";
                sql = sql.Replace("@id", request.Id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Tema eliminado con éxito.";

            }
            catch (Exception ex)
            {
                response.Error = "Error al eliminar Tema: " + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }


    }
}