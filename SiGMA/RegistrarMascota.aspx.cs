using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;

namespace SiGMA
{
    public partial class RegistrarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarColor(ref ddlColor);
                CargarCombos.cargarEspecies(ref ddlEspecie);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarCaracteresMascota(ref ddlCaracter);
            }
        }

        protected void ddlEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCombos.cargarRazas(ref ddlRaza, int.Parse(ddlEspecie.SelectedValue));
        }
       
    }
}