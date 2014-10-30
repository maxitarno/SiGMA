<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SiGMA.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container pt">
    <div class="row">
        <div class="col-lg-8 col-lg-offset-2 centered">
                <h3 >Elija que desea hacer en el menú inferior</h3>
        </div>
        </div>
		<div class="row mt centered">	
			<div class="col-lg-4">
				<a class="zoom green" href="Usuarios.aspx"><img class="img-responsive" src="assets/img/menu/usuarios.png" alt="" width="215px" height="315px"/></a>
				<p class="col-lg-4">USUARIOS</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="Mascotas.aspx"><img class="img-responsive" src="assets/img/menu/mascotas.png" alt="" width="200px" height="300px"/></a>
				<p class="col-lg-4">MASCOTAS</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="EnConstruccion.aspx"><img class="img-responsive" src="assets/img/menu/difusion.png" alt="" width="200px" height="300px" /></a>
				<p class="col-lg-4">DIFUSIÓN</p>
			</div>
		</div><!-- /row -->
		<div class="row mt centered">	
			<div class="col-lg-4">
				<a class="zoom green" href="EnConstruccion.aspx"><img class="img-responsive" src="assets/img/menu/voluntarios.png" alt="" width="200px" height="300px"/></a>
				<p class="col-lg-4">VOLUNTARIOS</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="EnConstruccion.aspx"><img class="img-responsive" src="assets/img/menu/veterinarias.png" alt="" width="200px" height="300px"/></a>
				<p class="col-lg-4">VETERINARIAS</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="Administracion.aspx"><img class="img-responsive" src="assets/img/menu/administracion.png" alt="" width="200px" height="300px"/></a>
				<p class="col-lg-4">ADMINISTRACIÓN</p>
			</div>
		</div><!-- /row -->
	</div><!-- /container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>

