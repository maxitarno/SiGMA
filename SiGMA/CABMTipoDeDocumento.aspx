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
    <div class="panel panel-default">
        <div class="panel panel-default">
            <div class="panel-heading">
              <div class="centered">
                  <h3 class="panel-title">
                      Consultar, modificar tipos de documentos
                  </h3>
              </div>
            </div>
            <div class="panel-body">
                <div class="col-md-12">
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
            </div>
            <div class="panel-body">
                <div class="col-md-12">
                    <div class="col-md-2 col-md-offset-4">
                        Nombre:
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un tipo de documento"
                            ControlToValidate="txtNombre" ValidationGroup="1" Display="Dynamic" Font-Underline="False"
                            BorderColor="Red" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-2 col-md-offset-4">
                        <asp:Panel ID="pnlBuscar" runat="server">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscarClick"
                                CausesValidation="False" />
                        </asp:Panel>
                    </div>
                </div>
                <div class="col-md-12">
                        <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                            <div class="col-md-2 col-md-offset-4">
                                Resultados:&nbsp&nbsp&nbsp
                            </div>
                            <div class="col-md-2">
                                <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="BtnSeleccionarClick" Width="100%"></asp:ListBox>
                            </div>
                        </asp:Panel>
                </div>
                <div class="col-md-12">
                    <div class="col-md-1 col-md-offset-5">
                        <asp:Panel ID="pnlRegistrar" runat="server">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrarClick"
                                ValidationGroup="1" />
                        </asp:Panel>
                    </div>
                    <div class="col-md-1">
                        <asp:Panel ID="pnlCambio" runat="server" Visible="false">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="BtnModificarClick"
                                CausesValidation="true" />
                        </asp:Panel>
                    </div>
                    <div class="col-md-1">
                        <asp:Panel runat="server" ID="pnl8" Visible="false">
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiarClick"
                                CausesValidation="False" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
            OnClick="BtnRegresarClick" CausesValidation="False" /><br />
        VOLVER
    </div>
</asp:Content>
