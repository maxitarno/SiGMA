﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Adopciones.aspx.cs" Inherits="SiGMA.Adopciones" %>
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
                <h3>ADOPCIONES</h3>
                <h4 >Elija que desea hacer en el menú inferior</h4>
        </div>
        </div>
		<div class="row mt centered">	
			<div class="col-lg-4">
				<a class="zoom green" href="RegistrarAdopcion.aspx"><img class="img-responsive" src="assets/img/mascotas/registrarmascota.jpg" alt="" width="200px" height="300px"/></a>
				<p class="col-lg-4">REGISTRAR</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="ConsultarAdopcion.aspx"><img class="img-responsive" src="assets/img/mascotas/consultarmascota.jpg" alt="" width="200px" height="300px"/></a>
				<p class="col-lg-4">CONSULTAR</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="ConsultarAdopcion.aspx?m=1"><img class="img-responsive" src="assets/img/mascotas/modificaradopcion.jpg" alt="" width="200px" height="300px" /></a>
				<p class="col-lg-4">MODIFICAR</p>
			</div>
		</div><!-- /row -->
		<div class="row mt centered">	
			<div class="col-lg-4">
				
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="Mascotas.aspx"><img class="img-responsive" src="assets/img/mascotas/volver.jpg" alt="" width="200px" height="300px" /></a>
				<p class="col-lg-4">VOLVER</p>
			</div>
			<div class="col-lg-4">
				
			</div>
		</div><!-- /row -->
	</div><!-- /container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>