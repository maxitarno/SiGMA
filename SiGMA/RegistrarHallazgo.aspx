<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true"
    CodeBehind="RegistrarHallazgo.aspx.cs" Inherits="SiGMA.RegistrarHallazgo" Culture="Auto" UICulture="Auto"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/registrarhallazgoMini.png" />
                    <h1>Registrar Hallazgos /</h1>
                    <p>Cuide a su mascota</p>
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
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-danger" Visible=false>
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
                                <asp:RadioButton ID="rbYaPerdida" runat="server" Text="Mascota Hallada" GroupName="TipoHallazgo"
                                    AutoPostBack="True" OnCheckedChanged="rbYaPerdida_CheckedChanged" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rbNuevaMascota" runat="server" Text="Mascota Rescatada" GroupName="TipoHallazgo"
                                    AutoPostBack="True" OnCheckedChanged="rbNuevaMascota_CheckedChanged" />
                            </div>
                            <asp:Panel ID="pnlFiltros" runat="server" Visible="false">
                            <label for="contact-name" style="text-align:center;">Filtrar mascotas perdidas</label><br />
                                <div class="form-group">
                                    <label for="contact-name">Especie</label>
                                    <asp:DropDownList ID="ddlFiltroEspecie" Width="100%" AutoPostBack="true" 
                                        runat="server" onselectedindexchanged="ddlFiltroEspecie_SelectedIndexChanged"/>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                    <asp:DropDownList ID="ddlFiltroRaza" Width="100%" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Sexo</label>
                                    <asp:DropDownList ID="ddlFiltroSexo" Width="100%" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Color</label>
                                    <asp:DropDownList ID="ddlFiltroColor" Width="100%" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnFiltros" runat="server" Text="Buscar" 
                                onclick="btnFiltros_Click" CausesValidation="False" />
                                </div>
                            </asp:Panel>
	                    </div>
                    </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <div class="form-group">
                            <br /><br /><br /><br />
                                <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                                    <label for="contact-name">Elegir una mascota</label>
                                    <br />
                                   <asp:ListBox ID="lstPerdidas" runat="server" AutoPostBack="true" 
                                    OnSelectedIndexChanged="lstPerdidas_SelectedIndexChanged" Visible="False" Width="100%"> 
                                    </asp:ListBox>
                                </asp:Panel>
	                        </div>
	                    </div>
	                </div>
	            </div>
            </div>
        </div>
        <asp:Panel ID="pnlMascotaSeleccionada" runat="server" Visible="false">
            <div class="services-half-width-container">
                <div class="container">
	                <div class="row">
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
	                            <div class="form-group">
                                    <label for="contact-name">Datos de la mascota</label>    
                                    <asp:Panel Visible="true" runat="server" ID="pnlImagen">
                                        <img id="imgprvw" style="border: 2px solid #000000; height: 135px; width: 215px;"
                                            runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg"/>
                                    </asp:Panel>
                                    <asp:Panel Visible="true" runat="server" ID="pnlPreview">
                                        <img id="preview" width="215px" style="margin-left: 27%" height="135px" hidden />
                                    </asp:Panel>
                                </div>
                                <asp:Panel ID="pnlHallazgoPerdidaMascota" runat="server" Visible="true">
                                    <div class="form-group">
                                        <label for="contact-name">Nombre de la mascota</label>  
                                        <asp:TextBox ID="txtNombreMascota" runat="server" Enabled="false" Width="100%"></asp:TextBox>
	                                </div>
                                    <div class="form-group">
                                        <label for="contact-name">Especie</label> 
                                        <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" 
                                        AutoPostBack="true" Enabled="false" AppendDataBoundItems="true" 
                                        onselectedindexchanged="ddlEspecie_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="cvEspecie" runat="server" ErrorMessage="Seleccione una especie" 
                                            ForeColor="Red" onservervalidate="cvEspecie_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
	                                </div>
                                    <div class="form-group">
                                        <label for="contact-name">Raza</label> 
                                        <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="cvRaza" runat="server" ErrorMessage="Seleccione una raza" 
                                            ForeColor="Red" onservervalidate="cvRaza_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
	                                </div>
                                    <div class="form-group">
                                        <label for="contact-name">Edad</label> 
                                        <asp:DropDownList ID="ddlEdad" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="cvEdad" runat="server" ErrorMessage="Seleccione una edad" 
                                        ForeColor="Red" onservervalidate="cvEdad_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
	                                </div>
                                    <div class="form-group">
                                        <label for="contact-name">Sexo</label> 
                                        <asp:DropDownList ID="ddlSexo" Enabled="false" runat="server" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="cvSexo" runat="server" ErrorMessage="Seleccione un sexo" 
                                            ForeColor="Red" onservervalidate="cvSexo_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
	                                </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlColor" Enabled="False" runat="server" Width="100%" AppendDataBoundItems="True">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="cvColor" runat="server" ErrorMessage="Seleccione un color" 
                                            ForeColor="Red" onservervalidate="cvColor_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
	                                </div>
                                    <div class="form-group">
                                        <asp:Panel ID="pnlInputFoto" runat="server">
                                        <input style="width:100%" type="file" runat="server"  id="fuImagen" onchange="showimagepreview(this,'preview')" />                                                               
                                        </asp:Panel>    
                                    </div> 
                                </asp:Panel>      
	                        </div>
                        </div>
	                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                            
                                <div class="form-group">
                                    <label for="contact-name" style="text-align:center;">Datos del hallazgo</label><br /><br />
                                    <label for="contact-name">Localidad</label>
                                     <asp:DropDownList ID="ddlLocalidades" Enabled="true" runat="server" Width="100%" AppendDataBoundItems="False"
                                    OnSelectedIndexChanged="ddlLocalidades_SelectedIndexChanged" AutoPostBack="True"/>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Barrio</label>
                                    <asp:DropDownList ID="ddlBarrios" Enabled="true" runat="server" Width="100%" AppendDataBoundItems="True">
                                    </asp:DropDownList>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Calle</label>
                                     <asp:DropDownList ID="ddlCalles" Enabled="true" runat="server" Width="100%" AppendDataBoundItems="True">
                                </asp:DropDownList>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración de la calle</label>
                                    <asp:TextBox ID="txtNroCalle" runat="server"></asp:TextBox>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Fecha del hallazgo</label>
                                    <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date"
                                    runat="server" TargetControlID="txtFecha" PopupPosition="BottomLeft" Animated="true" >
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"   ControlToValidate="txtFecha" Text="Ingrese una fecha"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rnvFecha" runat="server" ErrorMessage="La fecha es inválida" 
                                    ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                    MinimumValue="01/12/2015" Type="Date" Font-Size="Small" ></asp:RangeValidator>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Comentarios</label>
                                    <asp:TextBox ID="txtComentarios" runat="server" Style="resize: none" TextMode="MultiLine"
                                    Rows="7" Columns="30" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
	                            </div>
                                <div class="form-group" style="text-align:center;">
                                    <asp:CheckBox ID="chkTwitter" runat="server" Text="Publicar en Twitter"/>
	                            </div>
                                <div class="form-group">
                                    <asp:Button ID="btnRegistrarHallazgo" runat="server" Text="Registrar"
                                        OnClick="btnRegistrarHallazgo_Click" />
                                </div>
	                        </div>
	                    </div>
	                </div>
                </div>
            </div>
        </asp:Panel>
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
