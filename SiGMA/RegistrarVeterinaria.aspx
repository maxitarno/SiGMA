<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarVeterinaria.aspx.cs" Inherits="SiGMA.RegistrarVeterinaria" MasterPageFile="PaginaMaestra.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel panel-heading">
                <h3 class="panel-title">
                    Registrar veterinarias
                </h3>
            </div>
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
            <div class="col-md-offset-5 col-md-2">
                <table style="margin-left: 25%; width=50%;">
                    <tr>
                        <td>
                            Nombre:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Realiza:
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="chkPeluqueria" runat="server" Text="Peluqueria"/>
                            <asp:CheckBox ID="chkPetShop" runat="server" Text="PetShop"/>
                            <asp:CheckBox ID="chkMedicinas" runat="server" Text="Medicinas"/>
                            <asp:CheckBox ID="chkCastraciones" runat="server" Text="Castraciones"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contacto:
                        </td>
                        <td>
                            <asp:TextBox ID="txtContacto" runat="server" Width="100%"></asp:TextBox>  
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Localidad:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Barrio:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBarrio" runat="server" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Calle:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCalle" runat="server" Width="50%"></asp:TextBox>Nº<asp:TextBox ID="txtNº" runat="server" Width="25%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            T.E.:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTE" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="centered">
                        <div class="centered">
                            <div style="margin-left: 30%; display: table; width: 40%;">
                                <div style="display: table-row; width: 30%">
                                    <div style="display: table-cell; width: 20%;">
                                        <asp:Panel ID="pnlRegistrar" runat="server" Visible="false">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar"/>
                                        </asp:Panel>
                                    </div>
                                    <div style="display: table-cell; width: 20%;">
                                        <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </div>
    <div class="centered">
                <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                     CausesValidation="false"/>
                </br> Volver
            </div>
</asp:Content>