<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CABMRazas.aspx.cs" Inherits="SiGMA.CABMRazas"
    MasterPageFile="Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h1 class="panel-title">
                Consultar, modificar razas
            </h1>
        </div>
        <div class="panel-body">
            <div class="tablaDiv">
                <div class="filaDiv">
                    <div class="celdaDiv">
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
            <div class="tablaDiv">
                <div class="filaDiv">
                    <div class="celdaDiv">
                        <asp:Panel runat="server" ID="pnlEspecie">
                            Especie:
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:Panel runat="server" ID="pnlDdlEspecie">
                            <asp:DropDownList ID="ddlEspecies" runat="server" CssClass="DropDownList">
                            </asp:DropDownList>
                        </asp:Panel>
                    </div>
                </div>
                <div class="filaDiv">
                    <div class="celdaDiv">
                        <asp:Panel runat="server" ID="pnlNombre">
                            Nombre:
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:Panel ID="pnltxtNombre" runat="server">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox"></asp:TextBox>
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:Panel ID="pnlBuscar" runat="server" Width="100%">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-primary" CausesValidation="False"
                                OnClick="BtnBuscarClick" />
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un nombre de raza"
                            ControlToValidate="txtNombre" ValidationGroup="1" CssClass="Validator"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="tablaDiv">
                <div class="filaDiv">
                    <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                        <div class="celdaDiv">
                            Resultados:
                        </div>
                        <div class="celdaDiv">
                            <asp:ListBox ID="lstResultados" runat="server" CssClass="ListBox" Width="100%"></asp:ListBox>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="tablaDiv">
                <asp:Panel ID="pnlDatos" runat="server" Visible="false">
                    <div class="filaDiv">
                        <div class="celdaDiv">
                            Peso:
                        </div>
                        <div class="celdaDiv">
                            <asp:TextBox ID="txtPeso" runat="server" CssClass="TextBox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="filaDiv">
                        <div class="celdaDiv">
                            Cuidado especial:
                        </div>
                        <div class="celdaDiv">
                            <asp:DropDownList ID="ddlCuidadoEspecial" runat="server" CssClass="DropDownList" AutoPostBack="True" AppendDataBoundItems="True">
                                <asp:ListItem Text="-- Sin Asignar --" Value="0"></asp:ListItem>
                                <asp:ListItem Text="-- Pequeño --" Value="1"></asp:ListItem>
                                <asp:ListItem Text="-- Mediano --" Value="2"></asp:ListItem>
                                <asp:ListItem Text="-- Grande --" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="filaDiv">
                        <div class="celdaDiv">
                            Categoria:
                        </div>
                        <div class="celdaDiv">
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="DropDownList">
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <div class="tablaDiv">
                <div class="filaDiv">
                    <div class="celdaDiv">
                        <asp:Panel ID="pnlRegistrar" runat="server">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn-primary"
                                ValidationGroup="1" OnClick="BtnRegistrarClick" />
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:Panel ID="pnlSeleccionar" runat="server" Visible="false">
                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn-primary"
                                CausesValidation="False" OnClick="BtnSeleccionarClick" />
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:Panel ID="pnlCambio" runat="server" Visible="false">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn-primary"
                                CausesValidation="true" OnClick="BtnModificarClick" />
                        </asp:Panel>
                    </div>
                    <div class="celdaDiv">
                        <asp:Panel runat="server" ID="pnl8" Visible="false">
                            <!--<asp:Button ID="btneliminar" runat="server" Text="Eliminar" />-->
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-primary"
                                CausesValidation="False" OnClick="BtnLimpiarClick" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
