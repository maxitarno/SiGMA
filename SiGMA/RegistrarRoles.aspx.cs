using System;
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
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                    {
                        btnNuevoRol.Visible = false;
                        btnGuardarRol.Visible = false;
                    }
                    if (!LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                        btnEliminarRol.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarRoles(ref ddlRol);
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
            }
        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                btnEliminarRol.Visible = true;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
            pnlModificacionRol.Visible = true;
            txtRol.Text = ddlRol.SelectedItem.Text;
            int idRol = Convert.ToInt32(ddlRol.SelectedValue);
            ERol rol = LogicaBDRol.cargarRol(idRol);
            txtRol.Text = rol.nombreRol;
            txtDescripcionRol.Text = rol.descripcionRol;
            txtRol.Enabled = false;
            if (ddlRol.SelectedValue == "SIN ASIGNAR")
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
                    if (ddlRol.SelectedValue != "SIN ASIGNAR")
                        rol.idRol = Convert.ToInt32(ddlRol.SelectedValue);
                    if (LogicaBDRol.guardarRol(rol))
                    {
                        limpiarPagina();
                        ddlRol.Items.Clear();
                        CargarCombos.cargarRoles(ref ddlRol);
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Rol Guardado Correctamente";
                    }
                    else
                    {
                        pnlAtento.Visible = true;
                        lblError.Text = "No se guardo el rol. Verifique datos";
                    }
                }
            }
            catch (Exception exc)
            {
                pnlAtento.Visible = true;
                lblError.Text = "Ocurrio un error inesperado. Intente mas tarde";
            }
        }

        private void limpiarPagina()
        {
            ddlRol.SelectedValue = "SIN ASIGNAR";
            txtDescripcionRol.Text = "";
            txtRol.Text = "";
            pnlModificacionRol.Visible = false;
            txtRol.Enabled = true;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
        }

        protected void btnNuevoRol_Click(object sender, EventArgs e)
        {
            limpiarPagina();
            pnlModificacionRol.Visible = true;
            btnEliminarRol.Visible = false;
        }

        protected void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    ERol rol = new ERol();
                    rol.idRol = Convert.ToInt32(ddlRol.SelectedValue);
                    if (LogicaBDRol.eliminarRol(rol))
                    {
                        limpiarPagina();
                        ddlRol.Items.Clear();
                        CargarCombos.cargarRoles(ref ddlRol);
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Rol Eliminado Correctamente";
                    }
                    else
                    {
                        pnlAtento.Visible = true;
                        lblError.Text = "No se elimino el rol. Verifique la inexistencia de usuarios con este rol";
                    }
                }
            }
            catch (Exception exc)
            {
                pnlAtento.Visible = true;
                lblError.Text = "Ocurrio un error inesperado. Intente mas tarde";
            }
        }
    }
}