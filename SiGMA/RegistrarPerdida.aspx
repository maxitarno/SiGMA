﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPerdida.aspx.cs" Inherits="SiGMA.RegistrarPerdida" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!-- encabezado -->
<!-- fin encabezado -->
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

                    <asp:Panel ID="pnlBuscarPor" runat="server" >
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
                   
                        <asp:Panel ID="pnlRegistrarPerdida" runat="server" Visible="false">
                         <table width="100%">
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
                                <asp:DropDownList ID="ddlCalles" Enabled="false" runat="server"  Width="75%" AppendDataBoundItems="True">
                                </asp:DropDownList> - <asp:TextBox ID="txtNroCalle" ReadOnly="True" runat="server" Width="20%" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Barrio:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBarrios" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Localidad:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLocalidades" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False">
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
                                    <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" Enabled="false" AppendDataBoundItems="true">
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
                                Raza:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False">
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
                                <asp:DropDownList ID="ddlColor" Enabled="false" runat="server" Width="100%"
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Pérdida:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaPerdida" runat="server" Width="90%" ></asp:TextBox><asp:ImageButton ID="imgFechaPerdida" runat="server" CausesValidation="False"
                            ImageUrl="~/App_Themes/TemaSigma/imagenes/ico_calendar.gif" OnClick="imgFechaPerdida_click"  /> <asp:Calendar ID="calendario" runat="server" BorderColor="Black" 
                                    BorderWidth="1px" Visible="False" onselectionchanged="calendario_SelectionChanged">
                                     <DayHeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                                    <DayStyle ForeColor="Black" />
                                    <TitleStyle BackColor="Black" ForeColor="White" />
                                    </asp:Calendar>
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
                                <asp:TextBox ID="txtComentarios" runat="server" style="resize: none" TextMode="MultiLine"
                                        Rows="7" Columns="30" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               
                            </td>
                            <td>
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                    CssClass="btn-primary" onclick="btnCancelar_Click" /> -  
                                <asp:Button ID="btnRegistrarPerdida" runat="server" Text="Registrar" 
                                    CssClass="btn-primary" onclick="btnRegistrarPerdida_Click" />   
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
               </div>
            </div>
        </div>
    </div>
</asp:Content>
