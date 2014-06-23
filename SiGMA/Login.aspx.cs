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

        }

        protected void login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            EUsuario usuario = new EUsuario();
            usuario.user = login.UserName;
            usuario.password = login.Password;
            if (LogicaBDLogin.esUsuario(usuario))
            {
                LogicaBDLogin.obtenerRol(usuario);
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}
