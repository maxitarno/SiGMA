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
                CargarCombos.cargarBarrio(ref ddlBarrios);
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                CargarCombos.cargarTipoDocumento(ref ddlTipoDeDocumento);
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
                pnlSeleccionar.Visible = false;
                pnlsurname.Visible = false;
                pnlTelefonFijo.Visible = false;
                pnlTelefonoCelular.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlEliminar.Visible = false;
            }
        }
        public void btnBuscarClick(object sender, EventArgs e){
            if (rbPorPersona.Checked == true)
            {
                lstResultados.Items.Clear();
                List<EUsuario> usuarios = new List<EUsuario>();
                if (Validaciones.verificarSoloNumeros(txtNºDeDocumento.Text))
                {
                    usuarios = LogicaBDUsuario.BuscarUsuarios(int.Parse(ddlTipoDeDocumento.SelectedValue), txtNºDeDocumento.Text);
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
                        pnlAtento.Visible = false;
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = true;
                        lblResultado2.Text = "No se encontraron usuarios";
                    }
                }
                else{
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "Debe ingresar un numero de documento";
                }
            }
            else if(rbPorUsuario.Checked == true)
            {
                lstResultados.Items.Clear();
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
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron usuarios";
                }
            }
        }
        public void btnAceptarClick(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
            EBarrio barrio = new EBarrio();
            ELocalidad localidad = new ELocalidad();
            EPersona persona = new EPersona();
            EUsuario usuario = new EUsuario();
            if (lstResultados.SelectedValue != "")
            {
                LogicaBDUsuario.BuscarUsuarios(lstResultados.SelectedValue, usuario, persona, barrio, localidad);
                txtUsuario.Text = usuario.user;
                ddlTipoDeDocumento.SelectedValue = persona.idTipoDocumento.ToString();
                txtNºDeDocumento.Text = persona.nroDocumento;
                txtApellido.Text = persona.apellido;
                txtNombre.Text = persona.nombre;
                txtDomicilio.Text = persona.domicilio;
                ddlLocalidades.SelectedValue = localidad.idLocalidad.ToString();
                ddlBarrios.SelectedValue = barrio.idBarrio.ToString();
                txtTelefonoFijo.Text = persona.telefonoFijo;
                txtTelefonoCelular.Text = persona.telefonoCelular;
                txtMail.Text = persona.email;
                txtFecha.Text = persona.fechaNacimiento != null ? persona.fechaNacimiento.Value.ToShortDateString() : null;
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
                pnlSeleccionar.Visible = true;
                pnlsurname.Visible = true;
                pnlTelefonFijo.Visible = true;
                pnlTelefonoCelular.Visible = true;
                pnlLimpiar.Visible = true;
                pnlModificar.Visible = true;
                pnlEliminar.Visible = true;
            }
            else
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar un usuario";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
            txtUsuario.ReadOnly = true;
        }
        public void btnModificarClick(object sender, EventArgs e)
        {
            EPersona persona = new EPersona();
            persona.apellido = txtApellido.Text;
            persona.domicilio = txtDomicilio.Text;
            persona.email = txtMail.Text;
            persona.idBarrio = int.Parse(ddlBarrios.SelectedValue);
            persona.idTipoDocumento = int.Parse(ddlTipoDeDocumento.SelectedValue);
            DateTime fecha = new DateTime();
            if (ddlBarrios.SelectedValue.Equals("0") || ddlLocalidades.SelectedValue.Equals("0") || ddlTipoDeDocumento.SelectedValue.Equals("0"))
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar una opción";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
            else
            {
                pnlInfo.Visible = false;
                if (Validaciones.verificarSoloNumeros(txtNºDeDocumento.Text))
                {
                    if (Validaciones.Fecha(txtFecha.Text, out fecha))
                    {
                        persona.nombre = txtNombre.Text;
                        persona.nroDocumento = txtNºDeDocumento.Text;
                        persona.telefonoCelular = txtTelefonoCelular.Text;
                        persona.telefonoFijo = txtTelefonoFijo.Text;
                        persona.fechaNacimiento = fecha;
                        EUsuario usuario = new EUsuario();
                        usuario.user = txtUsuario.Text;
                        if (usuario.user != "")
                        {
                            if (LogicaBDUsuario.ModificarUsuario(persona, usuario))
                            {
                                pnlCorrecto.Visible = true;
                                lblResultado1.Text = "Se modifico corretamente";
                                pnlAtento.Visible = false;
                                pnlInfo.Visible = false;
                            }
                            else
                            {
                                pnlCorrecto.Visible = false;
                                pnlInfo.Visible = false;
                                pnlAtento.Visible = true;
                                lblResultado3.Text = "No se pudo modificar";
                                pnlCorrecto.Visible = false;
                            }
                        }
                        else
                        {
                            pnlCorrecto.Visible = false;
                            pnlInfo.Visible = false;
                            pnlAtento.Visible = true;
                            lblResultado3.Text = "No se pudo modificar";
                            pnlCorrecto.Visible = false;
                        }
                    }
                    else
                    {
                        pnlInfo.Visible = true;
                        lblResultado2.Text = "Debe ingresar una fecha";
                        pnlAtento.Visible = false;
                        pnlCorrecto.Visible = false;
                    }
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "Debe ingresar un número de documento";
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
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
                    txtDomicilio.Text = "";
                    txtFecha.Text = "";
                    txtMail.Text = "";
                    txtNºDeDocumento.Text = "";
                    txtNombre.Text = "";
                    txtTelefonoCelular.Text = "";
                    txtTelefonoFijo.Text = "";
                    txtUsuario.Text = "";
                    lstResultados.Items.Clear();
                    pnlApellido.Visible = false;
                    pnladress.Visible = false;
                    pnlAtento.Visible = false;
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
                    pnlphone.Visible = false;
                    pnlphonefixed.Visible = false;
                    pnlresult.Visible = false;
                    pnlResultados.Visible = false;
                    pnlSeleccionar.Visible = false;
                    pnlsurname.Visible = false;
                    pnlTelefonFijo.Visible = false;
                    pnlTelefonoCelular.Visible = false;
                    if (rbPorUsuario.Checked)
                    {
                        pnlUsuario.Visible = true;
                        pnlUser.Visible = true;
                        pnlType.Visible = false;
                        pnlTipoDeDocumento.Visible = false;
                        pnlnumber.Visible = false;
                        pnlNºDeDocumento.Visible = false;
                        pnlBuscar.Visible = true;
                    }
                    if (rbPorPersona.Checked)
                    {
                        pnlType.Visible = true;
                        pnlTipoDeDocumento.Visible = true;
                        pnlUsuario.Visible = false;
                        pnlUser.Visible = false;
                        pnlnumber.Visible = true;
                        pnlNºDeDocumento.Visible = true;
                        pnlBuscar.Visible = true;
                    }
                    pnlname.Visible = false;
                    pnlNombre.Visible = false;
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
            lstResultados.Items.Clear();
            pnlApellido.Visible = false;
            pnladress.Visible = false;
            pnlAtento.Visible = false;
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
            pnlphone.Visible = false;
            pnlphonefixed.Visible = false;
            pnlresult.Visible = false;
            pnlResultados.Visible = false;
            pnlSeleccionar.Visible = false;
            pnlsurname.Visible = false;
            pnlTelefonFijo.Visible = false;
            pnlTelefonoCelular.Visible = false;
            if (rbPorUsuario.Checked)
            {
                pnlUsuario.Visible = true;
                pnlUser.Visible = true;
                pnlType.Visible = false;
                pnlTipoDeDocumento.Visible = false;
                pnlnumber.Visible = false;
                pnlNºDeDocumento.Visible = false;
                pnlBuscar.Visible = true;
            }
            if (rbPorPersona.Checked)
            {
                pnlType.Visible = true;
                pnlTipoDeDocumento.Visible = true;
                pnlUsuario.Visible = false;
                pnlUser.Visible = false;
                pnlnumber.Visible = true;
                pnlNºDeDocumento.Visible = true;
                pnlBuscar.Visible = true;
            }
            pnlname.Visible = false;
            pnlNombre.Visible = false;
            txtUsuario.ReadOnly = false;
        }
        public void RdbPorUsuario(object sender, EventArgs e)
        {
            if (rbPorUsuario.Checked)
            {
                pnlInfo.Visible = false;
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
                pnlSeleccionar.Visible = false;
                pnlsurname.Visible = false;
                pnlTelefonFijo.Visible = false;
                pnlTelefonoCelular.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlEliminar.Visible = false;
                txtUsuario.ReadOnly = false;
            }
        }
        public void RdbPorPersona(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;
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
            pnlSeleccionar.Visible = false;
            pnlsurname.Visible = false;
            pnlTelefonFijo.Visible = false;
            pnlTelefonoCelular.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlEliminar.Visible = false;
            txtUsuario.ReadOnly = false;
        }
        public void DdlBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            if(!ddlLocalidades.SelectedValue.Equals("0")){
                ddlBarrios.Items.Clear();
                CargarCombos.cargarBarrio(ref ddlBarrios, int.Parse(ddlLocalidades.SelectedValue.ToString()));
                pnlInfo.Visible = false;
            }
        }
    }
}