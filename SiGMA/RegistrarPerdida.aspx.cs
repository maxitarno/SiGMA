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
    public partial class RegistrarPerdida : System.Web.UI.Page
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
                    {
                        if (Session["idMascota"] != null && Session["pantalla"].ToString() == "MisMascotas.aspx")
                        {
                            cargarMascotaPerdida(Convert.ToInt32(Session["idMascota"].ToString()));
                            return;
                        }
                    }

                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RegistrarPerdida.aspx"))
                    {
                        if (Session["EsRol"].ToString() == "1" || Session["EsRol"].ToString() == "4" || Session["EsRol"].ToString() == "5")
                            Response.Redirect("PermisosInsuficientes.aspx");
                        if (Session["EsRol"].ToString() == "2")
                            Response.Redirect("PermisoInsuficiente.aspx");
                    }
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RegistrarPerdida.aspx"))
                        btnRegistrarPerdida.Visible = false; 
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                cargarCombos();
            }
        }

        public void cargarCombos()
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
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascota.buscarMascotasPorNombre(txtMascota.Text);
            limpiarPagina();
            if (mascotas == null)
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Ingrese al menos una letra para buscar mascotas";
                return;
            }
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
        }

        protected void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idMascota = Convert.ToInt32(lstMascotas.SelectedValue);
            cargarMascotaPerdida(idMascota);
        }

        public void cargarMascotaPerdida(int idMascota) 
        {
            cargarCombos();
            Session["imagen"] = null;
            EMascota mascota = new EMascota();
            EDuenio duenio = new EDuenio();
            if (LogicaBDPerdida.BuscarMascotaARegistrarPerdida(idMascota, mascota, duenio))
            {
                pnlRegistrarPerdida.Visible = true;
                txtMascotaPerdida.Text = mascota.nombreMascota;
                txtNroCalle.Text = duenio.nroCalle.ToString();
                txtDatosDueño.Text = (duenio.nombre == null) ? null : duenio.nombre.ToString();
                txtDatosDueño.Text += " ";
                txtDatosDueño.Text += (duenio.apellido == null) ? null : duenio.apellido.ToString();
                if (txtDatosDueño.Text == "")
                    txtDatosDueño.Text = "SIN ASIGNAR";
                if (duenio.domicilio != null)
                    ddlCalles.SelectedValue = (duenio.domicilio.idCalle == null) ? null : duenio.domicilio.idCalle.ToString();
                else
                    ddlCalles.SelectedValue = null;
                ddlBarrios.SelectedValue = (duenio.barrio == null) ? null : duenio.barrio.idBarrio.ToString();
                if (duenio.barrio != null)
                    ddlLocalidades.SelectedValue = (duenio.barrio.localidad == null) ? null : duenio.barrio.localidad.idLocalidad.ToString();
                else
                    ddlLocalidades.SelectedValue = null;
                ddlColor.SelectedValue = (mascota.color == null) ? null : mascota.color.idColor.ToString();
                ddlEdad.SelectedValue = (mascota.edad == null) ? null : mascota.edad.idEdad.ToString();
                ddlEspecie.SelectedValue = (mascota.especie == null) ? null : mascota.especie.idEspecie.ToString();
                ddlRaza.SelectedValue = (mascota.raza == null) ? null : mascota.raza.idRaza.ToString();
                ddlSexo.SelectedValue = mascota.sexo.ToString();
                Session["idMascota"] = idMascota;

                if (mascota.imagen != null)
                {
                    pnlImagen.Visible = true;
                    Session["imagen"] = mascota.imagen;
                    Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                    imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                    imgprvw.Width = 255;
                    imgprvw.Height = 210;
                }
                else
                {
                    pnlImagen.Visible = false;
                    imgprvw.Width = 0;
                    imgprvw.Height = 0;
                }
                pnlInfo.Visible = false;
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "La mascota no se encuentra en estado necesario para registrar una pérdida";
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
        }

        protected void btnRegistrarPerdida_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    EPerdida perdida = new EPerdida();
                    perdida.mascota = new EMascota();
                    perdida.mascota.idMascota = Convert.ToInt32(Session["idMascota"].ToString());
                    perdida.mascota.raza = new ERaza { nombreRaza = ddlRaza.SelectedItem.Text };
                    perdida.mascota.color = new EColor { nombreColor = ddlColor.SelectedItem.Text };
                    perdida.mascota.sexo = ddlSexo.SelectedItem.Text;                    
                    perdida.domicilio = new EDomicilio();
                    perdida.domicilio.barrio = new EBarrio();
                    perdida.domicilio.barrio.localidad = new ELocalidad();
                    perdida.domicilio.calle = new ECalle();
                    perdida.domicilio.barrio.idBarrio = int.Parse(ddlBarrioPerdida.SelectedValue);
                    perdida.domicilio.barrio.nombre = ddlBarrioPerdida.SelectedItem.Text;
                    perdida.domicilio.calle.nombre = ddlCallePerdida.SelectedItem.Text;
                    perdida.domicilio.calle.idCalle = int.Parse(ddlCallePerdida.SelectedValue);
                    perdida.domicilio.numeroCalle = int.Parse(txtNroCallePerdida.Text);
                    perdida.usuario = new EUsuario();
                    perdida.usuario.user = Session["UsuarioLogueado"].ToString();
                    var fecha = DateTime.Today;
                    if (DateTime.TryParse(txtFecha.Text, out fecha))
                        perdida.fecha = Convert.ToDateTime(txtFecha.Text);
                    else
                    {
                        lblInfo.Text = "Ingrese una fecha válida";
                        pnlInfo.Visible = true;
                    }
                    perdida.comentarios = txtComentarios.Text;
                    //perdida.mapaPerdida = txtMapa.Text;
                    if (perdida.fecha > DateTime.Now)
                    {
                        pnlInfo.Visible = true;
                        lblInfo.Text = "La fecha de pérdida no puede ser superior a la actual";
                        txtFecha.Focus();
                        return;
                    }                    
                    if (LogicaBDRol.puedePublicarDifusion(Session["UsuarioLogueado"].ToString()))
                    {
                        if (LogicaBDPerdida.registrarPerdida(perdida))
                        {
                            limpiarPagina();
                            pnlCorrecto.Visible = true;
                            lblCorrecto.Text = "Pérdida Registrada Correctamente";
                        }
                        else
                        {
                            pnlAtento.Visible = true;
                            lblError.Text = "No se registro la pérdida. Verifique datos";
                            return;
                        }
                        var tweet = new Herramientas.GestorTwitter();
                        byte[] imagen = (byte[])Session["imagen"];                        
                        if (imagen != null)
                        {
                            tweet.PublicarTweetConFoto(imagen, tweet.generarMensajePerdida(perdida));
                        }
                        else
                        {
                            tweet.PublicarTweetSoloTexto(tweet.generarMensajePerdida(perdida));
                        }                        
                    }
                    else
                    {
                        EPedidoDifusion pedido = new EPedidoDifusion();
                        pedido.tipo = "Perdida";
                        pedido.perdida = perdida;
                        pedido.fecha = DateTime.Now;
                        pedido.estado = LogicaBDEstado.buscarEstadoPorNombre("Pendiente de Aceptacion");
                        pedido.user = new EUsuario { user = Session["UsuarioLogueado"].ToString() };
                        LogicaBDPedidoDifusion.registrarPedidoDifusion(pedido);
						LogicaBDPerdida.registrarPerdida(perdida); 
                        limpiarPagina();
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Pérdida Registrada Correctamente";
                    }
                }
            }
            catch (Exception)
            {
                pnlAtento.Visible = true;
                lblError.Text = "Se produjo un error en la registración.";
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
    }
}