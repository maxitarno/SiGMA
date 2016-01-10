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
    public partial class RegistrarVeterinaria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarLocalidades(ref ddlLocalidad);
                ddlLocalidad.SelectedValue = "1";
                CargarCombos.cargarBarrio(ref ddlBarrio, 1);
                CargarCombos.cargarCalles(ref ddlCalle, 1);
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "Veterinarias"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "Veterinarias"))
                        btnRegistrar.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        public void SeleccionarLocalidad(object sender, EventArgs e)
        {
            CargarCombos.cargarBarrio(ref ddlBarrio, int.Parse(ddlLocalidad.SelectedValue.ToString()));
            CargarCombos.cargarCalles(ref ddlCalle, int.Parse(ddlLocalidad.SelectedValue.ToString()));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EVeterinaria veterinaria = new EVeterinaria();
                veterinaria.nombre = txtNombre.Text;
                veterinaria.peluqueria = chkPeluqueria.Checked;
                veterinaria.petshop = chkPetShop.Checked;
                veterinaria.medicina = chkMedicinas.Checked;
                veterinaria.castraciones = chkCastraciones.Checked;
                veterinaria.contacto = (txtContacto.Text == "") ? "" : txtContacto.Text;
                veterinaria.telefono = (txtTE.Text == "") ? "" : txtTE.Text;
                veterinaria.domicilio = new EDomicilio();
                veterinaria.domicilio.barrio = new EBarrio();
                veterinaria.domicilio.barrio.localidad = new ELocalidad();
                veterinaria.domicilio.barrio.localidad.idLocalidad = int.Parse(ddlLocalidad.SelectedValue.ToString());
                veterinaria.domicilio.barrio = new EBarrio();
                veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue.ToString());
                veterinaria.domicilio.calle = new ECalle();
                veterinaria.domicilio.calle.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
                veterinaria.domicilio.numeroCalle = int.Parse(txtNº.Text);
                if (LogicaBDVeterinaria.RegistrarVeterinaria(veterinaria))
                {
                    pnlCorrecto.Visible = true;
                    lblCorrecto.Text = "La veterinaria se registró correctamente";
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = false;
                    txtContacto.Text = "";
                    txtNº.Text = "";
                    txtNombre.Text = "";
                    txtTE.Text = "";
                    ddlBarrio.SelectedIndex = -1;
                    ddlCalle.SelectedIndex = -1;
                }
                else
                {
                    pnlCorrecto.Visible = false;
                    lblError.Text = "Error. No se pudo registrar";
                    pnlAtento.Visible = true;
                    pnlInfo.Visible = false;
                }
            }
        }

        protected void cvCalle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCalle);
        }

        protected void cvBarrio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlBarrio);
        }

        protected void cvTelefono_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtTE.Text);
        }

        protected void cvLocalidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlLocalidad);
        }
    }
}