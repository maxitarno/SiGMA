<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SiGMA.About" %>
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
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Iniciar sesion</h3>
            </div>
            <div class="panel-body">
                <div>
                    <div class="centered" >
                        <asp:Login ID="login" runat="server" TitleText="" 
                            onauthenticate="login_Authenticate" style="margin-left:auto;margin-right:auto" 
                            FailureText="Usuario y/o Contraseña Incorrecto o No Validado" 
                            PasswordLabelText="Contraseña:" 
                            PasswordRequiredErrorMessage="Contraseña Requerida" RememberMeText="Recordarme" 
                            UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="Usuario Requerido">
                        </asp:Login>
                        <br />
                        No tiene un usuario? <input value="Crear Usuario" type="button" onclick="RegistrarUsuario()"/>
                        <br />
                        Validar usuario creado <input value="Validar Usuario" type="button" onclick="ValidarUsuario()"/>
                    </div>
                </div>
                <script type="text/javascript" >
                    function RegistrarUsuario() {
                        location.href = "RegistrarUsuario.aspx";
                    }
                    </script>
                    <script type="text/javascript" >
                        function ValidarUsuario() {
                            location.href = "ValidarUsuario.aspx";
                        }
                    </script>
            </div>
       </div>
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
