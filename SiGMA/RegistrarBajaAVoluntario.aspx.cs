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
    public partial class DarBajaAVoluntario : System.Web.UI.Page
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
                        Response.Redirect("PermisosInsuficientes.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                listarVoluntarios();
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }

        public void listarVoluntarios()
        {
            List<EVoluntario> voluntarios = LogicaBDVoluntario.BuscarPedidosVoluntariado(LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Activo", ambito = "Voluntario" }));
            grvVoluntarios.DataSource = voluntarios;
            grvVoluntarios.DataBind();
            if (voluntarios.Count == 0)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "No hay voluntarios";
                SetFocus(lblInfo);
            }
            else
            {
                pnlInfo.Visible = false;
            }
        }

        private void enviarMail(EVoluntario voluntario)
        {
            string mensaje = "";
            EPersona persona = new EPersona();
            voluntario = LogicaBDVoluntario.buscarVoluntarioPorId(voluntario.idVoluntario);
            persona = LogicaBDUsuario.BuscarUsuariosPorNombrePersona(voluntario.persona.nombre);
            mensaje += voluntario.persona.nombre + ", usted ha sido dado de baja por no cumplir con los requerimientos minimos para continuar como voluntario\n \n Disculpe las molestias \n SIGMA ";
            gmail g = new gmail();
            g.fromAlias = "SIGMA"; //  
            g.auth("infosigmasoftware@gmail.com", "Palangana321");
            g.To = persona.email; //DESTINATARIO/s
            g.Cc = "maxitarno@gmail.com";
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

        protected void grvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EVoluntario voluntario = new EVoluntario();
            voluntario.persona = new EPersona();
            voluntario.idVoluntario = int.Parse(grvVoluntarios.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[2].Text);
            voluntario.persona.nombre = grvVoluntarios.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[1].Text;
            voluntario.tipoVoluntario = grvVoluntarios.Rows[Int32.Parse(e.CommandArgument.ToString())].Cells[0].Text;
            enviarMail(voluntario);
            LogicaBDVoluntario.ActualizarEstadoVoluntario(voluntario.idVoluntario, 33); //Inactivo
            pnlCorrecto.Visible = true;
            lblCorrecto.Text = "Se registro la baja correctamente";
            listarVoluntarios();
        }      
    }
}