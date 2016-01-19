<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAMBVeterinarias.aspx.cs"
    Inherits="SiGMA.CAMBVeterinarias" MasterPageFile="~/PaginaAdmin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--agregado-->
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCN_PNx9ZJT_kk219eY1fF0Jt9J8JTrDkw"></script>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Scripts/jsapi.js"></script>
    <!--agregado-->
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="assets/js/hover.zoom.js"></script>
    <script src="assets/js/hover.zoom.conf.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/veterinariasMini.png" />
                    <h1><asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></h1>
                    <p>Mantenga sus datos actualizados</p>
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
                            <asp:RadioButton ID="rbPorNombre" runat="server" Text="Por nombre" GroupName="1" Checked="true"
                            OnCheckedChanged="RbPorNombre" AutoPostBack="True" />                            
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbPorDomicilio" runat="server" Text="Por domicilio" GroupName="1" OnCheckedChanged="RbPorDomicilio" AutoPostBack="True" />
                        </div>
                        <asp:Panel ID="pnlNombre" runat="server">
                            <div class="form-group">
                                <label for="contact-name">Consultar</label>
                                <asp:TextBox ID="txtNombreBusqueda" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombreBusqueda" runat="server" ErrorMessage="Ingrese nombre"
                                ForeColor="Red" Display="Dynamic" ControlToValidate="txtNombreBusqueda" ValidationGroup="1"></asp:RequiredFieldValidator><br />
                            </div>
                        </asp:Panel>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                                onclick="btnBuscar_Click" CausesValidation="False" Width="180px"/>
	                </div>
                </div>
	            <div class="col-sm-6 services-half-width-text wow fadeInUp">
                    <div class="contact-form">
                        <div class="form-group">
                        <br /><br />
                            <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                                <label for="contact-name">Elegir la veterinaria</label>
                                <br />
                                <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selected" Width="100%"></asp:ListBox>
                            </asp:Panel>
                            <asp:Panel ID="pnlMapa" runat="server" Visible="false">
                                <input id="btnUbicacion" type="button" value="Ubicación" Width="180px"/>
                            </asp:Panel>
	                    </div>
	                </div>
	            </div>
	        </div>
        </div>
    </div>                
    <div class="services-half-width-container">
        <div class="container">
	        <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDatos" runat="server" Visible="false">
	                            <div class="form-group">
                                    <label for="contact-name">Nombre</label>
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNombre" Text="Debe ingresar un nombre" ControlToValidate="txtNombre" Display="Dynamic" BorderColor="Red" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Email</label>
                                    <asp:TextBox ID="txtContacto" runat="server"></asp:TextBox>  
                                    <asp:RegularExpressionValidator ID="revContacto" runat="server" 
                                        ErrorMessage="Formato de email incorrecto" ControlToValidate="txtContacto" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfvContacto" runat="server" ErrorMessage="Debe ingresar un email" ControlToValidate="txtContacto" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDomicilio" runat="server" Width="100%">
                                <div class="form-group">
                                    <label for="contact-name">Localidad</label>
                                    <asp:DropDownList ID="ddlLocalidad" runat="server" Width="100%" OnSelectedIndexChanged="SeleccionarLocalidad" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                                     <asp:CustomValidator ID="cvLocalidad" runat="server" 
                                        ErrorMessage="Seleccione una localidad" ForeColor="Red"
                                    ControlToValidate="ddlLocalidad" 
                                        onservervalidate="cvLocalidad_ServerValidate" ></asp:CustomValidator>  
                                </div>
                               <div class="form-group">
                                    <label for="contact-name">Calle</label>
                                    <asp:DropDownList ID="ddlCalle" runat="server" Width="100%"  AppendDataBoundItems="True"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvCalle" runat="server" 
                                        ErrorMessage="Seleccione una calle" ForeColor="Red"
                                    ControlToValidate="ddlCalle" onservervalidate="cvCalle_ServerValidate" ></asp:CustomValidator>  
                                </div>
                            </asp:Panel>
                        </div>
	                </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <asp:Panel ID="pnlDatos1" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name" style="margin-bottom:15px">Tipo de servicios que brinda</label><br />
                                    <asp:CheckBox ID="chkMedicinas" runat="server" Text="Atención Médica" Checked="true"/>
                                    &nbsp;
                                    <asp:CheckBox ID="chkPeluqueria" runat="server" Text="Peluqueria" />
                                    &nbsp;
                                    <asp:CheckBox ID="chkPetShop" runat="server" Text="Pet Shop"/>
                                    &nbsp;
                                    <asp:CheckBox ID="chkCastraciones" runat="server" Text="Castraciones"/>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Teléfono</label>
                                    <asp:TextBox ID="txtTE" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="Debe ingresar un teléfono" ControlToValidate="txtTE" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvTelefono" runat="server" 
                                        ErrorMessage="Ingrese solo números" ControlToValidate="txtTE" 
                                        ForeColor="Red" onservervalidate="cvTelefono_ServerValidate"></asp:CustomValidator>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDomicilio1" runat="server" Width="100%">
                                <div class="form-group">
                                   <label for="contact-name">Barrio</label>
                                   <asp:DropDownList ID="ddlBarrio" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvBarrio" runat="server" 
                                        ErrorMessage="Seleccione un barrio" ForeColor="Red"
                                    ControlToValidate="ddlBarrio" onservervalidate="cvBarrio_ServerValidate" ></asp:CustomValidator> 
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numeración de calle/dpto</label>
                                    <asp:TextBox ID="txtNº" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNroCalle"  ForeColor="Red" runat="server" ErrorMessage="Ingrese la numeración de calle/dpto" ControlToValidate="txtNº"></asp:RequiredFieldValidator>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlBotones" runat="server" Visible="false">
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Width="180px" OnClientClick="if (!confirm('¿Está seguro que desea eliminar la veterinaria?')){ return false; } else { return true; }"/>&nbsp;&nbsp;
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="Modificar" ValidationGroup="1" Width="180px" CausesValidation="true"/>
	                        </asp:Panel>
                        </div>
	                </div>
	        </div>
        </div>
    </div>              
    <asp:HiddenField ID="hfDireccion" runat="server" />
    <asp:HiddenField ID="hfNombre" runat="server" />
    <asp:HiddenField ID="hfTelefono" runat="server" />
    <asp:HiddenField ID="hfContacto" runat="server" />
    <asp:HiddenField ID="hfServicios" runat="server" />
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                        Veterinarias</h4>
                </div>
                <div class="modal-body">
                    <div id="map" style="height: 500px; width: 500px">
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
        var i = 0;
        var acomodar = "";
        function initialize() {
            var mapProp = {
                center: { lat: -31.4080027, lng: -64.18063840000002 },
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            infowindow = new google.maps.InfoWindow();
            //            var map = null;
            map = new google.maps.Map(document.getElementById("map"), mapProp);
            var geocoder = new google.maps.Geocoder();
            geocodeAddress(geocoder, map);
        }
        function geocodeAddress(geocoder, resultsMap) {
            function getURLParameter(name) { return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null }
            var servicios = document.getElementById('<%=hfServicios.ClientID%>').value.toString().split(",");
            for (; i < servicios.length; i++) {
                acomodar += "<BR>" + servicios[i].toString();
            }
            var direccion = document.getElementById('<%=hfDireccion.ClientID%>').value.toString(); // (getURLParameter("direccion") == null) ? "" : getURLParameter("direccion");
            var nombre = document.getElementById('<%=hfNombre.ClientID%>').value.toString(); //(getURLParameter("nombre") == null) ? "" : getURLParameter("nombre");
            var telefono = document.getElementById('<%=hfTelefono.ClientID%>').value.toString(); //(getURLParameter("telefono") == null) ? "" : getURLParameter("telefono");
            var contacto = document.getElementById('<%=hfContacto.ClientID%>').value.toString(); //(getURLParameter("contacto") == null) ? "" : getURLParameter("contacto");
            var texto = "<div><p><h3>nombre: " + nombre + "</br>telefono: " + telefono + "</br>contacto: " + contacto + "<BR>Servicios: " + acomodar + "</h3></p></div>";
            var address = "argentina " + direccion;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    resultsMap.setCenter(results[0].geometry.location);
                    //                    var marker = null;
                    marker = new google.maps.Marker({
                        map: resultsMap,
                        position: results[0].geometry.location,
                        animation: google.maps.Animation.DROP,
                        icon: "./imagenes/veterinarias (35x35).jpg"
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
