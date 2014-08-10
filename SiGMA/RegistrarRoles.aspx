<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarRoles.aspx.cs" Inherits="SiGMA.RegistrarRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Roles</h3>
        </div>
        <div class="panel-body">
            <div>
                <div class="almedio">
                    <asp:Panel ID="pnlSeleccionRol" runat="server">
                        Modificar Rol <asp:DropDownList ID="ddlRol" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" 
                            onselectedindexchanged="ddlRol_SelectedIndexChanged"> 
                            <asp:ListItem Value="0" Text="---Seleccione un rol ---"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button runat="server" Text="Crear Nuevo Rol" ID="btnNuevoRol" 
                            class="btn-primary" onclick="btnNuevoRol_Click"/>    
                    </asp:Panel>
                    <asp:Panel ID="pnlModificacionRol" runat="server" Visible="false">
                        <table>
                            <tr style="height:30px">
                                <td align="right" width="100px"> Rol: </td>
                                <td align="left"> 
                                    <asp:TextBox ID="txtRol" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="100px">Descripcion: </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescripcionRol" runat="server" style="resize:none" TextMode="MultiLine" Rows="3" Columns="23" onkeyDown="checkTextAreaMaxLength(this,event,'50');"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="btnGuardarRol" runat="server" Text="Guardar" 
                            onclick="btnGuardarRol_Click" class="btn-primary" />
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
   </div>
</asp:Content>
