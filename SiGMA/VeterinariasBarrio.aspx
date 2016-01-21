<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="VeterinariasBarrio.aspx.cs" Inherits="SiGMA.VeterinariasBarrio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCN_PNx9ZJT_kk219eY1fF0Jt9J8JTrDkw"></script>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Scripts/jsapi.js"></script>
    <style type="text/css">
      html, body { height: 100%; margin: 0; padding: 0; }
      #map { height: 100%; }
    </style>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
                    <img src="assets/img/menu/veterinariasMini.png" />
                    <h1>Veterinarias /</h1>
                    <p>Cuide a su mascota</p>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-4 col-md-offset-4">
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible=false>
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="contact-us-container">
        <div class="container">
	        <div class="row">
	            <div class="col-sm-7 contact-form wow fadeInLeft">
	                <p>
	                   Aquí usted puede consultar las veterinarias que se encuentran en su barrio o el que desee. 
                       Ante cualquier comportamiento extraño de su mascota, no duda en consultar a una veterinaria.
	                </p>
                    <div class="form-group">
	                    	<label for="contact-name">Seleccione un barrio</label>
	                        <asp:DropDownList ID="ddlBarrio" runat="server" 
                            onselectedindexchanged="ddlBarrio_SelectedIndexChanged" 
                            AutoPostBack="True" Width="100%"> </asp:DropDownList>
	                </div>
	                <input id="btnUbicacion" type="button" value="Mostrar veterinarias" style="width:180px"/>
                </div>
	            <div class="col-sm-5 contact-address wow fadeInUp">
	                <img src="base/img/portfolio/veterinariasBarrio.png" />
	            </div>
	        </div>
	    </div>
    </div>
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
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
    <asp:HiddenField ID="hfTipos" runat="server" />
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
        var tipos;
        var acomodar = [];
        var anexar = "";
        var w = 0;
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
            tipos = document.getElementById('<%=hfTipos.ClientID%>').value.toString().split(",");
            len = direcciones.length;
            //            marcadores = null;
            for (; j < len; j++) {
                acomodar = tipos[j].toString().split("-");
                for (; w < acomodar.length; w++) {
                    anexar += "<BR>" + acomodar[w].toString();
                }
                aux = "<div><p><h5>nombre: " + nombres[j].toString() + "</br>telefono: " + telefonos[j].toString() + "</br>contacto: " + contactos[j] + "<BR>Servicios: " + anexar + "</h5></p></div>";
                anexar = "";
                w = 0;
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

