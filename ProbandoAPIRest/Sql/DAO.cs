using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbandoAPIRest.Sql
{
    public class DAO
    {
        private static string conString = "Server=localhost;Database=@bbdd;Uid=@user;Pwd=@password;";
        private static MySqlConnection Connection = null;
        private static DAO accessMysql;
        private static String Bbdd { get; set; } = null;
        private static String user { get; set; } = null;
        private static String password { get; set; } = null;

        public static DAO instance(String Bbdd, String user, String password) {
            try
            { 
                if (accessMysql != null)
                { 
                    if (DAO.Bbdd != Bbdd || DAO.user != user || DAO.password != password)
                    { 
                        Connection.Close();
                        createInstance(Bbdd, user, password);
                        //"Change connection"
                    }
                }
                else
                { 
                    createInstance(Bbdd, user, password);
                    //"new connection"
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al instanciar connection" + ex.Message);
            }

            return accessMysql;
        }

        private static void createInstance(String Bbdd, String user, String password)
        {
            accessMysql = new DAO(Bbdd, user, password);
            DAO.user = user;
            DAO.password = password;
            DAO.Bbdd = Bbdd;

        }

        private DAO(string bbdd, string user, string password)
        {
            try
            {
                var url = DAO.conString.Replace("@bbdd", bbdd);
                url = url.Replace("@user", user);
                url = url.Replace("@password", password);
                Connection = new MySql.Data.MySqlClient.MySqlConnection();
                Connection.ConnectionString = url;
            }
            catch (Exception e)
            {
                throw new Exception("Error al crear connection" + e.Message);
            }
        }

        public MySqlConnection getConnection()
        {
            return Connection;
        }

        public Boolean check()
        {
            if (Connection != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}