using ProbandoAPIRest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ProbandoAPIRest.Sql
{
    public class DAO_Libro : GetConnectionDAO
    {
        public DAO_Libro() { }

        public List<Libro> getLibros()
        {
            var listaLibros = new List<Libro>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getLibros()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var libro = new Libro();
                    libro.Id = reader.GetFieldValue<int>(0);
                    libro.Nombre = reader.GetFieldValue<string>(1);
                    libro.Isbn = reader.GetFieldValue<string>(2);
                    libro.Tema = reader.GetFieldValue<string>(3);
                    libro.Formato = reader.GetFieldValue<string>(4);
                    libro.Autor = reader.GetFieldValue<string>(5);
                    libro.Edicion = reader.GetFieldValue<string>(6);
                    libro.Precio = reader.GetFieldValue<decimal>(7);
                    libro.Cantidad = reader.GetFieldValue<int>(8);
                    libro.Imagen = reader.GetFieldValue<string>(9);
                    listaLibros.Add(libro);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
            return listaLibros;
        }

        public Response putLibro(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call putLibro('@isbn', '@nombre', @autor, @edicion, @formato, @tema, '@precio', '@url_imagen')";
                sql = sql.Replace("@isbn", request.Isbn);
                sql = sql.Replace("@nombre", request.Nombre);
                sql = sql.Replace("@autor", request.Autor);
                sql = sql.Replace("@edicion", request.Edicion);
                sql = sql.Replace("@formato", request.Formato);
                sql = sql.Replace("@tema", request.Tema);
                sql = sql.Replace("@precio", request.Precio);
                sql = sql.Replace("@url_imagen", request.Imagen);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Libro actualizado correctamente.";

                var libro = new Libro();
                //libro.Id = request.Id;
                libro.Isbn = request.Isbn;
                libro.Nombre = request.Nombre;
                libro.Autor = request.Autor;
                libro.Edicion = request.Edicion;
                libro.Formato = request.Formato;
                libro.Tema = request.Tema;
                libro.Precio = decimal.Parse(request.Precio, CultureInfo.InvariantCulture);
                libro.Imagen = request.Imagen;
                response.Data = libro;

            }
            catch (Exception ex)
            {
                response.Error = "Error al actualizar." + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }

        public Response postLibro(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call postLibro('@isbn', '@nombre', @autor, @edicion, @formato, @tema, '@precio', @cantidad, '@url_imagen')";
                sql = sql.Replace("@isbn", request.Isbn);
                sql = sql.Replace("@nombre", request.Nombre);
                sql = sql.Replace("@autor", request.Autor);
                sql = sql.Replace("@edicion", request.Edicion);
                sql = sql.Replace("@formato", request.Formato);
                sql = sql.Replace("@tema", request.Tema);
                sql = sql.Replace("@precio", request.Precio);
                sql = sql.Replace("@url_imagen", request.Imagen);
                if (request.Cantidad == 0)
                {
                    request.Cantidad = 1;
                }
                sql = sql.Replace("@cantidad", request.Cantidad.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Libro añadido correctamente.";
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

        public Response deleteLibro(Request request)
        {
            var response = new Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @"call deleteLibro('@isbn')";
                sql = sql.Replace("@isbn", request.Isbn);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.OK = "Libro eliminado con éxito.";

            }
            catch (Exception ex)
            {
                response.Error = "Error al eliminar Libro: " + ex.Message;
            }
            finally { connection.Close(); }
            return response;
        }


    }
}