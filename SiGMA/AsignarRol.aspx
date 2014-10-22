<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarRol.aspx.cs" Inherits="SiGMA.AsignarRol" %>
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
                Roles</h3>
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
                <asp:Panel ID="pnlSeleccionUsuario" runat="server">
                        <table>
                        <tr>
                            <td valign="middle">
                                    Usuario:&nbsp
                            </td>
                            <td>
                                    <asp:TextBox ID="txtSelecionUsuario" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="3" rowspan="2">
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                                        onclick="btnBuscar_Click"/>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="pnlUsuario" runat="server" Visible="false">
                        <table width="100%">
                            <tr>
                            <td>
                                Seleccione un Usuario: <asp:ListBox ID="lstUsuarios" runat="server" Width="100%" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="lstUsuarios_SelectedIndexChanged"></asp:ListBox>
                            </td>
                            </tr>
                        </table>
                    </asp:Panel>    
                    <br />  
                </asp:Panel>
            </div>
        </div>

        <div class="panel-body">
            <div class="col-md-2 col-md-offset-5">
                <asp:Panel ID="pnlAsignalRol" runat="server" Visible="false">
                    <table>
                        <tr style="height:30px">
                            <td align="right" width="100px"> Usuario: </td>
                            <td align="left"> 
                                <asp:TextBox ID="txtUsuario" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr style="height:30px">
                            <td align="right" width="100px"> Roles del Usuario: </td>
                            <td align="left"> 
                               <asp:DropDownList ID="ddlRolUsuario" runat="server" AutoPostBack="true" 
                                    AppendDataBoundItems="true"> 
                                </asp:DropDownList>
                            </td>
                            <td><asp:Button ID="btnEliminarRol" runat="server" Text="Eliminar" /></td>
                        </tr>
                        <tr>
                            <td align="right" width="100px">Agregar Rol: </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlRol" runat="server" AutoPostBack="true" 
                                    AppendDataBoundItems="true"> 
                                </asp:DropDownList>
                            </td>
                            <td><asp:Button ID="btnAsignarRol" runat="server" Text="Guardar" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png" CausesValidation="False"/><br />VOLVER
    </div>
</div>
    </div>
</asp:Content>

