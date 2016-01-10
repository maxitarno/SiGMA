using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;
using Herramientas;

namespace SiGMA
{
    public partial class ConsultarPerdida : System.Web.UI.Page
    {
        string direccion = " ";
        string cuidado = " ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarSoloDueño(Session["UsuarioLogueado"].ToString()))
                        pnlVoluntario.Visible = true;
                    else
                    {
                        if (Session["idMascota"] != null && Session["pantalla"] != null && Session["pantalla"].ToString() == "ConsultaPerdidaUsuario")
                        {
                            cargarDatosPagina();
                            cargarDatosMascotaPerdida(Convert.ToInt32(Session["idMascota"].ToString()));
                            btnModificar.Visible = false; 
                            return;
                        }
                        MascotasPorDueño();
                    }
                    cargarDatosPagina();
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "ConsultarPerdida.aspx"))
                    {
                        if (Session["EsRol"].ToString() == "1" || Session["EsRol"].ToString() == "4" || Session["EsRol"].ToString() == "5")
                            Response.Redirect("PermisosInsuficientes.aspx");
                        if (Session["EsRol"].ToString() == "2")
                            Response.Redirect("PermisoInsuficiente.aspx");
                    }
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "ConsultarPerdida.aspx"))
                        btnModificar.Visible = false; 
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            pnlAtento.Visible = false;
            pnlInfo.Visible = false;
            pnlCorrecto.Visible = false;
        }

        private void cargarDatosPagina()
        {
            CargarCombos.cargarColor(ref ddlColor);
            CargarCombos.cargarEdad(ref ddlEdad);
            CargarCombos.cargarEspecies(ref ddlEspecie);
            CargarCombos.cargarComboRazas(ref ddlRaza);
            CargarCombos.cargarSexo(ref ddlSexo);
            CargarCombos.cargarLocalidades(ref ddlLocalidades);
            ddlLocalidades.SelectedValue = "1";
            CargarCombos.cargarBarrio(ref ddlBarrios, 1);
            CargarCombos.cargarBarrio(ref ddlBarrioPerdida, 1);
            CargarCombos.cargarCalles(ref ddlCalles, 1);
            CargarCombos.cargarCalles(ref ddlCallePerdida, 1);
            rnvFecha.MaximumValue = DateTime.Now.ToShortDateString();
            String modif = Request.QueryString["m"];
            if (modif == "1")
            {
                txtComentarios.Enabled = true;
                txtNroCallePerdida.Enabled = true;
                ddlBarrioPerdida.Enabled = true;
                ddlCallePerdida.Enabled = true;
                btnModificar.Visible = true;
                lblTitulo.Text = "Modificar Pérdida /";
            }
            else
            {
                txtComentarios.Enabled = false;
                txtNroCallePerdida.Enabled = false;
                ddlBarrioPerdida.Enabled = false;
                ddlCallePerdida.Enabled = false;
                btnModificar.Visible = false;
                lblTitulo.Text = "Consultar Pérdida /";
                txtFecha.Enabled = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascota.buscarMascotasPerdidas(txtMascota.Text);
            limpiarPagina();
            if(mascotas != null)
            {
                if (mascotas.Count != 0)
                {
                    pnlDueño.Visible = true;
                    lstMascotas.DataSource = mascotas;
                    lstMascotas.DataTextField = "nombreMascota";
                    lstMascotas.DataValueField = "idMascota";
                    lstMascotas.DataBind();
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron mascotas perdidas";
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                }
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron mascotas perdidas";
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }

        private void MascotasPorDueño()
        {
            limpiarPagina();
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascota.BuscarMascotaPorIdDueño(Convert.ToInt32(Session["IdDueño"]));
            if (mascotas.Count != 0)
            {
                pnlDueño.Visible = true;
                lstMascotas.DataSource = mascotas;
                lstMascotas.DataTextField = "nombreMascota";
                lstMascotas.DataValueField = "idMascota";
                lstMascotas.DataBind();
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron mascotas";
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }

        private void limpiarPagina()
        {
            pnlInfo.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlRegistrarPerdida.Visible = false;
            txtFecha.Text = "";
            txtComentarios.Text = "";
            pnlMapa.Visible = false;
            Session["r"] = false;
        }

        public void cargarDatosMascotaPerdida(int idMascota)
        {
             pnlRegistrarPerdida.Visible = false;
                        Session["imagen"] = null;
            EMascota mascota = new EMascota();
            EPerdida perdida = new EPerdida();
            if (LogicaBDPerdida.BuscarMascotaAConsultarPerdida(idMascota, mascota, perdida))
            {
                pnlMapa.Visible = true; //agregado
                pnlRegistrarPerdida.Visible = true;
                txtMascotaPerdida.Text = mascota.nombreMascota;
                if (mascota.duenio == null) 
                   mascota.duenio = new EDuenio();
                txtNroCalle.Text = mascota.duenio.nroCalle.ToString();
                txtDatosDueño.Text = (mascota.duenio.nombre == null) ? null : mascota.duenio.nombre.ToString();
                txtDatosDueño.Text += " ";
                txtDatosDueño.Text += (mascota.duenio.apellido == null) ? null : mascota.duenio.apellido.ToString();
                if (txtDatosDueño.Text == "")
                    txtDatosDueño.Text = "SIN ASIGNAR";
                if (mascota.duenio.domicilio != null)
                    ddlCalles.SelectedValue = (mascota.duenio.domicilio.idCalle == null) ? null : mascota.duenio.domicilio.idCalle.ToString();
                else
                    ddlCalles.SelectedValue = null;
                ddlBarrios.SelectedValue = (mascota.duenio.barrio == null) ? null : mascota.duenio.barrio.idBarrio.ToString();
                if (mascota.duenio.barrio != null)
                    ddlLocalidades.SelectedValue = (mascota.duenio.barrio.localidad == null) ? null : mascota.duenio.barrio.localidad.idLocalidad.ToString();
                else
                    ddlLocalidades.SelectedValue = null;
                ddlColor.SelectedValue = (mascota.color == null) ? null : mascota.color.idColor.ToString();
                ddlEdad.SelectedValue = (mascota.edad == null) ? null : mascota.edad.idEdad.ToString();
                ddlEspecie.SelectedValue = (mascota.especie == null) ? null : mascota.especie.idEspecie.ToString();
                ddlRaza.SelectedValue = (mascota.raza == null) ? null : mascota.raza.idRaza.ToString();
                ddlSexo.SelectedValue = mascota.sexo.ToString();
                if(perdida.domicilio != null)
                {
                    if(perdida.domicilio.barrio != null)
                    {
                        ddlBarrioPerdida.SelectedValue = perdida.domicilio.barrio.idBarrio.ToString();
                        ddlCallePerdida.SelectedValue = (perdida.domicilio.calle == null) ? null : perdida.domicilio.calle.idCalle.ToString();
                        txtNroCallePerdida.Text = perdida.domicilio.numeroCalle.ToString();
                        //agregado
                        hfDireccion.Value = "cordoba capital" + " " + ddlCallePerdida.SelectedItem.Text.ToLower().ToString() + " " + txtNroCallePerdida.Text;
                        hfNombre.Value = txtMascotaPerdida.Text;
                        if (mascota.raza.cuidadoEspecial.idCuidado == 0)
                        {
                            cuidado = "0";
                        }
                        else if (mascota.raza.cuidadoEspecial.idCuidado == 1 || mascota.raza.cuidadoEspecial.idCuidado == 4)
                        {
                            cuidado = "2";
                        }
                        else if (mascota.raza.cuidadoEspecial.idCuidado == 2)
                        {
                            cuidado = "8";
                        }
                        else if (mascota.raza.cuidadoEspecial.idCuidado == 3)
                        {
                            cuidado = "4";
                        }
                        hfCuidado.Value = cuidado.ToString();
                        //agregado
                    }
                }
                Session["idPerdida"] = perdida.idPerdida;
                txtFecha.Text = perdida.fecha.ToShortDateString();
                if (perdida.comentarios != null)
                {
                    txtComentarios.Text = perdida.comentarios.ToString();
                }
                Session["idMascota"] = idMascota;

                if (mascota.imagen != null)
                {
                    pnlImagen.Visible = true;
                    Session["imagen"] = mascota.imagen;
                    Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                    imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                    imgprvw.Width = 280;
                    imgprvw.Height = 235;
                }
                else
                {
                    pnlImagen.Visible = false;
                    imgprvw.Width = 0;
                    imgprvw.Height = 0;
                }
                
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "La mascota no se encuentra en estado: pérdida";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }

        protected void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idMascota = Convert.ToInt32(lstMascotas.SelectedValue);
            cargarDatosMascotaPerdida(idMascota);  
        }

        public byte[] ImageHandler_ObtenerImagenMascota(HttpContext context)
        {
            if (Session["imagen"] != null)
            {
                var imagen = (byte[])Session["imagen"];
                return imagen;
            }
            else
                return null;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    EPerdida perdida = new EPerdida();
                    perdida.mascota = new EMascota();
                    perdida.mascota.idMascota = Convert.ToInt32(Session["idMascota"].ToString());
                    perdida.idPerdida = Convert.ToInt32(Session["idPerdida"].ToString());
                    perdida.domicilio = new EDomicilio();
                    perdida.domicilio.barrio = new EBarrio();
                    perdida.domicilio.barrio.localidad = new ELocalidad();
                    perdida.domicilio.calle = new ECalle();
                    perdida.domicilio.barrio.idBarrio = int.Parse(ddlBarrioPerdida.SelectedValue);
                    perdida.domicilio.barrio.nombre = ddlBarrioPerdida.SelectedItem.Text;
                    perdida.domicilio.barrio.localidad.idLocalidad = 1;
                    perdida.domicilio.calle.idCalle = int.Parse(ddlCallePerdida.SelectedValue);
                    perdida.domicilio.barrio.localidad.nombre = "CORDOBA CAPITAL";
                    perdida.domicilio.calle.nombre = ddlCallePerdida.SelectedItem.Text;
                    perdida.domicilio.numeroCalle = int.Parse(txtNroCallePerdida.Text);
                    perdida.usuario = new EUsuario();
                    perdida.usuario.user = Session["UsuarioLogueado"].ToString();
                    perdida.fecha = Convert.ToDateTime(txtFecha.Text);
                    perdida.comentarios = txtComentarios.Text;
                    if (LogicaBDPerdida.modificarPerdida(perdida))
                    {
                        limpiarPagina();
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Pérdida Modificada Correctamente";
                    }
                    else
                    {
                        pnlAtento.Visible = true;
                        lblError.Text = "No se modifico la pérdida. Verifique datos";
                    }
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        protected void cvBarrioPerdida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlBarrioPerdida);
        }

        protected void cvCallePerdida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCallePerdida);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cuidado = "";
            EMascota mascota = (EMascota)Session["mascota"];
            
            direccion = "mapaPerdida.htm?direccion=argentina " + "cordoba capital" + " " + ddlCallePerdida.SelectedItem.Text.ToLower() + " " + txtNroCallePerdida.Text + "&cuidado=" + cuidado + "&nombre=" + mascota.nombreMascota;
            Response.Write("<script> window.open('" + direccion + "','popup','width=800,height=500') </script>");
        }
    }
}