using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoSena.Modelo;

namespace BancoSena.Controlador
{
    public class ControllerTransaccion
    {
        public string error { get; set; }        
        private DatosTransaccion objDatosTransaccion;

        public ControllerTransaccion()
        {
            this.objDatosTransaccion = new DatosTransaccion();
        }
        /// <summary>
        /// Método que permite consignar
        /// </summary>
        /// <param name="unaTransaccion">Objeto tipo Transaccion</param>
        /// <returns>True o False</returns>
        public bool consignar(Transaccion unaTransaccion)
        {
            this.error = "";
            bool consignado = objDatosTransaccion.consignar(unaTransaccion);
            this.error = objDatosTransaccion.error;
            return consignado;
        }

        /// <summary>
        /// Método retirar. Recibe y devuelve datos de la vista
        /// </summary>
        /// <param name="unaTransaccion">Objeto de tipo Transacion</param>
        /// <returns>True o False</returns>
        public bool retirar(Transaccion unaTransaccion)
        {
            this.error = "";
            bool retirado = objDatosTransaccion.retirar(unaTransaccion);
            this.error = objDatosTransaccion.error;
            return retirado;
        }

        /// <summary>
        /// Método transferir Recibe y devuelve datos de la vista
        /// </summary>
        /// <param name="unaTransaccion">Objeto Transaccion</param>
        /// <returns>True o False</returns>
        public bool transferir(Transaccion unaTransaccion)
        {
            this.error = "";
            bool transfirio = objDatosTransaccion.transferir(unaTransaccion);
            this.error = objDatosTransaccion.error;
            return transfirio;
        }
    }
}