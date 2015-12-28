<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="Sugerencia.aspx.cs" Inherits="SiGMA.Sugerencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
</script>
<script src="http://maps.google.com/maps/api/js?sensor=true"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
                    <img src="assets/img/menu/sugerenciasMini.png" />
                    <h1>Buzón de Sugerencias /</h1>
                    <p>Sus sugerencias/opiniones nos ayudan a mejorar</p>
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
    <div class="contact-us-container">
        <div class="container">
	        <div class="row">
	            <div class="col-sm-7 contact-form wow fadeInLeft">
	                <p>
	                    Nuestra política de mejora continua, centrada en la experiencia de los usuarios, ha logrado que   
	                    día a día Sigma sea más completo, cubriendo las nuevas necesidades que surgen con el paso del tiempo.  
	                </p>
                    <div class="form-group">
	                    	<label for="contact-name">Nombre</label>
	                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:CustomValidator ID="cvNombre" runat="server" 
                                ErrorMessage="Ingrese solo letras" ControlToValidate="txtNombre" 
                                    ForeColor="Red" onservervalidate="cvNombre_ServerValidate"></asp:CustomValidator>
	                </div>
                    <div class="form-group">
	                    	<label for="contact-name">Email</label>
	                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                            ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Display="Dynamic"></asp:RegularExpressionValidator>
	                </div>
                    <div class="form-group">
	                    	<label for="contact-name">Teléfono</label>
	                        <asp:TextBox ID="txtTelefono" runat="server" MaxLength="20"></asp:TextBox>
                            <asp:CustomValidator ID="cvTelefono" runat="server" 
                                ErrorMessage="Ingrese solo números" ControlToValidate="txtTelefono" 
                                onservervalidate="cvTelefono_ServerValidate" ForeColor="Red"></asp:CustomValidator>
	                </div>
                    <div class="form-group">
	                    	<label for="contact-name">Sugerencia</label>
	                        <asp:TextBox ID="txtSugerencia" runat="server" style="resize: none" TextMode="MultiLine"
                                                    Rows="3" Columns="25" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'500');"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConsulta" runat="server" ErrorMessage="No ha ingresado una sugerencia" 
                                    ForeColor="Red" ControlToValidate="txtSugerencia"></asp:RequiredFieldValidator>
	                </div>
                    <asp:Button ID="btnEnviar" runat="server" 
                                    Text="Enviar" onclick="btnEnviar_Click" Width="180px"/>
                </div>
	            <div class="col-sm-5 contact-address wow fadeInUp">
	                <h3>Estamos aquí</h3>
	                <div class="map"></div>
	                <h3>Dirección</h3>
	                <p>Sargento Cabral 1564 <br> San Vicente, Córdoba, Argentina</p>
	                <p>Teléfono: 0351 456-5158</p>
	            </div>
	        </div>
	    </div>
    </div>
</asp:Content>
