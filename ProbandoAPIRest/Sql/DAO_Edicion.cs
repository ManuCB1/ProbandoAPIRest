using ProbandoAPIRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbandoAPIRest.Sql
{
    public class DAO_Edicion : GetConnectionDAO
    {
        public DAO_Edicion()
        {
        }

        public List<Edicion> getEdiciones()
        {
            var listaEdiciones = new List<Edicion>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getEdiciones()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var edicion = new Edicion();
                    edicion.Id = reader.GetFieldValue<int>(0);
                    edicion.Nombre = reader.GetFieldValue<string>(1);
                    listaEdiciones.Add(edicion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
            return listaEdiciones;
        }

        public Response putEdicion(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call putEdicion(@id, '@nombre')";
                sql = sql.Replace("@id", request.Id.ToString());
                sql = sql.Replace("@nombre", request.Nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Edición actualizado correctamente.";

                var edicion = new Edicion();
                edicion.Id = request.Id;
                edicion.Nombre = request.Nombre;
                response.Data = edicion;

            }
            catch (Exception ex)
            {
                response.Error = "Error al actualizar." + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }

        public Response postEdicion(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call postEdicion('@nombre')";
                sql = sql.Replace("@nombre", request.Nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Edición añadido correctamente.";
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

        public Response deleteEdicion(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call deleteEdicion(@id)";
                sql = sql.Replace("@id", request.Id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Edición eliminado con éxito.";

            }
            catch (Exception ex)
            {
                response.Error = "Error al eliminar Edición: " + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }

    }
}