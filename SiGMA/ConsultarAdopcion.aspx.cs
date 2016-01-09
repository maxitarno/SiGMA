using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Herramientas;
using AccesoADatos;
namespace SiGMA
{
    public partial class ConsultarAdopcion : System.Web.UI.Page
    {
        EMascota mascota = null;
        public  object adopciones { get; set; }protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "ConsultarAdopcion.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "ConsultarAdopcion.aspx"))
                        btnRegistrar.Visible = false;
                    if (!LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "ConsultarAdopcion.aspx"))
                        btnEliminar.Visible = false;
                }
                CargarCombos.cargarTipoDocumento(ref ddlTipo);
                String mod = Request.QueryString["m"];
                if (mod == "1")
                {
                    lblTitulo.Text = "Modificar Adopción /";
                    pnlRegistrar.Visible = true;
                    if (Session["Si"] != null && Session["Si"].ToString().Equals("Si"))
                    {
                        pnlRegistrar.Visible = true;
                    }
                }
                else
                {
                    lblTitulo.Text = "Consultar Adopción /";
                    pnlDatos.Visible = false;
                    pnlRegistrar.Visible = false;
                    pnlEliminar.Visible = false;
                    txtNº.Text = "";
                    pnlBuscar.Visible = true;
                    pnlPorDocumento.Visible = true;
                    pnlBuscar.Visible = true;
                    pnlDuenio.Visible = false;
                    pnlMascota.Visible = false;
                }
                if (rbPorDNI.Checked)
                {
                    txtNº.Text = "";
                    pnlBuscar.Visible = true;
                    pnlPorDocumento.Visible = true;
                }
                if (Session["Si"] != null)
                {
                    if (Session["Si"].Equals("Si"))
                    {
                        EPersona persona = (EPersona)Session["Dueño"];
                        EAdopcion adopcion = (EAdopcion)Session["Adopcion"];
                        txtTipoDeDocumento.Text = persona.tipoDocumento.nombre;
                        txtSexo.Text = adopcion.mascota.sexo;
                        txtRaza.Text = adopcion.mascota.raza.nombreRaza;
                        txtNro.Text = (persona.nroCalle == null) ? "0" : persona.nroCalle.ToString();
                        txtNombreM.Text = adopcion.mascota.nombreMascota;
                        txtNombreD.Text = persona.nombre;
                        txtApellidoD.Text = persona.apellido;
                        txtNumeroDocumento.Text = persona.nroDocumento;
                        txtNro.Text = persona.nroCalle.ToString();
                        txtNº.Text = persona.nroDocumento;
                        txtLocalidad.Text = persona.localidad.nombre;
                        txtEspecie.Text = adopcion.mascota.especie.nombreEspecie;
                        txtEdad.Text = adopcion.mascota.edad.nombreEdad;
                        txtCalle.Text = persona.domicilio.nombre;
                        txtBarrio.Text = persona.barrio.nombre;
                        pnlResultados.Visible = false;
                        pnlPorDocumento.Visible = false;
                        pnlPorAdopcion.Visible = false;
                        pnlMascota.Visible = true;
                        pnlDuenio.Visible = true;
                        pnlBuscar.Visible = false;
                        pnlRegistrar.Visible = true;
                        btnRegistrar.Text = "Guardar Cambios";
                        pnlRegistrar.Visible = true;
                        pnlDatos.Visible = false;
                        pnlbotones.Visible = true;
                        pnlEliminar.Visible = false;
                        btnRegistrar.Focus();
                    }
                }
                CargarCombos.cargarBarrio(ref ddlBarrio, 1);
                CargarCombos.cargarCalles( ref ddlCalle, 1);

            }
            else
            {
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }

        public void RbPorPersona(object sender, EventArgs e)
        {
            pnlBuscar.Visible = true;
            pnlPorDocumento.Visible = true;
            pnlPorAdopcion.Visible = false;
            pnlResultados.Visible = false;
            pnlMascota.Visible = false;
            pnlDuenio.Visible = false;
            pnlDatos.Visible = false;
            pnlbotones.Visible = false;
            btnRegistrar.Text = "Generar Contrato";
            pnlEliminar.Visible = false;
            pnlRegistrar.Visible = false;
            txtNº.Text = "";
            txtNombre.Text = "";
            btnBuscar.Visible = true;
        }
        public void RbPorN(object sender, EventArgs e)
        {
            pnlPorAdopcion.Visible = true;
            pnlPorDocumento.Visible = false;
            pnlBuscar.Visible = true;
            pnlResultados.Visible = false;
            pnlRegistrar.Visible = false;
            pnlMascota.Visible = false;
            pnlDuenio.Visible = false;
            pnlDatos.Visible = false;
            pnlbotones.Visible = false;
            btnRegistrar.Text = "Generar Contrato";
            pnlEliminar.Visible = false;
            txtNº.Text = "";
            txtNombre.Text = "";
            btnBuscar.Visible = true;
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            if (rbPorNombreMascota.Checked)
            {
                    List<EAdopcion> adopciones = LogicaBDAdopcion.BuscarAdopcion(txtNombre.Text);
                    if (adopciones.Count != 0)
                    {
                        lstResultados.Items.Clear();
                        lstResultados.DataSource = adopciones;
                        lstResultados.DataValueField = "idAdopcion";
                        lstResultados.DataTextField = "nombre";
                        lstResultados.DataBind();
                        pnlResultados.Visible = true;
                        pnlRegistrar.Visible = false;
                        if (adopciones.Count == 1)
                        {
                            lstResultados.SelectedIndex = 0;
                            lstResultados_SelectedIndexChanged(null, null);
                        }
                    }
                    else
                    {
                        lblInfo.Text = "No se encontraron adopciones";
                        pnlInfo.Visible = true;

                    }
            }
            if (rbPorDNI.Checked)
            {
                List<EAdopcion> adopciones = LogicaBDAdopcion.BuscarAdopcion(int.Parse(ddlTipo.SelectedValue), txtNº.Text);
                if (adopciones.Count != 0)
                {
                    lstResultados.Items.Clear();
                    lstResultados.DataSource = adopciones;
                    lstResultados.DataTextField = "nombre";
                    lstResultados.DataValueField = "idAdopcion";
                    lstResultados.DataBind();
                    pnlResultados.Visible = true;
                    if (adopciones.Count == 1)
                    {
                        lstResultados.SelectedIndex = 0;
                        lstResultados_SelectedIndexChanged(null, null);
                    }
                }
                else
                {
                    lblInfo.Text = "No se encontraron adopciones";
                    pnlInfo.Visible = true;
                    pnlRegistrar.Visible = false;
                }
            }
        }
        public void BtnModificarClick(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if(Session["Mascota"] != null)
                    mascota = (EMascota)Session["Mascota"];
                if (mascota != null && Validaciones.verificarSoloLetras(mascota.nombreMascota))
                {
                    if (Session["Si"] != null && Session["Si"].ToString().Equals("Si"))
                    {
                        EAdopcion adopcion = new EAdopcion();
                        adopcion = (EAdopcion)Session["Adopcion"];
                        adopcion.idVoluntario = int.Parse(Session["IdVoluntario"].ToString());
                        adopcion.fecha = DateTime.Parse(DateTime.Now.ToShortDateString());
                        EPersona persona = new EPersona();
                        persona = (EPersona)Session["Dueño"];
                        if (LogicaBDAdopcion.ModificarAdopcion(adopcion, persona))
                        {
                            txtNº.Text = "";
                            pnlBuscar.Visible = true;
                            pnlPorDocumento.Visible = true;
                            lblCorrecto.Text = "Cambios guardados correctamente";
                            pnlCorrecto.Visible = true;
                            Session["Si"] = null;
                            pnlBuscar.Visible = true;
                            pnlDuenio.Visible = false;
                            pnlMascota.Visible = false;
                            pnlRegistrar.Visible = false;
                            pnlDatos.Visible = false;
                            pnlbotones.Visible = false;
                            mascota = null;
                            Session["na"] = -1;
                        }
                        else
                        {
                            lblError.Text = "No se pudo registrar";
                            pnlAtento.Visible = true;
                            //txtNº.Text = "";
                            //pnlBuscar.Visible = true;
                            //pnlPorDocumento.Visible = true;
                            //Session["Si"] = null;
                            //pnlBuscar.Visible = true;
                            //pnlDuenio.Visible = false;
                            //pnlMascota.Visible = false;
                            //pnlRegistrar.Visible = false;
                            //pnlDatos.Visible = false;
                            //mascota = null;
                            //Session["na"] = -1;
                        }
                    }
                    else
                    {
                        EAdopcion adopcion = new EAdopcion();
                        EPersona persona = new EPersona();
                        adopcion = (EAdopcion)Session["Adopcion"];
                        persona = (EPersona)Session["Dueño"];
                        if (ddlBarrio.SelectedValue.Equals("0") && txtNombreMascota.Text == "" && txtNºCalle.Text == "" && ddlCalle.SelectedValue.Equals("0"))
                        {
                            Session["Dueño"] = persona;
                            Session["Adopcion"] = adopcion;
                            Session["Mascota"] = adopcion.mascota;
                            Session["Modificar"] = "Si";
                            pnlEliminar.Visible = false;
                            Response.Redirect("Contrato.aspx");
                        }
                        else if (txtNombreMascota.Text != "" && ddlBarrio.SelectedValue.Equals("0") && txtNºCalle.Text == "" && ddlCalle.SelectedValue.Equals("0"))
                        {
                            adopcion.mascota.nombreMascota = txtNombreMascota.Text;
                            Session["Dueño"] = persona;
                            Session["Adopcion"] = adopcion;
                            Session["Mascota"] = adopcion.mascota;
                            Session["Modificar"] = "Si";
                            pnlEliminar.Visible = false;
                            Response.Redirect("Contrato.aspx");
                        }
                        else if (!ddlBarrio.SelectedValue.Equals("0") && txtNombreMascota.Text == "" || !ddlCalle.SelectedValue.Equals("0") && txtNombreMascota.Text == "" || txtNºCalle.Text != "" && txtNombreMascota.Text == "")
                        {
                            if (!ddlBarrio.SelectedValue.Equals("0") || !ddlCalle.SelectedValue.Equals("0") || txtNºCalle.Text == "")
                            {
                                persona.nroCalle = (txtNºCalle.Text == "") ? 0 : (int)int.Parse(txtNºCalle.Text);
                                persona.localidad.nombre = "CORDOBA CAPITAL";
                                persona.barrio.nombre = ddlBarrio.SelectedItem.Text;
                                persona.domicilio.nombre = ddlCalle.SelectedItem.Text;
                                persona.localidad.idLocalidad = 1;
                                persona.domicilio.idCalle = int.Parse(ddlCalle.SelectedValue);
                                persona.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue);
                                Session["Dueño"] = persona;
                                Session["Adopcion"] = adopcion;
                                Session["Mascota"] = adopcion.mascota;
                                Session["Modificar"] = "Si";
                                pnlEliminar.Visible = false;
                                Response.Redirect("Contrato.aspx");
                            }
                            else
                            {
                                pnlInfo.Visible = true;
                                lblInfo.Text = "Complete los datos del domicilio";
                            }
                        }
                        else 
                        {
                            adopcion.mascota.nombreMascota = txtNombreMascota.Text;
                            persona.localidad.idLocalidad = 1;
                            persona.domicilio.idCalle = int.Parse(ddlCalle.SelectedValue);
                            persona.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue);
                            persona.localidad.nombre = "CORDOBA CAPITAL";
                            persona.barrio.nombre = ddlBarrio.SelectedItem.Text;
                            persona.domicilio.nombre = ddlCalle.SelectedItem.Text;
                            persona.nroCalle = (txtNºCalle.Text == "") ? 0 : (int)int.Parse(txtNºCalle.Text);
                            Session["Dueño"] = persona;
                            Session["Adopcion"] = adopcion;
                            Session["Mascota"] = adopcion.mascota;
                            Session["Modificar"] = "Si";
                            pnlEliminar.Visible = false;
                            Response.Redirect("Contrato.aspx");
                        }
                    }
                }
                else
                {
                    lblInfo.Text = "Debe ingresar un nombre valido";
                    pnlInfo.Visible = true;
                }
            }
        }

        public void BtnEliminarClick(object sender, EventArgs e)
        {
            EAdopcion adopcion = (EAdopcion)Session["Adopcion"];
            if (LogicaBDAdopcion.EliminarAdopcion(adopcion))
            {
                lblCorrecto.Text = "Se elimino correctamente";
                pnlAtento.Visible = false;
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = true;
                txtNº.Text = "";
                pnlBuscar.Visible = true;
                pnlPorDocumento.Visible = true;
                pnlBuscar.Visible = true;
                pnlDuenio.Visible = false;
                pnlMascota.Visible = false;
                pnlRegistrar.Visible = false;
                pnlDatos.Visible = false;
                pnlEliminar.Visible = false;
                btnBuscar.Visible = true;
                pnlPorAdopcion.Visible = false;
                rbPorDNI.Checked = true;
            }
            else
            {
                lblError.Text = "No se pudo eliminar";
                pnlAtento.Visible = true;
                pnlCorrecto.Visible = false;
                pnlEliminar.Visible = false;
            }
        }
        protected void lstResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            EAdopcion adopcion = new EAdopcion();
            EPersona persona = new EPersona();
            adopcion.idAdopcion = int.Parse(lstResultados.SelectedValue);
            LogicaBDAdopcion.BuscarAdopcion(adopcion, persona);
            txtTipoDeDocumento.Text = persona.tipoDocumento.nombre;
            txtSexo.Text = adopcion.mascota.sexo;
            txtRaza.Text = adopcion.mascota.raza.nombreRaza;
            txtNro.Text = (persona.nroCalle == null) ? "0" : persona.nroCalle.ToString();
            txtNombreM.Text = adopcion.mascota.nombreMascota;
            txtNombreD.Text = persona.nombre;
            txtApellidoD.Text = persona.apellido;
            txtNumeroDocumento.Text = persona.nroDocumento;
            txtNº.Text = persona.nroDocumento;
            txtLocalidad.Text = persona.localidad.nombre;
            txtEspecie.Text = adopcion.mascota.especie.nombreEspecie;
            txtEdad.Text = adopcion.mascota.edad.nombreEdad;
            txtCalle.Text = persona.domicilio.nombre;
            txtBarrio.Text = persona.barrio.nombre;
            pnlMascota.Visible = true;
            pnlDuenio.Visible = true;
            pnlRegistrar.Visible = true;
            Session["Dueño"] = persona;
            Session["Adopcion"] = adopcion;
            Session["Mascota"] = adopcion.mascota;
            Session["na"] = int.Parse(lstResultados.SelectedValue);
            pnlDatos.Visible = true;
            pnlbotones.Visible = true;
            if(lblTitulo.Text.Equals("Consultar Adopción /")){
                pnlDatos.Visible = false;
                pnlRegistrar.Visible = false;
                pnlEliminar.Visible = false;
            }
            if(lblTitulo.Text.Equals("Modificar Adopción /")){
                btnRegistrar.Text = "Generar Contrato";
                pnlRegistrar.Visible = true;
                pnlEliminar.Visible = true;
            }
            pnlPorDocumento.Visible = false;
            pnlPorAdopcion.Visible = false;
            pnlResultados.Visible = false;
            pnlBuscar.Visible = false;
            btnBuscarOtro.Focus();
        }
        protected void ibtnBuscarOtro_Click(object sender, EventArgs args)
        {
            pnlBuscar.Visible = true;
            pnlPorDocumento.Visible = true;
            pnlPorAdopcion.Visible = false;
            pnlResultados.Visible = false;
            pnlMascota.Visible = false;
            pnlDuenio.Visible = false;
            pnlDatos.Visible = false;
            pnlbotones.Visible = false;
            btnRegistrar.Text = "Generar Contrato";
            pnlEliminar.Visible = false;
            pnlRegistrar.Visible = false;
            txtNº.Text = "";
            txtNombre.Text = "";
            rbPorDNI.Checked = true;
        }
    }
}