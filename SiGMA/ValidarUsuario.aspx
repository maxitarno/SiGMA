<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaLogin.Master" AutoEventWireup="true"
    CodeBehind="ValidarUsuario.aspx.cs" Inherits="SiGMA.ValidarUsuario" %>

<asp:Content  runat="server" ContentPlaceHolderID="head">
</asp:Content>
   
<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
                    <i class="fa fa-lock"></i>
                    <h1>Validar Usuario /</h1>
                    <p>Verifique email enviado a su correo para autenticación </p>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-4 col-md-offset-4">
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="contact-us-container">
        <div class="container">
	        <div class="row">
	            <div class="col-sm-7 contact-form wow fadeInLeft">
	                <p>
	                    Nuestra política de seguridad en registración de usuarios con validación, nos permite
                         garantizar que contamos con datos de contacto verídicos del usuario registrado. 
	                </p>
                    <div class="form-group">
	                    	<label for="contact-name">Usuario</label>
	                        <asp:TextBox  ID="txtUsuario" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese su usuario" ForeColor="Red"
                                ControlToValidate="txtUsuario" Display="Dynamic"></asp:RequiredFieldValidator>
	                </div>
                    <div class="form-group">
	                    	<label for="contact-name">Clave de validación</label>
	                        <asp:TextBox  ID="txtToken" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvToken" runat="server" ErrorMessage="Ingrese su clave de validación" ForeColor="Red"
                                ControlToValidate="txtToken" Display="Dynamic"></asp:RequiredFieldValidator>
	                </div>
	                <asp:Button ID="btnValidar" runat="server" Text="Validar" 
                        onclick="btnValidar_Click"/>
                </div>
	            <div class="col-sm-5 contact-address wow fadeInUp" style="margin-top:25px">
	                <img src="base/img/portfolio/validarUser.png" />
	            </div>
	        </div>
	    </div>
    </div>
</asp:Content>
