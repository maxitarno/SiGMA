using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;
using AccesoADatos;
using Entidades;
namespace SiGMA
{
    public partial class CAMBVeterinarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pnlDomicilio.Visible = false;
                pnlDomicilio1.Visible = false;
                pnlDatos1.Visible = false;
                pnlDatos.Visible = false;
                pnlResultados.Visible = false;
                pnlNombre.Visible = true;
                CargarCombos.cargarLocalidades(ref ddlLocalidad);
                ddlLocalidad.SelectedValue = "1";
                CargarCombos.cargarBarrio(ref ddlBarrio, 1);
                CargarCombos.cargarCalles(ref ddlCalle, 1);
                String mod = Request.QueryString["m"];
                if (mod == "1")
                {
                    lblTitulo.Text = "Modificar Veterinaria /";
                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                }
                else
                {
                    lblTitulo.Text = "Consultar Veterinaria /";
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                }
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RegistrarVeterinaria.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RegistrarVeterinaria.aspx"))
                        btnModificar.Visible = false;
                    if (!LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "RegistrarVeterinaria.aspx"))
                        btnEliminar.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        public void SeleccionarLocalidad(object sender, EventArgs e)
        {
            CargarCombos.cargarBarrio(ref ddlBarrio, int.Parse(ddlLocalidad.SelectedValue.ToString()));
            CargarCombos.cargarCalles(ref ddlCalle, int.Parse(ddlLocalidad.SelectedValue.ToString()));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            EVeterinaria veterinaria = new EVeterinaria();
            veterinaria.domicilio = new EDomicilio();
            veterinaria.domicilio.barrio = new EBarrio();
            veterinaria.domicilio.calle = new ECalle();
            veterinaria.domicilio.barrio.localidad = new ELocalidad();
            if (rbPorNombre.Checked)
            {
                pnlDomicilio.Visible = false;
                pnlDomicilio1.Visible = false;
                pnlDatos1.Visible = false;
                pnlDatos.Visible = false;
                pnlNombre.Visible = true;
                pnlResultados.Visible = true;
                lstResultados.Items.Clear();
                lstResultados.DataSource = LogicaBDVeterinaria.BuscarPorNombre(txtNombreBusqueda.Text);
                lstResultados.DataValueField = "id";
                lstResultados.DataTextField = "nombre";
                lstResultados.DataBind();
                if (lstResultados.Items.Count != 0)
                {
                    pnlResultados.Visible = true;
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                }
                else
                {
                    pnlResultados.Visible = false;
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron veterinaria";
                }
                if (lstResultados.Items.Count == 1)
                {
                    lstResultados.SelectedIndex = 0;
                    selected(null, null);
                }
            }
            else if(rbPorDomicilio.Checked){
                pnlDomicilio.Visible = true;
                pnlDomicilio1.Visible = true;
                pnlNombre.Visible = false;
                pnlResultados.Visible = true;
                pnlDatos.Visible = false;
                pnlDatos1.Visible = false;
                if (!ddlBarrio.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue.ToString());
                }
                else
                {
                    veterinaria.domicilio.barrio.idBarrio = null;
                }
                if (!ddlCalle.SelectedValue.Equals("") && !ddlCalle.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.calle.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
                }
                else
                {
                    veterinaria.domicilio.calle.idCalle = null;
                }
                if (!ddlLocalidad.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.barrio.localidad.idLocalidad = int.Parse(ddlLocalidad.SelectedValue.ToString());
                }
                else
                {
                    veterinaria.domicilio.barrio.localidad.idLocalidad = null;
                }
                lstResultados.Items.Clear();
                lstResultados.DataSource = LogicaBDVeterinaria.BuscarPorDomicilio(veterinaria);
                lstResultados.DataValueField = "id";
                lstResultados.DataTextField = "nombre";
                lstResultados.DataBind();
                if (lstResultados.Items.Count != 0)
                {
                    pnlResultados.Visible = true;
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    pnlBotones.Visible = false;
                }
                else
                {
                    pnlResultados.Visible = false;
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    pnlBotones.Visible = false;
                    lblInfo.Text = "No se encontraron veterinarias";
                }
                if (lstResultados.Items.Count == 1)
                {
                    lstResultados.SelectedIndex = 0;
                    selected(null, null);
                }
            }
        }

        public void selected(object sender, EventArgs e)
        {
            EVeterinaria veterinaria = new EVeterinaria();
            veterinaria.domicilio = new EDomicilio();
            veterinaria.domicilio.calle = new ECalle();
            veterinaria.domicilio.barrio = new EBarrio();
            veterinaria.domicilio.barrio.localidad = new ELocalidad();
            veterinaria.id = int.Parse(lstResultados.SelectedValue.ToString());
            LogicaBDVeterinaria.Buscar(veterinaria);
            txtNombre.Text = veterinaria.nombre;
            txtNombreBusqueda.Text = veterinaria.nombre;
            ddlLocalidad.SelectedValue = veterinaria.domicilio.barrio.localidad.idLocalidad.ToString();
            ddlBarrio.SelectedValue = veterinaria.domicilio.barrio.idBarrio.ToString();
            ddlCalle.SelectedValue = veterinaria.domicilio.calle.idCalle.ToString();
            chkCastraciones.Checked = veterinaria.castraciones;
            chkMedicinas.Checked = veterinaria.medicina;
            chkPeluqueria.Checked = veterinaria.peluqueria;
            chkPetShop.Checked = veterinaria.petshop;
            txtContacto.Text = veterinaria.contacto;
            txtTE.Text = veterinaria.telefono;
            txtNº.Text = veterinaria.domicilio.numeroCalle.ToString();//agregado
            Session["id"] = veterinaria.id;
            pnlDomicilio.Visible = true;
            pnlDomicilio1.Visible = true;
            pnlNombre.Visible = true;
            pnlResultados.Visible = true;
            pnlDatos.Visible = true;
            pnlDatos1.Visible = true;
            pnlBotones.Visible = true;
            pnlMapa.Visible = true;
            Session["veterinaria"] = veterinaria;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
            hfContacto.Value = txtContacto.Text;
            hfDireccion.Value = ddlLocalidad.SelectedItem.Text.ToLower().ToString() + " " + ddlCalle.SelectedItem.Text.ToLower().ToString() + " " + txtNº.Text;
            hfNombre.Value = txtNombre.Text;
            hfTelefono.Value = txtTE.Text;
            pnlBotones.Visible = true;
        }
        public void Modificar(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EVeterinaria veterinaria = new EVeterinaria();
                veterinaria.domicilio = new EDomicilio();
                veterinaria.domicilio.calle = new ECalle();
                veterinaria.domicilio.barrio = new EBarrio();
                veterinaria.domicilio.barrio.localidad = new ELocalidad();
                veterinaria.castraciones = chkCastraciones.Checked;
                veterinaria.contacto = txtContacto.Text;
                veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue.ToString());
                veterinaria.domicilio.calle.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
                veterinaria.domicilio.numeroCalle = (txtNº.Text == "") ? 0 : int.Parse(txtNº.Text);
                veterinaria.id = (int)Session["id"];
                veterinaria.medicina = chkMedicinas.Checked;
                veterinaria.nombre = txtNombre.Text;
                veterinaria.peluqueria = chkPeluqueria.Checked;
                veterinaria.petshop = chkPetShop.Checked;
                veterinaria.telefono = txtTE.Text;
                if (LogicaBDVeterinaria.Modificar(veterinaria))
                {
                    lblCorrecto.Text = "Se modifico correctamente";
                    pnlInfo.Visible = false;
                    pnlCorrecto.Visible = true;
                    pnlDomicilio.Visible = false;
                    pnlDomicilio1.Visible = false;
                    pnlDatos1.Visible = false;
                    pnlDatos.Visible = false;
                    pnlNombre.Visible = true;
                    pnlBotones.Visible = false;
                    rbPorNombre.Checked = true;
                    pnlResultados.Visible = false;
                    pnlMapa.Visible = false;
                    txtNombre.Text = "";
                    txtNombreBusqueda.Text = "";
                }
                else
                {
                    lblError.Text = "No se pudo modificar";
                    pnlInfo.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = true;
                    pnlDomicilio.Visible = true;
                    pnlDomicilio1.Visible = true;
                    pnlDatos1.Visible = true;
                    pnlDatos.Visible = true;
                    if (rbPorNombre.Checked)
                        pnlNombre.Visible = true;
                    else
                        pnlNombre.Visible = false;
                    pnlBotones.Visible = true;
                    pnlResultados.Visible = true;
                    pnlMapa.Visible = true;
                }
            }
        }
        public void RbPorDomicilio(object sender, EventArgs e)
        {
            pnlDomicilio.Visible = true;
            pnlDomicilio1.Visible = true;
            pnlNombre.Visible = false;
            pnlResultados.Visible = false;
            pnlDatos.Visible = false;
            pnlDatos1.Visible = false;
            pnlMapa.Visible = false;
            pnlInfo.Visible = false;
            pnlCorrecto.Visible = false;
            pnlAtento.Visible = false;
            pnlBotones.Visible = false;
            ddlBarrio.SelectedValue = "0";
            ddlCalle.SelectedValue = "0";
            txtNombre.Text = "";
            txtNombreBusqueda.Text = "";
            txtNº.Text = "";
        }
        public void RbPorNombre(object sender, EventArgs e)
        {
            pnlDomicilio.Visible = false;
            pnlDomicilio1.Visible = false;
            pnlNombre.Visible = true;
            pnlResultados.Visible = false;
            pnlDatos.Visible = false;
            pnlDatos1.Visible = false;
            pnlMapa.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlInfo.Visible = false;
            pnlBotones.Visible = false;
            ddlBarrio.SelectedValue = "0";
            ddlCalle.SelectedValue = "0";
            txtNombre.Text = "";
            txtNombreBusqueda.Text = "";
            txtNº.Text = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EVeterinaria veterinaria = new EVeterinaria();
            veterinaria.id = (int)Session["id"];
            if (LogicaBDVeterinaria.Eliminar(veterinaria))
            {
                pnlCorrecto.Visible = true;
                lblCorrecto.Text = "Se elimino correctamente";
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                pnlDomicilio.Visible = false;
                pnlDomicilio1.Visible = false;
                pnlNombre.Visible = true;
                pnlResultados.Visible = false;
                pnlDatos.Visible = false;
                pnlMapa.Visible = false;
                pnlBotones.Visible = false;
                txtNombre.Text = "";
                txtNombreBusqueda.Text = "";
                pnlDatos1.Visible = false;
            }
            else
            {
                lblError.Text = "No se pudo eliminar";
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = true;
                pnlDomicilio.Visible = true;
                pnlDomicilio1.Visible = true;
                pnlDatos1.Visible = true;
                pnlDatos.Visible = true;
                if (rbPorNombre.Checked)
                    pnlNombre.Visible = true;
                else
                    pnlNombre.Visible = false;
                pnlBotones.Visible = true;
                pnlResultados.Visible = true;
                pnlMapa.Visible = true;
            }
        }

        protected void cvCalle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCalle);
        }

        protected void cvBarrio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlBarrio);
        }

        protected void cvTelefono_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtTE.Text);
        }

        protected void cvLocalidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlLocalidad);
        }
    }


}