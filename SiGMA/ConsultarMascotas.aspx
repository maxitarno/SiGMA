<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarMascotas.aspx.cs"
    Inherits="SiGMA.ConsultarMascotasaspx" MasterPageFile="~/PaginaMaestra.Master" Culture="Auto" UICulture="Auto"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
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
   
    <script type="text/javascript">
        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgprvw').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div class="panel panel-default">
        <div class="centered">
                <div class="panel-heading">
                    <h3 class="panel-title">
                    <asp:Label ID="lblTitulo"  runat="server" Text="Label"></asp:Label></h3>
                </div>
            </div>
        <div class="panel-body">
                <div class="col-md-12">
                        <div class="col-md-4 col-md-offset-4">
                           
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
            </div>
        <div class="panel-body">
                <div class="col-md-12">
                    <div class="col-md-1 col-md-offset-4">
                        <asp:RadioButton ID="rbPorDuenio" runat="server" GroupName="1" ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RbPorDuenio" text="Por Dueño"/>&nbsp
                    </div>
                    <div class="col-md-1 col-md-offset-2">
                        <asp:RadioButton ID="rbPorMascota" runat="server" GroupName="1" ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RbPorMascota" Checked="True" text="Por Mascota"/>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-4 col-md-offset-2">
                        <asp:Panel Visible="false" runat="server" ID="imgImagen">
                        <%--<img id="imgprvw" width="140px" height="140px"/>--%>
                        <img id="imgprvw" style="border: 2px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                        </asp:Panel>
                        <table>
                            <tr>
                            <asp:Panel ID="pnlNo" runat=server visible=false>
                                <td>
                                    No mostrar mascota&nbsp
                                </td>
                                <td>
                                    <asp:CheckBox ID="chNoMostrar" Visible = "true" runat = "server"/>
                                </td>
                            </asp:Panel>
                        </tr>
                            <tr>
                            <td>
                                <asp:Panel ID="pnlNombre" Visible="false" runat="server">
                                    Nombre:
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Panel ID="pnltxtNombreDueñio" Visible="false" runat="server">
                                    <asp:TextBox ID="txtNombreDueñio" runat="server"></asp:TextBox> 
                                </asp:Panel>
                            </td>
                        </tr>
                            <tr>
                            <td>
                                <asp:Panel ID="pnlmascota" Visible="false" runat="server">
                                    mascota:
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Panel ID="pnltxtMascota" Visible="false" runat="server">
                                    <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox> 
                                    <asp:RequiredFieldValidator ID="rfvNombreMascota" runat="server" ErrorMessage="*" ControlToValidate="txtMascota" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                </asp:Panel>
                            </td>
                        </tr>
                            <tr>
                            <td>
                                <asp:Panel ID="pnlboton" runat="server" Visible="false">
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscarClick" CausesValidation="false" />
                                </asp:Panel>
                            </td>
                        </tr>
                            <asp:Panel ID="pnlfiltros" runat="server" Visible="false">
                                <tr>
                                <td>
                                    Especie:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEspecie" runat="server" Width="210px" CssClass="DropDownList" OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
                                    </asp:DropDownList><asp:CustomValidator ID="cvEspecies" runat="server" ErrorMessage="*" 
                                        ControlToValidate="ddlEspecie" ForeColor="Red" onservervalidate="cvEspecies_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
                                    </td>
                           </tr>
                                <tr>
                                <td>
                                    Raza:
                               </td>
                               <td>
                                    <asp:DropDownList ID="ddlRaza" runat="server" Width="210px" CssClass="DropDownList"
                                        AppendDataBoundItems="false">
                                    </asp:DropDownList><asp:CustomValidator ID="cvRazas" runat="server" ErrorMessage="*" 
                                ValidationGroup="1" ControlToValidate="ddlRaza" 
                                onservervalidate="cvRazas_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                               </td>
                            </tr>
                                <tr>
                                <td>
                                    Edad:
                                </td>
                                <td>
                                     <asp:DropDownList ID="ddlEdad" runat="server" Width="210px" CssClass="DropDownList"
                                        AppendDataBoundItems="True">
                                     </asp:DropDownList><asp:CustomValidator ID="cvEdad" runat="server" ErrorMessage="*" 
                            ForeColor="Red" ValidationGroup="1" ControlToValidate="ddlEdad" 
                            onservervalidate="cvEdad_ServerValidate"></asp:CustomValidator>
                                </td>
                            </tr>
                                <tr>
                                <td>
                                    Sexo:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSexo" runat="server" Width="210px" CssClass="DropDownList">
                                    </asp:DropDownList> <asp:CustomValidator ID="cvSexo" runat="server" ErrorMessage="*" 
                            ControlToValidate="ddlSexo" ForeColor="Red" ValidationGroup="1" 
                                onservervalidate="cvSexo_ServerValidate"></asp:CustomValidator>
                                </td>
                           </tr>
                                <tr>
                                <td>
                                    Estado:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDownList" Width="210px"
                                        AppendDataBoundItems="true">
                                    </asp:DropDownList><asp:CustomValidator ID="cvEstado" runat="server" ErrorMessage="*" 
                            ControlToValidate="ddlEstado" ValidationGroup="1" 
                            onservervalidate="cvEstado_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                </td>
                            </tr>
                                <tr>
                                <td>
                                    Trato animales:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTratoAnimales" runat="server" Width="210px">
                                        <asp:ListItem Selected="True" Value="0" Text="SIN ASIGNAR"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                   </asp:DropDownList><asp:CustomValidator ID="cvTratoAnimales" runat="server" ErrorMessage="*" 
                            ControlToValidate="ddlTratoAnimales" ForeColor="Red" ValidationGroup="1" 
                            onservervalidate="cvTratoAnimales_ServerValidate"></asp:CustomValidator>
                                </td>
                            </tr>
                                <tr>
                                <td>
                                    Trato niños:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTratoNinios" runat="server" Width="210px">
                                        <asp:ListItem Selected="True" Value="0" Text="SIN ASIGNAR"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                    </asp:DropDownList><asp:CustomValidator ID="cvTratoNinios" runat="server" ErrorMessage="*" 
                            ControlToValidate="ddlTratoNinios" ForeColor="Red" 
                            onservervalidate="cvTratoNinios_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
                                </td>
                            </tr>
                                <tr>
                                <td>
                                    <asp:ImageButton ID="ibtnBuscarOtro" runat="server" ImageUrl="~/imagenes/buscar.jpg" OnClick="BtnBuscarOtroClick" CausesValidation="false" Width="65%" Visible="false"/>
                                </td>
                            </tr>
                            </asp:Panel>
                            <tr>
                            <td>
                                <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                                    <table>
                                        <tr>
                                            <td>
                                                Resultados:
                                            </td>
                                            <td>
                                                <asp:ListBox ID="lstResultados" runat="server" AutoPostBack="True" 
                                                    onselectedindexchanged="lstResultados_SelectedIndexChanged" Width="210px"></asp:ListBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        </table>
                    </div>
                    <div class="col-md-4">
                        <table>
                            <asp:Panel ID="pnlDatos" runat="server">
                            <tr>
                                <td>
                                    Categoria:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cuidado especial:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCuidadoEspecial" runat="server" Width="210px" TextMode="MultiLine"
                                        Rows="5" Columns="25" CssClass="TextBox" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Color:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlColor" runat="server" Width="210px" CssClass="DropDownList"
                                        AppendDataBoundItems="True">
                                    </asp:DropDownList><asp:CustomValidator ID="cvColor" runat="server" ErrorMessage="*" 
                                ControlToValidate="ddlColor" ForeColor="Red" 
                                onservervalidate="cvColor_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Carater:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCaracter" runat="server" CssClass="DropDownList" Width="210px">
                                    </asp:DropDownList><asp:CustomValidator ID="cvCaracter" runat="server" ErrorMessage="*" 
                                ControlToValidate="ddlCaracter" ForeColor="Red" 
                                onservervalidate="cvCaracter_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Observaciones:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBox" Width="210px"
                                        TextMode="MultiLine" Rows="5" Columns="25" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Alimentacion especial:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAlimentacionEspecial" runat="server" CssClass="TextBox" Width="210px"
                                         TextMode="MultiLine" Rows="5" Columns="25" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Fecha:
                                </td>
                                <td>
                                    <asp:Panel ID="pnlFecha" runat="server" Visible="true">
                                                <asp:TextBox ID="txtFecha" runat="server"  Width="210px" />
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/calendario_dw/calendario.png" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" 
                                                    runat="server" TargetControlID="txtFecha" 
                                                    PopupButtonID="Image1">
                                                </ajaxToolkit:CalendarExtender>
                                        </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="file" runat="server" id="fuImagenMascota" onchange="showimagepreview(this)" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </asp:Panel>
                        </table>
                        <div style="margin-left: auto; margin-right: auto">
                        <asp:Panel ID="pnlbotones" runat="server" Visible="false" Width="600px">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="BtnModificarClick"
                                 Style="float: left" ValidationGroup="1" />
                            <asp:Button ID="btnGenerarQR" runat="server" Text="Generar Codigo QR" OnClick="btnGenerarQR_Click"
                                Style="float: left" CausesValidation="false"/>
                            <asp:Button ID="btnAdopcion" runat="server" Text="Poner en adopcion"  
                                Style="float: left" onclick="btnAdopcion_Click" CausesValidation="false"/>
                        </asp:Panel>
                    </div>
                    </div>
                </div>
            </div>
    </div>
    <div class="centered">
        <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/imagenes/volver.png" OnClick="BtnRegresarClick" CausesValidation="false"/>
        <br>
        VOLVER
    </div>
</asp:Content>
