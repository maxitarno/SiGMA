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
        <div class="panel panel-default">
            <div class="panel panel-default">
                <div class="centered">
                    <div class="panel panel-heading">
                        <h3 class="panel-title">
                            Registrar veterinarias
                        </h3>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="col-md-4 col-md-offset-4">
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
                    <div class="col-md-12">
                        <div class="col-md-offset-5 col-md-5">
                            <table>
                                <tr>
                                    <td>
                                        Nombre:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvNombre" Text="Debe ingresar un nombre" ControlToValidate="txtNombre" Display="Dynamic" BorderColor="Red" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Realiza:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Peluqueria
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPeluqueria" runat="server"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        PetShop
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPetShop" runat="server"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Medicinas
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkMedicinas" runat="server"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Castraciones
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCastraciones" runat="server"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Contacto:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContacto" runat="server"></asp:TextBox>  
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
                                    <td>
                                        Localidad:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlLocalidad" runat="server" Width="210px" OnSelectedIndexChanged="SeleccionarLocalidad" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Barrio:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBarrio" runat="server" Width="210px" AppendDataBoundItems="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Calle:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCalle" runat="server" Width="150px"  AppendDataBoundItems="True" style="float:left">
                                        </asp:DropDownList>
                                         - <asp:TextBox ID="txtNº" runat="server" Width="50px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        T.E.:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTE" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="Debe ingresar un telefono" ControlToValidate="txtTE" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right">
                                        <asp:Panel ID="pnlRegistrar" runat="server" Visible="true">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" 
                                                onclick="btnRegistrar_Click" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
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
