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
            <div class="col-md-offset-3 col-md-5">
                <table style="margin-left: 25%; width:50%;">
                    <tr>
                        <td>
                            Nombre:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvNombre" Text="Debe ingresar un nombre" ControlToValidate="txtNombre" Display="Dynamic" BorderColor="Red" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Realiza:
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left; width:50%">
                            Peluqueria
                        </td>
                        <td style="float:left; width:50%">
                            <asp:CheckBox ID="chkPeluqueria" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left; width:50%">
                            PetShop
                        </td>
                        <td style="float:left; width:50%">
                            <asp:CheckBox ID="chkPetShop" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left; width:50%">
                            Medicinas
                        </td>
                        <td style="float:left; width: 50%">
                            <asp:CheckBox ID="chkMedicinas" runat="server"/>
                        </td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:50%;text-align:left">
                            Castraciones
                        </td>
                        <td style="width:50%;float:left">
                            <asp:CheckBox ID="chkCastraciones" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">
                            Contacto:
                        </td>
                        <td>
                            <asp:TextBox ID="txtContacto" runat="server" Width="100%"></asp:TextBox>  
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="revContacto" runat="server" 
                                ErrorMessage="Formato de email incorrecto" ControlToValidate="txtContacto" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvContacto" runat="server" ErrorMessage="Debe ingresar un contacto" ControlToValidate="txtContacto" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">
                            Localidad:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" Width="100%" OnSelectedIndexChanged="SeleccionarLocalidad" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">
                            Barrio:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBarrio" runat="server" Width="100%" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">
                            Calle:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCalle" runat="server" Width="65%"  AppendDataBoundItems="True" style="float:left">
                            </asp:DropDownList>
                            Nº<asp:TextBox ID="txtNº" runat="server" Width="25%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">
                            T.E.:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTE" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="Debe ingresar un telefono" ControlToValidate="txtTE" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="centered">
            <div class="centered">
                <div style="margin-left: 34%; display: table; width: 40%;">
                    <div style="display: table-row; width: 30%">
                        <div style="display: table-cell; width: 20%;">
                            <asp:Panel ID="pnlRegistrar" runat="server" Visible="true">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" 
                                    onclick="btnRegistrar_Click" />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
           OnClick="BtnRegresarClick" CausesValidation="false" />
        <br> Volver
    </div>
</asp:Content>
