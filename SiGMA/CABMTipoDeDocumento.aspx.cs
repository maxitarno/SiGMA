using Herramientas;
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
    public partial class CABMTipoDeDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
            CargarCombos.cargarTipoDocumentoLista(ref lstResultados, txtNombre.Text);
            if (lstResultados.Items.Count != 0)
            {
                pnlResultado.Visible = true;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlRegistrar.Visible = false;
                pnlSeleccionar.Visible = true;
                pnl8.Visible = true;
            }
            else
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "No se encontraron tipos de documento";
            }
        }
        public void BtnSeleccionarClick(object sender, EventArgs e)
        {
            if (lstResultados.SelectedValue != "")
            {
                pnlResultado.Visible = false;
                txtNombre.Text = lstResultados.SelectedItem.Text;
                Session["id"] = int.Parse(lstResultados.SelectedValue);
                lstResultados.Items.Clear();
                pnlCambio.Visible = true;
                pnlSeleccionar.Visible = false;
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                lblResultado2.Text = "Debe seleccionar un tipo de documento";
                pnlInfo.Visible = true;
            }
        }
        public void BtnModificarClick(object sender, EventArgs e)
        {
            if(txtNombre.Text != "" && Session["id"] != null)
            {
                ETipoDeDocumento tipoDocumento = new ETipoDeDocumento();
                tipoDocumento.idTipoDeDocumento = (int)Session["id"];
                tipoDocumento.nombre = txtNombre.Text;
                if (Datos.ModificarTipoDeDocumento(tipoDocumento))
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = true;
                    pnlInfo.Visible = false;
                    lblResultado1.Text = "Se modifico correctamente";
                    txtNombre.Text = "";
                    pnlRegistrar.Visible = true;
                    pnlBuscar.Visible = true;
                    pnlCambio.Visible = false;
                }
                else
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    lblResultado1.Text = "No se pudo modificar";
                }
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = true;
                lblResultado1.Text = "Debe ingresar un tipo de documento";
            }
        }
        public void BtnRegistrarClick(object sender, EventArgs e)
        {
                ETipoDeDocumento tipoDocumento = new ETipoDeDocumento();
                tipoDocumento.nombre = txtNombre.Text;
                if (Datos.guardarTipoDocumento(tipoDocumento))
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = true;
                    pnlInfo.Visible = false;
                    lblResultado1.Text = "Se registro correctamente";
                    txtNombre.Text = "";
                    pnlRegistrar.Visible = true;
                }
                else
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    lblResultado1.Text = "No se pudo registrar";
                }
        }
        /*public void BtnEliminarClick(object sender, EventArgs e)
        {
            if(Session["id"] != null)
            {
                ETipoDeDocumento tipoDocumento = new ETipoDeDocumento();
                tipoDocumento.idTipoDeDocumento = (int)Session["id"];
                tipoDocumento.nombre = txtNombre.Text;
                if (Datos.EliminarTiposDNI(tipoDocumento))
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = true;
                    pnlInfo.Visible = false;
                    lblResultado1.Text = "Se modifico correctamente";
                    txtNombre.Text = "";
                }
                else
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    lblResultado1.Text = "No se pudo modificar";
                }
            }
        }*/
        public void BtnLimpiarClick(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
            txtNombre.Text = "";
            pnlRegistrar.Visible = true;
            pnlBuscar.Visible = true;
            pnlCambio.Visible = false;
            pnl8.Visible = false;
            pnlSeleccionar.Visible = false;
            pnlResultado.Visible = false;
        }
    }
}