<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Voluntario.aspx.cs" Inherits="SiGMA.Voluntario"%>
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
    <!--agregado-->
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCN_PNx9ZJT_kk219eY1fF0Jt9J8JTrDkw"></script>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Scripts/jsapi.js"></script>
    <!--agregado-->
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="assets/js/hover.zoom.js"></script>
    <script src="assets/js/hover.zoom.conf.js"></script>
    <!--Estilo del mapa-->
    <style type="text/css">
      html, body { height: 100%; margin: 0; padding: 0; }
      #map { height: 100%; }
    </style>f
    <!--Estilo del mapa-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h3 class="panel-title">
               Voluntario</h3>
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
            <div class="centered"><h4> Recuerde que ser voluntario implica compromiso y responsabilidad</h4> </div>
            <br />
            <div class="centered"><h5>¿Desear solicitar cambio de voluntariado?</h5></div>
            <asp:DropDownList class="dropdown" ID="ddlTipoVoluntario" runat="server" 
                AppendDataBoundItems="true" 
                onselectedindexchanged="ddlTipoVoluntario_SelectedIndexChanged" > 
                <asp:listitem value ="0"> -- Seleccione -- </asp:listitem>
                <asp:listitem value ="1" Text="Hogar"></asp:listitem>
                <asp:listitem value ="2" Text="Busqueda"></asp:listitem>
                <asp:listitem value ="3" Text="Ambos"></asp:listitem>
            </asp:DropDownList>
            <div class="centered"><asp:Button ID="btnCambioVoluntariado" runat="server" 
                    Text="Solicitar Voluntariado" onclick="btnCambioVoluntariado_Click" /></div>
            <br />
            <asp:Panel ID="pnlDejarDeSer" runat="server" Visible="false">
                <div class="centered"><h5>¿Desear dejar de ser voluntario?</h5>
                    <asp:Button ID="btnDejarVoluntariado" runat="server" Text="Dejar de serlo" 
                        onclick="btnDejarVoluntariado_Click" CausesValidation="false" /></div>
                <br />  
            </asp:Panel>
            <div class="panel-body">
                <div>
                    <div class="col-md-3 col-md-offset-4">
                        <table>
                            <tr style="height:30px">
                                <td align="right" width="200px">Voluntario:</td>
                                <td align="left"><asp:TextBox ID="txtNombre" runat="server" Width="325px" ReadOnly="true"></asp:TextBox></td>
                                <td></td>
                            </tr>
                            <tr style="height:30px">
                                <td align="right" width="200px">Email:</td>
                                <td align="left"><asp:TextBox ID="txtEmail" runat="server" Width="325px"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" 
                                        ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Formato de email incorrecto"
                                ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator>  
                                        </td>
                            </tr >
                        </table>
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnlHogar" runat="server" Visible="false">
                <div><h5>Datos Hogar</h5></div>
                <div class="panel-body">
                    <div>
                        <div class="col-md-3 col-md-offset-4">
                            <table>
                                <tr style="height:30px">
                                    <td align="right" width="200px" >Tipo Hogar:</td>
                                    <td align="left"><asp:DropDownList ID="ddlTipoHogar" runat="server" Width="325px" AppendDataBoundItems="True">
                                        <asp:listitem value ="1"> Sin Patio </asp:listitem>
                                        <asp:listitem value ="2"> Con Patio Chico </asp:listitem>
                                        <asp:listitem value ="3"> Con Patio Grande </asp:listitem>
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Calle:</td>
                                    <td><asp:DropDownList ID="ddlCalle" Enabled="true" runat="server" CssClass="DropDownList"
                                                Width="325px">
                                            </asp:DropDownList></td>
                                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="ddlCalle" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Nro:</td>
                                    <td align="left"><asp:TextBox ID="txtNro" runat="server" Width="325px"></asp:TextBox></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" 
                                            ForeColor="Red" ControlToValidate="txtNro"></asp:RequiredFieldValidator>
                                            </td>
                                </tr >
                                <tr style="height:30px">
                                    <td align="right" width="200px" >Barrio:</td>
                                    <td align="left"><asp:DropDownList ID="ddlBarrio" runat="server" Width="325px" AppendDataBoundItems="True">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddlBarrio" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Acepto Hasta</td>
                                    <td align="left"><asp:DropDownList ID="ddlNumeroMascotas" runat="server" Width="325px" AppendDataBoundItems="True">
                                        <asp:listitem value ="1"> 1 Mascota Provisoria </asp:listitem>
                                        <asp:listitem value ="2"> 2 Mascotas Provisorias</asp:listitem>
                                        <asp:listitem value ="3"> 3 Mascotas Provisorias</asp:listitem>
                                        <asp:listitem value ="4"> 4 Mascotas Provisorias</asp:listitem>
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Tipo Mascota:</td>
                                    <td align="left"><asp:DropDownList ID="ddlTipoMascota" runat="server" Width="325px" AppendDataBoundItems="True">
                                        <asp:listitem value ="1"> Solo Perros </asp:listitem>
                                        <asp:listitem value ="2"> Solo Gatos </asp:listitem>
                                        <asp:listitem value ="3"> Perros y Gatos </asp:listitem>
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Tiene Niños:</td>
                                    <td align="left"><asp:DropDownList ID="ddlTieneNinios" runat="server" Width="100%">
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Mis Provisorias:</td>
                                    <td align="left"> <asp:DropDownList ID="ddlMascotasEnHogar" runat="server" 
                                            onselectedindexchanged="ddlMascotasEnHogar_SelectedIndexChanged" 
                                            AutoPostBack="True">
                                    </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                            </table>
                            <div class="centered"><h5>¿Desea actualizar los datos de su hogar?</h5></div>
                            <div class="centered"><asp:Button ID="btnActualizarHogar" runat="server" 
                                    Text="Actualizar Hogar" onclick="btnActualizarHogar_Click"/></div>
                            <asp:Panel ID="pnlMisProvisorias" runat="server" Visible="false">
                                <table>
                                    <tr style="height:30px">
                                        <td align="right" width="200px">Mascota:</td>
                                        <td align="left"><asp:TextBox ID="txtMascotaHogar" runat="server" Width="325px" ReadOnly=true></asp:TextBox></td>
                                        <td></td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" width="200px" >Sexo:</td>
                                        <td align="left"><asp:TextBox ID="txtSexoHogar" runat="server" Width="325px" ReadOnly=true></asp:TextBox></td>
                                        <td></td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" width="200px" >Especie:</td>
                                        <td align="left"> <asp:DropDownList ID="ddlEspecieHogar" runat="server" CssClass="DropDownList" AppendDataBoundItems="true" Width="325px" Enabled="false">
                                                </asp:DropDownList></td>
                                        <td></td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" width="200px">Raza:</td>
                                        <td align="left"><asp:DropDownList ID="ddlRazaHogar" runat="server" Width="325px" CssClass="DropDownList" AppendDataBoundItems="true" Enabled="false">
                                                </asp:DropDownList></td>
                                        <td></td>
                                    </tr >
                                </table>
                                <div class="centered"><h5>¿No puede seguir cuidando a su mascota provisoria?</h5></div>
                                <div class="centered"><asp:Button ID="btnSolicitarDevolucion" runat="server" 
                                        Text="Solicitar Devolución" onclick="btnSolicitarDevolucion_Click"/></div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlBusqueda" runat="server" Visible="false">
            <div><h5>Datos Busqueda</h5></div>
                <div class="panel-body">
                    <div>
                        <div class="col-md-3 col-md-offset-4">
                            <table>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Disponibilidad Horaria</td>
                                    <td align="left"><asp:DropDownList ID="ddlDisponibilidadHoraria" runat="server" Width="325px" AppendDataBoundItems="True">
                                        <asp:listitem value ="1" Text="Por la mañana"></asp:listitem>
                                        <asp:listitem value ="2" Text="Por la tarde"></asp:listitem>
                                        <asp:listitem value ="3" Text="Por la noche"></asp:listitem>
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Barrio Domicilio:</td>
                                    <td align="left"><asp:DropDownList ID="ddlBarrioBusqueda" runat="server" 
                                            Width="325px" AppendDataBoundItems="True" 
                                            onselectedindexchanged="ddlBarrioBusqueda_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Mascotas Perdidas:</td>
                                    <td align="left"> <asp:DropDownList ID="ddlBusquedasMascota" runat="server" 
                                             AutoPostBack="True" 
                                            onselectedindexchanged="ddlBusquedasMascota_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">
                                        <input id="btnUbicacion1" type="button" value="Busquedas por barrio" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <div class="centered"><h5>¿Desea actualizar sus datos de disponibilidad?</h5></div>
                            <div class="centered"><asp:Button ID="btnActualizarBusqueda" runat="server" 
                                    Text="Actualizar Disponibilidad" onclick="btnActualizarBusqueda_Click"/></div>
                            <asp:Panel ID="pnlMisBusquedas" runat="server" Visible="false">
                                <table>
                                    <tr style="height:30px">
                                        <td align="right" width="200px">Mascota:</td>
                                        <td align="left"><asp:TextBox ID="txtMascotaPerdida" runat="server" Width="325px" ReadOnly="true"></asp:TextBox></td>
                                        <td></td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" width="200px" >Especie:</td>
                                        <td align="left">
                                        <asp:DropDownList ID="ddlEspeciePerdida" runat="server" CssClass="DropDownList" AppendDataBoundItems="true" Width="325px" Enabled="false">
                                                </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" width="200px">Raza:</td>
                                        <td align="left">
                                        <asp:DropDownList ID="ddlRazaPerdida" runat="server" Width="325px" CssClass="DropDownList" AppendDataBoundItems="true" Enabled="false">
                                                </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr >
                                    <tr style="height:30px">
                                        <td align="right" width="200px">Ver lugar pérdida:</td>
                                        <td align="left">
                                            <input id="btnUbicacion" type="button" value="Ubicación" />
                                        </td> 
                                        <td></td>
                                    </tr >
                                </table>
                                <div class="centered"><h5>¿Quisiera ver mas detalles de la mascota perdida?</h5></div>
                                <div class="centered"><asp:Button ID="btnSolicitarDetallesPerdida" runat="server" 
                                        Text="Ver Detalles Perdida" onclick="btnSolicitarDetallesPerdida_Click"/></div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            
        </div>
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
        </div>
        <asp:HiddenField ID="hfDirecciones" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="hfNombres" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="hfCuidados" runat="server"></asp:HiddenField>
        <!-- Modal -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
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
    </div>
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
        var marker;
        //var geocoder1;
        //metodo de inicio
        function initMap() {
            map = null;
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
            marcadores = null;
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
                        marcador = null;
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
            map1 = null;
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
                    marker = new google.maps.Marker({
                        map: resultsMap,
                        position: results[0].geometry.location,
                        animation: google.maps.Animation.DROP,
                        icon: "./imagenes/registrarperdida (34x35).jpg"
                    });
                    marker.addListener('click', function () {
                        infowindow1.setContent(texto);
                        infowindow1.open(resultsMap, marker);
                    });
//                    var cityCircle = new google.maps.Circle({
//                        strokeColor: '#FF0000',
//                        strokeOpacity: 0.8,
//                        strokeWeight: 2,
//                        fillColor: '#FF0000',
//                        fillOpacity: 0.35,
//                        map: resultsMap,
//                        center: results[0].geometry.location,
//                        radius: Math.sqrt(cuidado1) * 100
//                    });
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
                    map1 = null;
                    marker = null;
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
                    map = null;
                    marcadores = null;
                    marcador = null;
                    initialize();
                });
            }
            else {
                alert('No se encontraron veterinarias para ese barrio');
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

