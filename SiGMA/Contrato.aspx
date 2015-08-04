﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contrato.aspx.cs" Inherits="SiGMA.Contrato" MasterPageFile="PaginaMaestra.Master" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
        
        // When the document is ready, initialize the link so
        // that when it is clicked, the printable area of the
        // page will print.
        $(
            function () {
                document.all.item("noprint").style.visibility = 'hidden'
                document.all.item("noprint1").style.visibility = 'hidden'
                document.all.item("botones").style.visibility = 'hidden'
                document.all.item("b").style.visibility = 'hidden'
                // Hook up the print link.
                $("#imprimir")
                //.attr("href", "javascript:void(0)")
                    .click(
                        function () {
                            // Print the DIV.
                            //$(".printable").print();
                            document.all.item("a").style.visibility = "hidden"
                            window.print();
                            document.all.item("a").style.visibility = "visible"
                            document.all.item("noprint").style.visibility = 'visible'
                            document.all.item("noprint1").style.visibility = 'visible'
                            document.all.item("botones").style.visibility = 'visible'
                            document.all.item("b").style.visibility = 'visible'
                            // Cancel click event.
                            return (false);
                        }
                        )
                ;

            }
            );
  
    </script>
    <style type="text/css">
        h1 {
            font-size:small;
            }
  
        h2 {
            border-bottom: 1px solid #999999 ;
            font-size:small;
            }
  
        .printable {
            padding: 0px 0px 0px 0px ;
            font-size:small;
            }
  
        img {
            background-color: #E0E0E0 ;
            padding: 0px 0px 0px 0px ;
            }
        .td
        {
            font-size:small;
        }
    </style>
    <div class="container pt" style="height:888px">
        <div class="centered" style="height:800px">
            <div class="panel panel-default" style="height:800px">
                <div class="panel-heading" id=b>
                    <h3 class="panel-title">
                        Contrato
                    </h3>
                </div>
                <div class="panel-body">
                    <div class="printable" style="border:solid">
                        <table width="1500">
                            <tr>
                                <td colspan="7" align="center">
                                        <h1>
                                            CONTRATO DE ADOPCIÓN
                                        </h1>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3" class=td>
                                    Nº de adopción:&nbsp
                                    <asp:Label ID="lblNumeroDeAdopción" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="right" colspan="3" class=td>
                                        Fecha:
                                        <asp:Label ID="lblFecha" runat="server" Text="" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" align="left">
                                    <h2>
                                        Datos personales
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width:25%" class=td>
                                    Documento:  
                                </td>
                                <td style="width:25%;">
                                    <asp:Label ID="lblDocumento" runat="server"  ></asp:Label>
                                </td>
                                <td align="center" colspan="4" style="width:50%" class=td>
                                    <h3>Domicilio</h3>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class=td>
                                    Apellido y nombre: 
                                </td>
                                <td  >
                                    <asp:Label ID="lblApellidoYNombre" runat="server" Text="" ></asp:Label>
                                </td>
                                <td></td>
                                <td align="left" class=td>
                                    Localidad:
                                </td>
                                <td   colspan="2" style="width:25%">
                                    <asp:Label ID="lblLocalidad" runat="server" Text="" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class=td>
                                   Telefono fijo: 
                                </td>
                                <td>
                                    <asp:Label ID="lblTelefonoFijo" runat="server" Text="" ></asp:Label> 
                                </td>
                                <td></td>
                                <td align="left" class=td>
                                    Barrio: 
                                </td>
                                <td   colspan="2">
                                    <asp:Label ID="lblBarrio" runat="server" Text="" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class=td>
                                    Email: 
                                </td>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server" Text="" ></asp:Label>
                                </td>
                                <td></td>
                                <td align="left" class=td>
                                    Dirección: 
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblCalleYNumero" runat="server" Text="" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="justify" colspan="7">
                                    <h2>Datos de la mascota</h2>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class=td>
                                    Id de la mascota:
                                </td>
                                <td> 
                                    <asp:Label ID="lblId" runat="server" Text="" ></asp:Label>
                                </td>
                                <td></td>
                                <td align="left" class=td>
                                    Nombre: 
                                </td>
                                <td>
                                    <asp:Label ID="lblNombre" runat="server" Text="" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class=td>
                                    Especie: 
                                </td>
                                <td>
                                    <asp:Label ID="lblEspecie" runat="server" Text="" ></asp:Label>
                                </td>
                                <td></td>
                                <td align="left" class=td>
                                    Raza: 
                                </td>
                                <td>
                                    <asp:Label ID="lblRaza" runat="server" Text="" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class=td>
                                    Edad: 
                                </td>
                                <td>
                                    <asp:Label ID="lblEdad" runat="server" Text="" ></asp:Label>
                                </td>
                                <td></td>
                                <td align="left" class=td>
                                    Sexo: 
                                </td>
                                <td>
                                    <asp:Label ID="lblSexo" runat="server" Text="" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="7">
                                    <h2>Condiciones</h2>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="7" class=td>
                                    El adoptante se compromete a:
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="7" class=td>
                                    <p>
                                        * Proporcionarle todos los cuidados higienicos-sanitarios, cuidar su habitat,su necesidad de hacer ejercicio y darle cariño.
                                        <br/>
                                        * Devolverlo en el caso de que por cualquier circunstancia no pueda atenderlo correctamente (nunca cambiar de dueño sin dar aviso).
                                        <br/>
                                        * Darle cobijo por la noche y en ausencia de los propietarios.
                                        <br/>
                                        * Ponerle un collar en el que se identifique el nombre y dirección de los propietarios.
                                        <br />    
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="7" class=td>
                                    Esta adopción fue registrada por el voluntario Nº: <asp:Label ID="lblNumeroDeVoluntario" runat="server" Text="" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td width="50px">
                                </td>
                                <td style="border-top-style:ridge" width="500px" class=td>
                                    Firma del voluntario
                                </td>
                                <td width="50px"></td>
                                <td style="border-top-style:ridge" width="500px" class=td>
                                    Firma del adoptante
                                </td>
                                <td width="200px"></td>
                            </tr>
                        </table>                     
                    </div>
                    <div id=a>
                        <p>
                            <a id="imprimir">Imprimir</a>
                        </p>
                    </div>
                    <div id="botones">
                    <div style="margin-left: 30%; display: table; width: 40%;">
                        <div style="display: table-row; width: 30%">
                            <div style="display: table-cell; width: 20%;">
                                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptarClick"/>
                            </div>
                            <div style="display: table-cell; width: 20%;">
                                <asp:Button ID="BtnCancelar" runat="server" Text="Rechazar" OnClick="BtnRechazarClick"/>
                            </div>
                        </div>
                    </div>
                    </div>
            </div>
        </div>
    </div>
    </div>
    <!-- /container -->
</asp:Content>
