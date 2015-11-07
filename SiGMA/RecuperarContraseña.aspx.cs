using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;
using GmailSend;

namespace SiGMA
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtEmail != null)
                    {
                        string mensaje = "";
                        EUsuario usuario = new EUsuario();
                        usuario = LogicaBDUsuario.BuscarUsuarioPorEmail(txtEmail.Text).Count != 0 ? LogicaBDUsuario.BuscarUsuarioPorEmail(txtEmail.Text).First() : null;
                        if (usuario == null)
                            mostrarResultado("Email no registrado", false);
                        else
                        {
                            mensaje += "RESTABLECER CONTRASEÑA \n \n Usuario: " + usuario.user.ToString() + "\n Clave temporal: " + usuario.password.ToString() + "\n Utilice la clave temporal para ingresar a SiGMA \n Luego, modifique la misma por una que sea de su agrado desde 'MiPerfil' \n\n Gracias por elegirnos \n SiGMA";
                            gmail g = new gmail();
                            g.fromAlias = "SIGMA"; //  
                            g.auth("infosigmasoftware@gmail.com", "Palangana321");
                            g.To = txtEmail.Text; //DESTINATARIO/s
                            g.Cc = "maxitarno@gmail.com";
                            g.Subject = "Restablecer Contraseña"; //Asunto del email
                            //g.attach(@"D:\DATOS USUARIO\Documents\Visual Studio 2010\Projects\AldeaCampestre\AldeaCampestre\paginaBase\images\Logo-01.png");
                            g.Message = "\n" + mensaje.ToString() + "\n";// Creo que deberia ser con el reporte que hagamos en Crystal Reports
                            g.Priority = 1;//Le seteas la prioridad del envío
                            try
                            {
                                g.send();//Envía el correo
                                pnlCorrecto.Visible = true;
                            }
                            catch (Exception ex)
                            {
                                lblError.Text = "Problemas al enviar el email. Disculpe las molestias";
                                pnlAtento.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        mostrarResultado("Email no registrado", false);
                    }
                }
                catch (Exception ex)
                {
                    mostrarResultado(ex.InnerException.Message, false);
                }
            }                 
        }

        private void mostrarResultado(string tipoResultado, bool b)
        {
            if (b)
            {
                txtEmail.Text = "";
            }
            else
            {
                lblError.Text = tipoResultado;
            }
            pnlCorrecto.Visible = b;
            pnlAtento.Visible = !b;
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}