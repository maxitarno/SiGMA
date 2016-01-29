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
    public partial class AsignarMascotaHogar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "Voluntariado"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "Voluntariado"))
                    { }
                    if (!LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "Voluntariado"))
                    { }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                cargarDatosMascota();
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
            }
        }

        private void cargarDatosMascota()
        {            
            int idMascota = 0;
            if (Session["idMascotaHallada"] != null)
            {
                idMascota = Int32.Parse(Session["idMascotaHallada"].ToString());
            }
            else
            {
                idMascota = Int32.Parse(Session["idMascota"].ToString());
            }
            lblIdMascota.Text = idMascota.ToString();
            if(idMascota != 0)
            {
                EMascota entMascota = LogicaBDMascota.BuscarMascotaPorIdMascota(idMascota);
                lblNombre.Text = entMascota.nombreMascota;
                lblRaza.Text = entMascota.raza.nombreRaza;
                lblSexo.Text = entMascota.sexo;
                lblEdad.Text = entMascota.edad.nombreEdad + " - " + entMascota.edad.descripcion;
                if (entMascota.tratoAnimal != null)
                {
                    lblTratoAnimales.Text = entMascota.tratoAnimal == false ? "No" : "Si";
                }
                else
                {
                    lblTratoAnimales.Text = "No especificado";
                }
                if (entMascota.tratoNiños != null)
                {
                    lblTratoNiños.Text = entMascota.tratoNiños == false ? "No" : "Si";
                }
                else
                {
                    lblTratoNiños.Text = "No especificado";
                }
                if (entMascota.caracter.descripcion != null)
                {
                    lblTemperamento.Text = entMascota.caracter.descripcion;
                }
                else
                {
                    lblTemperamento.Text = "No especificado";
                }
                if (entMascota.imagen != null)
                {
                    Session["imagen"] = entMascota.imagen;
                    Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                    imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                    imgprvw.Width = 400;
                    imgprvw.Height = 300;
                }
            }
        }

        protected void btnBuscarHogares_Click(object sender, EventArgs e)
        {
            listarHogares();
        }

        private void listarHogares()
        {
            EHogarProvisorio entHogar = new EHogarProvisorio();
            entHogar.AceptaEspecie = Int32.Parse(ddlEspecie.SelectedValue);
            entHogar.tieneNiños = ddlNiños.SelectedValue;
            entHogar.tipoHogar = Int32.Parse(ddlTipoHogar.SelectedValue);
            List<EHogarProvisorio> lstHogares = LogicaBDHogar.buscarHogaresDisponibles(entHogar);           
            if (lstHogares.Count == 0)
            {
                lblNoHogares.Visible = true;
                SetFocus(lblNoHogares);
                grvHogares.Visible = false;
            }
            else
            {
                grvHogares.DataSource = lstHogares;
                grvHogares.DataBind();
                grvHogares.Visible = true;
                lblNoHogares.Visible = false;
            }
            pnlDatosVoluntario.Visible = false;
            pnlAsignar.Visible = false;
        }

        public byte[] ImageHandler_ObtenerImagenMascota(HttpContext context)
        {            
            if (Session["imagen"] != null)
            {
                var imagen = (byte[])Session["imagen"];                
                //Session["imagen"] = null;
                return imagen;
            }
            else
                return null;
        }

        protected void grvHogares_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EHogarProvisorio entHogar = new EHogarProvisorio();
            entHogar.voluntario = new EVoluntario();
            entHogar.voluntario.idVoluntario = int.Parse(grvHogares.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text);
            entHogar.disponibilidad = int.Parse(grvHogares.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text);
            entHogar.cantMascotas = int.Parse(grvHogares.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text);
            entHogar.idHogar = int.Parse(grvHogares.Rows[int.Parse(e.CommandArgument.ToString())].Cells[7].Text);
            Session["hogarSelec"] = entHogar;
            cargarDatosVoluntario(entHogar.voluntario.idVoluntario);
        }

        private void cargarDatosVoluntario(int idVoluntario)
        {
            EVoluntario entVoluntario = LogicaBDVoluntario.buscarVoluntarioPorId(idVoluntario);
            defaultLabels();
            lblNombreVoluntario.Text += entVoluntario.persona.nombre + " " + entVoluntario.persona.apellido;
            if (entVoluntario.persona.domicilio.nombre != null)
            {
                lblDireccion.Text += entVoluntario.persona.domicilio.nombre.ToLower() + " " + entVoluntario.persona.nroCalle;
            }
            else
            {
                lblDireccion.Text += "-";
            }
            if (entVoluntario.persona.barrio.nombre != null)
            {
                lblBarrio.Text += entVoluntario.persona.barrio.nombre.ToLower();
            }
            else
            {
                lblBarrio.Text += "-";
            }
            if (entVoluntario.persona.telefonoCelular != null)
            {
                lblTelefonoCel.Text += entVoluntario.persona.telefonoCelular;
            }
            else
            {
                lblTelefonoCel.Text += "-";
            }
            if (entVoluntario.persona.telefonoFijo != null)
            {
                lblTelefonoFijo.Text += entVoluntario.persona.telefonoFijo;
            }
            else
            {
                lblTelefonoFijo.Text += "-";
            }
            pnlDatosVoluntario.Visible = true;
            pnlAsignar.Visible = true;
            btnAsignar.Focus();
        }

        private void defaultLabels()
        {
            lblNombreVoluntario.Text = "Nombre: ";
            lblDireccion.Text = "Direccion: ";
            lblBarrio.Text = "Barrio: ";
            lblTelefonoCel.Text = "Celular: ";
            lblTelefonoFijo.Text = "Telefono fijo: ";
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            EOcupacionHogar entOcupacion = new EOcupacionHogar();
            entOcupacion.hogar = (EHogarProvisorio)Session["hogarSelec"];
            entOcupacion.mascota = new EMascota();
            entOcupacion.mascota.idMascota = int.Parse(lblIdMascota.Text);
            var fecha = DateTime.Today;
            if (DateTime.TryParse(txtFecha.Text, out fecha))
                entOcupacion.fechaIngreso = Convert.ToDateTime(txtFecha.Text);
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Ingrese una fecha válida";
            }
            try
            {
                LogicaBDHogar.registrarOcupacion(entOcupacion);
                pnlDatos.Visible = false;
                pnlDatos1.Visible = false;
                pnlImagenAsignar.Visible = true;
                pnlCorrecto.Visible = true;
                lblCorrecto.Text = "Asignacion registrada correctamente";
                pnlAtento.Visible = false;
            }
            catch (Exception)
            {
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = true;
                lblError.Text = "Error al registrar la asignacion";
            }
        }
    }
}