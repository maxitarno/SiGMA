using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
using Herramientas;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
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
            pnlInfo.Visible = false;
            pnlAtento.Visible = false;
            pnlCorrecto.Visible = false;
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
                imgImagen.Visible = false;
            }
        }
        public void RbPorMascota(object sender, EventArgs e)
        {
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
            imgImagen.Visible = false;
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            List<EMascota> mascotas = new List<EMascota>();
            if (rbPorDuenio.Checked)
            {
                mascotas = LogicaBDMascotas.BuscarMascotaPorduenio(txtNombreDueñio.Text);
                if (mascotas.Count != 0)
                {
                    pnlNombre.Visible = false;
                    pnltxtNombreDueñio.Visible = false;
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
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                }
            }
            else if (rbPorMascota.Checked)
            {
                mascotas = LogicaBDMascotas.BuscarMascotaPorMascota(txtMascota.Text);
                if (mascotas.Count != 0)
                {
                    pnlNombre.Visible = false;
                    pnltxtNombreDueñio.Visible = false;
                    pnlbtnSeleccionar.Visible = true;
                    pnlResultados.Visible = true;
                    lstResultados.DataSource = mascotas;
                    lstResultados.DataTextField = "nombreMascota";
                    lstResultados.DataValueField = "idMascota";
                    lstResultados.DataBind();
                    pnlNombre.Visible = false;
                    pnltxtNombreDueñio.Visible = false;
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron mascotas";
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
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
                if (LogicaBDMascotas.BuscarMascota(mascota, categoria, caracter, cuidado, idMascota))
                {
                    ddlEstado.SelectedValue = mascota.estado.idEstado.ToString();
                    txtAlimentacionEspecial.Text = mascota.alimentacionEspecial;
                    ddlCaracter.SelectedValue = caracter.idCaracter.ToString();
                    txtCategoria.Text = categoria.nombreCategoriaRaza;
                    txtCuidadoEspecial.Text = cuidado.descripcion;
                    txtFecha.Text = mascota.fechaNacimiento.ToShortDateString().ToString();
                    txtMascota.Text = mascota.nombreMascota;
                    txtObservaciones.Text = mascota.observaciones;
                    ddlTratoAnimales.SelectedValue = mascota.tratoAnimal;
                    ddlTratoNinios.SelectedValue = mascota.tratoNiños;
                    pnlDatos.Visible = true;
                    ddlColor.SelectedValue = mascota.color.idColor.ToString();
                    ddlEdad.SelectedValue = mascota.edad.idEdad.ToString();
                    ddlEspecie.SelectedValue = mascota.especie.idEspecie.ToString();
                    ddlRaza.SelectedValue = mascota.raza.idRaza.ToString();
                    ddlSexo.SelectedValue = mascota.sexo.ToString().ToUpper();
                    pnlbotones.Visible = true;
                    pnlInfo.Visible = false;
                    Session["idMAscota"] = idMascota;
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    pnlmascota.Visible = true;
                    pnltxtMascota.Visible = true;
                    Session["imagen"] = mascota.imagen;
                    imgImagen.Visible = true;
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
        public void BtnModificarClick(object sender, EventArgs e)
        {
            EMascota mascota = new EMascota();
            mascota.idMascota = (int)Session["idMascota"];
            DateTime fecha = new DateTime();
            if (ddlCaracter.SelectedValue.Equals("0") || ddlColor.SelectedValue.Equals("0") || ddlEdad.SelectedValue.Equals("0") || ddlEspecie.SelectedValue.Equals("0") || ddlEstado.SelectedValue.Equals("0") || ddlRaza.SelectedValue.Equals("0") || ddlSexo.SelectedValue.Equals("0") || ddlTratoAnimales.SelectedValue.Equals("0") || ddlTratoNinios.SelectedValue.Equals("0"))
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar una opción";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
            else
            {
                pnlInfo.Visible = false;
                if (Validaciones.Fecha(txtFecha.Text, out fecha))
                {
                    mascota.alimentacionEspecial = txtAlimentacionEspecial.Text;
                    mascota.fechaNacimiento = DateTime.Parse(txtFecha.Text);
                    mascota.tratoNiños = ddlTratoNinios.SelectedValue.ToString();
                    mascota.tratoAnimal = ddlTratoAnimales.SelectedValue.ToString();
                    mascota.sexo = ddlSexo.SelectedValue.ToString();
                    mascota.observaciones = txtObservaciones.Text;
                    mascota.nombreMascota = txtMascota.Text;
                    mascota.raza = new ERaza();
                    mascota.raza.idRaza = int.Parse(ddlRaza.SelectedValue);
                    mascota.estado = new EEstado();
                    mascota.estado.idEstado = int.Parse(ddlEstado.SelectedValue);
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = int.Parse(ddlEspecie.SelectedValue);
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = int.Parse(ddlEdad.SelectedValue);
                    mascota.color = new EColor();
                    mascota.color.idColor = int.Parse(ddlColor.SelectedValue);
                    mascota.caracter = new ECaracterMascota();
                    mascota.caracter.idCaracter = int.Parse(ddlCaracter.SelectedValue);
                    if(fuImagen.PostedFile.ContentLength != 0){
                        if (!GestorImagen.verificarTamaño(fuImagen.PostedFile.ContentLength))
                        {
                            pnlInfo.Visible = true;
                            lblResultado2.Text = "El tamaño de la imagen no debe superar 1Mb";
                        }
                        else
                        {
                            byte[] imagen = GestorImagen.obtenerArrayBytes(fuImagen.PostedFile.InputStream, fuImagen.PostedFile.ContentLength);
                            if (LogicaBDMascotas.ModificarMascota(mascota, imagen))
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
                    }
                    else{
                        if (LogicaBDMascotas.ModificarMascota(mascota, null))
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
        public void BtnEliminarClick(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedValue == "6")
            {
                if ((int)Session["idMascota"] != 0)
                {
                    if (LogicaBDMascotas.Eliminar((int)Session["idMascota"]))
                    {
                        pnlCorrecto.Visible = true;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = false;
                        lblResultado1.Text = "Se elimino correctamente";
                    }
                    else
                    {
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = true;
                        lblResultado3.Text = "No se puedo eliminar";
                    }
                }
                pnlAtento.Visible = false;
                pnlbotones.Visible = false;
                pnlbtnSeleccionar.Visible = false;
                pnlDatos.Visible = false;
                pnlInfo.Visible = false;
                pnlResultados.Visible = false;
                pnlbotones.Visible = false;
                txtMascota.Text = "";
                Session["idMascota"] = 0;
                txtNombreDueñio.Text = "";
                imgImagen.Visible = false;
            }
            else
            {
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlAtento.Visible = true;
                lblResultado3.Text = "No se puedo eliminar";
            }
        }
        public void BtnLimpiarClick(object sender, EventArgs e)
        {
            pnlAtento.Visible = false;
            pnlbotones.Visible = false;
            pnlbtnSeleccionar.Visible = false;
            pnlCorrecto.Visible = false;
            pnlDatos.Visible = false;
            pnlInfo.Visible = false;
            pnlResultados.Visible = false;
            pnlbotones.Visible = false;
            txtMascota.Text = "";
            Session["idMascota"] = 0;
            txtNombreDueñio.Text = "";
            imgImagen.Visible = false;
        }
        public void BtnMostrarImagen(object sender, EventArgs e)
        {
            if (Session["imagen"] != null)
            {
                Response.Redirect("imagenes.aspx");
            }
        }
    }
}