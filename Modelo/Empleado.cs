using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoSena.Modelo
{
    public class Empleado: Persona
    {
        public int idEmpleado { get; set; }
        public string cargo { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string estado { get; set; }
        /// <summary>
        /// Constructor clase Empleado
        /// </summary>
        /// <param name="identificacion">Número documento identidad</param>
        /// <param name="nombres">Nombre del Empleado</param>
        /// <param name="apellidos">Apellidos del Empleado</param>
        /// <param name="correo">Correo Electrónico del Empleado</param>
        /// <param name="genero">Femenino o Masculino</param>
        /// <param name="direccion">Direccion postal</param>
        /// <param name="telefono">Número telefono o celular</param>
        /// <param name="municipio">código de municipio</param>
        public Empleado(string cargo, DateTime fechaIngreso,
            string identificacion, string nombres,
            string apellidos, string correo, string genero,
            string direccion, string telefono, int municipio)
            :base(identificacion,nombres,apellidos,correo,genero,
            direccion,telefono, municipio)
        {
            this.cargo = cargo;
            this.fechaIngreso = fechaIngreso;
            this.estado = "Activo";
        }
        public Empleado()
        {

        }
    }
}