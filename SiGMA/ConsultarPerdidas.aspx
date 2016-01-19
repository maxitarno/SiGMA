<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true"
    CodeBehind="ConsultarPerdida.aspx.cs" Inherits="SiGMA.ConsultarPerdida" Culture="Auto" UICulture="Auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <!--agregado-->
   <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCN_PNx9ZJT_kk219eY1fF0Jt9J8JTrDkw"></script>
   <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
   <script type="text/javascript" src="Scripts/jsapi.js"></script>
   <!--agregado-->
    <script type="text/javascript">
        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/registrarperdidaMini.png" />
                    <h1><asp:Label ID="lblTitulo" runat="server"></asp:Label></h1>
                    <p>La precisión de los datos es vital para una busqueda más eficiente</p>
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
                <asp:Panel runat="server" ID="pnlInfo" class="alert alert-dismissable alert-info"
                    Visible="false">
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
    <asp:Panel ID="pnlBuscarPor" runat="server" >
        <div class="services-half-width-container">
        	<div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <asp:Panel ID="pnlVoluntario" runat="server" Visible="false">
                                <div class="form-group">                        
                                        <label for="contact-name">Nombre mascota</label><br />
                                    <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox><br /><br />
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  onclick="btnBuscar_Click" Width="180px"/>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDueño" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Eligir una mascosta</label>
                                    <br />
                                    <asp:ListBox ID="lstMascotas" runat="server" Width="100%" onselectedindexchanged="lstMascotas_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
	                            </div>
                            </asp:Panel>
                        </div>
	                </div>
	            </div>
            </div>
        </div>
    </asp:Panel><asp:Panel ID="Panel1" runat="server" >
        <div class="services-half-width-container">
        	<div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <asp:Panel ID="Panel2" runat="server" Visible="false">
                                <div class="form-group">                        
                                        <label for="contact-name">Nombre de la mascota</label><br />
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
                                    <asp:Button ID="Button1" runat="server" Text="Buscar"  onclick="btnBuscar_Click" Width="180px"/>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="Panel3" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Eligir una mascosta</label>
                                    <br />
                                    <asp:ListBox ID="ListBox1" runat="server" Width="100%" onselectedindexchanged="lstMascotas_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
	                            </div>
                            </asp:Panel>
                        </div>
	                </div>
	            </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlRegistrarPerdida" runat="server" Visible="false">
        <div class="services-half-width-container">
        	    <div class="container">
	                <div class="row">
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
                                <div class="form-group">
                                    <label for="contact-name">Dueño</label>
                                     <asp:TextBox ID="txtDatosDueño" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Localidad</label>
                                     <asp:DropDownList ID="ddlLocalidades" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Barrio</label>
                                     <asp:DropDownList ID="ddlBarrios" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Calle</label>
                                      <asp:DropDownList ID="ddlCalles" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración calle/dpto</label>
                                      <asp:TextBox ID="txtNroCalle" Enabled="false" runat="server" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Mascota perdida</label>
                                     <asp:TextBox ID="txtMascotaPerdida" ReadOnly="True" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Especie</label>
                                     <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" Enabled="false" AppendDataBoundItems="true"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Raza</label>
                                     <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Sexo</label>
                                      <asp:DropDownList ID="ddlSexo" Enabled="false" runat="server" Width="100%"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Edad</label>
                                      <asp:DropDownList ID="ddlEdad" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Color</label>
                                      <asp:DropDownList ID="ddlColor" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                                <asp:Panel Visible="false" runat="server" ID="pnlImagen">
                                    <div class="form-group" style="text-align:center;">
                                        <img id="imgprvw" style="border: 1px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlMapa" runat="server" Visible="false">
                                <div class="form-group" style="text-align:center;"">
                                        <input id="btnUbicacion" type="button" value="Ubicación" onclick="return btnUbicacion_onclick()" /><br />
                                        <input id="hidden1" type="hidden" runat="server"/>
                                </div>
                                </asp:Panel>
                                <div class="form-group">
                                    <label for="contact-name">Barrio donde se perdió</label>
                                    <asp:DropDownList ID="ddlBarrioPerdida" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvBarrioPerdida" runat="server" 
                                        ErrorMessage="Seleccione un barrio" ForeColor="Red"
                                    ControlToValidate="ddlBarrioPerdida" 
                                        onservervalidate="cvBarrioPerdida_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Calle donde se perdió</label>
                                    <asp:DropDownList ID="ddlCallePerdida" runat="server"  Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvCallePerdida" runat="server" 
                                        ErrorMessage="Seleccione una calle" ForeColor="Red"
                                    ControlToValidate="ddlCallePerdida" 
                                        onservervalidate="cvCallePerdida_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración de calle donde se perdió</label>
                                    <asp:TextBox ID="txtNroCallePerdida"  runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNroCallePerdida"  ForeColor="Red" runat="server" ErrorMessage="Ingrese la numeración de la calle" ControlToValidate="txtNroCallePerdida" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Fecha de pérdida</label>
                                    <asp:TextBox ID="txtFecha" runat="server" onclick="showDate();" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="Date"
                                    runat="server" TargetControlID="txtFecha" PopupPosition="BottomLeft" Animated="true" >
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:RangeValidator ID="rnvFecha" runat="server" ErrorMessage="La fecha es inválida" 
                                    ForeColor="Red" ControlToValidate="txtFecha" SetFocusOnError="True" 
                                    MinimumValue="01/12/2015" Type="Date" Font-Size="Small" ></asp:RangeValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Comentarios</label>
                                    <asp:TextBox ID="txtComentarios" runat="server" style="resize: none" TextMode="MultiLine"
                                     onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
                                </div>
                               <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" Width="180px"/>
                            </div>
	                    </div>
	                </div>
	            </div>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfDireccion" runat="server" />
        <asp:HiddenField ID="hfNombre" runat="server" />
        <asp:HiddenField ID="hfCuidado" runat="server" />
        <!-- Modal -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-md">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                            Perdidas</h4>
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
                zoom: 15,
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
            var nombre = "<div><p><h3>nombre: " + document.getElementById('<%=hfNombre.ClientID%>').value.toString() + "<BR>Direccón: ";
            var direccion = document.getElementById('<%=hfDireccion.ClientID%>').value.toString(); //(getURLParameter("direccion") == null) ? "" : getURLParameter("direccion");
            var address = "argentina " + direccion;
            var cuidado = document.getElementById('<%=hfCuidado.ClientID%>').value.toString(); //(getURLParameter("cuidado") == null) ? "0" : getURLParameter("cuidado");
            var mensaje = nombre + direccion + "</h3></p></div>";
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
                        infowindow.setContent(mensaje);
                        infowindow.open(resultsMap, marker);
                    });
                    var cityCircle = new google.maps.Circle({
                        strokeColor: '#FF0000',
                        strokeOpacity: 0.8,
                        strokeWeight: 2,
                        fillColor: '#FF0000',
                        fillOpacity: 0.35,
                        map: resultsMap,
                        center: results[0].geometry.location,
                        radius: Math.sqrt(cuidado) * 100
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
        function btnUbicacion_onclick() {

        }

    </script>
</asp:Content>
