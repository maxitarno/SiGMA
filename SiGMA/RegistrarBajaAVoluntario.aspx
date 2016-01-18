<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarBajaAVoluntario.aspx.cs" Inherits="SiGMA.DarBajaAVoluntario" MasterPageFile="PaginaAdmin.Master" %>
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
	                <img src="assets/img/menu/voluntariosMini.png" />
                    <h1>Inhabilitar Voluntario /</h1>
                    <p>Ser voluntario, implica compromiso y responsabilidad</p>
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
	                    	        <label for="contact-name">Voluntarios</label>
                                    <asp:GridView ID="grvVoluntarios" runat="server" CssClass="GridView1" AutoGenerateColumns="False" 
                                    onrowcommand="grvPedidos_RowCommand" HorizontalAlign="Center" Font-Size="Medium" 
                                    CellPadding="2" CellSpacing="3" Width="100%" > 
                                    <RowStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#9D426B"/>  
                                    <Columns>
                                        <asp:BoundField DataField="tipoVoluntario" HeaderText="Tipo de voluntario" />
                                        <asp:BoundField DataField="persona.nombre" HeaderText="Nombre del voluntario" />
                                        <asp:BoundField DataField="idVoluntario" HeaderText="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField DataField="disponibilidadHoraria" HeaderText="Disponibilidad horaria" />
                                        <asp:ButtonField ButtonType="Button" Text="Inhabilitar"/>
                                    </Columns>
                                </asp:GridView> 
	                            </div>
                            </asp:Panel>
                        </div>
	                </div>
                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                                <div class="form-group">
                                    <img src="base/img/portfolio/bajavoluntario.jpg" />
                                </div>
                        </div>
	                </div>

                    
	            </div>
	        </div>
        </div>                
</asp:Content>
