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
    public partial class Graficos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Informes.aspx");
        }

        protected void ddlListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlListado.SelectedValue.Equals("1"))
            {
                int hogar = 0;
                int busqueda = 0;
                int ambos = 0;
                int no = 0;
                LogicaBDGraficos.BuscarUsuarios(ref hogar, ref busqueda, ref ambos, ref no);
                string pagina = "TiposDeUsuarios.htm?h=" + hogar + "&b=" + busqueda + "&a=" + ambos + "&n=" + no + "&t=" + (no + ambos + busqueda + hogar);
                Response.Redirect(pagina);
            }
            if (ddlListado.SelectedValue.Equals("2"))
            {
                int mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada").Count;
                int mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada").Count;
                int mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida").Count;
                int mascotas = LogicaBDMascota.buscarMascotasPorNombre("").Count;
                string pagina = "Grafico.htm?a=" + mascotasAdoptadas + "&p=" + mascotasPerdidas + "&h=" + mascotasHalladas + "&m=" + mascotas;
                Response.Redirect(pagina);
            }
            if (ddlListado.SelectedValue.Equals("3"))
            {
                int mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada").Count;
                int mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada").Count;
                int mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida").Count;
                int mascotas = LogicaBDMascota.buscarMascotasPorNombre("").Count;
                int cantH = 0;
                int cantM = 0;
                LogicaBDGraficos.BuscarAdopciones(ref cantM, ref cantH);
                string pagina = "AdopcionesPorSexo.htm?a=" + mascotasAdoptadas + "&p=" + mascotasPerdidas + "&h=" + mascotasHalladas + "&m=" + mascotas + "&cantH=" + cantH + "&cantM=" + cantM;
                Response.Redirect(pagina);
            }
            if (ddlListado.SelectedValue.Equals("4"))
            {
                int mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada").Count;
                int mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada").Count;
                int mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida").Count;
                int mascotas = LogicaBDMascota.buscarMascotasPorNombre("").Count;
                int cantH = 0;
                int cantM = 0;
                LogicaBDGraficos.BuscarPerdidas(ref cantH, ref cantM);
                string pagina = "PerdidasPorSexo.htm?a=" + mascotasAdoptadas + "&p=" + mascotasPerdidas + "&h=" + mascotasHalladas + "&m=" + mascotas + "&cantH=" + cantH + "&cantM=" + cantM;
                Response.Redirect(pagina);
            }
            if (ddlListado.SelectedValue.Equals("5"))
            {
                int mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada").Count;
                int mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada").Count;
                int mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida").Count;
                int mascotas = LogicaBDMascota.buscarMascotasPorNombre("").Count;
                int cantH = 0;
                int cantM = 0;
                LogicaBDGraficos.BuscarHallazgos(ref cantM, ref cantH);
                string pagina = "HallazgosPorSexo.htm?a=" + mascotasAdoptadas + "&p=" + mascotasPerdidas + "&h=" + mascotasHalladas + "&m=" + mascotas + "&cantH=" + cantH + "&cantM=" + cantM;
                Response.Redirect(pagina);
            }
        }
    }
}