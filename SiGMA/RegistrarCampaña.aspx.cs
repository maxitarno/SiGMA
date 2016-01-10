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
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "Campañas"))
                    {
                        if (Session["EsRol"].ToString() == "1" || Session["EsRol"].ToString() == "4" || Session["EsRol"].ToString() == "5")
                            Response.Redirect("PermisosInsuficientes.aspx");
                        if (Session["EsRol"].ToString() == "2")
                            Response.Redirect("PermisoInsuficiente.aspx");
                    }
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "Campañas"))
                        btnRegistrarCampaña.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarTipoCampaña(ref ddlTipoCampaña);
                rnvFechaCampaña.MinimumValue = DateTime.Now.ToShortDateString();
                rnvFechaCampaña.MaximumValue = DateTime.Now.AddMonths(6).ToShortDateString();
            }
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["EsRol"] != null)
            {
                if (Session["EsRol"].ToString() == "1")
                {
                    Response.Redirect("_Difusion.aspx");
                }
                else
                {
                    Response.Redirect("DifusionDueño.aspx");
                }
            }            
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
                var fecha = DateTime.Today;
                if (DateTime.TryParse(txtFecha.Text, out fecha))
                    campaña.fecha = Convert.ToDateTime(txtFecha.Text);
                else
                {
                    lblInfo.Text = "Ingrese una fecha válida";
                    pnlInfo.Visible = true;
                }
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
                        var imagen = campaña.imagen;
                        if (imagen != null)
                        {
                            tweet.PublicarTweetConFoto(imagen, tweet.generarMensajeCampaña(campaña));
                        }
                        else
                        {
                            tweet.PublicarTweetSoloTexto(tweet.generarMensajeCampaña(campaña));
                        }
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
                        lblCorrecto.Text = "Campaña registrada exitosamente. \nPendiente de aceptacion";
                    }
                    pnlCorrecto.Visible = true;
                    pnlAtento.Visible = false;
                    SetFocus(lblCorrecto);                    
                }
                catch (Exception)
                {
                    pnlAtento.Visible = true;
                    pnlCorrecto.Visible = false;
                    lblError.Text = "Error al registrar la campaña";
                    SetFocus(pnlAtento);                    
                }
            }
        }
    }
}