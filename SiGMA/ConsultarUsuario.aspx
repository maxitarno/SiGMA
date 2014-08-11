<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs"
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
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            Por persona:&nbsp<asp:RadioButton ID="rbPorPersona" runat="server" GroupName="1" ValidationGroup="1" with=100%/>
                        </td>
                        <td colspan="2" align="right">
                            Por usuario:&nbsp<asp:RadioButton ID="rbPorUsuario" runat="server" GroupName="1" ValidationGroup="1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuario:&nbsp
                        </td>
                        <td>
                            <asp:TextBox CssClass="TextBox" ID="txtUsuario" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvUsuarion" runat="server" ErrorMessage=" Debe ingresar un usuario" ControlToValidate="txtUsuario" CssClass="Validator" Display="Dynamic" ValidationGroup="3" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" CssClass="Validator" Display="Dynamic" ErrorMessage="Debe ingresar un usuario" SetFocusOnError="True" ValidationGroup="2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo de documento:&nbsp
                        </td>
                        <td>
                            <asp:DropDownList CssClass="DropDownList" ID="ddlTipoDeDocumento" runat="server">
                            </asp:DropDownList>
                            &nbsp
                        </td>
                        <td colspan="2" align="center">
                            <asp:Button CssClass="Button" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscarClick" width=100%/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nº de documento:&nbsp
                        </td>
                        <td>
                            <asp:TextBox CssClass="TextBox" ID="txtNºDeDocumento" runat="server"></asp:TextBox>&nbsp
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvNºDeDocumento" runat="server" ErrorMessage="debe ingresar un numero de documento" ControlToValidate="txtNºDeDocumento" CssClass="Validator" Display="Dynamic" ValidationGroup="2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Resultados:
                        </td>
                        <td>
                            <asp:ListBox ID="lstResultados" runat="server" CssClass="ListBox" Width="100%"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Apellido:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Debe ingresar un apellido" ControlToValidate="txtApellido" CssClass="Validator" ValidationGroup="2" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Domicilio:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtDomicilio" runat="server" CssClass="TextBox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvDomicilio" runat="server" ErrorMessage="Debe ingresar un domicilio" CssClass="Validator" ControlToValidate="txtDomicilio" Display="Dynamic" SetFocusOnError="True" ValidationGroup="2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Localidades:&nbsp
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocalidades" runat="server" CssClass="DropDownList">
                            </asp:DropDownList>&nbsp
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnBuscarLocalidades" runat="server" Text="Buscar Localidades" OnClick="ddlLocalidadSelected"
                                CssClass="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Barrios:&nbsp
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBarrios" runat="server" CssClass="DropDownList">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha de nacimiento:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="TextBox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvFechaDeNacimiento" runat="server" ErrorMessage="Debe ingresar una fecha" CssClass="Validator" Display="Dynamic" ControlToValidate="txtFecha" SetFocusOnError="True" ValidationGroup="2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Telefono fijo:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefonoFijo" runat="server" CssClass="TextBox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvTelefonoFijo" runat="server" ErrorMessage="Debe ingresar un telefono fijo" ControlToValidate="txtTelefonoFijo" Display="Dynamic" ValidationGroup="2" CssClass="Validator"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Telefono celular:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefonoCelular" runat="server" CssClass="TextBox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvTelefonoCelular" runat="server" ErrorMessage="Debe ingresar un telefono celular" ControlToValidate="txtTelefonoCelular" CssClass="Validator" ValidationGroup="2" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mail:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtMail" runat="server" CssClass="TextBox" CausesValidation="True"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="Debe ingresar un mail" ControlToValidate="txtMail" Display="Dynamic" ValidationGroup="2" SetFocusOnError="True" CssClass="Validator"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Debe ingresar un mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMail" ValidationGroup="2" CssClass="Validator" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Rol:&nbsp
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRoles" runat="server" CssClass="DropDownList" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="Button" OnClick="btnAceptarClick" Width=100%/>
                        </td>
                        <td>
                            <asp:Button ID="Modificar" runat="server" Text="Modificar" CssClass="Button" OnClick="btnModificarClick" width=100% ValidationGroup="2" />
                        </td>
                        <td>
                            <asp:Button ID="Elimiar" runat="server" Text="Eliminar" CssClass="Button" onClick="btnEliminarClick" Width=100% ValidationGroup="3" />
                        </td>
                        <td>
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="Button" OnClick="btnLimpiarClick"/>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
