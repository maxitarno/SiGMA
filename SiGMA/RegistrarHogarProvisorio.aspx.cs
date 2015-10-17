using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Herramientas;

namespace SiGMA
{
    public partial class RegistrarHogarProvisorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarEspecies(ref ddlEspecie);
                ddlEspecie.Items.Add("Ambas");
            }
        }

        protected void cvNiños_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlNiños);
        }
        
        protected void cvTamaño_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTamañoPerro);
        }

        protected void cvEspecie_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEspecie);
        }

        protected void btnRegistrarHogar_Click(object sender, EventArgs e)
        {

        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {

        }      
    }
}