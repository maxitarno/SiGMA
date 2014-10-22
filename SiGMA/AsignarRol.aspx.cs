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

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarRoles(ref ddlRol);
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
            ddlRolUsuario.DataSource = LogicaBDRol.cargarRolesSergunUsuario(usuario);
            ddlRolUsuario.DataTextField = "nombreRol";
            ddlRolUsuario.DataValueField = "idRol";
            ddlRolUsuario.DataBind();
            List<ERol> roles = LogicaBDRol.cargarRolesSergunUsuario(usuario);
            foreach (var item in roles)
            {
                ddlRol.Items.Remove(item.nombreRol);    
            }
        }
    }
}