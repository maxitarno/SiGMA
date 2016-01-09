<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarAdopcion.aspx.cs"
    Inherits="SiGMA.RegistrarAdopcion" MasterPageFile="PaginaAdmin.Master" Culture="Auto" UICulture="Auto"%>

<asp:Content ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/registraradopcionMini.png" />
                    <h1>Registrar Adopción /</h1>
                    <p>Cuide a su mascota</p>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-4 col-md-offset-4">
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-danger" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlBuscarDuenio" runat="server" Visible="false">
        <div class="services-half-width-container">
                <div class="container">
	                <div class="row">
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
	                            <div class="form-group">
                                     <asp:RadioButton ID="rbPorNombre" runat="server" GroupName="1" ValidationGroup="1"
                                    AutoPostBack="True" OnCheckedChanged="rbPorName" Checked="True" Text=" Por Nombre" />&nbsp&nbsp
                                    <asp:RadioButton ID="rbPorDNI" runat="server" OnCheckedChanged="rbPorTipo" AutoPostBack="True"
                                    ValidationGroup="1" GroupName="1" Checked="False" Text=" Por DNI" />
                                </div>
                                <label for="contact-name" style="text-align:center;">Filtrar Dueños</label><br />
                                <asp:Panel ID="pnlNombre" runat="server" Visible="false">
                                    <div class="form-group">
                                        <label for="contact-name">Nombre</label>
                                        <asp:TextBox ID="txtNombreDuenio" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlDocumento" runat="server" Visible="false">
                                    <div class="form-group">
                                        <label for="contact-name">Tipo Documento</label>
                                        <asp:DropDownList ID="ddlTipo" runat="server" ViewStateMode="Enabled" Width="100%">
                                            </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="contact-name">Numero Documento</label>
                                         <asp:TextBox ID="txtDNI" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                                <div class="form-group">
                                    <asp:Button ID="btnBuscarDuenio" runat="server" Text="Buscar" OnClick="btnBuscarDuenioClick" Width="180px"/>
                                </div>
	                        </div>
                        </div>
	                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                                <div class="form-group">
                                <br /><br />
                                   <asp:Panel ID="pnlResultadosDuenio" runat="server" Visible="false">
                                        <label for="contact-name">Elegir un dueño</label>
                                        <br /><br />
                                       <asp:ListBox ID="lstResultadosDuenios" runat="server" ViewStateMode="Enabled" 
                                                Width="100%" AutoPostBack="True" 
                                                onselectedindexchanged="lstResultadosDuenios_SelectedIndexChanged">
                                            </asp:ListBox>
                                    </asp:Panel>
	                            </div>
	                        </div>
	                    </div>
	                </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlBuscarMascota" runat="server" Visible="false">
            <div class="services-half-width-container">
                <div class="container">
	                <div class="row">
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
                                <label for="contact-name" style="text-align:center;">Filtrar mascotas para adoptar</label><br />
                                <div class="form-group">
                                    <label for="contact-name">Nombre Mascotas</label>
                                    <asp:TextBox ID="txtNombreMascota" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Especie</label>
                                        <asp:DropDownList ID="ddlEspecies" runat="server" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"
                                        AutoPostBack="True" ViewStateMode="Enabled" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                    <asp:DropDownList ID="ddlRaza" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Edad</label>
                                    <asp:DropDownList ID="ddlEdad" runat="server" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"
                                        ViewStateMode="Enabled" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                    <div class="form-group">
                                    <label for="contact-name">Sexo</label>
                                    <asp:DropDownList ID="ddlSexo" runat="server" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"
                                        ViewStateMode="Enabled" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                    <div class="form-group">
                                    <asp:Button ID="btnBuscarMascota" runat="server" Text="Buscar" OnClick="btnBuscarMascotaClick" Width="180px"/>
                                </div>
	                        </div>
                        </div>
	                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                                <div class="form-group">
                                <br />
                                   <asp:Panel Visible="false" runat="server" ID="pnlResultadosMascotas">
                                        <label for="contact-name">Elegir una mascota</label>
                                        <asp:ListBox ID="lstResultadosMascotas" runat="server" ViewStateMode="Enabled" Width="100%" 
                                        AutoPostBack="true" OnSelectedIndexChanged="lstResultadosMascotas_SelectedIndexChanged">
                                        </asp:ListBox>
                                    </asp:Panel>
	                            </div>
                                <div>
	                                <img src="base/img/portfolio/adopciones.png" style="width:470px;height:278px"/>
	                            </div>
	                        </div>
	                    </div>
	                </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlDuenio" runat="server" Visible="false">
            <div class="services-half-width-container">
                <div class="container">
	                <div class="row">
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
	                            <div class="form-group">
                                     <label for="contact-name" style="text-align:center;">Datos del Dueño</label><br />
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Nombre</label>
                                    <asp:TextBox ID="txtNombreD" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Tipo Documento</label>
                                    <asp:TextBox ID="txtTipoDeDocumento" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numero Documento</label>
                                    <asp:TextBox ID="txtNº" runat="server" ReadOnly="True" ViewStateMode="Enabled" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
	                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                            <br /><br />
                                <div class="form-group">
                                    <label for="contact-name">Barrio</label>
                                    <asp:TextBox ID="txtBarrio" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Calle</label>
                                    <asp:TextBox ID="txtCalle" runat="server" ReadOnly="True" ViewStateMode="Enabled" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración Calle</label>
                                    <asp:TextBox ID="txtNro" runat="server" ReadOnly="True" ViewStateMode="Enabled" Enabled="False"></asp:TextBox>
	                            </div>
	                        </div>
	                    </div>
	                </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlMascota" runat="server" Visible="false">
            <div class="services-half-width-container">
                <div class="container">
	                <div class="row">
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
	                            <div class="form-group">
                                     <label for="contact-name" style="text-align:center;">Datos de la Mascota</label><br />
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Nombre</label>
                                    <asp:TextBox ID="txtNombreM" runat="server" ReadOnly="false" ViewStateMode="Enabled"
                                Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Especie</label>
                                    <asp:TextBox ID="txtEspecie" runat="server" ViewStateMode="Enabled" ReadOnly="true"
                                 Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                    <asp:TextBox ID="txtRaza" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
	                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                                <br /><br />
                                <div class="form-group">
                                    <label for="contact-name">Sexo</label>
                                    <asp:TextBox ID="txtSexo" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Edad</label>
                                    <asp:TextBox ID="txtEdad" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                    Enabled="False"></asp:TextBox>
	                            </div>
                                <asp:Panel ID="pnlRegistrar" runat="server" Visible="false">
                                <div class="form-group">
                                    <asp:Button ID="btnRegistrar" runat="server" Text="Generar contrato" OnClick="btnRegistrarClick" ValidationGroup="1" Width="180px"/>
                                </div>
                                </asp:Panel>
	                        </div>
	                    </div>
	                </div>
                </div>
            </div>
        </asp:Panel>
</asp:Content>
