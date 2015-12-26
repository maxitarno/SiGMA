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
    public partial class RegistrarVeterinaria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarLocalidades(ref ddlLocalidad);
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RegistrarVeterinaria.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RegistrarVeterinaria.aspx"))
                        btnRegistrar.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Veterinarias.aspx");
        }
        public void SeleccionarLocalidad(object sender, EventArgs e)
        {
            CargarCombos.cargarBarrio(ref ddlBarrio, int.Parse(ddlLocalidad.SelectedValue.ToString()));
            CargarCombos.cargarCalles(ref ddlCalle, int.Parse(ddlLocalidad.SelectedValue.ToString()));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Validaciones.verificarSoloLetras(txtNombre.Text))
            {
                if (Validaciones.verificarSeleccionEnDdl(ref ddlLocalidad))
                {
                    if (Validaciones.verificarSeleccionEnDdl(ref ddlBarrio))
                    {
                        if (Validaciones.verificarSeleccionEnDdl(ref ddlCalle))
                        {
                            if (Validaciones.verificarSoloNumeros(txtNº.Text))
                            {
                                if (Validaciones.contarCaracteresMinimos(7, txtTE.Text) && Validaciones.contarCaracteresMaximos(16, txtTE.Text))
                                {
                                    EVeterinaria veterinaria = new EVeterinaria();
                                    veterinaria.nombre = txtNombre.Text;
                                    veterinaria.peluqueria = chkPeluqueria.Checked;
                                    veterinaria.petshop = chkPetShop.Checked;
                                    veterinaria.medicina = chkMedicinas.Checked;
                                    veterinaria.castraciones = chkCastraciones.Checked;
                                    veterinaria.contacto = (txtContacto.Text == "") ? "" : txtContacto.Text;
                                    veterinaria.telefono = (txtTE.Text == "") ? "" : txtTE.Text;
                                    veterinaria.domicilio = new EDomicilio();
                                    veterinaria.domicilio.barrio = new EBarrio();
                                    veterinaria.domicilio.barrio.localidad = new ELocalidad();
                                    veterinaria.domicilio.barrio.localidad.idLocalidad = int.Parse(ddlLocalidad.SelectedValue.ToString());
                                    veterinaria.domicilio.barrio = new EBarrio();
                                    veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue.ToString());
                                    veterinaria.domicilio.calle = new ECalle();
                                    veterinaria.domicilio.calle.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
                                    veterinaria.domicilio.numeroCalle = int.Parse(txtNº.Text);
                                    if (LogicaBDVeterinaria.RegistrarVeterinaria(veterinaria))
                                    {
                                        pnlCorrecto.Visible = true;
                                        lblCorrecto.Text = "Se registro correctamente";
                                        pnlAtento.Visible = false;
                                        pnlInfo.Visible = false;
                                        txtContacto.Text = "";
                                        txtNº.Text = "";
                                        txtNombre.Text = "";
                                        txtTE.Text = "";
                                        ddlBarrio.SelectedIndex = -1;
                                        ddlCalle.SelectedIndex = -1;
                                        ddlLocalidad.SelectedIndex = -1;
                                    }
                                    else
                                    {
                                        pnlCorrecto.Visible = false;
                                        lblError.Text = "No se pudo registrar";
                                        pnlAtento.Visible = true;
                                        pnlInfo.Visible = false;
                                    }
                                }
                                else
                                {
                                    pnlCorrecto.Visible = false;
                                    lblInfo.Text = "Debe ingresar un número de telefono valido";
                                    pnlAtento.Visible = false;
                                    pnlInfo.Visible = true;
                                }
                            }
                            else
                            {
                                pnlCorrecto.Visible = false;
                                lblInfo.Text = "Debe ingresar un número de calle valido";
                                pnlAtento.Visible = false;
                                pnlInfo.Visible = true;
                            }
                        }
                        else
                        {
                            pnlCorrecto.Visible = false;
                            lblInfo.Text = "Debe seleccionar una calle";
                            pnlAtento.Visible = false;
                            pnlInfo.Visible = true;
                        }
                    }
                    else
                    {
                        pnlCorrecto.Visible = false;
                        lblInfo.Text = "Debe ingresar un barrio";
                        pnlAtento.Visible = false;
                        pnlInfo.Visible = true;
                    }
                }
                else
                {
                    pnlCorrecto.Visible = false;
                    lblInfo.Text = "Debe ingresar una localidad";
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = true;
                }
            }
            else
            {
                pnlCorrecto.Visible = false;
                lblInfo.Text = "Debe ingresar un nombre valido";
                pnlAtento.Visible = false;
                pnlInfo.Visible = true;
            }
        }
    }
}