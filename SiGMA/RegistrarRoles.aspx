<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarRoles.aspx.cs" Inherits="SiGMA.RegistrarRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../../docs-assets/ico/favicon.png">

    <title>SIGMA</title>

    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">


    <!-- Custom styles for this template -->
    <link href="assets/css/main.css" rel="stylesheet">

    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="assets/js/hover.zoom.js"></script>
    <script src="assets/js/hover.zoom.conf.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h3 class="panel-title">
                Roles</h3>
        </div>
         <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-md-2 col-md-offset-5">
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

        <div class="panel-body">
            <div class="col-md-2 col-md-offset-5">
                    <asp:Panel ID="pnlSeleccionRol" runat="server">
                        Modificar Rol <asp:DropDownList ID="ddlRol" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" 
                            onselectedindexchanged="ddlRol_SelectedIndexChanged"> 
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button runat="server" Text="Crear Nuevo Rol" ID="btnNuevoRol" 
                             onclick="btnNuevoRol_Click"/>    
                    </asp:Panel>
            </div>
        </div>

        <div class="panel-body">
            <div class="col-md-2 col-md-offset-4">
                <asp:Panel ID="pnlModificacionRol" runat="server" Visible="false">
                    <table>
                        <tr style="height:30px">
                            <td align="right" width="100px"> Rol: </td>
                            <td align="left"> 
                                <asp:TextBox ID="txtRol" runat="server" MaxLength="21"></asp:TextBox>
                            </td>
                            <td><asp:RequiredFieldValidator ID="rfvRol" runat="server" ErrorMessage="*" 
                                    Text="Ingrese nombre de rol" ControlToValidate="txtRol" Font-Size="Small" 
                                    ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" width="100px">Descripcion: </td>
                            <td align="left">
                                <asp:TextBox ID="txtDescripcionRol" runat="server" style="resize:none" TextMode="MultiLine" Rows="3" Columns="23" onkeyDown="checkTextAreaMaxLength(this,event,'50');"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                    </table>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-md-2 col-md-offset-5">
                    <br />
                    <asp:Button ID="btnGuardarRol" runat="server" Text="Guardar" 
                        onclick="btnGuardarRol_Click" />
                    <asp:Button ID="btnEliminarRol" runat="server" Text="Eliminar" 
                       onclick="btnEliminarRol_Click" />
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
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
</div>
</asp:Content>
