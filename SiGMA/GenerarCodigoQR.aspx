<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarCodigoQR.aspx.cs" Inherits="SiGMA.GenerarCodigoQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel-body"><div class="almedio"> <table> 
<tr><td> <asp:CheckBox ID="chkNombreMascota" runat="server" Text="Nombre" 
        AutoPostBack="true" oncheckedchanged="chkNombreMascota_CheckedChanged" /></td>
   </tr>
<tr><td> <asp:CheckBox ID="chkColor" runat="server" Text="Color" 
        AutoPostBack="True" oncheckedchanged="chkColor_CheckedChanged" /></td></tr>
<tr><td> <asp:CheckBox ID="chkRaza" runat="server" Text="Raza" AutoPostBack="True" 
        oncheckedchanged="chkRaza_CheckedChanged" /></td></tr>
<tr><td> <asp:CheckBox ID="chkSexo" runat="server" Text="Sexo" AutoPostBack="True" 
        oncheckedchanged="chkSexo_CheckedChanged" /></td></tr>
<tr>
    <td><asp:Image ID="imgQR" runat="server" /></td></tr>
</table>
    
</div>
</div>
</asp:Content>
