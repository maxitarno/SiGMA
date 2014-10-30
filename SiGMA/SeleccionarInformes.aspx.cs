using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using Herramientas;
namespace SiGMA
{
    public partial class SeleccionarInformes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarComboRazas(ref ddlRaza);
                CargarCombos.cargarBarrio(ref ddlBarrioHallazgo);
                CargarCombos.cargarBarrio(ref ddlBarrioPerdida);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarEspecies(ref ddlEspecies);
                CargarCombos.cargarEstado(ref ddlEstado, "Mascota");
                CargarCombos.cargarEstado(ref ddlEstadoDelHallazgo, "Hallazgo");
                CargarCombos.cargarEstado(ref ddlEstadoPerdida, "Perdida");
                CargarCombos.cargarEstado(ref ddlEstadoDeAdopcion, "Adopcion");
                //rnvMascota.MaximumValue = DateTime.Now.ToShortDateString();
                //rnvHallazgo.MaximumValue = DateTime.Now.ToShortDateString();
                //rnvAdopcion.MaximumValue = DateTime.Now.ToShortDateString();
                //rnvPerdida.MaximumValue = DateTime.Now.ToShortDateString();
                pnlGenerar.Visible = false;
                pnlInfo.Visible = false;
            }
        }
        public void BtnRegresarClick(object sender, EventArgs e)
        {
            Response.Redirect("Administracion.aspx");
        }
        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaAdopcion.Text = calendar1.SelectedDate.ToString("d");
            calendar1.Visible = false;
            pnlInfo.Visible = false;
        }

        protected void imgFechaPerdida_Click(object sender, ImageClickEventArgs e)
        {
            //calendario.Visible = true;
            calendar1.Visible = true;
            calendar2.Visible = true;
            calendar3.Visible = true;
            pnlInfo.Visible = false;
        }
        protected void calendario_SelectionChangedPerdida(object sender, EventArgs e)
        {
            txtFechaDeLaPerdida.Text = calendar3.SelectedDate.ToString("d");
            calendar3.Visible = false;
            pnlInfo.Visible = false;
        }
        protected void calendario_SelectionChangedHallazgo(object sender, EventArgs e)
        {
            txtFechaDelHallazgo.Text = calendar2.SelectedDate.ToString("d");
            calendar2.Visible = false;
            pnlInfo.Visible = false;
        }
        //protected void calendario_SelectionChangedMascota(object sender, EventArgs e)
        //{
        //    txtFechaMascota.Text = calendario.SelectedDate.ToString("d");
        //    calendario.Visible = false;
        //    pnlInfo.Visible = false;
        //}
        protected void ddlSelectedChanged(object sender, EventArgs e)
        {
            if (ddlInforme.SelectedValue.Equals("0"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = false;
                pnlInfo.Visible = false;
            }
            if (ddlInforme.SelectedValue.Equals("1"))
            {
                pnlFiltros1.Visible = true;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = false;
                Session["listas"] = "1";
                pnlGenerar.Visible = true;
                pnlInfo.Visible = false;
            }
            if (ddlInforme.SelectedValue.Equals("2"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = false;
                Session["listas"] = "2";
                Response.Redirect("listas.aspx");
            }
            if (ddlInforme.SelectedValue.Equals("3"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = true;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = false;
                pnlInfo.Visible = false;
            }
            if (ddlInforme.SelectedValue.Equals("4"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = true;
                pnlFiltros4.Visible = false;
            }
            if (ddlInforme.SelectedValue.Equals("5"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = true;
                pnlInfo.Visible = false;
            }
        }
        public void BtnGenerarClick(object sender, EventArgs e)
        {
            if (ddlInforme.SelectedValue.ToString().Equals("1"))
            {
                EMascota mascota = new EMascota();
                if (!ddlEdad.SelectedValue.Equals("0"))
                {
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = int.Parse(ddlEdad.SelectedValue);
                } if (!ddlEspecies.SelectedValue.Equals("0"))
                {
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = int.Parse(ddlEspecies.SelectedValue);
                }
                if (!ddlEstado.SelectedValue.Equals("0"))
                {
                    mascota.estado = new EEstado();
                    mascota.estado.idEstado = int.Parse(ddlEstado.SelectedValue);
                }
                if (!ddlRaza.SelectedValue.Equals("0"))
                {
                    mascota.raza = new ERaza();
                    mascota.raza.idRaza = int.Parse(ddlRaza.SelectedValue);
                }
                mascota.nombreMascota = "";
                Session["mascotas"] = mascota;
                Response.Redirect("listas.aspx");
            }
        }
    }
}