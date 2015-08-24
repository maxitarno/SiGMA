<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true"
    CodeBehind="ConsultarPerdida.aspx.cs" Inherits="SiGMA.ConsultarPerdida" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
   <script type="text/javascript" src="assets/calendario_dw/jquery-1.4.4.min.js"></script>
   <script type="text/javascript" src="assets/calendario_dw/calendario_dw.js"></script>
   
   <script type="text/javascript">
       (function ($) {
           $(document).ready(function () {
               $(".campofecha").calendarioDW();
           })
       })(jQuery);
      </script>

    <script type="text/javascript">
        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h3>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-4 col-md-offset-4">
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
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div style="margin-left: 30%; display: table; width: 40%;">
                    <div style="display: table-row; width: 30%">
                        <asp:Panel ID="pnlBuscarPor" runat="server">
                            <div style="display: table-cell; width: 20%; vertical-align: top;">
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
                                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
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
                                                            Seleccione una Mascota:
                                                            <asp:ListBox ID="lstMascotas" runat="server" Width="100%" OnSelectedIndexChanged="lstMascotas_SelectedIndexChanged"
                                                                AutoPostBack="True"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <div style="display: table-cell; width: 20%;">
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlRegistrarPerdida" runat="server" Visible="false">
                    <div style="margin-left: 20%; display: table; width: 60%;">
                        <div style="display: table-row; width: 30%;">
                            <div style="display: table-cell; width: 30%;">
                                <asp:Panel Visible="false" runat="server" ID="pnlImagen">
                                    <img id="imgprvw" style="border: 2px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                                </asp:Panel>
                            </div>
                            <div style="display: table-cell; width: 22%; vertical-align: top;">
                                <table>
                                    <tr><!--agregado para el mapa-->
                                        <td style="float:left">
                                            <asp:Panel ID="pnlMapa" runat="server" Visible="false">
                                                <asp:Button ID="btnMapa" runat="server" Text="Ubicación" 
                                                    onclick="btnMapa_Click" />
                                            </asp:Panel>
                                        </td>
                                    </tr><!--fin-->
                                    <tr>
                                        <td>
                                            Calle y Nro:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCallePerdida" class="pull-left" runat="server" Width="75%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            -
                                            <asp:TextBox ID="txtNroCallePerdida" runat="server" Width="20%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Barrio:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBarrioPerdida" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Localidad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadPerdida" runat="server" Width="100%" AppendDataBoundItems="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha Pérdida:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFechaPerdida" class="campofecha pull-left" runat="server"  Width="90%" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Comentarios:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtComentarios" runat="server" Style="resize: none" TextMode="MultiLine"
                                                Rows="3" Columns="20" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                            -
                                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="display: table-row; width: 30%">
                            <div class="col-md-12 col-md-offset-1" style="padding-right: 1%;">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Dueño:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDatosDueño" Enabled="false" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Domicilio:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCalles" Enabled="false" runat="server" Width="75%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            -
                                            <asp:TextBox ID="txtNroCalle" Enabled="false" runat="server" Width="20%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Barrio:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBarrios" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Localidad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidades" Enabled="false" runat="server" Width="100%"
                                                AppendDataBoundItems="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mascota:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMascotaPerdida" ReadOnly="True" Enabled="false" runat="server"
                                                Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Especie:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" Enabled="false" AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Edad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEdad" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Raza:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Sexo:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSexo" Enabled="false" runat="server" Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Color:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlColor" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False" /><br />
            VOLVER
        </div>
    </div>
</asp:Content>
