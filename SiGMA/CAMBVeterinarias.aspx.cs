using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;
using AccesoADatos;
using Entidades;
namespace SiGMA
{
    public partial class CAMBVeterinarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarLocalidades(ref ddlLocalidad);
            }
        }
        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Veterinarias.aspx");
        }
        public void selectedIndexChange(object sender, EventArgs e)
        {
            CargarCombos.cargarBarrio(ref ddlBarrio, int.Parse(ddlLocalidad.SelectedValue.ToString()));
            CargarCombos.cargarCalles(ref ddlCalle, int.Parse(ddlLocalidad.SelectedValue.ToString()));
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            EVeterinaria veterinaria = new EVeterinaria();
            veterinaria.domicilio = new EDomicilio();
            veterinaria.domicilio.barrio = new EBarrio();
            veterinaria.domicilio.calle = new ECalle();
            if (rbPorNombre.Checked)
            {
                lstResultados.Items.Clear();
                lstResultados.DataSource = LogicaBDVeterinaria.BuscarPorNombre(txtNombre.Text);
                lstResultados.DataValueField = "id";
                lstResultados.DataTextField = "nombre";
                lstResultados.DataBind();
            }
            else
            {
                if (!ddlBarrio.SelectedValue.Equals("0") && !ddlCalle.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue.ToString());
                    veterinaria.domicilio.calle.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
                }
                else if (!ddlBarrio.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue.ToString());
                }
                else if (!ddlCalle.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.calle.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
                }
                lstResultados.Items.Clear();
                lstResultados.DataSource = LogicaBDVeterinaria.BuscarPorDomicilio(veterinaria);
                lstResultados.DataValueField = "id";
                lstResultados.DataTextField = "nombre";
                lstResultados.DataBind();
            }
        }
        public void selected(object sender, EventArgs e)
        {
            EVeterinaria veterinaria = new EVeterinaria();
            veterinaria.id = int.Parse(lstResultados.SelectedValue.ToString());
            LogicaBDVeterinaria.Buscar(veterinaria);
            txtNombre.Text = veterinaria.nombre;
            ddlLocalidad.SelectedValue = veterinaria.domicilio.barrio.localidad.idLocalidad.ToString();
            ddlBarrio.SelectedValue = veterinaria.domicilio.barrio.idBarrio.ToString();
            ddlCalle.SelectedValue = veterinaria.domicilio.calle.idCalle.ToString();
            chkCastraciones.Checked = veterinaria.castraciones;
            chkMedicinas.Checked = veterinaria.medicina;
            chkPeluqueria.Checked = veterinaria.peluqueria;
            chkPetShop.Checked = veterinaria.petshop;
            txtContacto.Text = veterinaria.contacto;
            txtTE.Text = veterinaria.telefono;
        }
    }
}