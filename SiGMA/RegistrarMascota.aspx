<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarMascota.aspx.cs" Inherits="SiGMA.RegistrarMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 199px;
            text-align: left;
        }
        .style2
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                            <asp:Panel ID="pnlDatos" runat="server">
                                <table>
                                 <tr>
                                    <td class="style2">Nombre:&nbsp                                       
                                    </td>
                                    <td class="style1">
                                            <asp:TextBox ID="txtMascota" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                    <tr>
                                        <td class="style2">
                                            Especie:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlEspecie"
                                            AutoPostBack="true" runat="server" 
                                                onselectedindexchanged="ddlEspecie_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Raza:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlRaza" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Edad:
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlEdad" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Cuidado especial:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:TextBox ID="txtCuidadoEspecial" runat="server"
                                             Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Color:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlColor" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Trato con animales:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlTratoAnimales" runat="server">
                                            <asp:ListItem Selected="True" Value="0" Text=""></asp:ListItem>
                                                <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Trato con niños:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlTratoNinios" runat="server">
                                            <asp:ListItem Selected="True" Value="0" Text=""></asp:ListItem>
                                                <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Caracter:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlCaracter" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Observaciones:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:TextBox ID="txtObservaciones" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Alimentacion especial:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:TextBox ID="txtAlimentacionEspecial" runat="server" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Sexo:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlSexo" runat="server" Width="100%">
                                                <asp:ListItem Selected="True" Value="0" Text=""></asp:ListItem>
                                                <asp:ListItem Text="Hembra" Value="1"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Macho"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Fecha:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" ></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="almedio">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlBtnRegistrar" runat="server">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn-primary" />
                                        </asp:Panel>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Panel ID="pnlBtnLimpiar" runat="server">
                                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-primary" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
