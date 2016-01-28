<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarAdopcion.aspx.cs"
    Inherits="SiGMA.ConsultarAdopcion" MasterPageFile="PaginaAdmin.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title-container">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 wow fadeIn">
	                <img src="assets/img/menu/registraradopcionMini.png" />
                    <h1><asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h1>
                    <p>Cuide a su mascota</p>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-4 col-md-offset-4">
                <asp:Panel runat="server" id="pnlCorrecto" class="alert alert-dismissable alert-success" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlInfo" class="alert alert-dismissable alert-info" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" id="pnlAtento" class="alert alert-dismissable alert-danger" Visible="false">
                    <button class="close" type="button" data-dismiss="alert">
                        ×</button>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlBuscar" runat="server" Visible="false">
        <div class="services-half-width-container">
            <div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
	                        <div class="form-group">
                                    <asp:RadioButton ID="rbPorNombreMascota" runat="server" GroupName="1"
                                        AutoPostBack="True" OnCheckedChanged="RbPorN" Text="Por Nombre de Mascota"/>&nbsp&nbsp
                                    <asp:RadioButton ID="rbPorDNI" runat="server" AutoPostBack="True"
                                        GroupName="1" Checked="True" OnCheckedChanged="RbPorPersona" Text="Por Documento de Dueño"/>
                            </div>
                            <br />
                            <asp:Panel ID="pnlPorAdopcion" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Nombre de la mascota</label>
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlPorDocumento" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="contact-name">Tipo Documento</label>
                                    <asp:DropDownList ID="ddlTipo" runat="server" ViewStateMode="Enabled" Width="100%">
                                        </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Numero Documento</label>
                                        <asp:TextBox ID="txtNº" runat="server"></asp:TextBox>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscarClick" Width="180px" />
                            </div>
	                    </div>
                    </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                            <div class="form-group">
                                <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                                    <label for="contact-name">Elegir</label>
                                    <br /><br />
                                    <asp:ListBox ID="lstResultados" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="lstResultados_SelectedIndexChanged"></asp:ListBox>
                                </asp:Panel>
	                        </div>
	                    </div>
	                </div>
	            </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlDuenio" runat="server" Visible="false">
        <div class="services-half-width-container">
            <div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <label for="contact-name">Datos del dueño</label><br />
                            <div class="form-group">
                                <label for="contact-name">Nombre</label>
                                <asp:TextBox ID="txtNombreD" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"></asp:TextBox>   
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Tipo Documento</label>
                                <asp:TextBox ID="txtTipoDeDocumento" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"></asp:TextBox>
                            </div>  
                            <div class="form-group">
                                <label for="contact-name">Localidad</label>
                                <asp:TextBox ID="txtLocalidad" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"></asp:TextBox>       
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Calle</label>
                                <asp:TextBox ID="txtCalle" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"/>
                            </div>                            
                                
	                    </div>
                    </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                        <label for="contact-name">&nbsp;</label><br />
                            <div class="form-group">
                                <label for="contact-name">Apellido</label>
                                <asp:TextBox ID="txtApellidoD" runat="server" ReadOnly="True" ViewStateMode="Enabled" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Numero Documento</label>
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"></asp:TextBox>   
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Barrio</label>
                                <asp:TextBox ID="txtBarrio" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Numeración Calle</label>
                                <asp:TextBox ID="txtNro" runat="server" ReadOnly="True" ViewStateMode="Enabled" Enabled="False"></asp:TextBox> 
                            </div>
	                    </div>
	                </div>
	            </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlMascota" runat="server" Visible="false">
        <div class="services-half-width-container">
            <div class="container">
	            <div class="row">
	                <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                        <div class="contact-form">
                            <label for="contact-name">Datos de la Mascota</label><br />
                            <div class="form-group">
                                <label for="contact-name">Nombre Mascota</label>
                                <asp:TextBox ID="txtNombreM" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                            Enabled="false"></asp:TextBox>  
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Raza</label>
                                <asp:TextBox ID="txtRaza" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                            Enabled="False"></asp:TextBox>
                            </div>  
                            <div class="form-group">
                                <label for="contact-name">Edad</label>
                                <asp:TextBox ID="txtEdad" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                            Enabled="False"></asp:TextBox>     
                            </div>                          
	                    </div>
                    </div>
	                <div class="col-sm-6 services-half-width-text wow fadeInUp">
                        <div class="contact-form">
                        <label for="contact-name">&nbsp;</label><br />
                            <div class="form-group">
                                <label for="contact-name">Especie</label>
                                <asp:TextBox ID="txtEspecie" runat="server" ViewStateMode="Enabled" ReadOnly="true"
                                        Enabled="False"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="contact-name">Sexo</label>
                                <asp:TextBox ID="txtSexo" runat="server" ReadOnly="True" ViewStateMode="Enabled"
                                        Enabled="False"></asp:TextBox>
                            </div>
	                    </div>
	                </div>
	            </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlDatos" runat="server" Visible="false">
            <div class="services-half-width-container">
                <div class="container">
	                <div class="row">
	                    <div class="col-sm-6 services-half-width-text wow fadeInLeft">
                            <div class="contact-form">
                                <label for="contact-name">Datos a modificar</label><br />
                                <div class="form-group">
                                    <label for="contact-name">Barrio</label>
                                    <asp:DropDownList ID="ddlBarrio" runat="server" Width="100%">
                                                    </asp:DropDownList>
                                </div>                              
                                <div class="form-group">
                                    <label for="contact-name">Numeración Calle</label>
                                    <asp:TextBox ID="txtNºCalle" runat="server"></asp:TextBox>         
                                </div>
	                        </div>
                        </div>
	                    <div class="col-sm-6 services-half-width-text wow fadeInUp">
                            <div class="contact-form">
                            <label for="contact-name">&nbsp;</label><br />
                                <div class="form-group">
                                    <label for="contact-name">Calle</label>
                                    <asp:DropDownList ID="ddlCalle" runat="server" Width="100%">
                                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="contact-name">Nombre Mascota</label>
                                    <asp:TextBox ID="txtNombreMascota" runat="server"></asp:TextBox>
                                </div>
	                        </div>
	                    </div>
	                </div>
                </div>
            </div>
        </asp:Panel>
    <div class="container">
        <asp:Panel ID="pnlbotones" runat="server" Visible="false" >
            <div class="contact-form">
                <div style="text-align:center;">
                    <table style="margin: 0 auto;">
                        <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp; </td>
                            <td><asp:Button ID="btnBuscarOtro" runat="server" Width="180px" Text="Buscar Otra" OnClick="ibtnBuscarOtro_Click"/>
                                &nbsp;&nbsp;&nbsp; </td>
                            <td><asp:Panel ID="pnlEliminar" runat="server" Visible="false">
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminarClick" Width="180px"
                                OnClientClick="if (!confirm('¿Está seguro que desea eliminar la adopción?')){ return false; } else { return true; }" />
                            </asp:Panel> </td>
                            <td>
                            <asp:Panel ID="pnlRegistrar" runat="server" Visible="false">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnRegistrar" runat="server" Text="Generar Contrato" 
                                    OnClick="BtnModificarClick" Width="180px" />
                            </asp:Panel> 
                                
                            </td>
                        </tr>
                    </table>
                </div>   
            </div> 
        </asp:Panel>   
    </div>
</asp:Content>

