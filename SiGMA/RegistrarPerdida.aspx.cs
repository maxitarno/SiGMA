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
                        MascotasPorDueño();
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
                CargarCombos.cargarCaracteresMascota(ref ddlCaracter);
                CargarCombos.cargarBarrio(ref ddlBarrios);
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                CargarCombos.cargarCalles(ref ddlCalles);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascotas.BuscarMascotaPorMascota(txtMascota.Text);
            limpiarPagina();
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
            mascotas = LogicaBDMascotas.BuscarMascotaPorIdDueño(Convert.ToInt32(Session["IdDueño"]));
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
            calendario.Visible = true;
        }

        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaPerdida.Text = calendario.SelectedDate.ToString("d");
            calendario.Visible = false;
        }

        private void limpiarPagina() 
        {
            pnlInfo.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
            pnlRegistrarPerdida.Visible = false;
            txtFechaPerdida.Text = "";
            txtComentarios.Text = "";
            txtMapa.Text = "";
        }

        protected void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Session["imagen"] = null;
            var idMascota = Convert.ToInt32(lstMascotas.SelectedValue);
            pnlRegistrarPerdida.Visible = true;
            EMascota mascota = new EMascota();
            ECaracterMascota caracter = new ECaracterMascota();
            ECategoriaRaza categoria = new ECategoriaRaza();
            EPersona persona = new EPersona();
            EBarrio barrio = new EBarrio();
            ELocalidad localidad = new ELocalidad();
            ECalle calle = new ECalle();
            if (LogicaBDMascotas.BuscarMascotaPorIdMascota(idMascota, mascota, categoria, caracter, persona, barrio, localidad, calle))
            {
                ddlCaracter.SelectedValue = caracter.idCaracter.ToString();
                txtCategoria.Text = categoria.nombreCategoriaRaza;
                txtMascotaPerdida.Text = mascota.nombreMascota;
                if (mascota.tratoAnimal != null)
                {
                    ddlTratoAnimales.SelectedValue = mascota.tratoAnimal.ToString() == "false" ? "2" : "1";
                }
                if (mascota.tratoNiños != null)
                {
                    ddlTratoNinios.SelectedValue = mascota.tratoNiños.ToString() == "false" ? "2" : "1";
                }
                txtNroCalle.Text = mascota.duenio.nroCalle.ToString();
                txtDatosDueño.Text = (mascota.duenio.nombre == null) ? null : mascota.duenio.nombre.ToString();
                txtDatosDueño.Text += (mascota.duenio.apellido == null) ? null : mascota.duenio.apellido.ToString();
                ddlCalles.SelectedValue = calle.idCalle.ToString();
                ddlBarrios.SelectedValue = mascota.duenio.barrio.idBarrio.ToString();
                ddlLocalidades.SelectedValue = mascota.duenio.barrio.localidad.idLocalidad.ToString();
                ddlColor.SelectedValue = mascota.color.idColor.ToString();
                ddlEdad.SelectedValue = mascota.edad.idEdad.ToString();
                ddlEspecie.SelectedValue = mascota.especie.idEspecie.ToString();
                ddlRaza.SelectedValue = mascota.raza.idRaza.ToString();
                ddlSexo.SelectedValue = mascota.sexo.ToString();
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

            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontro la mascota";
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
                    perdida.barrio = new EBarrio();
                    perdida.barrio.idBarrio = Convert.ToInt32(ddlBarrios.SelectedValue);
                    perdida.usuario = new EUsuario();
                    perdida.usuario.user = Session["UsuarioLogueado"].ToString();
                    perdida.fecha = Convert.ToDateTime(txtFechaPerdida.Text);
                    perdida.comentarios = txtComentarios.Text;
                    perdida.mapaPerdida = txtMapa.Text;
                    if (LogicaBDMascotas.registrarPerdida(perdida))
                    {
                        limpiarPagina();
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Pérdida Registrada Correctamente";
                    }
                    else
                    {
                        pnlAtento.Visible = true;
                        lblError.Text = "No se registro la pérdida. Verifique datos";
                    }
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

    }
}