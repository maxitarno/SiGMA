﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarMascotas.aspx.cs"
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
                                        <td colspan="2" align="justify">
                                            <asp:Panel ID="pnlrdbporDuenio" runat="server">
                                                Por dueñio:&nbsp<asp:RadioButton ID="rbPorDuenio" runat="server" GroupName="1" ValidationGroup="1"
                                                    AutoPostBack="True" OnCheckedChanged="RbPorDuenio" />&nbsp
                                            </asp:Panel>
                                        </td>
                                        <td colspan="2" align="right">
                                            <asp:Panel ID="pnlrdbMascota" runat="server">
                                                Por mascota:&nbsp<asp:RadioButton ID="rbPorMascota" runat="server" GroupName="1"
                                                    ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RbPorMascota" Checked="True" />
                                            </asp:Panel>
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
                                    <td valign="middle">
                                        <asp:Panel ID="pnlNombre" Visible="false" runat="server">
                                            Nombre:&nbsp
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnltxtNombreDueñio" Visible="false" runat="server">
                                            <asp:TextBox ID="txtNombreDueñio" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlboton" runat="server" Visible="false">
                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-primary" OnClick="BtnBuscarClick" />
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvNombreDuenio" runat="server" ErrorMessage="Debe ingresar un nombre"
                                            ControlToValidate="txtNombreDueñio" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage=" Debe ingresar un nombre"
                                            ID="rfvNombre" ValidationGroup="2" Display="Dynamic" ControlToValidate="txtNombreDueñio"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        <asp:Panel ID="pnlmascota" Visible="false" runat="server">
                                            mascota:&nbsp
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnltxtMascota" Visible="false" runat="server">
                                            <asp:TextBox ID="txtMascota" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvMascota" runat="server" ErrorMessage="Debe ingresar un nombre"
                                            ControlToValidate="txtMascota" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage=" Debe ingresar un nombre"
                                            ID="rfvNombreMascota" ValidationGroup="2" Display="Dynamic" ControlToValidate="txtNombreDueñio"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlResultados" runat="server" Width="100%" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            Resultados:
                                        </td>
                                        <td colspan="3">
                                            <asp:ListBox ID="lstResultados" runat="server" Width="100%" CssClass="ListBox"></asp:ListBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlDatos" runat="server" Visible="false">
                                <table>
                                    <tr>
                                        <td>
                                            Estado:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDownList" Width="100%"
                                                AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Especie:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" CssClass="DropDownList"
                                                OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Edad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEdad" runat="server" Width="100%" CssClass="DropDownList"
                                                AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Raza:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRaza" runat="server" Width="100%" CssClass="DropDownList"
                                                AppendDataBoundItems="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Categoria:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCategoria" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Cuidado especial:&nbsp
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCuidadoEspecial" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Color:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlColor" runat="server" Width="100%" CssClass="DropDownList"
                                                AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Trato animales:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTratoAnimales" runat="server">
                                                <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción"></asp:ListItem>
                                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                                <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Trato niños:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTratoNinios" runat="server">
                                                <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción --"></asp:ListItem>
                                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                                <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Carater:&nbsp
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCaracter" runat="server" CssClass="DropDownList">
                                            </asp:DropDownList>
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
                                            <asp:DropDownList ID="ddlSexo" runat="server" Width="100%" CssClass="DropDownList">
                                                <asp:ListItem Selected="True" Value="0" Text="-- seleccione --"></asp:ListItem>
                                                <asp:ListItem Text="HEMBRA" Value="HEMBRA"></asp:ListItem>
                                                <asp:ListItem Value="MACHO" Text="MACHO"></asp:ListItem>
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
                            <table>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlbtnSeleccionar" runat="server" Visible="false">
                                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn-primary"
                                                OnClick="BtnSeleccionarClick" CausesValidation="False" />
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlbotones" runat="server" Visible="false">
                                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn-primary"
                                                OnClick="BtnModificarClick" ValidationGroup="1" />
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-primary"
                                                ValidationGroup="2" OnClick="BtnEliminarClick"/>
                                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-primary" OnClick="BtnLimpiarClick"/>
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
