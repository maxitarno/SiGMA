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
    public partial class AsignarPermisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarRoles();
        }

        //carga del combo de roles
        private void cargarRoles()
        {
            ddlRol.DataTextField = "nombreRol";
            ddlRol.DataValueField = "idRol";
            ddlRol.DataSource = LogicaBDUsuario.Roles();
            ddlRol.DataBind();
        }

        //metodo para asignacion de permisos por rol, se elige el rol y luego se especifica con el chk 
        // en cada pantalla que permisos va a tener cualquier usuario con ese rol
        // es un bajon para mi que sea de esta forma pero funcionaria tecnicamente
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                List<EPermisoRol> ListadoPermisos = new List<EPermisoRol>();
                EPermisoRol permisoRol = new EPermisoRol();

                //RegistrarUsuario
                permisoRol.idPermiso = chkRegistrarUsuarioL.Checked ? 1 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "RegistrarUsuario.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);
                permisoRol.idPermiso = chkRegistrarUsuarioG.Checked ? 2 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "RegistrarUsuario.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);
                permisoRol.idPermiso = chkRegistrarUsuarioE.Checked ? 3 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "RegistrarUsuario.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);

                //ConsultarUsuario
                permisoRol.idPermiso = chkConsultarUsuarioL.Checked ? 1 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "ConsultarUsuario.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);
                permisoRol.idPermiso = chkConsultarUsuarioG.Checked ? 2 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "ConsultarUsuario.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);
                permisoRol.idPermiso = chkConsultarUsuarioE.Checked ? 3 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "ConsultarUsuario.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);

                //AsignarPermisos
                permisoRol.idPermiso = chkAsignarPermisosL.Checked ? 1 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "AsignarPermisos.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);
                permisoRol.idPermiso = chkAsignarPermisosG.Checked ? 2 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "AsignarPermisos.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);
                permisoRol.idPermiso = chkAsignarPermisosE.Checked ? 3 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "AsignarPermisos.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);

                LogicaBDRol.guardarPermisoRol(ListadoPermisos);
            }
        }

        //carga el lbl con el nombre del rol seleccionado
        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRol.Text = ddlRol.SelectedItem.Text;
        }
    }
}