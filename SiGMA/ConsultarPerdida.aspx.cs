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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarSoloDueño(Session["UsuarioLogueado"].ToString()))
                        pnlVoluntario.Visible = true;
                    else
                        MascotasPorDueño();
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "ConsultarPerdida.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "ConsultarPerdida.aspx"))
                        btnModificar.Visible = false; 
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarColor(ref ddlColor);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarEspecies(ref ddlEspecie);
                CargarCombos.cargarComboRazas(ref ddlRaza);
                CargarCombos.cargarSexo(ref ddlSexo);
                CargarCombos.cargarBarrio(ref ddlBarrios);
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                CargarCombos.cargarCalles(ref ddlCalles);
                CargarCombos.cargarBarrio(ref ddlBarrioPerdida);
                CargarCombos.cargarLocalidades(ref ddlLocalidadPerdida);
                CargarCombos.cargarCalles(ref ddlCallePerdida);
                //txtFechaPerdida.Text = DateTime.Now.ToShortDateString();
                String modif = Request.QueryString["m"];
                if (modif == "1")
                {
                    txtComentarios.Enabled = true;
                    //txtFechaPerdida.Enabled = false;
                    //calendario.Enabled = true;
                    txtNroCallePerdida.Enabled = true;
                    ddlBarrioPerdida.Enabled = true;
                    ddlCallePerdida.Enabled = true;
                    ddlLocalidadPerdida.Enabled = true;
                    btnModificar.Visible = true;
                    lblTitulo.Text = "Modificar Pérdida";
                }
                else 
                {
                    txtComentarios.Enabled = false;
                    //txtFechaPerdida.Enabled = false;
                    //calendario.Enabled = false;
                    txtNroCallePerdida.Enabled = false;
                    ddlBarrioPerdida.Enabled = false;
                    ddlCallePerdida.Enabled = false;
                    ddlLocalidadPerdida.Enabled = false;
                    btnModificar.Visible = false;
                    lblTitulo.Text = "Consultar Pérdida";
                }
                if (Session["r"] != null)
                {
                    if ((bool)Session["r"])//rellena los datos
                    {
                        EMascota mascota = (EMascota)Session["mascota"];
                        EPerdida perdida = (EPerdida)Session["perdida"];
                        pnlMapa.Visible = true;
                        pnlRegistrarPerdida.Visible = true;
                        txtMascotaPerdida.Text = mascota.nombreMascota;
                        mascota.duenio = new EDuenio();
                        txtNroCalle.Text = mascota.duenio.nroCalle.ToString();
                        txtDatosDueño.Text = (mascota.duenio.nombre == null) ? null : mascota.duenio.nombre.ToString();
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
                        if (perdida.domicilio != null)
                        {
                            if (perdida.domicilio.barrio != null)
                            {
                                ddlLocalidadPerdida.SelectedValue = (perdida.domicilio.barrio.localidad == null) ? null : perdida.domicilio.barrio.localidad.idLocalidad.ToString();
                                ddlBarrioPerdida.SelectedValue = perdida.domicilio.barrio.idBarrio.ToString();
                                ddlCallePerdida.SelectedValue = (perdida.domicilio.calle == null) ? null : perdida.domicilio.calle.idCalle.ToString();
                                txtNroCallePerdida.Text = perdida.domicilio.numeroCalle.ToString();
                            }
                        }
                        Session["idPerdida"] = perdida.idPerdida;
                        txtFechaPerdida.Text = perdida.fecha.ToShortDateString();
                        if (perdida.comentarios != null)
                        {
                            txtComentarios.Text = perdida.comentarios.ToString();
                        }
                        Session["idMascota"] = mascota.idMascota;

                        if (mascota.imagen != null)
                        {
                            pnlImagen.Visible = true;
                            Session["imagen"] = mascota.imagen;
                            Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                            imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                            imgprvw.Width = 300;
                            imgprvw.Height = 250;
                        }
                        else
                        {
                            pnlImagen.Visible = false;
                            imgprvw.Width = 0;
                            imgprvw.Height = 0;
                        }
                    }//fin
                }
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

        protected void imgFechaPerdida_click(object sender, ImageClickEventArgs e)
        {
            //calendario.Visible = true;
        }

        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {
            //txtFechaPerdida.Text = calendario.SelectedDate.ToString("d");
            //calendario.Visible = false;
        }

        private void limpiarPagina()
        {
            pnlInfo.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlRegistrarPerdida.Visible = false;
            txtFechaPerdida.Text = "";
            txtComentarios.Text = "";
            //txtMapa.Text = "";
            pnlMapa.Visible = false;
            Session["r"] = false;
        }

        protected void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlRegistrarPerdida.Visible = false;
            Session["imagen"] = null;
            var idMascota = Convert.ToInt32(lstMascotas.SelectedValue);
            EMascota mascota = new EMascota();
            EPerdida perdida = new EPerdida();
            if (LogicaBDPerdida.BuscarMascotaAConsultarPerdida(idMascota, mascota, perdida))
            {
                pnlMapa.Visible = true; //agregado
                pnlRegistrarPerdida.Visible = true;
                txtMascotaPerdida.Text = mascota.nombreMascota;
                mascota.duenio = new EDuenio();
                txtNroCalle.Text = mascota.duenio.nroCalle.ToString();
                txtDatosDueño.Text = (mascota.duenio.nombre == null) ? null : mascota.duenio.nombre.ToString();
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
                        ddlLocalidadPerdida.SelectedValue = (perdida.domicilio.barrio.localidad == null) ? null : perdida.domicilio.barrio.localidad.idLocalidad.ToString();
                        ddlBarrioPerdida.SelectedValue = perdida.domicilio.barrio.idBarrio.ToString();
                        ddlCallePerdida.SelectedValue = (perdida.domicilio.calle == null) ? null : perdida.domicilio.calle.idCalle.ToString();
                        txtNroCallePerdida.Text = perdida.domicilio.numeroCalle.ToString();
                    }
                }
                Session["idPerdida"] = perdida.idPerdida;
                txtFechaPerdida.Text = perdida.fecha.ToShortDateString();
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
                    imgprvw.Width = 300;
                    imgprvw.Height = 250;
                }
                else
                {
                    pnlImagen.Visible = false;
                    imgprvw.Width = 0;
                    imgprvw.Height = 0;
                }
                Session["mascota"] = mascota;//agregado
                Session["perdida"] = perdida;//agregado
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "La mascota no se encuentra en estado: pérdida";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarPagina();
            lstMascotas.SelectedValue = null;
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
                    perdida.domicilio.barrio.localidad.idLocalidad = int.Parse(ddlLocalidadPerdida.SelectedValue);
                    perdida.domicilio.calle.idCalle = int.Parse(ddlCallePerdida.SelectedValue);
                    perdida.domicilio.barrio.localidad.nombre = ddlLocalidadPerdida.SelectedItem.Text;
                    perdida.domicilio.calle.nombre = ddlCallePerdida.SelectedItem.Text;
                    perdida.domicilio.numeroCalle = int.Parse(txtNroCallePerdida.Text);
                    perdida.usuario = new EUsuario();
                    perdida.usuario.user = Session["UsuarioLogueado"].ToString();
                    perdida.fecha = Convert.ToDateTime(txtFechaPerdida.Text);
                    perdida.comentarios = txtComentarios.Text;
                    //perdida.mapaPerdida = txtMapa.Text;
                    if (perdida.fecha > DateTime.Now)
                    {
                        pnlInfo.Visible = true;
                        lblInfo.Text = "La fecha de pérdida no puede ser superior a la actual";
                        txtFechaPerdida.Focus();
                        return;
                    }
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

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Perdidas.aspx");
        }

        protected void btnMapa_Click(object sender, EventArgs e)
        {
            string cuidado = "";
            EMascota mascota = (EMascota)Session["mascota"];
            if(mascota.raza.cuidadoEspecial.idCuidado == 0){
                cuidado = "0";
            }
            else if(mascota.raza.cuidadoEspecial.idCuidado == 1 || mascota.raza.cuidadoEspecial.idCuidado == 4){
                cuidado = "2";
            }
            else if(mascota.raza.cuidadoEspecial.idCuidado == 2){
                cuidado = "8";
            }
            else if(mascota.raza.cuidadoEspecial.idCuidado == 3){
                cuidado = "4";
            }
            string direccion = "argentina " + ddlLocalidadPerdida.SelectedItem.Text.ToLower() + " " + ddlCallePerdida.SelectedItem.Text.ToLower() + " " + txtNroCallePerdida.Text;
            Session["r"] = true;
            Response.Redirect("mapa1.htm?direccion=" + direccion + "&m=" + Request.QueryString["m"] + "&cuidado=" + cuidado);
        }
    }
}