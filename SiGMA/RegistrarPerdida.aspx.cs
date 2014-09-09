﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;

namespace SiGMA
{
    public partial class RegistrarPerdida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogicaBDRol.verificarSoloDueño(Session["UsuarioLogueado"].ToString()))
                pnlVoluntario.Visible = true;
            else
                MascotasPorDueño();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascotas.BuscarMascotaPorMascota(txtMascota.Text);
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
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascotas.BuscarMascotaPorIdDueño(Convert.ToInt32(Session["IdDueño"]));
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

        private void limpiarPagina() 
        {
            pnlInfo.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
        }
    }
}