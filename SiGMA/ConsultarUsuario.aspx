<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs"
    Inherits="SiGMA.ConsultarUsuario" MasterPageFile="~/PaginaAdmin.Master" Culture="Auto"
    UICulture="Auto" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function showDate() {
            $find("Date").show();
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/usuariosMini.png" />
                    <h1><asp:Label ID="lblTitulo" runat="server"></asp:Label></h1>
                    <p>Mantenga los datos actualizados</p>
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
                            <asp:RadioButton ID="rbPorPersona" runat="server" GroupName="1"
                                AutoPostBack="True" OnCheckedChanged="RdbPorPersona" Text="Por persona" />                            
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbPorUsuario" runat="server" GroupName="1"
                                AutoPostBack="True" OnCheckedChanged="RdbPorUsuario" Checked="True" Text="Por usuario" />
                        </div>
                        <div class="form-group">
                            <asp:Panel runat="server" id="pnlUser" Visible="false">
                                 <label for="contact-name">Usuario</label><br /><asp:TextBox ID="txtUsuario" runat="server" ></asp:TextBox>
                            </asp:Panel>
                            <asp:Panel runat="server" id="pnlPersona" Visible="false">
                                <label for="contact-name">Tipo de documento</label><asp:DropDownList ID="ddlTipoDeDocumentoPersona" runat="server" Width="100%"/>
                                 <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Seleccione un tipo de documento" ForeColor="Red"
                                                ControlToValidate="ddlTipoDeDocumentoPersona" onservervalidate="cvTipoDocumentoPersona_ServerValidate" ></asp:CustomValidator><br />
                                <label for="contact-name">Nro. de documento</label><asp:TextBox ID="txtNºDeDocumento" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNºDeDocumento" runat="server" ErrorMessage="Ingrese un nro. de documento"
                                                    ControlToValidate="txtNºDeDocumento"  ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Ingrese un nro. de documento válido"
                                ControlToValidate="txtNºDeDocumento" ForeColor="Red" Display="Dynamic" 
                                onservervalidate="cvNroDocumentoPersona_ServerValidate"></asp:CustomValidator>
                            </asp:Panel>
                            <asp:Panel ID="pnlBuscar" runat="server" Visible="true">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscarClick" CausesValidation="False" Width="180px" />
                            </asp:Panel>
                        </div>
	                </div>
                </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                        <br /><br />
                            <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                                <label for="contact-name">Elegir un usuario</label>
                                <br />
                                <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstResultados_SelectedIndexChanged" Width="100%"></asp:ListBox>
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
                    <asp:Panel ID="pnlMostrarUsuario" runat="server" Visible="false" >
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
                                <div class="form-group">
	                    	        <label for="contact-name">Nombre</label>
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingrese su nombre" ForeColor="Red"
                                    ControlToValidate="txtNombre" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvLetrasNombre" runat="server" 
                                    ErrorMessage="Ingrese solo letras" ForeColor="Red" ControlToValidate="txtNombre" 
                                    onservervalidate="cvNombre_ServerValidate"  Display="Dynamic"></asp:CustomValidator><br />
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Usuario</label>
                                    <asp:TextBox ID="txtUsuarioMostrar" runat="server" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Telefono Fijo</label>
                                        <asp:TextBox ID="txtTelefonoFijo" runat="server" MaxLength="12"></asp:TextBox>
                                        <asp:CustomValidator ID="cvTelefonoFijo" runat="server" ErrorMessage="Ingrese solo números" 
                                        ControlToValidate="txtTelefonoFijo" ForeColor="Red" Display="Dynamic" onservervalidate="cvTelefonoFijo_ServerValidate" 
                                        ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Localidad</label>
                                    <asp:DropDownList ID="ddlLocalidades" Enabled="false" runat="server" OnSelectedIndexChanged="DdlBarrio_SelectedIndexChanged"
                                                            AutoPostBack="True" Width="100%"> </asp:DropDownList>
                                    <asp:CustomValidator ID="cvLocalidades" runat="server" ErrorMessage="Seleccione una localidad" 
                                        ControlToValidate="ddlLocalidades" ForeColor="Red" 
                                        onservervalidate="cvLocalidades_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
                                </div>
                                 <div class="form-group">
                                    <label for="contact-name">Calle</label>
                                    <asp:DropDownList ID="ddlCalle" Enabled="true" runat="server" Width="100%"></asp:DropDownList>
                                     <asp:CustomValidator ID="cvCalles" runat="server" ErrorMessage="Seleccione una calle" 
                                        ForeColor="Red" ControlToValidate="ddlCalle" 
                                        onservervalidate="cvCalles_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración calle</label>
                                     <asp:TextBox ID="txtNº" runat="server" MaxLength="10"></asp:TextBox>
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
	                    </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlMostrarUsuario1" runat="server" Visible="false" >
	                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                                <div class="form-group">
	                    	        <label for="contact-name">Apellido</label>
	                                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Ingrese su apellido" ForeColor="Red"
                                    ControlToValidate="txtApellido" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvLetrasApellido" runat="server" 
                                    ErrorMessage="Ingrese solo letras" ForeColor="Red" ControlToValidate="txtApellido" 
                                    onservervalidate="cvApellido_ServerValidate" Display="Dynamic"></asp:CustomValidator>
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
                                    <label for="contact-name">Telefono Celular</label>
                                     <asp:TextBox ID="txtTelefonoCelular" runat="server" MaxLength="12"></asp:TextBox>
                                     <asp:CustomValidator ID="cvTelefonoCelular" runat="server" ErrorMessage="Ingrese solo números" 
                                        ControlToValidate="txtTelefonoCelular" ForeColor="Red" Display="Dynamic" onservervalidate="cvTelefonoCelular_ServerValidate1" 
                                         ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Barrio</label>
                                    <asp:DropDownList ID="ddlBarrios" Enabled="true" runat="server" AutoPostBack="False" Width="100%"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvBarrios" runat="server" ErrorMessage="Selecciones un barrio" 
                                        ControlToValidate="ddlBarrios" ForeColor="Red" 
                                        onservervalidate="cvBarrios_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Tipo de documento</label>
                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="100%"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvTipoDoc" runat="server" ErrorMessage="Seleccione un tipo de documento" ForeColor="Red"
                                    ControlToValidate="ddlTipoDocumento" onservervalidate="cvTipoDocumento_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Nro de documento</label>
                                    <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ErrorMessage="Ingrese su número de documento" ForeColor="Red"
                                    ControlToValidate="txtDocumento" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cuvDocumento" runat="server" ErrorMessage="Ingrese un nro. de documento válido"
                                    ControlToValidate="txtDocumento" ForeColor="Red" Display="Dynamic" 
                                    onservervalidate="cvNroDocumento_ServerValidate"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                <br />
                                     <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificarClick"
                                        ValidationGroup="1" Width="180px" />
                                        &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminarClick"
                                        ValidationGroup="2" Width="180px" OnClientClick="if (!confirm('¿Está seguro que desea eliminar el usuario?')){ return false; } else { return true; }"/>
                                </div>
                            </div>
	                    </div>
                    </asp:Panel>
	            </div>
	        </div>
        </div>
</asp:Content>
