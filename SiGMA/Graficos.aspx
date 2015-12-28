<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Graficos.aspx.cs" Inherits="SiGMA.Graficos" MasterPageFile="~/PaginaMaestra.Master" Culture="Auto"
    UICulture="Auto" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
     <script type="text/javascript">

         // Load the Visualization API and the piechart package.
         google.load('visualization', '1.0', { 'packages': ['corechart'] });

         // Set a callback to run when the Google Visualization API is loaded.
         google.setOnLoadCallback(mostrarTiposDeUsuarios);

         // Callback that creates and populates a data table, 
         // instantiates the pie chart, passes in the data and
         // draws it.
         function drawChartTipoDeUsuarios() {
             var hogar = document.getElementById("<%=hfHogar.ClientID%>").value.toString();
             var busqueda = document.getElementById("<%=hfBusqueda.ClientID%>").value.toString();
             var ambos = document.getElementById("<%=hfAmbos.ClientID%>").value.toString();
             var no = document.getElementById("<%=hfNo.ClientID%>").value.toString();
             var total = hogar + busqueda + ambos + no;
             // Create the data table.
             var dataTiposDeUsuarios = google.visualization.arrayToDataTable([
             ['Categoria', 'Cantidad', { role: 'style'}],
        ['Hogar', parseInt(hogar), '#0000ff'],
        ['Busqueda', parseInt(busqueda), '#ffff00'],
        ['Ambos', parseInt(ambos), '#7f00ff'],
        ['No es voluntario', parseInt(no), '#00ffff'],
        ['Total de usuarios', parseInt(total), '#66ccff']
      ]);

             // Set chart options
             var optionsTiposDeUsuarios = { 'title': 'Tipos de voluntarios',
                 'width': 800,
                 'height': 800
             };

             // Instantiate and draw our chart, passing in some options.
             var chartTiposDeUsuarios = new google.visualization.BarChart(document.getElementById('grafico'));
             chartTiposDeUsuarios.draw(dataTiposDeUsuarios, optionsTiposDeUsuarios);
         }
         function mostrarTiposDeUsuarios() {
             $("#btnGrafico").click(function () {
                 drawChartTipoDeUsuarios();
             });
         }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="panel panel-default">
            <div class="panel panel-default">
                <div class="centered">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            Graficos</h3>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-md-4 col-md-offset-4">
                        <asp:Panel runat="server" ID="pnlCorrecto" class="alert alert-dismissable alert-success"
                            Visible="false">
                            <button class="close" type="button" data-dismiss="alert">
                                ×</button>
                            <asp:Label ID="lblResultado1" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlInfo" class="alert alert-dismissable alert-info"
                            Visible="false">
                            <button class="close" type="button" data-dismiss="alert">
                                ×</button>
                            <asp:Label ID="lblResultado2" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlAtento" class="alert alert-dismissable alert-danger"
                            Visible="false">
                            <button class="close" type="button" data-dismiss="alert">
                                ×</button>
                            <asp:Label ID="lblResultado3" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="col-md-2 col-md-offset-5">
                            <asp:DropDownList ID="ddlListado" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlListado_SelectedIndexChanged">
                                <asp:ListItem Text="SIN ASIGNAR" Value="0"></asp:ListItem>
                                <asp:ListItem Text="tipos de usuarios" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div id="grafico"></div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-1 col-md-offset-1">
                            <input id="btnGrafico" type="button" value="Mostrar" />
                        </div>
                    </div>
                    <div class="col-md-12">
                    
                    </div>
                </div>
            </div>
      </div>
    <asp:HiddenField ID="hfHogar" runat="server" />
    <asp:HiddenField ID="hfNo" runat="server" />
    <asp:HiddenField ID="hfAmbos" runat="server" />
    <asp:HiddenField ID="hfBusqueda" runat="server" />
     <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
</asp:Content>
