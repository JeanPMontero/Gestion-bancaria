using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace BancoSena.Modelo
{
    public class DatosCuenta
    {
        private SqlConnection conexion;
        private string error;
                
        /// <summary>
        /// Constructor clase DatosCuenta
        /// </summary>
        public DatosCuenta()
        {
            this.conexion = Conexion.getConexion();
        }

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        /// <summary>
        /// Método agregar una cuenta
        /// </summary>
        /// <param name="unaCuenta">Objeto de tipo Cuenta</param>
        /// <returns>True o False</returns>
        public bool agregarCuenta(Cuenta unaCuenta)
        {
            this.error = "";
            bool agregada = false;
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = this.conexion;
                comando.Transaction=this.conexion.BeginTransaction();
                //procesa agregar tabla cuenta
                comando.CommandText = "insert into cuentas values" +
                "(@numeroCuenta,@cliente,@tipo,@saldo,@fecha,@estado)";
                comando.Parameters.AddWithValue("@numeroCuenta", unaCuenta.numeroCuenta);
                comando.Parameters.AddWithValue("@cliente", unaCuenta.unCliente.idCliente);
                comando.Parameters.AddWithValue("@tipo", unaCuenta.tipoCuenta);
                comando.Parameters.AddWithValue("@saldo", unaCuenta.saldo);
                comando.Parameters.AddWithValue("@fecha", unaCuenta.fechaCreacion);
                comando.Parameters.AddWithValue("@estado", unaCuenta.estado);
                comando.ExecuteNonQuery();
                //proceso actualizar tabla consecutivoscuentas
                if (unaCuenta.tipoCuenta == 1)
                {
                    comando.CommandText = "update consecutivocuentas set conCuentaAhorro=ConcuentaAhorro+1";
                }
                else
                {
                    comando.CommandText = "update consecutivocuentas set conCuentaCorriente=ConcuentaCorriente+1";
                }
                comando.ExecuteNonQuery();
                comando.Transaction.Commit();
                agregada = true;
            }catch(SqlException ex){
                this.error = ex.Message;
                comando.Transaction.Rollback();
            }
            return agregada;
        }

        public List<Cuenta> obtenerCuentasPorUsuario(int idUsuario)
        {
            this.error = "";
            Cuenta unaCuenta = null;
            List<Cuenta> listaCuentas = new List<Cuenta>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader registro = null;
            try
            {
                comando.Connection = this.conexion;
                comando.CommandText = "select cuentas.*, personas.perNombres, personas.perApellidos, personas.perCorreo " +
                " from cuentas inner join clientes on cuentas.cueCliente = clientes.idCliente" +
                " inner join personas on clientes.cliPersona=personas.idPersona" +
                " inner join  usuarios on usuarios.usuPersona=personas.idPersona" +
                " where usuarios.idUsuario=@idUsuario";
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    unaCuenta = new Cuenta();
                    unaCuenta.idCuenta = registro.GetInt32(0);
                    unaCuenta.numeroCuenta = registro.GetInt32(1);
                    unaCuenta.unCliente.idCliente = registro.GetInt32(2);
                    unaCuenta.tipoCuenta = registro.GetInt32(3);
                    unaCuenta.saldo = registro.GetInt32(4);
                    unaCuenta.fechaCreacion = registro.GetDateTime(5);
                    unaCuenta.estado = registro.GetString(6);
                    unaCuenta.unCliente.nombres = registro.GetString(7);
                    unaCuenta.unCliente.apellidos = registro.GetString(8);
                    unaCuenta.unCliente.correo = registro.GetString(9);
                    listaCuentas.Add(unaCuenta);
                }
                registro.Close();

            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
           // registro.Close();
            return listaCuentas;
        }

        /// <summary>
        /// Método que permite obtener el consecutivo actual de números de cuenta
        /// de acuerdo al tipo de cuenta. 
        /// </summary>
        /// <param name="tipo">Tipo de Cuenta. 1: Ahorro, 2: Corriente</param>
        /// <returns>Consecutivo de cuenta actual</returns>
        public int obtenerConsecutivoCuentaPorTipo(int tipo)
        {
            this.error = "";
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = this.conexion;
                if (tipo == 1)
                {
                    comando.CommandText = "select conCuentaAhorro from consecutivocuentas";
                }
                else
                {
                    comando.CommandText = "select conCuentaCorriente from consecutivocuentas";
                }
                int consecutivo = Convert.ToInt32(comando.ExecuteScalar());
                return consecutivo;
            }catch(SqlException ex){
                this.error = ex.Message;
                return 0;
            }
        }
        /// <summary>
        /// Método que devuelve el idCuenta de acuerdo a número de cuenta
        /// </summary>
        /// <param name="numeroCuenta">Número de cuenta</param>
        /// <returns>IdCuenta si existe o 0 sino existe</returns>
        public int existeCuentaPorNumero(int numeroCuenta)
        {
            this.error = "";          
            int idCuenta = 0;
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            try
            {              
                comando.CommandText = "select idCuenta from cuentas where cueNumero=@numeroCuenta";
                comando.Parameters.AddWithValue("@numeroCuenta", numeroCuenta);
                idCuenta = Convert.ToInt32(comando.ExecuteScalar());                        
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;               
            }
            return idCuenta;
        }

        public Cuenta obtenerDatosCuenta(int numeroCuenta)
        {
            this.error = "";
            Cuenta unaCuenta = null;
            SqlCommand comando = new SqlCommand();
            SqlDataReader registro = null;            
            try
            {
                comando.Connection = this.conexion;
                comando.CommandText = "select cuentas.*, personas.perNombres, personas.perApellidos, personas.perCorreo " +
                " from cuentas inner join clientes on cuentas.cueCliente = clientes.idCliente" +
                " inner join personas on clientes.cliPersona=personas.idPersona where cueNumero=@numeroCuenta";
                comando.Parameters.AddWithValue("@numeroCuenta", numeroCuenta);
                registro = comando.ExecuteReader();                
                if (registro.Read())
                {
                    unaCuenta = new Cuenta();
                    unaCuenta.idCuenta = registro.GetInt32(0);
                    unaCuenta.numeroCuenta = registro.GetInt32(1);
                    unaCuenta.unCliente.idCliente = registro.GetInt32(2);
                    unaCuenta.tipoCuenta = registro.GetInt32(3);
                    unaCuenta.saldo = registro.GetInt32(4);
                    unaCuenta.fechaCreacion = registro.GetDateTime(5);
                    unaCuenta.estado = registro.GetString(6);
                    unaCuenta.unCliente.nombres = registro.GetString(7);
                    unaCuenta.unCliente.apellidos = registro.GetString(8);
                    unaCuenta.unCliente.correo = registro.GetString(9);
                }
                registro.Close();

            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            registro.Close();
            return unaCuenta;
        }
    }
}