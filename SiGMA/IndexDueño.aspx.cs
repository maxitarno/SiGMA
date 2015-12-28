using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiGMA
{
    public partial class IndexDueño : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["EsRol"] != null)
                {
                    if (Session["EsRol"].ToString() == "3")
                        Response.Redirect("SeleccionIndex.aspx");
                    if (Session["EsRol"].ToString() == "1")
                        Response.Redirect("Default.aspx");
                }
            }
        }
    }
}