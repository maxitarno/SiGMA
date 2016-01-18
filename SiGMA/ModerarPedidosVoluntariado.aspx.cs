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
            }
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
        }
        public void listarPedidosVoluntariado(){
            List<EVoluntario> voluntarios = LogicaBDVoluntario.BuscarPedidosVoluntariado(LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Pendiente", ambito = "Voluntario" }));
            grvPedidosVoluntariado.DataSource = voluntarios;
            grvPedidosVoluntariado.DataBind();
            if (voluntarios.Count == 0)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "No hay pedidos para moderar";
                SetFocus(lblInfo);
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
            mensaje += txtMensaje.Text + "\n \n GRACIAS \n Usuario: " + voluntario.persona.nombre;
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

    }
}