<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegistrarHallazgo.aspx.cs" Inherits="SiGMA.RegistrarHallazgo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Registrar Hallazgo</h3>
        </div>
        
        <div style="margin-left: 30%; display: table;width: 40%;">
            <div style="display: table-row; width:30%">           
                <div style="display: table-cell; width: 20%;"> 
                        <asp:RadioButton ID="rbYaPerdida" runat="server" Text="Mascota Perdida" 
                            GroupName="TipoHallazgo" AutoPostBack="True" 
                            oncheckedchanged="rbYaPerdida_CheckedChanged" />                   
        </div>
        <div style="display: table-cell; width: 20%;">
                                <asp:RadioButton ID="rbNuevaMascota" runat="server" Text="Nueva Mascota" 
                                    GroupName="TipoHallazgo" AutoPostBack="True" 
                                    oncheckedchanged="rbNuevaMascota_CheckedChanged" />
        </div> 
        </div>  
        </div>      
                <asp:Panel ID="pnlPerdida" runat="server" Visible="false">
                   
                        <div style="margin-left: 30%; display: table;width: 40%;">
                        <div style="display: table-row; width:30%">           
                <div style="display: table-cell; width: 20%;"> 
                 <asp:ListBox ID="lstPerdidas" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="lstPerdidas_SelectedIndexChanged"></asp:ListBox>
                </div>
                </div>
                <asp:Panel ID="pnlMascotaSeleccionada" runat="server" Visible="false">
            <div style="display: table-row; width:30%">           
                <div style="display: table-cell; width: 20%;"> 
                        <asp:Panel Visible="true" runat="server" ID="pnlImagen">
                        <img id="imgprvw" style="border: 2px solid #000000; height: 135px; width: 215px;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                     </asp:Panel>
                     </div>
                   <div style="display: table-cell; width: 30%;">
                        <asp:Panel ID="pnlHallazgoPerdidaMascota" runat="server" Visible="true">
                         <table>
                         <tr>
                                <td>
                                    Nombre: 
                                </td>
                                <td>
                                    <asp:Label ID="lblNombreMascotaPerdida" runat="server" Text="Label"></asp:Label> </td>
                                </tr>
                          <tr>
                                <td>
                                    Especie:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" Enabled="false" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                       
                        <tr>
                            <td>
                                Raza:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                Edad:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEdad" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                            <tr>
                            <td>
                                Sexo:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSexo" Enabled="false" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Color:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlColor" Enabled="False" runat="server" Width="100%"
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>  
                        </div> 
                        </div>
                        <asp:Panel ID="pnlHallazgoPerdidaLugar" runat="server" Visible="false"> 
                         <div style="display: table-row; width:30%">           
                <div style="display: table-cell; width: 20%;">   
                <table>   
                
                        <tr>
                            <td>
                                Localidad:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLocalidades" Enabled="true" runat="server" Width="50%" 
                                    AppendDataBoundItems="False" 
                                    onselectedindexchanged="ddlLocalidades_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>                                        
                        <tr>
                            <td>
                                Domicilio:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCalles" Enabled="true" runat="server"  Width="50%" AppendDataBoundItems="True">
                                </asp:DropDownList> - <asp:TextBox ID="txtNroCalle" ReadOnly="True" runat="server" Width="20%" ></asp:TextBox>
                            </td>
                        </tr>                        
                        <tr>
                            <td>
                                Barrio:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBarrios" Enabled="true" runat="server" Width="50%" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr> 
                       
                        <tr>
                            <td>
                                Fecha del Hallazgo:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" Width="50%" ></asp:TextBox>
                                <%--<asp:ImageButton ID="imgFechaPerdida" runat="server" CausesValidation="False"
                            ImageUrl="~/App_Themes/TemaSigma/imagenes/ico_calendar.gif"  /> <asp:Calendar ID="calendario" runat="server" BorderColor="Black" 
                                    BorderWidth="1px" Visible="False" onselectionchanged="calendario_SelectionChanged">
                                     <DayHeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                                    <DayStyle ForeColor="Black" />
                                    <TitleStyle BackColor="Black" ForeColor="White" />
                                    </asp:Calendar>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Lugar:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMapa" runat="server" Width="50%" Text="Acá iría el mapa con el punto de donde se perdio"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Comentarios:
                            </td>
                            <td>
                                <asp:TextBox ID="txtComentarios" runat="server" style="resize: none" TextMode="MultiLine"
                                        Rows="7" Columns="30" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               
                            </td>
                            <td>                                  
                                <asp:Button ID="btnRegistrarPerdida" runat="server" Text="Registrar" 
                                    CssClass="btn-primary" />   
                            </td>
                        </tr>
                        </table>
                         </div> 
                        </div>
                        </asp:Panel>    
                        </asp:Panel>
                        </div> 
                        </asp:Panel> 
                <asp:Panel ID="pnlNueva" runat="server">
                </asp:Panel>  
                </div>     
</asp:Content>
