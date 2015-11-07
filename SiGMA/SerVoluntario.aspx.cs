using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmailSend;
using AccesoADatos;

namespace SiGMA
{
    public partial class SerVoluntario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoVoluntario"].ToString() != "0")
            {
                    Response.Redirect("Voluntario.aspx");
            }
        }

        protected void ddlTipoVoluntario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoVoluntario.SelectedValue == "0")
            {
                pnlHogar.Visible = false;
                pnlBusqueda.Visible = false;
            }
            if (ddlTipoVoluntario.SelectedValue == "1")
            {
                pnlHogar.Visible = true;
                pnlBusqueda.Visible = false;
            }
            
            if (ddlTipoVoluntario.SelectedValue == "2")
            {
                pnlHogar.Visible = false;
                pnlBusqueda.Visible = true;
            }
            if (ddlTipoVoluntario.SelectedValue == "3")
            {
                pnlHogar.Visible = true;
                pnlBusqueda.Visible = true;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (ddlTipoVoluntario.SelectedValue == "0")
            {
                lblInfo.Text = "Seleccione un tipo de voluntario";
                pnlInfo.Visible = true;
                return;
            }
            //CONTINUAR CON LA REGISTRACION DEL PEDIDO DE VOLUNTARIADO
            //LogicaBDVoluntario.RegistrarPedidoVoluntariado(Session["UsuarioLogueado"].ToString(), txtEmail.Text, txtNombre.Text, ddlTipoHogar.SelectedValue, ddlBarrio.SelectedValue, ddlNumeroMascotas.SelectedValue, ddlTipoMascota.SelectedValue, ddlCalle.SelectedValue, txtNro, ddlBarrioBusqueda.SelectedValue, ddlDisponibilidadHoraria.SelectedValue);
            string mensaje = "";
            mensaje += "Email: " + txtEmail.Text + "\n Nombre y Apellido: " + txtNombre.Text + "\n \n";
            if (ddlTipoVoluntario.SelectedValue == "1" || ddlTipoVoluntario.SelectedValue == "3")
            {
                mensaje += "VOLUNTARIO DE HOGAR \n Tipo Hogar: " + ddlTipoHogar.SelectedItem.Text + "\n Acepto hasta: " + ddlNumeroMascotas.SelectedValue + " mascotas provisorias \n Tipo Mascota: " + ddlTipoMascota.SelectedItem.Text + "\n \n";
            }
            if (ddlTipoVoluntario.SelectedValue == "2" || ddlTipoVoluntario.SelectedValue == "3")
            {
                mensaje += "VOLUNTARIO DE BUSQUEDA \n Disponibilidad Horaria: " + ddlDisponibilidadHoraria.SelectedItem.Text + "\n Acepto hasta: " + ddlNumeroMascotas.SelectedValue + " mascotas provisorias \n Tipo Mascota: " + ddlTipoMascota.SelectedItem.Text + "\n \n";
            }
            gmail g = new gmail();
            g.fromAlias = "SIGMA"; //  
            g.auth("infosigmasoftware@gmail.com", "Palangana321");
            g.To = "infosigmasoftware@gmail.com"; //DESTINATARIO/s
            g.Cc = "maxitarno@gmail.com";
            g.Subject = "Solicitud Voluntariado SiGMA"; //Asunto del email
            //g.attach(@"D:\DATOS USUARIO\Documents\Visual Studio 2010\Projects\AldeaCampestre\AldeaCampestre\paginaBase\images\Logo-01.png");
            g.Message = "\n" + mensaje.ToString() + "\n";// Creo que deberia ser con el reporte que hagamos en Crystal Reports
            g.Priority = 1;//Le seteas la prioridad del envío
            try
            {
                g.send();//Envía el correo
                pnlCorrecto.Visible = true;
                lblCorrecto.Text = "Solicitud enviada, nos pondremos en contacto con usted. Muchas Gracias";
                
                limpiarPagina();
            }
            catch (Exception ex)
            {
                lblError.Text = "Problemas al enviar la solicitud. Disculpe las molestias";
                pnlAtento.Visible = true;
            }
        }

        private void limpiarPagina()
        {
            throw new NotImplementedException();
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefaultDueño.aspx");
        }
    }
}