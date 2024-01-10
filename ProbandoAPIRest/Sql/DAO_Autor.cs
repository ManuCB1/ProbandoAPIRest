using ProbandoAPIRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbandoAPIRest.Sql
{
    public class DAO_Autor : GetConnectionDAO
    {
        public DAO_Autor()
        {
        }

        public List<Autor> getAutores()
        {
            var listaAutores = new List<Autor>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getAutores()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var autor = new Autor();
                    autor.Id = reader.GetFieldValue<int>(0);
                    autor.Nombre = reader.GetFieldValue<string>(1);
                    listaAutores.Add(autor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
            return listaAutores;
        }

        public Response putAutor(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call putAutor(@id, '@nombre')";
                sql = sql.Replace("@id", request.Id.ToString());
                sql = sql.Replace("@nombre", request.Nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Autor actualizado correctamente.";

                var autor = new Autor();
                autor.Id = request.Id;
                autor.Nombre = request.Nombre;
                response.Data = autor;

            }
            catch (Exception ex)
            {
                response.Error = "Error al actualizar." + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }

        public Response postAutor(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call postAutor('@nombre')";
                sql = sql.Replace("@nombre", request.Nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Autor añadido correctamente.";
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

        public Response deleteAutor(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call deleteAutor(@id)";
                sql = sql.Replace("@id", request.Id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Autor eliminado con éxito.";

            }
            catch (Exception ex)
            {
                response.Error = "Error al eliminar Autor: " + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }

    }
}