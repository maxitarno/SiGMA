using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmailSend;
using AccesoADatos;
using Herramientas;
using Entidades;

namespace SiGMA
{
    public partial class SerVoluntario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "Voluntariado"))
                        Response.Redirect("PermisoInsuficiente.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "Voluntariado"))
                        btnEnviar.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                if (Session["TipoVoluntario"].ToString() != "0")
                {
                    if (Session["pantalla"] != null && Session["pantalla"].ToString() == "Voluntario.aspx")
                    {
                        cargarCombos();
                        if (Session["cambioVoluntariado"] != null && Session["cambioVoluntariado"].ToString() == "1")
                        {
                            ddlTipoVoluntario.SelectedValue = "1";
                            ddlTipoVoluntario_SelectedIndexChanged(null, null);
                            return;
                        }
                        if (Session["cambioVoluntariado"] != null && Session["cambioVoluntariado"].ToString() == "2")
                        {
                            ddlTipoVoluntario.SelectedValue = "2";
                            ddlTipoVoluntario_SelectedIndexChanged(null, null);
                            return;
                        }
                        if (Session["cambioVoluntariado"] != null && Session["cambioVoluntariado"].ToString() == "3")
                        {
                            ddlTipoVoluntario.SelectedValue = "3";
                            ddlTipoVoluntario_SelectedIndexChanged(null, null);
                            return;
                        }
                    }
                    else 
                    {
                        if (Session["EstadoVoluntario"].ToString() == "Activo")
                            Response.Redirect("Voluntario.aspx");
                        if (Session["EstadoVoluntario"].ToString() == "Pendiente")
                        {
                            ddlTipoVoluntario.Enabled = false;
                            pnlInfo.Visible = true;
                            lblInfo.Text = "Su pedido de voluntariado se encuentra pendiente, pronto nos comunicaremos con usted";
                            return;
                        }
                        if (Session["EstadoVoluntario"].ToString() == "Solicitud Baja")
                        {
                            ddlTipoVoluntario.Enabled = false;
                            pnlInfo.Visible = true;
                            lblInfo.Text = "Su solicitud de baja esta en tramite, pronto nos comunicaremos con usted";
                            return;
                        }
                        if (Session["EstadoVoluntario"].ToString() == "Rechazado")
                        {
                            ddlTipoVoluntario.Enabled = true;
                            pnlInfo.Visible = true;
                            lblInfo.Text = "Su solicitud de voluntariado fue rechazada";
                        }
                        if (Session["EstadoVoluntario"].ToString() == "Inactivo")
                        {
                            ddlTipoVoluntario.Enabled = true;
                            pnlInfo.Visible = true;
                            lblInfo.Text = "El voluntario no se encuentra activo, pero puede solicitar voluntariado";
                        }
                    }
                }
                cargarCombos();
            }
            else
            {
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }

        public void cargarCombos() 
        {
            CargarCombos.cargarBarrio(ref ddlBarrio);
            CargarCombos.cargarBarrio(ref ddlBarrioBusqueda);
            CargarCombos.cargarCalles(ref ddlCalle);
        }
        protected void ddlTipoVoluntario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBarrio.Enabled = true;
            ddlBarrioBusqueda.Enabled = true;
            if (ddlTipoVoluntario.SelectedValue == "0")
            {
                pnlHogar.Visible = false;
                pnlBusqueda.Visible = false;
                pnlImagenBusqueda.Visible = false;
                pnlImagenHogar.Visible = false;
                pnlDatoPersona.Visible = false;
            }
            if (ddlTipoVoluntario.SelectedValue == "1")
            {
                pnlHogar.Visible = true;
                pnlBusqueda.Visible = false;
                pnlImagenBusqueda.Visible = false;
                pnlImagenHogar.Visible = true;
                pnlDatoPersona.Visible = true;
                cargarDatosHogar();
            }
            
            if (ddlTipoVoluntario.SelectedValue == "2")
            {
                pnlHogar.Visible = false;
                pnlBusqueda.Visible = true;
                pnlImagenBusqueda.Visible = true;
                pnlImagenHogar.Visible = false;
                pnlDatoPersona.Visible = true;
                cargarBarrioPersona();
            }
            if (ddlTipoVoluntario.SelectedValue == "3")
            {
                pnlHogar.Visible = true;
                pnlBusqueda.Visible = true;
                pnlImagenBusqueda.Visible = false;
                pnlImagenHogar.Visible = false;
                pnlDatoPersona.Visible = true;
                cargarDatosHogar();
                cargarBarrioPersona();
            }
        }

        private void cargarBarrioPersona()
        {
            EPersona persona = new EPersona();
            ECalle calle = new ECalle();
            EBarrio barrio = new EBarrio();
            LogicaBDUsuario.buscarPersonaPorUsuario(Session["UsuarioLogueado"].ToString(), persona, barrio, calle);
            ddlBarrioBusqueda.SelectedValue = barrio.idBarrio == null ? "0" : barrio.idBarrio.ToString();
            txtNombre.Text = persona.nombre;
            txtEmail.Text = persona.email;
            btnEnviar.Visible = true;
        }

        private void cargarDatosHogar()
        {
            EPersona persona = new EPersona();
            ECalle calle = new ECalle();
            EBarrio barrio = new EBarrio();
            LogicaBDUsuario.buscarPersonaPorUsuario(Session["UsuarioLogueado"].ToString(), persona, barrio, calle);
            txtNombre.Text = persona.nombre;
            txtEmail.Text = persona.email;
            ddlBarrio.SelectedValue = barrio.idBarrio == null ? "0" : barrio.idBarrio.ToString();
            ddlCalle.SelectedValue = calle.idCalle == null ? "0" : calle.idCalle.ToString();
            txtNro.Text = persona.nroCalle == null ? "0" : persona.nroCalle.ToString();
            btnEnviar.Visible = true;
        }



        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Session["cambioVoluntariado"] != null && Session["pantalla"] != null && Session["pantalla"].ToString() == "Voluntario.aspx")
                {
                    modificarVoluntariado();
                }
                else
                {
                    if (ddlTipoVoluntario.SelectedValue == "3")
                    {
                        LogicaBDVoluntario.RegistrarPedidoVoluntariado(Session["UsuarioLogueado"].ToString(), txtEmail.Text, txtNombre.Text, Convert.ToInt32(ddlTipoHogar.SelectedValue), Convert.ToInt32(ddlBarrio.SelectedValue), Convert.ToInt32(ddlNumeroMascotas.SelectedValue), Convert.ToInt32(ddlTipoMascota.SelectedValue), Convert.ToInt32(ddlCalle.SelectedValue), txtNro.Text, ddlTieneNinios.SelectedItem.Text, Convert.ToInt32(ddlBarrioBusqueda.SelectedValue), ddlDisponibilidadHoraria.SelectedItem.Text);
                    }
                    if (ddlTipoVoluntario.SelectedValue == "2")
                    {
                        LogicaBDVoluntario.RegistrarPedidoVoluntariado(Session["UsuarioLogueado"].ToString(), txtEmail.Text, txtNombre.Text, null, null, null, null, null, null, null, Convert.ToInt32(ddlBarrioBusqueda.SelectedValue), ddlDisponibilidadHoraria.SelectedItem.Text);
                    }
                    if (ddlTipoVoluntario.SelectedValue == "1")
                    {
                        LogicaBDVoluntario.RegistrarPedidoVoluntariado(Session["UsuarioLogueado"].ToString(), txtEmail.Text, txtNombre.Text, Convert.ToInt32(ddlTipoHogar.SelectedValue), Convert.ToInt32(ddlBarrio.SelectedValue), Convert.ToInt32(ddlNumeroMascotas.SelectedValue), Convert.ToInt32(ddlTipoMascota.SelectedValue), Convert.ToInt32(ddlCalle.SelectedValue), txtNro.Text, ddlTieneNinios.SelectedItem.Text, null, null);
                    }
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
                        Session["EstadoVoluntario"] = "Pendiente";
                        Session["TipoVoluntario"] = "1";
                        limpiarPagina();
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Problemas al enviar la solicitud. Disculpe las molestias";
                        pnlAtento.Visible = true;
                    }
                }
            }
        }

        private void modificarVoluntariado()
        {
            if (Page.IsValid)
            {
                if (ddlTipoVoluntario.SelectedValue == "3")
                {
                    if (LogicaBDVoluntario.dejarDeSerVoluntario(Convert.ToInt32(Session["IdVoluntario"].ToString())))
                        LogicaBDVoluntario.RegistrarPedidoVoluntariado(Session["UsuarioLogueado"].ToString(), txtEmail.Text, txtNombre.Text, Convert.ToInt32(ddlTipoHogar.SelectedValue), Convert.ToInt32(ddlBarrio.SelectedValue), Convert.ToInt32(ddlNumeroMascotas.SelectedValue), Convert.ToInt32(ddlTipoMascota.SelectedValue), Convert.ToInt32(ddlCalle.SelectedValue), txtNro.Text, ddlTieneNinios.SelectedItem.Text, Convert.ToInt32(ddlBarrioBusqueda.SelectedValue), ddlDisponibilidadHoraria.SelectedItem.Text);
                    else
                    {
                        lblError.Text = "Problemas al enviar la solicitud. Disculpe las molestias";
                        pnlAtento.Visible = true;
                        return;
                    }
                }
                if (ddlTipoVoluntario.SelectedValue == "2")
                {
                    if (LogicaBDVoluntario.dejarDeSerVoluntario(Convert.ToInt32(Session["IdVoluntario"].ToString())))
                    {
                        if (Session["TipoVoluntario"].ToString() == "1" || Session["TipoVoluntario"].ToString() == "3")
                        {
                            List<EMascota> provisorias = LogicaBDVoluntario.cargarDatosProvisorias(Session["UsuarioLogueado"].ToString());

                            if (provisorias.Count != 0)
                            {
                                foreach (EMascota item in provisorias)
                                {
                                    LogicaBDVoluntario.registrarSolicitudDevolucion(item.idMascota);
                                }
                                pnlInfo.Visible = true;
                                lblInfo.Text = "Nos pondremos en contacto con usted para la devolución de las mascotas provisorias";
                            }
                        }
                        LogicaBDVoluntario.RegistrarPedidoVoluntariado(Session["UsuarioLogueado"].ToString(), txtEmail.Text, txtNombre.Text, null, null, null, null, null, null, null, Convert.ToInt32(ddlBarrioBusqueda.SelectedValue), ddlDisponibilidadHoraria.SelectedItem.Text);
                    }
                    else
                    {
                        lblError.Text = "Problemas al enviar la solicitud. Disculpe las molestias";
                        pnlAtento.Visible = true;
                        return;
                    }
                }

                if (ddlTipoVoluntario.SelectedValue == "1")
                {
                    if (LogicaBDVoluntario.dejarDeSerVoluntario(Convert.ToInt32(Session["IdVoluntario"].ToString())))
                        LogicaBDVoluntario.RegistrarPedidoVoluntariado(Session["UsuarioLogueado"].ToString(), txtEmail.Text, txtNombre.Text, Convert.ToInt32(ddlTipoHogar.SelectedValue), Convert.ToInt32(ddlBarrio.SelectedValue), Convert.ToInt32(ddlNumeroMascotas.SelectedValue), Convert.ToInt32(ddlTipoMascota.SelectedValue), Convert.ToInt32(ddlCalle.SelectedValue), txtNro.Text, ddlTieneNinios.SelectedItem.Text, null, null);
                    else
                    {
                        lblError.Text = "Problemas al enviar la solicitud. Disculpe las molestias";
                        pnlAtento.Visible = true;
                        return;
                    }
                }
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
                    lblCorrecto.Text = "Pedido de cambio de voluntariado realizado. Muchas Gracias";
                    limpiarPagina();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Problemas al enviar la solicitud. Disculpe las molestias";
                    pnlAtento.Visible = true;
                }
            }
        }

        private void limpiarPagina()
        {
            pnlDatoPersona.Visible = false;
            pnlHogar.Visible = false;
            pnlBusqueda.Visible = false;
            ddlTipoVoluntario.Enabled = false;
            btnEnviar.Visible = false;
            pnlImagenBusqueda.Visible = false;
            pnlImagenHogar.Visible = false;
        }

        protected void ddlBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoVoluntario.SelectedValue == "3")
            {
                ddlBarrioBusqueda.SelectedValue = ddlBarrio.SelectedValue;
                ddlBarrioBusqueda.Enabled = false;
            }
        }

        protected void ddlBarrioBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoVoluntario.SelectedValue == "3")
            {
                ddlBarrio.SelectedValue = ddlBarrioBusqueda.SelectedValue;
                ddlBarrio.Enabled = false;
            }
        }

        protected void cvBarrioHogar_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlBarrio);
        }

        protected void cvCalle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCalle);
        }

        protected void cvNiños_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTieneNinios);
        }

        protected void cvBarrioBusqueda_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlBarrioBusqueda);
        }

        protected void cvTipoVoluntario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTipoVoluntario);
        }
    }
}