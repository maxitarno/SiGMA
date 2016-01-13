<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CABMTipoDeDocumento.aspx.cs"
    Inherits="SiGMA.CABMTipoDeDocumento" MasterPageFile="PaginaAdmin.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/tipodocMini.png" />
                    <h1>Tipos de Documentos</h1>
                    <p>Aquí podrá registrar, consultar y/o modificar tipos de documentos</p>
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
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-danger" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
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
                            <label for="contact-name">Nombre Tipo de Documento</label>
                            <asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingresar un nombre detipo de documento"
                                        ControlToValidate="txtNombre" ValidationGroup="1" Display="Dynamic" Font-Underline="False"
                                        BorderColor="Red" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CausesValidation="False" Width="180px" OnClick="BtnBuscarClick"/>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnNuevoDoc" runat="server" Text="Nuevo" OnClick="BtnNuevoDocClick" Width="180px" CausesValidation="False" />
                        </div>
                        <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                            <div class="form-group">
                                <label for="contact-name">Elegir un tipo de documento</label>
                                <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="true" OnSelectedIndexChanged="BtnSeleccionarClick" Width="100%"></asp:ListBox>
                            </div>
                        </asp:Panel>
                        <div class="form-group">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrarClick" Width="180px" ValidationGroup="1" Visible="false"/>
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="180px" OnClick="BtnModificarClick" Visible="false" ValidationGroup="1" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="180px" OnClick="BtnCancelarClick" CausesValidation="false" Visible="false"/>
                        </div>                             
	                </div>
                </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                            <img id="imgRazas" src="base/img/portfolio/tipodoc.jpg" />
	                    </div>
	                </div>
	            </div>
	        </div>
        </div>
    </div>
</asp:Content>
