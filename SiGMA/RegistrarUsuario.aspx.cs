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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
             if (Page.IsValid)
             {
                 EDuenio duenio = new EDuenio();
                 EUsuario usuario = new EUsuario();
                 duenio.usuario = usuario;
                 duenio.nombre = txtNombre.Text;
                 duenio.apellido = txtApellido.Text;
                 duenio.idTipoDocumento = ddlTipoDocumento.SelectedIndex;
                 duenio.nroDocumento = txtDocumento.Text;
                 duenio.usuario.user = txtUsuario.Text;
                 duenio.email = txtEmail.Text;
                 usuario.user = txtUsuario.Text;
                 usuario.password =txtContra.Text;                 
                 LogicaBDUsuario.guardarUsuario(duenio, usuario);       
             }
        }
    }
}
   