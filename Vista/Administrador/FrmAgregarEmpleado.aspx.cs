using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BancoSena.Controlador;
using BancoSena.Modelo;

namespace BancoSena.Vista.Administrador
{
    public partial class FrmAgregarEmpleado : System.Web.UI.Page
    {
        ControllerGestionBanco objControllerGestionBanco = new ControllerGestionBanco();
        ControllerEmpleado objControllerEmpleado = new ControllerEmpleado();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("../../frmIniciarSesion.aspx?x=1");
            }
            if (IsPostBack == false) { 
            cbDepartamentos.DataSource = objControllerGestionBanco.obtenerDepartamentos();
            cbDepartamentos.DataTextField = "depNombre";
            cbDepartamentos.DataValueField = "iDdepartamento";
            cbDepartamentos.DataBind(); 
                }
        }

        protected void cbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32(cbDepartamentos.SelectedValue);
            lblMensaje.Text = "Valor: " + idDepartamento.ToString();
            cbMunicipios.DataSource = objControllerGestionBanco.obtenerMunicipiosByIdDepartamento(idDepartamento);
            cbMunicipios.DataTextField = "munNombre";
            cbMunicipios.DataValueField = "idMunicipio";
            cbMunicipios.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Empleado unEmpleado = new Empleado();
            unEmpleado.identificacion = txtIdentificacion.Text;
            unEmpleado.nombres = txtNombres.Text;
            unEmpleado.apellidos = txtApellidos.Text;
            unEmpleado.direccion = txtDireccion.Text;
            unEmpleado.correo = txtCorreo.Text;
            unEmpleado.genero = cbGenero.SelectedValue;
            unEmpleado.telefono = txtTelefono.Text;
            unEmpleado.cargo = cbCargos.SelectedValue;
            unEmpleado.fechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);
            unEmpleado.municipio = Convert.ToInt32(cbMunicipios.SelectedValue);
            Rol unRol = new Rol();
            unRol.idRol = Convert.ToInt32(cbRol.SelectedValue);

            bool agregado = objControllerEmpleado.agregarEmpleado(unEmpleado, unRol);
            if (agregado)
            {
                lblMensaje.Text = "Empleado agregado correctamente";
            }
            else
            {
                lblMensaje.Text = "Problemas al agregar el empleado " + objControllerEmpleado.Error;
            }
        }

    }
}