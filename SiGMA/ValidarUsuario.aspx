<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true"
    CodeBehind="ValidarUsuario.aspx.cs" Inherits="SiGMA.ValidarUsuario" %>

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
                    Validar Usuario</h3>
            </div>
            <div class="panel-body">
                <div class="col-md-2 col-md-offset-5">
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text="Usuario Validado Exitosamente"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-md-3 col-md-offset-5">
                <table>
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
                            Clave Validación:
                        </td>
                        <td>
                            <asp:TextBox  ID="txtToken" runat="server" MaxLength="10"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="rfvToken" runat="server" ErrorMessage="*" ForeColor="Red"
                                ControlToValidate="txtToken" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnValidar" runat="server" Text="Validar" 
                                onclick="btnValidar_Click"/>
                        </td>                    
                    </tr>
                </table>
                </div>
            </div>
        </div>
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
    </div>
</asp:Content>
