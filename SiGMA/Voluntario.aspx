<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Voluntario.aspx.cs" Inherits="SiGMA.Voluntario" MaintainScrollPositionOnPostback="true"%>
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
            <asp:DropDownList class="dropdown" ID="ddlTipoVoluntario" runat="server" AppendDataBoundItems="true" > 
                <asp:listitem value ="0"> -- Seleccione -- </asp:listitem>
                <asp:listitem value ="1" Text="Hogar"></asp:listitem>
                <asp:listitem value ="2" Text="Busqueda"></asp:listitem>
                <asp:listitem value ="3" Text="Ambos"></asp:listitem>
            </asp:DropDownList>
            <div class="centered"><asp:Button ID="btnCambioVoluntariado" runat="server" Text="Solicitar Voluntariado" /></div>
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
                            <tr style="height:30px">
                                <td align="right" width="200px" >Telefono:</td>
                                <td align="left"><asp:TextBox ID="txtTelefono" runat="server" Width="325px"></asp:TextBox></td>
                                <td></td>
                            </tr>
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
                                        <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción --"></asp:ListItem>
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
                            <div class="centered"><asp:Button ID="btnActualizarHogar" runat="server" Text="Actualizar Hogar"/></div>
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
                                <div class="centered"><asp:Button ID="btnSolicitarDevolucion" runat="server" Text="Solicitar Devolución"/></div>
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
                                        <asp:listitem value ="1"> Por la mañana </asp:listitem>
                                        <asp:listitem value ="2"> Por la tarde </asp:listitem>
                                        <asp:listitem value ="3"> Por la noche </asp:listitem>
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Barrio Domicilio:</td>
                                    <td align="left"><asp:DropDownList ID="ddlBarrioBusqueda" runat="server" Width="325px" AppendDataBoundItems="True">
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                                <tr style="height:30px">
                                    <td align="right" width="200px">Mascotas Perdidas:</td>
                                    <td align="left"> <asp:DropDownList ID="ddlBusquedasMascota" runat="server">
                                    </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                            </table>
                            <br />
                            <div class="centered"><h5>¿Desea actualizar sus datos de disponibilidad?</h5></div>
                            <div class="centered"><asp:Button ID="btnActualizarBusqueda" runat="server" Text="Actualizar Disponibilidad"/></div>
                            <asp:Panel ID="pnlMisBusquedas" runat="server" Visible="false">
                                <table>
                                    <tr style="height:30px">
                                        <td align="right" width="200px">Mascota:</td>
                                        <td align="left"><asp:TextBox ID="txtMascotaPerdida" runat="server" Width="325px"></asp:TextBox></td>
                                        <td></td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" width="200px" >Especie:</td>
                                        <td align="left"><asp:TextBox ID="txtEspeciePerdida" runat="server" Width="325px"></asp:TextBox></td>
                                        <td></td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" width="200px">Raza:</td>
                                        <td align="left"><asp:TextBox ID="txtRazaPerdida" runat="server" Width="325px"></asp:TextBox></td>
                                        <td></td>
                                    </tr >
                                    <tr style="height:30px">
                                        <td align="right" width="200px">Ver lugar pérdida:</td>
                                        <td align="left"><asp:Button ID="btnMapa" runat="server" Text="Ubicación" /></td> 
                                        <td></td>
                                    </tr >
                                </table>
                                <div class="centered"><h5>¿Quisiera ver mas detalles de la mascota perdida?</h5></div>
                                <div class="centered"><asp:Button ID="btnSolicitarDetallesPerdida" runat="server" Text="Ver Detalles Perdida"/></div>
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
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

