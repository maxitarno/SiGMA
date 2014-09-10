using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;
using Entidades;
using AccesoADatos;
using System.IO;

namespace SiGMA
{
    public partial class RegistrarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {                    
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RegistrarMascota.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RegistrarMascota.aspx"))
                    {
                        btnRegistrar.Visible = false;                        
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
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
                mascota.duenio = new EDuenio { idDuenio = Int32.Parse(Request.Cookies["idDueño"].Value) };                
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
                mascota.alimentacionEspecial = txtAlimentacionEspecial.Text;
                if (!txtFecha.Text.Equals(""))
                {
                    mascota.fechaNacimiento = DateTime.Parse(txtFecha.Text);
                }               
                mascota.sexo = ddlSexo.SelectedValue;
                mascota.caracter = new ECaracterMascota();
                mascota.caracter.idCaracter = int.Parse(ddlCaracter.SelectedValue);
                mascota.estado = LogicaBDEstado.buscarEstadoPorNombre("Con dueño");
                if (fuImagen.PostedFile.ContentLength != 0)
                {
                    if (!GestorImagen.verificarTamaño(fuImagen.PostedFile.ContentLength))
                    {
                        mostrarResultado("El tamaño de la imagen no debe superar 1Mb", false);
                        return;
                    }
                    byte[] imagen = GestorImagen.obtenerArrayBytes(fuImagen.PostedFile.InputStream, fuImagen.PostedFile.ContentLength);
                    LogicaBDMascotas.registrarMascota(mascota, imagen);

                }
                else
                {
                    LogicaBDMascotas.registrarMascota(mascota, null);
                }
                mostrarResultado("", true);
            }
        }
        private void mostrarResultado(string mensaje, bool b)
        {
            if (!b)
            {
                lblError.Text = mensaje;
            }           
            pnlCorrecto.Visible = b;
            pnlAtento.Visible = !b;
            pnlDatos.Visible = !b;
            pnlBtnRegistrar.Visible = !b;
            fuImagen.Visible = !b;
        }
        protected void cvDdlSexo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlSexo); 
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void cvEdad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEdad); 
        }

        protected void cvColor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlColor); 
        }
       
    }
}