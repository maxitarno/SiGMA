<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarCodigoQR.aspx.cs" Inherits="SiGMA.GenerarCodigoQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../../docs-assets/ico/favicon.png">

    <title>SIGMA</title>

    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">


    <!-- Custom styles for this template -->
    <link href="assets/css/main.css" rel="stylesheet">

    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="assets/js/hover.zoom.js"></script>
    <script src="assets/js/hover.zoom.conf.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="centered">   
<div class="panel panel-default">
<div class="panel-heading">
                <h3 class="panel-title">
                   Generar Codigo QR
                </h3>
            </div>
<div class="panel-body"><p class="centered">Seleccione los datos que quiere incluir en el codigo QR</p>
<div style="margin-left: 35%; display: table;width: 40%;">
<div style="display: table-row; width:30%">
    <div style="display: table-cell; width: 20%; text-align: left"> <table> 
<tr><td> <asp:CheckBox ID="chkNombreMascota" runat="server" Text="Nombre de la mascota" 
        AutoPostBack="true" oncheckedchanged="chkNombreMascota_CheckedChanged" /></td>
   </tr>
<tr><td> <asp:CheckBox ID="chkColor" runat="server" Text="Color" 
        AutoPostBack="True" oncheckedchanged="chkColor_CheckedChanged" /></td></tr>
<tr><td> <asp:CheckBox ID="chkRaza" runat="server" Text="Raza" AutoPostBack="True" 
        oncheckedchanged="chkRaza_CheckedChanged" /></td></tr>
<tr><td> <asp:CheckBox ID="chkSexo" runat="server" Text="Sexo" AutoPostBack="True" 
        oncheckedchanged="chkSexo_CheckedChanged" /></td></tr>
        <tr><td> 
            <asp:CheckBox ID="chkNiños" runat="server" Text="Trato con niños" AutoPostBack="True" 
        oncheckedchanged="chkTratoNiños_CheckedChanged" /></td></tr>
        <tr><td> <asp:CheckBox ID="chkAnimales" runat="server" 
                Text="Trato con animales" AutoPostBack="True" 
        oncheckedchanged="chkTratoAnimales_CheckedChanged" /></td></tr>
</table></div>
<div style="width: 20%; display: table-cell; text-align: left">
    <asp:Panel ID="pnlDueño" runat="server">
        <table>
        <tr><td>
            <asp:CheckBox ID="chkNombreDueño" runat="server" 
                Text="Nombre del dueño" AutoPostBack="True" 
        oncheckedchanged="chkNombreDueño_CheckedChanged" /></td></tr>
        <tr><td>
            <asp:CheckBox ID="chkDireccion" runat="server" Text="Direccion" AutoPostBack="True" 
        oncheckedchanged="chkDireccion_CheckedChanged" /></td></tr>
        <tr><td>
            <asp:CheckBox ID="chkEmail" runat="server" Text="Email" AutoPostBack="True" 
        oncheckedchanged="chkEmail_CheckedChanged" /></td></tr>
        <tr><td>
            <asp:CheckBox ID="chkTelefonoCel" runat="server" Text="Telefono Celular" AutoPostBack="True" 
        oncheckedchanged="chkTelefono_CheckedChanged" /></td></tr></table>
    </asp:Panel>
</div>
</div>
</div>
<table style="margin-left: 44%"><tr>
    <td><asp:Image ID="imgQR" runat="server" /></td></tr>
    <tr><td></td></tr>
    <tr>
    <td>
        <asp:Button ID="btnDescargar" runat="server" Text="Descargar" 
            onclick="btnDescargar_Click" Enabled="false" />
        </td>
    </tr></table>  
    </div> 
</div>
    </div>    
</asp:Content>
