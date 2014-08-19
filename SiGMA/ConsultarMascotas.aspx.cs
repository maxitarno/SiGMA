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
    public partial class ConsultarMascotasaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<EEstados> estados = new List<EEstados>();
                estados = Datos.BuscarEstados();
                ddlEstado.DataSource = estados;
                ddlEstado.DataTextField = "nombreEstado";
                ddlEstado.DataValueField = "idEstado";
                ddlEstado.DataBind();
                List<EColor> colores = new List<EColor>();
                colores = Datos.BuscarColores();
                ddlColor.DataSource = colores;
                ddlColor.DataTextField = "nombreColor";
                ddlColor.DataValueField = "idColor";
                ddlColor.DataBind();
            }
        }
    }
}