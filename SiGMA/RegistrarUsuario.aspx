<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true"
    CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SiGMA._Default" %>

<asp:Content  runat="server" ContentPlaceHolderID="head">
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
   
<asp:Content  runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Registrar Usuario</h3>
            </div>
            <div class="panel-body">
                <div class="col-md-2 col-md-offset-5">
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text="Usuario registrado exitosamente"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-md-2 col-md-offset-4">
                <table>
                    <tr>
                        <td>
                            Nombre:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="*" ForeColor="Red"
                                ControlToValidate="txtNombre" Display="Dynamic"></asp:RequiredFieldValidator></td>
                   
                    </tr>
                    <tr>
                        <td>
                            Apellido:
                        </td>
                        <td>
                            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="*" ForeColor="Red"
                                ControlToValidate="txtApellido" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo de Documento:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server">
                            </asp:DropDownList></td><td>
                            <asp:RequiredFieldValidator ID="rfvTipoDocumento" runat="server" ErrorMessage="*"
                                ForeColor="Red" ControlToValidate="ddlTipoDocumento" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           Nro. de Documento:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ErrorMessage="*" ForeColor="Red"
                                ControlToValidate="txtDocumento" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cuvDocumento" runat="server" ErrorMessage="Solo numeros"
                                ControlToValidate="txtDocumento" ForeColor="Red" Display="Dynamic" 
                                onservervalidate="cuvDocumento_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuario:
                        </td>
                        <td>
                            <asp:TextBox  ID="txtUsuario" runat="server" MaxLength="10"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="*" ForeColor="Red"
                                ControlToValidate="txtUsuario" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contraseña:
                        </td>
                        <td>
                            <asp:TextBox ID="txtContra" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="rfvContra" runat="server" ErrorMessage="*" ForeColor="Red"
                                ControlToValidate="txtContra" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRepetirContraseña" runat="server" Text="Repetir Contraseña:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox  ID="txtRepetirContra" runat="server" MaxLength="25" TextMode="Password"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="rfvRepetirContra" runat="server" ErrorMessage="*"
                                ForeColor="Red" ControlToValidate="txtRepetirContra" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="covPassword" runat="server" ErrorMessage="Las contraseñas no son iguales"
                                ControlToCompare="txtContra" ControlToValidate="txtRepetirContra" ForeColor="Red"
                                Display="Dynamic"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email:
                        </td>
                        <td>
                            <asp:TextBox  ID="txtEmail" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                                ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click"/>
                        </td>                    
                    </tr>
                </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
