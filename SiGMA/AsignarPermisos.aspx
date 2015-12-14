<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarPermisos.aspx.cs" Inherits="SiGMA.AsignarPermisos" %>
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
    <style>
    .centering{
        float:none;
        margin:0 auto
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="conteiner fluid">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h3 class="panel-title centered">
                Asignar permisos a usuarios</h3>
        </div>

    <div class="panel panel-default">
        <div class="panel-body">
                <div class="col-md-2 col-md-offset-5">
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
                </div>
        </div>
    </div>

    <div class="panel-body">
        <div class="col-md-2 col-md-offset-5">
            <asp:Panel ID="pnlRol" runat="server">
                <asp:DropDownList ID="ddlRol" runat="server" 
                    onselectedindexchanged="ddlRol_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true"> 
                </asp:DropDownList>
                <br />
            </asp:Panel>
        </div>
    </div>

    <div class="panel-body">
        <div class="col-md-4 col-md-offset-4">
                <asp:Panel ID="pnlPermisos" runat="server" Visible="false">
                    <asp:Label ID="lblRol" runat="server" Text="" CssClass="pagination-centered"></asp:Label>
                    <br />
                    <table border="2px">
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
<%--                        <tr>
                            <td>RegistrarUsuarios</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarUsuarioL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarUsuarioG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarUsuarioE" runat="server" /></td>
                        </tr>--%>
                        <tr>
                            <td>AsignarPermisos</td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkAsignarPermisosE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td >ConsultarPerdidas</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarPerdidasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarPerdidasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarPerdidasE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>RegistrarPerdidas</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarPerdidasL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarPerdidasG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarPerdidasE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>ConsultarHallazgos</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarHallazgosL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarHallazgosG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarHallazgosE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>RegistrarHallazgos</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarHallazgosL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarHallazgosG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarHallazgosE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>ConsultarAdopciones</td>
                            <td align="center"><asp:CheckBox ID="chkConsultarAdopcionesL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarAdopcionesG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkConsultarAdopcionesE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>RegistrarAdopciones</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarAdopcionesL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarAdopcionesG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarAdopcionesE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>RegistrarVeterinaria</td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarVeterinariaL" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarVeterinariaG" runat="server" /></td>
                            <td align="center"><asp:CheckBox ID="chkRegistrarVeterinariaE" runat="server" /></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                        onclick="btnGuardar_Click"/>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
</div>
</asp:Content>
