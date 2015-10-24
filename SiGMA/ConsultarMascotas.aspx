﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarMascotas.aspx.cs"
    Inherits="SiGMA.ConsultarMascotasaspx" MasterPageFile="~/PaginaMaestra.Master" Culture="Auto" UICulture="Auto"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
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

    <link href="assets/calendario_dw/calendario_dw-estilos.css" type="text/css" rel="STYLESHEET"/>
   
    <script type="text/javascript">
        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgprvw').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                <asp:Label ID="lblTitulo"  runat="server" Text="Label"></asp:Label></h3>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-2 col-md-offset-5">
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
            <div class="centered">
                <asp:RadioButton ID="rbPorDuenio" runat="server" GroupName="1" ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RbPorDuenio" text="Por Dueño"/>&nbsp
                <asp:RadioButton ID="rbPorMascota" runat="server" GroupName="1" ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RbPorMascota" Checked="True" text="Por Mascota"/>
            </div>
            <div class="panel-body">
                <div class="col-md-3 col-md-offset-1">
                    <div style="margin-left: 30%; display: table; width: 40%;">
                        <div style="display: table-row; width: 30%">
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel Visible="false" runat="server" ID="imgImagen">
                                    <%--<img id="imgprvw" width="140px" height="140px"/>--%>
                                    <img id="imgprvw" style="border: 2px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                                </asp:Panel>
                            </div>
                        </div>
                        <div style="display: table-row; width: 30%">
                            <div style="display: table-cell; width: 20%;">
                                <table>
                                    <tr>
                                        <asp:Panel ID="pnlNo" runat=server visible=false>
                                            <td colspan = 2 align =justify>
                                                No mostrar mascota&nbsp<asp:CheckBox ID="chNoMostrar" Visible = "true" runat = "server"/>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlNombre" Visible="false" runat="server">
                                                Nombre:
                                            </asp:Panel>
                                        </td>
                                        <td>
                                            <asp:Panel ID="pnltxtNombreDueñio" Visible="false" runat="server">
                                                <asp:TextBox ID="txtNombreDueñio" runat="server"></asp:TextBox> 
                                            </asp:Panel>
                                        </td>
                                        <td>
                                            <asp:Panel ID="pnlboton" runat="server" Visible="false">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscarClick" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="middle">
                                            <asp:Panel ID="pnlmascota" Visible="false" runat="server">
                                                mascota:
                                            </asp:Panel>
                                        </td>
                                        <td>
                                            <asp:Panel ID="pnltxtMascota" Visible="false" runat="server">
                                                <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox> 
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlfiltros" runat="server" Visible="false">
                                        <tr>
                                            <td>
                                                Especie:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" CssClass="DropDownList"
                                                    OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Raza:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRaza" runat="server" Width="100%" CssClass="DropDownList"
                                                    AppendDataBoundItems="false">
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
                                                Sexo:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSexo" runat="server" Width="100%" CssClass="DropDownList">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Estado:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDownList" Width="100%"
                                                    AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Trato animales:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTratoAnimales" runat="server" Width="100%">
                                                    <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción"></asp:ListItem>
                                                    <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Trato niños:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTratoNinios" runat="server" Width="100%">
                                                    <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción --"></asp:ListItem>
                                                    <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtnBuscarOtro" runat="server" ImageUrl="~/imagenes/buscar.jpg" OnClick="BtnBuscarOtroClick" CausesValidation="false" Width="65%" Visible="false"/>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Resultados:
                                                        </td>
                                                        <td>
                                                            <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="lstResultados_SelectedIndexChanged"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlbtnSeleccionar" runat="server" Visible="false" Style="display: inline">
                                                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="BtnSeleccionarClick"
                                                    CausesValidation="False" Style="float: left" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-md-offset-2">
                    <table>
                        <asp:Panel ID="pnlDatos" runat="server">
                            <tr>
                                <td>
                                    Categoria:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="TextBox" ReadOnly="True"
                                        Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cuidado especial:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCuidadoEspecial" runat="server" Style="resize: none" TextMode="MultiLine"
                                        Rows="5" Columns="25" CssClass="TextBox" Width="100%" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Color:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlColor" runat="server" Width="100%" CssClass="DropDownList"
                                        AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Carater:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCaracter" runat="server" CssClass="DropDownList" Width="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Observaciones:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBox" Width="100%"
                                        Style="resize: none" TextMode="MultiLine" Rows="5" Columns="25" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Alimentacion especial:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAlimentacionEspecial" runat="server" CssClass="TextBox" Width="100%"
                                        Style="resize: none" TextMode="MultiLine" Rows="5" Columns="25" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2">
                                    Fecha:
                                </td>
                                <td>
                                    <asp:Panel ID="pnlFecha" runat="server" Visible="true">
                                                <asp:TextBox ID="txtFecha" runat="server"  Width="90%" />
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/calendario_dw/calendario.png" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" 
                                                    runat="server" TargetControlID="txtFecha" 
                                                    PopupButtonID="Image1">
                                                </ajaxToolkit:CalendarExtender>
                                        </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="file" runat="server" id="fuImagenMascota" onchange="showimagepreview(this)" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </asp:Panel>
                    </table>
                    <div style="margin-left: auto; margin-right: auto">
                        <asp:Panel ID="pnlbotones" runat="server" Visible="false" Width="600px">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="BtnModificarClick"
                                 Style="float: left" />
                            <asp:Button ID="btnGenerarQR" runat="server" Text="Generar Codigo QR" OnClick="btnGenerarQR_Click"
                                Style="float: left" CausesValidation="false"/>
                            <asp:Button ID="btnAdopcion" runat="server" Text="Poner en adopcion"  
                                Style="float: left" onclick="btnAdopcion_Click" CausesValidation="false"/>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png" OnClick="BtnRegresarClick" CausesValidation="false"/>
        </br>
        VOLVER
    </div>
</asp:Content>
