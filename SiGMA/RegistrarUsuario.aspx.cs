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
                    duenio.tipoDocumento = new ETipoDeDocumento();
                    duenio.tipoDocumento.idTipoDeDocumento = int.Parse(ddlTipoDocumento.SelectedValue);
                    duenio.nroDocumento = txtDocumento.Text;                    
                    duenio.email = txtEmail.Text;
                    usuario.user = txtUsuario.Text;
                    usuario.password = txtContra.Text;
                    usuario.estado = true;
                    if (LogicaBDUsuario.guardarUsuario(duenio, usuario))
                    {
                        mostrarResultado("", true);
                    }
                    else
                    {
                        mostrarResultado("Error al registrar el usuario", false);
                    }
                }
                catch (Exception ex)
                {
                    mostrarResultado(ex.InnerException.Message, false);
                }
            }                 
        }        

        //Metodo para mostrar un label informando alguna excepcion, el parametro sera el string de la excepcion
        private void mostrarResultado(string tipoResultado, bool b)
        {
            if (b)
            {
                txtApellido.Text = "";
                txtContra.Text = "";
                txtDocumento.Text = "";
                txtEmail.Text = "";
                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtRepetirContra.Text = "";
                ddlTipoDocumento.SelectedValue = "0";
            }
            else
            {
                if (tipoResultado.Contains("Unique_Email"))
                {
                    lblError.Text = "Ya existe un usuario con el email " + txtEmail.Text;
                }
                else if (tipoResultado.Contains("PK_Usuarios"))
                {
                    lblError.Text = "Ya existe el usuario " + txtUsuario.Text;
                }
                else
                {
                    lblError.Text = tipoResultado;
                }
            }
            pnlCorrecto.Visible = b;
            pnlAtento.Visible = !b;
           
        }

        protected void cuvDocumento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtDocumento.Text);
        }

        protected void cvLetrasNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloLetras(txtNombre.Text);
        }

        protected void cvLetrasApellido_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloLetras(txtApellido.Text);
        }

        protected void cvTipoDoc_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTipoDocumento);
        }

        protected void cvContraseña_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.contarCaracteres(txtContra.Text);
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("Usuarios.aspx");
        }
    }
}
   