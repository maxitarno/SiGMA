<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarAdopcion.aspx.cs"
    Inherits="SiGMA.RegistrarAdopcion" MasterPageFile="Site.Master" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h1 class="panel-title">
                Registrar Adopcion
            </h1>
        </div>
        <div class="panel-body">
            <div class="Doble">
                <table>
                    <tr>
                        <!-- mensajes -->
                        <td colspan="4">
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
                        <!-- fin mensajes -->
                    </tr>
                    <tr>
                        <td>
                            Voluntario<br />
                            <table>
                                <tr>
                                    <td>
                                        Nº:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtN" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td colspan="3">
                                                    por nombre
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rbPorNombre" runat="server" GroupName="1" ValidationGroup="1"
                                                        AutoPostBack="True" OnCheckedChanged="rbPorName" />&nbsp
                                                </td>
                                                <td colspan="3">
                                                    Por documento
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rbPorDNI" runat="server" OnCheckedChanged="rbPorTipo" AutoPostBack="True"
                                                        ValidationGroup="1" GroupName="1" Checked="True" />&nbsp
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <asp:Panel ID="pnlNombre" runat="server" Visible="false">
                                        <td>
                                            Nombre:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNombreDuenio" runat="server" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </asp:Panel>
                                    <td>
                                        <asp:Button ID="btnBuscarDuenio" runat="server" Text="Buscar" CssClass="btn-primary"
                                            OnClick="btnBuscarDuenioClick" />
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlDocumento" runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            Tipo de documento:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="DropDownList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Nº de doumento:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDNI" runat="server" CssClass="TextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="pnlResultadosDuenio" runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            Resultados:
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lstResultadosDuenios" runat="server" CssClass="ListBox"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSeleccionarDuenio" runat="server" Text="Seleccionar" CssClass="btn-primary"
                                                OnClick="btnSeleccionarDuenioClick" />
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </table>
                            <table>
                                <asp:Panel ID="pnlBuscarMascota" runat="server" Visible="false">
                                        <tr>
                                            <td>
                                                Nombre de la mascota:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNombreMascota" runat="server" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnBuscarMascota" runat="server" Text="Buscar" CssClass="btn-primary"
                                                    OnClick="btnBuscarMascotaClick" />
                                            </td>
                                        </tr>
                                </asp:Panel>
                                <asp:Panel Visible="false" runat="server" ID="pnlResultadosMascotas">
                                    <tr>
                                        <td>
                                            Resultados:
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lstResultadosMascotas" runat="server" CssClass="ListBox"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSeleccioarMascota" runat="server" Text="Seleccionar" CssClass="btn-primary"
                                                OnClick="btnSeleccionarMascota" />
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </table>
                            Fecha:&nbsp<asp:TextBox ID="txtFecha" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                        <td>
                            <asp:Panel ID="pnlDuenio" runat="server" Visible="false">
                        <h5>
                            Datos del dueño
                        </h5>
                        <table>
                            <tr>
                                <td>
                                    Nombre:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombreD" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tipo de documento:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTipoDeDocumento" runat="server" ReadOnly="True" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Nº de documento:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNº" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Localidad:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLocalidad" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Barrio:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBarrio" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Calle:<asp:TextBox ID="txtCalle" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    Nº:<asp:TextBox ID="txtNro" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                            <asp:Panel ID="pnlMascota" runat="server" Visible="false">
                        <h5>
                            Datos de la mascota
                        </h5>
                        <table>
                            <tr>
                                <td>
                                    Nombre de la mascota:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombreM" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Raza:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRaza" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sexo:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSexo" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Edad:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEdad" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:Panel ID=pnlRegistrar runat=server Visible=false>
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrarClick" />
                           </asp:Panel>
                           <asp:Panel ID=pnllimpiar runat=server Visible=false>
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
                           </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
