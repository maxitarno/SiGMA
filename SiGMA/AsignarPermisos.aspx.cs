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
    public partial class AsignarPermisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDUsuario.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "AsignarPermisos.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarRoles(ref ddlRol);
            } 
        }

        //metodo para asignacion de permisos por rol, se elige el rol y luego se especifica con el chk 
        // en cada pantalla que permisos va a tener cualquier usuario con ese rol
        // es un bajon para mi que sea de esta forma pero funcionaria tecnicamente
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {
                    List<EPermiso> ListadoPermisos = new List<EPermiso>();
                    EPermiso permisoRol = new EPermiso();
                    var idRol = Convert.ToInt32(ddlRol.SelectedItem.Value);
                    var i = 0;

                    // --------------- RegistrarUsuario --------------- //
                    permisoRol.idPermiso = chkRegistrarUsuarioL.Checked ? 1 : 0;
                    permisoRol.pantalla = "RegistrarUsuario.aspx";
                    if (permisoRol.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol);

                    EPermiso permisoRol2 = new EPermiso();
                    permisoRol2.idPermiso = chkRegistrarUsuarioG.Checked ? 2 : 0;
                    permisoRol2.pantalla = "RegistrarUsuario.aspx";
                    if (permisoRol2.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol2);

                    EPermiso permisoRol3 = new EPermiso();
                    permisoRol3.idPermiso = chkRegistrarUsuarioE.Checked ? 3 : 0;
                    permisoRol3.pantalla = "RegistrarUsuario.aspx";
                    if (permisoRol3.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol3);

                    // --------------- ConsultarUsuario --------------- //
                    EPermiso permisoRol4 = new EPermiso();
                    permisoRol4.idPermiso = chkConsultarUsuarioL.Checked ? 1 : 0;
                    permisoRol4.pantalla = "ConsultarUsuario.aspx";
                    if (permisoRol4.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol4);

                    EPermiso permisoRol5 = new EPermiso();
                    permisoRol5.idPermiso = chkConsultarUsuarioG.Checked ? 2 : 0;
                    permisoRol5.pantalla = "ConsultarUsuario.aspx";
                    if (permisoRol5.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol5);

                    EPermiso permisoRol6 = new EPermiso();
                    permisoRol6.idPermiso = chkConsultarUsuarioE.Checked ? 3 : 0;
                    permisoRol6.pantalla = "ConsultarUsuario.aspx";
                    if (permisoRol6.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol6);

                    // --------------- AsignarPermisos --------------- //
                    EPermiso permisoRol7 = new EPermiso();
                    permisoRol7.idPermiso = chkAsignarPermisosL.Checked ? 1 : 0;
                    permisoRol7.pantalla = "AsignarPermisos.aspx";
                    if (permisoRol7.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol7);

                    EPermiso permisoRol8 = new EPermiso();
                    permisoRol8.idPermiso = chkAsignarPermisosG.Checked ? 2 : 0;
                    permisoRol8.pantalla = "AsignarPermisos.aspx";
                    if (permisoRol8.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol8);

                    EPermiso permisoRol9 = new EPermiso();
                    permisoRol9.idPermiso = chkAsignarPermisosE.Checked ? 3 : 0;
                    permisoRol9.pantalla = "AsignarPermisos.aspx";
                    if (permisoRol9.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol9);

                    // --------------- ConsultarMascotas --------------- //

                    EPermiso permisoRol10 = new EPermiso();
                    permisoRol10.idPermiso = chkConsultarMascotasL.Checked ? 1 : 0;
                    permisoRol10.pantalla = "ConsultarMascotas.aspx";
                    if (permisoRol10.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol10);

                    EPermiso permisoRol11 = new EPermiso();
                    permisoRol11.idPermiso = chkConsultarMascotasG.Checked ? 2 : 0;
                    permisoRol11.pantalla = "ConsultarMascotas.aspx";
                    if (permisoRol11.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol11);

                    EPermiso permisoRol12 = new EPermiso();
                    permisoRol12.idPermiso = chkConsultarMascotasE.Checked ? 3 : 0;
                    permisoRol12.pantalla = "ConsultarMascotas.aspx";
                    if (permisoRol12.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol12);

                    // --------------- RegistrarMascotas --------------- //

                    EPermiso permisoRol13 = new EPermiso();
                    permisoRol13.idPermiso = chkRegistrarMascotasL.Checked ? 1 : 0;
                    permisoRol13.pantalla = "RegistrarMascota.aspx";
                    if (permisoRol13.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol13);

                    EPermiso permisoRol14 = new EPermiso();
                    permisoRol14.idPermiso = chkRegistrarMascotasG.Checked ? 2 : 0;
                    permisoRol14.pantalla = "RegistrarMascota.aspx";
                    if (permisoRol14.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol14);

                    EPermiso permisoRol15 = new EPermiso();
                    permisoRol15.idPermiso = chkRegistrarMascotasE.Checked ? 3 : 0;
                    permisoRol15.pantalla = "RegistrarMascota.aspx";
                    if (permisoRol15.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol15);

                    ERol RolEnviar = new ERol();
                    RolEnviar.listaPermisos = ListadoPermisos;
                    RolEnviar.idRol = idRol;

                    if (LogicaBDRol.guardarPermisoRol(RolEnviar))
                    {
                        Response.Write("<SCRIPT>alert('Rol Actualizado Correctamente');</SCRIPT>");
                        limpiarPagina();
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('No se actualizo el rol');</SCRIPT>");
                    }
                }
            }
            catch (Exception exc)
            {
                Response.Write("<SCRIPT>alert('OCURRIO UN ERROR EN LA APLICACIÓN');</SCRIPT>");
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
            ddlRol.SelectedValue = "0";
            lblRol.Text = "";
        }

        //Cargar los checkbox segun el Rol seleccionado
        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreRol = ddlRol.SelectedItem.Text;
            int idRol = Convert.ToInt32(ddlRol.SelectedValue);
            List<EPermiso> permisosRol = new List<EPermiso>();
            if (ddlRol.SelectedItem.Value == "0")
                pnlPermisos.Visible = false;
            else
            {
                limpiarPagina();
                lblRol.Text = nombreRol;
                ddlRol.SelectedValue = idRol.ToString();
                pnlPermisos.Visible = true;
                permisosRol = LogicaBDRol.cargarPermisosRol(idRol);
                for (int i = 0; i < permisosRol.Count; i++)
                {
                    if (permisosRol[i].pantalla == "ConsultarUsuario.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarUsuarioL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarUsuarioG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarUsuarioE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "RegistrarUsuario.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkRegistrarUsuarioL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkRegistrarUsuarioG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkRegistrarUsuarioE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "AsignarPermisos.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkAsignarPermisosL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkAsignarPermisosG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkAsignarPermisosE.Checked = true;
                    }
                }
            }
        }
    }
}