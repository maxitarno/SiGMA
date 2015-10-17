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
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "Administracion"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "Administracion"))
                        btnGuardar.Visible = false;
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

                    // --------------- RegistrarVeterinarias --------------- //

                    EPermiso permisoRol37 = new EPermiso();
                    permisoRol37.idPermiso = chkRegistrarVeterinariaL.Checked ? 1 : 0;
                    permisoRol37.pantalla = "RegistrarVeterinaria.aspx";
                    if (permisoRol37.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol37);

                    EPermiso permisoRol38 = new EPermiso();
                    permisoRol38.idPermiso = chkRegistrarVeterinariaG.Checked ? 2 : 0;
                    permisoRol38.pantalla = "RegistrarVeterinaria.aspx";
                    if (permisoRol38.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol38);

                    EPermiso permisoRol39 = new EPermiso();
                    permisoRol39.idPermiso = chkRegistrarVeterinariaE.Checked ? 3 : 0;
                    permisoRol39.pantalla = "RegistrarVeterinaria.aspx";
                    if (permisoRol39.idPermiso != 0)
                        ListadoPermisos.Add(permisoRol39);

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
            chkRegistrarUsuarioL.Checked = false;
            chkRegistrarUsuarioG.Checked = false;
            chkRegistrarUsuarioE.Checked = false;
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
                    if (permisosRol[i].pantalla == "ConsultarPerdida.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarPerdidasL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarPerdidasG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarPerdidasE.Checked = true;
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
                    if (permisosRol[i].pantalla == "ConsultarHallazgo.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarHallazgosL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarHallazgosG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarHallazgosE.Checked = true;
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
                    if (permisosRol[i].pantalla == "ConsultarAdopcion.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkConsultarAdopcionesL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkConsultarAdopcionesG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkConsultarAdopcionesE.Checked = true;
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
                    if (permisosRol[i].pantalla == "RegistrarVeterinaria.aspx")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkRegistrarVeterinariaL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkRegistrarVeterinariaG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkRegistrarVeterinariaE.Checked = true;
                    }
                    if (permisosRol[i].pantalla == "Administracion")
                    {
                        if (permisosRol[i].idPermiso == 1)
                            chkAdministracionL.Checked = true;
                        if (permisosRol[i].idPermiso == 2)
                            chkAdministracionG.Checked = true;
                        if (permisosRol[i].idPermiso == 3)
                            chkAdministracionE.Checked = true;
                    }
                }
            }
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Administracion.aspx");
        }
    }
}