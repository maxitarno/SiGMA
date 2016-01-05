<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true"
    CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SiGMA._Default" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2"  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <i class="fa fa-user-plus"></i>
                    <h1>Registrar Usuario /</h1>
                    <p>Cuide a su mascota</p>
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
                        <asp:Label ID="lblCorrecto" runat="server" Text="Usuario Registrado Exitosamente. Verifique email enviado a su correo para autenticación"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="services-half-width-container">
        	<div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <div class="form-group">
	                    	    <label for="contact-name">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingrese su nombre" ForeColor="Red"
                                ControlToValidate="txtNombre" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvLetrasNombre" runat="server" 
                                ErrorMessage="Ingrese solo letras" ForeColor="Red" ControlToValidate="txtNombre" 
                                onservervalidate="cvLetrasNombre_ServerValidate"  Display="Dynamic"></asp:CustomValidator>
	                        </div>
                            <div class="form-group">
	                    	    <label for="contact-name">Apellido</label>
	                            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Ingrese su apellido" ForeColor="Red"
                                ControlToValidate="txtApellido" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvLetrasApellido" runat="server" 
                                ErrorMessage="Ingrese solo letras" ForeColor="Red" ControlToValidate="txtApellido" 
                                onservervalidate="cvLetrasApellido_ServerValidate" Display="Dynamic"></asp:CustomValidator>
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Tipo de documento</label>
                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Nro de documento</label>
                                <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ErrorMessage="Ingrese su número de documento" ForeColor="Red"
                                ControlToValidate="txtDocumento" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cuvDocumento" runat="server" ErrorMessage="Ingrese solo números"
                                ControlToValidate="txtDocumento" ForeColor="Red" Display="Dynamic" 
                                onservervalidate="cuvDocumento_ServerValidate"></asp:CustomValidator>
                            </div>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <div class="form-group">
                                <label for="contact-name">Email</label>
                                <asp:TextBox  ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese su email"
                                    ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                                    ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Usuario</label>
                                <asp:TextBox  ID="txtUsuario" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Cree su usuario para SIGMA" ForeColor="Red"
                                ControlToValidate="txtUsuario" Display="Dynamic"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Contraseña</label>
                                <asp:TextBox ID="txtContra" runat="server" MaxLength="16" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvContra" runat="server" ErrorMessage="Cree su contraseña" ForeColor="Red"
                                ControlToValidate="txtContra" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvContraseña" runat="server" 
                                ErrorMessage="Minimo 8 caracteres" ControlToValidate="txtContra" ForeColor="Red" 
                                onservervalidate="cvContraseña_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Repetir contraseña</label>
                                <asp:TextBox  ID="txtRepetirContra" runat="server" MaxLength="16" 
                                TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRepetirContra" runat="server" ErrorMessage="Ingrese su contraseña"
                                ForeColor="Red" ControlToValidate="txtRepetirContra" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="covPassword" runat="server" ErrorMessage="Las contraseñas deben coincidir"
                                ControlToCompare="txtContra" ControlToValidate="txtRepetirContra" ForeColor="Red"
                                Display="Dynamic"></asp:CompareValidator>
                            </div>
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click"/>
                        </div>
	                </div>
	            </div>
	        </div>
        </div>
        <asp:CustomValidator ID="cvTipoDoc" runat="server" ErrorMessage="Seleccione un tipo de documento" ForeColor="Red"
                                    ControlToValidate="ddlTipoDocumento" onservervalidate="cvTipoDoc_ServerValidate" ></asp:CustomValidator>
</asp:Content>
