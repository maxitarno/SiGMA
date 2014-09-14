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

        private void limpiarPagina() 
        {
            pnlInfo.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
        }

        protected void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var idMascota = Convert.ToInt32(lstMascotas.SelectedValue);
            pnlRegistrarPerdida.Visible = true;
            EMascota mascota = new EMascota();
            ECaracterMascota caracter = new ECaracterMascota();
            ECategoriaRaza categoria = new ECategoriaRaza();
            EPersona persona = new EPersona();
            EBarrio barrio = new EBarrio();
            ELocalidad localidad = new ELocalidad();
            if (LogicaBDMascotas.BuscarMascotaPorIdMascota(idMascota, mascota, categoria, caracter, persona, barrio, localidad))
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
                ddlColor.SelectedValue = mascota.color.idColor.ToString();
                ddlEdad.SelectedValue = mascota.edad.idEdad.ToString();
                ddlEspecie.SelectedValue = mascota.especie.idEspecie.ToString();
                ddlRaza.SelectedValue = mascota.raza.idRaza.ToString();
                ddlSexo.SelectedValue = mascota.sexo.ToString();
                Session["idMascota"] = idMascota;
                pnlImagen.Visible = true;
                if (mascota.imagen != null)
                {
                    Session["imagen"] = mascota.imagen;
                    Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                    imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                    imgprvw.Width = 300;
                    imgprvw.Height = 200;
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
                Session["imagen"] = null;
                return imagen;
            }
            else
                return null;
        }
    }
}