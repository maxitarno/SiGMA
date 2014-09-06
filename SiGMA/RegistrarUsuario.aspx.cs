using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades; 
using AccesoADatos;
using Herramientas; 

namespace SiGMA
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    //if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RegistrarUsuario.aspx"))
                    //    Response.Redirect("PermisosInsuficientes.aspx");
                    //if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "ConsultarUsuario.aspx"))
                    //    btnRegistrar.Visible = false;
                }
                CargarCombos.cargarTipoDocumento(ref ddlTipoDocumento);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EDuenio duenio = new EDuenio();
                EUsuario usuario = new EUsuario();
                try
                {                    
                    duenio.usuario = usuario;
                    duenio.nombre = txtNombre.Text;
                    duenio.apellido = txtApellido.Text;
                    duenio.idTipoDocumento = int.Parse(ddlTipoDocumento.SelectedValue);
                    duenio.nroDocumento = txtDocumento.Text;
                    duenio.usuario.user = txtUsuario.Text;
                    duenio.email = txtEmail.Text;
                    usuario.user = txtUsuario.Text;
                    usuario.password = txtContra.Text;
                    if (LogicaBDUsuario.guardarUsuario(duenio, usuario))
                    {
                        Response.Write("<SCRIPT>alert('Usuario Registrado Exitosamente');</SCRIPT>");
                        limpiarPagina();
                    }
                    else
                    {
                        Response.Write("<SCRIPT>alert('Error al registrar usuario');</SCRIPT>");
                    }
                }
                catch (Exception ex)
                {
                    mostrarResultado(ex.InnerException.Message);
                }
            }                 
        }

        private void limpiarPagina() 
        {
            txtApellido.Text = "";
            txtContra.Text = "";
            txtDocumento.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtRepetirContra.Text = "";
            ddlTipoDocumento.SelectedValue = "0";
        }

        //Metodo para mostrar un label informando alguna excepcion, el parametro sera el string de la excepcion
        private void mostrarResultado(string tipoResultado)
        {
            if(tipoResultado.Contains("Unique_Email"))
            {
                lblResultado.Text = "Ya existe un usuario con el email " + txtEmail.Text;                
            }
            else if (tipoResultado.Contains("PK_Usuarios"))
            {
                lblResultado.Text = "Ya existe el usuario " + txtUsuario.Text;   
            }
            lblResultado.Visible = true;
            lblResultado.ForeColor = System.Drawing.Color.Red;
        }

        protected void cuvDocumento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtDocumento.Text);
        }
    }
}
   