<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEjemploReportes.aspx.cs" Inherits="BancoSena.Vista.Administrador.FrmEjemploReportes" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BancoSenaConnectionString %>" SelectCommand="SELECT * FROM [vistaCuentas]"></asp:SqlDataSource>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="869px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Vista\Administrador\Report6.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSetEjemplo" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
