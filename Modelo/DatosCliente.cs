using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BancoSena.Modelo
{
    public class DatosCliente
    {
        public SqlConnection conexion;
        public string error;

        public DatosCliente()
        {
            this.conexion = Conexion.getConexion();
        }
        /// <summary>
        /// Método que agrega un cliente a la base de datos.
        /// El proceso es el siguiente:
        /// 1. Agrega a la tabla personas.
        /// 2. Obtener el id de la persona recien agregada
        /// 3. Agregar a la tabla clientes
        /// 4. Agregar a la tabla usuarios
        /// 5. Obtiene el id del usuario recien creado
        /// 6. Agregar a la tabla usuarioroles
        /// </summary>
        /// <param name="unCliente"> Objeto de tipo Cliente</param>
        /// <param name="unRol">Objeto de Tipo Rol</param>
        /// <returns>True o False</returns>
        public bool agregarCliente(Cliente unCliente, Rol unRol)
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
                comando.Parameters.AddWithValue("@perIdentificacion", unCliente.identificacion);
                comando.Parameters.AddWithValue("@perNombres", unCliente.nombres);
                comando.Parameters.AddWithValue("@perApellidos", unCliente.apellidos);
                comando.Parameters.AddWithValue("@perCorreo", unCliente.correo);
                comando.Parameters.AddWithValue("@perGenero", unCliente.genero);
                comando.Parameters.AddWithValue("@perDireccion", unCliente.direccion);
                comando.Parameters.AddWithValue("@perTelefono", unCliente.telefono);
                comando.Parameters.AddWithValue("@perMunicipio", unCliente.municipio);
                comando.ExecuteNonQuery();//inserta a la base de datos
                //obtener idpersona
                comando.CommandText = "select max(idPersona) from personas";
                unCliente.idpersona = Convert.ToInt32(comando.ExecuteScalar());
                //agregar tabla empleados
                comando.CommandText = "insert into Clientes values(@fechaRegistro,@persona)";
                comando.Parameters.AddWithValue("@fechaRegistro", unCliente.fechaRegistro);             
                comando.Parameters.AddWithValue("@persona", unCliente.idpersona);
                comando.ExecuteNonQuery();
                //agregar tabla usuarios
                comando.CommandText = "insert into usuarios values(@usuUserName,@usuPassword,'Activo',@usuPersona)";
                comando.Parameters.AddWithValue("@usuUserName", unCliente.identificacion);
                comando.Parameters.AddWithValue("@usuPassword", unCliente.identificacion);
                comando.Parameters.AddWithValue("@usuPersona", unCliente.idpersona);
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
            }
            catch (SqlException ex)
            {
                comando.Transaction.Rollback();
                this.error = ex.Message;
            }
            return agregado;
        }

        public List<Cliente> obtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = this.conexion;
                comando.CommandText = "select clientes.idCliente, personas.perIdentificacion," +
                " personas.perNombres,personas.perApellidos from clientes inner join personas " +
                " on clientes.cliPersona=personas.idPersona";
                SqlDataReader registro = comando.ExecuteReader();
                while(registro.Read()){
                    Cliente unCliente = new Cliente();
                    unCliente.idCliente = registro.GetInt32(0);
                    unCliente.identificacion = registro.GetString(1);
                    unCliente.nombres = registro.GetString(2);
                    unCliente.apellidos = registro.GetString(3);
                    listaClientes.Add(unCliente);
                }
                registro.Close();
            }catch(SqlException ex){ 
                this.error = ex.Message;
            }
            return listaClientes;
        }

        public Cliente obtenerClientePorIdentificacion(string identificacion){
            this.error="";
            Cliente unCliente = null; ;
            SqlCommand comando = new SqlCommand();
            try{
                comando.Connection=this.conexion;
                comando.CommandText="select clientes.idCliente, personas.perNombres,personas.perApellidos " +
                " from clientes inner join personas on clientes.cliPersona=personas.idPersona " + 
                " where personas.perIdentificacion=@identifica";
                comando.Parameters.AddWithValue("@identifica",identificacion);
                SqlDataReader registro = comando.ExecuteReader();
                if(registro.Read()){
                    unCliente = new Cliente();
                    unCliente.idCliente = registro.GetInt32(0);                 
                    unCliente.nombres = registro.GetString(1);
                    unCliente.apellidos = registro.GetString(2);
                   
                }
                registro.Close();
            }catch(SqlException ex){
                this.error = ex.Message;
            }
            return unCliente;
        }

        public Cliente obtenerClientePorUsuario(int idUsuario)
        {
            this.error = "";
            Cliente unCliente = null; ;
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = this.conexion;
                comando.CommandText = "select clientes.idCliente, personas.perNombres,personas.perApellidos " +
                " from clientes inner join personas on clientes.cliPersona=personas.idPersona " +
                " inner join usuarios on usuarios.usuPersona=personas.idPersona" +
                " where usuarios.idUsuario=@idUsuario";
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    unCliente = new Cliente();
                    unCliente.idCliente = registro.GetInt32(0);
                    unCliente.nombres = registro.GetString(1);
                    unCliente.apellidos = registro.GetString(2);

                }
                registro.Close();
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return unCliente;
        }
    }
}