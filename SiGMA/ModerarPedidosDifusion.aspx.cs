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
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "PedidosDifusion"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "PedidosDifusion"))
                        btnAceptar.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                listarPedidosDifusion();
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
            }
            ponerImagen((byte[])Session["imagen"]);
        }

        private void listarPedidosDifusion()
        {
            List<EPedidoDifusion> listPedidos = LogicaBDPedidoDifusion.buscarPedidosDifusion(LogicaBDEstado.buscarEstado(
                    new EEstado { nombreEstado = "Pendiente de Aceptacion", ambito = "Difusion" }));
            grvPedidos.DataSource = listPedidos;
            grvPedidos.DataBind();
            if (listPedidos.Count == 0)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "No hay pedidos para moderar";
                pnlPedidos.Visible = false;
                pnlImagenPedidoDifusion.Visible = true;
                SetFocus(lblInfo);
            }
        }

        protected void ddlResolucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlResolucion.SelectedValue.Equals("Rechazar"))
            {
                txtRechazo.Enabled = true;
                txtRechazo.Text = "";
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
            EPedidoDifusion pedido = new EPedidoDifusion();
            pedido.idPedidoDifusion = int.Parse(grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[3].Text);
            pedido.tipo = grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[0].Text;
            pedido.user = new EUsuario { user = grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[2].Text };
            pedido.fecha = DateTime.Parse(grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[1].Text);
            if (pedido.tipo.Contains("Campa"))
            {
                ECampaña entCampaña = LogicaBDCampaña.buscarCampaña(Int32.Parse(grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[4].Text));
                lblDatos.Text = "Tipo de campaña: " + entCampaña.tipoCampaña.descripcion + ", fecha: " + entCampaña.fecha.ToShortDateString()
                    + ", lugar: " + entCampaña.lugar + ", hora: " + entCampaña.hora.ToString("HH:mm");
                if (entCampaña.imagen != null)
                {
                    ponerImagen(entCampaña.imagen);
                }
                else
                {
                    ponerImagen(null);
                }
                pedido.campaña = entCampaña;
            }
            else if(pedido.tipo.Contains("Adop"))
            {
                EMascota entMascota = LogicaBDMascota.BuscarMascotaPorIdMascota(
                    Int32.Parse(grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[7].Text));
                lblDatos.Text = entMascota.especie.nombreEspecie + ", raza: " + entMascota.raza.nombreRaza + ", edad: " + entMascota.edad.nombreEdad + ", sexo: "
                    + entMascota.sexo;
                if (entMascota.imagen != null)
                {
                    ponerImagen(entMascota.imagen);
                }
                else
                {
                    ponerImagen(null);
                }
                pedido.mascota = entMascota;
            }
            else if (pedido.tipo.Contains("Perd"))
            {
                EPerdida entPerdida = LogicaBDPerdida.buscarPerdida(
                    Int32.Parse(grvPedidos.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[6].Text));
                lblDatos.Text = "Mascota perdida en " + entPerdida.domicilio.calle.nombre.ToLower() + " " +
                    entPerdida.domicilio.numeroCalle + ", " + entPerdida.domicilio.barrio.nombre.ToLower();
                if (entPerdida.mascota.imagen != null)
                {
                    ponerImagen(entPerdida.mascota.imagen);
                }
                else
                {
                    ponerImagen(null);
                }
                pedido.perdida = entPerdida;
            }
            pnlDatos.Visible = true;
            pnlResolucion.Visible = true;
            Session["PedidoDifusion"] = pedido;
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    EPedidoDifusion pedido = (EPedidoDifusion)Session["PedidoDifusion"];
                    if (ddlResolucion.SelectedValue.Equals("Rechazar"))
                    {
                        pedido.motivoRechazo = txtRechazo.Text;
                        pedido.estado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Rechazado", ambito = "Difusion" });
                        LogicaBDPedidoDifusion.modificarPedidoDifusion(pedido);
                        lblCorrecto.Text = "Pedido rechazado exitosamente";
                    }
                    else
                    {
                        pedido.estado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Publicado", ambito = "Difusion" });
                        LogicaBDPedidoDifusion.modificarPedidoDifusion(pedido);
                        var tweet = new Herramientas.GestorTwitter();
                        byte[] imagen = null;
                        if (pedido.campaña != null)
                        {
                           imagen = pedido.campaña.imagen;
                           if (imagen != null)
                           {
                               tweet.PublicarTweetConFoto(imagen, tweet.generarMensajeCampaña(pedido.campaña));
                           }
                           else
                           {
                               tweet.PublicarTweetSoloTexto(tweet.generarMensajeCampaña(pedido.campaña));
                           }
                        }
                        else if (pedido.mascota != null)
                        {
                            imagen = pedido.mascota.imagen;
                            if (imagen != null)
                            {
                                tweet.PublicarTweetConFoto(imagen, tweet.generarMensajeAdopcion(pedido.mascota));
                            }
                            else
                            {
                                tweet.PublicarTweetSoloTexto(tweet.generarMensajeAdopcion(pedido.mascota));
                            }
                            LogicaBDMascota.ponerEnAdopcion(pedido.mascota.idMascota);
                        }
                        else if (pedido.perdida != null)
                        {
                            imagen = pedido.perdida.mascota.imagen;
                            if (imagen != null)
                            {
                                tweet.PublicarTweetConFoto(imagen, tweet.generarMensajePerdida(pedido.perdida));
                            }
                            else
                            {
                                tweet.PublicarTweetSoloTexto(tweet.generarMensajePerdida(pedido.perdida));
                            }
                        }
                        lblCorrecto.Text = "Pedido publicado exitosamente";
                    }
                    pnlCorrecto.Visible = true;
                    pnlAtento.Visible = false;
                    SetFocus(lblCorrecto);
                }
                catch (Exception)
                {
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = true;
                    lblError.Text = "Error al moderar el pedido, intente de nuevo mas tarde.";
                    SetFocus(lblError);                    
                }
                finally
                {
                    listarPedidosDifusion();
                    pnlDatos.Visible = false;
                    pnlResolucion.Visible = false;
                    ddlResolucion.SelectedIndex = 0;
                    txtRechazo.Text = "";
                    txtRechazo.Visible = false;
                    lblRechazo.Visible = false;
                }
            }
        }

        protected void cvRechazo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlResolucion.SelectedValue.Equals("Rechazar") && txtRechazo.Text.Equals(""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}