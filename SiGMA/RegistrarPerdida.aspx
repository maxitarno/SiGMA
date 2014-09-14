<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPerdida.aspx.cs" Inherits="SiGMA.RegistrarPerdida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!-- encabezado -->
<!-- fin encabezado -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h1 class="panel-title">
                   Registrar Perdida
                </h1>
            </div>
            <div class="panel-body">
               <div class="almedio">
                    <asp:Panel runat="server" ID="pnlCorrecto" class="alert alert-dismissable alert-success"
                    Visible="false">
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
                    <asp:Panel runat="server" ID="pnlAtento" class="alert alert-dismissable alert-danger"
                    Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </asp:Panel>

                    <asp:Panel ID="pnlBuscarPor" runat="server" Width="100%">
                        <table>
                            <tr>
                                <td colspan="2" align="justify">
                                    <asp:Panel ID="pnlVoluntario" runat="server" Visible="false">
                                        <table>
                                        <tr>
                                        <td valign="middle">
                                                Mascota:&nbsp
                                        </td>
                                        <td>
                                                <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox>
                                        </td>
                                        <td colspan="3" rowspan="2">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-primary" onclick="btnBuscar_Click" />
                                        </td>
                                        </tr>
                                        </table>
                                        <br />
                                        </asp:Panel>
                                </td>
                                </tr>
                                <tr>
                                <td colspan="2" align="right">
                                    <asp:Panel ID="pnlDueño" runat="server" Visible="false">
                                    <table width="100%">
                                        <tr>
                                        <td>
                                            Mascota: <asp:ListBox ID="lstMascotas" runat="server" Width="100%" 
                                                onselectedindexchanged="lstMascotas_SelectedIndexChanged" 
                                                AutoPostBack="True"></asp:ListBox>
                                        </td>
                                        <td>
                                           <asp:Button ID="btnSeleccionar" runat="server" Text="Cargar Formulario" 
                                                CssClass="btn-primary" onclick="btnSeleccionar_Click" />
                                        </td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel Visible="false" runat="server" ID="pnlImagen">
                        <img id="imgprvw" style="border: 2px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                     </asp:Panel>
                    <table>
                        <asp:Panel ID="pnlRegistrarPerdida" runat="server" Width="100%" Visible="false">
                         <tr>
                            <td>
                                Dueño:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDatosDueño" ReadOnly="True" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                                <td>
                                    Domicilio:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDomicilio" ReadOnly="True" runat="server" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                Barrio:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBarrio" ReadOnly="True" runat="server" Width="100%" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Localidad:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLocalidad" ReadOnly="True" runat="server" Width="100%" AppendDataBoundItems="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                Mascota:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMascotaPerdida" ReadOnly="True" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                                <td>
                                    Especie:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" ReadOnly="True" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                Edad:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEdad" ReadOnly="True" runat="server" Width="100%" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Raza:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRaza" ReadOnly="True" runat="server" Width="100%" AppendDataBoundItems="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                            <tr>
                            <td>
                                Sexo:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSexo" ReadOnly="True" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Color:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlColor" ReadOnly="True" runat="server" Width="100%"
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Categoría:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCategoria" ReadOnly="True" runat="server"
                                    Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                            <tr>
                            <td>
                                Carácter:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCaracter" ReadOnly="True" runat="server" CssClass="DropDownList" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trato con otros animales:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTratoAnimales" runat="server" Width="100%" ReadOnly="True">
                                    <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="False"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trato con niños:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTratoNinios" runat="server" Width="100%" ReadOnly="True">
                                    <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción --"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="False"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Pérdida:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaPerdida" runat="server" Width="100%" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Lugar:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMapa" runat="server" Width="100%" Text="Acá iría el mapa con el punto de donde se perdio"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Comentarios:
                            </td>
                            <td>
                                <asp:TextBox ID="txtComentarios" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />    
                            </td>
                        </tr>
                        </asp:Panel>
                    </table>
               </div>
            </div>
        </div>
    </div>
</asp:Content>
