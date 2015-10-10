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
                EUsuario usuario2 = new EUsuario();
                usuario2 = LogicaBDUsuario.BuscarUsuarios(login.UserName).First();
                if(String.IsNullOrEmpty(usuario2.token))
                {
                    Session["UsuarioLogueado"] = usuario.user;
                    Session["IdDueño"] = LogicaBDDueño.buscarIdDueñoPorUsuario(usuario.user).ToString();
                    Session["IdVoluntario"] = LogicaBDVoluntario.buscarIdVoluntarioPorUsuario(usuario.user).ToString();
                    Session["EsRol"] = LogicaBDRol.verRolesSegunUsuario(usuario.user);
                    //aca hay que verificar el rol, HACER!!!!
                    HttpCookie cook = new HttpCookie("idDueño");
                    cook.Value = Session["IdDueño"].ToString();
                    cook.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cook);

                    e.Authenticated = true;
                }
                else
                {
                    e.Authenticated = false;
                }  
            }
            else
            {
                e.Authenticated = false;
            }   
        }

   }
}
