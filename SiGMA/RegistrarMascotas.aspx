<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="RegistrarMascota.aspx.cs" Inherits="SiGMA.RegistrarMascota" Culture="Auto" UICulture="Auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showimagepreview(input, image) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgprvw').attr('src', e.target.result);
                    document.getElementById(image).style.display = 'block';
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
        function showDate() {
            $find("Date").show();
        }
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/registrarmascotasMini.png" />
                    <h1>Registrar Mascota /</h1>
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
                        <asp:Label ID="lblCorrecto" runat="server" Text="Mascota registrada exitosamente"></asp:Label>
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
                        <asp:Panel ID="pnlDatos" runat="server">
                            <div class="form-group">
                                <label for="contact-name">Nombre mascota</label>
                                <asp:TextBox ID="txtNombreMascota" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombreMascota" runat="server" ErrorMessage="Ingrese el nombre de la mascota" 
                                ControlToValidate="txtNombreMascota" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Especie</label>
                                <asp:DropDownList ID="ddlEspecie" AutoPostBack="true" runat="server" 
                                        onselectedindexchanged="ddlEspecie_SelectedIndexChanged" width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="cvEspecie" runat="server" ErrorMessage="Seleccione una especie" ControlToValidate="ddlEspecie" ForeColor="Red" 
                                    onservervalidate="cvEspecie_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Raza</label>
                                <asp:DropDownList ID="ddlRaza" runat="server" width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="cvRaza" runat="server" ErrorMessage="Seleccione una raza" ControlToValidate="ddlRaza" ForeColor="Red" 
                                    onservervalidate="cvRaza_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Sexo</label>
                                <asp:DropDownList ID="ddlSexo" runat="server" width="100%"></asp:DropDownList>
                                        <asp:CustomValidator ID="cvDdlSexo" runat="server" ErrorMessage="Seleccione un sexo" ControlToValidate="ddlSexo" ForeColor="Red" 
                                            onservervalidate="cvDdlSexo_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Edad</label>
                                <asp:DropDownList ID="ddlEdad" runat="server" width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="cvEdad" runat="server" ErrorMessage="Seleccione una edad" ControlToValidate="ddlEdad" ForeColor="Red" 
                                    onservervalidate="cvEdad_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Color</label>
                                <asp:DropDownList ID="ddlColor" runat="server" width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="cvColor" runat="server" ErrorMessage="Seleccione un color" ControlToValidate="ddlColor" ForeColor="Red" 
                                        onservervalidate="cvColor_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Temperamento</label>
                                <asp:DropDownList ID="ddlCaracter" runat="server" width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="cvCaracter" runat="server" 
                                    ErrorMessage="Seleccione un temperamento" ControlToValidate="ddlCaracter" 
                                    ForeColor="Red" onservervalidate="cvCaracter_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">¿Tiene trato con otros animales?</label>
                                    <asp:DropDownList ID="ddlTratoAnimales" runat="server" width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="cvTratoAnim" runat="server" 
                                    ErrorMessage="Seleccione una opción" ControlToValidate="ddlTratoAnimales" 
                                    ForeColor="Red" onservervalidate="cvTratoAnim_ServerValidate" ></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">¿Tiene trato con niños?</label>
                                    <asp:DropDownList ID="ddlTratoNinios" runat="server" width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="dvTratoNinios" runat="server" 
                                    ErrorMessage="Seleccione una opción" ControlToValidate="ddlTratoNinios" 
                                    ForeColor="Red" onservervalidate="dvTratoNinios_ServerValidate"></asp:CustomValidator>
                            </div>
                        </asp:Panel>
                    </div>
	            </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <asp:Panel ID="pnlDatos1" runat="server">
                            <div class="form-group">
                                <label for="contact-name">Fecha de nacimiento</label>
                                <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date" 
                                runat="server" TargetControlID="txtFecha" PopupPosition="BottomLeft" Animated="true" >
                                </ajaxToolkit:CalendarExtender>
                                <asp:RangeValidator ID="rnvFecha" runat="server" ErrorMessage="La fecha es inválida" 
                                ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                MinimumValue="01/01/1980" Type="Date" Font-Size="Small"></asp:RangeValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Observaciones</label>
                                <asp:TextBox ID="txtObservaciones" runat="server" Style="resize: none" TextMode="MultiLine" Enabled="True" onkeyDown="checkTextAreaMaxLength(this,event,'500');"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Alimentación</label>
                                <asp:TextBox ID="txtAlimentacionEspecial" runat="server" Style="resize: none" TextMode="MultiLine" Enabled="True" onkeyDown="checkTextAreaMaxLength(this,event,'200');"></asp:TextBox>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlFoto" runat="server">
                            <div class="form-group">
                                <label for="contact-name">Foto mascota</label>
                                <input type="file" runat="server"  id="fuImagen"  onchange="showimagepreview(this,'imgprvw')" /><br />
                                <img id="imgprvw" width="380px" height="325px" hidden /> 
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlBtnRegistrar" runat="server">
                            <div class="form-group">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Mascota" 
                                        onclick="btnRegistrar_Click" Width="180px"/>
                            </div>
                        </asp:Panel>
                        </div>
	            </div>
            </div>
	    </div>
    </div>
</asp:Content>
