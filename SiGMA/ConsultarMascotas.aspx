<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarMascotas.aspx.cs"
    Inherits="SiGMA.ConsultarMascotasaspx" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">     
        <script type="text/javascript">
            /***** CUSTOMIZE THESE VARIABLES *****/

            // width to resize large images to
            var maxWidth = 200;
            // height to resize large images to
            var maxHeight = 200;
            // valid file types
            var fileTypes = ["bmp", "gif", "png", "jpg", "jpeg"];
            // the id of the preview image tag
            var outImage = "imgprvw";

            /***** DO NOT EDIT BELOW *****/
            function preview(input) {
                var source = input.value;
                var ext = input.value.substring(input.value.lastIndexOf(".") + 1, input.value.length).toLowerCase();
                for (var i = 0; i < fileTypes.length; i++) if (fileTypes[i] == ext) break;
                globalPic = new Image();
                if (i < fileTypes.length) globalPic.src = input.value;
                else {
                    if (input.value != "") {
                        alert("Formato del archivo no permitido, debe ser: " + fileTypes.join(", "));
                    }
                }
                setTimeout("applyChanges()", 100);
            }
            var globalPic;
            function applyChanges() {
                var field = document.getElementById(outImage);
                var x = parseInt(globalPic.width);
                var y = parseInt(globalPic.height);
                if (x > maxWidth) {
                    y *= maxWidth / x;
                    x = maxWidth;
                }
                if (y > maxHeight) {
                    x *= maxHeight / y;
                    y = maxHeight;
                }
                field.style.display = (x < 1 || y < 1) ? "none" : "";
                field.src = globalPic.src;
                field.width = x;
                field.height = y;
            }
            // End -->
        </script>
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
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                Consultar Mascotas</h3>
            </div>   
        <div class="panel-body">
                <div class="almedio">
                    <asp:Panel Visible=false runat=server ID="imgImagen">
                        <%--<img id="imgprvw" width="140px" height="140px"/>--%>
                        <img id="imgprvw" style="border: 2px solid #000000;" runat="server" src="~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg" />
                    </asp:Panel>

                <table >
                    <tr>
                        <td>
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
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Panel ID="pnlBuscarPor" runat="server" Width="100%">
                                <table>
                                    <tr>
                                        <td colspan="2" align="justify">
                                            <asp:Panel ID="pnlrdbporDuenio" runat="server">
                                                Por dueñio:&nbsp<asp:RadioButton ID="rbPorDuenio" runat="server" GroupName="1" ValidationGroup="1"
                                                    AutoPostBack="True" OnCheckedChanged="RbPorDuenio" />&nbsp
                                            </asp:Panel>
                                        </td>
                                        <td colspan="2" align="right">
                                            <asp:Panel ID="pnlrdbMascota" runat="server">
                                                Por mascota:&nbsp<asp:RadioButton ID="rbPorMascota" runat="server" GroupName="1"
                                                    ValidationGroup="1" AutoPostBack="True" OnCheckedChanged="RbPorMascota" Checked="True" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <table>
                                <tr>
                                    <td valign="middle">
                                        <asp:Panel ID="pnlNombre" Visible="false" runat="server">
                                            Nombre:&nbsp
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnltxtNombreDueñio" Visible="false" runat="server">
                                            <asp:TextBox ID="txtNombreDueñio" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td colspan="3" rowspan="2">
                                        <asp:Panel ID="pnlboton" runat="server" Visible="false">
                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-primary" OnClick="BtnBuscarClick"
                                                Width="100%" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        <asp:Panel ID="pnlmascota" Visible="false" runat="server">
                                            mascota:&nbsp
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnltxtMascota" Visible="false" runat="server">
                                            <asp:TextBox ID="txtMascota" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvMascota" runat="server" ErrorMessage="Debe ingresar un nombre"
                                            ControlToValidate="txtMascota" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlResultados" runat="server" Width="100%" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Resultados:
                                        </td>
                                        <td colspan="3">
                                            <asp:ListBox ID="lstResultados" runat="server" Width="100%" CssClass="ListBox"></asp:ListBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    </table>
                    </div>
                    <div class="almedio">
                    <asp:Panel ID="pnlDatos" runat="server" Visible="false" >
                    <table>
                        <tr>
                            <td>
                                Estado:&nbsp
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDownList" Width="100%"
                                    AppendDataBoundItems="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Especie:&nbsp
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEspecie" runat="server" Width="100%" CssClass="DropDownList"
                                    OnSelectedIndexChanged="ddlRaza_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Edad:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEdad" runat="server" Width="100%" CssClass="DropDownList"
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Raza:&nbsp
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRaza" runat="server" Width="100%" CssClass="DropDownList"
                                    AppendDataBoundItems="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Categoria:&nbsp
                            </td>
                            <td>
                                <asp:TextBox ID="txtCategoria" runat="server" CssClass="TextBox" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cuidado especial:&nbsp
                            </td>
                            <td>
                                <asp:TextBox ID="txtCuidadoEspecial" runat="server" style="resize:none" TextMode="MultiLine" Rows="5" Columns="25" CssClass="TextBox" Width="100%" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Color:&nbsp
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlColor" runat="server" Width="100%" CssClass="DropDownList"
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trato animales:&nbsp
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTratoAnimales" runat="server" Width="100%">
                                    <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trato niños:&nbsp
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTratoNinios" runat="server" Width="100%">
                                    <asp:ListItem Selected="True" Value="0" Text="-- Seleccione una opción --"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Carater:&nbsp
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCaracter" runat="server" CssClass="DropDownList" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Observaciones:&nbsp
                            </td>
                            <td>
                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Alimentacion especial:&nbsp
                            </td>
                            <td>
                                <asp:TextBox ID="txtAlimentacionEspecial" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sexo:&nbsp
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSexo" runat="server" Width="100%" CssClass="DropDownList">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha:&nbsp
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="TextBox" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            <input type="file" runat="server" id="File1" onchange="showimagepreview(this)" />
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlbtnSeleccionar" runat="server" Visible="false">
                                    <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn-primary"
                                        OnClick="BtnSeleccionarClick" CausesValidation="False" />
                                </asp:Panel>
                            </td>
                            <td colspan="3">
                                <asp:Panel ID="pnlbotones" runat="server" Visible="false">
                                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn-primary"
                                        OnClick="BtnModificarClick" ValidationGroup="1" />
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-primary"
                                        ValidationGroup="2" OnClick="BtnEliminarClick" />
                                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-primary"
                                        OnClick="BtnLimpiarClick" />
                                    <asp:Button ID=btnGenerarQR runat=server Text="Generar Codigo QR" CssClass="btn-primary" 
                                        OnClick="btnGenerarQR_Click" />
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
              </div>
        </div>
    </div>
</asp:Content>
