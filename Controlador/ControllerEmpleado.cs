using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoSena.Modelo;

namespace BancoSena.Controlador
{
    public class ControllerEmpleado
    {
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        DatosEmpleado objDatosEmpleado;

        public ControllerEmpleado()
        {
            objDatosEmpleado = new DatosEmpleado();
        }
        /// <summary>
        /// Método que recibe de la vista un empleado para ser agregado
        /// </summary>
        /// <param name="unEmpleado">Objeto de tipo Empleado</param>
        /// <returns>Booleano True o False</returns>
        public bool agregarEmpleado(Empleado unEmpleado, Rol unRol)
        {
            this.error = "";
            bool agregado = objDatosEmpleado.agregarEmpleado(unEmpleado, unRol);
            this.error = objDatosEmpleado.error;
            return agregado;
        }
    }
}