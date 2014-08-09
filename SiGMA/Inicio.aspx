<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SiGMA.WebForm1" MasterPageFile="~/Site.Master" %>
<asp:Content ContentPlaceHolderID=HeadContent runat="server">
<!-- encabezado -->
<!-- fin encabezado -->
</asp:Content>
<asp:Content ContentPlaceHolderID=MainContent runat="server">

    <div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h1 class="panel-title">
                    Bienvenidos a SIGMA
                </h1>
            </div>
            <div class="panel-body">
                <h2 style="text-align:center">
                    Nuestro sistema integral de gestión de mascotas.
                </h2>
                <h2>
                    Este sistema surgio de la necesidad de brindar soporte, a la gestión de los procesos 
                    de atención de mascotas por parte de las protectoras de animales, desde que se 
                    encuentren, atienden y alojen en hogares provisorios, ayudando a la difusión ante 
                    perdidas, a la adopción de mascotas y a contar con un seguimiento de las mismas.                     
                </h2>
                <input value="Iniciar Sesion" type="button" class="btn-primary" onclick="IniciarSesion()"/>
                <input value="Crear Usuario" type="button" class="btn-primary" onclick="RegistrarUsuario()"/>
                <script type="text/javascript" >
                    function IniciarSesion() {
                        location.href = "Login.aspx";
                    }
                    function RegistrarUsuario() {
                        location.href = "RegistrarUsuario.aspx";
                    }
                </script>
            </div>
        </div>
    </div>
</asp:Content>
