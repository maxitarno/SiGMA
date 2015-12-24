<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAMBVeterinarias.aspx.cs" Inherits="SiGMA.CAMBVeterinarias" MasterPageFile="~/PaginaMaestra.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="panel panel-default">
        <div class="centered">
            <div class="panel panel-heading">
                <h3 class="panel-title">
                    <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-md-12">
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
        <div class="panel-body">
            <div class="col-md-12">
                <div class="col-md-2 col-md-offset-4">
                    Por Nombre
                    <asp:RadioButton ID="rbPorNombre" runat="server" Text="" GroupName="1" Checked="true" OnCheckedChanged="RbPorNombre" AutoPostBack="True" />
                </div>
                <div class="col-md-2 col-md-offset-1">       
                    Por Domicilio
                    <asp:RadioButton ID="rbPorDomicilio" runat="server" Text="" GroupName="1" OnCheckedChanged="RbPorDomicilio" AutoPostBack="True" />
                </div>
            </div>
            <div class="col-md-offset-3 col-md-3">
                <table>
                    <tr>
                        <asp:Panel ID="pnlNombre" runat="server" ForeColor="Red">
                            <td>
                                Nombre:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un nombre" ForeColor="Red" Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup="1"></asp:RequiredFieldValidator>
                            </td>
                        </asp:Panel>
                    </tr>
                    <asp:Panel ID="pnlDomicilio" runat="server">
                        <tr>
                        <td>
                            Localidad:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" style="width:210px" AutoPostBack="True" OnSelectedIndexChanged="selectedIndexChange" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                        <tr>
                        <td>
                            Barrio:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBarrio" runat="server"  AutoPostBack="True" Width="210px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                        <tr>
                        <td>
                            Calle:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCalle" runat="server" AutoPostBack="True" Width="150px">
                            </asp:DropDownList>
                            - <asp:TextBox ID="txtNº" runat="server" Width="50px"></asp:TextBox>
                        </td>
                    </tr>
                    </asp:Panel>
                    <tr>
                    <td>
                        <asp:Panel ID="pnlMapa" runat="server" Visible="false">
                            <input id="btnUbicacion" type="button" value="Ubicación" />
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                            onclick="btnBuscar_Click" />
                    </td> 
                </tr>
                    <asp:Panel ID="pnlResultados" runat="server">
                    <tr>
                        <td>
                            Resultados:
                        </td>
                        <td>
                            <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selected" Width="210px"></asp:ListBox>
                        </td>
                    </tr>
                </asp:Panel>
                </table>
            </div>
            <div class="col-md-4">
                <table>
                    <asp:Panel ID="pnlDatos" runat="server">
                        <tr>
                            <td>
                                Realiza:
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Peluqueria
                            </td>
                            <td>
                                <asp:CheckBox ID="chkPeluqueria" runat="server"/>
                            </td>
                        </tr>
                        <tr> 
                            <td> 
                                PetShop 
                            </td>
                            <td>
                                <asp:CheckBox ID="chkPetShop" runat="server"/> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Medicinas
                            </td>
                            <td>
                                <asp:CheckBox ID="chkMedicinas" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Castraciones
                            </td>
                            <td>
                                <asp:CheckBox ID="chkCastraciones" runat="server"/>                                    
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Contacto:
                            </td>
                            <td>
                                <asp:TextBox ID="txtContacto" runat="server" Width="210px"></asp:TextBox>  
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="revContacto" runat="server" ErrorMessage="Formato de email incorrecto" ControlToValidate="txtContacto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfvContacto" runat="server" ErrorMessage="Debe ingresar un contacto" ControlToValidate="txtContacto" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                T.E.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTE" runat="server" Width="210px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="Debe ingresar un telefono" ControlToValidate="txtTE" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td align="right">
                            <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                                    onclick="btnEliminar_Click" />
                            </asp:Panel>
                        </td>
                        <td align="right">
                            <asp:Panel ID="pnlModificar" runat="server" Visible="true">
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="Modificar" ValidationGroup="1" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfDireccion" runat="server" />
    <asp:HiddenField ID="hfNombre" runat="server" />
    <asp:HiddenField ID="hfTelefono" runat="server" />
    <asp:HiddenField ID="hfContacto" runat="server" />
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                            Veterinarias</h4>
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
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
           OnClick="BtnRegresarClick" CausesValidation="false" />
        <br> Volver
    </div>
    <script type="text/javascript">
        var infowindow;
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
            var direccion = document.getElementById('<%=hfDireccion.ClientID%>').value.toString();// (getURLParameter("direccion") == null) ? "" : getURLParameter("direccion");
            var nombre = document.getElementById('<%=hfNombre.ClientID%>').value.toString(); //(getURLParameter("nombre") == null) ? "" : getURLParameter("nombre");
            var telefono = document.getElementById('<%=hfTelefono.ClientID%>').value.toString(); //(getURLParameter("telefono") == null) ? "" : getURLParameter("telefono");
            var contacto = document.getElementById('<%=hfContacto.ClientID%>').value.toString(); //(getURLParameter("contacto") == null) ? "" : getURLParameter("contacto");
            var texto = "<div><p><h3>nombre: " + nombre + "</br>telefono: " + telefono + "</br>contacto: " + contacto + "</h3></p></div>";
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