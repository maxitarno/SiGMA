<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CABMTipoDeDocumento.aspx.cs" Inherits="SiGMA.CABMTipoDeDocumento" MasterPageFile="Site.Master" %>
<asp:Content ContentPlaceHolderID=HeadContent runat=server>
</asp:Content>
<asp:Content ContentPlaceHolderID=MainContent runat=server>
    <div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h1 class="panel-title">
                    Consultar, modificar, eliminar tipos de documentos
                </h1>
            </div>
            <div class="panel-body">
                <div class="almedio">
                    <table>
                        <tr>
                            <td>
                                <asp:Panel runat=server ID=pnlNombre>
                                    Nombre:
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Panel ID=pnltxtNombre runat=server>
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                </asp:Panel>
                            </td>

                            <td>
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNombre" ValidationGroup="1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <asp:Panel ID=pnlResultado runat=server>
                                <td>
                                    Resultados:
                                </td>
                                <td>
                                    <asp:ListBox ID="lstResulttados" runat="server" CssClass="ListBox"></asp:ListBox>
                                </td>
                            </asp:Panel>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID=pnRegistrar runat=server>
                                    <asp:Button ID="btnRregistrar" runat="server" Text="Registrar" />
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Panel ID=pnlSeleccionar runat=server>
                                    <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" />
                                </asp:Panel>
                            </td>
                            <td colspan=2>
                                <asp:Panel ID=pnlBotones runat=server Width=100%>
                                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
                                    <asp:Button ID="btneliminar" runat="server" Text="Eliminar" />
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
