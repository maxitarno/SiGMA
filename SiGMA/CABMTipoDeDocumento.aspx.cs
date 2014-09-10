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
            pnlResultado.Visible = true;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
        }
        public void BtnSeleccionarClick(object sender, EventArgs e)
        {
            if (lstResultados.SelectedValue != "")
            {
                pnlResultado.Visible = false;
                txtNombre.Text = lstResultados.SelectedItem.Text;
                lstResultados.Items.Clear();
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
            if (txtNombre.Text != "")
            {
                ETipoDeDocumento tipoDocumento = new ETipoDeDocumento();
                if (Datos.ModificarTipoDeDocumento(tipoDocumento, txtNombre.Text))
                {
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = true;
                    pnlInfo.Visible = false;
                    lblResultado1.Text = "Se modifico correctamente";
                    txtNombre.Text = "";
                }
                else
                {
                    pnlAtento.Visible = true;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    lblResultado1.Text = "No se pudo modificar";
                }
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = true;
                pnlInfo.Visible = false;
                lblResultado1.Text = "Debe seleccionar un tipo de documento";
            }
        }
    }
}