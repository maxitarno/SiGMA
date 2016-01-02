<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Graficos.aspx.cs" Inherits="SiGMA.Graficos" MasterPageFile="~/PaginaMaestra.Master" Culture="Auto"
    UICulture="Auto" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="panel panel-default">
            <div class="panel panel-default">
                <div class="centered">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            Graficos</h3>
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
                        <div class="col-md-2 col-md-offset-5">
                            <asp:DropDownList ID="ddlListado" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlListado_SelectedIndexChanged" Width="210px">
                                <asp:ListItem Text="SIN ASIGNAR" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Tipos de voluntarios" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Mascotas por estado" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Adopciones por sexo" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Perdidas por sexo" Value="4"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Hallazgos por sexo"></asp:ListItem>
                                <asp:ListItem Value="6" Text="Mascotas por sexo y edad"></asp:ListItem>
                                <asp:ListItem value="7" Text="Hallazgos por barrio"></asp:ListItem>
                                <asp:ListItem Text="Adopciones por barrio" Value="8"></asp:ListItem>
                                <asp:ListItem Value="9" Text="Perdidas por barrio"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
      </div>
     <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
</asp:Content>
