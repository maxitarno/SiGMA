<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VeterinariasBarrio.aspx.cs" Inherits="SiGMA.VeterinariasBarrio" %>
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
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCN_PNx9ZJT_kk219eY1fF0Jt9J8JTrDkw"></script>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Scripts/jsapi.js"></script>
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="assets/js/hover.zoom.js"></script>
    <script src="assets/js/hover.zoom.conf.js"></script>
    <style type="text/css">
      html, body { height: 100%; margin: 0; padding: 0; }
      #map { height: 100%; }
    </style>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h3 class="panel-title">
                Contacto</h3>
            </div>

            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-5 col-md-offset-5">
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

            <div class="panel-body">
                <div>
                    <div class="col-md-4 col-md-offset-4">
                        <asp:DropDownList ID="ddlBarrio" runat="server" 
                            onselectedindexchanged="ddlBarrio_SelectedIndexChanged" 
                            AutoPostBack="True">
                            
                        </asp:DropDownList>
                    </div>
                    <br />
                    <input id="btnUbicacion" class="centered" type="button" value="Mostrar veterinarias por barrio" />
                </div>
            </div>
        </div>
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
    </div>
        <!-- Modal -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                            Veterinarias por barrio</h4>
                    </div>
                    <div class="modal-body">
                        <div id="map" style="height:500px; width:500px">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Cerrar</button>
                    </div>
                </div>
            </div>
</div>
        <asp:HiddenField ID="hfdirecciones" runat="server" />
        <asp:HiddenField ID="hfnombres" runat="server" />
        <asp:HiddenField ID="hfcontactos" runat="server" />
        <asp:HiddenField ID="hftelefonos" runat="server" />
    
    <script type="text/javascript">
        //variables
        var bounds = new google.maps.LatLngBounds();
        var map;
        var marcador = new google.maps.Marker();
        var marcadores = [];
        var geocoder;
        var latlong;
        var opciones;
        var i = 0;
        var len = 0;
        var imagen;
        var infowindows;
        var direcciones = [];
        var nombres = [];
        var contactos = [];
        var telefonos = [];
        var j = 0;
        var aux;
        //metodo de inicio
        function initMap() {
//            map = null;
            map = new google.maps.Map(document.getElementById("map"), {
                center: { lat: -31.4080027, lng: -64.18063840000002 },
                zoom: 8,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            infowindows = new google.maps.InfoWindow();
            geocoder = new google.maps.Geocoder();
            direcciones = document.getElementById('<%=hfdirecciones.ClientID%>').value.toString().split(","); //getURLParameter("direccion").toString().split(",");
            nombres = document.getElementById('<%=hfnombres.ClientID%>').value.toString().split(","); //(getURLParameter("nombre") == null) ? "" : getURLParameter("nombre").toString().split(",");
            contactos = document.getElementById('<%=hfcontactos.ClientID%>').value.toString().split(","); //getURLParameter("contacto").toString().split(",");
            telefonos = document.getElementById('<%=hftelefonos.ClientID%>').value.toString().split(","); //(getURLParameter("telefono") == null) ? "" : getURLParameter("telefono").toString().split(",");
            len = direcciones.length;
//            marcadores = null;
            for (; j < len; j++) {
                aux = "<div><p><h3>nombre: " + nombres[j].toString() + "</br>telefono: " + telefonos[j].toString() + "</br>contacto: " + contactos + "</h3></p></div>";
                geocoderAdress(("argentina " + direcciones[j].toString()).toString(), aux);
            }
            len = marcadores.length;
            for (; i < len; i++) {
                marcadores[i].setMap(map);
            };
        }
        //funciones

        //funcion de geocodificacion
        function geocoderAdress(direccion, datos) {
            geocoder.geocode({ 'address': direccion }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    (function (marcador, datos) {
                        map.setCenter(results[0].geometry.location);
                        marcador = new google.maps.Marker({
                            position: results[0].geometry.location,
                            map: map,
                            icon: "./imagenes/veterinarias (35x35).jpg"
                        });
                        marcador.addListener('click', function () {
                            infowindows.setContent(datos);
                            infowindows.open(map, marcador);
                        });
                        bounds.extend(results[0].geometry.location);
                        map.fitBounds(bounds);
                    } (marcador, datos));
                    marcadores.push(marcador);
                }
                else {
                    alert('no se encontro la direccion');
                }
            });
        }

        //funcion de direccion
        function getURLParameter(name) { return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null }

        //eventos

        //google.maps.event.addDomListener(window, 'resize', initMap);
        $("#btnUbicacion").click(function () {
            if (document.getElementById('<%=hfdirecciones.ClientID%>').value.toString() != "") {
                $("#myModal").modal("show");
                $("#myModal").on('shown.bs.modal', function () {
                    initMap();
                });
            }
            else {
                alert('No se encontraron veterinarias en el barrio seleccionado');
            }
        });
    </script>
</asp:Content>

