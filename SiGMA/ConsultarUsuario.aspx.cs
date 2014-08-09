using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;
namespace SiGMA
{
    public partial class ConsultarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<ETipoDeDocumento> tipos = new List<ETipoDeDocumento>();
                tipos = LogicaBDUsuario.TiposDNI();
                ddlTipoDeDocumento.DataSource = tipos;
                ddlTipoDeDocumento.DataTextField = "nombre";
                ddlTipoDeDocumento.DataValueField = "idTipoDeDocumento";
                ddlTipoDeDocumento.DataBind();
                List<ERol> roles = new List<ERol>();
                roles = LogicaBDUsuario.Roles();
                ddlRoles.DataSource = roles;
                ddlRoles.DataTextField = "nombreRol";
                ddlRoles.DataValueField = "idRol";
                ddlRoles.DataBind();
                rbPorPersona.Checked = true;
            }
        }
        public void btnBuscarClick(object sender, EventArgs e){
            if (rbPorPersona.Checked == true)
            {
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuarios(ddlTipoDeDocumento.SelectedIndex, txtNºDeDocumento.Text);
                lstResultados.DataSource = usuarios;
                lstResultados.DataTextField = "user";
                lstResultados.DataValueField = "user";
                lstResultados.DataBind();
            }
            else
            {
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuarios(txtUsuario.Text);
                lstResultados.DataSource = usuarios;
                lstResultados.DataTextField = "user";
                lstResultados.DataValueField = "user";
                lstResultados.DataBind();
            }
        }
    }
}