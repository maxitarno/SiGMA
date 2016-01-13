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
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "Administracion"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "Administracion"))
                    {
                        btnRegistrar.Visible = false;
                        btnModificar.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarEspecies(ref ddlEspecies);
                CargarCombos.cargarCategorias(ref ddlCategoria);
            }
            pnlCorrecto.Visible = false;
            pnlAtento.Visible = false;
            pnlInfo.Visible = false;
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
            if (ddlEspecies.SelectedValue.Equals("0"))
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe seleccionar una especie";
            }
            else
            {
                CargarCombos.cargarRazaLista(ref lstResultados, txtNombre.Text, int.Parse(ddlEspecies.SelectedValue));
                if (lstResultados.Items.Count != 0)
                {
                    pnlRegistrar.Visible = false;
                    pnlResultado.Visible = true;
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron razas";
                }
            }
        }
        public void BtnSeleccionarClick(object sender, EventArgs e)
        {
            if (lstResultados.SelectedValue != "")
            {
                pnlRegistrar.Visible = false;
                pnlResultado.Visible = true;
                pnlCambio.Visible = true;
                ERaza raza = new ERaza();
                raza = Datos.BuscarRaza(int.Parse(lstResultados.SelectedValue));
                ddlEspecies.SelectedValue = raza.especie.idEspecie.ToString();
                txtNombre.Text = raza.nombreRaza;
                ddlCategoria.SelectedValue = raza.CategoriaRaza.idCategoriaRaza.ToString();
                ddlCuidadoEspecial.SelectedValue = raza.cuidadoEspecial.idCuidado.ToString();
                txtPeso.Text = raza.pesoRaza;
                Session["idraza"] = int.Parse(lstResultados.SelectedValue.ToString());
                ddlEspecies.SelectedValue = raza.especie.idEspecie.ToString();
                pnlDatos.Visible = true;
                btnModificar.Focus();
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe seleccionar una raza";
            }
        }
        public void BtnModificarClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (ddlEspecies.SelectedValue.Equals("0"))
                {
                    pnlRegistrar.Visible = false;
                    pnlInfo.Visible = true;
                    lblInfo.Text = "Debe seleccionar una especie";
                }
                else
                {
                    ERaza raza = new ERaza();
                    raza.pesoRaza = txtPeso.Text;
                    raza.nombreRaza = txtNombre.Text;
                    raza.CategoriaRaza = new ECategoriaRaza();
                    raza.cuidadoEspecial = new ECuidado();
                    raza.especie = new EEspecie();
                    raza.CategoriaRaza.idCategoriaRaza = int.Parse(ddlCategoria.SelectedValue.ToString());
                    raza.cuidadoEspecial.idCuidado = int.Parse(ddlCuidadoEspecial.SelectedValue.ToString());
                    raza.especie.idEspecie = int.Parse(ddlEspecies.SelectedValue.ToString());
                    raza.idRaza = (int)Session["idraza"];
                    if (Datos.ModificarRaza(raza))
                    {
                        lblCorrecto.Text = "Se modifico correctamente";
                        pnlCorrecto.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "No se pudo modificar";
                        pnlAtento.Visible = true;
                    }
                }
            }
        }
        public void BtnRegistrarClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ERaza raza = new ERaza();
                raza.especie = new EEspecie();
                raza.CategoriaRaza = new ECategoriaRaza();
                raza.cuidadoEspecial = new ECuidado();
                raza.CategoriaRaza.idCategoriaRaza = int.Parse(ddlCategoria.SelectedValue.ToString());
                raza.cuidadoEspecial.idCuidado = int.Parse(ddlCuidadoEspecial.SelectedValue.ToString());
                raza.especie.idEspecie = int.Parse(ddlEspecies.SelectedValue.ToString());
                raza.nombreRaza = txtNombre.Text;
                raza.pesoRaza = txtPeso.Text;
                if (Datos.guardarRaza(raza))
                {
                    lblCorrecto.Text = "Se registro correctamente";
                    pnlCorrecto.Visible = true;
                }
                else
                {
                    pnlAtento.Visible = true;
                    lblError.Text = "No se pudo registrar. Verifique datos";
                }
            }
        }
        public void BtnLimpiarClick(object sender, EventArgs e)
        {
            pnlCambio.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlDatos.Visible = true;
            pnlInfo.Visible = false;
            pnlResultado.Visible = false;
            txtNombre.Text = "";
            pnlRegistrar.Visible = true;
            ddlCategoria.SelectedValue = "0";
            ddlEspecies.SelectedValue = "0";
            ddlCuidadoEspecial.SelectedValue = "0";
            txtPeso.Text = "";
        }

        protected void ddlEspecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEspecies.SelectedValue == "SIN ASIGNAR")
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe seleccionar una especie";
            }
            else
            {
                btnNuevaRaza.Visible = true;
                btnBuscar.Visible = true;
            }
        }

        public void BtnNuevaRazaClick(object sender, EventArgs e)
        {
            pnlCambio.Visible = false;
            pnlDatos.Visible = true;
            pnlRegistrar.Visible = true;
            pnlResultado.Visible = false;
            txtNombre.Text = "";
            ddlCategoria.SelectedValue = "0";
            ddlCuidadoEspecial.SelectedValue = "0";
            txtPeso.Text = "";
            btnRegistrar.Focus();
        }

        protected void cvTipoMascota_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCuidadoEspecial);
            if (args.IsValid == false && btnRegistrar.Visible == false)
                btnModificar.Focus();
            if (args.IsValid == false && btnRegistrar.Visible == true)
                btnRegistrar.Focus();
        }

        protected void cvCategoria_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCategoria);
            if (args.IsValid == false && btnRegistrar.Visible == false)
                btnModificar.Focus();
            if (args.IsValid == false && btnRegistrar.Visible == true)
                btnRegistrar.Focus();
        }
    }
}