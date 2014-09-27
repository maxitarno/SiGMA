<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="PermisosInsuficientes.aspx.cs" Inherits="SiGMA.PermisosInsuficientes" %>
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
                    Permisos Insuficientes
                </h3>
            </div>
            <div class="panel-body">
                <h4 style="text-align:center">
                    ¡ No posee autorización para acceder a la pagina solicitada ! 
                </h4>
            </div>
        </div>
    </div>

		<div class="row mt centered">	
			<div class="col-lg-4">
				
			</div>
			<div class="col-lg-4">
				<a class="zoom green" href="Default.aspx"><img class="img-responsive" src="assets/img/usuarios/volver.jpg" alt="" width="300px" height="400px" /></a>
				<p>PRINCIPAL</p>
			</div>
			<div class="col-lg-4">
				
			</div>
		</div><!-- /row -->
		<div class="row mt centered">	
			<div class="col-lg-4">
				
			</div>
			<div class="col-lg-4">
				
			</div>
			<div class="col-lg-4">
				
			</div>
		</div><!-- /row -->
	</div><!-- /container -->
</asp:Content>