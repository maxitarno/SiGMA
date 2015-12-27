<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contrato.aspx.cs" Inherits="SiGMA.Contrato"
    MasterPageFile="PaginaMaestra.Master" %>

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
    <script src="https://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/js/hover.zoom.js"></script>
    <script src="assets/js/hover.zoom.conf.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Scripts/jquery.print.js"></script>
    <script type="text/javascript" src=""></script>
    <script type="text/javascript">
        function imprimir(id) {
            var a = document.getElementById(id);
            var Popup = window.open('', 'Impresion');
            Popup.document.open();
            Popup.document.writeln('<HTML><HEAD>');
            Popup.document.writeln('<style type="text/css">{');
            Popup.document.writeln('h1 {font-size:large;border-bottom-style:solid;}');
            Popup.document.writeln('h2 {border-bottom: 1px solid #999999 ;font-size:large;}')
            Popup.document.writeln('</style></HEAD><BODY>');
            Popup.document.write(a.innerHTML);
            Popup.document.writeln('</BODY></HTML>');
            Popup.document.close();
            Popup.print();
            Popup.close();
        }
    </script>
    <div class="container pt">
        <div class="centered">
            <div class="panel panel-default">
                <div class="centered">
                    <div class="panel-heading" id="b">
                        <h3 class="panel-title">
                            Contrato
                        </h3>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="printable" style="border: solid" id="contrato">
                        <div class="col-md-12">
                            <div class="col-md-8 col-md-offset-4">
                                <table>
                                    <tr>
                                        <td align="center">
                                            <h3>
                                                CONTRATO DE ADOPCIÓN
                                            </h3>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Nº de adopción:&nbsp
                                <asp:Label ID="lblNumeroDeAdopción" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-4 col-md-offset-4">
                                 Fecha:
                                 <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <table>
                                <tr>
                                    <td align="left">
                                        <h3>
                                            Datos personales
                                        </h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Documento:&nbsp
                                        <asp:Label ID="lblDocumento" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Apellido y nombre:&nbsp
                                        <asp:Label ID="lblApellidoYNombre" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Telefono fijo:&nbsp
                                        <asp:Label ID="lblTelefonoFijo" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Email:&nbsp
                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <h3>
                                            Domicilio</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Localidad:&nbsp
                                        <asp:Label ID="lblLocalidad" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Barrio:&nbsp
                                        <asp:Label ID="lblBarrio" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Dirección:&nbsp
                                        <asp:Label ID="lblCalleYNumero" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <h3>
                                            Datos de la mascota</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Id de la mascota:
                                        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Nombre:&nbsp
                                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Especie:&nbsp
                                        <asp:Label ID="lblEspecie" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Raza:&nbsp
                                        <asp:Label ID="lblRaza" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Edad:&nbsp
                                        <asp:Label ID="lblEdad" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Sexo:&nbsp
                                        <asp:Label ID="lblSexo" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <h3>
                                            Condiciones</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <h2>
                                            El adoptante se compromete a:</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="justify">
                                        <p>
                                            * Proporcionarle todos los cuidados higienicos-sanitarios, cuidar su habitat,su
                                            necesidad de hacer ejercicio y darle cariño.
                                            <br />
                                            * Devolverlo en el caso de que por cualquier circunstancia no pueda atenderlo correctamente
                                            (nunca cambiar de dueño sin dar aviso).
                                            <br />
                                            * Darle cobijo por la noche y en ausencia de los propietarios.
                                            <br />
                                            * Ponerle un collar en el que se identifique el nombre y dirección de los propietarios.
                                            <br />
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        Esta adopción fue registrada por el voluntario Nº:
                                        <asp:Label ID="lblNumeroDeVoluntario" runat="server" Text=""></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Fecha de la revisión:<asp:Label ID="lblFechaRevición" runat="server" Text=""></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Nombre y legajo del encargado de la revisión: -------------
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Firma del encargado: -------------
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                        <div class="col-md-12">
                            <div  class="col-md-8 col-md-offset-2">
                                    <table>
                                    <tr>
                                        <td style="border-top-style:dotted">
                                            Firma del voluntario
                                        </td>
                                        <td style="width:350px"></td>
                                        <td style="border-top-style:dotted">
                                            Firma del adoptante
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div id="a">
                        <div class="col-md-12">
                            <div class="col-md-2 col-md-offset-5">
                                <p>
                                    <a id="imprimir" href="javascript:;" onclick="imprimir('contrato')">Imprimir</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div id="botones">
                        <div class="col-md-12">
                            <div class="col-md-3 col-md-offset-3">
                                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptarClick" />
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="BtnCancelar" runat="server" Text="Rechazar" OnClick="BtnRechazarClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /container -->
</asp:Content>
