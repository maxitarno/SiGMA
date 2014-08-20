using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;
namespace SiGMA
{
    public partial class ConsultarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<ETipoDeDocumento> tipos = new List<ETipoDeDocumento>();
                tipos = Datos.TiposDNI();
                ddlTipoDeDocumento.DataSource = tipos;
                ddlTipoDeDocumento.DataTextField = "nombre";
                ddlTipoDeDocumento.DataValueField = "idTipoDeDocumento";
                ddlTipoDeDocumento.DataBind();
                List<ERol> roles = new List<ERol>();
                roles = LogicaBDRol.Roles();
                ddlRoles.DataSource = roles;
                ddlRoles.DataTextField = "nombreRol";
                ddlRoles.DataValueField = "idRol";
                ddlRoles.DataBind();
                rbPorPersona.Checked = true;
                List<ELocalidad> localidades = new List<ELocalidad>();
                localidades = Datos.BuscarLocalidades();
                ddlLocalidades.DataSource = localidades;
                ddlLocalidades.DataTextField = "nombre";
                ddlLocalidades.DataValueField = "idLocalidad";
                ddlLocalidades.DataBind();
                List<EBarrio> barrios = new List<EBarrio>();
                barrios = Datos.BuscarBarrios();
                ddlBarrios.DataSource = barrios;
                ddlBarrios.DataTextField = "nombre";
                ddlBarrios.DataValueField = "idBarrio";
                ddlBarrios.DataBind();
            }
        }
        public void btnBuscarClick(object sender, EventArgs e){
            if (rbPorPersona.Checked == true)
            {
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuarios(ddlTipoDeDocumento.SelectedIndex + 1, txtNºDeDocumento.Text);
                if (usuarios.Count != 0)
                {
                    lstResultados.DataSource = usuarios;
                    lstResultados.DataTextField = "user";
                    lstResultados.DataValueField = "user";
                    lstResultados.DataBind();
                    pnlSeleccionar.Visible = true;
                    pnlResultados.Visible = true;
                    pnlInfo.Visible = false;
                    pnlEliminar.Visible = false;
                    pnlAtento.Visible = false;
                }
                else if(usuarios.Count == 0)
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron usuarios";
                }
            }
            else if(rbPorUsuario.Checked == true)
            {
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuarios(txtUsuario.Text);
                if (usuarios.Count != 0)
                {
                    lstResultados.DataSource = usuarios;
                    lstResultados.DataTextField = "user";
                    lstResultados.DataValueField = "user";
                    lstResultados.DataBind();
                    pnlSeleccionar.Visible = true;
                    pnlResultados.Visible = true;
                    pnlInfo.Visible = false;
                    pnlEliminar.Visible = false;
                    pnlAtento.Visible = false;
                }
                else if(usuarios.Count == 0)
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron usuarios";
                }
            }
        }
        public void btnAceptarClick(object sender, EventArgs e)
        {
            EBarrio barrio = new EBarrio();
            ELocalidad localidad = new ELocalidad();
            EPersona persona = new EPersona();
            EUsuario usuario = new EUsuario();
            LogicaBDUsuario.BuscarUsuarios(lstResultados.SelectedValue, usuario, persona, barrio, localidad);
            txtUsuario.Text = usuario.user;
            ddlTipoDeDocumento.SelectedIndex = persona.idTipoDocumento - 1;
            txtNºDeDocumento.Text = persona.nroDocumento;
            txtApellido.Text = persona.apellido;
            txtNombre.Text = persona.nombre;
            txtDomicilio.Text = persona.domicilio;
            ddlRoles.SelectedIndex = usuario.idRol - 1;
            ddlLocalidades.SelectedIndex = localidad.idLocalidad - 1;
            ddlBarrios.SelectedIndex = barrio.idBarrio;
            txtTelefonoFijo.Text = persona.telefonoFijo;
            txtTelefonoCelular.Text = persona.telefonoCelular;
            txtMail.Text = persona.email;
            txtFecha.Text = persona.fechaNacimiento.ToShortDateString();
            Session["persona"] = persona.idPersona;
            pnlUser.Visible = true;
            pnlBuscar.Visible = false;
            pnlUsuario.Visible = true;
            pnlType.Visible = true;
            pnlNºDeDocumento.Visible = true;
            pnlTipoDeDocumento.Visible = true;
            pnlnumber.Visible = true;
            pnlTipoDeDocumento.Visible = true;
            pnlApellido.Visible = true;
            pnladress.Visible = true;
            pnlbarrio.Visible = true;
            pnlBarrios.Visible = true;
            pnldate.Visible = true;
            pnlDomicilio.Visible = true;
            pnlEliminar.Visible = true;
            pnlestate.Visible = true;
            pnlFecha.Visible = true;
            pnlLimpiar.Visible = true;
            pnlLocalidades.Visible = true;
            pnlMail.Visible = true;
            pnlmails.Visible = true;
            pnlModificar.Visible = true;
            pnlname.Visible = true;
            pnlNombre.Visible = true;
            pnlphone.Visible = true;
            pnlphonefixed.Visible = true;
            pnlresult.Visible = true;
            pnlResultados.Visible = true;
            pnlrol.Visible = true;
            pnlRoles.Visible = true;
            pnlSeleccionar.Visible = true;
            pnlsurname.Visible = true;
            pnlTelefonFijo.Visible = true;
            pnlTelefonoCelular.Visible = true;
            pnlLimpiar.Visible = true;
            pnlModificar.Visible = true;
            pnlEliminar.Visible = true;
        }
        public void btnModificarClick(object sender, EventArgs e)
        {
            EPersona persona = new EPersona();
            persona.apellido = txtApellido.Text;
            persona.domicilio = txtDomicilio.Text;
            persona.email = txtMail.Text;
            try
            {
                persona.fechaNacimiento = DateTime.Parse(txtFecha.Text);
            }
            catch (System.FormatException)
            {
                pnlAtento.Visible = true;
                lblResultado3.Text = "No se pudo modificar";
                pnlCorrecto.Visible = false;
            }
            persona.idBarrio = ddlBarrios.SelectedIndex + 1;
            persona.idTipoDocumento = ddlTipoDeDocumento.SelectedIndex + 1;
            persona.nombre = txtNombre.Text;
            persona.nroDocumento = txtNºDeDocumento.Text;
            persona.telefonoCelular = txtTelefonoCelular.Text;
            persona.telefonoFijo = txtTelefonoFijo.Text;
            EUsuario usuario = new EUsuario();
            usuario.idRol = int.Parse(ddlRoles.SelectedValue);
            usuario.user = txtUsuario.Text;
            if (usuario.user != "")
            {
                if (LogicaBDUsuario.ModificarUsuario(persona, usuario))
                {
                    pnlCorrecto.Visible = true;
                    lblResultado1.Text = "Se modifico corretamente";
                }
                else
                {
                    pnlAtento.Visible = true;
                    lblResultado3.Text = "No se pudo modificar";
                    pnlCorrecto.Visible = false;
                }
            }
            else
            {
                pnlAtento.Visible = true;
                lblResultado3.Text = "No se pudo modificar";
                pnlCorrecto.Visible = false;
            }

        }
        public void btnEliminarClick(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            if (usuario != "")
            {
                if (LogicaBDUsuario.EliminarUsuario(txtUsuario.Text))
                {
                    pnlCorrecto.Visible = true;
                    lblResultado1.Text = "Se elimino corretamente";
                }
                else
                {
                    pnlAtento.Visible = true;
                    lblResultado3.Text = "No se elimino correctamente";
                }
            }
            else
            {
                pnlAtento.Visible = true;
                lblResultado3.Text = "No se elimino correctamente";
            }
        }
        public void btnLimpiarClick(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
            txtApellido.Text = "";
            txtDomicilio.Text = "";
            txtFecha.Text = "";
            txtMail.Text = "";
            txtNºDeDocumento.Text = "";
            txtNombre.Text = "";
            txtTelefonoCelular.Text = "";
            txtTelefonoFijo.Text = "";
            txtUsuario.Text = "";
            
        }
        public void RdbPorUsuario(object sender, EventArgs e)
        {
            if (rbPorUsuario.Checked)
            {
                pnlUser.Visible = true;
                pnlBuscar.Visible = true;
                pnlUsuario.Visible = true;
                pnlType.Visible = false;
                pnlNºDeDocumento.Visible = false;
                pnlTipoDeDocumento.Visible = false;
                pnlnumber.Visible = false;
                pnlTipoDeDocumento.Visible = false;
                pnlApellido.Visible = false;
                pnladress.Visible = false;
                pnlbarrio.Visible = false;
                pnlBarrios.Visible = false;
                pnldate.Visible = false;
                pnlDomicilio.Visible = false;
                pnlEliminar.Visible = false;
                pnlestate.Visible = false;
                pnlFecha.Visible = false;
                pnlLimpiar.Visible = false;
                pnlLocalidades.Visible = false;
                pnlMail.Visible = false;
                pnlmails.Visible = false;
                pnlModificar.Visible = false;
                pnlname.Visible = false;
                pnlNombre.Visible = false;
                pnlphone.Visible = false;
                pnlphonefixed.Visible = false;
                pnlresult.Visible = false;
                pnlResultados.Visible = false;
                pnlrol.Visible = false;
                pnlRoles.Visible = false;
                pnlSeleccionar.Visible = false;
                pnlsurname.Visible = false;
                pnlTelefonFijo.Visible = false;
                pnlTelefonoCelular.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlEliminar.Visible = false;
            }
        }
        public void RdbPorPersona(object sender, EventArgs e)
        {
            pnlType.Visible = true;
            pnlTipoDeDocumento.Visible = true;
            pnlnumber.Visible = true;
            pnlNºDeDocumento.Visible = true;
            pnlBuscar.Visible = true;
            pnlUser.Visible = false;
            pnlUsuario.Visible = false;
            pnlApellido.Visible = false;
            pnladress.Visible = false;
            pnlbarrio.Visible = false;
            pnlBarrios.Visible = false;
            pnldate.Visible = false;
            pnlDomicilio.Visible = false;
            pnlEliminar.Visible = false;
            pnlestate.Visible = false;
            pnlFecha.Visible = false;
            pnlLimpiar.Visible = false;
            pnlLocalidades.Visible = false;
            pnlMail.Visible = false;
            pnlmails.Visible = false;
            pnlModificar.Visible = false;
            pnlname.Visible = false;
            pnlNombre.Visible = false;
            pnlphone.Visible = false;
            pnlphonefixed.Visible = false;
            pnlresult.Visible = false;
            pnlResultados.Visible = false;
            pnlrol.Visible = false;
            pnlRoles.Visible = false;
            pnlSeleccionar.Visible = false;
            pnlsurname.Visible = false;
            pnlTelefonFijo.Visible = false;
            pnlTelefonoCelular.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlEliminar.Visible = false;
        }
    }
}