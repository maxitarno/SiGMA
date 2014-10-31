<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listas.aspx.cs" Inherits="SiGMA.listas" MasterPageFile="~/PaginaMaestra.Master" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Informe
                    </h3>
                </div>
                <div class="centered">
                    <CR:CrystalReportViewer ID="crtListas" runat="server" AutoDataBind="true" />
                </div>
                <div class="centered">
                    <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                        OnClick="BtnRegresarClick" CausesValidation="false"/>
                    <br /> VOLVER
                </div>
            </div>
        </div>
    </div>
</asp:Content>
