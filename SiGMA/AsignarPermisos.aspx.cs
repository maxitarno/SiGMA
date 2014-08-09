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
    public partial class AsignarPermisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarRoles();
            }
           
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

                // --------------- RegistrarUsuario --------------- //
                permisoRol.idPermiso = chkRegistrarUsuarioL.Checked ? 1 : 0;
                permisoRol.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol.pantalla = "RegistrarUsuario.aspx";
                if (permisoRol.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol);

                EPermisoRol permisoRol2 = new EPermisoRol();
                permisoRol2.idPermiso = chkRegistrarUsuarioG.Checked ? 2 : 0;
                permisoRol2.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol2.pantalla = "RegistrarUsuario.aspx";
                if (permisoRol2.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol2);

                EPermisoRol permisoRol3 = new EPermisoRol();
                permisoRol3.idPermiso = chkRegistrarUsuarioE.Checked ? 3 : 0;
                permisoRol3.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol3.pantalla = "RegistrarUsuario.aspx";
                if (permisoRol3.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol3);

                // --------------- ConsultarUsuario --------------- //
                EPermisoRol permisoRol4 = new EPermisoRol();
                permisoRol4.idPermiso = chkConsultarUsuarioL.Checked ? 1 : 0;
                permisoRol4.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol4.pantalla = "ConsultarUsuario.aspx";
                if (permisoRol4.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol4);

                EPermisoRol permisoRol5 = new EPermisoRol();
                permisoRol5.idPermiso = chkConsultarUsuarioG.Checked ? 2 : 0;
                permisoRol5.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol5.pantalla = "ConsultarUsuario.aspx";
                if (permisoRol5.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol5);

                EPermisoRol permisoRol6 = new EPermisoRol();
                permisoRol6.idPermiso = chkConsultarUsuarioE.Checked ? 3 : 0;
                permisoRol6.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol6.pantalla = "ConsultarUsuario.aspx";
                if (permisoRol6.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol6);

                // --------------- AsignarPermisos --------------- //
                EPermisoRol permisoRol7 = new EPermisoRol();
                permisoRol7.idPermiso = chkAsignarPermisosL.Checked ? 1 : 0;
                permisoRol7.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol7.pantalla = "AsignarPermisos.aspx";
                if (permisoRol7.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol7);

                EPermisoRol permisoRol8 = new EPermisoRol();
                permisoRol8.idPermiso = chkAsignarPermisosG.Checked ? 2 : 0;
                permisoRol8.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol8.pantalla = "AsignarPermisos.aspx";
                if (permisoRol8.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol8);

                EPermisoRol permisoRol9 = new EPermisoRol();
                permisoRol9.idPermiso = chkAsignarPermisosE.Checked ? 3 : 0;
                permisoRol9.idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                permisoRol9.pantalla = "AsignarPermisos.aspx";
                if (permisoRol9.idPermiso != 0)
                    ListadoPermisos.Add(permisoRol9);

                if (LogicaBDRol.guardarPermisoRol(ListadoPermisos))
                {
                    Response.Write("<SCRIPT>alert('Rol Actualizado Correctamente');</SCRIPT>");
                }
                else 
                {
                    Response.Write("<SCRIPT>alert('No se actualizo el rol');</SCRIPT>");
                }
                limpiarPagina();    
            }
        }

        private void limpiarPagina()
        {
            chkAsignarPermisosL.Checked = false;
            chkAsignarPermisosG.Checked = false;
            chkAsignarPermisosE.Checked = false;
            chkConsultarUsuarioL.Checked = false;
            chkConsultarUsuarioG.Checked = false;
            chkConsultarUsuarioE.Checked = false;
            chkRegistrarUsuarioL.Checked = false;
            chkRegistrarUsuarioG.Checked = false;
            chkRegistrarUsuarioE.Checked = false;
            pnlPermisos.Visible = false;
            lblRol.Text = "";
        }

        //carga el lbl con el nombre del rol seleccionado
        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRol.Text = ddlRol.SelectedItem.Text;
            if (ddlRol.SelectedItem.Value == "0")
                pnlPermisos.Visible = false;
            else
                pnlPermisos.Visible = true;
        }
    }
}