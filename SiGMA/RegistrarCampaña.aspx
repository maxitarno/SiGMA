﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarCampaña.aspx.cs" Inherits="SiGMA.RegistrarCampaña" Culture="Auto" UICulture="Auto"%>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
<div class="centered">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">
                Registrar Campaña</h3>
        </div>
        <div class="panel-body">
        <div class="col-md-5 col-md-offset-5">      
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
                <div class="col-md-4 col-md-offset-4" style="margin-left: 30%; display: table; width: 60%;">  
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
                                            <asp:TextBox ID="txtFecha" runat="server"  />
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/calendario_dw/calendario.png" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" 
                                                    runat="server" TargetControlID="txtFecha" 
                                                    PopupButtonID="Image1">
                                                </ajaxToolkit:CalendarExtender>
                                            <asp:RangeValidator ID="rnvFechaCampaña" runat="server" ErrorMessage="La fecha no puede ser inferior a la actual" 
                                                    ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                                    Type="Date" Font-Size="XX-Small" 
                                                    ></asp:RangeValidator>
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
        VOLVER
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
