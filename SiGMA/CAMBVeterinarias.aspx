<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAMBVeterinarias.aspx.cs" Inherits="SiGMA.CAMBVeterinarias" MasterPageFile="~/PaginaMaestra.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel panel-heading">
                <h3 class="panel-title">
                    <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-md-2 col-md-offset-5">
                    <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible=false>
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                            <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible=false>
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                        <button class="close" type="button" data-dismiss="alert">
                            ×</button>
                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-5 col-md-offset-5">
                    <div class="centered">
                        <table>
                            <tr>
                                <td align="left">
                                    Por Nombre
                                </td>                 
                                <td>
                                    <asp:RadioButton ID="rbPorNombre" runat="server" Text="" GroupName="1" Checked="true" OnCheckedChanged="RbPorNombre" AutoPostBack="True" />
                                </td>
                                <td align="left">
                                    Por Domicilio
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbPorDomicilio" runat="server" Text="" GroupName="1" OnCheckedChanged="RbPorDomicilio" AutoPostBack="True" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-offset-1 col-md-5">
                <table>
                    <tr>
                        <asp:Panel ID="pnlNombre" runat="server">
                            <td>
                                Nombre:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" style="width:250px"></asp:TextBox>
                            </td>
                        </asp:Panel>
                    </tr>
                    <asp:Panel ID="pnlDomicilio" runat="server" Width="100%">
                        <tr>
                            <td>
                                Localidad:
                            </td>
                        <td>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" style="width:250px" AutoPostBack="True" OnSelectedIndexChanged="selectedIndexChange" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                        <tr>
                            <td>
                                Barrio:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBarrio" runat="server"  AutoPostBack="True" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Calle:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCalle" runat="server" AutoPostBack="True" Width="250px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Nº<asp:TextBox ID="txtNº" runat="server" Width="50px"></asp:TextBox>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr style="float:right">
                       <td>
                            <asp:Panel ID="pnlMapa" runat=server Visible=false>
                                <asp:Button ID="btnMapa" runat="server" Text="Ubicacion" 
                                    onclick="btnMapa_Click" />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                                onclick="btnBuscar_Click" />
                        </td> 
                    </tr>
                    <asp:Panel ID="pnlResultados" runat="server">
                        <tr>
                            <td>
                                Resultados:
                            </td>
                            <td>
                                <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selected" Width="250px"></asp:ListBox>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </div>
                <div class="col-md-4 col-md-offset-0">
                <table>
                    <tr>
                        <td colspan="3">   
                        </td>
                    </tr>
                    <asp:Panel ID="pnlDatos" runat="server">
                        <tr>
                            <td align="left">
                                Realiza:
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left">
                                Peluqueria
                            </td>
                            <td style="float:left">
                                <asp:CheckBox ID="chkPeluqueria" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left">
                                PetShop
                            </td>
                            <td style="float:left">
                                <asp:CheckBox ID="chkPetShop" runat="server"/> 
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left">
                                Medicinas
                            </td>
                            <td style="float:left">
                                <asp:CheckBox ID="chkMedicinas" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left">
                                Castraciones
                            </td>
                            <td style="float:left">
                                <asp:CheckBox ID="chkCastraciones" runat="server"/>                                    
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Contacto:
                            </td>
                            <td>
                                <asp:TextBox ID="txtContacto" runat="server" Width="250px"></asp:TextBox>  
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                T.E.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTE" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                    </asp:Panel>
                </table>
            </div>
            </div>
        </div>
        <div class="centered">
            <div class="centered">
                <div style="margin-left: 30%; display: table; width: 40%;">
                    <div style="display: table-row; width: 30%">
                        <div style="display: table-cell; width: 20%;">
                            <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
                            </asp:Panel>
                        </div>
                        <div style="display: table-cell; width: 20%;">
                            <asp:Panel ID="pnlModificar" runat="server" Visible="true">
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="Modificar"/>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
           OnClick="BtnRegresarClick" CausesValidation="false" />
        <br> Volver
    </div>
</asp:Content>