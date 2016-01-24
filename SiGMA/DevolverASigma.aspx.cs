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
    public partial class DevolverASigma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listarSolicitudes();
        }

        private void listarSolicitudes()
        {
            try
            {
                List<EOcupacionHogar> lstOcupaciones = LogicaBDHogar.buscarSolicitudesDevolucion();
                if (lstOcupaciones.Count() != 0)
                {
                    grvMascotas.DataSource = lstOcupaciones;
                    grvMascotas.DataBind();
                    pnlMascotas.Visible = true;
                    pnlInfo.Visible = false;
                    Session["listaOcupaciones"] = lstOcupaciones;
                }
                else
                {
                    pnlMascotas.Visible = false;
                    pnlInfo.Visible = true;
                }
                pnlDatos.Visible = false;
                pnlDatos1.Visible = false;
                pnlImagenDevolver.Visible = true;
            }
            catch (Exception)
            {
                pnlInfo.Visible = false;
                pnlMascotas.Visible = false;
                pnlAtento.Visible = true;
                lblError.Text = "Error al cargar las solicitudes de devolucion.";
            }        
        }

        protected void grvMascotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<EOcupacionHogar> lstOcupaciones = (List<EOcupacionHogar>)Session["listaOcupaciones"];                        
            int idOcupacionSelec = int.Parse(grvMascotas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Text);
            Session["idOcupacion"] = idOcupacionSelec;
            EMascota entMascota = lstOcupaciones.First(h => h.idOcupacion == idOcupacionSelec).mascota;
            cargarDatosMascota(entMascota);
            txtVoluntario.Text = lstOcupaciones.First(h => h.idOcupacion == idOcupacionSelec).hogar.voluntario.persona.nombre + " " +
                lstOcupaciones.First(h => h.idOcupacion == idOcupacionSelec).hogar.voluntario.persona.apellido;
        }

        private void cargarDatosMascota(EMascota mascota)
        {
            txtNombre.Text = mascota.nombreMascota;
            txtEspecie.Text = mascota.especie.nombreEspecie;
            txtRaza.Text = mascota.raza.nombreRaza;
            txtSexo.Text = mascota.sexo;
            txtEdad.Text = mascota.edad.nombreEdad;
            if (mascota.imagen != null)
            {
                ponerImagen(mascota.imagen);
            }
            else
            {
                ponerImagen(null);
            }
            pnlDatos.Visible = true;
            pnlDatos1.Visible = true;
            pnlImagenDevolver.Visible = false;
            Session["mascotaDevolver"] = mascota;
        }

        protected void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {                
                EMascota entMascota = (EMascota)Session["mascotaDevolver"];
                LogicaBDHogar.aceptarDevolucion(entMascota.idMascota, Convert.ToDateTime(txtFecha.Text));                
                pnlCorrecto.Visible = true;
                pnlAtento.Visible = false;
                lblCorrecto.Text = "Devolucion registrada exitosamente.";
                txtFecha.Text = "";
                listarSolicitudes();
            }
            catch (Exception)
            {
                pnlAtento.Visible = true;
                pnlCorrecto.Visible = false;
                lblError.Text = "Error al registrar la devolucion.";
            }
        }

        private void ponerImagen(byte[] imagen)
        {
            Session["imagen"] = imagen;
            Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
            imgprvw.Src = ResolveUrl("~/Handler1.ashx");
            imgprvw.Width = 300;
            imgprvw.Height = 200;
        }

        public byte[] ImageHandler_ObtenerImagenMascota(HttpContext context)
        {
            if (Session["imagen"] != null)
            {
                var imagen = (byte[])Session["imagen"];
                return imagen;
            }
            else
                return null;
        }
    }
}