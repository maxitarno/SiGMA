<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="DevolverASigma.aspx.cs" Inherits="SiGMA.DevolverASigma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .tr {
    text-align: center;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
<div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">	 
                <img src="assets/img/menu/registrarhallazgoMini.png" />               
                    <h1>Devolución a SiGMA /</h1>
                    <p>Retirar una mascota de un hogar provisorio</p>                    
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-4 col-md-offset-4">
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible="false">                    
                        <asp:Label ID="lblInfo" runat="server" Text = "No hay solicitudes de devolución."></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
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
            <asp:Panel ID="pnlMascotas" runat="server">
                <div class="form-group" style="text-align:center">
                    <label for="contact-name">Mascotas para devolución</label>
                    <asp:GridView ID="grvMascotas" runat="server"
                        AutoGenerateColumns="False" Width="600px" 
                        HorizontalAlign="Center" Font-Size="Medium"
                        CellPadding="2" CellSpacing="3" onrowcommand="grvMascotas_RowCommand"> 
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>  
                        <Columns>                              
                            <asp:BoundField DataField="mascota.nombreMascota" HeaderText="Nombre"/>
                            <asp:BoundField DataField="hogar.voluntario.persona.nombre" Visible="False" />
                            <asp:BoundField DataField="hogar.voluntario.persona.apellido" Visible="False" />
                            <asp:TemplateField HeaderText="Voluntario">
                                <ItemTemplate>
                                    <asp:Label ID="lblVoluntario" runat="server" 
                                    Text='<%#Eval("hogar.voluntario.persona.nombre")+ " " + Eval("hogar.voluntario.persona.apellido")%>' >
                                    </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:ButtonField ButtonType="Button" Text="+"/>
                            <asp:BoundField DataField="idOcupacion" >
                            <HeaderStyle CssClass="hidden" />
                            <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>   
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
                                <div class="form-group">
                                    <label for="contact-name">Nombre del Voluntario</label>
	                    	        <asp:TextBox ID="txtVoluntario" runat="server" enabled="false"></asp:TextBox>                                    
	                            </div>    
                                <div class="form-group">
                                    <label for="contact-name">Teléfono</label>
	                    	        <asp:TextBox ID="txtTelefono" runat="server" enabled="false"></asp:TextBox>                                    
	                            </div>                                  
                                <div class="form-group">
                                    <label for="contact-name">Nombre de la mascota</label>
	                    	        <asp:TextBox ID="txtNombre" runat="server" enabled="false"></asp:TextBox>                                    
	                            </div>                                               
                            </asp:Panel>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDatos" runat="server" visible="false"> 
                            <div class="form-group">
                                    <label for="contact-name">Especie</label>
	                                <asp:TextBox ID="txtEspecie" runat="server" enabled="false"></asp:TextBox>                                     
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                    <asp:TextBox ID="txtRaza" runat="server" enabled="false"></asp:TextBox>                                     
                                </div>                                
                                <div class="form-group">
                                    <label for="contact-name">Sexo</label>
                                    <asp:TextBox ID="txtSexo" runat="server" enabled="false"></asp:TextBox>                                     
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Edad</label>
                                    <asp:TextBox ID="txtEdad" runat="server" enabled="false"></asp:TextBox>                                     
                                </div>
                                <div>
                                            <label for="contact-name">Fecha de devolución</label>
                                            <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date"
                                            runat="server" TargetControlID="txtFecha" PopupPosition="BottomLeft" Animated="true" >
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ForeColor="Red" 
                                            ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"   ControlToValidate="txtFecha" 
                                            Text="Ingrese una fecha"></asp:RequiredFieldValidator>
                                            </div>
                                <asp:Button ID="btnDevolver" runat="server" Text="Registrar Devolución" 
                                    Width="180px" onclick="btnDevolver_Click"/>      
                            </asp:Panel>
                        </div>
	                </div>
	            </div>
	        </div>
        </div>
    </asp:Panel>                       
        </div>
    </div>
    <asp:Panel runat="server" id="pnlImagenDevolver" Visible="false">
        <div class="container">
            <div class="contact-form">
                <div class="form-group">
                    <img src="base/img/portfolio/devolucion.jpg" />
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
