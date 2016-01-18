using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using Herramientas;
using System.Threading;
using System.Globalization;

namespace SiGMA
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarBarrio(ref ddlBarrios, 1);
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                ddlLocalidades.SelectedValue = "1";
                CargarCombos.cargarCalles(ref ddlCalle, 1);
                CargarCombos.cargarTipoDocumento(ref ddlTipoDeDocumento);
                rnvFechaPerdida.MaximumValue = DateTime.Now.ToShortDateString();
                cargarMiPerfil();
                pnlModificarContra.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
            {
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }

        private void cargarMiPerfil()
        {
            EBarrio barrio = new EBarrio();
            ELocalidad localidad = new ELocalidad();
            ETipoDeDocumento tipodoc = new ETipoDeDocumento();
            EPersona persona = new EPersona();
            EUsuario usuario = new EUsuario();
            ECalle calle = new ECalle();
            List<EUsuario> usuarios = new List<EUsuario>();
            LogicaBDUsuario.BuscarUsuarios(Session["UsuarioLogueado"].ToString(), usuario, persona, barrio, localidad, tipodoc, calle);
            txtNº.Text = (persona.nroCalle == null) ? "0" : persona.nroCalle.Value.ToString();
            txtUsuario.Text = usuario.user;
            ddlTipoDeDocumento.SelectedValue = tipodoc.idTipoDeDocumento.ToString();
            txtNºDeDocumento.Text = persona.nroDocumento;
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
            txtUsuario.ReadOnly = true;
        }

        protected void cuvDocumento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtNºDeDocumento.Text);
        }

        protected void cvLetrasNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloLetras(txtNombre.Text);
        }

        protected void cvLetrasApellido_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloLetras(txtApellido.Text);
        }

        protected void cvTipoDoc_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTipoDeDocumento);
        }

        protected void cvContraseña_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.contarCaracteres(txtContraNueva.Text);
        }

        public void btnModificarClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EPersona persona = new EPersona();
                pnlInfo.Visible = false;
                persona.nombre = txtNombre.Text;
                persona.nroDocumento = txtNºDeDocumento.Text;
                persona.telefonoCelular = txtTelefonoCelular.Text;
                persona.telefonoFijo = txtTelefonoFijo.Text;
                var fecha = DateTime.Today;
                if (DateTime.TryParse(txtFecha.Text, out fecha))
                    persona.fechaNacimiento = Convert.ToDateTime(txtFecha.Text);
                else
                {
                    persona.fechaNacimiento = null;
                }
                persona.fechaNacimiento = Convert.ToDateTime(txtFecha.Text);
                persona.apellido = txtApellido.Text;
                persona.email = txtMail.Text;
                persona.barrio = new EBarrio();
                persona.barrio.idBarrio = int.Parse(ddlBarrios.SelectedValue);
                persona.tipoDocumento = new ETipoDeDocumento();
                persona.tipoDocumento.idTipoDeDocumento = int.Parse(ddlTipoDeDocumento.SelectedValue);
                EUsuario usuario = new EUsuario();
                usuario.user = txtUsuario.Text;
                usuario.password = txtContraNueva.Text;
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
                        chkCambiarContra.Checked = false;
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
                    lblError.Text = "No se pudo modificar";
                    pnlCorrecto.Visible = false;
                }
            }
        }

        public void DdlBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            if (!ddlLocalidades.SelectedValue.Equals("0"))
            {
                ddlBarrios.Items.Clear();
                CargarCombos.cargarBarrio(ref ddlBarrios, int.Parse(ddlLocalidades.SelectedValue.ToString()));
                pnlInfo.Visible = false;
                CargarCombos.cargarCalles(ref ddlCalle, int.Parse(ddlLocalidades.SelectedValue.ToString()));
            }
        }

        protected void btnModificarContraseña_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                EUsuario usuario = new EUsuario();
                usuario.user = txtUsuario.Text;
                usuario.password = txtContraNueva.Text;
                if (LogicaBDUsuario.verificarContraseña(txtUsuario.Text, txtContraAnterior.Text))
                {
                    if (LogicaBDUsuario.ModificarContraseñaUsuario(usuario))
                    {
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Contraseña modificada corretamente";
                        pnlAtento.Visible = false;
                        pnlInfo.Visible = false;
                        chkCambiarContra.Checked = false;
                        pnlModificarContra.Style.Add(HtmlTextWriterStyle.Display, "none");
                        chkCambiarContra.Checked = false;
                    }
                    else
                    {
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = true;
                        lblError.Text = "No se pudo modificar la contraseña";
                        pnlCorrecto.Visible = false;

                    }
                }
                else
                {
                    chkCambiarContra.Checked = true;
                    chkCambiarContra.Checked = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    pnlAtento.Visible = true;
                    lblError.Text = "Contraseña Incorrecta";
                    pnlCorrecto.Visible = false;

                }
            }
            if (txtContraNueva.Text.Length < 8)
            {
                chkCambiarContra.Checked = true;
                pnlModificarContra.Style.Add(HtmlTextWriterStyle.Display, "visible");
            }
            
        }

        protected void cvTipoDoc_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTipoDeDocumento);
        }

        protected void cvNroDocumento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Validaciones.verificarSoloNumeros(txtNºDeDocumento.Text) && Validaciones.contarCaracteresMaximos(8, txtNºDeDocumento.Text) && Validaciones.contarCaracteresMinimos(8, txtNºDeDocumento.Text));
        }

        protected void cvApellido_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Validaciones.verificarSoloLetras(txtApellido.Text);
        }

        protected void cvNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Validaciones.verificarSoloLetras(txtNombre.Text);
        }

        protected void cvTelefonoFijo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Validaciones.verificarSoloNumeros(txtTelefonoFijo.Text);
        }

        protected void cvTelefonoCelular_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Validaciones.verificarSoloNumeros(txtTelefonoCelular.Text);
        }

    }
}