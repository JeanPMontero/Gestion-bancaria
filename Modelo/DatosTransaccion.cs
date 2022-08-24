using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BancoSena.Modelo
{
    public class DatosTransaccion
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        public string error { get; set; }
        public DatosTransaccion()
        {
            this.conexion = Conexion.getConexion();
        }
        /// <summary>
        /// Método agregar la transacción
        /// </summary>
        /// <param name="unaTransaccion">Objeto Transacción</param>
        private void agregarTransaccion(Transaccion unaTransaccion)
        {
            this.error = "";          
            try
            {
                comando.Connection = this.conexion;
                comando.CommandText = "insert into transacciones values " +
                    "(@tipo,@cliente,@cuentaOrigen,@cuentaDestino,@valor1,@fecha)";
                comando.Parameters.AddWithValue("@tipo", unaTransaccion.tipo);
                comando.Parameters.AddWithValue("@cliente", unaTransaccion.unCliente.idCliente);
                comando.Parameters.AddWithValue("@cuentaOrigen", unaTransaccion.cuentaOrigen.idCuenta);
                comando.Parameters.AddWithValue("@cuentaDestino", unaTransaccion.cuentaDestino.idCuenta);
                comando.Parameters.AddWithValue("@valor1", unaTransaccion.valor);
                comando.Parameters.AddWithValue("@fecha", unaTransaccion.fecha);
                comando.ExecuteNonQuery();               
            }catch(SqlException ex){
                this.error = ex.Message;
            }           
        }
        /// <summary>
        /// Método consignar
        /// </summary>
        /// <param name="unaTransaccion">Objeto tipo transacción</param>
        /// <returns>True o False</returns>
        public bool consignar(Transaccion unaTransaccion)
        {
            this.error = "";
            bool consignado = false;
            comando = new SqlCommand();
            try
            {
                comando.Connection = this.conexion;
                comando.Transaction = this.conexion.BeginTransaction();
                //actualizar saldo tabla cuentas
                comando.CommandText = "update cuentas set cueSaldo= cueSaldo + @valor " +
                    " where idCuenta=@idCuenta";
                comando.Parameters.AddWithValue("@valor", unaTransaccion.valor);
                comando.Parameters.AddWithValue("@idCuenta", unaTransaccion.cuentaOrigen.idCuenta);
                comando.ExecuteNonQuery();
                //agregar la transaccion llamar al método agregarTransaccion
                agregarTransaccion(unaTransaccion);
                comando.Transaction.Commit();
                consignado = true;
            }
            catch (SqlException ex)
            {
                comando.Transaction.Rollback();
                this.error = ex.Message;
            }
            return consignado;
        }
        /// <summary>
        /// Método retirar de un cuenta
        /// </summary>
        /// <param name="unaTransaccion">Objeto tipo YTransacción</param>
        /// <returns>True o False</returns>
        public bool retirar(Transaccion unaTransaccion)
        {
            this.error = "";
            bool retirado = false;
            comando = new SqlCommand();
            try
            {
                comando.Connection = this.conexion;
                comando.Transaction = this.conexion.BeginTransaction();
                //actualizar saldo tabla cuentas
                comando.CommandText = "update cuentas set cueSaldo= cueSaldo - @valor " +
                    " where idCuenta=@idCuenta";
                comando.Parameters.AddWithValue("@valor", unaTransaccion.valor);
                comando.Parameters.AddWithValue("@idCuenta", unaTransaccion.cuentaOrigen.idCuenta);
                comando.ExecuteNonQuery();
                //agregar la transaccion llamar al método agregarTransaccion
                agregarTransaccion(unaTransaccion);
                comando.Transaction.Commit();
                retirado = true;
            }
            catch (SqlException ex)
            {
                comando.Transaction.Rollback();
                this.error = ex.Message;
            }
            return retirado;
        }

        public bool transferir(Transaccion unaTransaccion)
        {
            this.error = "";
            bool transfirio = false;
            comando = new SqlCommand();
            try
            {
                comando.Connection = this.conexion;
                comando.Transaction = this.conexion.BeginTransaction();
                //actualizar saldo tabla cuenta Origen
                comando.CommandText = "update cuentas set cueSaldo= cueSaldo - @valor " +
                    " where idCuenta=@idCuentaOrigen";
                comando.Parameters.AddWithValue("@valor", unaTransaccion.valor);
                comando.Parameters.AddWithValue("@idCuentaOrigen", unaTransaccion.cuentaOrigen.idCuenta);
                comando.ExecuteNonQuery();
                //actualizar saldo tabla cuenta Destino
                comando.Parameters.Clear();
                comando.CommandText = "update cuentas set cueSaldo= cueSaldo + @valor" +
                    " where idCuenta=@idCuentaDestino";
                comando.Parameters.AddWithValue("@valor", unaTransaccion.valor);
                comando.Parameters.AddWithValue("@idCuentaDestino", unaTransaccion.cuentaDestino.idCuenta);
                comando.ExecuteNonQuery();
                //agregar la transaccion llamar al método agregarTransaccion
                agregarTransaccion(unaTransaccion);
                comando.Transaction.Commit();
                transfirio = true;
            }
            catch (SqlException ex)
            {
                comando.Transaction.Rollback();
                this.error = ex.Message;
            }
            return transfirio;
        }
    }
}