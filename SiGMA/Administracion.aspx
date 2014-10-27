﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="SiGMA.Administracion" %>
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
                <h3>MASCOTAS</h3>
                <h4 >Elija que desea hacer en el menú inferior</h4>
        </div>
        </div>
		<div class="row mt centered">	
			<div class="col-lg-4">
				<a class="zoom green" href="AsignarPermisos.aspx"><img class="img-responsive" src="assets/img/administracion/permisos.jpg" alt="" width="200px" height="300px"/></a>
				<p class="col-lg-4">PERMISOS</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="RegistrarRoles.aspx"><img class="img-responsive" src="assets/img/administracion/roles.jpg" alt="" width="200px" height="300px"/></a>
				<p class="col-lg-4">ROLES</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="AsignarRol.aspx"><img class="img-responsive" src="assets/img/administracion/asignarrol.jpg" alt="" width="200px" height="300px" /></a>
				<p class="col-lg-4">ASIGNAR ROL</p>
			</div>
		</div><!-- /row -->
		<div class="row mt centered">	
			<div class="col-lg-4">
				<a class="zoom green" href="CABMRazas.aspx"><img class="img-responsive" src="assets/img/administracion/razas.jpg" alt="" width="200px" height="300px" /></a>
				<p class="col-lg-4">RAZAS</p>
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="CABMTipoDeDocumento.aspx"><img class="img-responsive" src="assets/img/administracion/documentos.jpg" alt="" width="200px" height="300px" /></a>
				<p class="col-lg-4">TIPOS DOCS</p>
			</div>
			<div class="col-lg-4">
                <a class="zoom green" href=""><img class="img-responsive" src="assets/img/administracion/listas.jpg" alt="" width="200px" height="300px" /></a>
                <p class="col-lg-4">INFORMES</p>
            </div>
		</div><!-- /row -->
        <div class="row mt centered">
            <div class="col-lg-4">
                <a class="zoom green" href="Default.aspx">
                    <img class="img-responsive" src="assets/img/mascotas/volver.jpg" alt="" width="200px"
                        height="300px" /></a>
                <p class="col-lg-4">
                    VOLVER</p>
            </div>
		</div><!-- /row -->
	</div><!-- /container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
