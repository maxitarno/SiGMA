<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CABMRazas.aspx.cs" Inherits="SiGMA.CABMRazas"
    MasterPageFile="Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h1 class="panel-title">
                Consultar, modificar razas
            </h1>
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
                        <td>
                            <asp:Panel runat="server" ID="pnlEspecie">
                                Especie:</asp:Panel>
                        </td>
                        <td>
                            <asp:Panel runat="server" ID="pnlDdlEspecie">
                                <asp:DropDownList ID="ddlEspecies" runat="server">
                                </asp:DropDownList>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="pnlNombre">
                                Nombre:
                            </asp:Panel>
                        </td>
                        <td colspan="5">
                            <asp:Panel ID="pnltxtNombre" runat="server">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox"></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlBuscar" runat="server" Width="100%">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-primary" CausesValidation="False"
                                    OnClick="BtnBuscarClick" />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un tipo de documento"
                                ControlToValidate="txtNombre" ValidationGroup="1" CssClass="Validator"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <asp:Panel ID="pnlResultado" runat="server" Visible="false" Width="100%">
                            <td>
                                Resultados:
                            </td>
                            <td colspan="5">
                                <asp:ListBox ID="lstResultados" runat="server" CssClass="ListBox"></asp:ListBox>
                            </td>
                        </asp:Panel>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel runat="server" Visible="true" ID="pnlDatos">
                                <table>
                                    <tr>
                                        <td>
                                            Categoria:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCategoria" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <!--<tr>
                                        <td>
                                            Cuidado especial:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCuidadoEspecial" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>-->
                                    <tr>
                                        <td>
                                            Peso Raza:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlRegistrar" runat="server">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn-primary"
                                    ValidationGroup="1" />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlSeleccionar" runat="server" Visible="false">
                                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn-primary"
                                    CausesValidation="False" OnClick="BtnSeleccionarClick" />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlCambio" runat="server" Visible="false">
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn-primary"
                                    CausesValidation="False" />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel runat="server" ID="pnl8" Visible="false">
                                <!--<asp:Button ID="btneliminar" runat="server" Text="Eliminar" />-->
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-primary"
                                    CausesValidation="False" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
