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
                    Registrar veterinarias
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
            <div class="col-md-offset-1 col-md-5">
                <table>
                    <tr>
                        <td Width="25%">
                            Por Nombre
                        </td>
                        <td Width="12.5%">
                            <asp:RadioButton ID="rbPorNombre" runat="server" Text="" GroupName="1" Checked="true" />
                        </td>
                        <td Width="25%">
                            Por Domicilio
                        </td>
                        <td Width="12.5%">
                            <asp:RadioButton ID="rbPorDomicilio" runat="server" Text="" GroupName="1" />
                        </td>
                    </tr>
                    <tr>
                        <asp:Panel ID="pnlNombre" runat="server">
                            <td>
                                Nombre:
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </asp:Panel>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                                onclick="btnBuscar_Click" />
                        </td>
                    </tr>
                    <asp:Panel ID="pnlDomicilio" runat="server" Width="100%">
                        <tr>
                            <td>
                                Localidad:
                            </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlLocalidad" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="selectedIndexChange">
                            </asp:DropDownList>
                        </td>
                    </tr>
                        <tr>
                        <td>
                            Barrio:
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlBarrio" runat="server" Width="100%" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                        <tr>
                        <td>
                            Calle:
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlCalle" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel ID="pnlResultados" runat="server">
                        <tr>
                        <td>
                            Resultados:
                        </td>
                        <td>
                            <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selected"></asp:ListBox>
                        </td>
                    </tr>
                    </asp:Panel>
                </table>
            </div>
            <div class="col-md-5 col-md-offset-1">
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlGoogle" runat="server" Width="100%" BorderStyle="Solid">
                            </asp:Panel>
                        </td>
                    </tr>
                    <asp:Panel ID="pnlDatos" runat="server">
                        <tr>
                        <td colspan="2">
                            Realiza:
                        </td>
                    </tr>
                        <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="chkPeluqueria" runat="server" Text="Peluqueria"/>
                            <br />
                            <asp:CheckBox ID="chkPetShop" runat="server" Text="PetShop"/>
                            <br />
                            <asp:CheckBox ID="chkMedicinas" runat="server" Text="Medicinas"/>
                            <br />
                            <asp:CheckBox ID="chkCastraciones" runat="server" Text="Castraciones"/>
                        </td>
                    </tr>
                        <tr>
                        <td>
                            Contacto:
                        </td>
                        <td>
                            <asp:TextBox ID="txtContacto" runat="server" Width="100%"></asp:TextBox>  
                        </td>
                    </tr>
                        <tr>
                            <td>
                                T.E.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTE" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </div>
        </div>
        <div class="centered">
            <div class="centered">
                <div style="margin-left: 30%; display: table; width: 40%;">
                    <div style="display: table-row; width: 30%">
                        <div style="display: table-cell; width: 20%;">
                            <asp:Panel ID="pnlRegistrar" runat="server" Visible="false">
                                
                            </asp:Panel>
                        </div>
                        <div style="display: table-cell; width: 20%;">
                            <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
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