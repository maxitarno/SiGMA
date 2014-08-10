<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs"
    Inherits="SiGMA.ConsultarUsuario" MasterPageFile="Site.Master" %>

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
                            <asp:Label ID="lblResultado" runat="server" Text="" OnDisposed="Resultado"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Por persona:&nbsp<asp:RadioButton ID="rbPorPersona" runat="server" GroupName="1"
                                ValidationGroup="1" />
                            <br />
                        </td>
                        <td>
                            Por usuario:&nbsp<asp:RadioButton ID="rbPorUsuario" runat="server" GroupName="1"
                                ValidationGroup="1" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuario:&nbsp
                        </td>
                        <td>
                            <asp:TextBox CssClass="TextBox" ID="txtUsuario" runat="server"></asp:TextBox>
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
                        <td rowspan="2" align="center">
                            <asp:Button CssClass="Button" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscarClick" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nº de documento:&nbsp
                        </td>
                        <td>
                            <asp:TextBox CssClass="TextBox" ID="txtNºDeDocumento" runat="server"></asp:TextBox>&nbsp
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
                    </tr>
                    <tr>
                        <td>
                            Localidades:&nbsp
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocalidades" runat="server" CssClass="DropDownList">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscarLocalidades" runat="server" Text="BuscarLocalidades" OnClick="ddlLocalidadSelected"
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
                    </tr>
                    <tr>
                        <td>
                            Telefono fijo:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefonoFijo" runat="server" CssClass="TextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Telefono celular:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefonoCelular" runat="server" CssClass="TextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mail:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtMail" runat="server" CssClass="TextBox"></asp:TextBox>
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
                        <td colspan="3" align="center">
                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="Button"
                                OnClick="btnAceptarClick" />
                        </td>
                        <td>
                            <asp:Button ID="Modificar" runat="server" Text="Modificar" CssClass="Button" OnClick="btnModificarClick" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
