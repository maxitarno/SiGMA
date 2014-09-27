<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CABMTipoDeDocumento.aspx.cs"
    Inherits="SiGMA.CABMTipoDeDocumento" MasterPageFile="PaginaMaestra.Master" %>

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
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Consultar, modificar tipos de documentos
                </h3>
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
            <div class="panel-body">
                <div class="col-md-2 col-md-offset-4">
                    <div style="margin-left: 30%; display: table; width: 40%;">
                        <div style="display: table-row; width: 30%">
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel runat="server" ID="pnlNombre">
                                    Nombre:
                                </asp:Panel>
                            </div>
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel ID="pnltxtNombre" runat="server">
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                </asp:Panel>
                            </div>
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel ID="pnlBuscar" runat="server">
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscarClick"
                                        CausesValidation="False" CssClass="btn-primary"/>
                                </asp:Panel>
                            </div>
                            <div style="display: table-cell; width: 20%;">
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un tipo de documento"
                                    ControlToValidate="txtNombre" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div style="margin-left: 30%; display: table; width: 40%;">
                        <div style="display: table-row; width: 30%;>
                            <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                                <div style="display: table-cell; width: 20%;">
                                    Resultados:
                                </div>
                                <div style="display: table-cell; width: 20%;">
                                    <asp:ListBox ID="lstResultados" runat="server"></asp:ListBox>
                                </div>
                            </asp:Panel>
                        </div>
                        <div style="display: table-row; width: 30%">
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel ID="pnlRegistrar" runat="server">
                                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrarClick"
                                        ValidationGroup="1" CssClass="btn-primary"/>
                                </asp:Panel>
                            </div>
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel ID="pnlSeleccionar" runat="server" Visible="false">
                                    <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="BtnSeleccionarClick"
                                        CausesValidation="False" CssClass="btn-primary"/>
                                </asp:Panel>
                            </div>
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel ID="pnlCambio" runat="server" Visible="false">
                                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="BtnModificarClick"
                                        CausesValidation="true" CssClass="btn-primary"/>
                                </asp:Panel>
                            </div>
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel runat="server" ID="pnl8" Visible="false">
                                    <!--<asp:Button ID="btneliminar" runat="server" Text="Eliminar" />-->
                                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiarClick"
                                        CausesValidation="False" CssClass="btn-primary"/>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png" OnClick="BtnRegresarClick"/>
            </div>
        </div>
    </div>
</asp:Content>
