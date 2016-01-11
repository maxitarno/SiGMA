<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="RegistrarRoles.aspx.cs" Inherits="SiGMA.RegistrarRoles" %>
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
                    <img src="assets/img/menu/asignarrolMini.png" />
                    <h1>Roles /</h1>
                    <p>Una identificación precisa de cada rol es indispensable para un buen manejo de los mismos</p>
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
	                    <label for="contact-name">Modificar Rol</label>
	                    <asp:DropDownList ID="ddlRol" runat="server" AutoPostBack="true" 
                        AppendDataBoundItems="true" Width="100%"
                        onselectedindexchanged="ddlRol_SelectedIndexChanged"> 
                        </asp:DropDownList>
	                    <asp:Button runat="server" Text="Crear Nuevo Rol" ID="btnNuevoRol" 
                        onclick="btnNuevoRol_Click" Width="180px"/>  
                            <br />
                        </div>
                    <asp:Panel ID="pnlModificacionRol" runat="server" Visible="false">
                        <div class="form-group"> 
                            <asp:TextBox ID="txtRol" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRol" runat="server" ErrorMessage="Ingrese un nombre de rol" 
                            Text="Ingrese nombre de rol" ControlToValidate="txtRol" Font-Size="Small" 
                            ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group"> 
                            <asp:TextBox ID="txtDescripcionRol" runat="server" style="resize:none" TextMode="MultiLine" Rows="3" Columns="23" onkeyDown="checkTextAreaMaxLength(this,event,'50');"></asp:TextBox>
                        </div>
                        <div class="form-group"> 
                            <asp:Button ID="btnGuardarRol" runat="server" Text="Guardar" 
                            onclick="btnGuardarRol_Click" Width="180px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnEliminarRol" runat="server" Text="Eliminar" 
                            onclick="btnEliminarRol_Click" Width="180px" OnClientClick="if (!confirm('¿Está seguro que desea eliminar el rol?')){ return false; } else { return true; }"/>
                        </div>
                    </asp:Panel>
                </div>
	            <div class="col-sm-5 contact-address wow fadeInUp">
                <br /><br />
	                <img src="base/img/portfolio/roles.jpg" />
	            </div>
	        </div>
	    </div>
    </div>
</asp:Content>
