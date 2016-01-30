using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;

namespace SiGMA
{
    public partial class ValidarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnValidar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EUsuario usuario = new EUsuario();
                try
                {
                    usuario = LogicaBDUsuario.BuscarUsuarios(txtUsuario.Text).First();
                    if(txtUsuario.Text == usuario.user && txtToken.Text == usuario.token)
                    {
                        LogicaBDUsuario.ValidarUsuario(txtUsuario.Text);
                        mostrarResultado("Usuario Validado Exitosamente", true);
                    }
                    else
                        mostrarResultado("", false);
                }
                catch (Exception ex)
                {
                    mostrarResultado(ex.InnerException.Message, false);
                }
            }                 
        }

        //Metodo para mostrar un label informando alguna excepcion, el parametro sera el string de la excepcion
        private void mostrarResultado(string tipoResultado, bool b)
        {
            if (b)
            {
                txtUsuario.Text = "";
                txtToken.Text = "";
                lblCorrecto.Text = "Usuario Validado Exitosamente";
            }
            else
            {
                if(tipoResultado.ToString() == "")
                    lblError.Text = "Clave de Validación incorrecta";
                else
                    lblError.Text = tipoResultado;
            }
            pnlCorrecto.Visible = b;
            pnlAtento.Visible = !b;

        }
    }
}