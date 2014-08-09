<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarPermisos.aspx.cs" Inherits="SiGMA.AsignarPermisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID=HeadContent runat=server>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID=MainContent runat=server>
     <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Asignar permisos a usuarios</h3>
        </div>
        <div class="panel-body">
            <div class="almedio">
            <asp:Panel ID="pnlUsuario" runat="server">
            <%--busqueda del usuario asignar permisos--%>
            </asp:Panel>
                <asp:Panel ID="pnlPermisos" runat="server" Visible="false">
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
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
                            <td>
                                <asp:CheckBox ID="chkConsultarUsuarioL" runat="server" /></td>
                            <td><asp:CheckBox ID="chkConsultarUsuarioG" runat="server" /></td>
                            <td><asp:CheckBox ID="chkConsultarUsuarioE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>RegistrarUsuario</td>
                            <td><asp:CheckBox ID="chkRegistrarUsuarioL" runat="server" /></td>
                            <td><asp:CheckBox ID="chkRegistrarUsuarioG" runat="server" /></td>
                            <td><asp:CheckBox ID="chkRegistrarUsuarioE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>AsignarPermisos</td>
                            <td><asp:CheckBox ID="chkAsignarPermisosL" runat="server" /></td>
                            <td><asp:CheckBox ID="chkAsignarPermisosG" runat="server" /></td>
                            <td><asp:CheckBox ID="chkAsignarPermisosE" runat="server" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                
            </div>
        </div>
    </div>
</asp:Content>
