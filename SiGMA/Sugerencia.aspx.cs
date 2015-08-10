using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmailSend;

namespace SiGMA
{
    public partial class Sugerencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            string mensaje = "";
            mensaje += "Email: " + txtEmail.Text + "\n Nombre y Apellido: " + txtNombre.Text + "\n Telefono: " + txtTelefono.Text + "\n Sugerencia: " + txtConsulta.Text + "\n \n";
            gmail g = new gmail();
            g.fromAlias = "SIGMA"; // Si te fijás en la bandeja, aparecerá tu correo pero con nombre de remitente "ALDEA CAMPESTRE"
            g.auth("infosigmasoftware@gmail.com", "Palangana321");
            g.To = "infosigmasoftware@gmail.com"; //DESTINATARIO/s
            g.Cc = "maxitarno@gmail.com";
            g.Subject = "Sugerencia SiGMA"; //Asunto del email
            //g.attach(@"D:\DATOS USUARIO\Documents\Visual Studio 2010\Projects\AldeaCampestre\AldeaCampestre\paginaBase\images\Logo-01.png");
            g.Message = "\n" + mensaje.ToString() + "\n";// Creo que deberia ser con el reporte que hagamos en Crystal Reports
            g.Priority = 1;//Le seteas la prioridad del envío
            try
            {
                g.send();//Envía el correo
                pnlCorrecto.Visible = true;
                lblCorrecto.Text = "Muchas Gracias por su sugerencia";
                limpiarPagina();
            }
            catch (Exception ex)
            {
                lblError.Text = "Problemas al enviar la sugerencia. Disculpe las molestias";
                pnlAtento.Visible = true;
            }
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefaultDueño.aspx");
        }
    }
}