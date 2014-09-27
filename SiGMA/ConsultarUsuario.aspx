<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs"
    Inherits="SiGMA.ConsultarUsuario" MasterPageFile="~/PaginaMaestra.Master" %>

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
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">
                Consultar usuarios</h3>
        </div>
        <div class="panel-body">
                <div class="col-md-2 col-md-offset-5">
                    <asp:Panel runat=server id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible=false>
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                            <asp:Label ID="lblResultado1" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat=server id="pnlInfo" class="alert alert-dismissable alert-info" Visible=false>
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                            <asp:Label ID="lblResultado2" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat=server id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                            <asp:Label ID="lblResultado3" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </div>
        </div>

       <div class="panel-body">
                <div class="col-md-2 col-md-offset-4">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Panel ID="pnlrdbPersona" runat="server">
                                Persona:&nbsp<asp:RadioButton ID="rbPorPersona" runat="server" GroupName="1" ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RdbPorPersona" cssClass="text-primary"/>
                            </asp:Panel>
                        </td>
                        <td  align="center">
                            <asp:Panel ID="pnlrdbUsuario" runat="server" >
                                Usuario:&nbsp<asp:RadioButton ID="rbPorUsuario" runat="server" GroupName="1" ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RdbPorUsuario" Checked="True" cssClass="text-primary"/>
                            </asp:Panel>
                        </td>
                        <td align="right">
                            <asp:Panel ID="pnlBuscar" runat="server" Visible="false">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscarClick" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlUser" runat="server" Visible="false">
                                Usuario:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlUsuario" runat="server" Visible="false">
                                <asp:TextBox CssClass="TextBox" ID="txtUsuario" runat="server"  Width="350px"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td align="center"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlType" runat="server" Visible="false">
                                Tipo de documento:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlTipoDeDocumento" runat="server" Visible="false">
                                <asp:DropDownList ID="ddlTipoDeDocumento" runat="server" cssClass="TextBox" Width="350px">
                            </asp:DropDownList>
                            &nbsp
                            </asp:Panel>
                        </td>
                        <td align="center">
                            <%--<asp:Panel ID="pnlBuscar" runat="server" Visible="false">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscarClick" />
                            </asp:Panel>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlnumber" runat="server" Visible="false">
                                Nº de documento:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlNºDeDocumento" runat="server" Visible="false">
                                 <asp:TextBox CssClass="TextBox" ID="txtNºDeDocumento" runat="server" Width="350px"></asp:TextBox>&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvNºDeDocumento" runat="server" ErrorMessage="Debe ingresar un numero de documento" ControlToValidate="txtNºDeDocumento" CssClass="Validator" Display="Dynamic" ValidationGroup="2"></asp:RequiredFieldValidator>
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
                                <asp:ListBox ID="lstResultados" runat="server" cssClass="TextBox" Width="200px"></asp:ListBox>
                            </asp:Panel>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlsurname" runat="server" Visible="false">
                                 Apellido:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlApellido" runat="server" Visible="false">
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="TextBox"  Width="350px"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Debe ingresar un apellido" ControlToValidate="txtApellido" CssClass="Validator" ValidationGroup="2" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlname" runat="server" Visible="false">
                                Nombre:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlNombre" runat="server" Visible="false">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox"  Width="350px"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator CssClass="Validator" ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un nombre" Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup="1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlestate" runat="server" Visible="false">
                                Localidades:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlLocalidades" runat="server" Visible="false">
                                <asp:DropDownList ID="ddlLocalidades" Enabled="true"  runat="server" OnSelectedIndexChanged="DdlBarrio_SelectedIndexChanged" AutoPostBack="True" cssClass="TextBox" Width="350px">
                                </asp:DropDownList>&nbsp
                            </asp:Panel>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlCalle" runat="server" Visible="false">
                                Calle:
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel runat="server" Visible="false" ID="pnlDdlCalle">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCalle"  Enabled="true"  runat="server" CssClass="DropDownList" Width="300px">
                                            </asp:DropDownList> 
                                        </td>
                                        <td colspan=2>
                                          <asp:TextBox ID="txtNº" runat="server" CssClass="TextBox" Width="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlbarrio" runat="server" Visible="false">
                                Barrios:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlBarrios" runat="server" Visible="false">
                                <asp:DropDownList ID="ddlBarrios"  Enabled="true"  runat="server" AutoPostBack="False" cssClass="TextBox" Width="350px">
                                </asp:DropDownList>
                            </asp:Panel>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnldate" runat="server" Visible="false">
                                Fecha de nacimiento:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlFecha" runat="server" Visible="false">
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="TextBox" TextMode="SingleLine" Text="  /  /"  Width="350px"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvFechaDeNacimiento" runat="server" ErrorMessage="Debe ingresar una fecha" CssClass="Validator" Display="Dynamic" ControlToValidate="txtFecha" SetFocusOnError="True" ValidationGroup="2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlphonefixed" runat="server" Visible="false">
                                Telefono fijo:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlTelefonFijo" runat="server" Visible="false">
                                <asp:TextBox ID="txtTelefonoFijo" runat="server" CssClass="TextBox" Width="350px"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvTelefonoFijo" runat="server" ErrorMessage="Debe ingresar un telefono fijo" ControlToValidate="txtTelefonoFijo" Display="Dynamic" ValidationGroup="2" CssClass="Validator"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlphone" runat="server" Visible="false">
                                Telefono celular:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlTelefonoCelular" runat="server" Visible="false">
                                <asp:TextBox ID="txtTelefonoCelular" runat="server" CssClass="TextBox"  Width="350px"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvTelefonoCelular" runat="server" ErrorMessage="Debe ingresar un telefono celular" ControlToValidate="txtTelefonoCelular" CssClass="Validator" ValidationGroup="2" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlmails" runat="server" Visible="false">
                                Mail:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlMail" runat="server" Visible="false">
                                <asp:TextBox ID="txtMail" runat="server" CssClass="TextBox" CausesValidation="True"  Width="350px"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="Debe ingresar un mail" ControlToValidate="txtMail" Display="Dynamic" ValidationGroup="2" SetFocusOnError="True" CssClass="Validator"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Debe ingresar un mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMail" ValidationGroup="2" CssClass="Validator" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlSeleccionar" runat="server" Visible="false">
                                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="btnAceptarClick"/>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlModificar" runat="server" Visible="false">
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                                     OnClick="btnModificarClick"  
                                    ValidationGroup="2" />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" onClick="btnEliminarClick"  ValidationGroup="3" />
                            </asp:Panel>
                        </td>
                        <%--<td>
                            <asp:Panel ID="pnlLimpiar" runat="server" Visible="false">
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiarClick" />
                            </asp:Panel>
                        </td>--%>
                    </tr>
                </table>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
