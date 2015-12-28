<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SiGMA.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 wow fadeIn">
                        <i class="fa fa-key"></i>
                        <h1>Ingrese a Sigma /</h1>
                        <p>Cuide a su mascota</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-sm-offset-2 contact-form">
                    <asp:Login ID="login" runat="server" TitleText="" 
                        onauthenticate="login_Authenticate" style="margin-left:auto;margin-right:auto" 
                        FailureText="Usuario y/o Contraseña Incorrecto o No Validado" 
                        PasswordLabelText="Contraseña: " 
                        PasswordRequiredErrorMessage="Contraseña Requerida" RememberMeText="" 
                        UserNameLabelText="Usuario: " 
                        UserNameRequiredErrorMessage="Usuario Requerido" LoginButtonText="Ingresar" 
                        Height="35px" Width="90%" DisplayRememberMe="False">
                    </asp:Login>
                </div>
            </div>
            <div class="contact-form">
                <div style="text-align:center;">
                    <table style="margin: 0 auto;">
                        <tr>
                            <td><label style="width:232px">¿No tiene un usuario?</label></td>
                            <td><label style="width:232px">¿Usuario no validado?</label></td>
                            <td><label style="width:230px">¿Contraseña olvidada?</label></td>
                        </tr>
                        <tr>
                            <td><input value="Crear Usuario" type="button" onclick="RegistrarUsuario()" style="width:220px"/></td>
                            <td><input value="Validar Usuario" type="button" onclick="ValidarUsuario()" style="width:220px"/></td>
                            <td><input value="Restablecer Contraseña" type="button" onclick="RecuperarContra()" style="width:220px"/></td>
                        </tr>
                    </table>
                </div>   
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
    <script type="text/javascript" >
        function RecuperarContra() {
            location.href = "RecuperarContraseña.aspx";
        }
    </script>
</asp:Content>

