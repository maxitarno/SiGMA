<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Mascotas.aspx.cs" Inherits="SiGMA.Mascotas" %>
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
                <h3>MASCOTAS</h3>
                <h4 >Elija que desea hacer en el menú inferior</h4>
        </div>
        </div>
		<div class="row">	
			<div class="col-lg-4 col-md-4">
                <div class="thumbnail">
                    <a class="zoom green" href="_Mascotas.aspx"><img class="img-responsive img-circle" src="assets/img/mascotas/registrarmascota3.jpg" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>REGISTROS</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
				 <div class="thumbnail">
                    <a class="zoom green" href="Hallazgos.aspx"><img class="img-responsive img-circle" src="assets/img/mascotas/registrarhallazgo.jpg" alt="" width="200px" height="300px" /></a>
				    <div class="caption centered"><h4>HALLAZGOS</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
				<div class="thumbnail">
                    <a class="zoom green" href="Perdidas.aspx"><img class="img-responsive img-circle" src="assets/img/mascotas/registrarperdida.jpg" alt="" width="200px" height="300px" /></a>
				    <div class="caption centered"><h4>PERDIDAS</h4> </div>
                </div>
			</div>
		</div><!-- /row -->
		<div class="row">	
			<div class="col-lg-4 col-md-4">
				<div class="thumbnail">
                    <a class="zoom green" href="Adopciones.aspx"><img class="img-responsive img-circle" src="assets/img/mascotas/registraradopcion.jpg" alt="" width="200px" height="300px" /></a>
				    <div class="caption centered"><h4>ADOPCIONES</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
				<div class="thumbnail">
                    <a class="zoom green" href="Default.aspx"><img class="img-responsive img-circle" src="assets/img/mascotas/volver.jpg" alt="" width="200px" height="300px" /></a>
				    <div class="caption centered"><h4>VOLVER</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
			<%--	<a class="zoom green" href="Default.aspx"><img class="img-responsive" src="assets/img/mascotas/volver.jpg" alt="" width="200px" height="300px" /></a>
				<p class="col-lg-4">VOLVER</p>--%>
			</div>
		</div><!-- /row -->
	</div><!-- /container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
