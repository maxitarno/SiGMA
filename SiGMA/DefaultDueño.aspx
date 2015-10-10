<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DefaultDueño.aspx.cs" Inherits="SiGMA.DefaultDueño" %>
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
<div class="container fluid">
    <div class="row">
        <div class="col-lg-8 col-lg-offset-2 centered">
                <h3 >Elija que desea hacer en el menú inferior</h3>
        </div>
        </div>
		<div class="row">	
			<div class="col-lg-4 col-md-4">
                <div class="thumbnail">    
				    <a class="zoom green" href="MiPerfil.aspx"><img class="img-responsive img-circle" src="assets/img/menu/miperfil.png" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>MI PERFIL</h4> </div>
                 </div>
			</div>
			<div class="col-lg-4 col-md-4">
                <div class="thumbnail"> 
				    <a class="zoom green" href="MisMascotas.aspx"><img class="img-responsive img-circle" src="assets/img/menu/mascotas.png" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>MIS MASCOTAS</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
				<div class="thumbnail">
                    <a class="zoom green" href="SerVoluntario.aspx"><img class="img-responsive img-circle" src="assets/img/menu/servoluntario.png" alt="" width="200px" height="300px" /></a>
				    <div class="caption centered"><h4>SER VOLUNTARIO</h4> </div>
                </div>
			</div>
		</div><!-- /row -->
		<div class="row">	
			<div class="col-lg-4 col-md-4">
                <div class="thumbnail">
			        <a class="zoom green" href="EnConstruccion.aspx"><img class="img-responsive img-circle" src="assets/img/menu/ultimaspublicaciones.png" alt="" width="200px" height="300px"/></a>
			        <div class="caption centered"><h4>ULTIMAS PUBLICACIONES</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
                <div class="thumbnail">
				    <a class="zoom green" href="VeterinariasBarrio.aspx"><img class="img-responsive img-circle" src="assets/img/menu/veterinarias.png" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>VETERINARIAS</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
                <div class="thumbnail">
				    <a class="zoom green" href="Sugerencia.aspx"><img class="img-responsive img-circle" src="assets/img/menu/sugerencias.png" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>BUZÓN DE SUGERENCIAS</h4> </div>
                </div>
			</div>
		</div><!-- /row -->
	</div><!-- /container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>

