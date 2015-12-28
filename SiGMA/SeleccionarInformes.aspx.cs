using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using Herramientas;
using Pechkin;
using System.IO;
using System.Text;
namespace SiGMA
{
    public partial class SeleccionarInformes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "Administracion"))
                    Response.Redirect("PermisosInsuficientes.aspx");
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
                rnvPerdida.MaximumValue = DateTime.Now.ToShortDateString();
                rnvAdopcion.MaximumValue = DateTime.Now.ToShortDateString();
                rnvHallazgo.MaximumValue = DateTime.Now.ToShortDateString();
            }
        }
        public void BtnRegresarClick(object sender, EventArgs e)
        {
            Response.Redirect("Informes.aspx");
        }

        protected void ddlSelectedChanged(object sender, EventArgs e)
        {
            pnlAdopciones.Visible = false;
            pnlHallazgos.Visible = false;
            pnlListadoDeMascotas.Visible = false;
            pnlPerdidas.Visible = false;
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
                pnlGenerar.Visible = true;
                pnlInfo.Visible = false;
            }
            if (ddlInforme.SelectedValue.Equals("2"))//borrar
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = false;
                pnlGenerar.Visible = true;
                int mascotasAdoptadas = LogicaBDMascota.buscarMascotasPorEstado("Adoptada").Count;
                int mascotasHalladas = LogicaBDMascota.buscarMascotasPorEstado("Hallada").Count;
                int mascotasPerdidas = LogicaBDMascota.buscarMascotasPorEstado("Perdida").Count;
                int mascotas = LogicaBDMascota.buscarMascotasPorNombre("").Count;
                string pagina = "Grafico.htm?a=" + mascotasAdoptadas + "&p=" + mascotasPerdidas + "&h=" + mascotasHalladas + "&m=" + mascotas;
                Response.Redirect(pagina);

            }//borrar
            if (ddlInforme.SelectedValue.Equals("3"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = true;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = false;
                pnlInfo.Visible = false;
                pnlGenerar.Visible = true;
            }
            if (ddlInforme.SelectedValue.Equals("4"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = true;
                pnlFiltros4.Visible = false;
                pnlGenerar.Visible = true;
            }
            if (ddlInforme.SelectedValue.Equals("5"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = true;
                pnlInfo.Visible = false;
                pnlGenerar.Visible = true;
            }
            pnlImprimir.Visible = false;
        }
        public void BtnGenerarClick(object sender, EventArgs e)
        {
            DateTime fecha;
            if (ddlInforme.SelectedValue.ToString().Equals("1"))
            {
                EMascota mascota = new EMascota();
                pnlListadoDeMascotas.Visible = true;
                pnlAdopciones.Visible = false;
                pnlHallazgos.Visible = false;
                pnlPerdidas.Visible = false;
                if (!ddlEdad.SelectedValue.Equals("0"))
                {
                    mascota.edad = new EEdad();
                    mascota.edad.nombreEdad = ddlEdad.SelectedItem.Text;
                    mascota.edad.idEdad = int.Parse(ddlEdad.SelectedValue.ToString());
                }
                if (!ddlEspecies.SelectedValue.Equals("0"))
                {
                    mascota.especie = new EEspecie();
                    mascota.especie.nombreEspecie = ddlEspecies.SelectedItem.Text;
                    mascota.especie.idEspecie = int.Parse(ddlEspecies.SelectedValue.ToString());
                }
                if (!ddlEstado.SelectedValue.Equals("0"))
                {
                    mascota.estado = new EEstado();
                    mascota.estado.nombreEstado = ddlEstado.SelectedItem.Text;
                    mascota.estado.idEstado = int.Parse(ddlEstado.SelectedValue.ToString());
                }
                if (!ddlRaza.SelectedValue.Equals("0"))
                {
                    mascota.raza = new ERaza();
                    mascota.raza.nombreRaza = ddlRaza.SelectedItem.Text;
                    mascota.raza.idRaza = int.Parse(ddlRaza.SelectedValue.ToString());
                }
                mascota.nombreMascota = "";
                List<EMascota> mascotas1 = LogicaBDMascota.buscarMascotasFiltros(mascota);
                grvListas.DataSource = mascotas1;
                grvListas.DataBind();
                lblTitulo.Text = "LISTADO DE MASCOTAS";
            }
            if(ddlInforme.SelectedValue.Equals("3")){
                EAdopcion adopcion = new EAdopcion();
                pnlListadoDeMascotas.Visible = false;
                pnlAdopciones.Visible = true;
                pnlHallazgos.Visible = false;
                pnlPerdidas.Visible = false;
                fecha = new DateTime();
                if (!ddlEstadoDeAdopcion.SelectedValue.Equals("0"))
                {
                    adopcion.estado = new EEstado();
                    adopcion.estado.nombreEstado = ddlEstadoDeAdopcion.SelectedValue.ToString();
                }
                if (DateTime.TryParse(txtFechaAdopcion.Text, out fecha))
                {
                    fecha = DateTime.Parse(txtFechaAdopcion.Text);
                }
                List<EAdopcion> adopciones = LogicaBDAdopcion.BuscarAdopcionesPorFiltros(adopcion);
                lblTitulo.Text = "LISTADO DE ADOPCIONES";
                grvAdopciones.DataSource = adopciones;
                grvAdopciones.DataBind();
            }
            if (ddlInforme.SelectedValue.Equals("4"))
            {
                EHallazgo hallazgo = new EHallazgo();
                fecha = new DateTime();
                hallazgo.domicilio = new EDomicilio();
                pnlListadoDeMascotas.Visible = false;
                pnlAdopciones.Visible = false;
                pnlHallazgos.Visible = true;
                pnlPerdidas.Visible = false;
                if (DateTime.TryParse(txtFechaDelHallazgo.Text, out fecha))
                {
                    hallazgo.fechaHallazgo = DateTime.Parse(txtFechaDelHallazgo.Text);
                }
                if (!ddlEstado.SelectedValue.Equals("0"))
                {
                    hallazgo.estado = new EEstado();
                    hallazgo.estado.nombreEstado = ddlEstadoDelHallazgo.SelectedItem.Text;
                    hallazgo.estado.idEstado = int.Parse(ddlBarrioHallazgo.SelectedValue.ToString());
                }
                if (!ddlBarrioHallazgo.SelectedValue.Equals("0"))
                {
                    hallazgo.domicilio = new EDomicilio();
                    hallazgo.domicilio.barrio = new EBarrio();
                    hallazgo.domicilio.barrio.nombre = ddlBarrioHallazgo.SelectedItem.Text;
                    hallazgo.domicilio.barrio.idBarrio = int.Parse(ddlBarrioHallazgo.SelectedValue.ToString());
                }
                List<EHallazgo> hallazgos = LogicaBDHallazgo.BuscarHallazgosPorOpciones(hallazgo);
                lblTitulo.Text = "LISTA DE HALLAZGOS";
                grvHallazgos.DataSource = hallazgos;
                grvHallazgos.DataBind();
            }
            if (ddlInforme.SelectedValue.Equals("5"))
            {
                EPerdida perdida = new EPerdida();
                fecha = new DateTime();
                pnlListadoDeMascotas.Visible = false;
                pnlAdopciones.Visible = false;
                pnlHallazgos.Visible = false;
                pnlPerdidas.Visible = true;
                if (DateTime.TryParse(txtFechaDeLaPerdida.Text, out fecha))
                {
                    perdida.fecha = DateTime.Parse(txtFechaDeLaPerdida.Text);
                }
                if (!ddlEstadoPerdida.SelectedValue.Equals("0"))
                {
                    perdida.estado = new EEstado();
                    perdida.estado.nombreEstado = ddlEstadoPerdida.SelectedItem.Text;
                    perdida.estado.idEstado = int.Parse(ddlEstadoPerdida.SelectedValue.ToString());
                }
                if (!ddlBarrioPerdida.SelectedValue.Equals("0"))
                {
                    perdida.barrio = new EBarrio();
                    perdida.barrio.idBarrio = int.Parse(ddlBarrioPerdida.SelectedValue.ToString());
                    perdida.barrio.nombre = ddlBarrioPerdida.SelectedItem.Text;
                }
                List<EPerdida> perdidas = LogicaBDPerdida.BuscarPerdidasPorOpciones(perdida);
                lblTitulo.Text = "LISTADO DE MASCOTAS PERDIDAS";
                grvPerdidas.DataSource = perdidas;
                grvPerdidas.DataBind();
            }
            if (ddlInforme.SelectedValue.Equals("2"))
            {
                pnlFiltros1.Visible = false;
                pnlFiltros2.Visible = false;
                pnlFiltros3.Visible = false;
                pnlFiltros4.Visible = false;
                pnlGenerar.Visible = false;
            }
            pnlImprimir.Visible = true;
        }
        public void ddlRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ERaza> razas = new List<ERaza>();
            if (!ddlEspecies.SelectedValue.Equals("0"))
            {
                int aux = int.Parse(ddlEspecies.SelectedValue);
                CargarCombos.cargarRazas(ref ddlRaza, aux);
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
            else
            {
                CargarCombos.cargarComboRazas(ref ddlRaza);
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }
        private void ExportarExel(string fileName, string contenType, GridView grvSeleccion)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AppendHeader("content-disposition", "atachament;filename=" + fileName);
            Response.Charset = "";
            Response.ContentType = contenType;
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            FileInfo fi = new FileInfo(Server.MapPath("~/assets/css/bootstrap.css"));
            StringBuilder sb = new StringBuilder();
            StreamReader sr = fi.OpenText();
            while (sr.Peek() >= 0)
            {
                sb.Append(sr.ReadLine());
            }
            sr.Close();
            grvSeleccion.RenderControl(hw);
            Response.Write("<html><head><style type='text/css'>" + sb.ToString() + "</style></head><body>" + sw.ToString() + "</body></html>");
            Response.Flush();
            Response.Close();
            Response.End();
        }
        protected void btnImprimirExcel_Click(object sender, EventArgs e)
        {
            if (ddlInforme.SelectedValue.Equals("1"))
            {
                string archivo = ddlInforme.SelectedItem.Text + ".xlsx";
                ExportarExel(archivo, "aplication/vnd.ms-excel", grvListas);
            }
            if (ddlInforme.SelectedValue.Equals("3"))
            {
                string archivo = ddlInforme.SelectedItem.Text + ".xlsx";
                ExportarExel(archivo, "aplication/vnd.ms-excel", grvAdopciones);
            }
            if (ddlInforme.SelectedValue.Equals("4"))
            {
                string archivo = ddlInforme.SelectedItem.Text + ".xlsx";
                ExportarExel(archivo, "aplication/vnd.ms-excel", grvHallazgos);
            }
            if (ddlInforme.SelectedValue.Equals("5"))
            {
                string archivo = ddlInforme.SelectedItem.Text + ".xlsx";
                ExportarExel(archivo, "aplication/vnd.ms-excel", grvPerdidas);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}