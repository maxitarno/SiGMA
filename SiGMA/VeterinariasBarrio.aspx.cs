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
    public partial class VeterinariasBarrio : System.Web.UI.Page
    {
        public EVeterinaria veterinaria;
        public List<EVeterinaria> veterinarias = new List<EVeterinaria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarBarrio(ref ddlBarrio);
            }
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefaultDueño.aspx");
        }

        protected void ddlBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            veterinaria = new EVeterinaria();
            veterinaria.domicilio = new EDomicilio();
            veterinaria.domicilio.barrio = new EBarrio();
            veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue);
            veterinarias = LogicaBDVeterinaria.BuscarPorDomicilio1(veterinaria);
            lstVeterinarias.DataSource = veterinarias;
            lstVeterinarias.DataTextField = "nombre";
            lstVeterinarias.DataValueField = "id";
            lstVeterinarias.DataBind();
        }
    }
}