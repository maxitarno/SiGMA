<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CABMTipoDeDocumento.aspx.cs"
    Inherits="SiGMA.CABMTipoDeDocumento" MasterPageFile="Site.Master" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h1 class="panel-title">
                Consultar, modificar tipos de documentos
            </h1>
        </div>
        <div class="panel-body">
            <div class="tablaDiv">
                <div class="filaDiv">
                    <div class="celdaDiv">
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
            </div>
            <div class="tablaDiv">
                <div class="filaDiv">
                    <div class="celdaDiv">
                        <asp:Panel runat="server" ID="pnlNombre">
                            Nombre:
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:Panel ID="pnltxtNombre" runat="server">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox"></asp:TextBox>
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:Panel ID="pnlBuscar" runat="server">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscarClick"
                                CssClass="btn-primary" CausesValidation="False" />
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un tipo de documento"
                            ControlToValidate="txtNombre" ValidationGroup="1" CssClass="Validator" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="tablaDiv">
                <div class="filaDiv">
                    <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                        <div class="celdaDiv">
                            Resultados:
                        </div>
                        <div class="celdaDiv">
                            <asp:ListBox ID="lstResultados" runat="server" CssClass="ListBox"></asp:ListBox>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="tablaDiv">
                <div class="filaDiv">
                    <div class="celdaDiv">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlRegistrar" runat="server">
                                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrarClick"
                                            CssClass="btn-primary" ValidationGroup="1" />
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="pnlSeleccionar" runat="server" Visible="false">
                                        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="BtnSeleccionarClick"
                                            CssClass="btn-primary" CausesValidation="False" />
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="pnlCambio" runat="server" Visible="false">
                                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="BtnModificarClick"
                                            CssClass="btn-primary" CausesValidation="true" />
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel runat="server" ID="pnl8" Visible="false">
                                        <!--<asp:Button ID="btneliminar" runat="server" Text="Eliminar" />-->
                                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiarClick"
                                            CssClass="btn-primary" CausesValidation="False" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
