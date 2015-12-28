<%@ Page Title="Difusion" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DifusionDueño.aspx.cs" Inherits="SiGMA.DifusionDueño" %>
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
        <table style="margin-left: 42%">
        <tr><td>
            <h3 class="panel-title">
                Mis Pedidos de Difusion
            </h3>
            </td>
            <td>
            <div style="margin-left: 210%">
        <asp:Button ID="btnRegCampaña" 
                    runat="server" Text="Registrar Campaña" onclick="btnRegCampaña_Click" />

        </div>
        </td>
        </tr>
        </table>
        </div>
        
        <div class="panel-body">          
                <div class="col-md-4 col-md-offset-4">
                 <asp:Panel ID="pnlPedidos" runat="server">
                <div >
                    <asp:GridView ID="grvPedidos" runat="server"
                        AutoGenerateColumns="False" AllowSorting="True" 
                        onsorting="grvPedidos_Sorting" Width="520px">
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                            <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderText="Fecha" SortExpression="fecha" />  
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo" />                                                      
                            <asp:BoundField DataField="estado.nombreEstado" HeaderText="Estado" 
                                SortExpression="estado.nombreEstado" />
                            <asp:BoundField DataField="motivoRechazo" HeaderText="Motivo Rechazo" 
                                SortExpression="motivoRechazo" NullDisplayText="-" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>                                      
                    </div>
                    <asp:Label ID="lblNoPedidos" runat="server" visible="false" Text = "Usted no ha generado pedidos todavia."></asp:Label>
            </asp:Panel>                               
                <asp:Panel ID="pnlDatos" runat="server" Visible="false">
                <div style="margin-left: 30%; display: table; width: 60%;">  
                    <div style="display: table-row; width: 30%;"> 
                    </div>
                        <div style="display: table-row; width: 30%">  
                            
                        </div>  
                        </div>                         
                        </asp:Panel>                       
                        </div>  
                        </div> 
        </div>
    </div> 
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" 
            ImageUrl="~/imagenes/volver.png"
            CausesValidation="False" onclick="ibtnRegresar_Click"/>
        </br>
        Volver
    </div> 
</asp:Content>

