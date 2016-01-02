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
                LogicaBDGraficos.BuscarUsuarios(ref hogar, ref busqueda, ref ambos);
                string pagina = "TiposDeUsuarios.htm?h=" + hogar + "&b=" + busqueda + "&a=" + ambos;
                Response.Redirect(pagina);
            }
            if (ddlListado.SelectedValue.Equals("2"))
            {
                int mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada").Count;
                int mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada").Count;
                int mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida").Count;
                string pagina = "Grafico.htm?a=" + mascotasAdoptadas + "&p=" + mascotasPerdidas + "&h=" + mascotasHalladas;
                Response.Redirect(pagina);
            }
            if (ddlListado.SelectedValue.Equals("3"))
            {
                int cantH = 0;
                int cantM = 0;
                LogicaBDGraficos.BuscarAdopciones(ref cantM, ref cantH);
                string pagina = "AdopcionesPorSexo.htm?cantH=" + cantH + "&cantM=" + cantM;
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
                int cantH = 0;
                int cantM = 0;
                LogicaBDGraficos.BuscarHallazgos(ref cantM, ref cantH);
                string pagina = "HallazgosPorSexo.htm?cantH=" + cantH + "&cantM=" + cantM;
                Response.Redirect(pagina);
            }
            if (ddlListado.SelectedValue.Equals("6"))
            {
                int cantH = 0;
                int cantM = 0;
                int cachorro = 0;
                int adulto = 0;
                int senior = 0;
                LogicaBDGraficos.BuscarMascotas(ref cachorro, ref adulto, ref senior, ref cantH, ref cantM);
                string pagina = "MascotasPorEdadYSexo.htm?s=" + senior + "&a=" + adulto + "&c=" + cachorro + "&M=" + cantM + "&H=" + cantH;
                Response.Redirect(pagina);
            }
            if (ddlListado.SelectedValue.Equals("7"))
            {
                int i = 0;
                string nombre = "";
                string cantidad = "";
                string año = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.HallazgosPorBarrio(ref datos);
                foreach(var dato in datos){
                    if(i != (datos.Count - 1)){
                        nombre += dato.nombre + ",";
                        cantidad += dato.cantidad + ",";
                        año += dato.año + ",";
                    }
                    else{
                        nombre += dato.nombre;
                        cantidad += dato.cantidad;
                        año += dato.año;
                    }
                    i++;
                }
                string pagina = "HallazgosPorBarrio.htm?nombre=" + nombre + "&cant=" + cantidad + "&anio=" + año;
                Response.Redirect(pagina);
            }
        }
    }
}