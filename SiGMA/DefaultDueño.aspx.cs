using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiGMA
{
    public partial class DefaultDueño : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["EsRol"] != null)
                {
                    if (Session["EsRol"].ToString() == "1")
                        Response.Redirect("Default.aspx");
                }
                if (Session["TipoVoluntario"].ToString() != "0")
                {
                    if (Session["TipoVoluntario"].ToString() == "1")
                        lblVoluntario.Text = "VOL. HOGAR";
                    if (Session["TipoVoluntario"].ToString() == "2")
                        lblVoluntario.Text = "VOL. BUSQUEDA";
                    if (Session["TipoVoluntario"].ToString() == "3")
                        lblVoluntario.Text = "VOL. BUSQ/HOGAR";
                }
            }
        }
    }
}