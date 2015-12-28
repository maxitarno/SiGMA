using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
namespace SiGMA
{
    public partial class Graficos : System.Web.UI.Page
    {
        int hogar = 0;
        int busqueda = 0;
        int ambos = 0;
        int no = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Informes.aspx");
        }

        protected void ddlListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlListado.SelectedValue.ToString() == "1")
            {
                LogicaBDGraficos.BuscarUsuarios(hogar, busqueda, ambos, no);
                hfHogar.Value = hogar.ToString();
                hfNo.Value = no.ToString();
                hfBusqueda.Value = busqueda.ToString();
                hfAmbos.Value = ambos.ToString();
            }
        }
    }
}