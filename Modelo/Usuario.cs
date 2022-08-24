using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoSena.Modelo
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string estado { get; set; }
        public Persona unaPersona { get; set; }
        public Rol unRol { get; set; }
        /// <summary>
        /// Método constructor clase Usuario
        /// </summary>
        public Usuario()
        {
            unaPersona = new Persona();
            unRol = new Rol();
        }
    }
}