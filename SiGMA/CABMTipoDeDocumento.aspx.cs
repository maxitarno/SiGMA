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
            }
            else 
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
            }
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            btnNuevoDoc.Visible = true;
            lstResultados.Items.Clear();
            CargarCombos.cargarTipoDocumentoLista(ref lstResultados, txtNombre.Text);
            if (lstResultados.Items.Count != 0)
            {
                pnlResultado.Visible = true;
                btnRegistrar.Visible = false;
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron tipos de documento";
            }
        }
        public void BtnSeleccionarClick(object sender, EventArgs e)
        {
            if (lstResultados.SelectedValue != "")
            {
                btnNuevoDoc.Visible = false;
                btnBuscar.Visible = false;
                pnlResultado.Visible = false;
                txtNombre.Text = lstResultados.SelectedItem.Text;
                Session["id"] = int.Parse(lstResultados.SelectedValue);
                lstResultados.Items.Clear();
                btnModificar.Visible = true;
                btnCancelar.Visible = true;
            }
            else
            {
                lblInfo.Text = "Debe seleccionar un tipo de documento";
                pnlInfo.Visible = true;
            }
        }
        public void BtnModificarClick(object sender, EventArgs e)
        {
            if(Validaciones.verificarSoloLetras(txtNombre.Text) && Session["id"] != null)
            {
                ETipoDeDocumento tipoDocumento = new ETipoDeDocumento();
                tipoDocumento.idTipoDeDocumento = (int)Session["id"];
                tipoDocumento.nombre = txtNombre.Text;
                if (Datos.ModificarTipoDeDocumento(tipoDocumento))
                {
                    pnlCorrecto.Visible = true;
                    lblCorrecto.Text = "Se modifico correctamente";
                    txtNombre.Text = "";
                    btnRegistrar.Visible = false;
                    btnBuscar.Visible = true;
                    btnNuevoDoc.Visible = true;
                    btnModificar.Visible = false;
                    btnCancelar.Visible = false;
                }
                else
                {
                    pnlAtento.Visible = true;
                    lblError.Text = "No se pudo modificar";
                }
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe ingresar un nombre valido";
            }
        }
        public void BtnRegistrarClick(object sender, EventArgs e)
        {
            if (Validaciones.verificarSoloLetras(txtNombre.Text))
            {
                ETipoDeDocumento tipoDocumento = new ETipoDeDocumento();
                tipoDocumento.nombre = txtNombre.Text;
                if (Datos.guardarTipoDocumento(tipoDocumento))
                {
                    pnlCorrecto.Visible = true;
                    lblCorrecto.Text = "Se registro correctamente";
                    txtNombre.Text = "";
                    btnRegistrar.Visible = false;
                    btnBuscar.Visible = true;
                    btnNuevoDoc.Visible = true;
                    btnModificar.Visible = false;
                    btnCancelar.Visible = false;
                }
                else
                {
                    pnlAtento.Visible = true;
                    lblError.Text = "No se pudo registrar";
                }
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe ingresar un nombre valido";
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
        public void BtnNuevoDocClick(object sender, EventArgs e)
        {
            btnModificar.Visible = false;
            btnRegistrar.Visible = true;
            btnNuevoDoc.Visible = false;
            pnlResultado.Visible = false;
            btnBuscar.Visible = false;
            txtNombre.Text = "";
            btnRegistrar.Focus();
            btnCancelar.Visible = true;
        }

        public void BtnCancelarClick(object sender, EventArgs e)
        {
            btnModificar.Visible = false;
            btnRegistrar.Visible = false;
            btnNuevoDoc.Visible = true;
            pnlResultado.Visible = false;
            btnBuscar.Visible = true;
            txtNombre.Text = "";
            btnCancelar.Visible = false;
        }
        
    }
}