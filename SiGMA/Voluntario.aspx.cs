using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;

namespace SiGMA
{
    public partial class Voluntario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoVoluntario"].ToString() != "0")
            {
                if (Session["TipoVoluntario"].ToString() == "1")
                {
                    pnlHogar.Visible = true;
                    cargarDatosHogar(); //cargar los datos del hogar del usuario logueado
                    cargarComboMisProvisorias(); //cargar el combo con las mascotas provisorias que tiene
                }
                else if (Session["TipoVoluntario"].ToString() == "2")
                {
                    pnlBusqueda.Visible = true;
                    cargarDatosBusqueda(); //cargar los datos de la dispoibilidad del usuario logueado
                    cargarComboPerdidasBarrio(); //cargar el combo con las mascotas perdidas en el barrio del usuario logueado
                }
                else if (Session["TipoVoluntario"].ToString() == "3")
                {
                    pnlHogar.Visible = true;
                    pnlBusqueda.Visible = true;
                    cargarDatosHogar(); //cargar los datos del hogar del usuario logueado
                    cargarComboMisProvisorias(); //cargar el combo con las mascotas provisorias que tiene
                    cargarDatosBusqueda(); //cargar los datos de la dispoibilidad del usuario logueado
                    cargarComboPerdidasBarrio(); //cargar el combo con las mascotas perdidas en el barrio del usuario logueado
                }
            }
            else 
            {
                Response.Redirect("SerVoluntario.aspx");
            }
        }

        private void cargarComboPerdidasBarrio()
        {
            throw new NotImplementedException();
        }

        private void cargarDatosBusqueda()
        {
            throw new NotImplementedException();
        }

        private void cargarComboMisProvisorias()
        {
            throw new NotImplementedException();
        }

        private void cargarDatosHogar()
        {
           EPersona persona = new EPersona();
           EHogarProvisorio hogar = new EHogarProvisorio();
           ECalle calle = new ECalle();
           EBarrio barrio = new EBarrio();
           LogicaBDVoluntario.cargarDatosHogarProvisorio(Session["UsuarioLogueado"].ToString(), persona, hogar, calle, barrio);
           txtNombre.Text = persona.nombre;
           txtEmail.Text = persona.email;
           txtTelefono.Text = persona.telefonoCelular + '-' + persona.telefonoFijo;
           ddlTipoHogar.SelectedValue = hogar.tipoHogar.ToString();
           ddlCalle.SelectedValue = calle.idCalle.ToString();
           txtNro.Text = persona.nroCalle.ToString();
           ddlBarrio.SelectedValue = barrio.idBarrio.ToString();
           ddlNumeroMascotas.SelectedValue = hogar.cantMascotas.ToString();
           ddlTipoMascota.SelectedValue = hogar.AceptaEspecie.ToString();
           ddlTieneNinios.SelectedValue = hogar.tieneNiños.ToString();
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefaultDueño.aspx");
        }
    }
}