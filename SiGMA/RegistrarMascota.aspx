﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarMascota.aspx.cs" Inherits="SiGMA.RegistrarMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 199px;
            text-align: left;
        }
        .style2
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                Registrar Mascota</h3>
        </div>
        <div>
         <div class="derecha">
    <table><tr><td><input type="file" runat="server"  id="fuImagen"  onchange="showimagepreview(this,'imgprvw')" />
        <%--<asp:FileUpload ID="fuImagen" runat="server"  />--%>
        </td>          
          </tr>
               <tr><td>
               <script type="text/javascript">
                           function showimagepreview(input, image) {
                               if (input.files && input.files[0]) {
                                   var filerdr = new FileReader();
                                   filerdr.onload = function (e) {
                                       $('#imgprvw').attr('src', e.target.result);
                                       document.getElementById(image).style.display = 'block';
                                   }
                                   filerdr.readAsDataURL(input.files[0]);
                               }
                           }
</script>                   
              <img id="imgprvw" width="140px" height="140px" hidden />    
    </td></tr>  
                  </table>
      
    </div>
        <div class="panel-body">
        
            <div class="almedio">
                        
   <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible=false>
                <button class="close" type="button" data-dismiss="alert">
                    ×</button>
                    <asp:Label ID="lblCorrecto" runat="server" Text="Mascota registrada exitosamente"></asp:Label>
            </asp:Panel>
            <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                <button class="close" type="button" data-dismiss="alert">
                    ×</button>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </asp:Panel>
            
                  <table>   
                    <tr>
                        <td>
                            <asp:Panel ID="pnlDatos" runat="server">
                                <table>
                                 <tr>   
                                    <td class="style2">Nombre:&nbsp                                       
                                    </td>
                                    <td class="style1">
                                            <asp:TextBox ID="txtNombreMascota" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                    <td>
    <asp:RequiredFieldValidator ID="rfvNombreMascota" runat="server" ErrorMessage="*" 
                                            ControlToValidate="txtNombreMascota" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                    <tr>
                                        <td class="style2">
                                            Especie:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlEspecie"
                                            AutoPostBack="true" runat="server" 
                                                onselectedindexchanged="ddlEspecie_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
        <asp:CustomValidator ID="cvEspecie" runat="server" ErrorMessage="*" ControlToValidate="ddlEspecie" ForeColor="Red" 
                                                onservervalidate="cvEspecie_ServerValidate"></asp:CustomValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Raza:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlRaza" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
        <asp:CustomValidator ID="cvRaza" runat="server" ErrorMessage="*" ControlToValidate="ddlRaza" ForeColor="Red" 
                                                onservervalidate="cvRaza_ServerValidate"></asp:CustomValidator></td>
                                    
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Edad:
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlEdad" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
        <asp:CustomValidator ID="cvEdad" runat="server" ErrorMessage="*" ControlToValidate="ddlEdad" ForeColor="Red" 
                                                onservervalidate="cvEdad_ServerValidate"></asp:CustomValidator></td>
                                    </tr>                                    
                                    <tr>
                                        <td class="style2">
                                            Color:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlColor" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
        <asp:CustomValidator ID="cvColor" runat="server" ErrorMessage="*" ControlToValidate="ddlColor" ForeColor="Red" 
                                                onservervalidate="cvColor_ServerValidate"></asp:CustomValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Trato con animales:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlTratoAnimales" runat="server">                                            
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Trato con niños:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlTratoNinios" runat="server">
                                            
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Caracter:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlCaracter" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Observaciones:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:TextBox ID="txtObservaciones" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Alimentacion especial:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:TextBox ID="txtAlimentacionEspecial" runat="server" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Sexo:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlSexo" runat="server">
                                                
                                            </asp:DropDownList>
                                        </td>
                                         <td>
        <asp:CustomValidator ID="cvDdlSexo" runat="server" ErrorMessage="*" ControlToValidate="ddlSexo" ForeColor="Red" 
                                                onservervalidate="cvDdlSexo_ServerValidate"></asp:CustomValidator></td>
                                    
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Fecha:&nbsp
                                        </td>
                                        <td class="style1">
                                            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" ></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="almedio">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlBtnRegistrar" runat="server">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" 
                                                CssClass="btn-primary" onclick="btnRegistrar_Click" />
                                        </asp:Panel>
                                    </td>                                    
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
