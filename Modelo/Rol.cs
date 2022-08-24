using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoSena.Modelo
{
    public class Rol
    {
        public int idRol { get; set; }
        public string nombre { get; set; }

        public Rol(string nombre)
        {
            this.nombre = nombre;
        }

        public Rol()
        {

        }
    }
}