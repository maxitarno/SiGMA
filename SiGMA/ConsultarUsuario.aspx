<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs"
    Inherits="SiGMA.ConsultarUsuario" MasterPageFile="~/PaginaMaestra.Master" Culture="Auto"
    UICulture="Auto" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
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
    <link href="assets/calendario_dw/calendario_dw-estilos.css" type="text/css" rel="STYLESHEET" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="centered">
        <div class="panel panel-default">
            <div class="centered">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h3>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-md-4 col-md-offset-4">
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
                <div class="col-md-12">
                    <div class="col-md-2 col-md-offset-4">
                        <asp:RadioButton ID="rbPorPersona" runat="server" GroupName="1"
                            AutoPostBack="True" OnCheckedChanged="RdbPorPersona" Text="Por persona" />
                    </div>
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbPorUsuario" runat="server" GroupName="1"
                            AutoPostBack="True" OnCheckedChanged="RdbPorUsuario" Checked="True" Text="Por usuario" />
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-3 col-md-offset-3">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlUser" runat="server" Visible="false">
                                        Usuario:
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="pnlUsuario" runat="server" Visible="false">
                                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                                    </asp:Panel>
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
                                        <asp:DropDownList ID="ddlTipoDeDocumento" runat="server" Width="210px">
                                        </asp:DropDownList>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:CustomValidator ID="cvTipoDocumento" runat="server" ErrorMessage="*" 
                                        ControlToValidate="ddlTipoDeDocumento" 
                                        onservervalidate="cvTipoDocumento_ServerValidate" ForeColor="Red" 
                                        ValidationGroup="1"></asp:CustomValidator>
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
                                        <asp:TextBox ID="txtNºDeDocumento" runat="server"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvNºDeDocumento" runat="server" ErrorMessage="*"
                                        ControlToValidate="txtNºDeDocumento"  ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Panel ID="pnlBuscar" runat="server" Visible="true">
                                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscarClick" CausesValidation="False" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlresult" runat="server" Visible="false">
                                        Resultados:
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                                        <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstResultados_SelectedIndexChanged" Width="210px">
                                        </asp:ListBox>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:ImageButton ID="ibtnBuscarOtro" runat="server" 
                                        ImageUrl="~/imagenes/buscar.jpg" onclick="ibtnBuscarOtro_Click"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-6">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlsurname" runat="server" Visible="false">
                                        Apellido:
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="pnlApellido" runat="server" Visible="false">
                                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="*"
                                        ControlToValidate="txtApellido" ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="*"
                                         ControlToValidate="txtNombre" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlestate" runat="server" Visible="false">
                                        Localidades:
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="pnlLocalidades" runat="server" Visible="false">
                                        <asp:DropDownList ID="ddlLocalidades" Enabled="true" runat="server" OnSelectedIndexChanged="DdlBarrio_SelectedIndexChanged"
                                            AutoPostBack="True" Width="210px">
                                        </asp:DropDownList>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:CustomValidator ID="cvLocalidades" runat="server" ErrorMessage="*" 
                                        ControlToValidate="ddlLocalidades" ForeColor="Red" 
                                        onservervalidate="cvLocalidades_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
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
                                        <asp:DropDownList ID="ddlCalle" Enabled="true" runat="server" Width="155px">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtNº" runat="server" CssClass="TextBox" Width="55px"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:CustomValidator ID="cvCalles" runat="server" ErrorMessage="*" 
                                        ForeColor="Red" ControlToValidate="ddlCalle" 
                                        onservervalidate="cvCalles_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlbarrio" runat="server" Visible="false">
                                        Barrios:
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="pnlBarrios" runat="server" Visible="false">
                                        <asp:DropDownList ID="ddlBarrios" Enabled="true" runat="server" AutoPostBack="False"
                                            Width="210px">
                                        </asp:DropDownList>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:CustomValidator ID="cvBarrios" runat="server" ErrorMessage="*" 
                                        ControlToValidate="ddlBarrios" ForeColor="Red" 
                                        onservervalidate="cvBarrios_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
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
                                        <asp:TextBox ID="txtFecha" runat="server" Width="190px"/>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/calendario_dw/calendario.png" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFecha"
                                            PopupButtonID="Image1"></ajaxToolkit:CalendarExtender>
                                    </asp:Panel>
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
                                        <asp:TextBox ID="txtTelefonoFijo" runat="server"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvTelefonoFijo" runat="server" ErrorMessage="*o"
                                        ControlToValidate="txtTelefonoFijo"  ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                        <asp:TextBox ID="txtTelefonoCelular" runat="server"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvTelefonoCelular" runat="server" ErrorMessage="*"
                                        ControlToValidate="txtTelefonoCelular" ValidationGroup="1" SetFocusOnError="True"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
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
                                        <asp:TextBox ID="txtMail" runat="server" CssClass="TextBox" CausesValidation="True"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="*"
                                        ControlToValidate="txtMail"  ValidationGroup="1" SetFocusOnError="True"
                                        CssClass="Validator" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="El formato del mail no es correcto"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMail"
                                        ValidationGroup="1" CssClass="Validator" ForeColor="Red" SetFocusOnError="True" ></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-1 col-md-offset-8">
                        <asp:Panel ID="pnlModificar" runat="server" Visible="false">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificarClick"
                                ValidationGroup="1" />
                        </asp:Panel>
                    </div>
                    <div class="col-md-1">
                        <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminarClick"
                                ValidationGroup="2" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
            OnClick="BtnRegresarClick" CausesValidation="False" /><br />
        VOLVER
    </div>
</asp:Content>
