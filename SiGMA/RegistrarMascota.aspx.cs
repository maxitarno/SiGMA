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
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                rnvFecha.MaximumValue = DateTime.Now.ToShortDateString();
                CargarCombos.cargarColor(ref ddlColor);
                CargarCombos.cargarEspecies(ref ddlEspecie);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarCaracteresMascota(ref ddlCaracter);
                CargarCombos.cargarSexo(ref ddlSexo);
                CargarCombos.cargarTratos(ref ddlTratoAnimales);
                CargarCombos.cargarTratos(ref ddlTratoNinios);
                if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RegistrarMascota.aspx"))
                {
                    if (Session["EsRol"].ToString() == "1" || Session["EsRol"].ToString() == "4" || Session["EsRol"].ToString() == "5")
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (Session["EsRol"].ToString() == "2")
                        Response.Redirect("PermisoInsuficiente.aspx");
                }
                if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RegistrarMascota.aspx"))
                    btnRegistrar.Visible = false;
            }
			else
			{
				pnlCorrecto.Visible = false;
				pnlAtento.Visible = false;
                pnlInfo.Visible = false;
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
                if (Validaciones.verificarSeleccionEnDdl(ref ddlTratoNinios))
                {
                    mascota.tratoNiños = Convert.ToBoolean(ddlTratoNinios.SelectedValue);
                }
                if (Validaciones.verificarSeleccionEnDdl(ref ddlTratoAnimales))
                {
                    mascota.tratoAnimal = Convert.ToBoolean(ddlTratoAnimales.SelectedValue);
                }
                mascota.observaciones = txtObservaciones.Text;                
                mascota.alimentacionEspecial = txtAlimentacionEspecial.Text;
                if (txtFecha.Text != "")
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
                    mascota.imagen = imagen;
                    LogicaBDMascota.registrarMascota(mascota);
                }
                else
                {
                    LogicaBDMascota.registrarMascota(mascota);
                }
                mostrarResultado("", true);
            }
        }
        private void mostrarResultado(string mensaje, bool b)
        {                      
            pnlCorrecto.Visible = b;
            pnlAtento.Visible = !b;
            pnlDatos.Visible = !b;
            pnlDatos1.Visible = !b;
            pnlBtnRegistrar.Visible = !b;
            fuImagen.Visible = !b;
            pnlFoto.Visible = !b;
            if (!b)
            {
                lblError.Text = mensaje;
            }
            else
            {
                Response.AddHeader("REFRESH", "4;URL=RegistrarMascota.aspx");
            }
        }
        protected void cvDdlSexo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlSexo); 
        }

        protected void cvEdad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEdad); 
        }

        protected void cvColor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlColor); 
        }

        protected void cvCaracter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCaracter); 
        }

        protected void cvTratoAnim_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTratoAnimales); 
        }

        protected void dvTratoNinios_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTratoNinios); 
        }
    }
}