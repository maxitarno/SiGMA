<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" 
CodeBehind="RegistrarHogarProvisorio.aspx.cs" Inherits="SiGMA.RegistrarHogarProvisorio" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="centered">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">
                Registrar Hogar Provisorio</h3>
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
                <asp:Panel ID="pnlDatosHogar" runat="server" Visible="true">
                <div style="margin-left: 28%; display: table; width: 60%;">  
                    <div style="display: table-row; width: 30%;">     
                        <div style="display: table-cell; width: 30%;">                       
                            <asp:Panel ID="pnlHallazgoPerdidaMascota" runat="server" Visible="true">
                                <table>
                                <tr>
                                        <td align="right">
                                            Especie:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" 
                                               Enabled="true" AppendDataBoundItems="true" 
                                                >
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:CustomValidator ID="cvEspecie" runat="server" ErrorMessage="*" 
                                                ForeColor="Red" onservervalidate="cvEspecie_ServerValidate"></asp:CustomValidator></td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Cantidad de Mascotas:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCantMascotas" runat="server" Enabled="true" Width="100%" 
                                                TextMode="Number"></asp:TextBox>
                                        </td>
                                        <td>
                                        <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ErrorMessage="*" 
                                                ControlToValidate="txtCantMascotas" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                            <asp:RangeValidator ID="rgvCantidad" runat="server" 
                                                ControlToValidate="txtCantMascotas" ErrorMessage="Debe ser mayor a cero" ForeColor="Red" 
                                                MinimumValue="1" MaximumValue="null"></asp:RangeValidator>
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td align="right">
                                            Tamaño de Perros:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTamañoPerro" Enabled="true" runat="server" Width="100%">
                                                <asp:ListItem Selected="True" Value="0">SIN ASIGNAR</asp:ListItem>
                                                <asp:ListItem Value="1">Pequeño</asp:ListItem>
                                                <asp:ListItem Value="2">Grande</asp:ListItem>
                                                <asp:ListItem Value="3">Mediano</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:CustomValidator ID="cvTamaño" runat="server" ErrorMessage="*" 
                                                ForeColor="Red" onservervalidate="cvTamaño_ServerValidate"></asp:CustomValidator></td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            ¿Tiene niños?:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlNiños" Enabled="true" runat="server" Width="100%" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="0">SIN ASIGNAR</asp:ListItem>
                                                <asp:ListItem>Si</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:CustomValidator ID="cvNiños" runat="server" ErrorMessage="*" 
                                                ForeColor="Red" onservervalidate="cvNiños_ServerValidate"></asp:CustomValidator></td>
                                        </tr>                                                                                                   
                                </table>
                            </asp:Panel>
                        </div>                        
                    </div>
                        </div>
                        <div class="centered"> 
                           <asp:Button ID="btnRegistrarHogar" runat="server" Text="Registrar" onclick="btnRegistrarHogar_Click"
                                                 />      
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
</asp:Content>

