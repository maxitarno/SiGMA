﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs"
    Inherits="SiGMA.ConsultarUsuario" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Consultar usuarios</h3>
        </div>
        <div class="panel-body">
            <div class="almedio">
                <table >
                    <tr>
                    <!-- mensajes -->
                        <td colspan="4">
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
                        </td>
                        <!-- fin mensajes -->
                    </tr>
                    <tr>
                        <td colspan="2" align="justify">
                            <asp:Panel ID="pnlrdbPersona" runat="server">
                                Por persona:&nbsp<asp:RadioButton ID="rbPorPersona" runat="server" GroupName="1" ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RdbPorPersona" cssClass="text-primary"/>&nbsp
                            </asp:Panel>
                        </td>
                        <td colspan="3" align="right">
                            <asp:Panel ID="pnlrdbUsuario" runat="server" >
                                Por usuario:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RadioButton ID="rbPorUsuario" runat="server" GroupName="1" ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RdbPorUsuario" Checked="True" cssClass="text-primary"/>
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
                                <asp:TextBox CssClass="TextBox" ID="txtUsuario" runat="server" Width="100%"></asp:TextBox>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlType" runat="server" Visible="false">
                                Tipo de documento:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlTipoDeDocumento" runat="server" Visible=false>
                                <asp:DropDownList ID="ddlTipoDeDocumento" runat="server" cssClass="TextBox" Width=100%>
                            </asp:DropDownList>
                            &nbsp
                            </asp:Panel>
                        </td>
                        <td colspan="2" align="center">
                            <asp:Panel ID="pnlBuscar" runat="server" Visible="false" Width=100%>
                                <asp:Button CssClass="btn-primary" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscarClick" width=100%/>
                            </asp:Panel>
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
                                 <asp:TextBox CssClass="TextBox" ID="txtNºDeDocumento" runat="server" Width=100%></asp:TextBox>&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvNºDeDocumento" runat="server" ErrorMessage="debe ingresar un numero de documento" ControlToValidate="txtNºDeDocumento" CssClass="Validator" Display="Dynamic" ValidationGroup="2"></asp:RequiredFieldValidator>
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
                                <asp:ListBox ID="lstResultados" runat="server" Width="100%" cssClass="TextBox"></asp:ListBox>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlsurname" runat="server" Visible="false">
                                 Apellido:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlApellido" runat="server" Visible="false">
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
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
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator CssClass="Validator" ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un nombre" Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup="1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnladress" runat="server" Visible="false">
                                Domicilio:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlDomicilio" runat="server" Visible="false">
                                <asp:TextBox ID="txtDomicilio" runat="server" CssClass="DropDownList"  Enabled="false" Width=100%></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvDomicilio" runat="server" ErrorMessage="Debe ingresar un domicilio" CssClass="Validator" ControlToValidate="txtDomicilio" Display="Dynamic" SetFocusOnError="True" ValidationGroup="2"></asp:RequiredFieldValidator>
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
                                <asp:DropDownList ID="ddlLocalidades" Enabled="false"  runat="server" OnSelectedIndexChanged="DdlBarrio_SelectedIndexChanged" AutoPostBack="True" cssClass="TextBox" Width=100%>
                                </asp:DropDownList>&nbsp
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlCalle" runat=server Visible=false>
                                Calle:
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel runat=server Visible=false ID=pnlDdlCalle>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCalle"  Enabled="false"  runat="server" CssClass="DropDownList">
                                            </asp:DropDownList> 
                                        </td>
                                        <td colspan=2>
                                          <asp:TextBox ID="txtNº" runat="server" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlbarrio" runat="server" Visible="false">
                                Barrios:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlBarrios" runat="server" Visible="false" Width=100%>
                                <asp:DropDownList ID="ddlBarrios"  Enabled="false"  runat="server" AutoPostBack="False" cssClass="TextBox" withd=100%>
                                </asp:DropDownList>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnldate" runat="server" Visible="false">
                                Fecha de nacimiento:&nbsp
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlFecha" runat="server" Visible="false">
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="TextBox" TextMode="SingleLine" Text="  /  /"  Width=100%></asp:TextBox>
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
                                <asp:TextBox ID="txtTelefonoFijo" runat="server" CssClass="TextBox"  Width=100%></asp:TextBox>
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
                                <asp:TextBox ID="txtTelefonoCelular" runat="server" CssClass="TextBox"  Width=100%></asp:TextBox>
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
                                <asp:TextBox ID="txtMail" runat="server" CssClass="TextBox" CausesValidation="True"  Width=100%></asp:TextBox>
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
                                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn-primary" OnClick="btnAceptarClick" Width=100%/>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlModificar" runat="server" Visible="false">
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                                    CssClass="btn-primary" OnClick="btnModificarClick" width=100% 
                                    ValidationGroup="2" />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-primary" onClick="btnEliminarClick" Width=100% ValidationGroup="3" />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlLimpiar" runat="server" Visible="false">
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-primary" OnClick="btnLimpiarClick" Width=100%/>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
