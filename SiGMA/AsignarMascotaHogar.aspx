<%@ Page Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="AsignarMascotaHogar.aspx.cs" Inherits="SiGMA.AsignarMascotaHogar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/registrarhallazgoMini.png" />
                    <h1>Asignar Mascota a Hogar /</h1>
                    <p>Dar una mascota a un hogar para su cuidado temporal</p>                    
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
                            <asp:Panel ID="pnlDatos1" runat="server" visible="true">
                                <div class="form-group" style="text-align:center;">
                                    <img id="imgprvw" style="border: 2px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                                </div>                                
                                <div style="text-align:center;">
                                    <label for="contact-name">Nombre: </label>	                    	        
                                    <asp:Label ID="lblNombre"
                                        runat="server" Text="lblNombre"></asp:Label>                                    
	                            </div>                                
                                <div style="text-align:center;">
                                    <label for="contact-name">Raza: </label>
                                    <asp:Label ID="lblRaza"
                                        runat="server" Text="lblRaza"></asp:Label>                                    
                                </div>                                
                                <div style="text-align:center;">
                                    <label for="contact-name">Sexo: </label>
                                    <asp:Label ID="lblSexo"
                                        runat="server" Text="lblSexo"></asp:Label>                                   
                                </div>
                                <div style="text-align:center;">
                                    <label for="contact-name">Edad: </label>
                                    <asp:Label ID="lblEdad"
                                        runat="server" Text="lblEdad"></asp:Label>                                     
                                </div>
                                <div style="text-align:center;">
                                    <label for="contact-name">Trato con animales: </label>
                                    <asp:Label ID="lblTratoAnimales"
                                        runat="server" Text="lblTratoAnimales"></asp:Label> 
                                </div>
                                <div style="text-align:center;">
                                        <label for="contact-name">Trato con niños: </label>
                                        <asp:Label ID="lblTratoNiños"
                                        runat="server" Text="lblTratoNiños"></asp:Label>                      
                                </div>
                                <div style="text-align:center;">
                                    <label for="contact-name">Temperamento: </label>
                                    <asp:Label ID="lblTemperamento"
                                        runat="server" Text="lblTemperamento"></asp:Label>
                                </div>                                      
                            </asp:Panel>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDatos" runat="server">
                                                         
                                <div class="panel panel-default" style="margin-top:10px">
                                    <div class="panel-heading">
                                        Hogares
                                    </div>
                                    <div class="panel-body" style="padding-bottom:2px;">
                                        <table>
                                            <tr>
                                                <td style="padding-right:10px;">
                                                    <label for="contact-name">¿Con niños?</label>
                                                    <asp:DropDownList ID="ddlNiños" runat="server" Width="100%">                                                        
                                                        <asp:ListItem>Si</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:DropDownList>    
                                                </td>
                                                <td style="padding-right:10px;">
                                                    <label for="contact-name">Especie</label>                                                    
                                                    <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" AppendDataBoundItems="True">
                                                        <asp:listitem value ="1" Text="Solo Perros">  </asp:listitem>
                                                        <asp:listitem value ="2" Text="Solo Gatos">  </asp:listitem>
                                                        <asp:listitem value ="3" Text="Perros y Gatos">  </asp:listitem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <label for="contact-name">Tipo de hogar</label>
                                                    <asp:DropDownList ID="ddlTipoHogar" runat="server" Width="100%" AppendDataBoundItems="True">
                                                        <asp:listitem value ="1"> Sin Patio </asp:listitem>
                                                        <asp:listitem value ="2"> Con Patio Chico </asp:listitem>
                                                        <asp:listitem value ="3"> Con Patio Grande </asp:listitem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>                                                
                                                <td class="btn pull-right">
                                                    <asp:Button ID="btnBuscarHogares" runat="server" Text="Buscar" 
                                                        onclick="btnBuscarHogares_Click" CausesValidation="False" Width="180px"/>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grvHogares" runat="server" AutoGenerateColumns="False" 
                                                        Visible="False" onrowcommand="grvHogares_RowCommand" Width="161%">
                                                        <RowStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>  
                                                        <Columns>
                                                            <asp:BoundField DataField="voluntario.persona.nombre" HeaderText="Nombre" 
                                                                Visible="False" />
                                                            <asp:BoundField DataField="voluntario.persona.apellido" HeaderText="Apellido" 
                                                                Visible="False" />
                                                            <asp:TemplateField HeaderText="Voluntario">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVoluntario" runat="server" 
                                                                    Text='<%#Eval("voluntario.persona.nombre")+ " " + Eval("voluntario.persona.apellido")%>' >
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="disponibilidad" HeaderText="Disponibilidad" >
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="cantMascotas" HeaderText="Cantidad Maxima" >
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:ButtonField ButtonType="Button" Text="+" />
                                                            <asp:BoundField DataField="voluntario.idVoluntario">
                                                            <HeaderStyle CssClass="hidden" />
                                                            <ItemStyle CssClass="hidden" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="idHogar">
                                                            <HeaderStyle CssClass="hidden" />
                                                            <ItemStyle CssClass="hidden" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lblNoHogares" runat="server" visible="false" Text = "No hay hogares disponibles que cumplan con los criterios"></asp:Label>
                                        <asp:Panel ID="pnlDatosVoluntario" runat="server" visible="false">
                                        <table>
                                            <tr>
                                            <td>
                                                <asp:Label ID="lblNombreVoluntario" runat="server" Text="Nombre: "></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                <asp:Label ID="lblBarrio" runat="server" Text="Barrio: "></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                <asp:Label ID="lblTelefonoFijo" runat="server" Text="Telefono fijo: "></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                <asp:Label ID="lblTelefonoCel" runat="server" Text="Celular: "></asp:Label>
                                            </td>
                                            </tr>                                            
                                        </table>
                                        </asp:Panel>                                         
                                    </div>
                                </div>
                                <asp:Panel ID="pnlAsignar" runat="server" visible="false"> 
                                <div>
                                            <label for="contact-name">Fecha de ingreso</label>
                                            <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date"
                                            runat="server" TargetControlID="txtFecha" PopupPosition="TopLeft" Animated="true" >
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ForeColor="Red" 
                                            ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"   ControlToValidate="txtFecha" 
                                            Text="Ingrese una fecha"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" 
                                                onclick="btnAsignar_Click" Width="180px"/> 
                                     </asp:Panel>                             
                            </asp:Panel>
                        </div>
	                </div>
	            </div>
	        </div>
        </div>
    <asp:Panel runat="server" id="pnlImagenAsignar" Visible="false">
        <div class="container">
            <div class="contact-form">
                <div class="form-group">
                    <img src="base/img/portfolio/asignarMascota.png" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Label
        ID="lblIdMascota" Visible="false" runat="server" Text=""></asp:Label>  
</asp:Content>
