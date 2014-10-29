using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using System.Data;
namespace SiGMA
{
    public partial class listas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listas"].ToString().Equals("2"))
            {
                //List<EMascota> mascotasEnAdopcion = LogicaBDMascota.buscarMascotasPorEstado("En adopcion");
                List<EMascota> mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada");
                List<EMascota> mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada");
                List<EMascota> mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida");
                List<EMascota> mascotas = LogicaBDMascota.buscarMascotasPorNombre("");
                DataSet ds = new DatosReportes();
                DataTable dt = ds.Tables["Metricas"];
                DataRow row = dt.NewRow();
                Metricas metricas = new Metricas();
                row["cantidad de perdidas promedio"] = float.Parse(mascotasPerdidas.Count.ToString()) / float.Parse(mascotas.Count.ToString());
                row["cantidad de hallazgos promedio"] = float.Parse(mascotasHalladas.Count.ToString()) / float.Parse(mascotas.Count.ToString());
                row["cantidad de adopciones promedio"] = float.Parse(mascotasAdoptadas.Count.ToString()) / float.Parse(mascotas.Count.ToString());
                row["porcentaje de adopcion"] =  (float.Parse(mascotasAdoptadas.Count.ToS  tring()) / float.Parse(mascotas.Count.ToString())) * 100.00;
                row["porcentaje de 
                dt.Rows.Add(row);
                metricas.SetDataSource(ds);
                crtListas.ReportSource = metricas;
                crtListas.RefreshReport();
            }
            if (Session["listas"].ToString().Equals("3"))
            {
            }
            if (Session["listas"].ToString().Equals("4"))
            {
            }
            if (Session["listas"].ToString().Equals("5"))
            {
            }
        }
        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SeleccionarInformes.aspx");
        }
    }
}