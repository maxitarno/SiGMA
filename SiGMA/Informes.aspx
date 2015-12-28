<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="SiGMA.Informes" MasterPageFile="PaginaMaestra.Master" %>
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
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container pt">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 centered">
                <h3>Informes</h3>
                <h4 >Elija que desea hacer en el menú inferior</h4>
            </div>
            <div class="col-lg-4 col-md-4">
				<div class="thumbnail">    
				    <a class="zoom green" href="Graficos.aspx"><img class="img-responsive img-circle" src="imagenes/graficos.jpg" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>Graficos</h4> </div>
                 </div>
			</div>
            <div class="col-lg-4 col-md-4">
				<div class="thumbnail">    
				    <a class="zoom green" href="SeleccionarInformes.aspx"><img class="img-responsive img-circle" src="imagenes/listados.jpg" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>Listados</h4> </div>
                 </div>
			</div>
        </div>
    </div>
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                        OnClick="BtnRegresarClick" CausesValidation="false"/>
                    <br /> VOLVER
    </div>
</asp:Content>
