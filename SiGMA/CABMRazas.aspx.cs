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
                    Session["idraza"] = int.Parse(lstResultados.SelectedValue.ToString());
                    ddlEspecies.SelectedValue = raza.idEspecie.ToString();
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
        public void BtnModificarClick(object sender, EventArgs e)
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
                if (!ddlCuidadoEspecial.SelectedValue.Equals("0"))
                {
                    if (!ddlCategoria.SelectedValue.Equals("0"))
                    {
                        if (txtNombre.Text != "")
                        {
                            ERaza raza = new ERaza();
                            raza.pesoRaza = txtPeso.Text;
                            raza.nombreRaza = txtNombre.Text;
                            raza.idCategoriaRaza = int.Parse(ddlCategoria.SelectedValue.ToString());
                            raza.idcuidadoEspecial = int.Parse(ddlCuidadoEspecial.SelectedValue.ToString());
                            raza.idEspecie = int.Parse(ddlEspecies.SelectedValue.ToString());
                            raza.idRaza = (int)Session["idraza"];
                            if(Datos.ModificarRaza(raza)){
                                pnlInfo.Visible = false;
                                lblResultado1.Text = "Se modifico correctamente";
                                pnlCorrecto.Visible = true;
                                pnlAtento.Visible = false;
                            }
                            else{
                                pnlInfo.Visible = false;
                                lblResultado1.Text = "No se pudo modificar";
                                pnlCorrecto.Visible = false;
                                pnlAtento.Visible = true;
                            }
                        }
                        else
                        {
                            pnlInfo.Visible = true;
                            lblResultado2.Text = "Debe ingresar un nombre";
                            pnlCorrecto.Visible = false;
                            pnlAtento.Visible = false;
                        }
                    }
                    else
                    {
                        pnlInfo.Visible = true;
                        lblResultado2.Text = "Debe seleccionar una categoria";
                        pnlCorrecto.Visible = false;
                        pnlAtento.Visible = false;
                    }
                }
                else
                {
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "Debe seleccionar un cuidado";
                }
            }
        }
        public void BtnRegistrarClick(object sender, EventArgs e)
        {
            ERaza raza = new ERaza();
            raza.idCategoriaRaza = int.Parse(ddlCategoria.SelectedValue.ToString());
            raza.idcuidadoEspecial = int.Parse(ddlCuidadoEspecial.SelectedValue.ToString());
            raza.idEspecie = int.Parse(ddlEspecies.SelectedValue.ToString());
            raza.nombreRaza = txtNombre.Text;
            raza.pesoRaza = txtPeso.Text;
            if (!ddlCuidadoEspecial.SelectedValue.Equals("0"))
            {
                if (!ddlCategoria.SelectedValue.Equals("0"))
                {
                    if (!ddlEspecies.SelectedValue.Equals("0"))
                    {
                        if(Datos.guardarRaza(raza)){
                            lblResultado1.Text = "Se modifico correctamente";
                            pnlCorrecto.Visible = true;
                            pnlAtento.Visible = false;
                            pnlInfo.Visible = false;
                        }
                        else{
                            pnlCorrecto.Visible = false;
                            pnlAtento.Visible = true;
                            pnlInfo.Visible = false;
                            lblResultado3.Text = "No se pudo modificar";
                        }
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
                    lblResultado2.Text = "Debe seleccionar una categoria";
                }
            }
            else
            {
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar un cuidado";
            }
        }
        public void BtnLimpiarClick(object sender, EventArgs e)
        {
            pnlCambio.Visible = false;
            pnl8.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlDatos.Visible = false;
            pnlInfo.Visible = false;
            pnlResultado.Visible = false;
            pnlSeleccionar.Visible = false;
            txtNombre.Text = "";
        }
    }
}