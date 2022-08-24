using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BancoSena.Modelo
{
    public class DatosUsuario
    {
        private SqlConnection conexion;
        public string error ;

        public DatosUsuario()
        {
            this.conexion = Conexion.getConexion();
        }
        
        public Usuario iniciarSesion(Usuario unUsuario)
        {
            this.error = "";
            SqlCommand comando = new SqlCommand();
            Usuario usuRetorno = null;
            try
            {
                comando.Connection = this.conexion;
                comando.CommandText = "select usuarios.*, personas.perNombres, personas.perApellidos, " +
                " roles.rolNombre from usuarios inner join personas on usuarios.usuPersona=personas.idPersona " +
                " inner join usuarioroles on usuarioroles.usuUsuario=usuarios.idUsuario " +
                " inner join roles on usuarioroles.usuRol = roles.idRol " +
                " where usuarios.usuUserName=@login and usuarios.usuPassword=@password " +
                " and usuarios.usuEstado='Activo'";
                comando.Parameters.AddWithValue("@login", unUsuario.userName);
                comando.Parameters.AddWithValue("@password", unUsuario.password);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    usuRetorno = new Usuario();
                    usuRetorno.idUsuario = registro.GetInt32(0);
                    usuRetorno.unaPersona.idpersona = registro.GetInt32(4);
                    usuRetorno.unaPersona.nombres = registro.GetString(5);
                    usuRetorno.unaPersona.apellidos = registro.GetString(6);
                    usuRetorno.unRol.nombre = registro.GetString(7);
                }
                registro.Close();
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return usuRetorno;
        }
    }
}