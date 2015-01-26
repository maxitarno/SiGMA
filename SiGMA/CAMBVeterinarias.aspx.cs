using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;
namespace SiGMA
{
    public partial class CAMBVeterinarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Veterinarias.aspx");
        }
        public void selectedIndexChange(object sender, EventArgs e)
        {
            CargarCombos.cargarBarrio(ref ddlBarrio, int.Parse(ddlLocalidad.SelectedValue.ToString());

        }
    }
}