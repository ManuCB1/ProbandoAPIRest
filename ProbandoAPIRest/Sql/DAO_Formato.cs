using ProbandoAPIRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbandoAPIRest.Sql
{
    public class DAO_Formato : GetConnectionDAO
    {
        public DAO_Formato()
        {
        }

        public List<Formato> getFormatos()
        {
            var listaFormatos = new List<Formato>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getFormatos()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var formato = new Formato();
                    formato.Id = reader.GetFieldValue<int>(0);
                    formato.Nombre = reader.GetFieldValue<string>(1);
                    listaFormatos.Add(formato);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
            return listaFormatos;
        }

        public Response putFormato(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call putFormato(@id, '@nombre')";
                sql = sql.Replace("@id", request.Id.ToString());
                sql = sql.Replace("@nombre", request.Nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Formato actualizado correctamente.";

                var formato = new Formato();
                formato.Id = request.Id;
                formato.Nombre = request.Nombre;
                response.Data = formato;

            }
            catch (Exception ex)
            {
                response.Error = "Error al actualizar." + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }

        public Response postFormato(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call postFormato('@nombre')";
                sql = sql.Replace("@nombre", request.Nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Formato añadido correctamente.";
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

        public Response deleteFormato(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call deleteFormato(@id)";
                sql = sql.Replace("@id", request.Id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Formato eliminado con éxito.";

            }
            catch (Exception ex)
            {
                response.Error = "Error al eliminar Formato: " + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }
    }
}