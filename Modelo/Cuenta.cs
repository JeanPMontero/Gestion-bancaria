using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoSena.Modelo
{
    public class Cuenta
    {
        public int idCuenta { get; set; }
        public int tipoCuenta { get; set; }
        public int numeroCuenta { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
        public Cliente unCliente { get; set; }
        public int saldo { get; set; }
        /// <summary>
        /// Constructor clase cuenta
        /// </summary>
        /// <param name="numeroCuenta">Número de la cuenta</param>
        /// <param name="tipoCuenta">tipo: 1: Ahorros, 2: Corriente</param>
        /// <param name="unCliente">Objeto tipo Cliente</param>
        /// <param name="saldo">Saldo inicial al crear la cuenta</param>
        public Cuenta(int numeroCuenta, int tipoCuenta, Cliente unCliente,
            int saldo)
        {
            this.numeroCuenta = numeroCuenta;
            this.tipoCuenta = tipoCuenta;
            this.unCliente = unCliente;
            this.fechaCreacion = DateTime.Now.Date;
            this.saldo = saldo;
            this.estado = "Activa";
        }

        public Cuenta()
        {
            this.unCliente = new Cliente();
        }
    }
}