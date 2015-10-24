<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarHallazgo.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="SiGMA.ConsultarHallazgo" Culture="Auto" UICulture="Auto"%>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="centered">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">
                <asp:Label ID="lblTitulo"  runat="server" Text="Label"></asp:Label></h3>
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
        <asp:Panel ID="pnlFiltros" runat="server" Visible="true">
            <div style="margin-left: 30%; display: table; width: 40%;">   
                <div style="display: table-row; width: 30%">
                 <div style="display: table-cell; width: 20%; vertical-align: top;">                    
                    <table>
                    <tr>
                    <td colspan="2" align="left"><asp:Label ID="lblFiltros" runat="server" Text="Filtrar mascotas perdidas"></asp:Label></td>                    
                    </tr>
                    <tr>
                    <td>Especie:</td> <td> <asp:DropDownList ID="ddlFiltroEspecie" Width="100%" AutoPostBack="true" 
                            runat="server" onselectedindexchanged="ddlFiltroEspecie_SelectedIndexChanged">
                        </asp:DropDownList></td>                       
                    </tr>
                        <tr>
                        <td>
                        Raza:</td> <td> <asp:DropDownList ID="ddlFiltroRaza" Width="100%" runat="server">
                        </asp:DropDownList>
                        </td>                        
                        </tr>
                        <tr><td>
                        Sexo: </td> <td><asp:DropDownList ID="ddlFiltroSexo" Width="100%" runat="server">
                        </asp:DropDownList>
                        </td>                            
                        </tr>
                        <tr>
                        <td>
                        Color: </td> <td><asp:DropDownList ID="ddlFiltroColor" Width="100%" runat="server">
                        </asp:DropDownList></td>   
                                                   
                        </tr> 
                        <tr>
                        <td><asp:Button ID="btnFiltros" runat="server" Text="Buscar" 
                                onclick="btnFiltros_Click" CausesValidation="False" />
                        </td></tr>                              
                    </table>
                    </div>  
                <div style="display: table-cell; width: 20%;">
                    <asp:ListBox ID="lstPerdidas" runat="server" AutoPostBack="true" 
                        OnSelectedIndexChanged="lstPerdidas_SelectedIndexChanged" Visible="False">
                        </asp:ListBox>
                    </div>         
                </div>
                
                </div>
                 </asp:Panel> 
                                                
                <asp:Panel ID="pnlMascotaSeleccionada" runat="server" Visible="false">
                <div style="margin-left: 20%; display: table; width: 60%;">                
                
                    <div style="display: table-row; width: 30%;">     
                        <div style="display: table-cell; width: 30%;">
                        Datos de la mascota
                            <asp:Panel Visible="true" runat="server" ID="pnlImagen">
                                <img id="imgprvw" style="border: 2px solid #000000; height: 135px; width: 215px;"
                                    runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg"/>
                            </asp:Panel> 
                            <asp:Panel ID="pnlHallazgoPerdidaMascota" runat="server" Visible="true">
                                <table>
                                    <tr>
                                        <td>
                                            Nombre:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNombreMascota" runat="server" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Especie:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" 
                                                AutoPostBack="true" Enabled="false" AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Raza:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
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
                                        <td>
                                           </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Color:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlColor" Enabled="False" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            </td>
                                        </tr>                                                        
                                </table>
                            </asp:Panel>                           
                        </div>
                        <div style="display: table-cell; width: 35%; vertical-align: top;">                        
                            <div class="col-md-offset-1" style="width: 120%; padding-right: 1%; ">
                            Datos del hallazgo
                                <table>
                                    <tr>
                                        <td>
                                            Localidad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidades" Enabled="true" runat="server" Width="100%" AppendDataBoundItems="False"
                                                OnSelectedIndexChanged="ddlLocalidades_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Domicilio:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCalles" Enabled="true" runat="server" Width="70%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            -
                                            <asp:TextBox ID="txtNroCalle" runat="server" Width="23%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:CustomValidator ID="cvCalleNumero" runat="server" ErrorMessage="Solo numeros"
                                                ForeColor="Red" OnServerValidate="cvCalleNumero_ServerValidate"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Barrio:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBarrios" Enabled="true" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha del Hallazgo:
                                        </td>
                                        <td>
                                          <asp:TextBox ID="txtFecha" runat="server"  Width="90%" />
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/calendario_dw/calendario.png" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" 
                                                    runat="server" TargetControlID="txtFecha" 
                                                    PopupButtonID="Image1">
                                                </ajaxToolkit:CalendarExtender>
                                        </td>--%>
                                        <td>
                                            <%--<asp:RequiredFieldValidator ID="rfvFecha" runat="server" ErrorMessage="*" ForeColor="Red"
                                                ControlToValidate="txtFecha"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Lugar:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMapa" runat="server" Width="100%" Text="Acá iría el mapa con el punto donde se hallo"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Comentarios:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtComentarios" runat="server" Style="resize: none" TextMode="MultiLine"
                                                Rows="7" Columns="30" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnModificarHallazgo" runat="server" Text="Modificar"
                                                OnClick="btnModificarHallazgo_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>                                    
                                </table>
                                </div>
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
            ImageUrl="~/imagenes/volver.png" onclick="ibtnRegresar_Click" CausesValidation="false"/>
        </br>
        Volver
    </div>     
</asp:Content>