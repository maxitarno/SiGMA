<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SiGMA.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Inicar sesion</h3>
        </div>
        <div class="panel-body">
            <div>
                <div class="almedio">
                    <asp:Login ID="login" runat="server" onauthenticate="login_Authenticate">
                        <LoginButtonStyle CssClass="btn-primary" />
                        <TextBoxStyle/>
                    </asp:Login>
                    <br />
                    No tiene un usuario? <input value="Crear Usuario" type="button" class="btn-primary" onclick="RegistrarUsuario()"/>
                </div>
            </div>
            <script type="text/javascript" >
                function RegistrarUsuario() {
                    location.href = "RegistrarUsuario.aspx";
                }
                </script>
        </div>
   </div>
</asp:Content>
