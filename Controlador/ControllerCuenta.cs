using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoSena.Modelo;

namespace BancoSena.Controlador
{
    public class ControllerCuenta
    {
        public string error { get; set; }        
        private DatosCuenta objDatosCuenta;

        public ControllerCuenta()
        {
            this.objDatosCuenta = new DatosCuenta();
        }
        /// <summary>
        /// Método crear una cuenta
        /// </summary>
        /// <param name="unaCuenta">Objeto de tipo cuenta</param>
        /// <returns>true o false</returns>
        public bool agregarCuenta(Cuenta unaCuenta)
        {
            this.error = "";
            bool agregada = objDatosCuenta.agregarCuenta(unaCuenta);
            this.error = objDatosCuenta.Error;
            return agregada;
        }
        /// <summary>
        /// Método obtener el consecutivo actual de la cuenta por tipo
        /// </summary>
        /// <param name="tipo">tipo de cuenta 1: Ahorros, 2: Corriente</param>
        /// <returns>consecutivo</returns>
        public int obtenerConsecutivoCuentaPorTipo(int tipo)
        {
            this.error = "";
            int consecutivo = objDatosCuenta.obtenerConsecutivoCuentaPorTipo(tipo);
            this.error = objDatosCuenta.Error;
            return consecutivo;
        }
        /// <summary>
        /// Método que verifica si existe una cuenta de acuerdo a su número
        /// </summary>
        /// <param name="numeroCuenta">Número de cuenta</param>
        /// <returns>True o False</returns>
        public int existeCuentaPorNumero(int numeroCuenta)
        {
            this.error = "";
            int idCuenta = objDatosCuenta.existeCuentaPorNumero(numeroCuenta);
            this.error = objDatosCuenta.Error;
            return idCuenta;
        }
        /// <summary>
        /// Obtener los datos de una cuenta de acuerdo a número de cuenta
        /// </summary>
        /// <param name="numeroCuenta">Número de Cuenta</param>
        /// <returns>Objeto de tipo Cuenta or Null</returns>
        public Cuenta obtenerDatosCuenta(int numeroCuenta)
        {
            this.error = "";
            Cuenta unaCuenta = objDatosCuenta.obtenerDatosCuenta(numeroCuenta);
            this.error = objDatosCuenta.Error;
            return unaCuenta;
        }

        public List<Cuenta> obtenerCuentasPorUsuario(int idUsuario)
        {
            this.error = "";
            List<Cuenta> lista = objDatosCuenta.obtenerCuentasPorUsuario(idUsuario);
            this.error = objDatosCuenta.Error;
            return lista;
        }
    }
}