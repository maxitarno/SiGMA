using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;

namespace SiGMA
{
    public partial class ModerarPedidosDifusion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grvPedidos.DataSource = LogicaBDPedidoDifusion.buscarPedidosDifusion(LogicaBDEstado.buscarEstadoPorNombre("Pendiente de Aceptacion"));
                grvPedidos.DataBind();
            }
            Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
            imgprvw.Src = ResolveUrl("~/Handler1.ashx");
            imgprvw.Width = 300;
            imgprvw.Height = 200;
        }

        protected void ddlResolucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlResolucion.SelectedValue.Equals("Rechazar"))
            {
                txtRechazo.Enabled = true;
                txtRechazo.Visible = true;
                lblRechazo.Visible = true;
            }
            else
            {
                txtRechazo.Enabled = false;
                txtRechazo.Visible = false;
                lblRechazo.Visible = false;

            }
        }

        protected void grvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string asd = grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[0].Text;
            
            
            if (grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[0].Text.Contains("Campa"))
            {

                ECampaña entCampaña = LogicaBDCampaña.buscarCampaña(Int32.Parse(grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[4].Text));
                string asd2 = entCampaña.hora.ToString("HH:mm");
                lblDatosCampaña.Text = "Tipo de campaña: " + entCampaña.tipoCampaña.descripcion + ", fecha: " + entCampaña.fecha.ToShortDateString()
                    + ", lugar: " + entCampaña.lugar + ", hora: " + entCampaña.hora.ToString("HH:mm");
                if (entCampaña.imagen != null)
                {
                    ponerImagen(entCampaña.imagen);
                }
                else
                {
                    ponerImagen(null);
                }
            }
            pnlDatos.Visible = true;
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
                Session["imagen"] = null;
                return imagen;
            }
            else
                return null;
        }
    }
}