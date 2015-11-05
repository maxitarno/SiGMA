using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            throw new NotImplementedException();
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefaultDueño.aspx");
        }
    }
}