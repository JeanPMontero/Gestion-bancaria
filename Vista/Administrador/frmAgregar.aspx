<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAgregar.aspx.cs" Inherits="BancoSena.Vista.Administrador.frmAgregar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnAgregaer" runat="server" OnClick="btnAgregaer_Click" Text="Agregar" />
    
    </div>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
