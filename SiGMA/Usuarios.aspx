<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SiGMA.Usuarios" %>
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
                <h3>USUARIOS</h3>
                <h4 >Elija que desea hacer en el menú inferior</h4>
        </div>
        </div>
		<div class="row">	
			<div class="col-lg-4 col-md-4">
				<div class="thumbnail">
                    <a class="zoom green" href="RegistrarUsuario.aspx"><img class="img-responsive img-circle" src="assets/img/usuarios/registrarusuario.jpg" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>REGISTRAR</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
                <div class="thumbnail">
                    <a class="zoom green" href="ConsultarUsuario.aspx"><img class="img-responsive img-circle" src="assets/img/usuarios/consultarusuario.jpg" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>CONSULTAR</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
				<div class="thumbnail">
                    <a class="zoom green" href="ConsultarUsuario.aspx?m=1"><img class="img-responsive img-circle" src="assets/img/usuarios/modificarusuario.jpg" alt="" width="200px" height="300px"/></a>
				    <div class="caption centered"><h4>MODIFICAR</h4> </div>
                </div>
			</div>
		</div><!-- /row -->
		<div class="row ">	
			<div class="col-lg-4 col-md-4">
				<%--<a class="zoom green" href="work01.html"><img class="img-responsive" src="assets/img/menu/voluntarios.png" alt="" width="300px" height="400px"/></a>
				<p>VOLUNTARIOS</p>--%>
			</div>
			<div class="col-lg-4 col-md-4">
				<div class="thumbnail">
                     <a class="zoom green" href="Default.aspx"><img class="img-responsive img-circle" src="assets/img/usuarios/volver.jpg" alt="" width="200px" height="300px" /></a>
				    <div class="caption centered"><h4>VOLVER</h4> </div>
                </div>
			</div>
			<div class="col-lg-4 col-md-4">
				<%--<a class="zoom green" href="work01.html"><img class="img-responsive" src="assets/img/menu/administracion.png" alt="" width="300px" height="400px"/></a>
				<p>ADMINISTRACIÓN</p>--%>
			</div>
		</div><!-- /row -->
	</div><!-- /container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
