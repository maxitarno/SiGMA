﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;
using Herramientas;

namespace SiGMA
{
    public partial class RegistrarPerdida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarSoloDueño(Session["UsuarioLogueado"].ToString()))
                        pnlVoluntario.Visible = true;
                    else
                        MascotasPorDueño();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarColor(ref ddlColor);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarEspecies(ref ddlEspecie);
                CargarCombos.cargarComboRazas(ref ddlRaza);
                CargarCombos.cargarSexo(ref ddlSexo);
                CargarCombos.cargarBarrio(ref ddlBarrios);
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                CargarCombos.cargarCalles(ref ddlCalles);
                CargarCombos.cargarBarrio(ref ddlBarrioPerdida);
                CargarCombos.cargarLocalidades(ref ddlLocalidadPerdida);
                CargarCombos.cargarCalles(ref ddlCallePerdida);
                rnvFechaPerdida.MaximumValue = DateTime.Now.ToShortDateString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascota.buscarMascotasPorNombre(txtMascota.Text);
            limpiarPagina();
            if (mascotas.Count != 0)
            {
                pnlDueño.Visible = true;
                lstMascotas.DataSource = mascotas;
                lstMascotas.DataTextField = "nombreMascota";
                lstMascotas.DataValueField = "idMascota";
                lstMascotas.DataBind();
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron mascotas";
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }

        private void MascotasPorDueño() 
        {
            limpiarPagina();
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascota.BuscarMascotaPorIdDueño(Convert.ToInt32(Session["IdDueño"]));
            if (mascotas.Count != 0)
            {
                pnlDueño.Visible = true;
                lstMascotas.DataSource = mascotas;
                lstMascotas.DataTextField = "nombreMascota";
                lstMascotas.DataValueField = "idMascota";
                lstMascotas.DataBind();
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron mascotas";
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }

        protected void imgFechaPerdida_click(object sender, ImageClickEventArgs e)
        {
            calendario.Visible = true;
        }

        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaPerdida.Text = calendario.SelectedDate.ToString("d");
            calendario.Visible = false;
        }

        private void limpiarPagina() 
        {
            pnlInfo.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlRegistrarPerdida.Visible = false;
            txtFechaPerdida.Text = "";
            txtComentarios.Text = "";
            //txtMapa.Text = "";
        }

        protected void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["imagen"] = null;
            var idMascota = Convert.ToInt32(lstMascotas.SelectedValue);
            EMascota mascota = new EMascota();
            if (LogicaBDMascota.BuscarMascotaPorIdMascota(idMascota, mascota))
            {
                pnlRegistrarPerdida.Visible = true;
                txtMascotaPerdida.Text = mascota.nombreMascota;
                mascota.duenio = new EDuenio();
                txtNroCalle.Text = mascota.duenio.nroCalle.ToString();
                txtDatosDueño.Text = (mascota.duenio.nombre == null) ? null : mascota.duenio.nombre.ToString();
                txtDatosDueño.Text += (mascota.duenio.apellido == null) ? null : mascota.duenio.apellido.ToString();
                if (txtDatosDueño.Text == "")
                    txtDatosDueño.Text = "SIN ASIGNAR";
                if (mascota.duenio.domicilio != null)
                    ddlCalles.SelectedValue = (mascota.duenio.domicilio.idCalle == null) ? null : mascota.duenio.domicilio.idCalle.ToString();
                else
                    ddlCalles.SelectedValue = null;
                ddlBarrios.SelectedValue = (mascota.duenio.barrio == null) ? null : mascota.duenio.barrio.idBarrio.ToString();
                if (mascota.duenio.barrio != null)
                    ddlLocalidades.SelectedValue = (mascota.duenio.barrio.localidad == null) ? null : mascota.duenio.barrio.localidad.idLocalidad.ToString();
                else
                    ddlLocalidades.SelectedValue = null;
                ddlColor.SelectedValue = (mascota.color == null) ? null : mascota.color.idColor.ToString();
                ddlEdad.SelectedValue = (mascota.edad == null) ? null : mascota.edad.idEdad.ToString();
                ddlEspecie.SelectedValue = (mascota.especie == null) ? null : mascota.especie.idEspecie.ToString();
                ddlRaza.SelectedValue = (mascota.raza == null) ? null :mascota.raza.idRaza.ToString();
                ddlSexo.SelectedValue = mascota.sexo.ToString();
                Session["idMascota"] = idMascota;

                if (mascota.imagen != null)
                {
                    pnlImagen.Visible = true;
                    Session["imagen"] = mascota.imagen;
                    Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                    imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                    imgprvw.Width = 300;
                    imgprvw.Height = 250;
                }
                else
                {
                    pnlImagen.Visible = false;
                    imgprvw.Width = 0;
                    imgprvw.Height = 0;
                }

            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "La mascota no se encuentra en estado necesario para registrar una pérdida";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //Session["imagen"] = null;
            //var idMascota = Convert.ToInt32(lstMascotas.SelectedValue);
            //pnlRegistrarPerdida.Visible = true;
            //EMascota mascota = new EMascota();
            //ECaracterMascota caracter = new ECaracterMascota();
            //ECategoriaRaza categoria = new ECategoriaRaza();
            //EPersona persona = new EPersona();
            //EBarrio barrio = new EBarrio();
            //ELocalidad localidad = new ELocalidad();
            //ECalle calle = new ECalle();
            //if (LogicaBDMascota.BuscarMascotaPorIdMascota(idMascota, mascota))
            //{
            //    txtMascotaPerdida.Text = mascota.nombreMascota;
            //    mascota.duenio = new EDuenio();
            //    txtNroCalle.Text = mascota.duenio.nroCalle.ToString();
            //    txtDatosDueño.Text = (mascota.duenio.nombre == null) ? null : mascota.duenio.nombre.ToString();
            //    txtDatosDueño.Text += (mascota.duenio.apellido == null) ? null : mascota.duenio.apellido.ToString();
            //    ddlCalles.SelectedValue = (calle.idCalle == null) ? null : calle.idCalle.ToString();
            //    ddlBarrios.SelectedValue = (mascota.duenio.barrio == null) ? null : mascota.duenio.barrio.idBarrio.ToString();
            //    ddlLocalidades.SelectedValue = (mascota.duenio.barrio.localidad == null) ? null : mascota.duenio.barrio.localidad.idLocalidad.ToString();
            //    ddlColor.SelectedValue = mascota.color.idColor.ToString();
            //    ddlEdad.SelectedValue = mascota.edad.idEdad.ToString();
            //    ddlEspecie.SelectedValue = mascota.especie.idEspecie.ToString();
            //    ddlRaza.SelectedValue = mascota.raza.idRaza.ToString();
            //    ddlSexo.SelectedValue = mascota.sexo.ToString();
            //    Session["idMascota"] = idMascota;

            //    if (mascota.imagen != null)
            //    {
            //        pnlImagen.Visible = true;
            //        Session["imagen"] = mascota.imagen;
            //        Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
            //        imgprvw.Src = ResolveUrl("~/Handler1.ashx");
            //        imgprvw.Width = 300;
            //        imgprvw.Height = 250;
            //    }
            //    else
            //    {
            //        pnlImagen.Visible = false;
            //        imgprvw.Width = 0;
            //        imgprvw.Height = 0;
            //    }

            //}
            //else
            //{
            //    pnlInfo.Visible = true;
            //    lblInfo.Text = "No se encontro la mascota";
            //    pnlCorrecto.Visible = false;
            //    pnlAtento.Visible = false;
            //}
        }
        public byte[] ImageHandler_ObtenerImagenMascota(HttpContext context)
        {
            if (Session["imagen"] != null)
            {
                var imagen = (byte[])Session["imagen"];
                return imagen;
            }
            else
                return null;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarPagina();
        }

        protected void btnRegistrarPerdida_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    EPerdida perdida = new EPerdida();
                    perdida.mascota = new EMascota();
                    perdida.mascota.idMascota = Convert.ToInt32(Session["idMascota"].ToString());
                    perdida.domicilio = new EDomicilio();
                    perdida.domicilio.barrio = new EBarrio();
                    perdida.domicilio.barrio.localidad = new ELocalidad();
                    perdida.domicilio.calle = new ECalle();
                    perdida.domicilio.barrio.idBarrio = int.Parse(ddlBarrioPerdida.SelectedValue);
                    perdida.domicilio.barrio.nombre = ddlBarrioPerdida.SelectedItem.Text;
                    perdida.domicilio.barrio.localidad.idLocalidad = int.Parse(ddlLocalidadPerdida.SelectedValue);
                    perdida.domicilio.barrio.localidad.nombre = ddlLocalidadPerdida.SelectedItem.Text;
                    perdida.domicilio.calle.nombre = ddlCallePerdida.SelectedItem.Text;
                    perdida.domicilio.numeroCalle = int.Parse(txtNroCallePerdida.Text);
                    perdida.usuario = new EUsuario();
                    perdida.usuario.user = Session["UsuarioLogueado"].ToString();
                    perdida.fecha = Convert.ToDateTime(txtFechaPerdida.Text);
                    perdida.comentarios = txtComentarios.Text;
                    //perdida.mapaPerdida = txtMapa.Text;
                    if (perdida.fecha > DateTime.Now)
                    {
                        pnlInfo.Visible = true;
                        lblInfo.Text = "La fecha de pérdida no puede ser superior a la actual";
                        txtFechaPerdida.Focus();
                        return;
                    }
                    if (LogicaBDPerdida.registrarPerdida(perdida))
                    {
                        limpiarPagina();
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Pérdida Registrada Correctamente";
                    }
                    else
                    {
                        pnlAtento.Visible = true;
                        lblError.Text = "No se registro la pérdida. Verifique datos";
                    }
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

    }
}