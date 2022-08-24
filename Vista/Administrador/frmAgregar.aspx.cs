using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BancoSena.Modelo;
using BancoSena.Controlador;

namespace BancoSena.Vista.Administrador
{
    public partial class frmAgregar : System.Web.UI.Page
    {
        ControllerEmpleado objControllerEmpleado = new ControllerEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregaer_Click(object sender, EventArgs e)
        {
            Empleado unEmpleado = new Empleado();
            unEmpleado.identificacion = "13";
            unEmpleado.nombres = "Pedro";
            unEmpleado.apellidos = "Picapiedra";
            unEmpleado.direccion = "calle Roka";
            unEmpleado.fechaIngreso = Convert.ToDateTime("15-8-2000");
            unEmpleado.correo = "pedroxxxx@picapiedra.com";
            unEmpleado.estado = "Activo";
            unEmpleado.genero = "Masculino";
            unEmpleado.municipio = 1;
            unEmpleado.cargo = "Gerente";
            unEmpleado.telefono = "300555555";
            Rol unRol = new Rol();
            unRol.idRol = 2;
            bool agregado = objControllerEmpleado.agregarEmpleado(unEmpleado, unRol);
            if (agregado)
            {
                lblMensaje.Text = "Empleado Agregado Correctamente";
            }
            else
            {
                lblMensaje.Text = "No se pudo Agregar el Empleado " + objControllerEmpleado.Error;
            }

        }
    }
}