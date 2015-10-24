<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarMascota.aspx.cs" Inherits="SiGMA.RegistrarMascota" Culture="Auto" UICulture="Auto"%>
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
    <link href="assets/calendario_dw/calendario_dw-estilos.css" type="text/css" rel="STYLESHEET"/>

    <style type="text/css">
        .style1
        {
            text-align: left;
        }
        .style2
        {
            text-align: right;
        }
        .style3
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h3 class="panel-title">
                Registrar Mascota</h3>
            </div>


    <div class="panel panel-default">
        <div class="panel-body">
                <div class="col-md-2 col-md-offset-5">
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
                </div>
         </div>
        <div class="panel-body">
        <div class="col-md-2 col-md-offset-5">

                        <asp:Panel ID="pnlDatos" runat="server">
                            <table>
                                <tr>   
                                <td class="style2" width="100px">Nombre:&nbsp                                       
                                </td>
                                <td class="style1" width="250px">
                                        <asp:TextBox ID="txtNombreMascota" runat="server" width="250px"></asp:TextBox>
                                </td>
                                <td class="style3" >
                                    <asp:RequiredFieldValidator ID="rfvNombreMascota" runat="server" ErrorMessage="*" 
                                        ControlToValidate="txtNombreMascota" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                <tr>
                                    <td class="style2" width="100px" >
                                        Especie:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:DropDownList ID="ddlEspecie"
                                        AutoPostBack="true" runat="server" 
                                            onselectedindexchanged="ddlEspecie_SelectedIndexChanged" width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3" >
                                    <asp:CustomValidator ID="cvEspecie" runat="server" ErrorMessage="*" ControlToValidate="ddlEspecie" ForeColor="Red" 
                                            onservervalidate="cvEspecie_ServerValidate"></asp:CustomValidator></td>
                                </tr>
                                <tr>
                                    <td class="style2" width="100px">
                                        Raza:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:DropDownList ID="ddlRaza" runat="server" width="250px">
                                        </asp:DropDownList>
                                    </td >
                                    <td class="style3" >
                                        <asp:CustomValidator ID="cvRaza" runat="server" ErrorMessage="*" ControlToValidate="ddlRaza" ForeColor="Red" 
                                            onservervalidate="cvRaza_ServerValidate"></asp:CustomValidator></td>
                                    
                                </tr>
                                <tr>
                                    <td class="style2" width="100px">
                                        Edad:
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:DropDownList ID="ddlEdad" runat="server" width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3" >
                                        <asp:CustomValidator ID="cvEdad" runat="server" ErrorMessage="*" ControlToValidate="ddlEdad" ForeColor="Red" 
                                            onservervalidate="cvEdad_ServerValidate"></asp:CustomValidator></td>
                                </tr>                                    
                                <tr>
                                    <td class="style2" width="100px"> 
                                        Color:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:DropDownList ID="ddlColor" runat="server" width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3" >
                                    <asp:CustomValidator ID="cvColor" runat="server" ErrorMessage="*" ControlToValidate="ddlColor" ForeColor="Red" 
                                            onservervalidate="cvColor_ServerValidate"></asp:CustomValidator></td>
                                </tr>
                                <tr>
                                    <td class="style2" width="100px" >
                                        Trato con animales:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:DropDownList ID="ddlTratoAnimales" runat="server" width="250px">                                            
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3" ></td>
                                </tr>
                                <tr>
                                    <td class="style2" width="100px">
                                        Trato con niños:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:DropDownList ID="ddlTratoNinios" runat="server" width="250px">
                                            
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3" ></td>
                                </tr>
                                <tr>
                                    <td class="style2" width="100px">
                                        Caracter:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:DropDownList ID="ddlCaracter" runat="server" width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3" ></td>
                                </tr>
                                <tr>
                                    <td class="style2" width="100px">
                                        Observaciones:&nbsp
                                    </td>
                                    <td class="style1" width="250px" >
                                        <asp:TextBox ID="txtObservaciones" runat="server" width="250px"></asp:TextBox>
                                    </td>
                                    <td class="style3" ></td>
                                </tr>
                                <tr>
                                    <td class="style2" width="100px">
                                        Alimentacion especial:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:TextBox ID="txtAlimentacionEspecial" runat="server" width="250px"></asp:TextBox>
                                    </td>
                                    <td class="style3" ></td>
                                </tr>
                                <tr>
                                    <td class="style2" width="100px" >
                                        Sexo:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                        <asp:DropDownList ID="ddlSexo" runat="server" width="250px">
                                                
                                        </asp:DropDownList>
                                    </td>
                                        <td class="style3" >
                                    <asp:CustomValidator ID="cvDdlSexo" runat="server" ErrorMessage="*" ControlToValidate="ddlSexo" ForeColor="Red" 
                                            onservervalidate="cvDdlSexo_ServerValidate"></asp:CustomValidator></td>
                                    
                                </tr>
                                <tr>
                                    <td class="style2" width="100px">
                                        Fecha Nac.:&nbsp
                                    </td>
                                    <td class="style1" width="250px">
                                            <asp:TextBox ID="txtFecha" runat="server"  Width="90%" />
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/calendario_dw/calendario.png" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" 
                                                runat="server" TargetControlID="txtFecha" 
                                                PopupButtonID="Image1">
                                            </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td class="style3" ></td>
                                </tr>
                                </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlFoto" runat="server">
                            <table>
                             <tr>
                                <td class="style2" width="100px">
                                    Foto:&nbsp
                                </td>
                                <td class="style1" width="250px">
                                    <input type="file" runat="server"  id="fuImagen"  onchange="showimagepreview(this,'imgprvw')" />
                                </td>
                                <td class="style3" ></td>
                            </tr>
                            <tr>
                                <td class="style2" width="100px">
    
                                </td>
                                <td class="style1" width="250px">
                                    <img id="imgprvw" width="250px" height="170px" hidden /> 
                                </td>
                                <td class="style3" ></td>
                            </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Panel ID="pnlBtnRegistrar" runat="server">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" 
                                                 onclick="btnRegistrar_Click" />
                                        </asp:Panel>
                                    </td>                                    
                                </tr>
                            </table>
                        </asp:Panel>
                </div>
        </div>
    </div>
    </div><div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
</div>
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
</asp:Content>
