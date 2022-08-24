using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoSena.Modelo
{
    public class Persona
    {
        public int idpersona { get; set; }
        public string identificacion { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string genero { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int municipio { get; set; }

        /// <summary>
        /// Constructor clase Persona
        /// </summary>
        /// <param name="identificacion">Número documento identidad</param>
        /// <param name="nombres">Nombre de la persona</param>
        /// <param name="apellidos">Apellidos de la Persona</param>
        /// <param name="correo">Correo Electrónico de la persona</param>
        /// <param name="genero">Femenino o Masculino</param>
        /// <param name="direccion">Direccion postal</param>
        /// <param name="telefono">Número telefono o celular</param>
        /// <param name="municipio">código de municipio</param>
        public Persona(string identificacion, string nombres,
            string apellidos, string correo, string genero,
            string direccion, string telefono, int municipio)
        {
            this.identificacion = identificacion;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.correo = correo;
            this.genero = genero;
            this.direccion = direccion;
            this.telefono = telefono;
            this.municipio = municipio;
        }

        public Persona()
        {

        }
    }
}