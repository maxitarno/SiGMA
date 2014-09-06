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
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.login.Focus();
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Inicio.aspx");
            }   
        }

        protected void login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            EUsuario usuario = new EUsuario();
            usuario.user = login.UserName;
            usuario.password = login.Password;
            if (LogicaBDLogin.esUsuario(usuario))
            {
                Session["UsuarioLogueado"] = usuario.user;
                //aca hay que verificar el rol, HACER!!!!
                HttpCookie cook = new HttpCookie("idDueño");
                cook.Value = LogicaBDUsuario.buscarIdDueñoPorUsuario(usuario.user).ToString();
                cook.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cook);
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }   
        }

   }
}
