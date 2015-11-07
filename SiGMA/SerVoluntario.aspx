<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="SerVoluntario.aspx.cs" Inherits="SiGMA.SerVoluntario" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centered">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h3 class="panel-title">
                Ser Voluntario</h3>
            </div>

            <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-md-4 col-md-offset-3">
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
            <div class="centered"><h4>Ser voluntario, implica compromiso y responsabilidad</h4> </div>
            <br/>
            <div class="centered"><h5>Puedes ser voluntario aportando tu casa como hogar provisorio para mascotas halladas, temporalmente sin dueño </h5></div>
            <div class="centered"><h5>o puedes serlo incorporandote a las patrullas de busqueda de mascotas perdidas </h5></div>
            <br/>
            <div class="centered"><h5>En ambos casos, solicitaremos que llenes el formulario de solicitud de voluntariado con tus datos de contacto</h5></div>
            <br />
            <div class="centered"><h6>¿Que tipo de voluntario desea ser?</h6></div>
            <asp:DropDownList class="dropdown" ID="ddlTipoVoluntario" runat="server" AutoPostBack="true" 
                AppendDataBoundItems="true" 
                onselectedindexchanged="ddlTipoVoluntario_SelectedIndexChanged"> 
                <asp:listitem value ="0"> -- Seleccione -- </asp:listitem>
                <asp:listitem value ="1" Text="Hogar"></asp:listitem>
                <asp:listitem value ="2" Text="Busqueda"></asp:listitem>
                <asp:listitem value ="3" Text="Ambos"></asp:listitem>
                
            </asp:DropDownList>
            <br />
            <div class="panel-body">
                    <div>
                        <div class="col-md-3 col-md-offset-4">
                            <table>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Nombre:</td>
                                    <td align="left"><asp:TextBox ID="txtNombre" runat="server" Width="325px"></asp:TextBox></td>
                                    <td><asp:RequiredFieldValidator ID="rfvNombreApellido" runat="server" 
                                            ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator></td>
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
                                    <td align="left"><asp:DropDownList ID="ddlCalle" Enabled="true" runat="server" CssClass="DropDownList"
                                                Width="325px">
                                            </asp:DropDownList></td>
                                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCalle"></asp:RequiredFieldValidator></td>
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
                                    <td></td>
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
                                        <asp:listitem value ="1" Text="Solo Perros">  </asp:listitem>
                                        <asp:listitem value ="2" Text="Solo Gatos">  </asp:listitem>
                                        <asp:listitem value ="3" Text="Perros y Gatos">  </asp:listitem>
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                            </table>
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
                                        <asp:listitem value ="1" Text="Por la mañana"> </asp:listitem>
                                        <asp:listitem value ="2" Text="Por la tarde"> </asp:listitem>
                                        <asp:listitem value ="3" Text="Por la noche"> </asp:listitem>
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Barrio Domicilio:</td>
                                    <td align="left"><asp:DropDownList ID="ddlBarrioBusqueda" runat="server" Width="325px" AppendDataBoundItems="True">
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            
            <div class="centered">
            <asp:Button ID="btnEnviar" style="margin-left: 39px" runat="server" 
                                        Text="Enviar" onclick="btnEnviar_Click" />
            </div>
        </div>
        <div class="centered">
            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                OnClick="BtnRegresarClick" CausesValidation="False"/><br />VOLVER
    </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
