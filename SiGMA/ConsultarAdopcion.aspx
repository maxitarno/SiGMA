<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarAdopcion.aspx.cs"
    Inherits="SiGMA.ConsultarAdopcion" MasterPageFile="PaginaMaestra.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="panel panel-default">
            <div class="panel panel-default">
                <div class="centered">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h3>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-md-4 col-md-offset-4">
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
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="col-md-2 col-md-offset-4">
                            Por Nombre <asp:RadioButton ID="rbPorNombreMascota" runat="server" GroupName="1"
                                AutoPostBack="True" OnCheckedChanged="RbPorN" />&nbsp&nbsp
                        </div>
                        <div class="col-md-2 col-md-offset-1">
                            Por DNI<asp:RadioButton ID="rbPorDNI" runat="server" AutoPostBack="True"
                                GroupName="1" Checked="True" OnCheckedChanged="RbPorPersona" />
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-4 col-md-offset-2">
                                    <table>
                                        <asp:Panel runat="server" Visible="false" ID="pnlPorAdopcion">
                                            <tr>
                                                <td>
                                                    Nombre de la mascota:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlPorDocumento" runat="server" Visible="false">
                                            <tr>
                                                <td>
                                                    Tipo de documento:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTipo" runat="server" Width="210px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nº de documento:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNº" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlBuscar" runat="server" Visible="false">
                                            <tr>
                                                <td align="left">
                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscarClick" />
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <asp:Panel runat="server" Visible="false" ID="pnlResultados">
                                            <tr>
                                                <td>
                                                    Resultados:
                                                </td>
                                                <td>
                                                    <asp:ListBox ID="lstResultados" runat="server" Width="210px" AutoPostBack="true" OnSelectedIndexChanged="lstResultados_SelectedIndexChanged"></asp:ListBox>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ibtnBuscarOtro" runat="server" ImageUrl="~/imagenes/buscar.jpg" onclick="ibtnBuscarOtro_Click"/>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlDatos" runat="server" Visible="false">
                                            <tr>
                                                <td>
                                                    <h5>
                                                        Datos a modificar
                                                    </h5>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Localidad:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlLocalidad" runat="server" AutoPostBack="True" Width="210px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Barrio:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBarrio" runat="server" Width="210px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Domicilio:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCalle" runat="server" Width="155px">
                                                    </asp:DropDownList><asp:TextBox ID="txtNºCalle" runat="server" Width="55px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nombre de la mascota:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNombreMascota" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </table>
                        </div>
                        <div class="col-md-6">
                        <asp:Panel ID="pnlAdopcion" Visible="false" runat="server">
                            <h5>
                                Datos de la adopcion
                            </h5>
                            <table>
                                <tr>
                                    <td>
                                        Nº de adopcion:&nbsp&nbsp&nbsp
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNºAdopcion" runat="server" Width="210px" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
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
                                        <asp:TextBox ID="txtNumeroDocumento" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                            Enabled="False"></asp:TextBox>
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
                                        Domicilio:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCalle" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                            Enabled="False" Width="155px"></asp:TextBox><asp:TextBox ID="txtNro" runat="server" ReadOnly="True" ViewStateMode="Enabled" Enabled="False"
                                            Width="55px"></asp:TextBox>
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
                                            Enabled="false"></asp:TextBox>
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
                    <div class="col-md-12">
                    <div class="col-md-2 col-md-offset-7">
                                                        <asp:Panel ID="pnlRegistrar" runat="server" Visible="false">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Generar contrato" 
                                                OnClick="BtnModificarClick" Visible="False"/>
                                        </asp:Panel>
                    </div>
                    <div class="col-md-1">
                                        <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminarClick"/>
                                        </asp:Panel>
                    </div>
                </div>
                </div>
            </div>
            <div class="centered">
                <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                    OnClick="ibtnRegresar_Click" CausesValidation="false"/>
                <br/> Volver
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
