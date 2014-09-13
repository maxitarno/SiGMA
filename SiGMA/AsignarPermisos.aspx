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
            <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible=false>
                <button class="close" type="button" data-dismiss="alert">
                    ×</button>
                    <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible=false>
                <button class="close" type="button" data-dismiss="alert">
                    ×</button>
                    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                <button class="close" type="button" data-dismiss="alert">
                    ×</button>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlRol" runat="server">
                <asp:DropDownList ID="ddlRol" runat="server" 
                    onselectedindexchanged="ddlRol_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true"> 
                </asp:DropDownList>
                <br />
                <br />
            </asp:Panel>
                <asp:Panel ID="pnlPermisos" runat="server" Visible="false">
                    <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <table border="1px">
                        <tr>
                            <td width="300">Pantallas</td>
                            <td width="300">Visualización</td>
                            <td width="300">Grabación</td>
                            <td width="300">Eliminación</td>
                        </tr>
                        <tr>
                            <td>Administración</td>
                            <td align="center"><asp:CheckBox ID="chkAdministracionL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAdministracionG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAdministracionE" runat="server" /></td>
                        </tr>
                         <tr>
                            <td>ConsultarMascotas</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarMascotasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarMascotasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarMascotasE" runat="server" /></td>
                        </tr>
                         <tr>
                            <td>RegistrarMascotas</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarMascotasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarMascotasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarMascotasE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td >ConsutarUsuarios</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>RegistrarUsuarios</td>
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
                        onclick="btnGuardar_Click" class="btn-primary"/>
                </asp:Panel>
                
            </div>
        </div>
    </div>
</asp:Content>
