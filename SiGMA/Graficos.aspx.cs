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

        protected void ddlListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlListado.SelectedValue.Equals("1"))
            {
                int hogar = 0;
                int busqueda = 0;
                int ambos = 0;
                LogicaBDGraficos.BuscarUsuarios(ref hogar, ref busqueda, ref ambos);
                string pagina = "TiposDeUsuarios.htm?h=" + hogar + "&b=" + busqueda + "&a=" + ambos;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("2"))
            {
                int mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada").Count;
                int mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada").Count;
                int mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida").Count;
                int mascotasConDueño = LogicaBDMascota.buscarMascotasPorEstado("Con dueño").Count;
                int mascotasEnAdopcion = LogicaBDMascota.buscarMascotasPorEstado("En adopcion").Count;
                int mascotasFallecida = LogicaBDMascota.buscarMascotasPorEstado("Fallecida") == null ? 0 : LogicaBDMascota.buscarMascotasPorEstado("Fallecida").Count;
                string pagina = "Grafico.htm?a=" + mascotasAdoptadas + "&p=" + mascotasPerdidas + "&h=" + mascotasHalladas + "&d=" + mascotasConDueño + "&e=" + mascotasEnAdopcion + "&f=" + mascotasFallecida;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("3"))
            {
                int cantH = 0;
                int cantM = 0;
                LogicaBDGraficos.BuscarAdopciones(ref cantM, ref cantH);
                string pagina = "AdopcionesPorSexo.htm?cantH=" + cantH + "&cantM=" + cantM;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("4"))
            {
                int mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada").Count;
                int mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada").Count;
                int mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida").Count;
                int mascotas = LogicaBDMascota.buscarMascotasPorNombre("").Count;
                int cantH = 0;
                int cantM = 0;
                LogicaBDGraficos.BuscarPerdidas(ref cantM, ref cantH);
                string pagina = "PerdidasPorSexo.htm?a=" + mascotasAdoptadas + "&p=" + mascotasPerdidas + "&h=" + mascotasHalladas + "&m=" + mascotas + "&cantH=" + cantH + "&cantM=" + cantM;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("5"))
            {
                int cantH = 0;
                int cantM = 0;
                LogicaBDGraficos.BuscarHallazgos(ref cantM, ref cantH);
                string pagina = "HallazgosPorSexo.htm?cantH=" + cantH + "&cantM=" + cantM;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
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
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("7"))
            {
                int i = 0;
                string nombre = "";
                string cantidad = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.HallazgosPorBarrio(ref datos);
                foreach(var dato in datos){
                    if(i != (datos.Count - 1)){
                        nombre += dato.nombre + ",";
                        cantidad += dato.cantidad + ",";
                    }
                    else{
                        nombre += dato.nombre;
                        cantidad += dato.cantidad;
                    }
                    i++;
                }
                string pagina = "HallazgosPorBarrio.htm?nombre=" + nombre + "&cant=" + cantidad;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("8"))
            {
                int i = 0;
                string nombre = "";
                string cantidad = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.AdopcionesPorBarrio(ref datos);
                foreach (var dato in datos)
                {
                    if (i != (datos.Count - 1))
                    {
                        nombre += dato.nombre + ",";
                        cantidad += dato.cantidad + ",";
                    }
                    else
                    {
                        nombre += dato.nombre;
                        cantidad += dato.cantidad;
                    }
                    i++;
                }
                string pagina = "ADopcionesPorBarrio.htm?nombre=" + nombre + "&cant=" + cantidad;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("9"))
            {
                int i = 0;
                string nombre = "";
                string cantidad = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.PerdidasPorBarrio(ref datos);
                foreach (var dato in datos)
                {
                    if (i != (datos.Count - 1))
                    {
                        nombre += dato.nombre + ",";
                        cantidad += dato.cantidad + ",";
                    }
                    else
                    {
                        nombre += dato.nombre;
                        cantidad += dato.cantidad;
                    }
                    i++;
                }
                string pagina = "PerdidasPorBarrio.htm?nombre=" + nombre + "&cant=" + cantidad;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("11"))
            {
                int i = 0;
                string cant = "";
                string fecha = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.AdopcionesPorFecha(ref datos);
                foreach (var dato in datos)
                {
                    if (i != (datos.Count))
                    {
                        cant += dato.cantidad + ",";
                        fecha += dato.año + ",";
                    }
                    else
                    {
                        cant += dato.cantidad;
                        fecha += dato.año;
                    }
                }
                string pagina = "AdopcionesPorFecha.htm?nombre=" + fecha + "&cant=" + cant;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("10"))
            {
                int i = 0;
                string cant = "";
                string fecha = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.HallazgosPorFecha(ref datos);
                foreach (var dato in datos)
                {
                    if (i != (datos.Count))
                    {
                        cant += dato.cantidad + ",";
                        fecha += dato.año + ",";
                    }
                    else
                    {
                        cant += dato.cantidad;
                        fecha += dato.año;
                    }
                }
                string pagina = "HallazgosPorFecha.htm?nombre=" + fecha + "&cant=" + cant;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("12"))
            {
                int i = 0;
                string cant = "";
                string fecha = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.PerdidasPorFecha(ref datos);
                foreach (var dato in datos)
                {
                    if (i != datos.Count)
                    {
                        cant += dato.cantidad + ",";
                        fecha += dato.año + ",";
                    }
                    else
                    {
                        cant += dato.cantidad;
                        fecha += dato.año;
                    }
                }
                string pagina = "PerdidasPorFecha.htm?nombre=" + fecha + "&cant=" + cant;
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("13"))
            {
                int cantidadPerros = 0;
                int cantidadGatos = 0;
                LogicaBDGraficos.BuscarMascotasPorEspecie(ref cantidadPerros, ref cantidadGatos);
                string pagina = "MascotasPorEspecie.htm?cantPerros=" + cantidadPerros + "&cantGatos=" + cantidadGatos;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("14"))
            {
                int cantidadPerros = 0;
                int cantidadGatos = 0;
                LogicaBDGraficos.PerdidasPorEspecie(ref cantidadGatos, ref cantidadPerros);
                string pagina = "PerdidasPorEspecie.htm?cantPerros=" + cantidadPerros + "&cantGatos=" + cantidadGatos;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("15"))
            {
                int cantidadPerros = 0;
                int cantidadGatos = 0;
                LogicaBDGraficos.AdopcionesPorEspecie(ref cantidadGatos, ref cantidadPerros);
                string pagina = "AdopcionesPorEspecie.htm?cantPerros=" + cantidadPerros + "&cantGatos=" + cantidadGatos;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("16"))
            {
                int cantidadPerros = 0;
                int cantidadGatos = 0;
                LogicaBDGraficos.HallazgosPorEspecie(ref cantidadGatos, ref cantidadPerros);
                string pagina = "HallazgosPorEspecies.htm?cantPerros=" + cantidadPerros + "&cantGatos=" + cantidadGatos;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("17"))
            {
                int i = 0;
                string nombre = "";
                string cantidad = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.AdopcionesPorRaza(ref datos);
                foreach (var dato in datos)
                {
                    if (i != (datos.Count - 1))
                    {
                        nombre += dato.nombre + ",";
                        cantidad += dato.cantidad + ",";
                    }
                    else
                    {
                        nombre += dato.nombre;
                        cantidad += dato.cantidad;
                    }
                    i++;
                }
                string pagina = "AdopcionesPorRaza.htm?nombre=" + nombre + "&cant=" + cantidad;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("18"))
            {
                int i = 0;
                string nombre = "";
                string cantidad = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.HallazgosPorRaza(ref datos);
                foreach (var dato in datos)
                {
                    if (i != (datos.Count - 1))
                    {
                        nombre += dato.nombre + ",";
                        cantidad += dato.cantidad + ",";
                    }
                    else
                    {
                        nombre += dato.nombre;
                        cantidad += dato.cantidad;
                    }
                    i++;
                }
                string pagina = "HallazgosPorRaza.htm?nombre=" + nombre + "&cant=" + cantidad;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
            if (ddlListado.SelectedValue.Equals("19"))
            {
                int i = 0;
                string nombre = "";
                string cantidad = "";
                List<EDatos> datos = new List<EDatos>();
                LogicaBDGraficos.PerdidasPorRaza(ref datos);
                foreach (var dato in datos)
                {
                    if (i != (datos.Count - 1))
                    {
                        nombre += dato.nombre + ",";
                        cantidad += dato.cantidad + ",";
                    }
                    else
                    {
                        nombre += dato.nombre;
                        cantidad += dato.cantidad;
                    }
                    i++;
                }
                string pagina = "PerdidasPorRaza.htm?nombre=" + nombre + "&cant=" + cantidad;
                //Response.Redirect(pagina);
                Response.Write("<script>");
                Response.Write("window.open('" + pagina + "','_blank')");
                Response.Write("</script>");
            }
        }
    }
}