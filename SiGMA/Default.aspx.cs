using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiGMA
{
    public partial class Default : System.Web.UI.Page
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
                    if (Session["EsRol"].ToString() == "3")
                        Response.Redirect("SeleccionDefault.aspx");
                    if (Session["EsRol"].ToString() == "2")
                        Response.Redirect("DefaultDueño.aspx");
                }
            }
        }
    }
}