<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="ModerarPedidosDifusion.aspx.cs" Inherits="SiGMA.ModerarPedidosDifusion" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/difusiondueñoMini.png" />
                    <h1>Moderar Pedidos de Difusión /</h1>
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
                            <asp:Panel ID="pnlPedidos" runat="server">
                                <div class="form-group">
	                    	        <label for="contact-name">Pedidos de Difusión</label>
                                    <asp:GridView ID="grvPedidos" runat="server" CssClass="GridView1" AutoGenerateColumns="False" 
                                    onrowcommand="grvPedidos_RowCommand" HorizontalAlign="Center" Font-Size="Medium" 
                                    CellPadding="2" CellSpacing="3" Width="100%"> 
                                    <RowStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>  
                                    <Columns>
                                        <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                                        <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                            HeaderText="Fecha" />
                                        <asp:BoundField DataField="user.user" HeaderText="Usuario" />
                                        <asp:BoundField DataField="idPedidoDifusion" HeaderText="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField DataField="campaña.idCampaña" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField DataField="hallazgo.idHallazgo" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField DataField="perdida.idPerdida" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField DataField="mascota.idMascota" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:ButtonField ButtonType="Button" Text="+"/>
                                    </Columns>
                                </asp:GridView>   
	                            </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDatos" runat="server" Visible="false">
                                <div class="form-group" style="text-align:center;">
	                                 <img id="imgprvw" style="border: 1px solid #000000; height: 200px; width: 300px;"
                                    runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg"/>
                                    <br /><label for="contact-name"><asp:Label ID="lblDatos" runat="server"/></label>
	                            </div>
                             </asp:Panel>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlResolucion" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Resolución</label>
                                    <asp:DropDownList ID="ddlResolucion" runat="server" 
                                        AppendDataBoundItems="true" 
                                        onselectedindexchanged="ddlResolucion_SelectedIndexChanged" 
                                        AutoPostBack="True" Width="100%">
                                        <asp:ListItem Selected="True">Publicar</asp:ListItem>
                                        <asp:ListItem>Rechazar</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name"><asp:Label ID="lblRechazo" runat="server" Text="Motivo de rechazo:" Visible="false"/></label>
                                    <asp:TextBox ID="txtRechazo" runat="server" Visible="false" Enabled="false" 
                                        MaxLength="100" TextMode="MultiLine" Style="resize:none" onkeyDown="checkTextAreaMaxLength(this,event,'100');"></asp:TextBox>
                                    <asp:CustomValidator ID="cvRechazo" runat="server" ErrorMessage="Ingrese el motivo de rechazo" 
                                        ForeColor="Red" onservervalidate="cvRechazo_ServerValidate"></asp:CustomValidator>
                                </div>
                                <asp:Button ID="btnAceptar" runat="server" Width="180px" 
                                                        Text="Aceptar" onclick="btnAceptar_Click"  />
                            </asp:Panel>
                        </div>
	                </div>
	            </div>
	        </div>
        </div>                
</asp:Content>

