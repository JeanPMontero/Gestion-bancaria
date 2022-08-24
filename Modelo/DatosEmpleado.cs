using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BancoSena.Modelo
{   
    public class DatosEmpleado
    {
        public SqlConnection conexion;
        public string error;
        /// <summary>
        /// Constructor
        /// </summary>
        public DatosEmpleado()
        {
            this.conexion = Conexion.getConexion();
        }
        /// <summary>
        /// /// Método que agrega un empleado a la base de datos.
        /// El proceso es el siguiente:
        /// 1. Agrega a la tabla personas.
        /// 2. Obtener el id de la persona recien agregada
        /// 3. Agregar a la tabla empleados
        /// 4. Agregar a la tabla usuarios
        /// 5. Obtiene el id del usuario recien creado
        /// 6. Agregar a la tabla usuarioroles
        /// </summary>
        /// <param name="unEmpleado"></param>
        /// <param name="unRol"></param>
        /// <returns></returns>
        public bool agregarEmpleado(Empleado unEmpleado, Rol unRol)
        {
            this.error = "";
            bool agregado = false;
            SqlCommand comando = new SqlCommand();            
            try
            {
                comando.Connection = this.conexion;
                comando.Transaction = this.conexion.BeginTransaction();
                //agregar tabla personas
                comando.CommandText = "insert into personas values(@perIdentificacion,@perNombres,@perApellidos,@perCorreo,@perGenero,@perDireccion,@perTelefono,@perMunicipio)";
                comando.Parameters.AddWithValue("@perIdentificacion", unEmpleado.identificacion);
                comando.Parameters.AddWithValue("@perNombres", unEmpleado.nombres);
                comando.Parameters.AddWithValue("@perApellidos", unEmpleado.apellidos);
                comando.Parameters.AddWithValue("@perCorreo", unEmpleado.correo);
                comando.Parameters.AddWithValue("@perGenero", unEmpleado.genero);
                comando.Parameters.AddWithValue("@perDireccion", unEmpleado.direccion);
                comando.Parameters.AddWithValue("@perTelefono", unEmpleado.telefono);
                comando.Parameters.AddWithValue("@perMunicipio", unEmpleado.municipio);
                comando.ExecuteNonQuery();//inserta a la base de datos
                //obtener idpersona
                comando.CommandText = "select max(idPersona) from personas";
                unEmpleado.idpersona = Convert.ToInt32(comando.ExecuteScalar());
                //agregar tabla empleados
                comando.CommandText = "insert into empleados values(@empCargo,@empFechaIngreso,'Activo',@empPersona)";
                comando.Parameters.AddWithValue("@empCargo", unEmpleado.cargo);
                comando.Parameters.AddWithValue("@empFechaIngreso", unEmpleado.fechaIngreso);
                comando.Parameters.AddWithValue("@empPersona", unEmpleado.idpersona);
                comando.ExecuteNonQuery();
                //agregar tabla usuarios
                comando.CommandText = "insert into usuarios values(@usuUserName,@usuPassword,'Activo',@usuPersona)";
                comando.Parameters.AddWithValue("@usuUserName", unEmpleado.identificacion);
                comando.Parameters.AddWithValue("@usuPassword", unEmpleado.identificacion);
                comando.Parameters.AddWithValue("@usuPersona", unEmpleado.idpersona);
                comando.ExecuteNonQuery();
                //obtener el id del usuario
                comando.CommandText = "select max(idUsuario) from usuarios";
                int idUsuario = Convert.ToInt32(comando.ExecuteScalar());                
                //Agregar tabla UsuariosRoles
                comando.CommandText = "insert into usuarioroles values(@usuario,@rol)";
                comando.Parameters.AddWithValue("@usuario", idUsuario);
                comando.Parameters.AddWithValue("@rol", unRol.idRol);
                comando.ExecuteNonQuery();
                //la siguiente linea es la que acepta las operaciones anteriores
                comando.Transaction.Commit();
                agregado = true;
            }catch(SqlException ex){
                comando.Transaction.Rollback();
                this.error = ex.Message;
            }
            return agregado;
        }
    }
}