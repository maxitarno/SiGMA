<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="SiGMA.MiPerfil" Culture="Auto" UICulture="Auto"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function verCamposContra() {
            valor = document.getElementById("<%=chkCambiarContra.ClientID%>").checked;
            if (valor == true) {
                $('#<%=pnlModificarContra.ClientID %>').toggle();
            }
            else {
                $('#<%=pnlModificarContra.ClientID %>').hide();
            }
        }
       
        function showDate() {
            $find("Date").show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/miperfilMini.png" />
                    <h1>Mi Perfil /</h1>
                    <p>Mantenga sus datos actualizados</p>
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
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible="false">
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
    <div class="services-half-width-container">
        	<div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
	                        <div class="form-group">
	                    	    <label for="contact-name">Usuario</label>
	                            <asp:TextBox ID="txtUsuario" runat="server" ReadOnly="true"></asp:TextBox>
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Email</label>
                                <asp:TextBox ID="txtMail" runat="server" CausesValidation="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="Debe ingresar un email" ForeColor="Red"
                                                ControlToValidate="txtMail" Display="Dynamic" ValidationGroup="2" SetFocusOnError="True"
                                                CssClass="Validator"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMail"
                                    ValidationGroup="2" CssClass="Validator" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
	                    	    <label for="contact-name">Tipo de documento</label>
	                            <asp:DropDownList ID="ddlTipoDeDocumento" Width="100%" runat="server"></asp:DropDownList>
                                <asp:CustomValidator ID="cvTipoDoc" runat="server" 
                                    ErrorMessage="Seleccione un tipo de documento" ForeColor="Red"
                                    ControlToValidate="ddlTipoDeDocumento" 
                                    onservervalidate="cvTipoDoc_ServerValidate1"></asp:CustomValidator>
	                        </div>
                            <div class="form-group">
	                    	    <label for="contact-name">Nro de documento</label>
	                            <asp:TextBox ID="txtNºDeDocumento" runat="server" MaxLength="12"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvNºDeDocumento" runat="server" ErrorMessage="Debe ingresar un número de documento" ForeColor="Red"
                                                ControlToValidate="txtNºDeDocumento" CssClass="Validator" Display="Dynamic" ValidationGroup="2"></asp:RequiredFieldValidator>
                                 <asp:CustomValidator ID="cvNroDocumento" runat="server" 
                                    ErrorMessage="Ingrese un nro. de documento válido" ForeColor="Red"
                                    ControlToValidate="txtNºDeDocumento" 
                                    onservervalidate="cvNroDocumento_ServerValidate"></asp:CustomValidator>   
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Apellido</label>
	                            <asp:TextBox ID="txtApellido" runat="server" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Debe ingresar un apellido" ForeColor="Red"
                                                ControlToValidate="txtApellido" CssClass="Validator" ValidationGroup="2" SetFocusOnError="True"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvApellido" runat="server" 
                                    ErrorMessage="Ingrese solo letras" ForeColor="Red"
                                    ControlToValidate="txtApellido" 
                                    onservervalidate="cvApellido_ServerValidate" ></asp:CustomValidator>   
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="Validator" ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un nombre" ForeColor="Red"
                                                Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvNombre" runat="server" 
                                    ErrorMessage="Ingrese solo letras" ForeColor="Red"
                                    ControlToValidate="txtNombre" onservervalidate="cvNombre_ServerValidate" ></asp:CustomValidator>
                            </div>
                            <asp:CheckBox ID="chkCambiarContra" runat="server" Text="Cambiar contraseña" 
                                                 OnClick="verCamposContra()" />
                            <asp:Panel ID="pnlModificarContra" runat="server">
                            <div class="form-group">
                                    <label for="contact-name">Contraseña actual</label>
                                    <asp:TextBox ID="txtContraAnterior" runat="server" MaxLength="16" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese su contraseña actual" ForeColor="Red"
                                    ControlToValidate="txtContraAnterior" Display="Dynamic" ValidationGroup="contra"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                    <label for="contact-name">Nueva contraseña</label>
                                    <asp:TextBox ID="txtContraNueva" runat="server" MaxLength="16" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvContra" runat="server" ErrorMessage="Ingrese su nueva contraseña" ForeColor="Red"
                                    ControlToValidate="txtContraNueva" Display="Dynamic" ValidationGroup="contra"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvContraseña" runat="server" 
                                    ErrorMessage="Minimo 8 caracteres" ControlToValidate="txtContraNueva" ForeColor="Red" 
                                    onservervalidate="cvContraseña_ServerValidate" Display="Dynamic" ValidationGroup="contra"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                    <label for="contact-name">Repetir nueva contraseña</label>
                                    <asp:TextBox  ID="txtRepetirContra" runat="server" MaxLength="16" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRepetirContra" runat="server" ErrorMessage="Repita su nueva contraseña"
                                    ForeColor="Red" ControlToValidate="txtRepetirContra" Display="Dynamic" ValidationGroup="contra"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="covPassword" runat="server" ErrorMessage="Las contraseñas no coinciden"
                                    ControlToCompare="txtContraNueva" ControlToValidate="txtRepetirContra" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="contra"></asp:CompareValidator>
                            </div>
                                <asp:Button ID="btnModificarContraseña" runat="server" 
                                    Text="Modificar Contraseña" ValidationGroup="contra" 
                                    onclick="btnModificarContraseña_Click" Width="180px"/>
                             </asp:Panel>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <div class="form-group">
                                <label for="contact-name">Localidad</label>
                                <asp:DropDownList ID="ddlLocalidades" Enabled="false" runat="server" OnSelectedIndexChanged="DdlBarrio_SelectedIndexChanged"
                                                        AutoPostBack="True" Width="100%"> </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Barrio</label>
                                <asp:DropDownList ID="ddlBarrios" Enabled="true" runat="server" AutoPostBack="False" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Calle</label>
                                <asp:DropDownList ID="ddlCalle" Enabled="true" runat="server" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Numeración calle</label>
                                 <asp:TextBox ID="txtNº" runat="server" MaxLength="10"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Telefono Fijo</label>
                                    <asp:TextBox ID="txtTelefonoFijo" runat="server" MaxLength="12"></asp:TextBox>
                                    <asp:CustomValidator ID="cvTelefonoFijo" runat="server" ErrorMessage="Ingrese solo números" 
                                    ControlToValidate="txtTelefonoFijo" ForeColor="Red" Display="Dynamic" 
                                    onservervalidate="cvTelefonoFijo_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Telefono Celular</label>
                                 <asp:TextBox ID="txtTelefonoCelular" runat="server" MaxLength="12"></asp:TextBox>
                                 <asp:CustomValidator ID="cvTelefonoCelular" runat="server" ErrorMessage="Ingrese solo números" 
                                    ControlToValidate="txtTelefonoCelular" ForeColor="Red" Display="Dynamic" 
                                    onservervalidate="cvTelefonoCelular_ServerValidate" ></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Fecha de nacimiento</label>
                                <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/assets/calendario_dw/calendario.png" />--%>
                                <asp:TextBox ID="txtFecha" onclick="showDate();" runat="server" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date" 
                                    runat="server" TargetControlID="txtFecha" PopupPosition="TopLeft" Animated="true" >
                                </ajaxToolkit:CalendarExtender>
                                <asp:RangeValidator ID="rnvFechaPerdida" runat="server" ErrorMessage="La fecha es inválida" 
                                ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                MinimumValue="01/01/1920" Type="Date" Font-Size="Small" 
                                ></asp:RangeValidator>
                            </div>
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar Datos" OnClick="btnModificarClick" Width="180px"/>
                        </div>
	                </div>
	            </div>
	        </div>
        </div>
</asp:Content>