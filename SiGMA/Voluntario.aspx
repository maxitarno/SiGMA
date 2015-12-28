<%@ Page Title="SIGMA" Language="C#" MasterPageFile="~/PaginaBase.Master" AutoEventWireup="true" CodeBehind="Voluntario.aspx.cs" Inherits="SiGMA.Voluntario"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--agregado-->
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCN_PNx9ZJT_kk219eY1fF0Jt9J8JTrDkw"></script>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Scripts/jsapi.js"></script>
    <!--Estilo del mapa-->
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
	                <img src="assets/img/menu/voluntariosMini.png" />
                    <h1>Voluntario /</h1>
                    <p>Recuerde que ser voluntario implica compromiso y responsabilidad</p>
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
    <div class="services-half-width-container">
        <div class="container">
	        <div class="row">
	            <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                    <div class="contact-form">
	                    <div class="form-group">
                            <label for="contact-name">¿Desear solicitar cambio de voluntariado?</label>
                            <asp:DropDownList ID="ddlTipoVoluntario" runat="server" 
                                AppendDataBoundItems="true" Width="100%"
                                onselectedindexchanged="ddlTipoVoluntario_SelectedIndexChanged" > 
                                <asp:listitem value ="0"> -- Seleccione -- </asp:listitem>
                                <asp:listitem value ="1" Text="Hogar"></asp:listitem>
                                <asp:listitem value ="2" Text="Busqueda"></asp:listitem>
                                <asp:listitem value ="3" Text="Ambos"></asp:listitem>
                            </asp:DropDownList>
                            <asp:Button ID="btnCambioVoluntariado" runat="server" 
                                Text="Solicitar Voluntariado" onclick="btnCambioVoluntariado_Click" Width="180px"/>
                        </div>
                        <asp:Panel ID="pnlDejarDeSer" runat="server" Visible="false">
	                        <div class="form-group">
                                <label for="contact-name">¿Desear dejar de ser voluntario?</label><br />
                                <asp:Button ID="btnDejarVoluntariado" runat="server" Text="Dejar de serlo" 
                                onclick="btnDejarVoluntariado_Click" CausesValidation="false" Width="180px"/>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                                <label for="contact-name">Voluntario</label>
                                <asp:TextBox ID="txtNombre" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        <div class="form-group">
                            <label for="contact-name">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Ingrese su email" 
                                        ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                                ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator> 
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlHogar" runat="server" Visible="false">
        <div class="services-half-width-container">
            <div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
	                        <div class="form-group">
                                <label for="contact-name">Tipo de hogar</label>
                                <asp:DropDownList ID="ddlTipoHogar" runat="server" Width="100%" AppendDataBoundItems="True">
                                <asp:listitem value ="1" Text="Sin Patio"></asp:listitem>
                                <asp:listitem value ="2" Text="Con Patio Chico"></asp:listitem>
                                <asp:listitem value ="3" Text="Con Patio Grande"></asp:listitem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Barrio</label>
                                <asp:DropDownList ID="ddlBarrio" runat="server" Width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="cvBarrio" runat="server" 
                                    ErrorMessage="Seleccione un barrio" ForeColor="Red"
                                ControlToValidate="ddlBarrio" onservervalidate="cvBarrio_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Calle</label>
                                <asp:DropDownList ID="ddlCalle" Enabled="true" runat="server" Width="100%"></asp:DropDownList>
                                <asp:CustomValidator ID="cvCalle" runat="server" 
                                ErrorMessage="Seleccione una calle" ForeColor="Red"
                                ControlToValidate="ddlCalle" onservervalidate="cvCalle_ServerValidate"></asp:CustomValidator>
                            </div>
                             <div class="form-group">
                                <label for="contact-name">Numeración de calle/dpto</label>
                                <asp:TextBox ID="txtNro" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNroCalle" runat="server" ErrorMessage="Ingrese su numeración de calle/dpto" ForeColor="Red"
                                        ControlToValidate="txtNro" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Acepto hasta</label>
                                <asp:DropDownList ID="ddlNumeroMascotas" runat="server" Width="100%" AppendDataBoundItems="True">
                                <asp:listitem value ="1" Text="1 Mascota Provisoria"></asp:listitem>
                                <asp:listitem value ="2" Text="2 Mascotas Provisorias"></asp:listitem>
                                <asp:listitem value ="3" Text="3 Mascotas Provisorias"></asp:listitem>
                                <asp:listitem value ="4" Text="4 Mascotas Provisorias"></asp:listitem>
                                </asp:DropDownList>
                             </div>
                             <div class="form-group">
                                <label for="contact-name">Especie de mascota</label>
                                <asp:DropDownList ID="ddlTipoMascota" runat="server" Width="100%" AppendDataBoundItems="True">
                                <asp:listitem value ="1" Text="Solo Perros"></asp:listitem>
                                <asp:listitem value ="2" Text="Solo Gatos"></asp:listitem>
                                <asp:listitem value ="3" Text="Perros y Gatos"></asp:listitem>
                                </asp:DropDownList>
                             </div>
                             <div class="form-group">
                                 <label for="contact-name">¿Tiene niños en el hogar?</label>
                                 <asp:DropDownList ID="ddlTieneNinios" runat="server" Width="100%">
                                    <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                 </asp:DropDownList>
                             </div>
                             <asp:Button ID="btnActualizarHogar" Width="180px" runat="server" Text="Actualizar Hogar" onclick="btnActualizarHogar_Click"/>
                        </div>
                    </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
	                        <div class="form-group">
                                <label for="contact-name">Mis mascotas provisorias</label>
                                <asp:DropDownList ID="ddlMascotasEnHogar" runat="server" onselectedindexchanged="ddlMascotasEnHogar_SelectedIndexChanged" 
                                AutoPostBack="True" Width="100%"> </asp:DropDownList>
                            </div>
                            <asp:Panel ID="pnlMisProvisorias" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Mascota</label>
                                    <td align="left"><asp:TextBox ID="txtMascotaHogar" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Sexo</label>
                                    <asp:TextBox ID="txtSexoHogar" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Especie</label>
                                    <asp:DropDownList ID="ddlEspecieHogar" runat="server" AppendDataBoundItems="true" Width="100%" Enabled="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                    <asp:DropDownList ID="ddlRazaHogar" runat="server" Width="100%" AppendDataBoundItems="true" Enabled="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">¿No puede seguir cuidando a su mascota provisoria?</label>
                                    <asp:Button ID="btnSolicitarDevolucion" Width="180px" runat="server" Text="Solicitar Devolución" onclick="btnSolicitarDevolucion_Click"/>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlSinProvisorias" runat="server" Visible="false">
                                <img src="base/img/portfolio/sinProvisorias.png" />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlBusqueda" runat="server" Visible="false">
        <div class="services-half-width-container">
            <div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
	                        <div class="form-group">
                                <label for="contact-name">Disponibilidad horaria para patrullas de busqueda</label>
                                <asp:DropDownList ID="ddlDisponibilidadHoraria" runat="server" Width="100%" AppendDataBoundItems="True">
                                    <asp:listitem value ="1" Text="Por la mañana"></asp:listitem>
                                    <asp:listitem value ="2" Text="Por la tarde"></asp:listitem>
                                    <asp:listitem value ="3" Text="Por la noche"></asp:listitem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Barrio a patrullar</label>
                                <asp:DropDownList ID="ddlBarrioBusqueda" runat="server" 
                                    Width="100%" AppendDataBoundItems="True" onselectedindexchanged="ddlBarrioBusqueda_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="cvBarrioBusqueda" runat="server" 
                                    ErrorMessage="Seleccione un barrio" ForeColor="Red"
                                ControlToValidate="ddlBarrioBusqueda" 
                                        onservervalidate="cvBarrioBusqueda_ServerValidate"></asp:CustomValidator>
                            </div>
                            <asp:Button ID="btnActualizarBusqueda" runat="server" 
                                    Text="Actualizar Datos" onclick="btnActualizarBusqueda_Click"/>
                            <br />
                            <div class="form-group">
                                <label for="contact-name">Mascotas perdidas en el barrio</label>
                                <asp:DropDownList ID="ddlBusquedasMascota" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlBusquedasMascota_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                                <input id="btnUbicacion1" type="button" value="Ver todas en mapa" style="width:180px"/>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlMisBusquedas" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Nombre mascota</label>
                                    <asp:TextBox ID="txtMascotaPerdida" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Especie</label>
                                     <asp:DropDownList ID="ddlEspeciePerdida" runat="server" AppendDataBoundItems="true" Width="100%" Enabled="false"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                     <asp:DropDownList ID="ddlRazaPerdida" runat="server" Width="100%" AppendDataBoundItems="true" Enabled="false"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Ver lugar de pérdida</label><br />
                                    <input id="btnUbicacion" type="button" value="Ubicación" style="width:180px"/>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">¿Quisiera ver mas detalles de la mascota perdida?</label><br />
                                    <asp:Button ID="btnSolicitarDetallesPerdida" runat="server" Width="180px"
                                        Text="Ver Detalles Perdida" onclick="btnSolicitarDetallesPerdida_Click"/>
                                </div>
                            </asp:Panel>    
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>         
    <asp:HiddenField ID="hfDirecciones" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hfNombres" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hfCuidados" runat="server"></asp:HiddenField>
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                        Busquedas</h4>
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
    <asp:HiddenField ID="hfdirecciones1" runat="server" />
    <asp:HiddenField ID="hfnombres1" runat="server" />
    <asp:HiddenField ID="hfcuidados1" runat="server" />

    <script type="text/javascript">
    //para varios barrios
        //variables
        var map;
        var marcador = new google.maps.Marker();
        var marcadores = [];
        var geocoder = new google.maps.Geocoder();
        var latlong;
        var opciones;
        var i = 0;
        var len = 0;
        var imagen;
        var infowindows;
        var direcciones = [];
        var nombres = [];
        var cuidados = [];
        var j = 0;
        var bounds;
        var map1;
