<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true"
    CodeBehind="ConsultarPerdida.aspx.cs" Inherits="SiGMA.ConsultarPerdida" Culture="Auto" UICulture="Auto"%>


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
    
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="assets/js/hover.zoom.js"></script>
    <script src="assets/js/hover.zoom.conf.js"></script>
    <link href="assets/calendario_dw/calendario_dw-estilos.css" type="text/css" rel="STYLESHEET"/>
   <script type="text/javascript" src="assets/calendario_dw/jquery-1.4.4.min.js"></script>
   <script type="text/javascript" src="assets/calendario_dw/calendario_dw.js"></script>
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
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h3>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-4 col-md-offset-4">
                        <asp:Panel runat="server" ID="pnlCorrecto" class="alert alert-dismissable alert-success"
                            Visible="false">
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
                        <asp:Panel runat="server" ID="pnlAtento" class="alert alert-dismissable alert-danger"
                            Visible="false">
                            <button class="close" type="button" data-dismiss="alert">
                                ×</button>
                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div style="margin-left: 30%; display: table; width: 40%;">
                    <div style="display: table-row; width: 30%">
                        <asp:Panel ID="pnlBuscarPor" runat="server">
                            <div style="display: table-cell; width: 20%; vertical-align: top;">
                                <table>
                                    <tr>
                                        <td colspan="2" align="justify">
                                            <asp:Panel ID="pnlVoluntario" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td valign="middle">
                                                            Mascota:&nbsp
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td colspan="3" rowspan="2">
                                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="right">
                                            <asp:Panel ID="pnlDueño" runat="server" Visible="false">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            Seleccione una Mascota:
                                                            <asp:ListBox ID="lstMascotas" runat="server" Width="100%" OnSelectedIndexChanged="lstMascotas_SelectedIndexChanged"
                                                                AutoPostBack="True"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <div style="display: table-cell; width: 20%;">
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlRegistrarPerdida" runat="server" Visible="false">
                    <div style="margin-left: 20%; display: table; width: 60%;">
                        <div style="display: table-row; width: 30%;">
                            <div style="display: table-cell; width: 30%;">
                                <asp:Panel Visible="false" runat="server" ID="pnlImagen">
                                    <img id="imgprvw" style="border: 2px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                                </asp:Panel>
                            </div>
                            <div style="display: table-cell; width: 22%; vertical-align: top;">
                                <table>
                                    <tr><!--agregado para el mapa-->
                                        <td style="float:left">
                                            <asp:Panel ID="pnlMapa" runat="server" Visible="false">
                                                <input id="btnUbicacion" type="button" value="Ubicación" onclick="return btnUbicacion_onclick()" />
                                                &nbsp;<br />
                                                <input id="hidden1" type="hidden" runat=server/>
                                                &nbsp;</asp:Panel>
                                        </td>
                                    </tr><!--fin-->
                                    <tr>
                                        <td>
                                            Calle y Nro:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCallePerdida" class="pull-left" runat="server" Width="75%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            -
                                            <asp:TextBox ID="txtNroCallePerdida" runat="server" Width="20%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Barrio:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBarrioPerdida" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Localidad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadPerdida" runat="server" Width="100%" AppendDataBoundItems="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha Pérdida:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFecha" runat="server"  Width="90%" />
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/calendario_dw/calendario.png" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" 
                                                    runat="server" TargetControlID="txtFecha" 
                                                    PopupButtonID="Image1">
                                                </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Comentarios:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtComentarios" runat="server" Style="resize: none" TextMode="MultiLine"
                                                Rows="3" Columns="20" CssClass="TextBox" Width="100%" onkeyDown="checkTextAreaMaxLength(this,event,'250');"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                            -
                                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="display: table-row; width: 30%">
                            <div class="col-md-12 col-md-offset-1" style="padding-right: 1%;">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Dueño:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDatosDueño" Enabled="false" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Domicilio:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCalles" Enabled="false" runat="server" Width="75%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            -
                                            <asp:TextBox ID="txtNroCalle" Enabled="false" runat="server" Width="20%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Barrio:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBarrios" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Localidad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidades" Enabled="false" runat="server" Width="100%"
                                                AppendDataBoundItems="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mascota:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMascotaPerdida" ReadOnly="True" Enabled="false" runat="server"
                                                Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Especie:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" Enabled="false" AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Edad:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEdad" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Raza:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRaza" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Sexo:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSexo" Enabled="false" runat="server" Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Color:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlColor" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <asp:HiddenField ID="hfDireccion" runat="server" />
        <asp:HiddenField ID="hfNombre" runat="server" />
        <asp:HiddenField ID="hfCuidado" runat="server" />
        <!-- Modal -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
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
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False" /><br />
            VOLVER
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
            var map = null; 
            map = new google.maps.Map(document.getElementById("map"), mapProp);
            var geocoder = new google.maps.Geocoder();
            infowindow = new google.maps.InfoWindow();
            geocodeAddress(geocoder, map);
            var marker = null;
            marker.setMap(map);
        }
        function geocodeAddress(geocoder, resultsMap) {
            //function getURLParameter(name) { return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null }
            var nombre = "<div><p><h3>nombre: " + document.getElementById('<%=hfNombre.ClientID%>').value.toString() + "</h3></p></div>";
            var direccion = document.getElementById('<%=hfDireccion.ClientID%>').value.toString(); //(getURLParameter("direccion") == null) ? "" : getURLParameter("direccion");
            var address = "argentina " + direccion;
            var cuidado = document.getElementById('<%=hfCuidado.ClientID%>').value.toString(); //(getURLParameter("cuidado") == null) ? "0" : getURLParameter("cuidado");
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
                        infowindow.setContent(nombre);
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
