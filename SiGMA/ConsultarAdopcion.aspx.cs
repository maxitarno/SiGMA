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
                    lblTitulo.Text = "Modificar Hallazgo";
                }
                else
                {
                    lblTitulo.Text = "Consultar Hallazgo";
                }
                if (rbPorDNI.Checked)
                {
                    pnlBuscar.Visible = true;
                    pnlPorDocumento.Visible = true;
                    pnlPorAdopcion.Visible = false;
                }
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
        }
        public void RbPorN(object sender, EventArgs e)
        {
            pnlPorAdopcion.Visible = true;
            pnlPorDocumento.Visible = false;
            pnlBuscar.Visible = true;
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            if (rbPorNAdopcion.Checked)
            {
                List<EAdopcion> adopciones = LogicaBDAdopcion.BuscarAdopcion(int.Parse(txtNDeAdopcion.Text));
                if (adopciones.Count != 0)
                {
                    lstResultados.Items.Clear();
                    lstResultados.DataSource = adopciones;
                    lstResultados.DataTextField = "idAdopcion";
                    lstResultados.DataValueField = "idAdopcion";
                    lstResultados.DataBind();
                    pnlResultados.Visible = true;
                }
                else
                {
                    lblResultado3.Text = "No se encontraron adopciones";
                    pnlAtento.Visible = true;
                    pnlInfo.Visible = false;
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
                    lstResultados.DataTextField = "idAdopcion";
                    lstResultados.DataValueField = "idAdopcion";
                    lstResultados.DataBind();
                    pnlResultados.Visible = true;
                }
                else
                {
                    lblResultado3.Text = "No se encontraron adopciones";
                    pnlAtento.Visible = true;
                    pnlInfo.Visible = false;
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
            }
            else
            {
                lblResultado3.Text = "Debe seleccionar una adopcion";
                pnlAtento.Visible = true;
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }
    }
}