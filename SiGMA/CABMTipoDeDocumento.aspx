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
                <table>
                    <tr>
                        <td>
                            <asp:Panel runat=server ID=pnlNombre>
                                Nombre:<asp:TextBox ID="txtNombre" runat="server" CssClass=TextBox></asp:TextBox>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
