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
                    lblTitulo.Text = "Modificar Usuario";
                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                }
                else
                {
                    lblTitulo.Text = "Consultar Usuario";
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
                CargarCombos.cargarBarrio(ref ddlBarrios);
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                CargarCombos.cargarCalles(ref ddlCalle);
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
                pnlbarrio.Visible = false;
                pnlBarrios.Visible = false;
                pnldate.Visible = false;
                pnlEliminar.Visible = false;
                pnlestate.Visible = false;
                pnlFecha.Visible = false;
                //pnlLimpiar.Visible = false;
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
                pnlCalle.Visible = false;
                pnlDdlCalle.Visible = false;
                //rnvFechaPerdida.MaximumValue = DateTime.Now.ToShortDateString();
            }
        }
        public void btnBuscarClick(object sender, EventArgs e){
            if (rbPorPersona.Checked == true)
            {
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                lstResultados.Items.Clear();
                pnlSeleccionar.Visible = true;
                List<EUsuario> usuarios = new List<EUsuario>();
                if (Validaciones.verificarSoloNumeros(txtNºDeDocumento.Text))
                {
                    if (Validaciones.verificarSeleccionEnDdl(ref ddlTipoDeDocumento))
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
                        else if (usuarios.Count == 0)
                        {
                            pnlAtento.Visible = false;
                            pnlCorrecto.Visible = false;
                            pnlInfo.Visible = true;
                            lblResultado2.Text = "No se encontraron usuarios";
                        }
                    }
                    else
                    {
                        pnlInfo.Visible = true;
                        lblResultado2.Text = "Debe ingresar un numero de documento";
                        pnlCorrecto.Visible = false;
                        pnlAtento.Visible = false;
                    }
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "Debe ingresar un tipo de documento";
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                }
            }
            else if(rbPorUsuario.Checked == true)
            {
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                lstResultados.Items.Clear();
                pnlSeleccionar.Visible = true;
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

        //protected void imgFechaPerdida_click(object sender, ImageClickEventArgs e)
        //{
        //    calendario.Visible = true;
        //}

        //protected void calendario_SelectionChanged(object sender, EventArgs e)
        //{
        //    txtFecha.Text = calendario.SelectedDate.ToString("d");
        //    calendario.Visible = false;
        //}


        public void btnAceptarClick(object sender, EventArgs e)
        {
            
        }
        public void btnModificarClick(object sender, EventArgs e)
        {
            EPersona persona = new EPersona();
            DateTime fecha = new DateTime();
            if (ddlTipoDeDocumento.SelectedValue.Equals("0"))
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar un tipo de documento";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
            else
            {
                if (!ddlLocalidades.SelectedValue.Equals("0"))
                {
                    if (!ddlCalle.SelectedValue.Equals("0"))
                    {
                        if (!ddlBarrios.SelectedValue.Equals("0"))
                        {
                            pnlInfo.Visible = false;
                            if (Validaciones.verificarSoloNumeros(txtNºDeDocumento.Text) && Validaciones.contarCaracteresMaximos(8, txtNºDeDocumento.Text) && Validaciones.contarCaracteresMinimos(8, txtNºDeDocumento.Text))
                            {
                                if (true == true) // Validaciones.Fecha(txtFecha.Text, out fecha)
                                {
                                    if (Validaciones.verificarSoloLetras(txtApellido.Text) && Validaciones.verificarSoloLetras(txtNombre.Text))
                                    {
                                        if (Validaciones.verificarSoloNumeros(txtTelefonoFijo.Text) && Validaciones.verificarSoloNumeros(txtTelefonoCelular.Text))
                                        {
                                            persona.nombre = txtNombre.Text;
                                            persona.nroDocumento = txtNºDeDocumento.Text;
                                            persona.telefonoCelular = txtTelefonoCelular.Text;
                                            persona.telefonoFijo = txtTelefonoFijo.Text;
                                            persona.fechaNacimiento = Convert.ToDateTime(txtFecha.Text);
                                            persona.apellido = txtApellido.Text;
                                            persona.email = txtMail.Text;
                                            persona.barrio = new EBarrio();
                                            persona.barrio.idBarrio = int.Parse(ddlBarrios.SelectedValue);
                                            persona.tipoDocumento = new ETipoDeDocumento();
                                            persona.tipoDocumento.idTipoDeDocumento = int.Parse(ddlTipoDeDocumento.SelectedValue);
                                            EUsuario usuario = new EUsuario();
                                            usuario.user = txtUsuario.Text;
                                            persona.domicilio = new ECalle();
                                            persona.domicilio.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
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
                                            lblResultado2.Text = "Debe ingresar un numero de telefono valido";
                                            pnlAtento.Visible = false;
                                            pnlCorrecto.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        pnlInfo.Visible = true;
                                        lblResultado2.Text = "Debe ingresar un nombre valido";
                                        pnlAtento.Visible = false;
                                        pnlCorrecto.Visible = false;
                                    }
                                }
                                else
                                {
                                    //pnlInfo.Visible = true;
                                    //lblResultado2.Text = "Debe ingresar una fecha";
                                    //pnlAtento.Visible = false;
                                    //pnlCorrecto.Visible = false;
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
                        else
                        {
                            pnlInfo.Visible = true;
                            lblResultado2.Text = "Debe ingresar un barrio";
                            pnlCorrecto.Visible = false;
                            pnlAtento.Visible = false;
                        }
                    }
                    else
                    {
                        pnlInfo.Visible = true;
                        lblResultado2.Text = "Debe ingresar una calle";
                        pnlAtento.Visible = false;
                        pnlCorrecto.Visible = false;
                    }
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "Debe ingresar una localidad";
                    pnlAtento.Visible = false;
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
                    txtNºDeDocumento.Text = "";
                    txtNombre.Text = "";
                    txtTelefonoCelular.Text = "";
                    txtTelefonoFijo.Text = "";
                    txtUsuario.Text = "";
                    lstResultados.Items.Clear();
                    pnlApellido.Visible = false;
                    pnlAtento.Visible = false;
                    pnlbarrio.Visible = false;
                    pnlBarrios.Visible = false;
                    pnldate.Visible = false;
                    pnlEliminar.Visible = false;
                    pnlestate.Visible = false;
                    pnlFecha.Visible = false;
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
                    txtUsuario.ReadOnly = false;
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
                    pnlDdlCalle.Visible = false;
                    pnlCalle.Visible = false;
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
                pnlbarrio.Visible = false;
                pnlBarrios.Visible = false;
                pnldate.Visible = false;
                pnlEliminar.Visible = false;
                pnlestate.Visible = false;
                pnlFecha.Visible = false;
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
                pnlCalle.Visible = false;
                pnlDdlCalle.Visible = false;
                pnlBuscar.Visible = true;
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
            pnlbarrio.Visible = false;
            pnlBarrios.Visible = false;
            pnldate.Visible = false;
            pnlEliminar.Visible = false;
            pnlestate.Visible = false;
            pnlFecha.Visible = false;
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
            pnlCalle.Visible = false;
            pnlDdlCalle.Visible = false;
            pnlBuscar.Visible = true;
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
        public void BtnRegresarClick(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
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
                pnlUser.Visible = true;
                pnlBuscar.Visible = true;
                pnlUsuario.Visible = true;
                pnlType.Visible = true;
                pnlNºDeDocumento.Visible = true;
                pnlTipoDeDocumento.Visible = true;
                pnlnumber.Visible = true;
                pnlTipoDeDocumento.Visible = true;
                pnlApellido.Visible = true;
                pnlbarrio.Visible = true;
                pnlBarrios.Visible = true;
                pnldate.Visible = true;
                pnlEliminar.Visible = true;
                pnlestate.Visible = true;
                pnlFecha.Visible = true;
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
                pnlSeleccionar.Visible = false;
                pnlsurname.Visible = true;
                pnlTelefonFijo.Visible = true;
                pnlTelefonoCelular.Visible = true;
                pnlEliminar.Visible = true;
                pnlresult.Visible = false;
                pnlResultados.Visible = false;
                pnlDdlCalle.Visible = true;
                ddlCalle.SelectedValue = (calle.idCalle == null) ? "0" : calle.idCalle.ToString();
                pnlCalle.Visible = true;
                pnlBuscar.Visible = false;
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

    }
}