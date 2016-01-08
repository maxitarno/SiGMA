using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;

namespace SiGMA
{
    public partial class AsignarMascotaHogar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarDatosMascota();
            }
        }

        private void cargarDatosMascota()
        {
            int idMascota = 0;
            if (Session["idMascotaHallada"] != null)
            {
                idMascota = Int32.Parse(Session["idMascotaHallada"].ToString());
            }
            if(idMascota != 0)
            {
                EMascota entMascota = LogicaBDMascota.BuscarMascotaPorIdMascota(idMascota);
                lblNombre.Text = entMascota.nombreMascota;
                lblRaza.Text = entMascota.raza.nombreRaza;
                lblSexo.Text = entMascota.sexo;
                lblEdad.Text = entMascota.edad.nombreEdad + " - " + entMascota.edad.descripcion;
                if (entMascota.tratoAnimal != null)
                {
                    lblTratoAnimales.Text = entMascota.tratoAnimal == false ? "No" : "Si";
                }
                else
                {
                    lblTratoAnimales.Text = "No especificado";
                }
                if (entMascota.tratoNiños != null)
                {
                    lblTratoNiños.Text = entMascota.tratoNiños == false ? "No" : "Si";
                }
                else
                {
                    lblTratoNiños.Text = "No especificado";
                }
                if (entMascota.caracter.descripcion != null)
                {
                    lblTemperamento.Text = entMascota.caracter.descripcion;
                }
                else
                {
                    lblTemperamento.Text = "No especificado";
                }
                if (entMascota.imagen != null)
                {
                    Session["imagen"] = entMascota.imagen;
                    Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                    imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                    imgprvw.Width = 400;
                    imgprvw.Height = 300;
                }
            }
        }

        protected void btnBuscarHogares_Click(object sender, EventArgs e)
        {
            listarHogares();
        }

        private void listarHogares()
        {
            EHogarProvisorio entHogar = new EHogarProvisorio();
            entHogar.AceptaEspecie = Int32.Parse(ddlEspecie.SelectedValue);
            entHogar.tieneNiños = ddlNiños.SelectedValue;
            entHogar.tipoHogar = Int32.Parse(ddlTipoHogar.SelectedValue);
            List<EHogarProvisorio> lstHogares = LogicaBDHogar.buscarHogaresDisponibles(entHogar);           
            if (lstHogares.Count == 0)
            {
                lblNoHogares.Visible = true;
                SetFocus(lblNoHogares);
                grvHogares.Visible = false;
            }
            else
            {
                grvHogares.DataSource = lstHogares;
                grvHogares.DataBind();
                grvHogares.Visible = true;
                lblNoHogares.Visible = false;
            }
        }

        public byte[] ImageHandler_ObtenerImagenMascota(HttpContext context)
        {            
            if (Session["imagen"] != null)
            {
                var imagen = (byte[])Session["imagen"];                
                Session["imagen"] = null;
                return imagen;
            }
            else
                return null;
        }
    }
}