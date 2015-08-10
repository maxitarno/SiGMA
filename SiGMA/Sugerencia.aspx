<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Sugerencia.aspx.cs" Inherits="SiGMA.Sugerencia" %>
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
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h3 class="panel-title">
                Buzón de Sugerencias</h3>
            </div>

            <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-md-4 col-md-offset-4">
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
            <div class="centered"><h5>Sus sugerencias/opiniones nos ayudan a mejorar</h5> </div>
            <br/>
            <div class="panel-body">
                <div>
                    <div class="col-lg-8 col-lg-offset-4 col-sm-10 col-sm-offset-2 col-md-8 col-md-offset-4">
                        <table>
                            <tr style="height:30px">
                                <td align="right" width="200px">Nombre:</td>
                                <td align="left"><asp:TextBox ID="txtNombre" runat="server" Width="325px"></asp:TextBox></td>
                                <td><asp:RequiredFieldValidator ID="rfvNombreApellido" runat="server" 
                                        ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr style="height:30px">
                                <td align="right" width="200px">Email:</td>
                                <td align="left"><asp:TextBox ID="txtEmail" runat="server" Width="325px"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" 
                                        ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                                ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator>  
                                        </td>
                            </tr >
                            <tr style="height:30px">
                                <td align="right" width="200px" >Telefono:</td>
                                <td align="left"><asp:TextBox ID="txtTelefono" runat="server" Width="325px"></asp:TextBox></td>
                                <td><asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="*" 
                                        ForeColor="Red" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr style="height:30px">
                                <td align="right" width="200px">Sugerencia</td>
                                <td align="left"><asp:TextBox ID="txtConsulta" runat="server" style="resize: none" TextMode="MultiLine"
                                                        Rows="4" Columns="25" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'500');"></asp:TextBox></td>
                                <td><asp:RequiredFieldValidator ID="rfvConsulta" runat="server" ErrorMessage="*" 
                                        ForeColor="Red" ControlToValidate="txtConsulta"></asp:RequiredFieldValidator></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
             <div class="centered">
            <asp:Button ID="btnEnviar" style="margin-left: 39px" runat="server" 
                                        Text="Enviar" onclick="btnEnviar_Click" /></td>
            </div>
        </div>
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />PRINCIPAL
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
