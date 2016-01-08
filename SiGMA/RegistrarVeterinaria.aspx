<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarVeterinaria.aspx.cs" Inherits="SiGMA.RegistrarVeterinaria" MasterPageFile="PaginaAdmin.Master" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/veterinariasMini.png" />
                    <h1>Registrar Veterinaria /</h1>
                    <p>Mantenga sus datos actualizados</p>
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
                            <label for="contact-name">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" Text="Debe ingresar un nombre" ControlToValidate="txtNombre" Display="Dynamic" BorderColor="Red" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="contact-name">Email</label>
                            <asp:TextBox ID="txtContacto" runat="server"></asp:TextBox>  
                            <asp:RegularExpressionValidator ID="revContacto" runat="server" 
                                ErrorMessage="Formato de email incorrecto" ControlToValidate="txtContacto" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvContacto" runat="server" ErrorMessage="Debe ingresar un email" ControlToValidate="txtContacto" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="contact-name">Localidad</label>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" Width="100%" OnSelectedIndexChanged="SeleccionarLocalidad" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                             <asp:CustomValidator ID="cvLocalidad" runat="server" 
                                ErrorMessage="Seleccione una localidad" ForeColor="Red"
                            ControlToValidate="ddlLocalidad" 
                                onservervalidate="cvLocalidad_ServerValidate" ></asp:CustomValidator>  
                        </div>
                       <div class="form-group">
                            <label for="contact-name">Calle</label>
                            <asp:DropDownList ID="ddlCalle" runat="server" Width="100%"  AppendDataBoundItems="True"></asp:DropDownList>
                            <asp:CustomValidator ID="cvCalle" runat="server" 
                                ErrorMessage="Seleccione una calle" ForeColor="Red"
                            ControlToValidate="ddlCalle" onservervalidate="cvCalle_ServerValidate" ></asp:CustomValidator>  
                        </div>
                    </div>
	            </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                            <label for="contact-name" style="margin-bottom:15px">Tipo de servicios que brinda</label><br />
                            <asp:CheckBox ID="chkMedicinas" runat="server" Text="Atención Médica" Checked="true"/>
                            &nbsp;
                            <asp:CheckBox ID="chkPeluqueria" runat="server" Text="Peluqueria" />
                            &nbsp;
                            <asp:CheckBox ID="chkPetShop" runat="server" Text="Pet Shop"/>
                            &nbsp;
                            <asp:CheckBox ID="chkCastraciones" runat="server" Text="Castraciones"/>
                        </div>
                        <div class="form-group">
                            <label for="contact-name">Teléfono</label>
                            <asp:TextBox ID="txtTE" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="Debe ingresar un teléfono" ControlToValidate="txtTE" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvTelefono" runat="server" 
                                ErrorMessage="Ingrese solo números" ControlToValidate="txtTE" 
                                ForeColor="Red" onservervalidate="cvTelefono_ServerValidate"></asp:CustomValidator>
                        </div>
                        <div class="form-group">
                           <label for="contact-name">Barrio</label>
                           <asp:DropDownList ID="ddlBarrio" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                            <asp:CustomValidator ID="cvBarrio" runat="server" 
                                ErrorMessage="Seleccione un barrio" ForeColor="Red"
                            ControlToValidate="ddlBarrio" onservervalidate="cvBarrio_ServerValidate" ></asp:CustomValidator> 
                        </div>
                        <div class="form-group">
                            <label for="contact-name">Numeración de calle/dpto</label>
                            <asp:TextBox ID="txtNº" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNroCalle"  ForeColor="Red" runat="server" ErrorMessage="Ingrese la numeración de calle/dpto" ControlToValidate="txtNº"></asp:RequiredFieldValidator>
                        </div>
                        <asp:Panel ID="pnlRegistrar" runat="server" Visible="true">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" 
                            onclick="btnRegistrar_Click" Width="180px"/>
                        </asp:Panel>
	                </div>
	            </div>
	        </div>
        </div>
    </div>
</asp:Content>
