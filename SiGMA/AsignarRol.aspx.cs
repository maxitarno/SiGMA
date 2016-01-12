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
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                        btnAsignarRol.Visible = true;
                    if (LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                        btnEliminarRol.Visible = true;
                }
                else
                {
                    Response.Redirect("Login.aspx"); 
                }
            }
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            usuarios = LogicaBDUsuario.BuscarUsuarios(txtSelecionUsuario.Text);
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
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron usuarios";
            }
        }

        protected void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlRolUsuario.Items.Clear();
            var usuario = lstUsuarios.SelectedValue;
            pnlAsignalRol.Visible = true;
            lblUsuario.Text = usuario;
            cargarRolUsuario(usuario);
            quitarRolesParaAsignar(usuario);
            ddlRol.Focus();
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
            if (ddlRol.SelectedValue == "SIN ASIGNAR")
            {
                lblInfo.Text = "El usuario no tiene rol asignado que pueda eliminar";
                pnlInfo.Visible = true;
                pnlInfo.Focus();
                return;
            }
            if (Session["UsuarioLogueado"].ToString() == "admin" && ddlRolUsuario.SelectedValue == "1")
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Acción no permitida. \n No puede eliminar el rol de Administrador en este usuario";
                return;
            }
            if (LogicaBDRol.eliminarRolAsignadoUsuario(Convert.ToInt32(ddlRolUsuario.SelectedValue), lstUsuarios.SelectedValue))
            {
                ddlRolUsuario.Items.RemoveAt(ddlRolUsuario.SelectedIndex);
                quitarRolesParaAsignar(lstUsuarios.SelectedValue);
                lblCorrecto.Text = "Rol eliminado del usuario correctamente";
                pnlCorrecto.Visible = true;
                pnlCorrecto.Focus();
            }
            else
            {
                lblError.Text = "Error al eliminar rol. Verifique datos";
                pnlAtento.Visible = true;
                pnlAtento.Focus();
            }
        }

        protected void btnAsignarRol_Click(object sender, EventArgs e)
        {
            if (ddlRol.SelectedValue == "SIN ASIGNAR") 
            {
                lblInfo.Text = "Seleccione un rol a asignar";
                pnlInfo.Visible = true;
                pnlInfo.Focus();
                return;
            }
            if (LogicaBDRol.guardarRolAsignadoUsuario(Convert.ToInt32(ddlRol.SelectedValue), lstUsuarios.SelectedValue))
            {
                ddlRolUsuario.Items.Clear();
                cargarRolUsuario(lstUsuarios.SelectedValue);
                ddlRol.Items.RemoveAt(Convert.ToInt32(ddlRol.SelectedIndex));
                lblCorrecto.Text = "Rol asignado al usuario correctamente";
                pnlCorrecto.Visible = true;
                pnlCorrecto.Focus();
            }
            else
            {
                lblError.Text = "Error al eliminar rol. Verifique datos";
                pnlAtento.Visible = true;
                pnlAtento.Focus();
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