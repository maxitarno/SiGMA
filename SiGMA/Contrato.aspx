<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contrato.aspx.cs" Inherits="SiGMA.Contrato"
    MasterPageFile="PaginaMaestra.Master" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
    <div class="container pt">
        <div class="centered">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Contrato
                    </h3>
                </div>
                <div class="panel-body">
                    <CR:CrystalReportViewer ID="CrContrato" runat="server" AutoDataBind="true" PrintMode="Pdf" />
                    <div style="margin-left: 30%; display: table; width: 40%;">
                        <div style="display: table-row; width: 30%">
                            <div style="display: table-cell; width: 20%;">
                                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptarClick"/>
                            </div>
                            <div style="display: table-cell; width: 20%;">
                                <asp:Button ID="BtnCancelar" runat="server" Text="Rechazar" OnClick="BtnRechazarClick"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /container -->
</asp:Content>
