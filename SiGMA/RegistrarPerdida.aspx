<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="RegistrarPerdida.aspx.cs" Inherits="SiGMA.RegistrarPerdida" MaintainScrollPositionOnPostback="true" Culture="Auto" UICulture="Auto"%>
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
    function showDate() {
        $find("Date").show();
    }
//    function cargarFecha() {
//        var fec = document.getElementById('<%=txtFecha.ClientID%>').value.toString()
//        $('#fecha').val('');
//     }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/registrarperdidaMini.png" />
                    <h1>Registrar Pérdida /</h1>
                    <p>La precisión de los datos es vital para una busqueda más eficiente</p>
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
                <asp:Panel runat="server" ID="pnlInfo" class="alert alert-dismissable alert-info"
                    Visible="false">
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
        <asp:Panel ID="pnlBuscarPor" runat="server" >
        <div class="services-half-width-container">
        	<div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <asp:Panel ID="pnlVoluntario" runat="server" Visible="false">
                                <div class="form-group">                        
                                        <label for="contact-name">Nombre mascota</label><br />
                                    <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox><br /><br />
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  onclick="btnBuscar_Click" Width="180px"/>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDueño" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Eligir una mascosta</label>
                                    <br />
                                    <asp:ListBox ID="lstMascotas" runat="server" Width="100%" onselectedindexchanged="lstMascotas_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
	                            </div>
                            </asp:Panel>
                        </div>
	                </div>
	            </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlRegistrarPerdida" runat="server" Visible="false">
        <div class="services-half-width-container">
        	    <div class="container">
	                <div class="row">
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
                                <div class="form-group">
                                    <label for="contact-name">Dueño</label>
                                     <asp:TextBox ID="txtDatosDueño" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Localidad</label>
                                     <asp:DropDownList ID="ddlLocalidades" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Barrio</label>
                                     <asp:DropDownList ID="ddlBarrios" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Calle</label>
                                      <asp:DropDownList ID="ddlCalles" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración calle/dpto</label>
                                      <asp:TextBox ID="txtNroCalle" Enabled="false" runat="server" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Mascota perdida</label>
                                     <asp:TextBox ID="txtMascotaPerdida" ReadOnly="True" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Especie</label>
                                     <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" Enabled="false" AppendDataBoundItems="true"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                     <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Sexo</label>
                                      <asp:DropDownList ID="ddlSexo" Enabled="false" runat="server" Width="100%"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Edad</label>
                                      <asp:DropDownList ID="ddlEdad" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Color</label>
                                      <asp:DropDownList ID="ddlColor" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                                <asp:Panel Visible="false" runat="server" ID="pnlImagen">
                                    <div class="form-group" style="text-align:center;">
                                        <img id="imgprvw" style="border: 1px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                                    </div>
                                </asp:Panel>
                                <div class="form-group">
                                    <label for="contact-name">Barrio donde se perdió</label>
                                    <asp:DropDownList ID="ddlBarrioPerdida" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvBarrioPerdida" runat="server" 
                                        ErrorMessage="Seleccione un barrio" ForeColor="Red"
                                    ControlToValidate="ddlBarrioPerdida" 
                                        onservervalidate="cvBarrioPerdida_ServerValidate"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Calle donde se perdió</label>
                                    <asp:DropDownList ID="ddlCallePerdida" runat="server"  Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvCallePerdida" runat="server" 
                                        ErrorMessage="Seleccione una calle" ForeColor="Red"
                                    ControlToValidate="ddlCallePerdida" 
                                        onservervalidate="cvCallePerdida_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración de calle donde se perdió</label>
                                    <asp:TextBox ID="txtNroCallePerdida"  runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNroCallePerdida"  ForeColor="Red" runat="server" ErrorMessage="Ingrese la numeración de la calle" ControlToValidate="txtNroCallePerdida"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvNroCallePerdida" runat="server" 
                                        ErrorMessage="Ingrese solo números" ControlToValidate="txtNroCallePerdida" 
                                        onservervalidate="cvNroCallePerdida_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Fecha de pérdida</label>
                                    <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date"
                                    runat="server" TargetControlID="txtFecha" PopupPosition="BottomLeft" Animated="true" >
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:RangeValidator ID="rnvFecha" runat="server" ErrorMessage="La fecha es inválida" 
                                    ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                    MinimumValue="01/12/2015" Type="Date" Font-Size="Small" ></asp:RangeValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Comentarios</label>
                                    <asp:TextBox ID="txtComentarios" runat="server" style="resize: none" TextMode="MultiLine"
                                     onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnRegistrarPerdida" runat="server" Text="Registrar" onclick="btnRegistrarPerdida_Click" Width="180px"/>  
                            </div>
	                    </div>
	                </div>
	            </div>
            </div>
        </asp:Panel>
</asp:Content>
