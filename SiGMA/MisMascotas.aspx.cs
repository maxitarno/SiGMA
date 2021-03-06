﻿using System;
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
    public partial class MisMascotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["buscarOtro"] = 0;
                Session["imagenAdopcion"] = null;

                rnvFecha.MaximumValue = DateTime.Now.ToShortDateString();
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "ConsultarMascotas.aspx"))
                        Response.Redirect("PermisoInsuficiente.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RegistrarMascota.aspx"))
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
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlDatos.Visible = false;
                pnlDatos1.Visible = false;
                pnlbotones.Visible = false;
                CargarCombos.cargarEstado(ref ddlEstado, "Mascota");
                CargarCombos.cargarCaracteresMascota(ref ddlCaracter);
                cargasMisMascotas();
                // lo que sigue estaba afuera del postback, no se porque .. daba error cuando un commbo con autopostback se tocaba
                Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                imgprvw.Width = 400;
                imgprvw.Height = 300;
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
            }
        }

        private void cargasMisMascotas()
        {
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascota.BuscarMascotaPorIdDueño(Convert.ToInt32(Session["idDueño"].ToString()));
            if (mascotas.Count != 0)
            {
                lstResultados.Items.Clear();
                lstResultados.DataSource = mascotas;
                lstResultados.DataTextField = "nombreMascota";
                lstResultados.DataValueField = "idMascota";
                lstResultados.DataBind();
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                if (mascotas.Count == 1)
                {
                    lstResultados.SelectedIndex = 0;
                    lstResultados_SelectedIndexChanged(null, null);
                }
            }
            else
            {
                lstResultados.Items.Clear();
                pnlInfo.Visible = true;
                lblInfo.Text = "No ha registrado mascotas en SIGMA";
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
            // Comentado lo de session mascota, porque cuando venias de consultar las perdidas y entrabas acá, se te cargaba esa que no es tu mascota
            //if (Session["idMascota"] != null)
            //    mostrarMascota(Convert.ToInt32(Session["idMascota"].ToString()));
        }

        private void mostrarMascota(int idMascota)
        {
            EMascota mascota = LogicaBDMascota.BuscarMascotaPorIdMascota(idMascota);
            ECaracterMascota caracter = new ECaracterMascota();
            ECategoriaRaza categoria = new ECategoriaRaza();
            ECuidado cuidado = new ECuidado();
            if (mascota != null)
            {
                ddlEstado.SelectedValue = mascota.estado.idEstado.ToString();
                if (mascota.estado.idEstado.ToString() == "3" || mascota.estado.idEstado.ToString() == "6") //Perdida o Fallecida
                {
                    btnPerdida.Visible = false;
                    btnAdopcion.Visible = false;
                    btnQuitarAdopcion.Visible = false;
                }
                else
                {
                    btnPerdida.Visible = true;
                    btnAdopcion.Visible = true;
                    if (mascota.estado.idEstado.ToString() == "4") //En adopcion
                    {
                        btnAdopcion.Visible = false;
                        btnQuitarAdopcion.Visible = true;
                    }
                    else
                    {
                        btnAdopcion.Visible = true;
                        btnQuitarAdopcion.Visible = false;
                    }
                }
                
                txtAlimentacionEspecial.Text = mascota.alimentacionEspecial;
                ddlCaracter.SelectedValue = mascota.caracter.idCaracter.ToString();
                txtCategoria.Text = mascota.raza.CategoriaRaza.nombreCategoriaRaza;
                txtCuidadoEspecial.Text = mascota.raza.cuidadoEspecial.descripcion;
                txtFecha.Text = mascota.fechaNacimiento == null ? null : mascota.fechaNacimiento.Value.ToShortDateString().ToString();
                txtMascota.Text = mascota.nombreMascota;
                txtObservaciones.Text = mascota.observaciones;
                if (mascota.tratoAnimal != null)
                {
                    ddlTratoAnimales.SelectedValue = mascota.tratoAnimal.ToString() == "false" ? "2" : "1";
                }
                if (mascota.tratoNiños != null)
                {
                    ddlTratoNinios.SelectedValue = mascota.tratoNiños.ToString() == "false" ? "2" : "1";
                }
                pnlDatos.Visible = true;
                pnlDatos1.Visible = true;
                ddlColor.SelectedValue = mascota.color.idColor.ToString();
                ddlEdad.SelectedValue = mascota.edad.idEdad.ToString();
                ddlEspecie.SelectedValue = mascota.especie.idEspecie.ToString();
                ddlRaza_SelectedIndexChanged(null, null);
                ddlRaza.SelectedValue = mascota.raza.idRaza.ToString();
                ddlSexo.SelectedValue = mascota.sexo.ToString();
                pnlbotones.Visible = true;
                pnlInfo.Visible = false;
                Session["idMascota"] = idMascota;
                if (mascota.imagen != null)
                {
                    Session["imagen"] = mascota.imagen;
                    Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                    imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                    imgprvw.Width = 400;
                    imgprvw.Height = 300;
                }
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron mascotas";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
            chNoMostrar.Checked = mascota.noMostrar;
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
        protected void lstResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["imagen"] = null;
            Session["buscarOtro"] = 1;
            if (lstResultados.SelectedValue != "")
            {
                int idMascota = int.Parse(lstResultados.SelectedValue);
                mostrarMascota(idMascota);
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe seleccionar una mascota";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }

        protected void btnGenerarQR_Click(object sender, EventArgs e)
        {
            if (Session["idMascota"] != null)
            {
                Session["pantalla"] = "MisMascotas.aspx";
                Response.Redirect("~/GenerarCodigoQR.aspx");
            }
        }

        public byte[] ImageHandler_ObtenerImagenMascota(HttpContext context)
        {
            if (Session["imagenAdopcion"] != null && Convert.ToInt32(Session["buscarOtro"].ToString()) == 0)
            {
                var imagen = (byte[])Session["imagenAdopcion"];
                return imagen;
            }
            Session["buscarOtro"] = 0;
            if (Session["imagen"] != null)
            {
                var imagen = (byte[])Session["imagen"];
                Session["imagenAdopcion"] = (byte[])Session["imagen"]; // BORRAR GRONCHADA
                Session["imagen"] = null;
                return imagen;
            }
            else
                return null;
        }

        protected void btnQuitarAdopcion_Click(object sender, EventArgs e)
        {
            try   
            {
                if (LogicaBDMascota.QuitarDeEnAdopcion(Convert.ToInt32(Session["idMascota"].ToString())))
                {
                    ddlEstado.SelectedValue = "1";
                    mostrarMascota(Convert.ToInt32(Session["idMascota"].ToString()));
                    lblCorrecto.Text = "La mascota ya no esta en adopción";
                    pnlCorrecto.Visible = true;
                    SetFocus(pnlCorrecto);
                }
                else
                {
                    lblInfo.Text = "No se pudo quitar de adopcion. Contacte al administrador";
                    pnlInfo.Visible = true;
                    SetFocus(pnlInfo);
                }
            }
            catch (Exception)
            {
                pnlAtento.Visible = true;
                lblError.Text = "Error al quitar la mascota de adopcion. Contacte al administrador";
                SetFocus(pnlAtento);
            }
        }

        protected void btnAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (LogicaBDRol.puedePublicarDifusion(Session["UsuarioLogueado"].ToString()))
                {
                    LogicaBDMascota.ponerEnAdopcion(Convert.ToInt32(Session["idMascota"].ToString()));
                    //ddlEstado.SelectedValue = "4";
                    var tweet = new Herramientas.GestorTwitter();
                    byte[] imagen = (byte[])Session["imagen"];
                    EMascota mascota = new EMascota { 
                        raza = new ERaza { nombreRaza = ddlRaza.SelectedItem.Text }, 
                        edad = new EEdad { descripcion = ddlEdad.SelectedItem.Text }
                    };
                    if (imagen != null)
                    {
                        tweet.PublicarTweetConFoto(imagen, tweet.generarMensajeAdopcion(mascota));
                    }
                    else
                    {
                        tweet.PublicarTweetSoloTexto(tweet.generarMensajeAdopcion(mascota));
                    }
                    mostrarMascota(Convert.ToInt32(Session["idMascota"].ToString()));
                    lblCorrecto.Text = "Mascota disponible para adopcion";
                }
                else
                {
                    EPedidoDifusion pedido = new EPedidoDifusion();
                    pedido.tipo = "Adopción";
                    pedido.estado = LogicaBDEstado.buscarEstadoPorNombre("Pendiente de Aceptacion");
                    pedido.mascota = new EMascota { idMascota = Int32.Parse(Session["idMascota"].ToString()) };
                    pedido.fecha = DateTime.Now;
                    pedido.user = new EUsuario { user = Session["UsuarioLogueado"].ToString() };
                    LogicaBDPedidoDifusion.registrarPedidoDifusion(pedido);
                    mostrarMascota(Convert.ToInt32(Session["idMascota"].ToString()));
                    lblCorrecto.Text = "Pedido para poner en adopcion registrado.";
                }
                pnlCorrecto.Visible = true;
                pnlInfo.Visible = false;
                pnlAtento.Visible = false;
                SetFocus(pnlCorrecto);
            }
            catch (Exception)
            {
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = false;
                pnlAtento.Visible = true;
                lblError.Text = "Error al poner la mascota en adopcion";
                SetFocus(pnlAtento);                
            }
        }

        private void limpiarControles()
        {
            ddlEspecie.SelectedValue = "0";
            ddlEstado.SelectedValue = "0";
            ddlRaza.SelectedValue = "0";
            ddlSexo.SelectedValue = "0";
            ddlTratoAnimales.SelectedValue = "0";
            ddlTratoNinios.SelectedValue = "0";
            txtMascota.Text = "";
            ddlEdad.SelectedValue = "0";
            pnlDatos.Visible = false;
            pnlDatos1.Visible = false;
            pnlbotones.Visible = false;
            txtMascota.Text = "";
            Session["idMascota"] = 0;
            btnModificar.Visible = false;
            btnGenerarQR.Visible = false;
            btnAdopcion.Visible = false;
        }

        public void BtnModificarClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EMascota mascota = new EMascota();
                mascota.idMascota = (int)Session["idMascota"];
                pnlInfo.Visible = false;
                mascota.alimentacionEspecial = txtAlimentacionEspecial.Text;
                var fecha = DateTime.Today;
                if (DateTime.TryParse(txtFecha.Text, out fecha))
                    mascota.fechaNacimiento = DateTime.Parse(txtFecha.Text);
                else
                {
                    mascota.fechaNacimiento = null;
                }
                if (ddlTratoAnimales.SelectedValue.Equals("Si"))
                    mascota.tratoAnimal = true;
                else
                    mascota.tratoAnimal = false;
                if (ddlTratoNinios.SelectedValue.Equals("Si"))
                    mascota.tratoNiños = true;
                else
                    mascota.tratoNiños = false;
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
                mascota.noMostrar = chNoMostrar.Checked;
                if(chkFallecida.Checked == true)
                    mascota.estado.idEstado = 6; //Fallecida
                if (fuImagenMascota.PostedFile.ContentLength != 0)
                {
                    if (!GestorImagen.verificarTamaño(fuImagenMascota.PostedFile.ContentLength))
                    {
                        pnlInfo.Visible = true;
                        lblInfo.Text = "El tamaño de la imagen no debe superar 1Mb";
                        pnlCorrecto.Visible = false;
                        pnlAtento.Visible = false;
                    }
                    else
                    {
                        byte[] imagen = GestorImagen.obtenerArrayBytes(fuImagenMascota.PostedFile.InputStream, fuImagenMascota.PostedFile.ContentLength);
                        if (LogicaBDMascota.ModificarMascota(mascota, imagen))
                        {
                            Session["imagen"] = imagen;
                            Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                            imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                            imgprvw.Width = 400;
                            imgprvw.Height = 300;
                            pnlCorrecto.Visible = true;
                            lblCorrecto.Text = "Se modifico corretamente";
                            pnlAtento.Visible = false;
                            pnlInfo.Visible = false;
                            ddlEspecie.SelectedValue = "0";
                            ddlEstado.SelectedValue = "0";
                            ddlRaza.SelectedValue = "0";
                            ddlSexo.SelectedValue = "0";
                            ddlTratoAnimales.SelectedValue = "0";
                            ddlTratoNinios.SelectedValue = "0";
                            txtMascota.Text = "";
                            ddlEdad.SelectedValue = "0";
                            pnlDatos.Visible = false;
                            pnlDatos1.Visible = false;
                            pnlbotones.Visible = false;
                        }
                        else
                        {
                            pnlCorrecto.Visible = false;
                            pnlInfo.Visible = false;
                            pnlAtento.Visible = true;
                            lblError.Text = "No se pudo modificar";
                            pnlCorrecto.Visible = false;
                        }
                    }
                }
                else
                {
                    if (LogicaBDMascota.ModificarMascota(mascota, null))
                    {
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Text = "Se modifico corretamente";
                        pnlAtento.Visible = false;
                        pnlInfo.Visible = false;
                        pnlbotones.Visible = false;
                        txtMascota.Text = "";
                        Session["idMascota"] = 0;
                        ddlEspecie.SelectedValue = "0";
                        ddlEstado.SelectedValue = "0";
                        ddlRaza.SelectedValue = "0";
                        ddlSexo.SelectedValue = "0";
                        ddlTratoAnimales.SelectedValue = "0";
                        ddlTratoNinios.SelectedValue = "0";
                        txtMascota.Text = "";
                        ddlEdad.SelectedValue = "0";
                        pnlDatos.Visible = false;
                        pnlDatos1.Visible = false;
                    }
                    else
                    {
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = true;
                        lblError.Text = "No se pudo modificar";
                        pnlCorrecto.Visible = false;
                    }
                }
            }   
        }

        protected void btnPerdida_Click(object sender, EventArgs e)
        {
            EMascota mascota = new EMascota();
            mascota.idMascota = Convert.ToInt32(Session["idMascota"].ToString());
            if (Session["idMascota"] != null)
            {
                Session["pantalla"] = "MisMascotas.aspx";
                Response.Redirect("~/RegistrarPerdida.aspx");
            }
        }

        protected void btnRegistrarMascota_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistrarMascota.aspx");
        }

        protected void cvEspecie_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEspecie);
        }

        protected void cvRaza_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlRaza);
        }

        protected void cvEdad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEdad);
        }

        protected void cvTratoAnimales_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTratoAnimales);
        }

        protected void cvTratoNiños_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTratoNinios);
        }

        protected void cvColor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlColor);
        }

        protected void cvTemperamento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCaracter);
        }

        protected void cvSexo_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlSexo);
        }

        protected void cvMascota_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloLetras(txtMascota.Text);
        }
    }
}