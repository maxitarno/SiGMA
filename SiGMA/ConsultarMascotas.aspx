<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarMascotas.aspx.cs"
    Inherits="SiGMA.ConsultarMascotasaspx" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Consultar Mascotas</h3>
        </div>
        <div class="panel-body">
            <div class="almedio">
                <table>
                    <tr>
                        <td>
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
                        </td>
                    </tr>
                    <tr>
                        <td class="almedio">
                            <asp:Panel ID="pnlBuscarPor" runat="server" Width="100%">
                                <table>
                                    <tr>
                                        <td>
                                            Por dueñio:&nbsp
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rbPorDuenio" runat="server" />&nbsp&nbsp
                                        </td>
                                        <td>
                                            Por Mascota:&nbsp
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rbPorMascota" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="almedio">
                            <asp:Panel ID="pnlBuscar" runat="server" Width="100%">
                                <table>
                                    <tr>
                                        <td valign="middle">
                                            Nombre:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNombreDueñio" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvNombreDuenio" runat="server" ErrorMessage="Debe ingresar un nombre"
                                                ControlToValidate="txtNombreDueñio" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage=" Debe ingresar un nombre"
                                                ID="rfvNombre" ValidationGroup="2" Display="Dynamic" ControlToValidate="txtNombreDueñio"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuscar" runat="server" Text="Button" CssClass="btn-primary" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="middle">
                                            mascota:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMascota" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvMascota" runat="server" ErrorMessage="Debe ingresar un nombre"
                                                ControlToValidate="txtMascota" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage=" Debe ingresar un nombre"
                                                ID="rfvNombreMascota" ValidationGroup="2" Display="Dynamic" ControlToValidate="txtNombreDueñio"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlResultados" runat="server" Width="100%">
                                <table width=100%>
                                    <tr>
                                        <td align="center">
                                            Resultados:
                                        </td>
                                        <td colspan="3">
                                            <asp:ListBox ID="lstResultados" runat="server" Width=100% CssClass="ListBox"></asp:ListBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlDatos" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            Estado:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDownList" Width=100%>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Especie:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEspecie" runat="server" Width=100% CssClass="DropDownList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Edad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEdad" runat="server" Width=100% CssClass="DropDownList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Raza:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRaza" runat="server" Width=100% CssClass="DropDownList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Color:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlColor" runat="server" Width=100% CssClass="DropDownList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Trato animales:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTratoA" runat="server" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Trato niños:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTratoN" runat="server" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Carater:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCaracter" runat="server" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Observaciones:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Alimentacion especial:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAlimentacionEspecial" runat="server" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Sexo:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSexo" runat="server" Width=100% CssClass="DropDownList">
                                                <asp:ListItem Text="Hembra" Value="1"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Macho"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="almedio">
                            <asp:Panel ID="pnlBotons" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn-primary" />
                                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn-primary" />
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-primary" />
                                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-primary" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
