<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VeterinariasBarrio.aspx.cs" Inherits="SiGMA.VeterinariasBarrio" %>
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
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h3 class="panel-title">
                Contacto</h3>
            </div>

            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-5 col-md-offset-5">
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
                <div>
                    <div class="col-md-4 col-md-offset-4">
                        <asp:DropDownList ID="ddlBarrio" runat="server" 
                            onselectedindexchanged="ddlBarrio_SelectedIndexChanged" 
                            AutoPostBack="True">
                            
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
    </div>
</asp:Content>

