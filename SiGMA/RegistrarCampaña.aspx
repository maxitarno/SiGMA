<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarCampaña.aspx.cs" Inherits="SiGMA.RegistrarCampaña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="utf-8">
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

    <link href="assets/calendario_dw/calendario_dw-estilos.css" type="text/css" rel="STYLESHEET"/>
   <script type="text/javascript" src="assets/calendario_dw/jquery-1.4.4.min.js"></script>
   <script type="text/javascript" src="assets/calendario_dw/calendario_dw.js"></script>
   
   <script type="text/javascript">
       (function ($) {
           $(document).ready(function () {
               $(".campofecha").calendarioDW();
           })
       })(jQuery);
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="centered">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">
                Registrar Campaña</h3>
        </div>
        <div class="panel-body">
        <div style="margin-left:30%; width: 30%">        
                <asp:Panel runat="server" id="pnlCorrecto" 
                        class="alert alert-dismissable alert-success"  Visible=false Width="550px">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Width="550px" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>                
                </div>                                 
                <asp:Panel ID="pnlDatosCampaña" runat="server">
                <div style="margin-left: 30%; display: table; width: 60%;">  
                    <div style="display: table-row; width: 30%;">     
                        <div style="display: table-cell; width: 30%;"> 
                            <asp:Panel Visible="true" runat="server" ID="pnlPreview">
                                <img id="preview" width="215px" style="margin-left: 19%" height="135px" hidden />
                            </asp:Panel>
                            <asp:Panel ID="pnlDatos" runat="server" Visible="true">
                                <table>
                                    <tr>
                                        <td align="right">
                                            Lugar:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLugar" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvLugar" runat="server" ErrorMessage="*"
                                            ForeColor="Red" ControlToValidate="txtLugar"></asp:RequiredFieldValidator>
                                        </td>
                                        
                                            
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Tipo de Campaña:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlTipoCampaña" runat="server" 
                                                AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                       
                                            <asp:CustomValidator ID="cvTipoCampaña" runat="server" ErrorMessage="*" 
                                                ForeColor="Red" ControlToValidate="ddlTipoCampaña" 
                                                onservervalidate="cvTipoCampaña_ServerValidate"></asp:CustomValidator></td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Fecha:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFecha" class="campofecha pull-left" ReadOnly="false" runat="server"></asp:TextBox>
                                        
                                            <asp:RequiredFieldValidator ForeColor="Red"
                                            ControlToValidate="txtFecha" ID="rfvFecha" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Hora:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtHora" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revHora" runat="server" 
                                                ErrorMessage="HH:mm" ControlToValidate="txtHora" ForeColor="Red"
                                                ValidationExpression="^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ControlToValidate="txtHora"
                                                    ID="rfvHora" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        </tr>
                                        <asp:Panel ID="pnlInputFoto" runat="server">
                                            <tr>
                                                <td align="right">
                                                </td>
                                                <td>
                                                    <input style="width:100%" type="file" runat="server"  id="fuImagen" onchange="showimagepreview(this,'preview')" />
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnRegistrarCampaña" runat="server" style="margin-left: 12%" 
                                                    Text="Registrar" onclick="btnRegistrarCampaña_Click" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </div>
                        <div style="display: table-row; width: 30%">  
                                        
                        </div>  
                        </div>                         
                        </asp:Panel>                       
                        </div>   
        </div>
    </div> 
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" 
            ImageUrl="~/imagenes/volver.png" onclick="ibtnRegresar_Click" 
            CausesValidation="False"/>
        </br>
        Volver
    </div>  
    <script type="text/javascript">
        function showimagepreview(input, image) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#preview').attr('src', e.target.result);
                    document.getElementById(image).style.display = 'block';
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
                                    </script>      
</asp:Content>
