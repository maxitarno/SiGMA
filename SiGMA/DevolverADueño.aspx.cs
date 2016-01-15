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
    public partial class DevolverADueño : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listarMascotas();
        }

        private void listarMascotas()
        {
            try 
            {
	            List<EMascota> lstMascotas = LogicaBDMascota.buscarHalladasConDueño();
                List<EHallazgo> lstHallazgos = LogicaBDHallazgo.buscarHallazgosPorIdMascotas(lstMascotas);
                if (lstHallazgos.Count() != 0)
                {
                    grvMascotas.DataSource = lstHallazgos;
                    grvMascotas.DataBind();
                    pnlMascotas.Visible = true;
                    pnlInfo.Visible = false;
                    Session["listaHallazgos"] = lstHallazgos;
                }
                else
                {
                    pnlMascotas.Visible = false;
                    pnlInfo.Visible = true;
                }
                pnlDatos.Visible = false;
                pnlDatos1.Visible = false;
            }
            catch (Exception)
            {
                pnlInfo.Visible = false;
                pnlMascotas.Visible = false;
                pnlAtento.Visible = true;
                lblError.Text = "Error al cargar las mascotas halladas.";
            }            
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
            Session["mascotaDevolver"] = mascota;
        }        

        protected void grvMascotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<EHallazgo> lstHallazgos = (List<EHallazgo>)Session["listaHallazgos"];
            int fila = int.Parse(e.CommandArgument.ToString());
            string dato = grvMascotas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text;
            int idHallazgoSelec = int.Parse(grvMascotas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text);
            Session["idHallazgo"] = idHallazgoSelec;
            EMascota entMascota = lstHallazgos.First(h => h.idHallazgo == idHallazgoSelec).mascota;
            cargarDatosMascota(entMascota);
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

        protected void btnDevolver_Click(object sender, EventArgs e)
        {            
            try
            {
                EMascota entMascota = (EMascota)Session["mascotaDevolver"];
                LogicaBDMascota.devolverADueño(entMascota);
                EHallazgo entHallazgo = new EHallazgo();
                entHallazgo.idHallazgo = int.Parse(Session["idHallazgo"].ToString());
                LogicaBDHallazgo.modificarEstado("Cerrada", entHallazgo);
                pnlCorrecto.Visible = true;
                pnlAtento.Visible = false;
                lblCorrecto.Text = "Devolucion registrada exitosamente.";
                listarMascotas();
            }
            catch (Exception)
            {
                pnlAtento.Visible = true;
                pnlCorrecto.Visible = false;
                lblError.Text = "Error al registrar la devolucion.";
            }            
        }
    }
}