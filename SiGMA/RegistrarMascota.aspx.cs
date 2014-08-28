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
    public partial class RegistrarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarColor(ref ddlColor);
                CargarCombos.cargarEspecies(ref ddlEspecie);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarCaracteresMascota(ref ddlCaracter);
                CargarCombos.cargarSexo(ref ddlSexo);
                CargarCombos.cargarTratos(ref ddlTratoAnimales);
                CargarCombos.cargarTratos(ref ddlTratoNinios);
            }
        }

        protected void ddlEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCombos.cargarRazas(ref ddlRaza, int.Parse(ddlEspecie.SelectedValue));
        }

        protected void cvEspecie_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEspecie);           
        }

        protected void cvRaza_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlRaza);
        }        
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EMascota mascota = new EMascota();
                mascota.nombreMascota = txtNombreMascota.Text;
                mascota.especie = new EEspecie();
                mascota.especie.idEspecie = int.Parse(ddlEspecie.SelectedValue);
                mascota.raza = new ERaza();
                mascota.raza.idRaza = int.Parse(ddlRaza.SelectedValue);
                mascota.edad = new EEdad();
                mascota.edad.idEdad = int.Parse(ddlEdad.SelectedValue);
                mascota.color = new EColor();
                mascota.color.idColor = int.Parse(ddlColor.SelectedValue);
                mascota.tratoNiños = ddlTratoNinios.SelectedValue;
                mascota.tratoAnimal = ddlTratoAnimales.SelectedValue;
                mascota.observaciones = txtObservaciones.Text;                
                mascota.alimetacionEspecial = txtAlimentacionEspecial.Text;
                if (!txtFecha.Text.Equals(""))
                {
                    mascota.fechaNacimiento = DateTime.Parse(txtFecha.Text);
                }               
                mascota.sexo = ddlSexo.SelectedValue;
                mascota.caracter = new ECaracterMascota();
                mascota.caracter.idCaracter = int.Parse(ddlCaracter.SelectedValue);
                //mascota.duenio.id      
                if (fuImagen.FileBytes != null)
                {
                    LogicaBDMascotas.registrarMascota(mascota, fuImagen.FileBytes);
                }
                else
                {
                    LogicaBDMascotas.registrarMascota(mascota, null);
                }
                Response.Redirect("~/Inicio.aspx");
            }
        }

        protected void cvDdlSexo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlSexo); 

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
       
    }
}