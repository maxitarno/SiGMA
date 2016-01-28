<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CABMRazas.aspx.cs" Inherits="SiGMA.CABMRazas"
    MasterPageFile="PaginaAdmin.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/mascotasMini.png" />
                    <h1>Razas</h1>
                    <p>Aquí podrá registrar, consultar y/o modificar razas</p>
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
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible=false>
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
                            <label for="contact-name">Seleccione un especie</label>
                            <asp:DropDownList ID="ddlEspecies" runat="server" Width="100%" 
                                AutoPostBack="True" onselectedindexchanged="ddlEspecies_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="contact-name">Nombre Raza</label>
                            <asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CausesValidation="False" Width="180px" OnClick="BtnBuscarClick" Visible="false"/>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnNuevaRaza" runat="server" Text="Nueva Raza" CausesValidation="False" Width="180px" OnClick="BtnNuevaRazaClick" Visible="false"/>
                        </div>                               
	                </div>
                </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                        <br />
                            <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                                <label for="contact-name">Elegir una raza</label>
                                <br />
                                <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="true" OnSelectedIndexChanged="BtnSeleccionarClick" Width="100%"></asp:ListBox>
                            </asp:Panel>
	                    </div>
	                </div>
	            </div>
	        </div>
        </div>
    </div>
    <div class="services-half-width-container">
        <div class="container">
	        <div class="row">
                <asp:Panel ID="pnlDatos" runat="server" Visible="false">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
	                        <div class="form-group">
                                <label for="contact-name">Categoria</label>
                                <asp:DropDownList ID="ddlCategoria" runat="server" Width="100%"/>
                                    <asp:CustomValidator ID="cvCategoria" runat="server" 
                                    ErrorMessage="Seleccione una categoria" ControlToValidate="ddlCategoria" 
                                        ForeColor="Red" onservervalidate="cvCategoria_ServerValidate"  ValidationGroup="1"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Tipo Mascota</label>
                                <asp:DropDownList ID="ddlCuidadoEspecial" runat="server" Width="100%">
                                    <asp:ListItem Value="0" Text="-- Seleccione un tipo de mascota --"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Perro Pequeño"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Perro Mediano"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Perro Grande"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Gato"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:CustomValidator ID="cvTipoMascota" runat="server" 
                                    ErrorMessage="Seleccione una tipo de mascota" ControlToValidate="ddlCuidadoEspecial" 
                                        ForeColor="Red" onservervalidate="cvTipoMascota_ServerValidate"  ValidationGroup="1"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Peso Raza</label>
                                <asp:TextBox ID="txtPeso" runat="server"/>
                                <asp:RequiredFieldValidator  ForeColor="Red" ID="rfvPeso" runat="server"  ValidationGroup="1" ErrorMessage="Ingrese un peso estandar en Kg de la raza en edad adulta" ControlToValidate="txtPeso"></asp:RequiredFieldValidator>
                            </div>      
                            <div class="form-group">
                                <asp:Panel ID="pnlRegistrar" runat="server" Visible="false">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" ValidationGroup="1" OnClick="BtnRegistrarClick" Width="180px"  />
                                </asp:Panel>
                                <asp:Panel ID="pnlCambio" runat="server" Visible="false">
                                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" ValidationGroup="1"
                                        OnClick="BtnModificarClick" Width="180px"/>
                                </asp:Panel>
                            </div>                
	                    </div>
                    </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <div class="form-group">
                                <img id="imgRazas" src="base/img/portfolio/razas.jpg" />
	                        </div>
	                    </div>
	                </div>
                </asp:Panel>  
	        </div>
        </div>
    </div>
</asp:Content>
