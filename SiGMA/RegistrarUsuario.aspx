<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SiGMA._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table >             
    <tr>
                <td style="text-align: right">Nombre:
                    </td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                              ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator> 
                    </td>
                               </tr>
                               <tr>
                <td style="text-align: right">Apellido:
                    </td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                              ErrorMessage="*" ForeColor="Red" ControlToValidate="txtApellido"></asp:RequiredFieldValidator> 
                    </td>
                               </tr>
                               <tr>
                <td style="text-align: right">Tipo de Documento:
                    </td>
                <td>
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="1">D.N.I.</asp:ListItem>
                        <asp:ListItem Value="2">Pasaporte</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTipoDocumento" runat="server" 
                              ErrorMessage="*" ForeColor="Red" 
                        ControlToValidate="ddlTipoDocumento"></asp:RequiredFieldValidator> 
                    </td>
                               </tr>
                                         <tr>
                <td style="text-align: right">Documento:
                    </td>
                <td>
                    <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" 
                              ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDocumento"></asp:RequiredFieldValidator> 
                    <asp:CustomValidator ID="cuvDocumento" runat="server" 
                        ErrorMessage="Solo numeros" ControlToValidate="txtDocumento" ForeColor="Red"></asp:CustomValidator>
                    </td>
                               </tr>
                <tr>
                     <td style="text-align: right">Usuario:</td>
                     <td ><asp:TextBox ID="txtUsuario" runat="server" MaxLength="10"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
                              ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
                         </td>                     
                 </tr>  
                 
                 <tr>
                     <td style="text-align: right">Contraseña:</td>
                     <td><asp:TextBox ID="txtContra" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvContra" runat="server" 
                              ErrorMessage="*" ForeColor="Red" ControlToValidate="txtContra"></asp:RequiredFieldValidator>
                         </td>                     
                 </tr>
                 
                 <tr>
                      <td><asp:Label ID="lblRepetirContraseña" runat="server" Text="Repetir Contraseña:"></asp:Label></td>
                      <td> <asp:TextBox ID="txtRepetirContra" runat="server" MaxLength="25" 
                              TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvRepetirContra" runat="server" 
                              ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRepetirContra"></asp:RequiredFieldValidator>
                          <asp:CompareValidator ID="covPassword" runat="server" 
                              ErrorMessage="Las contraseñas no son iguales" ControlToCompare="txtContra" 
                              ControlToValidate="txtRepetirContra" ForeColor="Red"></asp:CompareValidator>
                      </td>
                  </tr>
               
                        <tr>
                <td style="text-align: right">Email:
                    </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                              ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator> <asp:RegularExpressionValidator ID="revMail" runat="server" 
                                            ErrorMessage="Formato de email incorrecto" ForeColor="Red" 
                                            ControlToValidate="txtEmail" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                               </tr>                 
                  <tr><td></td><td> <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" 
                          onclick="btnRegistrar_Click" /></td><td><asp:Label ID="lblResultado" runat="server" Text="Label" Visible="False"></asp:Label></td></tr>
                   
               </table>
</asp:Content>
