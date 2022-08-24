using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoSena.Modelo
{
    public class Cliente:Persona
    {
        public DateTime fechaRegistro { get; set; }
        public int idCliente { get; set; }
        /// <summary>
        /// Constructor clase Cliente
        /// </summary>
        /// <param name="identificacion">Número documento identidad</param>
        /// <param name="nombres">Nombre del cliente</param>
        /// <param name="apellidos">Apellidos del cliente</param>
        /// <param name="correo">Correo Electrónico del Cliente</param>
        /// <param name="genero">Femenino o Masculino</param>
        /// <param name="direccion">Direccion postal</param>
        /// <param name="telefono">Número telefono o celular</param>
        /// <param name="municipio">código de municipio</param>
        public Cliente(string identificacion, string nombres,
            string apellidos, string correo, string genero,
            string direccion, string telefono, int municipio)
            : base(identificacion, nombres, apellidos, correo, genero,
            direccion, telefono, municipio)
        {
            this.fechaRegistro = DateTime.Now.Date;
        }

        public Cliente()
        {

        }
    }
}