//        var marker;
        //var geocoder1;
        //metodo de inicio
        function initMap() {
//            map = null;
            map = new google.maps.Map(document.getElementById("map"), {
                center: { lat: -31.4080027, lng: -64.18063840000002 },
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            bounds = new google.maps.LatLngBounds();
            infowindows = new google.maps.InfoWindow();
            direcciones = document.getElementById('<%=hfDirecciones.ClientID%>').value.toString().split(","); //(getURLParameter("direccion") == null) ? "" : getURLParameter("direccion").toString().split(",");
            nombres = document.getElementById('<%=hfNombres.ClientID%>').value.toString().split(",");// (getURLParameter("nombre") == null) ? "" : getURLParameter("nombre").toString().split(",");
            cuidados = document.getElementById('<%=hfCuidados.ClientID%>').value.toString().split(",");// (getURLParameter("cuidado") == null) ? "" : getURLParameter("cuidado").toString().split(",");
            len = direcciones.length;
//            marcadores = null;
            for (; j < len; j++) {
                var aux = "<div><p><h3>nombre: " + nombres[j].toString() + "</br>dirección: " + direcciones[j].toString() + "</h3></p></div>";
                geocoderAdress(("argentina "+ direcciones[j].toString()), aux), cuidados[j];
            }
            len = marcadores.length;
            for (; i < len; i++) {
                marcadores[i].setMap(map);
            };
        }

        //funciones

        //funcion de geocodificacion
        function geocoderAdress(direccion, datos, cuidado) {
            geocoder.geocode({ 'address': direccion }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    (function (marcador, datos) {
                        map.setCenter(results[0].geometry.location);
//                        marcador = null;
                        marcador = new google.maps.Marker({
                            position: results[0].geometry.location,
                            map: map,
                            icon: "./imagenes/registrarperdida (34x35).jpg"
                        });
                        marcador.addListener('click', function () {
                            infowindows.setContent(datos);
                            infowindows.open(map, marcador);
                        });
                        var cityCircle = new google.maps.Circle({
                            strokeColor: '#FF0000',
                            strokeOpacity: 0.8,
                            strokeWeight: 2,
                            fillColor: '#FF0000',
                            fillOpacity: 0.35,
                            map: map,
                            center: results[0].geometry.location,
                            radius: Math.sqrt(cuidado) * 100
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
        //para varios barrios
        //para uno
        var infowindow;
        function initialize() {
            var mapProp = {
                center: { lat: -31.4080027, lng: -64.18063840000002 },
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            infowindow1 = new google.maps.InfoWindow();
//            map1 = null;
            map1 = new google.maps.Map(document.getElementById("map"), mapProp);
            geocodeAddress1(geocoder, map1);
        }
        function geocodeAddress1(geocoder1, resultsMap) {
            //function getURLParameter(name) { return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null }
            var cuidado1 = document.getElementById('<%=hfcuidados1.ClientID%>').value.toString();// (getURLParameter("cuidado") == null) ? "" : getURLParameter("cuidado");
            var direccion1 = document.getElementById('<%=hfdirecciones1.ClientID%>').value.toString();// (getURLParameter("direccion") == null) ? "" : getURLParameter("direccion");
            var nombre1 = document.getElementById('<%=hfnombres1.ClientID%>').value.toString();//(getURLParameter("nombre") == null) ? "" : getURLParameter("nombre");
            var texto = "<div><p><h3>nombre: " + nombre1 + "<br>direccion: " + direccion1 + "</h3></p></div>";
            var address =  "argentina" + direccion1;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    resultsMap.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        map: resultsMap,
                        position: results[0].geometry.location,
                        animation: google.maps.Animation.DROP,
                        icon: "./imagenes/registrarperdida (34x35).jpg"
                    });
                    marker.addListener('click', function () {
                        infowindow1.setContent(texto);
                        infowindow1.open(resultsMap, marker);
                    });
                    var cityCircle = new google.maps.Circle({
                        strokeColor: '#FF0000',
                        strokeOpacity: 0.8,
                        strokeWeight: 2,
                        fillColor: '#FF0000',
                        fillOpacity: 0.35,
                        map: resultsMap,
                        center: results[0].geometry.location,
                        radius: Math.sqrt(cuidado1) * 100
                    });
                } else {
                    alert('La dirección especificada no se encontro ');
                }
            });
        }
        //para uno
        $("#btnUbicacion1").click(function () {
            if (document.getElementById('<%=hfDirecciones.ClientID%>').value.toString() != "") {
                $("#myModal").modal("show");
                $("#myModal").on('shown.bs.modal', function () {
//                    map1 = null;
//                    marker = null;
                    initMap();
                });
            }
            else {
                alert('No se encontraron veterinarias para ese barrio');
            }
        });
        $("#btnUbicacion").click(function () {
            if (document.getElementById('<%=hfdirecciones1.ClientID%>').value.toString() != "") {
                $("#myModal").modal("show");
                $("#myModal").on('shown.bs.modal', function () {
//                    map = null;
//                    marcadores = null;
//                    marcador = null;
                    initialize();
                });
            }
            else {
                alert('No se encontraron veterinarias para ese barrio');
            }
        });
    </script>
</asp:Content>


