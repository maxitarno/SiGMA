<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="SiGMA.MiPerfil" %>

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
    <link href="assets/calendario_dw/calendario_dw-estilos.css" type="text/css" rel="STYLESHEET"/>
   <script type="text/javascript" src="assets/calendario_dw/jquery-1.4.4.min.js"></script>
   <script type="text/javascript" src="assets/calendario_dw/calendario_dw.js"></script>
   
   <script type="text/javascript">
       (function ($) {
           $(document).ready(function () {
               $(".campofecha").calendarioDW();
           })
       })(jQuery);
      </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                <asp:Label ID="lblTitulo"  runat="server" Text="Mi Perfil"></asp:Label></h3>
            </div>
            <div class="panel-body">
                <div class="col-md-2 col-md-offset-5">
                    <asp:Panel runat="server" ID="pnlCorrecto" class="alert alert-dismissable alert-success"
                        Visible="false">
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                        <asp:Label ID="lblResultado1" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlInfo" class="alert alert-dismissable alert-info"
                        Visible="false">
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                        <asp:Label ID="lblResultado2" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlAtento" class="alert alert-dismissable alert-danger"
                        Visible="false">
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                        <asp:Label ID="lblResultado3" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-md-3 col-md-offset-1">
                    <div style="margin-left: 30%; display: table; width: 40%;">
                        <div style="display: table-row; width: 40%">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlUser" runat="server" Visible="false">
                                            Usuario:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlUsuario" runat="server" Visible="false">
                                            <asp:TextBox CssClass="TextBox" ID="txtUsuario" runat="server" Width="350px" ReadOnly="true"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Contraseña:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContra" runat="server" MaxLength="16" TextMode="Password" Width="350px"></asp:TextBox></td><td>
                                        <asp:RequiredFieldValidator ID="rfvContra" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtContra" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvContraseña" runat="server" 
                                            ErrorMessage="Minimo 8 caracteres" ControlToValidate="txtContra" ForeColor="Red" 
                                            onservervalidate="cvContraseña_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRepetirContraseña" runat="server" Text="Repetir Contraseña:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox  ID="txtRepetirContra" runat="server" MaxLength="16" 
                                            TextMode="Password" Width="350px"></asp:TextBox></td><td>
                                        <asp:RequiredFieldValidator ID="rfvRepetirContra" runat="server" ErrorMessage="*"
                                            ForeColor="Red" ControlToValidate="txtRepetirContra" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="covPassword" runat="server" ErrorMessage="Las contraseñas no son iguales"
                                            ControlToCompare="txtContra" ControlToValidate="txtRepetirContra" ForeColor="Red"
                                            Display="Dynamic"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlType" runat="server" Visible="false">
                                            Tipo de documento:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlTipoDeDocumento" runat="server" Visible="false">
                                            <asp:DropDownList ID="ddlTipoDeDocumento" runat="server" CssClass="TextBox" Width="350px">
                                            </asp:DropDownList>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlnumber" runat="server" Visible="false">
                                            Nº de documento:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlNºDeDocumento" runat="server" Visible="false">
                                            <asp:TextBox CssClass="TextBox" ID="txtNºDeDocumento" runat="server" Width="350px"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvNºDeDocumento" runat="server" ErrorMessage="Debe ingresar un numero de documento"
                                            ControlToValidate="txtNºDeDocumento" CssClass="Validator" Display="Dynamic" ValidationGroup="2"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-md-offset-2">
                    <div style="margin-left: 30%; display: table; width: 40%;">
                        <div style="display: table-row; width: 30%">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlsurname" runat="server" Visible="false">
                                            Apellido:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlApellido" runat="server" Visible="false">
                                            <asp:TextBox ID="txtApellido" runat="server" CssClass="TextBox" Width="350px"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Debe ingresar un apellido"
                                            ControlToValidate="txtApellido" CssClass="Validator" ValidationGroup="2" SetFocusOnError="True"
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlname" runat="server" Visible="false">
                                            Nombre:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlNombre" runat="server" Visible="false">
                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="350px"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator CssClass="Validator" ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un nombre"
                                            Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup="1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlestate" runat="server" Visible="false">
                                            Localidad:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlLocalidades" runat="server" Visible="false">
                                            <asp:DropDownList ID="ddlLocalidades" Enabled="true" runat="server" OnSelectedIndexChanged="DdlBarrio_SelectedIndexChanged"
                                                AutoPostBack="True" CssClass="TextBox" Width="350px">
                                            </asp:DropDownList>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlCalle" runat="server" Visible="false">
                                            Calle:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel runat="server" Visible="false" ID="pnlDdlCalle">
                                            <asp:DropDownList ID="ddlCalle" Enabled="true" runat="server" CssClass="DropDownList"
                                                Width="293px">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtNº" runat="server" CssClass="TextBox" Width="50px"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlbarrio" runat="server" Visible="false">
                                            Barrio:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlBarrios" runat="server" Visible="false">
                                            <asp:DropDownList ID="ddlBarrios" Enabled="true" runat="server" AutoPostBack="False"
                                                CssClass="TextBox" Width="350px">
                                            </asp:DropDownList>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnldate" runat="server" Visible="false">
                                            Fecha de nacimiento:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlFecha" runat="server" Visible="false">
                                                <asp:TextBox ID="txtFecha" class="campofecha pull-left" runat="server"  Width="90%" ></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlphonefixed" runat="server" Visible="false">
                                            Telefono fijo:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlTelefonFijo" runat="server" Visible="false">
                                            <asp:TextBox ID="txtTelefonoFijo" runat="server" CssClass="TextBox" Width="350px"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvTelefonoFijo" runat="server" ErrorMessage="Debe ingresar un telefono fijo"
                                            ControlToValidate="txtTelefonoFijo" Display="Dynamic" ValidationGroup="2" CssClass="Validator"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlphone" runat="server" Visible="false">
                                            Telefono celular:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlTelefonoCelular" runat="server" Visible="false">
                                            <asp:TextBox ID="txtTelefonoCelular" runat="server" CssClass="TextBox" Width="350px"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvTelefonoCelular" runat="server" ErrorMessage="Debe ingresar un telefono celular"
                                            ControlToValidate="txtTelefonoCelular" CssClass="Validator" ValidationGroup="2"
                                            SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlmails" runat="server" Visible="false">
                                            Mail:
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlMail" runat="server" Visible="false">
                                            <asp:TextBox ID="txtMail" runat="server" CssClass="TextBox" CausesValidation="True"
                                                Width="350px"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="Debe ingresar un mail"
                                            ControlToValidate="txtMail" Display="Dynamic" ValidationGroup="2" SetFocusOnError="True"
                                            CssClass="Validator"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Debe ingresar un mail"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMail"
                                            ValidationGroup="2" CssClass="Validator" ForeColor="Red" SetFocusOnError="True"
                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                            <div style="margin-left: 30%; display: table; width: 40%;">
                                <div style="display: table-row; width: 30%">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnlModificar" runat="server" Visible="false">
                                                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificarClick" />
                                                </asp:Panel>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
    </div>
</asp:Content>

