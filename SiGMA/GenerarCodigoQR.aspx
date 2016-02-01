<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="GenerarCodigoQR.aspx.cs" Inherits="SiGMA.GenerarCodigoQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
                    <i class="fa fa-key"></i>
                    <h1>Código QR /</h1>
                    <p>Seleccione los datos que quiere incluir en el código QR</p>
                </div>
            </div>
        </div>
    </div>
    <div class="services-half-width-container">
        	<div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form" style="text-align:right">
	                        <div class="form-group">
                                <asp:CheckBox ID="chkNombreMascota" runat="server" Text=" Nombre de la mascota" TextAlign="Left"
                                    AutoPostBack="true" oncheckedchanged="chkNombreMascota_CheckedChanged" /><br />
                                <asp:CheckBox ID="chkColor" runat="server" Text=" Color" TextAlign="Left"
                                    AutoPostBack="True" oncheckedchanged="chkColor_CheckedChanged" /><br />
                                <asp:CheckBox ID="chkRaza" runat="server" Text=" Raza" AutoPostBack="True" TextAlign="Left"
                                    oncheckedchanged="chkRaza_CheckedChanged" /><br />
                                <asp:CheckBox ID="chkSexo" runat="server" Text=" Sexo" AutoPostBack="True" TextAlign="Left"
                                    oncheckedchanged="chkSexo_CheckedChanged" /><br />
                                <asp:CheckBox ID="chkNiños" runat="server" Text=" Trato con niños" AutoPostBack="True" TextAlign="Left"
                                    oncheckedchanged="chkTratoNiños_CheckedChanged" />
                            </div>
                        </div>
                    </div>
                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
	                    <div class="form-group">
                        <asp:CheckBox ID="chkAnimales" runat="server" Text=" Trato con animales" AutoPostBack="True" 
                            oncheckedchanged="chkTratoAnimales_CheckedChanged" /><br />
                        <asp:CheckBox ID="chkNombreDueño" runat="server" Text=" Nombre del dueño" AutoPostBack="True" 
                            oncheckedchanged="chkNombreDueño_CheckedChanged" /><br />
                        <asp:CheckBox ID="chkDireccion" runat="server" Text=" Direccion" AutoPostBack="True" 
                            oncheckedchanged="chkDireccion_CheckedChanged" /><br />
                        <asp:CheckBox ID="chkEmail" runat="server" Text=" Email" AutoPostBack="True" 
                            oncheckedchanged="chkEmail_CheckedChanged" /><br />
                        <asp:CheckBox ID="chkTelefonoCel" runat="server" Text=" Teléfono" AutoPostBack="True" 
                            oncheckedchanged="chkTelefono_CheckedChanged" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div class="container">
            <div class="contact-form">
                <div class="form-group">
                    <asp:Image ID="imgQR" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnDescargar" runat="server" Text="Descargar" 
                        onclick="btnDescargar_Click" Enabled="false" Width="180px"/>
	            </div>
            </div>
        </div>
</asp:Content>
