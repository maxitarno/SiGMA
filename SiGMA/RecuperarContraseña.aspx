<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaLogin.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="SiGMA.RecuperarContraseña" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="head">
</asp:Content>
   
<asp:Content ID="Content2"  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
                    <i class="fa fa-lock"></i>
                    <h1>Restablecer Contraseña /</h1>
                    <p>Por razones de seguridad, no ponga la contraseña en conocimiento de otras personas</p>
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
	                    Enviaremos a su correo registrado una clave autogenerada para que ingrese a SIGMA, sugerimos 
                        modificarla por una nueva clave que sea de su agrado y pueda recordarla.
	                </p>
                    <div class="form-group">
	                    	<label for="contact-name">Email</label>
	                        <asp:TextBox  ID="txtEmail" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese su email registrado"
                            ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                            ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Display="Dynamic"></asp:RegularExpressionValidator>
	                </div>
	                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                                        onclick="btnEnviar_Click" Width="180px" />
                </div>
	            <div class="col-sm-5 contact-address wow fadeInUp">
	                <img src="base/img/portfolio/recuperarContra.png" />
	            </div>
	        </div>
	    </div>
    </div>
</asp:Content>
