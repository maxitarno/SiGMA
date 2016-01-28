<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="ConsultarHallazgo.aspx.cs" Inherits="SiGMA.ConsultarHallazgo" Culture="Auto" UICulture="Auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--agregado-->
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCN_PNx9ZJT_kk219eY1fF0Jt9J8JTrDkw"></script>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Scripts/jsapi.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/registrarhallazgoMini.png" />
                    <h1><asp:Label ID="lblTitulo" runat="server"></asp:Label></h1>
                    <p>Cuide a su mascota</p>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-4 col-md-offset-4">
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible="false">
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
                        <asp:Panel ID="pnlFiltros" runat="server" Visible="true">
                            <label for="contact-name" style="text-align:center;">Filtrar mascotas perdidas</label><br />
                            <div class="form-group">
                                <label for="contact-name">Especie</label>
                                <asp:DropDownList ID="ddlFiltroEspecie" Width="100%" AutoPostBack="true" 
                                    runat="server" onselectedindexchanged="ddlFiltroEspecie_SelectedIndexChanged"/>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Raza</label>
                                <asp:DropDownList ID="ddlFiltroRaza" Width="100%" runat="server"/>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Sexo</label>
                                <asp:DropDownList ID="ddlFiltroSexo" Width="100%" runat="server"/>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Color</label>
                                <asp:DropDownList ID="ddlFiltroColor" Width="100%" runat="server"/>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnFiltros" runat="server" Text="Buscar" 
                            onclick="btnFiltros_Click" CausesValidation="False" Width="180px"/>
                            </div>
                        </asp:Panel>
	                </div>
                </div>
                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                        <br />
                            <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                                <label for="contact-name">Elegir una mascota</label>
                                <br />
                                <asp:ListBox ID="lstPerdidas" runat="server" AutoPostBack="true" 
                                OnSelectedIndexChanged="lstPerdidas_SelectedIndexChanged" Width="100%"> 
                                </asp:ListBox>
                            </asp:Panel>
	                    </div>
	                </div>
	            </div>
            </div>
	    </div>
    </div>
    <asp:Panel ID="pnlMascotaSeleccionada" runat="server" Visible="false">
        <div class="services-half-width-container">
            <div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
	                        <div class="form-group" style="text-align:center;">
                                <label for="contact-name">Datos de la mascota</label>    
                                <asp:Panel Visible="true" runat="server" ID="pnlImagen">
                                    <img id="imgprvw" style="border: 1px solid #000000;"
                                        runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg"/>
                                </asp:Panel>
                            </div>
                            <asp:Panel ID="pnlHallazgoPerdidaMascota" runat="server" Visible="true">
                                <div class="form-group">
                                    <label for="contact-name">Nombre de la mascota</label>  
                                    <asp:TextBox ID="txtNombreMascota" runat="server" Enabled="false" Width="100%"></asp:TextBox>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Especie</label> 
                                    <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" 
                                    AutoPostBack="true" Enabled="false" AppendDataBoundItems="true"></asp:DropDownList>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label> 
                                    <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False">
                                    </asp:DropDownList>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Edad</label> 
                                    <asp:DropDownList ID="ddlEdad" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                    </asp:DropDownList>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Sexo</label> 
                                    <asp:DropDownList ID="ddlSexo" Enabled="false" runat="server" Width="100%">
                                    </asp:DropDownList>
	                            </div>
                                <div class="form-group">
                                    <label for="contact-name">Color</label> 
                                    <asp:DropDownList ID="ddlColor" Enabled="False" runat="server" Width="100%" AppendDataBoundItems="True">
                                    </asp:DropDownList>
	                            </div>
                            </asp:Panel>      
	                    </div>
                    </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <div class="form-group" style="text-align:center;">
                                <label for="contact-name" style="text-align:center;">Datos del hallazgo</label><br />
                                <input id="btnUbicacion" type="button" value="Ubicación" style="width:180px"/>
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Localidad</label>
                                    <asp:DropDownList ID="ddlLocalidades" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False"
                                OnSelectedIndexChanged="ddlLocalidades_SelectedIndexChanged" AutoPostBack="True"/>
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Barrio</label>
                                <asp:DropDownList ID="ddlBarrios" Enabled="true" runat="server" Width="100%" AppendDataBoundItems="True">
                                </asp:DropDownList>
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Calle</label>
                                    <asp:DropDownList ID="ddlCalles" Enabled="true" runat="server" Width="100%" AppendDataBoundItems="True">
                            </asp:DropDownList>
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Numeración de la calle</label>
                                <asp:TextBox ID="txtNroCalle" runat="server"></asp:TextBox>
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Fecha del hallazgo</label>
                                <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date"
                                runat="server" TargetControlID="txtFecha" PopupPosition="BottomLeft" Animated="true" >
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"   ControlToValidate="txtFecha" Text="Ingrese una fecha"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rnvFecha" runat="server" ErrorMessage="La fecha es inválida" 
                                ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                MinimumValue="01/12/2015" Type="Date" Font-Size="Small" ></asp:RangeValidator>
	                        </div>
                            <div class="form-group">
                                <label for="contact-name">Comentarios</label><asp:Label ID="lblFocus" runat="server"
                                    Text=""></asp:Label>
                                <asp:TextBox ID="txtComentarios" runat="server" Style="resize: none" TextMode="MultiLine"
                                Rows="7" Columns="30" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
	                        </div>
                            <div class="form-group">
                                <asp:Panel ID="pnlBtnModificar" runat="server" Visible="false">
                                    <asp:Button ID="btnModificarHallazgo" runat="server" Text="Modificar"
                                        OnClick="btnModificarHallazgo_Click" Width="180px"/>
                                </asp:Panel>
                            </div>
	                    </div>
	                </div>
	            </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField ID="hfDireccion" runat="server" />
    <asp:HiddenField ID="hfNombre" runat="server" />
     <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                        Hallazgos</h4>
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
    <script type="text/javascript">
        var infowindow;
        function initialize() {
            var mapProp = {
                center: { lat: -31.4080027, lng: -64.18063840000002 },
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
//            var map = null;
            map = new google.maps.Map(document.getElementById("map"), mapProp);
            var geocoder = new google.maps.Geocoder();
            infowindow = new google.maps.InfoWindow();
            geocodeAddress(geocoder, map);
//            var marker = null;
            marker.setMap(map);
        }
        function geocodeAddress(geocoder, resultsMap) {
            //function getURLParameter(name) { return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null }
            var direccion = document.getElementById('<%=hfDireccion.ClientID%>').value.toString(); //(getURLParameter("direccion") == null) ? "" : getURLParameter("direccion");
            var nombre = document.getElementById('<%=hfNombre.ClientID%>').value.toString(); //(getURLParameter("nombre") == null) ? "" : getURLParameter("nombre");
            var texto = "<div><p><h5>Nombre: " + nombre + "<BR>Dirección: " + direccion + "</h5></p></div>";
            var address = "argentina" + direccion
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    resultsMap.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        map: resultsMap,
                        position: results[0].geometry.location,
                        animation: google.maps.Animation.DROP,
                        icon: "./imagenes/registrarhallazgo (34x35).png"
                    });
                    marker.addListener('click', function () {
                        infowindow.setContent(texto);
                        infowindow.open(resultsMap, marker);
                    });
                } else {
                    alert('La dirección especificada no se encontro ');
                }
            });
        }
        $("#btnUbicacion").click(function () {
            if (document.getElementById('<%=hfDireccion.ClientID%>').value.toString() != "") {
                $("#myModal").modal("show");
                $("#myModal").on('shown.bs.modal', function () {
                    initialize();
                });
            }
        });
    </script>
</asp:Content>