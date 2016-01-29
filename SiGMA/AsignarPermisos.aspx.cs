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
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RolesPermisos"))
                        btnGuardar.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarRoles(ref ddlRol);
                ddlRol.SelectedIndex = 1;
                ddlRol_SelectedIndexChanged(null, null);
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
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

                    // --------------- Administracion --------------- //
                    EPermiso permisoRol16 = new EPermiso();
                    permisoRol16.idPermiso = chkAdministracionL.Checked ? 1 : 0;
                    permisoRol16.pantalla = "Administracion";
                    if (permisoRol16.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol16);

                    EPermiso permisoRol17 = new EPermiso();
                    permisoRol17.idPermiso = chkAdministracionG.Checked ? 2 : 0;
                    permisoRol17.pantalla = "Administracion";
                    if (permisoRol17.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol17);

                    EPermiso permisoRol18 = new EPermiso();
                    permisoRol18.idPermiso = chkAdministracionE.Checked ? 3 : 0;
                    permisoRol18.pantalla = "Administracion";
                    if (permisoRol18.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol18);

                    // --------------- RolesPermisos --------------- //
                    EPermiso permisoRol1 = new EPermiso();
                    permisoRol1.idPermiso = chkAsignarPermisosL.Checked ? 1 : 0;
                    permisoRol1.pantalla = "RolesPermisos";
                    if (permisoRol1.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol1);

                    EPermiso permisoRol2 = new EPermiso();
                    permisoRol2.idPermiso = chkAsignarPermisosG.Checked ? 2 : 0;
                    permisoRol2.pantalla = "RolesPermisos";
                    if (permisoRol2.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol2);

                    EPermiso permisoRol3 = new EPermiso();
                    permisoRol3.idPermiso = chkAsignarPermisosE.Checked ? 3 : 0;
                    permisoRol3.pantalla = "RolesPermisos";
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

                    // --------------- ConsultarPerdida --------------- //

                    EPermiso permisoRol19 = new EPermiso();
                    permisoRol19.idPermiso = chkConsultarPerdidasL.Checked ? 1 : 0;
                    permisoRol19.pantalla = "ConsultarPerdida.aspx";
                    if (permisoRol19.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol19);

                    EPermiso permisoRol20 = new EPermiso();
                    permisoRol20.idPermiso = chkConsultarPerdidasG.Checked ? 2 : 0;
                    permisoRol20.pantalla = "ConsultarPerdida.aspx";
                    if (permisoRol20.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol20);

                    EPermiso permisoRol21 = new EPermiso();
                    permisoRol21.idPermiso = chkConsultarPerdidasE.Checked ? 3 : 0;
                    permisoRol21.pantalla = "ConsultarPerdida.aspx";
                    if (permisoRol21.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol21);

                    // --------------- RegistrarPerdidas --------------- //

                    EPermiso permisoRol22 = new EPermiso();
                    permisoRol22.idPermiso = chkRegistrarPerdidasL.Checked ? 1 : 0;
                    permisoRol22.pantalla = "RegistrarPerdida.aspx";
                    if (permisoRol22.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol22);

                    EPermiso permisoRol23 = new EPermiso();
                    permisoRol23.idPermiso = chkRegistrarPerdidasG.Checked ? 2 : 0;
                    permisoRol23.pantalla = "RegistrarPerdida.aspx";
                    if (permisoRol23.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol23);

                    EPermiso permisoRol24 = new EPermiso();
                    permisoRol24.idPermiso = chkRegistrarPerdidasE.Checked ? 3 : 0;
                    permisoRol24.pantalla = "RegistrarPerdida.aspx";
                    if (permisoRol24.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol24);

                    // --------------- ConsultarHallazgos --------------- //

                    EPermiso permisoRol25 = new EPermiso();
                    permisoRol25.idPermiso = chkConsultarHallazgosL.Checked ? 1 : 0;
                    permisoRol25.pantalla = "ConsultarHallazgo.aspx";
                    if (permisoRol25.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol25);

                    EPermiso permisoRol26 = new EPermiso();
                    permisoRol26.idPermiso = chkConsultarHallazgosG.Checked ? 2 : 0;
                    permisoRol26.pantalla = "ConsultarHallazgo.aspx";
                    if (permisoRol26.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol26);

                    EPermiso permisoRol27 = new EPermiso();
                    permisoRol27.idPermiso = chkConsultarHallazgosE.Checked ? 3 : 0;
                    permisoRol27.pantalla = "ConsultarHallazgo.aspx";
                    if (permisoRol27.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol27);

                    // --------------- RegistrarHallazgos --------------- //

                    EPermiso permisoRol28 = new EPermiso();
                    permisoRol28.idPermiso = chkRegistrarHallazgosL.Checked ? 1 : 0;
                    permisoRol28.pantalla = "RegistrarHallazgo.aspx";
                    if (permisoRol28.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol28);

                    EPermiso permisoRol29 = new EPermiso();
                    permisoRol29.idPermiso = chkRegistrarHallazgosG.Checked ? 2 : 0;
                    permisoRol29.pantalla = "RegistrarHallazgo.aspx";
                    if (permisoRol29.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol29);

                    EPermiso permisoRol30 = new EPermiso();
                    permisoRol30.idPermiso = chkRegistrarHallazgosE.Checked ? 3 : 0;
                    permisoRol30.pantalla = "RegistrarHallazgo.aspx";
                    if (permisoRol30.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol30);

                    // --------------- ConsultarAdopciones --------------- //

                    EPermiso permisoRol31 = new EPermiso();
                    permisoRol31.idPermiso = chkConsultarAdopcionesL.Checked ? 1 : 0;
                    permisoRol31.pantalla = "ConsultarAdopcion.aspx";
                    if (permisoRol31.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol31);

                    EPermiso permisoRol32 = new EPermiso();
                    permisoRol32.idPermiso = chkConsultarAdopcionesG.Checked ? 2 : 0;
                    permisoRol32.pantalla = "ConsultarAdopcion.aspx";
                    if (permisoRol32.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol32);

                    EPermiso permisoRol33 = new EPermiso();
                    permisoRol33.idPermiso = chkConsultarAdopcionesE.Checked ? 3 : 0;
                    permisoRol33.pantalla = "ConsultarAdopcion.aspx";
                    if (permisoRol33.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol33);

                    // --------------- RegistrarAdopciones --------------- //

                    EPermiso permisoRol34 = new EPermiso();
                    permisoRol34.idPermiso = chkRegistrarAdopcionesL.Checked ? 1 : 0;
                    permisoRol34.pantalla = "RegistrarAdopcion.aspx";
                    if (permisoRol34.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol34);

                    EPermiso permisoRol35 = new EPermiso();
                    permisoRol35.idPermiso = chkRegistrarAdopcionesG.Checked ? 2 : 0;
                    permisoRol35.pantalla = "RegistrarAdopcion.aspx";
                    if (permisoRol35.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol35);

                    EPermiso permisoRol36 = new EPermiso();
                    permisoRol36.idPermiso = chkRegistrarAdopcionesE.Checked ? 3 : 0;
                    permisoRol36.pantalla = "RegistrarAdopcion.aspx";
                    if (permisoRol36.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol36);

                    // --------------- Veterinarias --------------- //

                    EPermiso permisoRol37 = new EPermiso();
                    permisoRol37.idPermiso = chkRegistrarVeterinariaL.Checked ? 1 : 0;
                    permisoRol37.pantalla = "Veterinarias";
                    if (permisoRol37.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol37);

                    EPermiso permisoRol38 = new EPermiso();
                    permisoRol38.idPermiso = chkRegistrarVeterinariaG.Checked ? 2 : 0;
                    permisoRol38.pantalla = "Veterinarias";
                    if (permisoRol38.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol38);

                    EPermiso permisoRol39 = new EPermiso();
                    permisoRol39.idPermiso = chkRegistrarVeterinariaE.Checked ? 3 : 0;
                    permisoRol39.pantalla = "Veterinarias";
                    if (permisoRol39.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol39);

                    // --------------- Voluntariado --------------- //

                    EPermiso permisoRol7 = new EPermiso();
                    permisoRol7.idPermiso = chkVoluntariadoL.Checked ? 1 : 0;
                    permisoRol7.pantalla = "Voluntariado";
                    if (permisoRol7.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol7);

                    EPermiso permisoRol8 = new EPermiso();
                    permisoRol8.idPermiso = chkVoluntariadoG.Checked ? 2 : 0;
                    permisoRol8.pantalla = "Voluntariado";
                    if (permisoRol8.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol8);

                    EPermiso permisoRol9 = new EPermiso();
                    permisoRol9.idPermiso = chkVoluntariadoE.Checked ? 3 : 0;
                    permisoRol9.pantalla = "Voluntariado";
                    if (permisoRol9.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol9);

                    // --------------- Campañas --------------- //

                    EPermiso permisoRo40 = new EPermiso();
                    permisoRo40.idPermiso = chkCampañasL.Checked ? 1 : 0;
                    permisoRo40.pantalla = "Campañas";
                    if (permisoRo40.idPermiso != 0)
                        ListadoPermisos.Add(permisoRo40);

                    EPermiso permisoRo41 = new EPermiso();
                    permisoRo41.idPermiso = chkCampañasG.Checked ? 2 : 0;
                    permisoRo41.pantalla = "Campañas";
                    if (permisoRo41.idPermiso != 0)
                        ListadoPermisos.Add(permisoRo41);

                    EPermiso permisoRo42 = new EPermiso();
                    permisoRo42.idPermiso = chkCampañasE.Checked ? 3 : 0;
                    permisoRo42.pantalla = "Campañas";
                    if (permisoRo42.idPermiso != 0)
                        ListadoPermisos.Add(permisoRo42);

                    // --------------- PedidosDifusion --------------- //

                    EPermiso permisoRo43 = new EPermiso();
                    permisoRo43.idPermiso = chkDifusionL.Checked ? 1 : 0;
                    permisoRo43.pantalla = "PedidosDifusion";
                    if (permisoRo43.idPermiso != 0)
                        ListadoPermisos.Add(permisoRo43);

                    EPermiso permisoRo44 = new EPermiso();
                    permisoRo44.idPermiso = chkDifusionG.Checked ? 2 : 0;
                    permisoRo44.pantalla = "PedidosDifusion";
                    if (permisoRo44.idPermiso != 0)
                        ListadoPermisos.Add(permisoRo44);

                    EPermiso permisoRo45 = new EPermiso();
                    permisoRo45.idPermiso = chkDifusionE.Checked ? 3 : 0;
                    permisoRo45.pantalla = "PedidosDifusion";
                    if (permisoRo45.idPermiso != 0)
                        ListadoPermisos.Add(permisoRo45);

                    ERol RolEnviar = new ERol();
                    RolEnviar.listaPermisos = ListadoPermisos;
                    RolEnviar.idRol = idRol;

                    if (LogicaBDRol.guardarPermisoRol(RolEnviar))
                    {
                        limpiarPagina();
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Rol Actualizado Correctamente";
                    }
                    else
                    {
                        pnlAtento.Visible = true;
                        lblError.Text = "No se actualizo el rol. Verifique datos";
                    }
                }
            }
            catch (Exception exc)
            {
                pnlAtento.Visible = true;
                lblError.Text = "" + exc.ToString();
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
            chkAdministracionL.Checked = false;
            chkAdministracionG.Checked = false;
            chkAdministracionE.Checked = false;
            chkConsultarMascotasL.Checked = false;
            chkConsultarMascotasG.Checked = false;
            chkConsultarMascotasE.Checked = false;
            chkRegistrarMascotasL.Checked = false;
            chkRegistrarMascotasG.Checked = false;
            chkRegistrarMascotasE.Checked = false;
            chkConsultarPerdidasL.Checked = false;
            chkConsultarPerdidasG.Checked = false;
            chkConsultarPerdidasE.Checked = false;
            chkRegistrarPerdidasL.Checked = false;
            chkRegistrarPerdidasG.Checked = false;
            chkRegistrarPerdidasE.Checked = false;
            chkConsultarHallazgosL.Checked = false;
            chkConsultarHallazgosG.Checked = false;
            chkConsultarHallazgosE.Checked = false;
            chkRegistrarHallazgosL.Checked = false;
            chkRegistrarHallazgosG.Checked = false;
            chkRegistrarHallazgosE.Checked = false;
            chkConsultarAdopcionesL.Checked = false;
            chkConsultarAdopcionesG.Checked = false;
            chkConsultarAdopcionesE.Checked = false;
            chkRegistrarAdopcionesL.Checked = false;
            chkRegistrarAdopcionesG.Checked = false;
            chkRegistrarAdopcionesE.Checked = false;
            chkRegistrarVeterinariaL.Checked = false;
            chkRegistrarVeterinariaG.Checked = false;
            chkRegistrarVeterinariaE.Checked = false;
            chkVoluntariadoL.Checked = false;
            chkVoluntariadoG.Checked = false;
            chkVoluntariadoE.Checked = false;
            chkCampañasL.Checked = false;
            chkCampañasG.Checked = false;
            chkCampañasE.Checked = false;
            chkDifusionL.Checked = false;
            chkDifusionG.Checked = false;
            chkDifusionE.Checked = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
            pnlPermisos.Visible = false;
            ddlRol.SelectedValue = "SIN ASIGNAR";
            lblRol.Text = "";
        }

        //Cargar los checkbox segun el Rol seleccionado
        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreRol = ddlRol.SelectedItem.Text;
            int idRol = Convert.ToInt32(ddlRol.SelectedValue);
            List<EPermiso> permisosRol = new List<EPermiso>();
            if (ddlRol.SelectedItem.Value == "SIN ASIGNAR")
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
                    if (permisosRol[i].pantalla == "Administracion")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkAdministracionL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkAdministracionG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkAdministracionE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "RolesPermisos")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkAsignarPermisosL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkAsignarPermisosG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkAsignarPermisosE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "ConsultarUsuario.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarUsuarioL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarUsuarioG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarUsuarioE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "RegistrarMascota.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkRegistrarMascotasL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkRegistrarMascotasG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkRegistrarMascotasE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "ConsultarMascotas.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarMascotasL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarMascotasG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarMascotasE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "RegistrarPerdida.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkRegistrarPerdidasL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkRegistrarPerdidasG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkRegistrarPerdidasE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "ConsultarPerdida.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarPerdidasL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarPerdidasG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarPerdidasE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "RegistrarHallazgo.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkRegistrarHallazgosL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkRegistrarHallazgosG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkRegistrarHallazgosE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "ConsultarHallazgo.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarHallazgosL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarHallazgosG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarHallazgosE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "RegistrarAdopcion.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkRegistrarAdopcionesL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkRegistrarAdopcionesG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkRegistrarAdopcionesE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "ConsultarAdopcion.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarAdopcionesL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarAdopcionesG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarAdopcionesE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "Veterinarias")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkRegistrarVeterinariaL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkRegistrarVeterinariaG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkRegistrarVeterinariaE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "Voluntariado")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkVoluntariadoL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkVoluntariadoG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkVoluntariadoE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "Campañas")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkCampañasL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkCampañasG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkCampañasE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "PedidosDifusion")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkDifusionL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkDifusionG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkDifusionE.Checked = true;
                    }
                }
                btnGuardar.Focus();
            }
        }
    }
}
