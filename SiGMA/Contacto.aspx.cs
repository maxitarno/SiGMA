using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmailSend;
using Herramientas;

namespace SiGMA
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                }
                else
                {
                    Response.Redirect("IndexDueño.aspx");
                }
            }
            else
            {
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }

        private void limpiarPagina() 
        {
            txtConsulta.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string mensaje = "";
                mensaje += "Email: " + txtEmail.Text + "\n Nombre y Apellido: " + txtNombre.Text + "\n Telefono: " + txtTelefono.Text + "\n Observaciones: " + txtConsulta.Text + "\n \n";
                gmail g = new gmail();
                g.fromAlias = "SIGMA"; //  
                g.auth("infosigmasoftware@gmail.com", "Palangana321"); 
                g.To = "infosigmasoftware@gmail.com"; //DESTINATARIO/s
                g.Cc = "maxitarno@gmail.com";
                g.Subject = "Solicitud de Contacto"; //Asunto del email
                //g.attach(@"C:\Users\maxitarno\Desktop\PRUEBA 1\SiGMA\base\img\logoSigma.png"); //imagen a enviar
                g.Message = "\n" + mensaje.ToString() + "\n";
                g.Priority = 1;//Le seteas la prioridad del envío
                try
                {
                    g.send();//Envía el correo
                    pnlCorrecto.Visible = true;
                    lblCorrecto.Text = "Nos contactaremos con usted a la brevedad. Muchas Gracias";
                    limpiarPagina();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Problemas al enviar el email. Disculpe las molestias";
                    pnlAtento.Visible = true;
                }
            }
        }

        protected void cvNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloLetras(txtNombre.Text);
        }

        protected void cvTelefono_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtTelefono.Text);
        }

        
    }
}