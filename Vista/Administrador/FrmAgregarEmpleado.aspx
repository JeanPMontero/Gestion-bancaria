<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="FrmAgregarEmpleado.aspx.cs" Inherits="BancoSena.Vista.Administrador.FrmAgregarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/footer.css" rel="stylesheet" />
    <link href="../../Css/form.css" rel="stylesheet" />
    <link href="../../Css/header.css" rel="stylesheet" />
    <link href="../../Css/index.css" rel="stylesheet" />
    <link href="../../Css/nav.css" rel="stylesheet" />
    <link href="../../Css/template.css" rel="stylesheet" />
    <script src="../../Recursos/Librerias/Jquery/external/jquery/jquery.js"></script>
    <script src="../../Recursos/Librerias/Jquery/jquery-ui.js"></script>
    <script src="../../Recursos/Librerias/Jquery/jquery-ui.min.js"></script>
    <link href="../../Recursos/Librerias/Jquery/jquery-ui.css" rel="stylesheet" />
    <link href="../../Recursos/Librerias/Jquery/jquery-ui.min.css" rel="stylesheet" />
    <script src="../../Js/index.js"></script>

    <style type="text/css">
        .auto-style1 {
            width: 50%;
            border-style: solid;
            border-width: 1px;
        }
        .auto-style2 {
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <table align="center" class="auto-style1">
        <tr>
            <td style="text-align: center">AGREGAR EMPLEADO</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtIdentificacion" runat="server" Width="367px" 
                    placeholder="Ingrese aquí # de Identificación" TextMode="Number" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtNombres" runat="server" Width="369px"
                 placeholder="Ingrese sus Nombre" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtApellidos" runat="server" Width="369px"
                 placeholder="Ingrese sus Apellidos" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtCorreo" runat="server" Width="369px"
                 placeholder="Ingrese su Correo Electrónico" TextMode="Email" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="cbGenero" runat="server" Width="366px">
                    <asp:ListItem>Femenino</asp:ListItem>
                    <asp:ListItem>Masculino</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server" Width="369px"
                 placeholder="Ingrese su Dirección Postal" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" Width="369px"
                 placeholder="Ingrese número de Telefono-Celular" TexMode="Number" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="cbDepartamentos" runat="server" Width="366px" OnSelectedIndexChanged="cbDepartamentos_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="cbMunicipios" runat="server" Width="366px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="cbCargos" runat="server" Width="366px">
                    <asp:ListItem>Gerente</asp:ListItem>
                    <asp:ListItem>Cajero</asp:ListItem>
                    <asp:ListItem>Jefe de Credito</asp:ListItem>
                    <asp:ListItem>Auxiliar</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="txtFechaIngreso" runat="server" Width="369px"
                 placeholder="Seleccione Fecha" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="cbRol" runat="server" Width="366px">
                    <asp:ListItem Value="1">Administrador</asp:ListItem>
                    <asp:ListItem Value="2">Cajero</asp:ListItem>
                    <asp:ListItem Value="3">Cliente</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            </td>
        </tr>
    </table>
    <p>
    <br>

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>


</asp:Content>
