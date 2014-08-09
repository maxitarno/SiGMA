<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarPermisos.aspx.cs" Inherits="SiGMA.AsignarPermisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Asignar permisos a usuarios</h3>
        </div>
        <div class="panel-body">
            <div class="almedio">
            <asp:Panel ID="pnlRol" runat="server">
                <%--ddlRol para que elija el rol que desea modificarle los permisos--%>
                <asp:DropDownList ID="ddlRol" runat="server" 
                    onselectedindexchanged="ddlRol_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true"> 
                    <asp:ListItem Value="0" Text="---Seleccione un rol ---"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </asp:Panel>
                <asp:Panel ID="pnlPermisos" runat="server" Visible="false">
                    <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <table>
                        <tr>
                            <td>Pantallas</td>
                            <td>Visualizacion</td>
                            <td>Grabacion</td>
                            <td>Eliminacion</td>
                        </tr>
                        <tr>
                            <td>ConsutarUsuario</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>RegistrarUsuario</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarUsuarioL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarUsuarioG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarUsuarioE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>AsignarPermisos</td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosE" runat="server" /></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                        onclick="btnGuardar_Click" />
                </asp:Panel>
                
            </div>
        </div>
    </div>
</asp:Content>
