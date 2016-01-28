<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarInformes.aspx.cs"
    Inherits="SiGMA.SeleccionarInformes" MasterPageFile="PaginaAdmin.Master" Culture="Auto" UICulture="Auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi" ></script>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
                    <img src="assets/img/menu/listadosMini.png" />
                    <h1>Listados /</h1>
                    <p>La información es de vital importancia para un buen manejo de la organización</p>
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
    <div class="services-half-width-container">
        <div class="container">
	        <div class="row">
	            <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                    <div class="contact-form">
	                    <div class="form-group">
                            <label for="contact-name">Seleccione el tipo de listado que desea generar</label>
                            <asp:DropDownList ID="ddlInforme" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlSelectedChanged"
                                AutoPostBack="True" Width="100%">
                                <asp:ListItem Value="0" Text="SIN ASIGNAR"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Listado de Mascotas"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Listado de Adopciones"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Listado de Hallazgos"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Listado de Perdidas"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:Panel runat="server" Visible="false" ID="pnlFiltros1">
                            <div class="form-group">
                                <label for="contact-name">Especie</label>
                                <asp:DropDownList ID="ddlEspecies" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged"/>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Raza</label>
                                <asp:DropDownList ID="ddlRaza" runat="server" Width="100%"/>
                                                        
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Edad</label>
                                <asp:DropDownList ID="ddlEdad" runat="server" Width="100%"/>
                                                        
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Estado</label>
                                 <asp:DropDownList ID="ddlEstado" runat="server" Width="100%"/>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" Visible="false" ID="pnlFiltros2">
                            <div class="form-group">
                                <label for="contact-name">Fecha desde</label>
                                <asp:TextBox ID="txtFechaAdopcion" runat="server" onclick="showDate();" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date"
                                runat="server" TargetControlID="txtFechaAdopcion" PopupPosition="BottomLeft" Animated="true" >
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ForeColor="Red" ErrorMessage="Ingrese una fecha" SetFocusOnError="True"   ControlToValidate="txtFechaAdopcion" Text="Ingrese una fecha"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rnvAdopcion" runat="server" ErrorMessage="La fecha es inválida" 
                                ForeColor="Red" ControlToValidate="txtFechaAdopcion" SetFocusOnError="True" 
                                MinimumValue="01/01/2015" Type="Date" Font-Size="Small" ></asp:RangeValidator>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" Visible="false" ID="pnlFiltros3">
                            <div class="form-group">
                                <label for="contact-name">Fecha desde</label>
                                 <asp:TextBox ID="txtFechaDelHallazgo" runat="server" />
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender2" BehaviorID="Date"
                                runat="server" TargetControlID="txtFechaDelHallazgo" PopupPosition="BottomLeft" Animated="true" >
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Ingrese una fecha" SetFocusOnError="True"   ControlToValidate="txtFechaDelHallazgo" Text="Ingrese una fecha"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rnvHallazgo" runat="server" ErrorMessage="La fecha es inválida" 
                                ForeColor="Red" ControlToValidate="txtFechaDelHallazgo" SetFocusOnError="True" 
                                MinimumValue="01/01/2015" Type="Date" Font-Size="Small" ></asp:RangeValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Barrio</label>
                                 <asp:DropDownList ID="ddlBarrioHallazgo" runat="server" Width="100%"/>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" Visible="false" ID="pnlFiltros4">
                            <div class="form-group">
                                <label for="contact-name">Fecha desde</label>
                                <asp:TextBox ID="txtFechaDeLaPerdida" runat="server" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" BehaviorID="Date"
                                runat="server" TargetControlID="txtFechaDeLaPerdida" PopupPosition="BottomLeft" Animated="true" >
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Ingrese una fecha" SetFocusOnError="True"   ControlToValidate="txtFechaDeLaPerdida" Text="Ingrese una fecha"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rnvPerdida" runat="server" ErrorMessage="La fecha es inválida" 
                                ForeColor="Red" ControlToValidate="txtFechaDeLaPerdida" SetFocusOnError="True" 
                                MinimumValue="01/01/2015" Type="Date" Font-Size="Small" ></asp:RangeValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Barrio</label>
                                <asp:DropDownList ID="ddlBarrioPerdida" runat="server" Width="100%"/>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlGenerar" runat="server" Visible="false">
                            <asp:Button ID="BtnGenerar" runat="server" Text="Generar" OnClick="BtnGenerarClick" Width="180px"/>
                        </asp:Panel>                 
	                </div>
                </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                        <br /><br />
                            <img id="imgRazas" src="base/img/portfolio/listados.jpg" />
	                    </div>
	                </div>
	            </div>
	        </div>
        </div>
    </div>
    <div class="container">
        <div class="contact-form">
            <label for="contact-name" style="color:#9D426B; font-weight:bold; font-size:medium"><asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></label>
            <asp:Panel ID="pnlListadoDeMascotas" runat="server">
                <div class="form-group">
                    <asp:GridView ID="grvListas" runat="server" AutoGenerateColumns="False" 
                        HorizontalAlign="Center" Font-Size="Medium" 
                    CellPadding="2" CellSpacing="3" Width="100%"> 
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>  
                    <Columns>
                        <asp:BoundField DataField="IdMascota" HeaderText="Nro Mascota"/>
                        <asp:BoundField DataField="nombreMascota" HeaderText="Nombre Mascota" />
                        <asp:BoundField DataField="especie.nombreEspecie" HeaderText="Especie" />
                        <asp:BoundField DataField="raza.nombreRaza" HeaderText="Raza" />
                        <asp:BoundField DataField="estado.nombreEstado" HeaderText="Estado" />
                        <asp:BoundField DataField="edad.nombreEdad" HeaderText="Edad" />
                        <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                        <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nac" 
                            DataFormatString="{0:d}" />
                    </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlAdopciones" runat="server">
                <div class="form-group">
                    <asp:GridView ID="grvAdopciones" runat="server" AutoGenerateColumns="False" 
                        HorizontalAlign="Center" Font-Size="Medium" 
                        CellPadding="2" CellSpacing="3" Width="100%"> 
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>  
                        <Columns>
                            <asp:BoundField DataField="idAdopcion" HeaderText="Nro Adopción" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Adopcion" 
                                DataFormatString="{0:d}" />
                            <asp:BoundField DataField="idVoluntario" HeaderText="Nro Voluntario" />
                            <asp:BoundField DataField="mascota.nombreMascota" HeaderText="Nombre Mascota" />
                            <asp:BoundField DataField="mascota.idMascota" HeaderText="Nro Mascota" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre Dueño" />
 
                        </Columns>
                    </asp:GridView>
	             </div>
            </asp:Panel>
            <asp:Panel ID="pnlPerdidas" runat="server">
                <div class="form-group">
                    <asp:GridView ID="grvPerdidas" runat="server" AutoGenerateColumns="False" 
                        HorizontalAlign="Center" Font-Size="Medium" 
                        CellPadding="2" CellSpacing="3" Width="100%"> 
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>  
                        <Columns>
                            <asp:BoundField DataField="mascota.idMascota" HeaderText="Nro" />
                            <asp:BoundField DataField="mascota.nombreMascota" HeaderText="Mascota" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Nac" 
                                DataFormatString="{0:d}" />
                            <asp:BoundField DataField="usuario.user" HeaderText="Usuario" />
                            <asp:BoundField DataField="barrio.nombre" HeaderText="Barrio" />
                            <asp:BoundField DataField="domicilio.calle.nombre" HeaderText="Calle" />
                            <asp:BoundField DataField="domicilio.numeroCalle" HeaderText="Nro" />
                            <asp:BoundField DataField="comentarios" HeaderText="Comentario" />
                        </Columns>
                    </asp:GridView>
	            </div>
            </asp:Panel>
            <asp:Panel  ID="pnlHallazgos" runat="server" >
                <div class="form-group">
                    <asp:GridView ID="grvHallazgos" runat="server" AutoGenerateColumns="False" 
                        HorizontalAlign="Center" Font-Size="Medium" 
                        CellPadding="2" CellSpacing="3" Width="100%"> 
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>  
                        <Columns>
                            <asp:BoundField DataField="idHallazgo" HeaderText="Nro Hallazgo" />
                            <asp:BoundField DataField="fechaHallazgo" HeaderText="Fecha Hallazgo" 
                                DataFormatString="{0:d}" />
                            <asp:BoundField DataField="domicilio.barrio.nombre" HeaderText="Barrio" />
                            <asp:BoundField DataField="domicilio.calle.nombre" HeaderText="Calle" />
                            <asp:BoundField DataField="domicilio.numeroCalle" HeaderText="Nro" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:BoundField DataField="perdida.idPerdida" HeaderText="Nro Pérdida" Visible="false"/>
                            <asp:BoundField DataField="mascota.IdMascota" HeaderText="Nro Mascota" />
                            <asp:BoundField DataField="mascota.nombreMascota" HeaderText="Nombre Mascota" />
                            <asp:BoundField DataField="usuario.user" HeaderText="Usuario" />
                        </Columns>
                    </asp:GridView>
	            </div>
            </asp:Panel><div class="form-group">
                        <asp:Button ID="btnImprimirExcel" runat="server" Text="Imprimir Excel" Visible="false"
                        onclick="btnImprimirExcel_Click" Width="180px"/>
                </div>
        </div>
    </div>
</asp:Content>
