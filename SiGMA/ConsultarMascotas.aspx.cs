﻿using System;
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
        protected void imgFechaPerdida_click(object sender, ImageClickEventArgs e)
        {
            calendario.Visible = true;
        }

        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = calendario.SelectedDate.ToString("d");
            calendario.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rnvFechaPerdida.MaximumValue = DateTime.Now.ToShortDateString();
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "ConsultarMascotas.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "ConsultarMascotas.aspx"))
                    {
                        btnModificar.Visible = false;
                    }
                    if (!LogicaBDRol.verificarPermisosEliminacion(Session["UsuarioLogueado"].ToString(), "ConsultarMascotas.aspx"))
                        btnEliminar.Visible = false;
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
                if (rbPorMascota.Checked)
                {
                    pnlfiltros.Visible = true;
                }
                String mod = Request.QueryString["m"];
                if (mod == "1")
                {
                    lblTitulo.Text = "Modificar Mascota";
                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                }
                else
                {
                    lblTitulo.Text = "Consultar Mascota";
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                }
            }
        }
        public void ddlRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ERaza> razas = new List<ERaza>();
            if (!ddlEspecie.SelectedValue.Equals("0"))
            {
                int aux = int.Parse(ddlEspecie.SelectedValue);
                CargarCombos.cargarRazas(ref ddlRaza, aux);
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
            else
            {
                CargarCombos.cargarComboRazas(ref ddlRaza);
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
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
                pnlfiltros.Visible = false;
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
            pnlfiltros.Visible = true;
            ddlEspecie.SelectedValue = "0";
            ddlEstado.SelectedValue = "0";
            ddlRaza.SelectedValue = "0";
            ddlSexo.SelectedValue = "0";
            ddlTratoAnimales.SelectedValue = "0";
            ddlTratoNinios.SelectedValue = "0";
            txtMascota.Text = "";
            ddlEdad.SelectedValue = "0";
        }
        public void BtnBuscarClick(object sender, EventArgs e)
        {
            List<EMascota> mascotas = new List<EMascota>();
            lstResultados.Items.Clear();
            if (rbPorDuenio.Checked)
            {
                mascotas = LogicaBDMascota.BuscarMascotaPorduenio(txtNombreDueñio.Text);
                if (mascotas.Count != 0)
                {
                    lstResultados.Items.Clear();
                    pnlbtnSeleccionar.Visible = true;
                    pnlResultados.Visible = true;
                    lstResultados.DataSource = mascotas;
                    lstResultados.DataTextField = "nombreMascota";
                    lstResultados.DataValueField = "idMascota";
                    lstResultados.DataBind();
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    pnlAtento.Visible = false;
                }
                else
                {
                    lstResultados.Items.Clear();
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron mascotas";
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                }
            }
            else if (rbPorMascota.Checked)
            {
                EMascota mascota = new EMascota();
                if (!ddlEdad.SelectedValue.Equals("0"))
                {
                    mascota.edad = new EEdad();
                    mascota.edad.nombreEdad = ddlEdad.SelectedItem.Text;
                    mascota.edad.idEdad = int.Parse(ddlEdad.SelectedValue);
                }
                if (!ddlEspecie.SelectedValue.Equals("0"))
                {
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = int.Parse(ddlEspecie.SelectedValue);
                    mascota.especie.nombreEspecie = ddlEspecie.SelectedItem.Text;
                }
                if (!ddlRaza.SelectedValue.Equals("") && !ddlRaza.SelectedValue.Equals("0"))
                {
                    mascota.raza = new ERaza();
                    mascota.raza.nombreRaza = ddlRaza.SelectedItem.Text;
                    mascota.raza.idRaza = int.Parse(ddlRaza.SelectedValue);
                }
                if (!ddlSexo.SelectedValue.Equals("0"))
                {
                    mascota.sexo = ddlSexo.SelectedItem.Text;
                }
                else
                {
                    mascota.sexo = null;
                }
                if (!ddlTratoAnimales.SelectedValue.Equals("0"))
                {
                    mascota.tratoAnimal = true;
                }
                if (!ddlTratoNinios.SelectedValue.Equals("0"))
                {
                    mascota.tratoNiños = true;
                }
                if (!ddlEstado.SelectedValue.Equals("0"))
                {
                    mascota.estado = new EEstado();
                    mascota.estado.nombreEstado = ddlEstado.SelectedItem.Text;
                    mascota.estado.idEstado = int.Parse(ddlEstado.SelectedValue);
                }
                mascota.nombreMascota = txtMascota.Text;
                mascotas = LogicaBDMascota.buscarMascotasFiltros(mascota);
                if (mascotas != null)
                {
                    lstResultados.Items.Clear();
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
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    pnlAtento.Visible = false;
                }
                else
                {
                    lstResultados.Items.Clear();
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron mascotas";
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                }
            }
        }
        public void BtnSeleccionarClick(object sender, EventArgs e)
        {
            Session["imagen"] = null;
            EMascota mascota = new EMascota();            
            ECaracterMascota caracter = new ECaracterMascota();
            ECategoriaRaza categoria = new ECategoriaRaza();
            ECuidado cuidado = new ECuidado();
            if (lstResultados.SelectedValue != "")
            {
                int idMascota = int.Parse(lstResultados.SelectedValue);
                if (LogicaBDMascota.BuscarMascota(mascota, categoria, caracter, cuidado, idMascota))
                {
                    ddlEstado.SelectedValue = mascota.estado.idEstado.ToString();
                    txtAlimentacionEspecial.Text = mascota.alimentacionEspecial;
                    ddlCaracter.SelectedValue = caracter.idCaracter.ToString();
                    txtCategoria.Text = categoria.nombreCategoriaRaza;
                    txtCuidadoEspecial.Text = cuidado.descripcion;
                    txtFecha.Text = mascota.fechaNacimiento.ToShortDateString().ToString();
                    txtMascota.Text = mascota.nombreMascota;
                    txtObservaciones.Text = mascota.observaciones;
                    if(mascota.tratoAnimal != null)
                    {
                        ddlTratoAnimales.SelectedValue = mascota.tratoAnimal.ToString() == "false" ? "2" : "1";
                    }
                    if (mascota.tratoNiños != null) 
                    {
                        ddlTratoNinios.SelectedValue = mascota.tratoNiños.ToString() == "false" ? "2" : "1";
                    }
                    pnlDatos.Visible = true;
                    ddlColor.SelectedValue = mascota.color.idColor.ToString();
                    ddlEdad.SelectedValue = mascota.edad.idEdad.ToString();
                    ddlEspecie.SelectedValue = mascota.especie.idEspecie.ToString();
                    ddlRaza.SelectedValue = mascota.raza.idRaza.ToString();
                    ddlSexo.SelectedValue = mascota.sexo.ToString();
                    pnlbotones.Visible = true;
                    pnlInfo.Visible = false;
                    Session["idMascota"] = idMascota;
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = false;
                    pnlmascota.Visible = true;
                    pnltxtMascota.Visible = true;
                    if (mascota.imagen != null) 
                    {
                        Session["imagen"] = mascota.imagen;
                        Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                        imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                        imgprvw.Width = 300;
                        imgprvw.Height = 200;
                    }
                    imgImagen.Visible = true;
                    pnlfiltros.Visible = true;
                    pnlNombre.Visible = false;
                    pnltxtNombreDueñio.Visible = false;
                    pnlboton.Visible = false;
                    pnlResultados.Visible = false;
                    pnlbtnSeleccionar.Visible = false;
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "No se encontraron mascota";
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                }
                pnltxtNombreDueñio.Visible = false;
                pnlNombre.Visible = false;
            }
            else
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar una mascota";
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

        public void BtnModificarClick(object sender, EventArgs e)
        {
            EMascota mascota = new EMascota();
            mascota.idMascota = (int)Session["idMascota"];
            DateTime fecha = new DateTime();
            if (ddlCaracter.SelectedValue.Equals("0"))
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "Debe seleccionar una caracter";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
            else
            {
                pnlInfo.Visible = false;
                if (!ddlColor.SelectedValue.Equals("0"))
                {
                    if (!ddlEdad.SelectedValue.Equals("0"))
                    {
                        if (!ddlEspecie.SelectedValue.Equals("0"))
                        {
                            if (!ddlEstado.SelectedValue.Equals("0"))
                            {
                                if (!ddlRaza.SelectedValue.Equals("0"))
                                {
                                    if (!ddlSexo.SelectedValue.Equals("0"))
                                    {
                                        if (!ddlTratoNinios.SelectedValue.Equals("0") && !ddlTratoAnimales.SelectedValue.Equals("0"))
                                        {
                                            if (Validaciones.Fecha(txtFecha.Text, out fecha))
                                            {
                                                if (Validaciones.verificarSoloLetras(txtMascota.Text))
                                                {
                                                    mascota.alimentacionEspecial = txtAlimentacionEspecial.Text;
                                                    mascota.fechaNacimiento = DateTime.Parse(txtFecha.Text);
                                                    if (ddlTratoAnimales.SelectedValue.Equals("Si"))
                                                    {
                                                        mascota.tratoAnimal = true;
                                                    }
                                                    else
                                                    {
                                                        mascota.tratoAnimal = false;
                                                    }
                                                    if (ddlTratoNinios.SelectedValue.Equals("Si"))
                                                    {
                                                        mascota.tratoNiños = true;
                                                    }
                                                    else
                                                    {
                                                        mascota.tratoNiños = false;
                                                    }
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
                                                    if (File1.PostedFile.ContentLength != 0)
                                                    {
                                                        if (!GestorImagen.verificarTamaño(File1.PostedFile.ContentLength))
                                                        {
                                                            pnlInfo.Visible = true;
                                                            lblResultado2.Text = "El tamaño de la imagen no debe superar 1Mb";
                                                            pnlCorrecto.Visible = false;
                                                            pnlAtento.Visible = false;
                                                        }
                                                        else
                                                        {
                                                            byte[] imagen = GestorImagen.obtenerArrayBytes(File1.PostedFile.InputStream, File1.PostedFile.ContentLength);
                                                            if (LogicaBDMascota.ModificarMascota(mascota, imagen))
                                                            {
                                                                Session["imagen"] = imagen;
                                                                Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                                                                imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                                                                imgprvw.Width = 300;
                                                                imgprvw.Height = 200;
                                                                pnlCorrecto.Visible = true;
                                                                lblResultado1.Text = "Se modifico corretamente";
                                                                pnlAtento.Visible = false;
                                                                pnlInfo.Visible = false;
                                                                if (rbPorDuenio.Checked)
                                                                {
                                                                    pnltxtNombreDueñio.Visible = true;
                                                                    pnlNombre.Visible = true;
                                                                    pnltxtMascota.Visible = false;
                                                                    pnlmascota.Visible = false;
                                                                    pnlfiltros.Visible = false;
                                                                }
                                                                if (rbPorMascota.Checked)
                                                                {
                                                                    pnltxtMascota.Visible = true;
                                                                    pnlmascota.Visible = true;
                                                                    pnltxtNombreDueñio.Visible = false;
                                                                    pnlNombre.Visible = false;
                                                                    pnlfiltros.Visible = true;
                                                                    ddlEspecie.SelectedValue = "0";
                                                                    ddlEstado.SelectedValue = "0";
                                                                    ddlRaza.SelectedValue = "0";
                                                                    ddlSexo.SelectedValue = "0";
                                                                    ddlTratoAnimales.SelectedValue = "0";
                                                                    ddlTratoNinios.SelectedValue = "0";
                                                                    txtMascota.Text = "";
                                                                    ddlEdad.SelectedValue = "0";
                                                                }
                                                                pnlboton.Visible = true;
                                                                pnlDatos.Visible = false;
                                                                pnlbotones.Visible = false;
                                                                imgImagen.Visible = false;
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
                                                        if (LogicaBDMascota.ModificarMascota(mascota, null))
                                                        {
                                                            pnlCorrecto.Visible = true;
                                                            lblResultado1.Text = "Se modifico corretamente";
                                                            pnlAtento.Visible = false;
                                                            pnlInfo.Visible = false;
                                                            pnlResultados.Visible = false;
                                                            pnlbotones.Visible = false;
                                                            txtMascota.Text = "";
                                                            Session["idMascota"] = 0;
                                                            txtNombreDueñio.Text = "";
                                                            imgImagen.Visible = false;
                                                            if (rbPorDuenio.Checked)
                                                            {
                                                                pnltxtNombreDueñio.Visible = true;
                                                                pnlNombre.Visible = true;
                                                                pnltxtMascota.Visible = false;
                                                                pnlmascota.Visible = false;
                                                                pnlfiltros.Visible = false;
                                                            }
                                                            if (rbPorMascota.Checked)
                                                            {
                                                                pnltxtMascota.Visible = true;
                                                                pnlmascota.Visible = true;
                                                                pnltxtNombreDueñio.Visible = false;
                                                                pnlNombre.Visible = false;
                                                                pnlfiltros.Visible = true;
                                                                ddlEspecie.SelectedValue = "0";
                                                                ddlEstado.SelectedValue = "0";
                                                                ddlRaza.SelectedValue = "0";
                                                                ddlSexo.SelectedValue = "0";
                                                                ddlTratoAnimales.SelectedValue = "0";
                                                                ddlTratoNinios.SelectedValue = "0";
                                                                txtMascota.Text = "";
                                                                ddlEdad.SelectedValue = "0";
                                                            }
                                                            pnlboton.Visible = true;
                                                            pnlDatos.Visible = false;
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
                                                    lblResultado2.Text = "Debe ingresar un nombre valido";
                                                    pnlCorrecto.Visible = false;
                                                    pnlAtento.Visible = false;
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
                                        else
                                        {
                                            pnlInfo.Visible = true;
                                            lblResultado2.Text = "Debe seleccionar un trato";
                                            pnlCorrecto.Visible = false;
                                            pnlAtento.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        pnlInfo.Visible = true;
                                        lblResultado2.Text = "Debe seleccionar un sexo";
                                        pnlCorrecto.Visible = false;
                                        pnlAtento.Visible = false;
                                    }
                                }
                                else
                                {
                                    pnlInfo.Visible = true;
                                    lblResultado2.Text = "Debe seleccionar un raza";
                                    pnlCorrecto.Visible = false;
                                    pnlAtento.Visible = false;
                                }
                            }
                            else
                            {
                                pnlInfo.Visible = true;
                                lblResultado2.Text = "Debe seleccionar un estado";
                                pnlCorrecto.Visible = false;
                                pnlAtento.Visible = false;
                            }
                        }
                        else
                        {
                            pnlInfo.Visible = true;
                            lblResultado2.Text = "Debe seleccionar un especie";
                            pnlCorrecto.Visible = false;
                            pnlAtento.Visible = false;
                        }
                    }
                    else
                    {
                        pnlInfo.Visible = true;
                        pnlCorrecto.Visible = false;
                        pnlAtento.Visible = false;
                        lblResultado2.Text = "Debe seleccionar una edad";
                    }
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblResultado2.Text = "Debe seleccionar un color";
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                }
            }
        }
        public void BtnEliminarClick(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedValue == "6")
            {
                if ((int)Session["idMascota"] != 0)
                {
                    if (LogicaBDMascota.Eliminar((int)Session["idMascota"]))
                    {
                        pnlCorrecto.Visible = true;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = false;
                        lblResultado1.Text = "Se elimino correctamente";
                        if (rbPorDuenio.Checked)
                        {
                            pnltxtNombreDueñio.Visible = true;
                            pnlNombre.Visible = true;
                            pnltxtMascota.Visible = false;
                            pnlmascota.Visible = false;
                            pnlfiltros.Visible = false;
                        }
                        if (rbPorMascota.Checked)
                        {
                            pnltxtMascota.Visible = true;
                            pnlmascota.Visible = true;
                            pnltxtNombreDueñio.Visible = false;
                            pnlNombre.Visible = false;
                            pnlfiltros.Visible = true;
                            ddlEspecie.SelectedValue = "0";
                            ddlEstado.SelectedValue = "0";
                            ddlRaza.SelectedValue = "0";
                            ddlSexo.SelectedValue = "0";
                            ddlTratoAnimales.SelectedValue = "0";
                            ddlTratoNinios.SelectedValue = "0";
                            txtMascota.Text = "";
                            ddlEdad.SelectedValue = "0";
                        }
                        pnlboton.Visible = false;
                        pnlDatos.Visible = false;
                        pnlboton.Visible = false;
                    }
                    else
                    {
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = true;
                        lblResultado3.Text = "No se pudo eliminar";
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
                lblResultado3.Text = "Debe seleccionar el estados de fallecido";
            }
        }
        
        protected void btnGenerarQR_Click(object sender, EventArgs e)
        {
            if (Session["idMascota"] != null)
            {
                Response.Redirect("~/GenerarCodigoQR.aspx");
            }
        }
        public void BtnRegresarClick(object sender, EventArgs e)
        {
            Response.Redirect("_Mascotas.aspx");
        }
    }
}