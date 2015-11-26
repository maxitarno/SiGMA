<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModerarPedidosDifusion.aspx.cs" Inherits="SiGMA.ModerarPedidosDifusion" %>
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
    <style type="text/css">
        .GridView1 td
        {
            padding: 2px;
            border: 1px solid #c1c1c1;
            color: #717171;
        }
        .GridView1 th
        {
            padding: 2px 4px;
            color: #fff;
            background-color: green;
            border-left: solid 1px #525252;
            font-size:0.9em;
        }
        .GridView1 .alt
        {
            background-color: #EFEFEF;
        }
       
     .hidden
     {
         display:none;
     }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="centered">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">
                Moderar Pedidos de Difusion</h3>
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
                 <asp:Panel ID="pnlPedidos" runat="server">
                <div style="margin-left:20%">
                    <asp:GridView ID="grvPedidos" runat="server" CssClass="GridView1" 
                        AutoGenerateColumns="False" onrowcommand="grvPedidos_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderText="Fecha" />
                            <asp:BoundField DataField="user.user" HeaderText="Usuario" />
                            <asp:BoundField DataField="idPedidoDifusion" HeaderText="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="campaña.idCampaña" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="hallazgo.idHallazgo" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="perdida.idPerdida" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="mascota.idMascota" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:ButtonField ButtonType="Button" Text="+"/>
                        </Columns>
                    </asp:GridView>                     
                    </div>
                    <asp:Label ID="lblNoPedidos" runat="server" visible="false" Text = "No hay pedidos para moderar"></asp:Label>
            </asp:Panel>                               
                <asp:Panel ID="pnlDatos" runat="server" Visible="false">
                <div style="margin-left: 30%; display: table; width: 60%;">  
                    <div style="display: table-row; width: 30%;">     
                            <asp:Panel ID="pnlCampaña" runat="server">
                            <table>
                            <tr><td></td>
                            <td >
                            <img id="imgprvw" style="border: 2px solid #000000; height: 135px; width: 215px;"
                                    runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg"/>
                                    </td>
                                    </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="lblDatos" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                    </div>
                        <div style="display: table-row; width: 30%">  
                            <asp:Panel ID="pnlResolucion" runat="server" Visible="true">
                                <table>
                                    <tr>
                                        <td align="right">
                                           <asp:DropDownList ID="ddlResolucion" runat="server" 
                                                AppendDataBoundItems="true" 
                                                onselectedindexchanged="ddlResolucion_SelectedIndexChanged" 
                                                AutoPostBack="True">
                                               <asp:ListItem Selected="True">Publicar</asp:ListItem>
                                               <asp:ListItem>Rechazar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td><td> <asp:Label ID="lblRechazo" runat="server" Text="Motivo de rechazo:" Visible="false"></asp:Label>
                                         </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRechazo" runat="server" Visible="false" Enabled="false" Height="58px" 
                                                MaxLength="100" TextMode="MultiLine" Width="190px"></asp:TextBox>
                                            <asp:CustomValidator ID="cvRechazo" runat="server" ErrorMessage="*" 
                                                ForeColor="Red" onservervalidate="cvRechazo_ServerValidate"
                                            ></asp:CustomValidator></td>   
                                    </tr>                                        
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnAceptar" runat="server" style="margin-left: 12%" 
                                                    Text="Aceptar" onclick="btnAceptar_Click"  />
                                            </td>                                            
                                        </tr>                                    
                                </table>
                            </asp:Panel>            
                        </div>  
                        </div>                         
                        </asp:Panel>                       
                        </div>   
        </div>
    </div> 
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" 
            ImageUrl="~/imagenes/volver.png"
            CausesValidation="False"/>
        </br>
        Volver
    </div>  
</asp:Content>

