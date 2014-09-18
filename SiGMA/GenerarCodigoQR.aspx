<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarCodigoQR.aspx.cs" Inherits="SiGMA.GenerarCodigoQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel panel-primary">
<div class="panel-heading">
                <h1 class="panel-title">
                   Generar Codigo QR
                </h1>
            </div>
<div class="panel-body"><p>Seleccione los datos que quiere reflejar en el codigo QR</p>
<div style="margin-left: 35%; display: table;width: 40%;">
<div style="display: table-row; width:30%">
    <div style="display: table-cell; width: 20%;"> <table> 
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
<div style="width: 20%; display: table-cell;">
    <asp:Panel ID="pnlDueño" runat="server">
        <table>
        <tr><td>
            <asp:CheckBox ID="chkNombreDueño" runat="server" 
                Text="Nombre y apellido del dueño" AutoPostBack="True" 
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
<div class="almedio"><table><tr>
    <td><asp:Image ID="imgQR" runat="server" /></td></tr>
    <tr><td></td></tr>
    <tr>
    <td>
        <asp:Button ID="btnDescargar" runat="server" Text="Descargar" 
            onclick="btnDescargar_Click" Enabled="false" />
        </td>
    </tr></table></div>    
    </div>
</div>
</asp:Content>
