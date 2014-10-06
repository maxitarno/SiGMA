﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarAdopcion.aspx.cs"
    Inherits="SiGMA.RegistrarAdopcion" MasterPageFile="PaginaMaestra.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../../docs-assets/ico/favicon.png">
    <title>SIGMA</title>
    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="assets/css/main.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="assets/js/hover.zoom.js"></script>
    <script src="assets/js/hover.zoom.conf.js"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                        <asp:TextBox ID="txtN" runat="server" ReadOnly="True" ViewStateMode="Enabled"></asp:TextBox>
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
                                                        AutoPostBack="True" OnCheckedChanged="rbPorName" Checked="False" />&nbsp
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
                                            <asp:TextBox ID="txtNombreDuenio" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                                        </td>
                                    </asp:Panel>
                                    <td>
                                        <asp:Panel ID="pnlBuscar" runat="server" Visible="false">
                                            <asp:Button ID="btnBuscarDuenio" runat="server" Text="Buscar" OnClick="btnBuscarDuenioClick" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlDocumento" runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            Tipo de documento:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTipo" runat="server" ViewStateMode="Enabled">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Nº de doumento:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDNI" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="pnlResultadosDuenio" runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            Resultados:
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lstResultadosDuenios" runat="server" ViewStateMode="Enabled"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSeleccionarDuenio" runat="server" Text="Seleccionar" OnClick="btnSeleccionarDuenioClick"
                                                ViewStateMode="Enabled" />
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
                                            <asp:TextBox ID="txtNombreMascota" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuscarMascota" runat="server" Text="Buscar" OnClick="btnBuscarMascotaClick" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Especie:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEspecies" runat="server" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"
                                                AutoPostBack="True" ViewStateMode="Enabled">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Raza:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRaza" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Edad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEdad" runat="server" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"
                                                ViewStateMode="Enabled">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Sexo:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSexo" runat="server" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"
                                                ViewStateMode="Enabled">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel Visible="false" runat="server" ID="pnlResultadosMascotas">
                                    <tr>
                                        <td>
                                            Resultados:
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lstResultadosMascotas" runat="server" ViewStateMode="Enabled"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSeleccioarMascota" runat="server" Text="Seleccionar" OnClick="btnSeleccionarMascota" />
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </table>
                            Fecha:&nbsp<asp:TextBox ID="txtFecha" runat="server" ReadOnly="True" ViewStateMode="Enabled"></asp:TextBox>
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
                                            <asp:TextBox ID="txtNombreD" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tipo de documento:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTipoDeDocumento" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Nº de documento:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNº" runat="server" ReadOnly="True" ViewStateMode="Enabled" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Localidad:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLocalidad" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Barrio:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBarrio" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Calle:<asp:TextBox ID="txtCalle" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            Nº:<asp:TextBox ID="txtNro" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
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
                                            <asp:TextBox ID="txtNombreM" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Especie:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEspecie" runat="server" ViewStateMode="Enabled" ReadOnly="true"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Raza:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRaza" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Sexo:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSexo" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Edad:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEdad" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlRegistrar" runat="server" Visible="false">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrarClick" />
                            </asp:Panel>
                            <!--<asp:Panel ID=pnllimpiar runat=server Visible=false>
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
                           </asp:Panel>-->
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
