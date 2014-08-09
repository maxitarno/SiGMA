﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs"
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
                            Por persona:&nbsp<asp:RadioButton ID="rbPorPersona" runat="server" GroupName="1" ValidationGroup="1" />
                            <br />
                        </td>
                        <td>
                            Por usuario:&nbsp<asp:RadioButton ID="rbPorUsuario" runat="server" GroupName="1" ValidationGroup="1" />
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
                            <asp:Button CssClass="Button" ID="btnBuscar" runat="server" Text="Buscar" />
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
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="TextBox" Width=100%></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre:&nbsp
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width=100%></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Rol:&nbsp
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRoles" runat="server" CssClass="DropDownList" Width=100%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="Button" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
