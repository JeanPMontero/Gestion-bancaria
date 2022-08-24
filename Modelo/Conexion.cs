using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BancoSena.Modelo
{
    public class Conexion
    {
        private static SqlConnection objConexion;
        private static string error;
        
        public static SqlConnection getConexion()
        {
            if (objConexion != null)
                return objConexion;
            objConexion = new SqlConnection();
            objConexion.ConnectionString = "Server=DESKTOP-3MCJA1S\\SQLSERVER;Database=BancoSena;Trusted_Connection=True;";
            try
            {
                objConexion.Open();
                return objConexion;
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }
        }
        
        public static void cerrarConexion()
        {
            if (objConexion != null)
                objConexion.Close();
        }
    }
}