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
        
public  object adopciones { get; set; }protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarTipoDocumento(ref ddlTipo);
                String mod = Request.QueryString["m"];
                if (mod == "1")
                {
                    pnlRegistrar.Visible = true;
                    lblTitulo.Text = "Modificar Adopción";
                    pnlDatos.Visible = true;
                    btnRegistrar.Visible = true;
                    btnEliminar.Visible = true;
                    pnlEliminar.Visible = true;
                }
                else
                {
                    lblTitulo.Text = "Consultar Adopción";
                    pnlDatos.Visible = false;
                    pnlRegistrar.Visible = false;
                    btnRegistrar.Visible = false;
                }
                if (rbPorDNI.Checked)
                {
                    pnlBuscar.Visible = true;
                    pnlPorDocumento.Visible = true;
                    pnlPorAdopcion.Visible = false;
                    pnlDatos.Visible = false;
                }
                if(Session["Si"] != null){
                    if(Session["Si"].Equals("Si")){
                        EPersona persona = (EPersona)Session["Dueño"];
                        EAdopcion adopcion = (EAdopcion)Session["Adopcion"];
                        txtTipoDeDocumento.Text = persona.tipoDocumento.nombre;
                        txtSexo.Text = adopcion.mascota.sexo;
                        txtRaza.Text = adopcion.mascota.raza.nombreRaza;
                        txtNro.Text = (persona.nroCalle == null) ? "0" : persona.nroCalle.ToString();
                        txtNombreM.Text = adopcion.mascota.nombreMascota;
                        txtNombreD.Text = persona.nombre;
                        txtNºAdopcion.Text = adopcion.idAdopcion.ToString();
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
                        pnlAdopcion.Visible = true;
                        pnlRegistrar.Visible = true;
                        btnRegistrar.Text = "Modificar adopcion";
                        btnEliminar.Visible = false;
                        pnlRegistrar.Visible = true;
                        pnlEliminar.Visible = false;
                    }
                }
                CargarCombos.cargarLocalidades(ref ddlLocalidad);
                ddlCalle.Items.Clear();
                ddlCalle.Items.Add(new ListItem("SIN ASIGNAR", "0"));
                ddlBarrio.Items.Clear();
                ddlBarrio.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            }
        }
        public void ibtnRegresar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Adopciones.aspx");
        }
        public void RbPorPersona(object sender, EventArgs e)
        {
            pnlBuscar.Visible = true;
            pnlPorDocumento.Visible = true;
            pnlPorAdopcion.Visible = false;
            pnlAtento.Visible = false;
            pnlInfo.Visible = false;
            pnlCorrecto.Visible = false;
            pnlResultados.Visible = false;
            pnlMascota.Visible = false;
            pnlDuenio.Visible = false;
            pnlDatos.Visible = false;
            pnlAdopcion.Visible = false;
            btnRegistrar.Text = "Generar Contrato";
            btnEliminar.Visible = false;
            pnlEliminar.Visible = false;
        }
        public void RbPorN(object sender, EventArgs e)
        {
            pnlPorAdopcion.Visible = true;
            pnlPorDocumento.Visible = false;
            pnlBuscar.Visible = true;
            pnlAtento.Visible = false;
            pnlInfo.Visible = false;
            pnlCorrecto.Visible = false;
            pnlResultados.Visible = false;
            pnlRegistrar.Visible = false;
            pnlMascota.Visible = false;
            pnlDuenio.Visible = false;
            pnlDatos.Visible = false;
            pnlAdopcion.Visible = false;
            btnRegistrar.Text = "Generar Contrato";
            btnEliminar.Visible = false;
            pnlEliminar.Visible = false;
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            if (rbPorNAdopcion.Checked)
            {
                if (Validaciones.verificarSoloNumeros(txtNDeAdopcion.Text))
                {
                    List<EAdopcion> adopciones = LogicaBDAdopcion.BuscarAdopcion(int.Parse(txtNDeAdopcion.Text));
                    if (adopciones.Count != 0)
                    {
                        lstResultados.Items.Clear();
                        lstResultados.DataSource = adopciones;
                        lstResultados.DataValueField = "idAdopcion";
                        lstResultados.DataTextField = "nombre";
                        lstResultados.DataBind();
                        pnlResultados.Visible = true;
                        pnlAtento.Visible = false;
                        pnlInfo.Visible = false;
                        pnlCorrecto.Visible = false;
                    }
                    else
                    {
                        lblResultado2.Text = "No se encontraron adopciones";
                        pnlAtento.Visible = false;
                        pnlInfo.Visible = true;
                        pnlCorrecto.Visible = false;
                    }
                }
                else
                {
                    lblResultado2.Text = "Debe ingresar un número de adopción";
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = true;
                    pnlCorrecto.Visible = false;
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
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = false;
                    pnlCorrecto.Visible = false;
                }
                else
                {
                    lblResultado2.Text = "No se encontraron adopciones";
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = true;
                    pnlCorrecto.Visible = false;
                }
            }
        }
        public void BtnSeleccionarClick(object sender, EventArgs e)
        {
            if (lstResultados.SelectedItem.Text != "")
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
                txtNºAdopcion.Text = adopcion.idAdopcion.ToString();
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
                pnlAdopcion.Visible = true;
                pnlRegistrar.Visible = true;
                if (ddlLocalidad.SelectedValue.Equals("0") && txtNombreMascota.Text == "")
                {
                    Session["Dueño"] = persona;
                    Session["Adopcion"] = adopcion;
                    Session["Mascota"] = adopcion.mascota;
                }
                else if (txtNombreMascota.Text != "" && ddlLocalidad.SelectedValue.Equals("0"))
                {
                    adopcion.mascota.nombreMascota = txtNombreMascota.Text;
                    Session["Dueño"] = persona;
                    Session["Adopcion"] = adopcion;
                    Session["Mascota"] = adopcion.mascota;
                }
                else if (!ddlLocalidad.SelectedValue.Equals("0") && txtNombreMascota.Text == "")
                {
                    persona.localidad.idLocalidad = int.Parse(ddlLocalidad.SelectedValue);
                    persona.domicilio.idCalle = int.Parse(ddlCalle.SelectedValue);
                    persona.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue);
                    Session["Dueño"] = persona;
                    Session["Adopcion"] = adopcion;
                    Session["Mascota"] = adopcion.mascota;
                }
                else
                {
                    adopcion.mascota.nombreMascota = txtNombreMascota.Text;
                    persona.localidad.idLocalidad = int.Parse(ddlLocalidad.SelectedValue);
                    persona.domicilio.idCalle = int.Parse(ddlCalle.SelectedValue);
                    persona.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue);
                    Session["Dueño"] = persona;
                    Session["Adopcion"] = adopcion;
                    Session["Mascota"] = adopcion.mascota;
                }
                Session["na"] = int.Parse(lstResultados.SelectedValue);
                btnEliminar.Visible = true;
                pnlEliminar.Visible = true;
            }
            else
            {
                lblResultado2.Text = "Debe seleccionar una adopcion";
                pnlAtento.Visible = false;
                pnlInfo.Visible = true;
                pnlCorrecto.Visible = false;
            }
        }
        public void BtnModificarClick(object sender, EventArgs e)
        {
            EMascota mascota = new EMascota();
            mascota = (EMascota)Session["Mascota"];
            if (Validaciones.verificarSoloLetras(mascota.nombreMascota))
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
                        pnlInfo.Visible = false;
                        lblResultado1.Text = "Se registro correctamente";
                        pnlCorrecto.Visible = true;
                        pnlAtento.Visible = false;
                        Session["Si"] = null;
                        pnlBuscar.Visible = true;
                        pnlDuenio.Visible = false;
                        pnlMascota.Visible = false;
                        pnlRegistrar.Visible = false;
                    }
                    else
                    {
                        pnlInfo.Visible = false;
                        lblResultado3.Text = "No se pudo registrar";
                        pnlCorrecto.Visible = false;
                        pnlAtento.Visible = true;
                    }
                }
                else
                {
                    Session["Modificar"] = "Si";
                    pnlEliminar.Visible = false;
                    btnEliminar.Visible = false;
                    Response.Redirect("Contrato.aspx");
                }
            }
            else
            {
                lblResultado2.Text = "Debe ingresar un nombre valido";
                pnlAtento.Visible = false;
                pnlInfo.Visible = true;
                pnlCorrecto.Visible = false;
            }
        }
        public void DdlBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            if (!ddlLocalidad.SelectedValue.Equals("0"))
            {
                ddlBarrio.Items.Clear();
                CargarCombos.cargarBarrio(ref ddlBarrio, int.Parse(ddlLocalidad.SelectedValue.ToString()));
                pnlInfo.Visible = false;
                ddlCalle.Items.Clear();
                CargarCombos.cargarCalles(ref ddlCalle, int.Parse(ddlLocalidad.SelectedValue.ToString()));
            }
            else
            {
                ddlCalle.Items.Clear();
                ddlCalle.Items.Add(new ListItem("SIN ASIGNAR", "0"));
                ddlBarrio.Items.Clear();
                ddlBarrio.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            }
        }
        public void BtnEliminarClick(object sender, EventArgs e)
        {
            EAdopcion adopcion = (EAdopcion)Session["Adopcion"];
            if (LogicaBDAdopcion.EliminarAdopcion(adopcion))
            {
                lblResultado1.Text = "Se elimmino correctamente";
                pnlAtento.Visible = false;
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = true;
                rbPorDNI.Checked = true;
                pnlDatos.Visible = false;
            }
            else
            {
                lblResultado3.Text = "No se pudo eliminar";
                pnlAtento.Visible = true;
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }
    }
}