<%@ Page Title="" Language="C#" CodeBehind="FrmReportes.aspx.cs" Inherits="BancoSena.Vista.Administrador.FrmReportes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
        
         <br />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="BancoSena.BancoSenaDataSetTableAdapters.vistaClientesTableAdapter"></asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BancoSenaConnectionString %>" SelectCommand="SELECT * FROM [vistaClientes]"></asp:SqlDataSource>
    <rsweb:ReportViewer ID="report" runat="server" Width="744px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Vista\Administrador\Report1.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
</rsweb:ReportViewer>

</form>
    
</body>
</html>
