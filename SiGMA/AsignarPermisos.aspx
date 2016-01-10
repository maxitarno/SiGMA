<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="AsignarPermisos.aspx.cs" Inherits="SiGMA.AsignarPermisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .centering{
        float:none;
        margin:0 auto
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/asignarrolMini.png" />
                    <h1>Asignar Permisos /</h1>
                    <p>El control de acceso permite mantener coherencia por roles</p>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-4 col-md-offset-4">
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-sm-8 col-sm-offset-2 contact-form">
            <asp:Panel ID="pnlRol" runat="server">
                <label for="contact-name">Seleccione un Rol</label><br />
                <asp:DropDownList ID="ddlRol" runat="server" 
                    onselectedindexchanged="ddlRol_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true"> 
                </asp:DropDownList>
                <br /><br />
            </asp:Panel>
                <asp:Panel ID="pnlPermisos" runat="server" Visible="false">
                    <label for="contact-name"><asp:Label ID="lblRol" runat="server" Text="" CssClass="pagination-centered"></asp:Label></label>
                    <br /><br />
                    <table border="2px" cellpadding="2" cellspacing="3" style="font-size:medium; text-align:center">
                        <tr style="font-weight:bold; color:#9D426B">
                            <td width="300">Pantallas</td>
                            <td width="300">Visualización</td>
                            <td width="300">Grabación</td>
                            <td width="300">Eliminación</td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">Administración</td>
                            <td align="center"><asp:CheckBox ID="chkAdministracionL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAdministracionG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAdministracionE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">RolesPermisos</td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">ConsutarUsuarios</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarUsuarioE" runat="server" /></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold;">ConsultarMascotas</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarMascotasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarMascotasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarMascotasE" runat="server" /></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold;">RegistrarMascotas</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarMascotasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarMascotasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarMascotasE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">ConsultarPerdidas</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarPerdidasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarPerdidasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarPerdidasE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">RegistrarPerdidas</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarPerdidasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarPerdidasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarPerdidasE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">ConsultarHallazgos</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarHallazgosL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarHallazgosG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarHallazgosE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">RegistrarHallazgos</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarHallazgosL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarHallazgosG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarHallazgosE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">ConsultarAdopciones</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarAdopcionesL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarAdopcionesG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarAdopcionesE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">RegistrarAdopciones</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarAdopcionesL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarAdopcionesG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarAdopcionesE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">Veterinarias</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarVeterinariaL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarVeterinariaG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarVeterinariaE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">Voluntariado</td>
                            <td align="center"><asp:CheckBox ID="chkVoluntariadoL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkVoluntariadoG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkVoluntariadoE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">Campañas</td>
                            <td align="center"><asp:CheckBox ID="chkCampañasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkCampañasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkCampañasE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">PedidosDifusion</td>
                            <td align="center"><asp:CheckBox ID="chkDifusionL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkDifusionG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkDifusionE" runat="server" /></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                        onclick="btnGuardar_Click" Width="180px"/>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
