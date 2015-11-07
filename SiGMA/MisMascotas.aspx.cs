using System;
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
                rnvFechaPerdida.MaximumValue = DateTime.Now.ToShortDateString();
                if (Session["UsuarioLogueado"] != null)
                {
                        btnModificar.Visible = true; // aca ponerlo en false y cuando seleccione del listado ponerlo en true

                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "MisMascotas.aspx"))
                        //Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "MisMascotas.aspx"))
                    { } //btnModificar.Visible = false;

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
                pnlbotones.Visible = false;
                pnlCorrecto.Visible = false;
                pnlDatos.Visible = false;
                pnlInfo.Visible = false;
                pnlmascota.Visible = false;
                pnltxtMascota.Visible = false;
                pnlfiltros.Visible = false;
                CargarCombos.cargarEstado(ref ddlEstado, "Mascota");
                CargarCombos.cargarCaracteresMascota(ref ddlCaracter);
                pnlResultados.Visible = true;
                cargasMisMascotas();
            }
            Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
            imgprvw.Src = ResolveUrl("~/Handler1.ashx");
            imgprvw.Width = 300;
            imgprvw.Height = 200;
        }

        private void cargasMisMascotas()
        {
            List<EMascota> mascotas = new List<EMascota>();
            mascotas = LogicaBDMascota.BuscarMascotaPorIdDueño(Convert.ToInt32(Session["idDueño"].ToString()));
            if (mascotas.Count != 0)
            {
                lstResultados.Items.Clear();
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
            if (Session["idMascota"] != null)
                mostrarMascota(Convert.ToInt32(Session["idMascota"].ToString()));
        }

        private void mostrarMascota(int idMascota)
        {
            EMascota mascota = new EMascota();
            ECaracterMascota caracter = new ECaracterMascota();
            ECategoriaRaza categoria = new ECategoriaRaza();
            ECuidado cuidado = new ECuidado();;
            if (LogicaBDMascota.BuscarMascota(mascota, categoria, caracter, cuidado, idMascota))
            {
                ddlEstado.SelectedValue = mascota.estado.idEstado.ToString();
                if (mascota.estado.idEstado.ToString() == "3")
                    btnPerdida.Visible = false;
                else
                    btnPerdida.Visible = true;
                txtAlimentacionEspecial.Text = mascota.alimentacionEspecial;
                ddlCaracter.SelectedValue = caracter.idCaracter.ToString();
                txtCategoria.Text = categoria.nombreCategoriaRaza;
                txtCuidadoEspecial.Text = cuidado.descripcion;
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
                pnlfiltros.Visible = true; ;
                pnlResultados.Visible = true;
                pnlNo.Visible = true;
            }
            else
            {
                pnlInfo.Visible = true;
                lblResultado2.Text = "No se encontraron mascota";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
                pnlNo.Visible = true;
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
                lblResultado2.Text = "Debe seleccionar una mascota";
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

        protected void btnAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (LogicaBDRol.puedePublicarDifusion(Session["UsuarioLogueado"].ToString()))
                {
                    LogicaBDMascota.ponerEnAdopcion(Convert.ToInt32(Session["idMascota"].ToString()));
                    ddlEstado.SelectedValue = "4";
                    lblResultado1.Text = "Mascota disponible para adopcion";
                    var tweet = new Herramientas.GestorTwitter();
                    byte[] imagen = (byte[])Session["imagen"];
                    EMascota mascota = new EMascota { raza = new ERaza { nombreRaza = ddlRaza.SelectedItem.Text }, 
                        edad = new EEdad { descripcion = ddlEdad.SelectedItem.Text } };
                    if (imagen != null)
                    {
                        tweet.PublicarTweetConFoto(imagen, tweet.generarMensajeAdopcion(mascota));
                    }
                    else
                    {
                        tweet.PublicarTweetSoloTexto(tweet.generarMensajeAdopcion(mascota));
                    }
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
                    lblResultado1.Text = "Pedido para poner en adopcion registrado.";
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
                lblResultado1.Text = "Error al poner la mascota en adopcion";
                SetFocus(pnlAtento);                
            }
        }

        private void limpiarControles()
        {
            pnltxtMascota.Visible = false;
            pnlmascota.Visible = false;
            pnlfiltros.Visible = false;
            pnltxtMascota.Visible = true;
            pnlmascota.Visible = true;
            pnlfiltros.Visible = true;
            ddlEspecie.SelectedValue = "0";
            ddlEstado.SelectedValue = "0";
            ddlRaza.SelectedValue = "0";
            ddlSexo.SelectedValue = "0";
            ddlTratoAnimales.SelectedValue = "0";
            ddlTratoNinios.SelectedValue = "0";
            txtMascota.Text = "";
            ddlEdad.SelectedValue = "0";
            pnlDatos.Visible = false;
            pnlResultados.Visible = false;
            pnlbotones.Visible = false;
            txtMascota.Text = "";
            Session["idMascota"] = 0;
            imgImagen.Visible = false;
            btnModificar.Visible = false;
            btnGenerarQR.Visible = false;
            btnAdopcion.Visible = false;
            //ibtnBuscarOtro.Visible = false;
            pnlNo.Visible = false;//modificado
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
                                                    mascota.noMostrar = chNoMostrar.Checked;//modificado
                                                    if (fuImagenMascota.PostedFile.ContentLength != 0)
                                                    {
                                                        if (!GestorImagen.verificarTamaño(fuImagenMascota.PostedFile.ContentLength))
                                                        {
                                                            pnlInfo.Visible = true;
                                                            lblResultado2.Text = "El tamaño de la imagen no debe superar 1Mb";
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
                                                                imgprvw.Width = 300;
                                                                imgprvw.Height = 200;
                                                                pnlCorrecto.Visible = true;
                                                                lblResultado1.Text = "Se modifico corretamente";
                                                                pnlAtento.Visible = false;
                                                                pnlInfo.Visible = false;
                                                                pnltxtMascota.Visible = false;
                                                                pnlmascota.Visible = false;
                                                                pnltxtMascota.Visible = true;
                                                                pnlmascota.Visible = true;
                                                                pnlfiltros.Visible = true;
                                                                ddlEspecie.SelectedValue = "0";
                                                                ddlEstado.SelectedValue = "0";
                                                                ddlRaza.SelectedValue = "0";
                                                                ddlSexo.SelectedValue = "0";
                                                                ddlTratoAnimales.SelectedValue = "0";
                                                                ddlTratoNinios.SelectedValue = "0";
                                                                txtMascota.Text = "";
                                                                ddlEdad.SelectedValue = "0";
                                                                pnlDatos.Visible = false;
                                                                pnlbotones.Visible = false;
                                                                imgImagen.Visible = false;
                                                                pnlNo.Visible = true;//modificado
                                                            }
                                                            else
                                                            {
                                                                pnlCorrecto.Visible = false;
                                                                pnlInfo.Visible = false;
                                                                pnlAtento.Visible = true;
                                                                lblResultado3.Text = "No se pudo modificar";
                                                                pnlCorrecto.Visible = false;
                                                                pnlNo.Visible = true;//modificado
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
                                                            pnlResultados.Visible = true;
                                                            pnlbotones.Visible = false;
                                                            txtMascota.Text = "";
                                                            Session["idMascota"] = 0;
                                                            imgImagen.Visible = false;
                                                            pnltxtMascota.Visible = true;
                                                            pnlmascota.Visible = true;
                                                            pnlfiltros.Visible = true;
                                                            ddlEspecie.SelectedValue = "0";
                                                            ddlEstado.SelectedValue = "0";
                                                            ddlRaza.SelectedValue = "0";
                                                            ddlSexo.SelectedValue = "0";
                                                            ddlTratoAnimales.SelectedValue = "0";
                                                            ddlTratoNinios.SelectedValue = "0";
                                                            txtMascota.Text = "";
                                                            ddlEdad.SelectedValue = "0";
                                                            pnlDatos.Visible = false;
                                                            pnlNo.Visible = false;
                                                            pnltxtMascota.Visible = false;
                                                            pnltxtMascota.Visible = false;
                                                            pnlfiltros.Visible = false;
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

        public void BtnRegresarClick(object sender, EventArgs e)
        {
            Response.Redirect("DefaultDueño.aspx");
        }

        protected void btnPerdida_Click(object sender, EventArgs e)
        {
            EMascota mascota = new EMascota();
            mascota.idMascota = (int)Session["idMascota"];
            if (Session["idMascota"] != null)
            {
                Session["pantalla"] = "MisMascotas.aspx";
                Response.Redirect("~/RegistrarPerdida.aspx");
            }
        }
    }
}