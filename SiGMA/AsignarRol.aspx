<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="AsignarRol.aspx.cs" Inherits="SiGMA.AsignarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
                    <img src="assets/img/menu/asignarrolMini.png" />
                    <h1>Asignar Rol a Usuario /</h1>
                    <p>Indispensable para un buen manejo de permisos en Sigma</p>
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
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible="false">
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
    <div class="contact-us-container">
        <div class="container">
	        <div class="row">
	            <div class="col-sm-7 contact-form wow fadeInLeft">
	                <div class="form-group">
	                    <label for="contact-name">Ingrese un usuario</label>
	                    <asp:TextBox ID="txtSelecionUsuario" runat="server"></asp:TextBox>
	                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" Width="180px" />
                        </div>
                        <asp:Panel ID="pnlUsuario" runat="server" Visible="false">
                            <div class="form-group"> 
                                 <label for="contact-name">Seleccione un Usuario</label>
                                 <asp:ListBox ID="lstUsuarios" runat="server" Width="100%" AutoPostBack="True" 
                                    onselectedindexchanged="lstUsuarios_SelectedIndexChanged"></asp:ListBox>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlAsignalRol" runat="server" Visible="false">
                            <div class="form-group"> 
                                <label for="contact-name">Usuario: <asp:Label ID="lblUsuario" runat="server" Text=""/></label>
                                
                            </div>
                            <div class="form-group"> 
                                <label for="contact-name">Roles que tiene el usuario</label>
                                 <asp:DropDownList ID="ddlRolUsuario" runat="server" 
                                    AppendDataBoundItems="true" Width="80%"/><asp:Button ID="btnEliminarRol" runat="server" Text="Eliminar" 
                                    onclick="btnEliminarRol_Click" visible="false" Width="20%"/> 
                            </div>
                            <div class="form-group"> 
                                <label for="contact-name">Agregar rol</label><br />
                                <asp:DropDownList ID="ddlRol" runat="server" 
                                    AppendDataBoundItems="true" Width="80%" /><asp:Button ID="btnAsignarRol" runat="server" Text="Asignar" 
                                    onclick="btnAsignarRol_Click" visible="false" Width="20%"/>
                            </div>
                                 <asp:DropDownList ID="ddlRolesTraspaso" visible="false" runat="server" AutoPostBack="true" 
                                    AppendDataBoundItems="true"> 
                                </asp:DropDownList>
                        </asp:Panel>
                </div>
	            <div class="col-sm-5 contact-address wow fadeInUp">
                <br />
	                <img src="base/img/portfolio/asignarRol.jpg" />
	            </div>
	        </div>
	    </div>
    </div>
</asp:Content>

