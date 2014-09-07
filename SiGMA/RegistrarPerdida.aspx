<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPerdida.aspx.cs" Inherits="SiGMA.RegistrarPerdida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!-- encabezado -->
<!-- fin encabezado -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h1 class="panel-title">
                   Registrar Perdida
                </h1>
            </div>
            <div class="panel-body">
               <div class="almedio">
                    <asp:Panel runat="server" ID="pnlCorrecto" class="alert alert-dismissable alert-success"
                    Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                    <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlInfo" class="alert alert-dismissable alert-info"
                    Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlAtento" class="alert alert-dismissable alert-danger"
                    Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </asp:Panel>

                    <asp:Panel ID="pnlBuscarPor" runat="server" Width="100%">
                        <table>
                            <tr>
                                <td colspan="2" align="justify">
                                    <asp:Panel ID="pnlVoluntario" runat="server" Visible="false">
                                        <table>
                                        <tr>
                                        <td valign="middle">
                                                Mascota:&nbsp
                                        </td>
                                        <td>
                                                <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox>
                                        </td>
                                        <td colspan="3" rowspan="2">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-primary" onclick="btnBuscar_Click" />
                                        </td>
                                        </tr>
                                        </table>
                                        <br />
                                        </asp:Panel>
                                </td>
                                </tr>
                                <tr>
                                <td colspan="2" align="right">
                                    <asp:Panel ID="pnlDueño" runat="server" Visible="false">
                                    <table width="100%">
                                        <tr>
                                        <td>
                                            Mascota:
                                        </td>
                                        <td colspan="3">
                                            <asp:ListBox ID="lstMascotas" runat="server" Width="100%"></asp:ListBox>
                                        </td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>

               </div>
            </div>
        </div>
    </div>
</asp:Content>
