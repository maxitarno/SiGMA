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
    public partial class RegistrarRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDUsuario.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RegistrarRoles.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarRoles(ref ddlRol);
            }

        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlModificacionRol.Visible = true;
            txtRol.Text = ddlRol.SelectedItem.Text;
            int idRol = Convert.ToInt32(ddlRol.SelectedValue);
            ERol rol = LogicaBDRol.cargarRol(idRol);
            txtRol.Text = rol.nombreRol;
            txtDescripcionRol.Text = rol.descripcionRol;
            if (ddlRol.SelectedValue == "0")
                limpiarPagina();
        }

        protected void btnGuardarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid) 
                {
                    ERol rol = new ERol();
                    rol.nombreRol = txtRol.Text;
                    rol.descripcionRol = txtDescripcionRol.Text;
                    if (ddlRol.SelectedValue != "0")
                        rol.idRol = Convert.ToInt32(ddlRol.SelectedValue);
                    if (LogicaBDRol.guardarRol(rol))
                    {
                        Response.Write("<SCRIPT>alert('Rol Guardado Correctamente');</SCRIPT>");
                        limpiarPagina();
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('No se guardo el rol');</SCRIPT>");
                    }
                }
            }
            catch (Exception exc)
            {
                
                throw exc;
            }
        }

        private void limpiarPagina()
        {
            ddlRol.SelectedValue = "0";
            txtDescripcionRol.Text = "";
            txtRol.Text = "";
            pnlModificacionRol.Visible = false;
        }

        protected void btnNuevoRol_Click(object sender, EventArgs e)
        {
            limpiarPagina();
            pnlModificacionRol.Visible = true;
        }
    }
}