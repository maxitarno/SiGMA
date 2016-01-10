<%@ Page Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="RegistrarCampaña.aspx.cs" Inherits="SiGMA.RegistrarCampaña" Culture="Auto" UICulture="Auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/difusiondueñoMini.png" />
                    <h1>Registrar Campaña /</h1>
                    <p>La difusión es una herramienta clave para llegar a la gente</p>
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
	                    	    <label for="contact-name">Lugar</label>
                                <asp:TextBox ID="txtLugar" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLugar" runat="server" ErrorMessage="Ingrese el lugar"
                                ForeColor="Red" ControlToValidate="txtLugar"></asp:RequiredFieldValidator>
	                        </div>
                            <div class="form-group">
	                    	    <label for="contact-name">Fecha</label>
	                           <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date" 
                                runat="server" TargetControlID="txtFecha" PopupPosition="BottomLeft" Animated="true" >
                                </ajaxToolkit:CalendarExtender>
                                <asp:RangeValidator ID="rnvFechaCampaña" runat="server" ErrorMessage="La fecha es inválida" 
                                ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                MinimumValue="01/01/1980" Type="Date" Font-Size="Small"></asp:RangeValidator>
	                        </div>
                            <div class="form-group" style="text-align:center; display:inline">
                                <img id="preview" style="display:inline; text-align:center;" width="300px" height="200px" hidden/>
                            </div>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <div class="form-group">
                                <label for="contact-name">Tipo de campaña</label>
                                <asp:DropDownList ID="ddlTipoCampaña" runat="server" AppendDataBoundItems="true" Width="100%" ></asp:DropDownList>
                                <asp:CustomValidator ID="cvTipoCampaña" runat="server" ErrorMessage="Seleccione un tipo" ForeColor="Red" ControlToValidate="ddlTipoCampaña" 
                                onservervalidate="cvTipoCampaña_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Hora</label>
                                <asp:TextBox ID="txtHora" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revHora" runat="server" 
                                    ErrorMessage="HH:mm" ControlToValidate="txtHora" ForeColor="Red"
                                    ValidationExpression="^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ControlToValidate="txtHora"
                                    ID="rfvHora" runat="server" ForeColor="Red" ErrorMessage="Ingrese horario"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Imagen de campaña</label>
                                <input style="width:100%" type="file" runat="server" id="fuImagen" onchange="showimagepreview(this,'preview')" />
                            </div>
                            <asp:Button ID="btnRegistrarCampaña" runat="server" Width="180px" Text="Registrar" onclick="btnRegistrarCampaña_Click"/>
                        </div>
	                </div>
	            </div>
	        </div>
        </div>             
    <script type="text/javascript">
        function showimagepreview(input, image) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#preview').attr('src', e.target.result);
                    document.getElementById(image).style.display = 'block';
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
     </script>      
</asp:Content>
