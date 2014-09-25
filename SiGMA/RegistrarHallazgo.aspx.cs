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
    public partial class RegistrarHallazgo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                LogicaBDMascota.buscarMascotasFiltros(new EMascota { nombreMascota = "h", estado = new EEstado { nombreEstado = "Hallada" } });
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                CargarCombos.cargarEspecies(ref ddlEspecie);
                CargarCombos.cargarComboRazas(ref ddlRaza);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarSexo(ref ddlSexo);
                CargarCombos.cargarColor(ref ddlColor);
            }
        }

        protected void rbYaPerdida_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYaPerdida.Checked)
            {
                mostrarPaneles("Perdida");
            }
            else
            {
                mostrarPaneles("Nueva");
            }
        }

        protected void rbNuevaMascota_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNuevaMascota.Checked)
            {
                mostrarPaneles("Nueva");
            }
            else
            {
                mostrarPaneles("Perdida");
            }
        }
        private void mostrarPaneles(string panel)
        {
            if (panel.Equals("Perdida"))
            {
                pnlPerdida.Visible = true;
                pnlNueva.Visible = false;
                pnlMascotaSeleccionada.Visible = false;
                pnlImagen.Visible = false;
                pnlHallazgoPerdidaMascota.Visible = false;
                pnlHallazgoPerdidaLugar.Visible = false;
                pnlImagen.Visible = false;
                cargarTablaPerdidas();
            }
            else
            {
                pnlPerdida.Visible = false;
                pnlNueva.Visible = true;
            }
        }
        private void cargarTablaPerdidas()
        {
            List<EMascota> lista = LogicaBDMascota.buscarMascotasPorEstado("Perdida");
            if(lista != null)
            {
                lstPerdidas.Items.Clear();
                foreach (var item in lista)
                {
                    ListItem li = new ListItem();
                    li.Text = item.nombreMascota;
                    li.Value = item.idMascota.ToString();
                    lstPerdidas.Items.Add(li);                    
                }                
            }
        }

        protected void lstPerdidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            EMascota mascota = LogicaBDMascota.BuscarMascotaPorIdMascota(int.Parse(lstPerdidas.SelectedValue));
            Session["MascotaPerdida"] = mascota;
            lblNombreMascotaPerdida.Text = mascota.nombreMascota;
            ddlEspecie.SelectedValue = mascota.especie.idEspecie.ToString();
            ddlRaza.SelectedValue = mascota.raza.idRaza.ToString();
            ddlColor.SelectedValue = mascota.color.idColor.ToString();
            ddlEdad.SelectedValue = mascota.edad.idEdad.ToString();
            ddlSexo.SelectedValue = mascota.sexo;
            pnlMascotaSeleccionada.Visible = true;
            pnlImagen.Visible = true;
            pnlHallazgoPerdidaMascota.Visible = true;
            pnlHallazgoPerdidaLugar.Visible = true;
            pnlImagen.Visible = true;
            Session["imagen"] = mascota.imagen;
            Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
            imgprvw.Src = ResolveUrl("~/Handler1.ashx");
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

        protected void ddlLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCombos.cargarBarrio(ref ddlBarrios, int.Parse(ddlLocalidades.SelectedValue));
            CargarCombos.cargarCalles(ref ddlCalles, int.Parse(ddlLocalidades.SelectedValue));
        }

        protected void btnRegistrarHallazgo_Click(object sender, EventArgs e)
        {
            EMascota mascota = (EMascota)Session["MascotaPerdida"];
            EPerdida perdida = LogicaBDPerdida.buscarPerdidaPorIdMascota(mascota);
            EHallazgo hallazgo = new EHallazgo();
            hallazgo.perdida = perdida;
            hallazgo.mascota = mascota;
            hallazgo.observaciones = txtComentarios.Text;
            hallazgo.fechaHallazgo = DateTime.Parse(txtFecha.Text);
            hallazgo.domicilio = new EDomicilio();
            hallazgo.domicilio.barrio = new EBarrio();
            hallazgo.domicilio.barrio.localidad = new ELocalidad();
            hallazgo.domicilio.barrio.idBarrio = int.Parse(ddlBarrios.SelectedValue);
            hallazgo.domicilio.barrio.localidad.idLocalidad = int.Parse(ddlLocalidades.SelectedValue);
            hallazgo.domicilio.numeroCalle = int.Parse(txtNroCalle.Text);
            hallazgo.usuario = new EUsuario() { user = Session["UsuarioLogueado"].ToString() };
            LogicaBDHallazgo.registrarHallazgo(hallazgo);
        }

        protected void cvCalleNumero_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtNroCalle.Text);
        }              
    }
}