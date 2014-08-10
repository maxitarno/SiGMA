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
                tipos = LogicaBDUsuario.TiposDNI();
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
                localidades = LogicaBDUsuario.BuscarLocalidades();
                ddlLocalidades.DataSource = localidades;
                ddlLocalidades.DataTextField = "nombre";
                ddlLocalidades.DataValueField = "idLocalidad";
                ddlLocalidades.DataBind();
            }
        }
        public void btnBuscarClick(object sender, EventArgs e){
            if (rbPorPersona.Checked == true)
            {
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuarios(ddlTipoDeDocumento.SelectedIndex + 1, txtNºDeDocumento.Text);
                lstResultados.DataSource = usuarios;
                lstResultados.DataTextField = "user";
                lstResultados.DataValueField = "user";
                lstResultados.DataBind();
            }
            else if(rbPorUsuario.Checked == true)
            {
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuarios(txtUsuario.Text);
                lstResultados.DataSource = usuarios;
                lstResultados.DataTextField = "user";
                lstResultados.DataValueField = "user";
                lstResultados.DataBind();
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
            txtFecha.Text = persona.fechaNacimiento.ToString();
        }
        public void ddlLocalidadSelected(object sender, EventArgs e)
        {
            List<EBarrio> barrios = new List<EBarrio>();
            barrios = LogicaBDUsuario.BuscarBarrios(ddlLocalidades.SelectedIndex + 1);
            ddlBarrios.DataSource = barrios;
            ddlBarrios.DataTextField = "nombre";
            ddlBarrios.DataValueField = "idBarrio";
            ddlBarrios.DataBind();
        }
    }
}