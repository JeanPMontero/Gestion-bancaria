using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoSena.Modelo
{
    public class Transaccion
    {
        public int tipo { get; set; }
        public Cliente unCliente { get; set; }
        public Cuenta cuentaOrigen { get; set; }
        public Cuenta cuentaDestino { get; set; }
        public DateTime fecha { get; set; }
        public int valor { get; set; }

        /// <summary>
        /// Constructor con parámetros de inicialización
        /// </summary>
        /// <param name="tipo">Tipo de Transacción: 1: Crear 2: Consignar 3: Retirar 4: Transferir 5: Cancelar</param>
        /// <param name="unCliente">Objeto de Tipo Cliente</param>
        /// <param name="cuentaOrigen">Objeto de Tipo Cuenta</param>
        /// <param name="cuentaDestino">Objeto de Tipo Cuenta</param>
        /// <param name="valor">Valor de la Trnsacción</param>
        public Transaccion(int tipo, Cliente unCliente, Cuenta cuentaOrigen,
            Cuenta cuentaDestino, int valor)
        {
            this.tipo = tipo;
            this.unCliente = unCliente;
            this.cuentaDestino = cuentaDestino;
            this.cuentaOrigen = cuentaOrigen;
            this.valor = valor;
            this.fecha = DateTime.Now.Date;
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Transaccion()
        {
            this.fecha = DateTime.Now.Date;
            this.unCliente = new Cliente();
            this.cuentaOrigen = new Cuenta();
            this.cuentaDestino = new Cuenta();
            this.valor = 0;
        }
    }
}