<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmReportesCuentas.aspx.cs" Inherits="BancoSena.Vista.Administrador.FrmReportesCuentas" %>

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
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="427px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="874px">
            <LocalReport ReportPath="Vista\Administrador\Report5.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    
    </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BancoSenaConnectionString %>" SelectCommand="SELECT * FROM [vistaClientesPorFecha]"></asp:SqlDataSource>
    </form>
</body>
</html>
