using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using Herramientas;
namespace SiGMA
{
    public partial class ConsultarMascotasaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarColor(ref ddlColor);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarEspecies(ref ddlEspecie);
                CargarCombos.cargarComboRazas(ref ddlRaza);
                    pnlNombre.Visible = false;
                    pnltxtNombreDueñio.Visible = false;
                    pnlboton.Visible = true;
                    pnlAtento.Visible = false;
                    pnlbotones.Visible = false;
                    pnlbtnSeleccionar.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlDatos.Visible = false;
                    pnlInfo.Visible = false;
                    pnlmascota.Visible = true;
                    pnltxtMascota.Visible = true;
                    CargarCombos.cargarEstado(ref ddlEstado);
                    CargarCombos.cargarCaracteresMascota(ref ddlCaracter);
            }
        }
        public void ddlRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ERaza> razas = new List<ERaza>();
            int aux = int.Parse(ddlEspecie.SelectedValue);
            razas = Datos.BuscarRazas(aux);
            ddlRaza.DataSource = razas;
            ddlRaza.DataTextField = "nombreRaza";
            ddlRaza.DataValueField = "idRaza";
            ddlRaza.DataBind();
        }
        public void RbPorDuenio(object sender, EventArgs e)
        {
            if (rbPorDuenio.Checked)
            {
                pnlNombre.Visible = true;
                pnltxtNombreDueñio.Visible = true;
                pnlboton.Visible = true;
                pnlAtento.Visible = false;
                pnlbotones.Visible = false;
                pnlbtnSeleccionar.Visible = false;
                pnlCorrecto.Visible = false;
                pnlDatos.Visible = false;
                pnlInfo.Visible = false;
                pnlmascota.Visible = false;
                pnltxtMascota.Visible = false;
                pnlResultados.Visible = false;
            }
        }
        public void RbPorMascota(object sender, EventArgs e){
            pnlNombre.Visible = false;
            pnltxtNombreDueñio.Visible = false;
            pnlboton.Visible = true;
            pnlAtento.Visible = false;
            pnlbotones.Visible = false;
            pnlbtnSeleccionar.Visible = false;
            pnlCorrecto.Visible = false;
            pnlDatos.Visible = false;
            pnlInfo.Visible = false;
            pnlmascota.Visible = true;
            pnltxtMascota.Visible = true;
            pnlResultados.Visible = false;
       }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            List<EMascota> mascotas = new List<EMascota>();
            if (rbPorDuenio.Checked)
            {
                mascotas = LogicaBDMascotas.BuscarMascotaPorduenio(txtNombreDueñio.Text);
                if (mascotas.Count != 0)
                {
                    pnlbtnSeleccionar.Visible = true;
                    pnlResultados.Visible = true;
                    lstResultados.DataSource = mascotas;
                    lstResultados.DataTextField = "nombreMascota";
                    lstResultados.DataValueField = "idMascota";
                    lstResultados.DataBind();
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron mascotas";
                }
            }
            else if (rbPorMascota.Checked)
            {
                mascotas = LogicaBDMascotas.BuscarMascotaPorMascota(txtMascota.Text);
                if (mascotas.Count != 0)
                {
                    pnlbtnSeleccionar.Visible = true;
                    pnlResultados.Visible = true;
                    lstResultados.DataSource = mascotas;
                    lstResultados.DataTextField = "nombreMascota";
                    lstResultados.DataValueField = "idMascota";
                    lstResultados.DataBind();
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron mascotas";
                }
            }
        }
        public void BtnSeleccionarClick(object sender, EventArgs e)
        {
            EMascota mascota = new EMascota();
            EPersona persona = new EPersona();
            ECaracterMascota caracter = new ECaracterMascota();
            ECategoriaRaza categoria = new ECategoriaRaza();
            ECuidado cuidado = new ECuidado();
            if (lstResultados.SelectedValue != "")
            {
                int idMascota = int.Parse(lstResultados.SelectedValue);
                if (LogicaBDMascotas.BuscarMascotaPorDuenio(persona, mascota, categoria, caracter, cuidado, idMascota))
                {
                    ddlEstado.SelectedValue = mascota.idEstado.ToString();
                    txtAlimentacionEspecial.Text = mascota.alimetaionEspeial;
                    ddlCaracter.SelectedValue = caracter.idCaracter.ToString();
                    txtCategoria.Text = categoria.nombreCategoriaRaza;
                    txtCuidadoEspecial.Text = cuidado.descripcion;
                    txtFecha.Text = mascota.fechaNcimiento.ToShortDateString().ToString();
                    txtMascota.Text = mascota.nombreMascota;
                    txtNombreDueñio.Text = persona.nombre;
                    txtObservaciones.Text = mascota.observaciones;
                    ddlTratoAnimales.SelectedValue = mascota.tratoAnimal;
                    ddlTratoNinios.SelectedValue = mascota.tratoNiños;
                    pnlDatos.Visible = true;
                    ddlColor.SelectedValue = mascota.idColor.ToString();
                    ddlEdad.SelectedValue = mascota.idEdad.ToString();
                    ddlEspecie.SelectedValue = mascota.idEspecie.ToString();
                    ddlRaza.SelectedValue = mascota.idRaza.ToString();
                    ddlSexo.SelectedValue = mascota.sexo.ToString().ToUpper();
                    pnlbotones.Visible = true;
                    pnlInfo.Visible = false;
                    Session["idMAscota"] = idMascota;
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron mascota";
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                }
            }
            else
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar una mascota";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }
        public void BtnModificarClick(object sender, EventArgs e){
            EMascota mascota = new EMascota();
            mascota.idMascota = (int)Session["idMascota"];
            DateTime fecha = new DateTime();
            if(Validaciones.Fecha(txtFecha.Text, out fecha)){
                mascota.alimetaionEspeial = txtAlimentacionEspecial.Text;
                mascota.fechaNcimiento = DateTime.Parse(txtFecha.Text);
                mascota.tratoNiños = ddlTratoNinios.SelectedValue.ToString();
                mascota.tratoAnimal = ddlTratoAnimales.SelectedValue.ToString();
                mascota.sexo = ddlSexo.SelectedValue.ToString();
                mascota.observaciones = txtObservaciones.Text;
                mascota.nombreMascota = txtMascota.Text;
                mascota.idRaza = int.Parse(ddlRaza.SelectedValue);
                mascota.idEstado = int.Parse(ddlEstado.SelectedValue);
                mascota.idEspecie = int.Parse(ddlEspecie.SelectedValue);
                mascota.idEdad = int.Parse(ddlEdad.SelectedValue);
                mascota.idColor = int.Parse(ddlColor.SelectedValue);
                mascota.idcaracter = int.Parse(ddlCaracter.SelectedValue);
                if (LogicaBDMascotas.ModificarMascota(mascota))
                {
                    pnlCorrecto.Visible = true;
                    lblResultado1.Text = "Se modifico corretamente";
                    pnlAtento.Visible = false;
                    pnlInfo.Visible = false;
                }
                else
                {
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    pnlAtento.Visible = true;
                    lblResultado3.Text = "No se pudo modificar";
                    pnlCorrecto.Visible = false;
                }
            }
            else
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe ingresar una fecha";
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }
    }
}