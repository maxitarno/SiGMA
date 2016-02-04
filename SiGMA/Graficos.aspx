<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Graficos.aspx.cs" Inherits="SiGMA.Graficos" MasterPageFile="~/PaginaAdmin.Master" Culture="Auto"
    UICulture="Auto" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
                    <img src="assets/img/menu/listadosMini.png" />
                    <h1>Gráficos /</h1>
                    <p>La información es de vital importancia para un buen manejo de la organización</p>
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
                <asp:Panel runat="server" ID="pnlInfo" class="alert alert-dismissable alert-info"
                    Visible="false">
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
                        <p>
	                    Las gráficas estadísticas nos permite “familiarizarnos” con los datos que se han recopilado y resumido.
                        Sin estadísticas una organización carece de capacidad para reconocer que actividades deberían ser más tenidas en cuenta, 
                        porque significan la mayor parte del esfuerzo de la organización.
                        </p>
                        <p>
                         No contar con datos e interpretarlos correctamente es para los administradores como caminar en la oscuridad.
                         Contar con los datos les ilumina, les permite ver lo que está aconteciendo y en consecuencia tomar las medidas más apropiadas
	                    </p>
                        <br />
	                    <div class="form-group">
                            <label for="contact-name">Seleccione el gráfico que desea visualizar</label>
                            <asp:DropDownList ID="ddlListado" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlListado_SelectedIndexChanged" Width="100%" >
                                <asp:ListItem Text="SIN ASIGNAR" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de  voluntarios por tipos en actualidad" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de mascotas por estado en la actualidad" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de mascotas por especie en la actualidad" Value="13"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de mascotas según sexo y edad en la actualidad" Value="6" ></asp:ListItem>
                                <asp:ListItem Text="Porcentaje de adopciones por raza (Historico)" Value="17"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de adopciones por barrio (Historico)" Value="8"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de adopciones según sexo (Historico)" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de adopciones por año (Historico)" Value="11" ></asp:ListItem>
                                <asp:ListItem Text="Porcentaje de adopciones por especie (Historico)" Value="15"></asp:ListItem>
                                <asp:ListItem Text="Porcentaje de hallazgos por raza (Historico)" Value="18"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de hallazgos por barrio (Historico)" value="7" ></asp:ListItem>
                                <asp:ListItem Text="Cantidad de hallazgos según sexo (Historico)" Value="5" ></asp:ListItem>
                                <asp:ListItem Text="Cantidad de hallazgos por año (Historico)" Value="10" ></asp:ListItem>
                                <asp:ListItem Text="Cantidad de hallazgos por especie (Historico)" Value="16"></asp:ListItem>
                                <asp:ListItem Text="Porcentaje de perdidas por raza (Historico)" Value="19"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de perdidas por barrio (Historico)" Value="9" ></asp:ListItem>
                                <asp:ListItem Text="Cantidad de perdidas según sexo (Historico)" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de perdidas por año (Historico)"  Value="12"></asp:ListItem>
                                <asp:ListItem Text="Cantidad perdidas por especie (Historico)" Value="14"></asp:ListItem>
                            </asp:DropDownList>
                        </div>        
	                </div>
                </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                            <img id="imgRazas" src="base/img/portfolio/graficos.jpg" />
	                    </div>
	                </div>
	            </div>
	        </div>
        </div>
    </div>            
                            
               
</asp:Content>
