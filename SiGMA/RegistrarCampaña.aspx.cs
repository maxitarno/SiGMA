using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;
using Entidades;
using AccesoADatos;

namespace SiGMA
{
    public partial class RegistrarCampaña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarTipoCampaña(ref ddlTipoCampaña);
            }
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void cvTipoCampaña_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTipoCampaña);
        }

        protected void btnRegistrarCampaña_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ECampaña campaña = new ECampaña();
                campaña.tipoCampaña = new ETipoCampaña();
                campaña.tipoCampaña.idTipoCampaña = int.Parse(ddlTipoCampaña.SelectedValue);
                campaña.tipoCampaña.descripcion = ddlTipoCampaña.SelectedItem.Text;
                campaña.fecha = DateTime.Parse(txtFecha.Text);
                campaña.lugar = txtLugar.Text;
                campaña.hora = DateTime.Parse(txtHora.Text);
                if (fuImagen.PostedFile.ContentLength != 0)
                {
                    if (!GestorImagen.verificarTamaño(fuImagen.PostedFile.ContentLength))
                    {
                        pnlAtento.Visible = true;
                        lblError.Text = "El tamaño de la imagen no debe superar 1Mb";
                        return;
                    }
                    byte[] imagen = GestorImagen.obtenerArrayBytes(fuImagen.PostedFile.InputStream, fuImagen.PostedFile.ContentLength);
                    campaña.imagen = imagen;
                }
                else
                {
                    campaña.imagen = null;
                }
                try
                {
                    if (LogicaBDRol.puedePublicarDifusion(Session["UsuarioLogueado"].ToString()))
                    {
                        LogicaBDCampaña.registrarCampaña(campaña);
                        var tweet = new Herramientas.GestorTwitter();
                        string mensaje = "Nueva campaña de " + campaña.tipoCampaña.descripcion +
                                ", Fecha: " + campaña.fecha.ToShortDateString() + " a las " + campaña.hora.ToString("HH:mm")
                                + " en " + campaña.lugar;
                        var imagen = campaña.imagen;
                        if (imagen != null)
                        {
                            tweet.PublicarTweetConFoto(imagen, mensaje);
                        }
                        else
                        {
                            tweet.PublicarTweetSoloTexto(mensaje);
                        }
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Campaña registrada exitosamente";
                    }
                    else
                    {
                        EPedidoDifusion pedido = new EPedidoDifusion();
                        pedido.tipo = "Campaña";
                        pedido.estado = LogicaBDEstado.buscarEstadoPorNombre("Pendiente de Aceptacion");
                        pedido.campaña = campaña;
                        pedido.fecha = DateTime.Now;
                        pedido.user = new EUsuario { user = Session["UsuarioLogueado"].ToString() };
                        LogicaBDPedidoDifusion.registrarPedidoDifusion(pedido);
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Campaña registrada exitosamente. \nPendiente de aceptacion";
                    }
                    SetFocus(lblCorrecto);                    
                }
                catch (Exception)
                {
                    pnlAtento.Visible = true;
                    lblError.Text = "Error al registrar la campaña";
                    SetFocus(pnlAtento);
                    throw;
                }
            }
        }
    }
}