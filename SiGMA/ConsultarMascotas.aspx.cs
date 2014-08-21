using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using Herramientas;
namespace SiGMA
{
    public partial class ConsultarMascotasaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarColor(ref ddlColor);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarEspecies(ref ddlEspecie);
                CargarCombos.cargarComboRazas(ref ddlRaza);
            }
        }
        public void ddlRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ERaza> razas = new List<ERaza>();
            int aux = int.Parse(ddlEspecie.SelectedValue);
            razas = Datos.BuscarRazas(aux);
            ddlRaza.DataSource = razas;
            ddlRaza.DataTextField = "nombreRaza";
            ddlRaza.DataValueField = "idRaza";
            ddlRaza.DataBind();
        }
    }
}