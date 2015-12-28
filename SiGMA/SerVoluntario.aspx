<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="SerVoluntario.aspx.cs" Inherits="SiGMA.SerVoluntario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/voluntariosMini.png" />
                    <h1>Voluntariado /</h1>
                    <p>Ser voluntario, implica compromiso y responsabilidad</p>
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
    <div class="call-to-action-container">
        <div class="container">
	        <div class="row">
	            <div class="col-sm-12 call-to-action-text wow fadeInUpBig">
	                <p>
	                    Puedes ser voluntario aportando tu casa como hogar provisorio para mascotas halladas, temporalmente 
                        sin dueño, o puedes serlo incorporandote a las patrullas de busqueda de mascotas perdidas.<br />
                        Solicitaremos que llenes el formulario de solicitud de voluntariado con tus datos de contacto
	                </p>
	            </div>
	        </div>
            <div class="contact-form">
                <div class="form-group">
                    <label for="contact-name">¿Que tipo de voluntario desea ser?</label><br />
                    <asp:DropDownList class="dropdown" ID="ddlTipoVoluntario" runat="server" AutoPostBack="true" AppendDataBoundItems="true" 
                    onselectedindexchanged="ddlTipoVoluntario_SelectedIndexChanged" Width="10%" > 
                    <asp:listitem value ="0"> - Seleccione - </asp:listitem>
                    <asp:listitem value ="1" Text="Hogar"></asp:listitem>
                    <asp:listitem value ="2" Text="Busqueda"></asp:listitem>
                    <asp:listitem value ="3" Text="Ambos"></asp:listitem>
                    </asp:DropDownList><br />
                    <asp:CustomValidator ID="cvTipoVoluntario" runat="server" 
                        ErrorMessage="Seleccione un tipo de voluntario" ForeColor="Red"
                    ControlToValidate="ddlTipoVoluntario" 
                        onservervalidate="cvTipoVoluntario_ServerValidate" ></asp:CustomValidator>
                </div>    
            </div>
        </div>
    </div>
    <div class="services-half-width-container">
        	<div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <asp:Panel ID="pnlHogar" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Tipo de hogar</label>
                                    <asp:DropDownList ID="ddlTipoHogar" runat="server" Width="100%" AppendDataBoundItems="True">
                                        <asp:listitem value ="1"> Sin Patio </asp:listitem>
                                        <asp:listitem value ="2"> Con Patio Chico </asp:listitem>
                                        <asp:listitem value ="3"> Con Patio Grande </asp:listitem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Barrio hogar</label>
                                    <asp:DropDownList ID="ddlBarrio" runat="server" Width="100%" 
                                        AppendDataBoundItems="True" AutoPostBack="true"
                                        onselectedindexchanged="ddlBarrio_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvBarrioHogar" runat="server" 
                                        ErrorMessage="Seleccione un barrio" ForeColor="Red"
                                    ControlToValidate="ddlBarrio" onservervalidate="cvBarrioHogar_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Calle</label>
                                    <asp:DropDownList ID="ddlCalle" Enabled="true" Width="100%" runat="server">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvCalle" runat="server" 
                                        ErrorMessage="Seleccione una calle" ForeColor="Red"
                                    ControlToValidate="ddlCalle" onservervalidate="cvCalle_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración calle/dpto</label>
                                    <asp:TextBox ID="txtNro" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNroCalle" runat="server" ErrorMessage="Ingrese su numeración de calle/dpto" ForeColor="Red"
                                    ControlToValidate="txtNro" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                                <div class="form-group">
                                <label for="contact-name">Acepto hasta</label>
                                    <asp:DropDownList ID="ddlNumeroMascotas" runat="server" Width="100%" AppendDataBoundItems="True">
                                        <asp:listitem value ="1"> 1 Mascota Provisoria </asp:listitem>
                                        <asp:listitem value ="2"> 2 Mascotas Provisorias</asp:listitem>
                                        <asp:listitem value ="3"> 3 Mascotas Provisorias</asp:listitem>
                                        <asp:listitem value ="4"> 4 Mascotas Provisorias</asp:listitem>
                                        </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                <label for="contact-name">Tipo de mascota</label>
                                <asp:DropDownList ID="ddlTipoMascota" runat="server" Width="100%" AppendDataBoundItems="True">
                                        <asp:listitem value ="1" Text="Solo Perros">  </asp:listitem>
                                        <asp:listitem value ="2" Text="Solo Gatos">  </asp:listitem>
                                        <asp:listitem value ="3" Text="Perros y Gatos">  </asp:listitem>
                                        </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                <label for="contact-name">¿Tiene niños?</label>
                                <asp:DropDownList ID="ddlTieneNinios" runat="server" Width="100%">
                                        <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción --"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvNiños" runat="server" 
                                        ErrorMessage="Indique si tiene o no niños en el hogar" ControlToValidate="ddlTieneNinios" 
                                        ForeColor="Red" onservervalidate="cvNiños_ServerValidate"></asp:CustomValidator>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlImagenBusqueda" runat="server" Visible="false">
                                <img src="base/img/portfolio/busqueda.png" />
                            </asp:Panel>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDatoPersona" runat="server" Visible="false">
                                <div class="form-group">
	                    	        <label for="contact-name">Nombre</label>
                                    <asp:TextBox ID="txtNombre" runat="server" ReadOnly="true"></asp:TextBox>
	                            </div>
                                <div class="form-group">
	                    	        <label for="contact-name">Email</label>
	                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
	                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Ingrese su email" 
                                        ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                                        ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        Display="Dynamic"></asp:RegularExpressionValidator>  
	                            </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlBusqueda" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Barrio de busquedas</label>
                                    <asp:DropDownList ID="ddlBarrioBusqueda" runat="server" Width="100%" 
                                        AppendDataBoundItems="True" AutoPostBack="true"
                                        onselectedindexchanged="ddlBarrioBusqueda_SelectedIndexChanged">
                                            </asp:DropDownList>
                                    <asp:CustomValidator ID="cvBarrioBusqueda" runat="server" 
                                        ErrorMessage="Seleccione un barrio" ForeColor="Red"
                                        ControlToValidate="ddlBarrioBusqueda" 
                                        onservervalidate="cvBarrioBusqueda_ServerValidate"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Disponibilidad horaria</label>
                                    <asp:DropDownList ID="ddlDisponibilidadHoraria" runat="server" Width="100%" AppendDataBoundItems="True">
                                            <asp:listitem value ="1" Text="Por la mañana"> </asp:listitem>
                                            <asp:listitem value ="2" Text="Por la tarde"> </asp:listitem>
                                            <asp:listitem value ="3" Text="Por la noche"> </asp:listitem>
                                            </asp:DropDownList>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlImagenHogar" runat="server" Visible="false">
                                <img src="base/img/portfolio/hogar.png" />
                            </asp:Panel>
                            <br />
                            <asp:Button ID="btnEnviar" runat="server" 
                                        Text="Enviar" onclick="btnEnviar_Click" Visible="false" Width="180px"/>
                        </div>
	                </div>
	            </div>
	        </div>
        </div>
</asp:Content>

