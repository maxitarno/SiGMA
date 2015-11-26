﻿using System;
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
            if (!Page.IsPostBack)
            {
                if (Session["TipoVoluntario"].ToString() != "0")
                {
                    if (Session["VoluntarioCargado"] != null && Session["VoluntarioCargado"].ToString() == "True")
                    {
                        if (Session["idMascota"] != null && Session["pantalla"].ToString() == "Voluntario.aspx")
                        {
                            cargarDatosPagina();
                        }
                        else if (Session["pantalla"] != null && Session["pantalla"].ToString() == "")
                            cargarDatosPagina();
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
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
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
                return;
            }

        }

        private void cargarComboPerdidasBarrio()
        {
            if (ddlBarrioBusqueda.SelectedValue != "0")
            {
                ddlBusquedasMascota.Items.Clear();
                List<EPerdida> perdidas = LogicaBDVoluntario.cargarPerdidasBarrioVoluntario(ddlBarrioBusqueda.SelectedItem.Text);
                List<EPerdida> aux = new List<EPerdida>();
                aux = perdidas;
                Session["perdidas"] = aux;
                if (perdidas.Count != 0)
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
            EVoluntario voluntario = new EVoluntario();
            LogicaBDVoluntario.cargarDatosBusqueda(Session["UsuarioLogueado"].ToString(), persona, barrio, voluntario);
            txtNombre.Text = persona.nombre;
            txtEmail.Text = persona.email;
            ddlBarrioBusqueda.SelectedValue = barrio.idBarrio == null ? null : barrio.idBarrio.ToString();
            if (voluntario.disponibilidadHoraria == "Por la mañana")
                ddlDisponibilidadHoraria.SelectedValue = "1";
            else if (voluntario.disponibilidadHoraria == "Por la tarde")
                ddlDisponibilidadHoraria.SelectedValue = "2";
            else if (voluntario.disponibilidadHoraria == "Por la noche")
                ddlDisponibilidadHoraria.SelectedValue = "3";
            else
                ddlDisponibilidadHoraria.SelectedValue = "1";
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
            Session["pantalla"] = ""; 
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
                    SetFocus(pnlCorrecto);
                }
            }
            else
            {
                pnlAtento.Visible = true;
                lblError.Text = "Error al enviar solicitud";
                SetFocus(pnlAtento);
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

        protected void btnSolicitarDevolucion_Click(object sender, EventArgs e)
        {
            LogicaBDVoluntario.registrarSolicitudDevolucion(Convert.ToInt32(ddlMascotasEnHogar.SelectedValue.ToString()));
            pnlInfo.Visible = true;
            lblInfo.Text = "Nos pondremos en contacto con usted para la devolución de la mascota";
            SetFocus(pnlCorrecto);
        }

        protected void btnActualizarBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                LogicaBDVoluntario.actualizarDisponibilidadVoluntario(Convert.ToInt32(Session["IdVoluntario"].ToString()), ddlDisponibilidadHoraria.SelectedItem.Text);
                pnlCorrecto.Visible=true;
                lblCorrecto.Text="Disponibilidad actualizada correctamente";
            }
            catch (Exception)
            {
                pnlAtento.Visible = true;
                lblError.Text = "Ha ocurrido un error al actualizar la disponibilidad";
            }
            SetFocus(pnlCorrecto);
        }

        protected void ddlBarrioBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboPerdidasBarrio();
        }

        protected void btnActualizarHogar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones.verificarSoloNumeros(txtNro.Text))
                {
                    LogicaBDVoluntario.actualizarHogarVoluntario(Convert.ToInt32(Session["IdVoluntario"].ToString()), Session["UsuarioLogueado"].ToString(), ddlTipoHogar.SelectedValue, ddlCalle.SelectedValue, txtNro.Text, ddlBarrio.SelectedValue, ddlNumeroMascotas.SelectedValue, ddlTipoMascota.SelectedValue, ddlTieneNinios.SelectedValue);
                    pnlCorrecto.Visible = true;
                    lblCorrecto.Text = "Hogar actualizado correctamente";
                }
                else
                {
                    lblInfo.Text = "Debe ingresar un número de calle valido";
                    pnlInfo.Visible = true;
                    SetFocus(pnlCorrecto);
                }
            }
            catch (Exception)
            {
                pnlAtento.Visible = true;
                lblError.Text = "Ha ocurrido un error al actualizar el hogar";
                SetFocus(pnlCorrecto);
            }
        }

        protected void btnCambioVoluntariado_Click(object sender, EventArgs e)
        {
            if (ddlTipoVoluntario.SelectedValue == "0")
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Seleccione un tipo de voluntariado";
                return;
            }
            Session["cambioVoluntariado"] = ddlTipoVoluntario.SelectedValue;
            if (Session["cambioVoluntariado"].ToString() == Session["TipoVoluntario"].ToString())
            {
                lblInfo.Text = "Usted es esa clase de voluntario, si desea solicitar cambio, seleccione otro tipo de voluntariado";
                pnlInfo.Visible = true;
                return;
            }
            Session["pantalla"] = "Voluntario.aspx";
            Response.Redirect("~/SerVoluntario.aspx");
        }

        protected void btnMapa_Click(object sender, EventArgs e)
        {
            string cuidado = "0";
            int idMascota = int.Parse(ddlBusquedasMascota.SelectedValue);
            EPerdida perdida = new EPerdida();
            EMascota mascota = new EMascota();
            LogicaBDPerdida.BuscarMascotaAConsultarPerdida(idMascota, mascota, perdida);
            string direccion = "argentina " + perdida.domicilio.barrio.localidad.nombre.ToLower().ToString() + " " + perdida.domicilio.calle.nombre.ToLower().ToString() + " " + perdida.domicilio.numeroCalle;
            string nombre = mascota.nombreMascota;
            if (mascota.raza.cuidadoEspecial.idCuidado == 0)
            {
                cuidado = "0";
            }
            else if (mascota.raza.cuidadoEspecial.idCuidado == 1 || mascota.raza.cuidadoEspecial.idCuidado == 4)
            {
                cuidado = "2";
            }
            else if (mascota.raza.cuidadoEspecial.idCuidado == 2)
            {
                cuidado = "8";
            }
            else if (mascota.raza.cuidadoEspecial.idCuidado == 3)
            {
                cuidado = "4";
            }
            string pagina = "Busqueda.htm?direccion=" + direccion + "&nombre=" + nombre + "&cuidado=" + cuidado;
            Response.Write("<script>window.open('" + pagina + "','popup','width=800,height=500');</script>");
        }

        protected void ddlTipoVoluntario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBusquedaPorBarrio_Click(object sender, EventArgs e)
        {
            string nombre = "";
            string direccion = "";
            string cuidado = "";
            List<EPerdida> aux = (List<EPerdida>)Session["perdidas"];
            for (int i = 0; i < aux.Count; i++ )
            {
                nombre += aux[i].mascota.nombreMascota;
                direccion += ("argentina " + aux[i].barrio.localidad.nombre.ToLower().ToString() + " " + aux[i].domicilio.calle.nombre.ToLower().ToString() + " " + aux[i].domicilio.numeroCalle.ToString()).ToString();
                if (aux[i].mascota.cuidadoEspecial.idCuidado == 0)
                {
                    cuidado += "0";
                }
                else if (aux[i].mascota.cuidadoEspecial.idCuidado == 1 || aux[i].mascota.cuidadoEspecial.idCuidado == 4)
                {
                    cuidado += "2";
                }
                else if (aux[i].mascota.cuidadoEspecial.idCuidado == 2)
                {
                    cuidado += "8";
                }
                else if (aux[i].mascota.cuidadoEspecial.idCuidado == 3)
                {
                    cuidado += "4";
                }
                if (i != (aux.Count - 1))
                {
                    direccion += ",";
                    nombre += ",";
                    cuidado += ",";
                }
            }
            string pagina = "busquedasPorBarrio.htm?direccion=" + direccion + "&nombre=" + nombre + "&cuidado=" + cuidado;
            Response.Write("<script>window.open('" + pagina + "','popup','width=800,height=500')</script>");
        }
    }
}