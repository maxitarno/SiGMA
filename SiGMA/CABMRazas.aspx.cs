using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;
using Entidades;
using AccesoADatos;
namespace SiGMA
{
    public partial class CABMRazas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarEspecies(ref ddlEspecies);
                CargarCombos.cargarCategorias(ref ddlCategoria);
                CargarCombos.cargarCuidados(ref ddlCuidadoEspecial);
            }
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
            if (ddlEspecies.SelectedValue.Equals("0"))
            {
                pnlRegistrar.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar una especie";
            }
            else
            {
                CargarCombos.cargarRazaLista(ref lstResultados, txtNombre.Text, int.Parse(ddlEspecies.SelectedValue));
                if (lstResultados.Items.Count != 0)
                {
                    pnlRegistrar.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = false;
                    pnlResultado.Visible = true;
                    pnlSeleccionar.Visible = true;
                }
                else
                {
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron razas";
                }
            }
        }
        public void BtnSeleccionarClick(object sender, EventArgs e)
        {
            if (lstResultados.Items.Count != 0)
            {
                pnlRegistrar.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
                pnlInfo.Visible = false;
                pnlResultado.Visible = true;
                pnlSeleccionar.Visible = true;
                if (lstResultados.SelectedValue != "")
                {
                    pnlCambio.Visible = true;
                    pnlSeleccionar.Visible = false;
                    pnl8.Visible = true;
                    ERaza raza = new ERaza();
                    raza = Datos.BuscarRaza(int.Parse(lstResultados.SelectedValue));
                    ddlEspecies.SelectedValue = raza.idEspecie.ToString();
                    txtNombre.Text = raza.nombreRaza;
                    ddlCategoria.SelectedValue = raza.idCategoriaRaza.ToString();
                    ddlCuidadoEspecial.SelectedValue = raza.idcuidadoEspecial.ToString();
                    txtPeso.Text = raza.pesoRaza;
                }
                else
                {
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "Debe seleccionar una especie";
                }
            }
            else
            {
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar una raza";
            }
        }
    }
}