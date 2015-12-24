using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Data;
namespace SiGMA
{
    public partial class Contrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            EMascota mascota = (EMascota)Session["Mascota"];
            EPersona persona = (EPersona)Session["Dueño"];
            lblDocumento.Text = persona.tipoDocumento.nombre + " " + persona.nroDocumento;
            lblApellidoYNombre.Text = persona.apellido + " " + persona.nombre;
            lblBarrio.Text = persona.barrio.nombre;
            lblCalleYNumero.Text = persona.domicilio.nombre + " " + ((persona.nroCalle == null) ? 0 : persona.nroCalle);
            lblLocalidad.Text = ((persona.localidad == null) ? "" : persona.localidad.nombre);
            lblTelefonoFijo.Text = ((persona.telefonoFijo == null) ? "" : persona.telefonoFijo);
            lblEmail.Text = ((persona.email == null) ? "" : persona.email);
            lblId.Text = mascota.idMascota.ToString();
            lblNombre.Text = mascota.nombreMascota;
            lblEspecie.Text = mascota.especie.nombreEspecie;
            lblRaza.Text = mascota.raza.nombreRaza;
            lblEdad.Text = mascota.edad.nombreEdad;
            lblSexo.Text = mascota.sexo;
            lblNumeroDeVoluntario.Text = Session["IdVoluntario"].ToString();
            lblNumeroDeAdopción.Text = Session["na"].ToString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblFechaRevición.Text = (DateTime.Now.AddDays(7).ToShortDateString().ToString());
        }
        public void BtnAceptarClick(object sender, EventArgs e)
        {
            Session["Si"] = "Si";
            if (Session["Modificar"].Equals("No"))
            {
                Response.Redirect("RegistrarAdopcion.aspx");
            }
            else
            {
                Response.Redirect("ConsultarAdopcion.aspx?m=1");
            }
        }
        public void BtnRechazarClick(object sender, EventArgs e)
        {
            Session["Si"] = "No";
            if (Session["Modificar"].Equals("No"))
            {
                Response.Redirect("RegistrarAdopcion.aspx");
            }
            else
            {
                Response.Redirect("ConsultarAdopcion.aspx?m=1");
            }
        }
    }
}