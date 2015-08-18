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
                pnlModificar.Visible = false;
                pnlNombre.Visible = true;
                pnlResultados.Visible = false;
                pnlDatos.Visible = false;
                btnModificar.Visible = false;
                CargarCombos.cargarLocalidades(ref ddlLocalidad);
                CargarCombos.cargarCalles(ref ddlCalle);
                CargarCombos.cargarBarrio(ref ddlBarrio);
                String mod = Request.QueryString["m"];
                if (mod == "1")
                {
                    lblTitulo.Text = "Modificar Usuario";
                    btnModificar.Visible = true;
                    //btnEliminar.Visible = true;
                }
                else
                {
                    lblTitulo.Text = "Consultar Usuario";
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                }
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "CAMBVeterinarias.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "CAMBVeterinarias.aspx"))
                        btnModificar.Visible = false;
                    if (!LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "CAMBVeterinarias.aspx"))
                        btnEliminar.Visible = false;
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
        public void selectedIndexChange(object sender, EventArgs e)
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
                pnlModificar.Visible = false;
                pnlNombre.Visible = true;
                pnlResultados.Visible = true;
                pnlDatos.Visible = false;
                lstResultados.Items.Clear();
                lstResultados.DataSource = LogicaBDVeterinaria.BuscarPorNombre(txtNombre.Text);
                lstResultados.DataValueField = "id";
                lstResultados.DataTextField = "nombre";
                lstResultados.DataBind();
            }
            else if(rbPorDomicilio.Checked){
                pnlDomicilio.Visible = true;
                pnlModificar.Visible = false;
                pnlNombre.Visible = false;
                pnlResultados.Visible = true;
                pnlDatos.Visible = false;
                if (!ddlBarrio.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue.ToString());
                }
                if (!ddlCalle.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.calle.idCalle = int.Parse(ddlCalle.SelectedValue.ToString());
                }
                if (!ddlLocalidad.SelectedValue.Equals("0"))
                {
                    veterinaria.domicilio.barrio.localidad.idLocalidad = int.Parse(ddlLocalidad.SelectedValue.ToString());
                }
                lstResultados.Items.Clear();
                lstResultados.DataSource = LogicaBDVeterinaria.BuscarPorDomicilio(veterinaria);
                lstResultados.DataValueField = "id";
                lstResultados.DataTextField = "nombre";
                lstResultados.DataBind();
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
            ddlLocalidad.SelectedValue = veterinaria.domicilio.barrio.localidad.idLocalidad.ToString();
            ddlBarrio.SelectedValue = veterinaria.domicilio.barrio.idBarrio.ToString();
            ddlCalle.SelectedValue = veterinaria.domicilio.calle.idCalle.ToString();
            chkCastraciones.Checked = veterinaria.castraciones;
            chkMedicinas.Checked = veterinaria.medicina;
            chkPeluqueria.Checked = veterinaria.peluqueria;
            chkPetShop.Checked = veterinaria.petshop;
            txtContacto.Text = veterinaria.contacto;
            txtTE.Text = veterinaria.telefono;
            Session["id"] = veterinaria.id;
            pnlDomicilio.Visible = true;
            pnlModificar.Visible = true;
            pnlNombre.Visible = true;
            pnlResultados.Visible = false;
            pnlDatos.Visible = true;
        }
        public void Modificar(object sender, EventArgs e)
        {
            if(Validaciones.verificarSoloLetras(txtNombre.Text)){
                if(Validaciones.verificarSeleccionEnDdl(ref ddlLocalidad)){
                    if(Validaciones.verificarSeleccionEnDdl(ref ddlCalle)){
                        if(Validaciones.verificarSeleccionEnDdl(ref ddlBarrio)){
                            if(Validaciones.verificarSoloNumeros(txtTE.Text) && Validaciones.contarCaracteresMinimos(7, txtTE.Text) && Validaciones.contarCaracteresMaximos(13, txtTE.Text)){
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
                                if(LogicaBDVeterinaria.Modificar(veterinaria)){
                                    lblCorrecto.Text = "Se modifico correctamente";
                                    pnlInfo.Visible = false;
                                    pnlCorrecto.Visible = true;
                                    pnlAtento.Visible = false;
                                    pnlDomicilio.Visible = false;
                                    pnlModificar.Visible = false;
                                    pnlNombre.Visible = true;
                                    pnlResultados.Visible = false;
                                    pnlDatos.Visible = false;
                                }
                                else{
                                    lblError.Text = "No se pudo modificar";
                                    pnlInfo.Visible = false;
                                    pnlCorrecto.Visible = false;
                                    pnlAtento.Visible = true;
                                    pnlDomicilio.Visible = false;
                                    pnlModificar.Visible = false;
                                    pnlNombre.Visible = true;
                                    pnlResultados.Visible = false;
                                    pnlDatos.Visible = false;
                                }
                            }
                            else{
                                lblInfo.Text = "Debe ingresar un telefono valido";
                                pnlInfo.Visible = true;
                                pnlCorrecto.Visible = false;
                                pnlAtento.Visible = false;
                            }
                        }
                        else{
                            lblInfo.Text = "Debe ingresar un barrio valido";
                            pnlInfo.Visible = true;
                            pnlCorrecto.Visible = false;
                            pnlAtento.Visible = false;
                        }
                    }
                    else{
                        lblInfo.Text = "Debe ingresar una calle valida";
                        pnlInfo.Visible = true;
                        pnlCorrecto.Visible = false;
                        pnlAtento.Visible = false;
                    }
                }
                else{
                    lblInfo.Text = "Debe ingresar una localidad valida";
                    pnlInfo.Visible = true;
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                }
            }
            else{
                lblInfo.Text = "Debe ingresar un nombre";
                pnlInfo.Visible = true;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }

        }
        public void RbPorDomicilio(object sender, EventArgs e)
        {
            pnlDomicilio.Visible = true;
            pnlModificar.Visible = false;
            pnlNombre.Visible = false;
            pnlResultados.Visible = false;
            pnlDatos.Visible = false;
        }
        public void RbPorNombre(object sender, EventArgs e)
        {
            pnlDomicilio.Visible = false;
            pnlModificar.Visible = false;
            pnlNombre.Visible = true;
            pnlResultados.Visible = false;
            pnlDatos.Visible = false;
        }

        protected void btnMapa_Click(object sender, EventArgs e)
        {
            string direccion = "argentina " + ddlLocalidad.SelectedItem.Text.ToLower() + " " + ddlCalle.SelectedItem.Text.ToLower() + " " + txtNº.Text;
            Response.Redirect("mapa.htm?direccion=" + direccion);
        }
    }
}