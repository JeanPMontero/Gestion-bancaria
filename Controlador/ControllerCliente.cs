using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoSena.Modelo;

namespace BancoSena.Controlador
{
    public class ControllerCliente
    {
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        DatosCliente objDatosCliente;

        public ControllerCliente()
        {
            objDatosCliente = new DatosCliente();
        }
        /// <summary>
        /// Método agregar cliente que recibe datos de la vista y los pasa y recibe datos del Modelo
        /// </summary>
        /// <param name="unCliente">Objeto de tipo cliente</param>
        /// <param name="unRol">Objeto de tipo Rol</param>
        /// <returns>True o False</returns>
        public bool agregarCliente(Cliente unCliente, Rol unRol)
        {
            this.error = "";
            bool agregado = objDatosCliente.agregarCliente(unCliente, unRol);
            this.error = objDatosCliente.error;
            return agregado;
        }

        public List<Cliente> obtenerClientes()
        {
            this.error = "";
            List<Cliente> lista = objDatosCliente.obtenerClientes();
            this.error = objDatosCliente.error;
            return lista;
        }

        public Cliente obtenerClientePorIdentificacion(string identificacion)
        {
            this.error = "";
            Cliente unCliente = objDatosCliente.obtenerClientePorIdentificacion(identificacion);
            this.error = objDatosCliente.error;
            return unCliente;
        }

        public Cliente obtenerClientePorUsuario(int idUsuario)
        {
            this.error = "";
            Cliente unCliente = objDatosCliente.obtenerClientePorUsuario(idUsuario);
            this.error = objDatosCliente.error;
            return unCliente;
        }

    }
}

/*
public class ControllerCliente {

	private string error;
	private DatosCliente objDatosCliente;



	~ControllerCliente(){

	}

	public ControllerCliente(){

	}

	public string Error{
		get;
		set;
	}

	/// 
	/// <param name="unCliente"></param>
	/// <param name="unRol"></param>
	public bool agregarCliente(Cliente unCliente, Rol unRol){

		return false;
	}

}//end ControllerCliente*/