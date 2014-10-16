<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarAdopcion.aspx.cs"
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
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel panel-default>
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Registrar Adopción
                    </h3>
                </div>
                <div class="panel-body">
                    <div class="centered">
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
                    <div class="centered">
                        <div style="margin-left: 30%; display: table; width: 40%;">
                            <div style="display: table-row; width: 30%">
                                <div style="display: table-cell; width: 20%;">
                                    Fecha:
                                </div>
                                <div style="display: table-cell; width: 20%;">
                                    <asp:TextBox ID="txtFecha" runat="server" ReadOnly="True" ViewStateMode="Enabled"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="centered">
                        <asp:RadioButton ID="rbPorNombre" runat="server" GroupName="1" ValidationGroup="1"
                            AutoPostBack="True" OnCheckedChanged="rbPorName" Checked="False" Text=" Por Nombre" />&nbsp&nbsp
                        <asp:RadioButton ID="rbPorDNI" runat="server" OnCheckedChanged="rbPorTipo" AutoPostBack="True"
                            ValidationGroup="1" GroupName="1" Checked="True" Text=" Por DNI" />
                    </div>
                    <div class="col-md-3 col-md-offset-1">
                        <div style="margin-left: 30%; display: table; width: 40%;">
                            <div style="display: table-row; width: 30%">
                                <asp:Panel ID="pnlNombre" runat="server" Visible="false">
                                    <div style="display: table-cell; width: 20%;">
                                        Nombre:
                                    </div>
                                    <div style="display: table-cell; width: 20%;">
                                        <asp:TextBox ID="txtNombreDuenio" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                            </div>
                            <asp:Panel ID="pnlDocumento" runat="server" Visible="false">
                                <div style="display: table-row; width: 30%">
                                    <div style="display: table-cell; width: 20%;">
                                        Tipo de documento:
                                    </div>
                                    <div style="display: table-cell; width: 20%;">
                                        <asp:DropDownList ID="ddlTipo" runat="server" ViewStateMode="Enabled" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="display: table-row; width: 30%">
                                    <div style="display: table-cell; width: 20%;">
                                        Nº de doumento:
                                    </div>
                                    <div style="display: table-cell; width: 20%;">
                                        <asp:TextBox ID="txtDNI" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div style="display: table-row; width: 30%;">
                                <div style="display: table-cell; width: 20%; margin-right=50%;">
                                    <asp:Panel ID="pnlBuscar" runat="server" Visible="false">
                                        <asp:Button ID="btnBuscarDuenio" runat="server" Text="Buscar" OnClick="btnBuscarDuenioClick" />
                                    </asp:Panel>
                                </div>
                            </div>
                            <asp:Panel ID="pnlResultadosDuenio" runat="server" Visible="false">
                                <div style="display: table-row; width: 30%">
                                    <div style="display: table-cell; width: 20%;">
                                        Resultados:
                                    </div>
                                    <div style="display: table-cell; width: 20%;">
                                        <asp:ListBox ID="lstResultadosDuenios" runat="server" ViewStateMode="Enabled" Width="100%">
                                        </asp:ListBox>
                                    </div>
                                </div>
                                <div style="display: table-row; width: 30%">
                                    <div style="display: table-cell; width: 20%;">
                                        <asp:Button ID="btnSeleccionarDuenio" runat="server" Text="Seleccionar" OnClick="btnSeleccionarDuenioClick"
                                            ViewStateMode="Enabled" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
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
                                            AutoPostBack="True" ViewStateMode="Enabled" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Raza:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRaza" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Edad:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEdad" runat="server" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"
                                            ViewStateMode="Enabled" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sexo:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSexo" runat="server" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"
                                            ViewStateMode="Enabled" Width="100%">
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
                                        <asp:ListBox ID="lstResultadosMascotas" runat="server" ViewStateMode="Enabled" Width="100%">
                                        </asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSeleccioarMascota" runat="server" Text="Seleccionar" OnClick="btnSeleccionarMascota" />
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                    </div>
                    <div class="col-md-3 col-md-offset-2">
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
                    </div>
                </div>
                <div class="centered">
                    <div class="centered">
                        <div class="centered">
                            <div style="margin-left: 30%; display: table; width: 40%;">
                                <div style="display: table-row; width: 30%">
                                    <div style="display: table-cell; width: 20%;">
                                        <asp:Panel ID="pnlRegistrar" runat="server" Visible="false">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Generar contrato" OnClick="btnRegistrarClick" />
                                        </asp:Panel>
                                    </div>
                                    <%--<div style="display: table-cell; width: 20%;">
                                        <asp:Panel ID="pnllimpiar" runat="server" Visible="false">
                                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
                                        </asp:Panel>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
