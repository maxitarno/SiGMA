using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using Herramientas;

namespace SiGMA
{
    public partial class Voluntario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoVoluntario"].ToString() != "0")
            {
                if (Session["VoluntarioCargado"] != null && Session["VoluntarioCargado"].ToString() == "True")
                {
                    if (Session["idMascota"] != null && Session["pantalla"].ToString() == "Voluntario.aspx")
                    {
                        cargarDatosPagina();
                    }
                }
                else
                {
                    cargarDatosPagina();
                }
            }
            else 
            {
                Response.Redirect("SerVoluntario.aspx");
            }
        }

        private void cargarDatosPagina()
        {
            CargarCombos.cargarEspecies(ref ddlEspecieHogar);
            CargarCombos.cargarEspecies(ref ddlEspeciePerdida);
            CargarCombos.cargarComboRazas(ref ddlRazaHogar);
            CargarCombos.cargarComboRazas(ref ddlRazaPerdida);
            CargarCombos.cargarBarrio(ref ddlBarrio);
            CargarCombos.cargarBarrio(ref ddlBarrioBusqueda);
            CargarCombos.cargarCalles(ref ddlCalle);

            if (Session["TipoVoluntario"].ToString() == "1")
            {
                pnlHogar.Visible = true;
                cargarDatosHogar(); //cargar los datos del hogar del usuario logueado
                cargarComboMisProvisorias(); //cargar el combo con las mascotas provisorias que tiene
                verificarEstadoVoluntario(); //chequea que el voluntario no este con solucitud de baja / inactivo / etc
                Session["VoluntarioCargado"] = true;
            }
            else if (Session["TipoVoluntario"].ToString() == "2")
            {
                pnlBusqueda.Visible = true;
                cargarDatosBusqueda(); //cargar los datos de la dispoibilidad del usuario logueado
                cargarComboPerdidasBarrio(); //cargar el combo con las mascotas perdidas en el barrio del usuario logueado
                verificarEstadoVoluntario(); //chequea que el voluntario no este con solucitud de baja / inactivo / etc
                Session["VoluntarioCargado"] = true;
            }
            else if (Session["TipoVoluntario"].ToString() == "3")
            {
                pnlHogar.Visible = true;
                pnlBusqueda.Visible = true;
                cargarDatosHogar(); //cargar los datos del hogar del usuario logueado
                cargarComboMisProvisorias(); //cargar el combo con las mascotas provisorias que tiene
                cargarDatosBusqueda(); //cargar los datos de la dispoibilidad del usuario logueado
                cargarComboPerdidasBarrio(); //cargar el combo con las mascotas perdidas en el barrio del usuario logueado
                verificarEstadoVoluntario(); //chequea que el voluntario no este con solucitud de baja / inactivo / etc
                Session["VoluntarioCargado"] = true;
            }
        }

        private void verificarEstadoVoluntario()
        {
            EVoluntario voluntario = LogicaBDVoluntario.buscarVoluntarioPorId(Convert.ToInt32(Session["IdVoluntario"].ToString()));
            if(voluntario.idEstado == LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Activo", ambito = "Voluntario" }).idEstado)
            {
                pnlDejarDeSer.Visible = true;
            }
            else
            {
                pnlHogar.Visible = false;
                pnlBusqueda.Visible = false;
                pnlInfo.Visible = true;
                lblInfo.Text = "El voluntario no se encuentra activo, pero puede solicitar voluntariado";
            }

        }

        private void cargarComboPerdidasBarrio()
        {
            if (ddlBarrioBusqueda.SelectedValue != "0")
            {
                List<EPerdida> perdidas = LogicaBDVoluntario.cargarPerdidasBarrioVoluntario(ddlBarrioBusqueda.SelectedItem.Text);
                if (perdidas != null)
                {
                    ddlBusquedasMascota.Enabled = true;
                    foreach (EPerdida item in perdidas)
                    {
                        ddlBusquedasMascota.Items.Add(new ListItem(item.mascota.nombreMascota.ToString(), item.mascota.idMascota.ToString()));
                    }
                    ddlBusquedasMascota_SelectedIndexChanged(null, null);
                }
                else 
                {
                    ddlBusquedasMascota.Items.Insert(0, "No hay perdidas en el barrio");
                    ddlBusquedasMascota.Enabled = false;
                }
            }
            else
            {
                ddlBusquedasMascota.Items.Insert(0, "No hay barrio seleccionado");
                ddlBusquedasMascota.Enabled = false;
            }
        }

        private void cargarDatosBusqueda()
        {
            EPersona persona = new EPersona();
            EBarrio barrio = new EBarrio();
            LogicaBDVoluntario.cargarDatosBusqueda(Session["UsuarioLogueado"].ToString(), persona, barrio);
            txtNombre.Text = persona.nombre;
            txtEmail.Text = persona.email;
            ddlBarrioBusqueda.SelectedValue = barrio.idBarrio == null ? null : barrio.idBarrio.ToString();
        }

        private void cargarComboMisProvisorias()
        {
            List<EMascota> provisorias = LogicaBDVoluntario.cargarDatosProvisorias(Session["UsuarioLogueado"].ToString());
            if (provisorias.Count != 0)
            {
                ddlMascotasEnHogar.Enabled = true;
                foreach (EMascota item in provisorias)
                {
                    ddlMascotasEnHogar.Items.Add(new ListItem(item.nombreMascota.ToString(), item.idMascota.ToString()));
                }
                ddlMascotasEnHogar_SelectedIndexChanged(null, null);
            }
            else 
            {
                ddlMascotasEnHogar.Items.Insert(0, "Sin Mascotas en el Hogar");
                ddlMascotasEnHogar.Enabled = false;
            }
        }

        private void cargarDatosHogar()
        {
           EPersona persona = new EPersona();
           EHogarProvisorio hogar = new EHogarProvisorio();
           ECalle calle = new ECalle();
           EBarrio barrio = new EBarrio();
           LogicaBDVoluntario.cargarDatosHogarProvisorio(Session["UsuarioLogueado"].ToString(), persona, hogar, calle, barrio);
           txtNombre.Text = persona.nombre;
           txtEmail.Text = persona.email;
           ddlTipoHogar.SelectedValue = hogar.tipoHogar.ToString();
           ddlCalle.SelectedValue = calle.idCalle == null ? null : calle.idCalle.ToString();
           txtNro.Text = persona.nroCalle.ToString();
           ddlBarrio.SelectedValue = barrio.idBarrio == null ? null : barrio.idBarrio.ToString();
           ddlNumeroMascotas.SelectedValue = hogar.cantMascotas.ToString();
           ddlTipoMascota.SelectedValue = hogar.AceptaEspecie.ToString();
           ddlTieneNinios.SelectedValue = hogar.tieneNiños.ToString() == "Si" ? "1" : "2"; 
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefaultDueño.aspx");
        }

        protected void ddlMascotasEnHogar_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<EMascota> provisorias = LogicaBDVoluntario.cargarDatosProvisorias(Session["UsuarioLogueado"].ToString());
            foreach (EMascota item in provisorias)
            {
                if (ddlMascotasEnHogar.SelectedValue == item.idMascota.ToString()) 
                {
                    txtMascotaHogar.Text = item.nombreMascota;
                    ddlRazaHogar.SelectedValue = item.raza.idRaza.ToString();
                    ddlEspecieHogar.SelectedValue = item.especie.idEspecie.ToString();
                    txtSexoHogar.Text = item.sexo;
                    pnlMisProvisorias.Visible = true;
                }
            }
        }

        protected void btnDejarVoluntariado_Click(object sender, EventArgs e)
        {
            List<EMascota> provisorias = LogicaBDVoluntario.cargarDatosProvisorias(Session["UsuarioLogueado"].ToString());
            if (LogicaBDVoluntario.dejarDeSerVoluntario(Convert.ToInt32(Session["IdVoluntario"].ToString())))
            {
                pnlCorrecto.Visible = true;
                lblCorrecto.Text = "Solicitud de baja registrada";
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
            else
            {
                pnlAtento.Visible = true;
                lblError.Text = "Error al enviar solicitud";
            }
        }

        protected void ddlBusquedasMascota_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<EPerdida> perdidas = LogicaBDVoluntario.cargarPerdidasBarrioVoluntario(ddlBarrioBusqueda.SelectedItem.Text);
            foreach (EPerdida item in perdidas)
            {
                EMascota mascota = LogicaBDMascota.BuscarMascotaPorIdMascota(item.mascota.idMascota);
                if (ddlBusquedasMascota.SelectedValue == mascota.idMascota.ToString())
                {
                    txtMascotaPerdida.Text = mascota.nombreMascota;
                    ddlRazaPerdida.SelectedValue = mascota.raza.idRaza.ToString();
                    ddlEspeciePerdida.SelectedValue = mascota.especie.idEspecie.ToString();
                    pnlMisBusquedas.Visible = true;
                }
            }
        }

        protected void btnSolicitarDetallesPerdida_Click(object sender, EventArgs e)
        {
            Session["idMascota"] = ddlBusquedasMascota.SelectedValue;
            EMascota mascota = new EMascota();
            mascota.idMascota = Convert.ToInt32(Session["idMascota"].ToString());
            if (Session["idMascota"] != null)
            {
                Session["pantalla"] = "Voluntario.aspx";
                Response.Redirect("~/ConsultarPerdida.aspx");
            }
        }


    }
}