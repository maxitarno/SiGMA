using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;
using Herramientas;
namespace SiGMA
{
    public partial class ConsultarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String mod = Request.QueryString["m"];
                if (mod == "1")
                {
                    lblTitulo.Text = "Modificar Usuario /";
                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    ddlTipoDocumento.Enabled = true;
                    ddlCalle.Enabled = true;
                    ddlBarrios.Enabled = true;
                    ddlTipoDocumento.Enabled = true;
                    txtFecha.Enabled = true;
                    txtApellido.ReadOnly = false;
                    txtMail.ReadOnly = false;
                    txtNombre.ReadOnly = false;
                    txtNº.ReadOnly = false;
                    txtDocumento.ReadOnly = false;
                    txtTelefonoCelular.ReadOnly = false;
                    txtTelefonoFijo.ReadOnly = false;
                }
                else
                {
                    lblTitulo.Text = "Consultar Usuario /";
                    ddlTipoDocumento.Enabled = false;
                    ddlCalle.Enabled = false;
                    ddlBarrios.Enabled = false;
                    ddlTipoDocumento.Enabled = false;
                    txtFecha.Enabled = false;
                    txtApellido.ReadOnly = true;
                    txtMail.ReadOnly = true;
                    txtNombre.ReadOnly = true;
                    txtNº.ReadOnly = true;
                    txtDocumento.ReadOnly = true;
                    txtTelefonoCelular.ReadOnly = true;
                    txtTelefonoFijo.ReadOnly = true;
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                }
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "ConsultarUsuario.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "ConsultarUsuario.aspx"))
                        btnModificar.Visible = false;
                    if (!LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "ConsultarUsuario.aspx"))
                        btnEliminar.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                ddlLocalidades.SelectedValue = "1";
                CargarCombos.cargarBarrio(ref ddlBarrios, 1);
                CargarCombos.cargarCalles(ref ddlCalle, 1);
                CargarCombos.cargarTipoDocumento(ref ddlTipoDeDocumentoPersona);
                CargarCombos.cargarTipoDocumento(ref ddlTipoDocumento);
                pnlUser.Visible = true;
                pnlBuscar.Visible = true;
                pnlMostrarUsuario.Visible = false;
                pnlMostrarUsuario1.Visible = false;
                pnlResultados.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                rnvFechaPerdida.MaximumValue = DateTime.Now.ToShortDateString();
            }
        }
        public void btnBuscarClick(object sender, EventArgs e){
            pnlMostrarUsuario.Visible = false;
            pnlMostrarUsuario1.Visible = false;
            if (rbPorPersona.Checked == true)
            {
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                lstResultados.Items.Clear();
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuarios(int.Parse(ddlTipoDeDocumentoPersona.SelectedValue), txtNºDeDocumento.Text);
                if (usuarios.Count != 0)
                {
                    lstResultados.DataSource = usuarios;
                    lstResultados.DataTextField = "user";
                    lstResultados.DataValueField = "user";
                    lstResultados.DataBind();
                    pnlResultados.Visible = true;
                    if (usuarios.Count == 1)
                    {
                        lstResultados.SelectedIndex = 0;
                        lstResultados_SelectedIndexChanged(null, null);
                    }
                    pnlInfo.Visible = false;
                    pnlAtento.Visible = false;
                }
                else if (usuarios.Count == 0)
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron usuarios";
                    pnlResultados.Visible = false;
                }
            }
            else if(rbPorUsuario.Checked == true)
            {
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                lstResultados.Items.Clear();
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuarios(txtUsuario.Text);
                if (usuarios.Count != 0)
                {
                    lstResultados.DataSource = usuarios;
                    lstResultados.DataTextField = "user";
                    lstResultados.DataValueField = "user";
                    lstResultados.DataBind();
                    pnlResultados.Visible = true;
                    if (usuarios.Count == 1)
                    {
                        lstResultados.SelectedIndex = 0;
                        lstResultados_SelectedIndexChanged(null, null);
                    }
                    pnlInfo.Visible = false;
                    pnlAtento.Visible = false;
                }
                else if(usuarios.Count == 0)
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron usuarios";
                    pnlResultados.Visible = false;
                }
            }
        }
        public void btnModificarClick(object sender, EventArgs e)
        {
            EPersona persona = new EPersona();
            if (Page.IsValid)
            {
                persona.nombre = txtNombre.Text;
                persona.nroDocumento = txtDocumento.Text;
                persona.telefonoCelular = txtTelefonoCelular.Text;
                persona.telefonoFijo = txtTelefonoFijo.Text;
                var fecha = DateTime.Today;
                if (DateTime.TryParse(txtFecha.Text, out fecha))
                    persona.fechaNacimiento = Convert.ToDateTime(txtFecha.Text);
                else
                {
                    persona.fechaNacimiento = null;
                }
                persona.apellido = txtApellido.Text;
                persona.email = txtMail.Text;
                persona.barrio = new EBarrio();
                persona.barrio.idBarrio = int.Parse(ddlBarrios.SelectedValue);
                persona.tipoDocumento = new ETipoDeDocumento();
                persona.tipoDocumento.idTipoDeDocumento = int.Parse(ddlTipoDocumento.SelectedValue);
                EUsuario usuario = new EUsuario();
                usuario.user = txtUsuarioMostrar.Text;
                persona.domicilio = new ECalle();
                persona.domicilio.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
                if (usuario.user != "")
                {
                    if (LogicaBDUsuario.ModificarUsuario(persona, usuario))
                    {
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Se modifico corretamente";
                        pnlAtento.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = false;
                        pnlCorrecto.Visible = true;
                        pnlInfo.Visible = false;
                        txtApellido.Text = "";
                        txtFecha.Text = "";
                        txtMail.Text = "";
                        txtDocumento.Text = "";
                        txtNombre.Text = "";
                        txtTelefonoCelular.Text = "";
                        txtTelefonoFijo.Text = "";
                        txtUsuario.Text = "";
                        txtUsuarioMostrar.Text = "";
                        lstResultados.Items.Clear();
                        pnlMostrarUsuario.Visible = false;
                        pnlMostrarUsuario1.Visible = false;
                        pnlResultados.Visible = false;
                        if (rbPorUsuario.Checked)
                        {
                            pnlUser.Visible = true;
                            pnlPersona.Visible = false;
                            pnlBuscar.Visible = true;
                        }
                        if (rbPorPersona.Checked)
                        {
                            pnlUser.Visible = false;
                            pnlPersona.Visible = true;
                            pnlBuscar.Visible = true;
                        }

                    }
                    else
                    {
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = true;
                        lblError.Text = "No se pudo modificar";
                        pnlCorrecto.Visible = false;
                    }
                }
                else
                {
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    pnlAtento.Visible = true;
                    lblError.Text = "No se encontro el usuario";
                    pnlCorrecto.Visible = false;
                }             
            }
        }
        public void btnEliminarClick(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            if (usuario != "")
            {
                if (LogicaBDUsuario.EliminarUsuario(txtUsuario.Text))
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    txtApellido.Text = "";
                    txtFecha.Text = "";
                    txtMail.Text = "";
                    txtDocumento.Text = "";
                    txtNombre.Text = "";
                    txtTelefonoCelular.Text = "";
                    txtTelefonoFijo.Text = "";
                    txtUsuario.Text = "";
                    txtUsuarioMostrar.Text = "";
                    lstResultados.Items.Clear();
                    pnlAtento.Visible = false;
                    pnlResultados.Visible = false;
                    pnlMostrarUsuario.Visible = false;
                    pnlMostrarUsuario1.Visible = false;
                    if (rbPorUsuario.Checked)
                    {
                        pnlUser.Visible = true;
                        pnlPersona.Visible = false;
                        pnlBuscar.Visible = true;
                    }
                    if (rbPorPersona.Checked)
                    {
                        pnlPersona.Visible = true;
                        pnlUser.Visible = false;
                        pnlBuscar.Visible = true;
                    }
                    pnlCorrecto.Visible = true;
                    lblCorrecto.Text = "Se elimino corretamente";
                }
                else
                {
                    pnlAtento.Visible = true;
                    lblError.Text = "No se pudo eliminar el usuario";
                }
            }
            else
            {
                pnlAtento.Visible = true;
                lblError.Text = "No se encontro el usuario";
            }
        }
        public void RdbPorUsuario(object sender, EventArgs e)
        {
            if (rbPorUsuario.Checked)
            {
                pnlInfo.Visible = false;
                pnlUser.Visible = true;
                pnlBuscar.Visible = true;
                pnlPersona.Visible = false;
                pnlResultados.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlBuscar.Visible = true;
                pnlMostrarUsuario.Visible = false;
                pnlMostrarUsuario1.Visible = false;
            }
        }
        public void RdbPorPersona(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;
            pnlUser.Visible = false;
            pnlBuscar.Visible = true;
            pnlPersona.Visible = true;
            pnlResultados.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlBuscar.Visible = true;
            pnlMostrarUsuario.Visible = false;
            pnlMostrarUsuario1.Visible = false;
        }
        public void DdlBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            if(!ddlLocalidades.SelectedValue.Equals("0")){
                ddlBarrios.Items.Clear();
                CargarCombos.cargarBarrio(ref ddlBarrios, int.Parse(ddlLocalidades.SelectedValue.ToString()));
                pnlInfo.Visible = false;
                CargarCombos.cargarCalles(ref ddlCalle, int.Parse(ddlLocalidades.SelectedValue.ToString()));
            }
        }
        protected void lstResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
            EBarrio barrio = new EBarrio();
            ELocalidad localidad = new ELocalidad();
            ETipoDeDocumento tipodoc = new ETipoDeDocumento();
            EPersona persona = new EPersona();
            EUsuario usuario = new EUsuario();
            ECalle calle = new ECalle();
            if (lstResultados.SelectedValue != "")
            {
                LogicaBDUsuario.BuscarUsuarios(lstResultados.SelectedValue, usuario, persona, barrio, localidad, tipodoc, calle);
                txtNº.Text = (persona.nroCalle == null) ? "0" : persona.nroCalle.Value.ToString();
                txtUsuario.Text = usuario.user;
                txtUsuarioMostrar.Text = usuario.user;
                ddlTipoDocumento.SelectedValue = tipodoc.idTipoDeDocumento.ToString();
                txtDocumento.Text = persona.nroDocumento;
                txtApellido.Text = persona.apellido;
                txtNombre.Text = persona.nombre; 
                ddlLocalidades.SelectedValue = localidad.idLocalidad.ToString();
                ddlBarrios.SelectedValue = barrio.idBarrio.ToString();
                txtTelefonoFijo.Text = persona.telefonoFijo;
                txtTelefonoCelular.Text = persona.telefonoCelular;
                txtMail.Text = persona.email;
                txtFecha.Text = persona.fechaNacimiento != null ? persona.fechaNacimiento.Value.ToShortDateString() : null;
                Session["persona"] = persona.idPersona;
                ddlCalle.SelectedValue = (calle.idCalle == null) ? "0" : calle.idCalle.ToString();
                pnlMostrarUsuario.Visible = true;
                pnlMostrarUsuario1.Visible = true;
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe seleccionar un usuario";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }

        protected void cvTipoDocumento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTipoDocumento);
        }
        protected void cvCalles_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCalle);
        }
        protected void cvLocalidades_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlLocalidades);
        }
        protected void cvBarrios_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlBarrios);
        }
        
        protected void cvTelefonoFijo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtTelefonoFijo.Text);
        }

        protected void cvTelefonoCelular_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtTelefonoCelular.Text);
        }

        protected void cvNroDocumento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Validaciones.verificarSoloNumeros(txtDocumento.Text) && Validaciones.contarCaracteresMaximos(8, txtDocumento.Text) && Validaciones.contarCaracteresMinimos(8, txtDocumento.Text));
        }

        protected void cvApellido_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Validaciones.verificarSoloLetras(txtApellido.Text);
        }

        protected void cvNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Validaciones.verificarSoloLetras(txtNombre.Text);
        }

        protected void cvTipoDocumentoPersona_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTipoDeDocumentoPersona);
        }

        protected void cvNroDocumentoPersona_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Validaciones.verificarSoloNumeros(txtNºDeDocumento.Text) && Validaciones.contarCaracteresMaximos(8, txtNºDeDocumento.Text) && Validaciones.contarCaracteresMinimos(8, txtNºDeDocumento.Text));
        }
    }
}