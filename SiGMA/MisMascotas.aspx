<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" enableSessionState="true" CodeBehind="MisMascotas.aspx.cs" Inherits="SiGMA.MisMascotas" Culture="Auto" UICulture="Auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
    <script type="text/javascript">
        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgprvw').attr('src', e.target.result);
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
	                <img src="assets/img/menu/mascotasMini.png" />
                    <h1>Mis Mascotas /</h1>
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
    <div class="container">
        <div class="contact-form">
            <div class="form-group">
                <label for="contact-name">Registrar una nueva mascota</label>
                <br />
                <asp:Button ID="btnRegistrarMascota" runat="server" Text="Registrar una Nueva Mascota" 
                onclick="btnRegistrarMascota_Click" />
            </div>
            <div class="form-group">
                <label for="contact-name">Eligir una de sus mascostas registada</label>
                <br />
                <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" onselectedindexchanged="lstResultados_SelectedIndexChanged" Width="20%"></asp:ListBox>
	        </div>
        </div>
    </div>
    <div class="services-half-width-container">
        	<div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDatos1" runat="server" visible="false">
                                <div class="form-group" style="text-align:center;">
                                    <img id="imgprvw" style="border: 1px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                                </div>
                                 <div class="form-group" style="margin-left:100px; text-align:justify;">
                                    <label for="contact-name">Actualizar imagen</label>
                                     <input type="file" runat="server" id="fuImagenMascota" onchange="showimagepreview(this)" />
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Nombre de la mascota</label>
	                    	        <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="Validator" ID="rfvNombreMascota" runat="server" ErrorMessage="Debe ingresar un nombre" ForeColor="Red"
                                            ControlToValidate="txtMascota" ValidationGroup="1"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvMascota" runat="server" 
                                    ErrorMessage="Ingrese solo letras" ControlToValidate="txtMascota" 
                                        ForeColor="Red" onservervalidate="cvMascota_ServerValidate"></asp:CustomValidator>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Especie</label>
	                                <asp:DropDownList ID="ddlEspecie" runat="server" 
                                        OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true" Width="100%">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvEspecie" runat="server" 
                                    ErrorMessage="Seleccione una especie" ControlToValidate="ddlEspecie" 
                                        ForeColor="Red" onservervalidate="cvEspecie_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                    <asp:DropDownList ID="ddlRaza" runat="server" Width="100%" AppendDataBoundItems="false">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvRaza" runat="server" 
                                    ErrorMessage="Seleccione una raza" ControlToValidate="ddlRaza" 
                                        ForeColor="Red" onservervalidate="cvRaza_ServerValidate"  ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Categoria</label>
                                    <asp:TextBox ID="txtCategoria" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Sexo</label>
                                    <asp:DropDownList ID="ddlSexo" runat="server" Width="100%">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvSexo" runat="server" 
                                    ErrorMessage="Seleccione un sexo" ControlToValidate="ddlSexo" 
                                        ForeColor="Red" onservervalidate="cvSexo_ServerValidate1" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Edad</label>
                                    <asp:DropDownList ID="ddlEdad" runat="server" Width="100%" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvEdad" runat="server" 
                                    ErrorMessage="Seleccione una edad" ControlToValidate="ddlEdad" 
                                        ForeColor="Red" onservervalidate="cvEdad_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                        <label for="contact-name">Estado</label>
                                        <asp:DropDownList ID="ddlEstado" runat="server" Width="100%"
                                            AppendDataBoundItems="true" Enabled="false">
                                        </asp:DropDownList>
                                </div>
                            </asp:Panel>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDatos" runat="server">
                            <div class="form-group">
                                    <label for="contact-name">Trato con animales</label>
                                    <asp:DropDownList ID="ddlTratoAnimales" runat="server" Width="100%">
                                        <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvTratoAnimales" runat="server" 
                                    ErrorMessage="Seleccione una opción" ControlToValidate="ddlTratoAnimales" 
                                        ForeColor="Red" onservervalidate="cvTratoAnimales_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                        <label for="contact-name">Trato con niños</label>
                                        <asp:DropDownList ID="ddlTratoNinios" runat="server" Width="100%">
                                                        <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción --"></asp:ListItem>
                                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvTratoNiños" runat="server" 
                                    ErrorMessage="Seleccione una opción" ControlToValidate="ddlTratoNinios" 
                                        ForeColor="Red" onservervalidate="cvTratoNiños_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Cuidado especial</label>
                                    <asp:TextBox ID="txtCuidadoEspecial" runat="server" Style="resize: none" TextMode="MultiLine"
                                             Enabled="true" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Color</label>
                                    <asp:DropDownList ID="ddlColor" runat="server" Width="100%"
                                            AppendDataBoundItems="True">
                                        </asp:DropDownList>
                                    <asp:CustomValidator ID="cvColor" runat="server" 
                                    ErrorMessage="Seleccione un color" ControlToValidate="ddlColor" 
                                        ForeColor="Red" onservervalidate="cvColor_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Temperamento</label>
                                    <asp:DropDownList ID="ddlCaracter" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    <asp:CustomValidator ID="cvTemperamento" runat="server" 
                                    ErrorMessage="Seleccione un temperamento" ControlToValidate="ddlCaracter" 
                                        ForeColor="Red" onservervalidate="cvTemperamento_ServerValidate" ></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Alimentación</label>
                                    <asp:TextBox ID="txtAlimentacionEspecial" runat="server"
                                            Style="resize: none" TextMode="MultiLine" Enabled="True" onkeyDown="checkTextAreaMaxLength(this,event,'200');"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Observaciones</label>
                                     <asp:TextBox ID="txtObservaciones" runat="server"
                                            Style="resize: none" TextMode="MultiLine" Enabled="True" onkeyDown="checkTextAreaMaxLength(this,event,'500');"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Fecha de nacimiento</label>
                                    <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date"
                                    runat="server" TargetControlID="txtFecha" PopupPosition="BottomLeft" Animated="true" >
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:RangeValidator ID="rnvFecha" runat="server" ErrorMessage="La fecha es inválida" 
                                    ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                    MinimumValue="01/01/1980" Type="Date" Font-Size="Small" 
                                    ></asp:RangeValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">¿Quiere ocultar esta mascota?</label><br />
                                    <asp:CheckBox ID="chNoMostrar" Visible = "true" runat = "server" Text=" No mostrar mascota"/>
	                            </div>
                            </asp:Panel>
                        </div>
	                </div>
	            </div>
	        </div>
        </div>
        
        <div class="container">
            <asp:Panel ID="pnlbotones" runat="server" Visible="false" >
                <div class="contact-form">
                    <div style="text-align:center;">
                        <table style="margin: 0 auto;">
                            <tr>
                                <td><asp:Button ID="btnModificar" runat="server" Text="Guardar Datos" OnClick="BtnModificarClick" Width="180px"/> 
                                    &nbsp;&nbsp;&nbsp; </td>
                                <td><asp:Button ID="btnGenerarQR" runat="server" Text="Generar Código QR" OnClick="btnGenerarQR_Click" Width="180px"/> 
                                    &nbsp;&nbsp;&nbsp; </td>
                                <td><asp:Button ID="btnAdopcion" runat="server" Text="Poner en Adopcion" Width="180px" OnClick="btnAdopcion_Click" CausesValidation="false" 
                                OnClientClick="if (!confirm('¿Está seguro que desea poner la mascota en adopcion?')){ return false; } else { return true; }" /> 
                                    &nbsp;&nbsp;&nbsp; </td>
                                <td><asp:Button ID="btnPerdida" runat="server" Text="Registrar Pérdida" CausesValidation="false" Width="180px" onclick="btnPerdida_Click"/></td>
                            </tr>
                        </table>
                    </div>   
                </div> 
            </asp:Panel>   
        </div>
</asp:Content>

