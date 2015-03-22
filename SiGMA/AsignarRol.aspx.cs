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
    public partial class AsignarRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "AsignarRol.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "AsignarRol.aspx"))
                        btnAsignarRol.Visible = true;
                    if (LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "AsignarRol.aspx"))
                        btnEliminarRol.Visible = true;
                }
                else
                {
                    Response.Redirect("Login.aspx"); 
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            usuarios = LogicaBDUsuario.BuscarUsuarios(txtUsuario.Text);
            if (usuarios.Count != 0)
            {
                lstUsuarios.DataSource = usuarios;
                lstUsuarios.DataTextField = "user";
                lstUsuarios.DataValueField = "user";
                lstUsuarios.DataBind();
                pnlUsuario.Visible = true;
            }
            else if (usuarios.Count == 0)
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron usuarios";
            }
        }

        protected void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usuario = lstUsuarios.SelectedValue;
            pnlAsignalRol.Visible = true;
            txtUsuario.Text = usuario;
            cargarRolUsuario(usuario);
            quitarRolesParaAsignar(usuario);
        }

        private void quitarRolesParaAsignar(string usuario)
        {
            ddlRol.Items.Clear();
            CargarCombos.cargarRoles(ref ddlRol);
            List<ERol> roles = LogicaBDRol.cargarRolesSergunUsuario(usuario);
            foreach (var item in roles)
            {
                ddlRol.SelectedValue = item.idRol.ToString();
                ddlRol.Items.RemoveAt(ddlRol.SelectedIndex);
            }   
        }

        protected void btnEliminarRol_Click(object sender, EventArgs e)
        {
            if (LogicaBDRol.eliminarRolAsignadoUsuario(Convert.ToInt32(ddlRolUsuario.SelectedValue), lstUsuarios.SelectedValue))
            {
                ddlRolUsuario.Items.RemoveAt(ddlRolUsuario.SelectedIndex);
                quitarRolesParaAsignar(lstUsuarios.SelectedValue);
                pnlInfo.Visible = false;
                lblCorrecto.Text = "Rol eliminado del usuario correctamente";
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = true;
            }
            else
            {
                pnlInfo.Visible = false;
                lblError.Text = "Error al iliminar rol. Verifique datos";
                pnlAtento.Visible = true;
                pnlCorrecto.Visible = true;
            }
        }

        protected void btnAsignarRol_Click(object sender, EventArgs e)
        {
            if (LogicaBDRol.guardarRolAsignadoUsuario(Convert.ToInt32(ddlRol.SelectedValue), lstUsuarios.SelectedValue))
            {
                ddlRolUsuario.Items.Clear();
                cargarRolUsuario(lstUsuarios.SelectedValue);
                ddlRol.Items.RemoveAt(Convert.ToInt32(ddlRol.SelectedIndex));
                pnlInfo.Visible = false;
                lblCorrecto.Text = "Rol asignado al usuario correctamente";
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = true;
            }
            else
            {
                pnlInfo.Visible = false;
                lblError.Text = "Error al iliminar rol. Verifique datos";
                pnlAtento.Visible = true;
                pnlCorrecto.Visible = true;
            }
        }

        private void cargarRolUsuario(string usuario) 
        {
            ddlRolUsuario.DataSource = LogicaBDRol.cargarRolesSergunUsuario(usuario);
            ddlRolUsuario.DataTextField = "nombreRol";
            ddlRolUsuario.DataValueField = "idRol";
            ddlRolUsuario.DataBind();
        }
    }
}