<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarInformes.aspx.cs"
    Inherits="SiGMA.SeleccionarInformes" MasterPageFile="PaginaMaestra.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Seleccionar informe
                    </h3>
                </div>
                <div class="panel-body">
                    <div class="col-md-2 col-md-offset-5">
                        <asp:Panel runat="server" ID="pnlCorrecto" class="alert alert-dismissable alert-success"
                            Visible="false">
                            <button class="close" type="button" data-dismiss="alert">
                                ×</button>
                            <asp:Label ID="lblResultado1" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlInfo" class="alert alert-dismissable alert-info"
                            Visible="false">
                            <button class="close" type="button" data-dismiss="alert">
                                ×</button>
                            <asp:Label ID="lblResultado2" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlAtento" class="alert alert-dismissable alert-danger"
                            Visible="false">
                            <button class="close" type="button" data-dismiss="alert">
                                ×</button>
                            <asp:Label ID="lblResultado3" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
                <div class="centered">
                    <div style="margin-left: 30%; display: table; width: 40%;">
                        <div style="display: table-row; width: 30%">
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel ID="pnlSeleccion" runat="server">
                                    <asp:DropDownList ID="ddlInforme" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlSelectedChanged" AutoPostBack="True">
                                        <asp:ListItem Value="0" Text="SIN ASIGNAR"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Listado de mascotas"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Listado de Metricas"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Listado de Adopciones"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Listado de Hallazgos"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="Listado de Perdidas"></asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Panel>
                            </div>
                        </div>
                        <div style="display: table-row; width: 30%">
                            <div style="display: table-cell; width: 20%;">
                                <asp:Panel runat="server" Visible="false" ID=pnlFiltros1>
                                    <table>
                                        <tr>
                                            <td>
                                                <%--Fecha:--%>
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtFechaMascota" Enabled="true" runat="server" Width="90%" text="01/01/2013"></asp:TextBox><asp:ImageButton
                                                ID="imgFechaPerdida" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/TemaSigma/imagenes/ico_calendar.gif"
                                                OnClick="imgFechaPerdida_Click" />
                                            <asp:Calendar ID="calendario" runat="server" BorderColor="Black" BorderWidth="1px"
                                                Visible="False" OnSelectionChanged="calendario_SelectionChangedMascota">
                                                <DayHeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                                                <DayStyle ForeColor="Black" />
                                                <TitleStyle BackColor="Black" ForeColor="White" />
                                            </asp:Calendar>
                                            <%--<asp:RangeValidator ID="rnvMascota" runat="server" ErrorMessage="La fecha no puede ser superior a la actual"
                                                ForeColor="Red" ControlToValidate="txtFechaMascota" SetFocusOnError="True" MinimumValue="01/01/2013"
                                                Type="Date" Font-Size="XX-Small"></asp:RangeValidator>--%>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Especie:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEspecies" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Raza:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRaza" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Edad:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEdad" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Estado:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEstado" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel runat=server Visible="false" ID=pnlFiltros2>
                                    <table>
                                        <tr>
                                            <td>
                                                Fecha de la adopción desde:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaAdopcion" Enabled="false" runat="server" Width="90%" Text="  /  /  "></asp:TextBox><asp:ImageButton
                                                ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/TemaSigma/imagenes/ico_calendar.gif"
                                                OnClick="imgFechaPerdida_Click" />
                                            <asp:Calendar ID="calendar1" runat="server" BorderColor="Black" BorderWidth="1px"
                                                Visible="False" OnSelectionChanged="calendario_SelectionChanged">
                                                <DayHeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                                                <DayStyle ForeColor="Black" />
                                                <TitleStyle BackColor="Black" ForeColor="White" />
                                            </asp:Calendar>
                                            <%--<asp:RangeValidator ID="rnvAdopcion" runat="server" ErrorMessage="La fecha no puede ser superior a la actual"
                                                ForeColor="Red" ControlToValidate="txtFechaAdopcion" SetFocusOnError="True" MinimumValue="01/01/2013"
                                                Type="Date" Font-Size="XX-Small"></asp:RangeValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Estado de adopcion:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEstadoDeAdopcion" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel runat="server" Visible="false" ID="pnlFiltros3">
                                    <table>
                                        <tr>
                                            <td>
                                                Fecha de el hallazgo desde:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaDelHallazgo" Enabled="false" runat="server" Width="90%" text="  /  /  "></asp:TextBox><asp:ImageButton
                                                ID="ImageButton2" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/TemaSigma/imagenes/ico_calendar.gif"
                                                OnClick="imgFechaPerdida_Click" />
                                            <asp:Calendar ID="calendar2" runat="server" BorderColor="Black" BorderWidth="1px"
                                                Visible="False" OnSelectionChanged="calendario_SelectionChangedHallazgo">
                                                <DayHeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                                                <DayStyle ForeColor="Black" />
                                                <TitleStyle BackColor="Black" ForeColor="White" />
                                            </asp:Calendar>
                                            <%--<asp:RangeValidator ID="rnvHallazgo" runat="server" ErrorMessage="La fecha no puede ser superior a la actual"
                                                ForeColor="Red" ControlToValidate="txtFechaDelHallazgo" SetFocusOnError="True" MinimumValue="01/01/2013"
                                                Type="Date" Font-Size="XX-Small"></asp:RangeValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Estado de el hallazgo:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEstadoDelHallazgo" runat="server">
                                                </asp:DropDownList> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Barrio:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBarrioHallazgo" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel runat="server" Visible="false" ID="pnlFiltros4">
                                    <table>
                                        <tr>
                                            <td>
                                                fecha de las perdidas desde:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaDeLaPerdida" Enabled="false" runat="server" Width="90%" text="  /  /  "></asp:TextBox><asp:ImageButton
                                                ID="ImageButton3" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/TemaSigma/imagenes/ico_calendar.gif"
                                                OnClick="imgFechaPerdida_Click" />
                                            <asp:Calendar ID="calendar3" runat="server" BorderColor="Black" BorderWidth="1px"
                                                Visible="False" OnSelectionChanged="calendario_SelectionChangedPerdida">
                                                <DayHeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                                                <DayStyle ForeColor="Black" />
                                                <TitleStyle BackColor="Black" ForeColor="White" />
                                            </asp:Calendar>
                                           <%-- <asp:RangeValidator ID="rnvPerdida" runat="server" ErrorMessage="La fecha no puede ser superior a la actual"
                                                ForeColor="Red" ControlToValidate="txtFechaDeLaPerdida" SetFocusOnError="True" MinimumValue="01/01/2013"
                                                Type="Date" Font-Size="XX-Small"></asp:RangeValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Estado de la perdida:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEstadoPerdida" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Barrio:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBarrioPerdida" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID=pnlGenerar runat=server Visible=false>
                                    <asp:Button ID="BtnGenerar" runat="server" Text="Generar" OnClick="BtnGenerarClick"/>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="centered">
                    <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png"
                        OnClick="BtnRegresarClick" CausesValidation="false"/>
                    <br /> VOLVER
                </div>
            </div>
        </div>
    </div>

</asp:Content>
