<%@ Page Title="Difusion" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="DifusionDueño.aspx.cs" Inherits="SiGMA.DifusionDueño" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .tr {
    text-align: center;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/difusiondueñoMini.png" />
                    <h1>Difusión /</h1>
                    <p>La difusión es una herramienta clave para llegar a la gente</p>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-4 col-md-offset-4">
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible="false">                    
                        <asp:Label ID="lblInfo" runat="server" Text = "Usted no ha generado pedidos de difusión"></asp:Label>
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
            <div class="form-group">
                <label for="contact-name">Registrar una nueva campaña</label>
                <br />
                <asp:Button ID="btnRegCampaña" 
                    runat="server" Text="Registrar Campaña" onclick="btnRegCampaña_Click" Width="180px" />
            </div>
            <br />
            <asp:Panel ID="pnlPedidos" runat="server">
                <div class="form-group" style="text-align:center">
                    <label for="contact-name">Mis pedidos de difusión</label>
                    <asp:GridView ID="grvPedidos" runat="server"
                        AutoGenerateColumns="False" 
                        onsorting="grvPedidos_Sorting" Width="600px" HorizontalAlign="Center" Font-Size="Medium"
                        CellPadding="2" CellSpacing="3" onrowcommand="grvPedidos_RowCommand"> 
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>
                        <Columns>
                            <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderText="Fecha" SortExpression="fecha" />  
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo" />                                                      
                            <asp:BoundField DataField="estado.nombreEstado" HeaderText="Estado" 
                                SortExpression="estado.nombreEstado" />
                            <asp:BoundField DataField="motivoRechazo" HeaderText="Motivo Rechazo" 
                                SortExpression="motivoRechazo" NullDisplayText="-" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" Text="Eliminar"  />
                            <asp:BoundField DataField="idPedidoDifusion">
                            <HeaderStyle CssClass="hidden" />
                            <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>   
                </div>
            </asp:Panel>                       
        </div>
    </div>
</asp:Content>

