using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using GmailSend;
namespace SiGMA
{
    public partial class ModerarPedidosVoluntariado : System.Web.UI.Page
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
                        btnAceptar.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                listarPedidosVoluntariado();
                listarPedidosBaja();
                verificarPedidos();
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
            }
        }

        private void verificarPedidos()
        {
            if (pnlPedidos.Visible == false && pnlBaja.Visible == false)
                pnlImagenPedidosVoluntariado.Visible = true;
            else
                pnlImagenPedidosVoluntariado.Visible = false;
        }

        public void listarPedidosVoluntariado(){
            List<EVoluntario> voluntarios = LogicaBDVoluntario.BuscarPedidosVoluntariado(LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Pendiente", ambito = "Voluntario" }));
            grvPedidosVoluntariado.DataSource = voluntarios;
            grvPedidosVoluntariado.DataBind();
            if (voluntarios.Count == 0)
            {
                pnlPedidos.Visible = false;
                pnlInfo.Visible = true;
                lblInfo.Text = "No hay pedidos de voluntariado para moderar";
                SetFocus(lblInfo);
            }
            else
                pnlPedidos.Visible = true;
        }

        public void listarPedidosBaja()
        {
            List<EVoluntario> voluntarios = LogicaBDVoluntario.BuscarPedidosVoluntariado(LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Solicitud Baja", ambito = "Voluntario" }));
            grvPedidosBaja.DataSource = voluntarios;
            grvPedidosBaja.DataBind();
            if (voluntarios.Count == 0)
            {
                pnlBaja.Visible = false;
            }
            else
            {
                pnlBaja.Visible = true;
                lblInfo.Text = "";
                pnlInfo.Visible = false;
            }
        }

        protected void grvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EVoluntario voluntario = new EVoluntario();
            voluntario.persona = new EPersona();
            voluntario.idVoluntario = int.Parse(grvPedidosVoluntariado.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[2].Text);
            voluntario.persona.nombre = grvPedidosVoluntariado.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[1].Text;
            voluntario.tipoVoluntario = grvPedidosVoluntariado.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[0].Text;
            pnlResolucion.Visible = true;
            Session["PedidoVoluntariado"] = voluntario;
            txtMensaje.Visible = true;
            txtMensaje.Text = "";
        }

        protected void cvRechazo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtMensaje.Equals(""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    EVoluntario voluntario = (EVoluntario)Session["PedidoVoluntariado"];
                    if (ddlResolucion.SelectedValue.Equals("Aceptar"))
                    {
                        LogicaBDVoluntario.ActualizarEstadoVoluntario(voluntario.idVoluntario, 32);
                        lblCorrecto.Text = "Voluntario aceptado";
                        enviarMail();
                        txtMensaje.Text = "";
                        txtMensaje.Visible = false;
                    }
                    else
                    {
                        LogicaBDVoluntario.ActualizarEstadoVoluntario(voluntario.idVoluntario, 35);
                        lblCorrecto.Text = "Voluntario rechazado";
                        enviarMail();
                        txtMensaje.Text = "";
                        txtMensaje.Visible = false;
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
                    listarPedidosVoluntariado();
                    pnlDatos.Visible = false;
                    pnlResolucion.Visible = false;
                    ddlResolucion.SelectedIndex = 0;
                    txtMensaje.Text = "";
                    txtMensaje.Visible = false;
                    lblMensaje.Visible = false;
                    verificarPedidos();
                }
            }
        }

        protected void grvPedidosVoluntariado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void enviarMail()
        {
            string mensaje = "";
            EVoluntario voluntario = (EVoluntario)Session["PedidoVoluntariado"];
            EPersona persona = new EPersona();
            voluntario = LogicaBDVoluntario.buscarVoluntarioPorId(voluntario.idVoluntario);
            persona = LogicaBDUsuario.BuscarUsuariosPorNombrePersona(voluntario.persona.nombre);
            mensaje += txtMensaje.Text + "\n \n GRACIAS ";
            gmail g = new gmail();
            g.fromAlias = "SIGMA"; //  
            g.auth("infosigmasoftware@gmail.com", "Palangana321");
            g.To = persona.email; //DESTINATARIO/s
            g.Cc = "nicolasing8@gmail.com";
            g.Subject = "Voluntariado"; //Asunto del email
            //g.attach(@"D:\DATOS USUARIO\Documents\Visual Studio 2010\Projects\AldeaCampestre\AldeaCampestre\paginaBase\images\Logo-01.png");
            g.Message = "\n" + mensaje.ToString() + "\n";// Creo que deberia ser con el reporte que hagamos en Crystal Reports
            g.Priority = 1;//Le seteas la prioridad del envío
            try
            {
                g.send();//Envía el correo
            }
            catch (Exception ex)
            {
                lblError.Text = "Problemas al enviar el email. Disculpe las molestias";
                pnlAtento.Visible = true;
            }
        }

        protected void grvPedidosBaja_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                EVoluntario entVoluntario = new EVoluntario();
                entVoluntario.tipoVoluntario = grvPedidosBaja.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                entVoluntario.idVoluntario = int.Parse(grvPedidosBaja.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[4].Text);
                if (entVoluntario.tipoVoluntario.Equals("Hogar"))
                {
                    if (LogicaBDHogar.chequearHogarSinMascotas(entVoluntario))
                    {
                        LogicaBDVoluntario.darDeBajaVoluntario(entVoluntario);                        
                    }
                    else
                    {
                        lblInfo.Text = "El voluntario tiene mascotas en su hogar, debe registrar la devolucion de las mismas para poder darlo de baja";
                        SetFocus(lblInfo);
                        pnlInfo.Visible = true;
                        pnlCorrecto.Visible = false;
                        pnlAtento.Visible = false;
                        return;
                    }
                }
                else
                {
                    LogicaBDVoluntario.darDeBajaVoluntario(entVoluntario);
                }
                lblCorrecto.Text = "Baja de voluntario registrada exitosamente";
                SetFocus(lblCorrecto);
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = true;
                pnlAtento.Visible = false;
                listarPedidosBaja();
                verificarPedidos();
            }
            catch (Exception)
            {
                lblError.Text = "Error al dar de baja al voluntario";
                pnlAtento.Visible = true;
                SetFocus(pnlAtento);
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;

            }
        }        

    }
}