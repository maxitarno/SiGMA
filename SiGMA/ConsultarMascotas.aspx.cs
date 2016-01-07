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
                Session["buscarOtro"] = 0;
                Session["imagenAdopcion"] = null;
                rnvFecha.MaximumValue = DateTime.Now.ToShortDateString();
                if (Session["UsuarioLogueado"] != null)
                {
                    String mod = Request.QueryString["m"];
                    if (mod == "1")
                    {
                        lblTitulo.Text = "Modificar Mascotas /";
                        btnModificar.Visible = true;
                    }
                    else
                    {
                        lblTitulo.Text = "Consultar Mascotas /";
                        btnModificar.Visible = false;
                    }
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "ConsultarMascotas.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "ConsultarMascotas.aspx"))
                    {
                        btnModificar.Visible = false;
                    }
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
                pnltxtNombreDueñio.Visible = false;
                pnlAtento.Visible = false;
                pnlbotones.Visible = false;
                pnlCorrecto.Visible = false;
                pnlDatos.Visible = false;
                pnlDatos1.Visible = false;
                pnlInfo.Visible = false;
                CargarCombos.cargarEstado(ref ddlEstado, "Mascota");
                CargarCombos.cargarCaracteresMascota(ref ddlCaracter);
                if (rbPorMascota.Checked)
                {
                    pnlfiltros.Visible = true;
                    pnlfiltros1.Visible = true;
                }
                // lo que sigue estaba afuera del postback, no se porque .. daba error cuando se hacia un autopostback
                Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                imgprvw.Width = 300;
                imgprvw.Height = 200;
            }
            pnlInfo.Visible = false;
            pnlCorrecto.Visible = false;
            pnlAtento.Visible = false;

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
                pnltxtNombreDueñio.Visible = true;
                pnlAtento.Visible = false;
                pnlbotones.Visible = false;
                pnlDatos.Visible = false;
                pnlDatos1.Visible = false;
                pnlInfo.Visible = false;
                pnlResultados.Visible = false;
                pnlfiltros.Visible = false;
                pnlfiltros1.Visible = false;
                pnlBuscar.Visible = true;
                pnlBuscarOtro.Visible = true;
            }
        }
        public void RbPorMascota(object sender, EventArgs e)
        {
            pnltxtNombreDueñio.Visible = false;
            pnlAtento.Visible = false;
            pnlbotones.Visible = false;
            pnlCorrecto.Visible = false;
            pnlDatos.Visible = false;
            pnlDatos1.Visible = false;
            pnlInfo.Visible = false;
            pnlResultados.Visible = false;
            pnlfiltros.Visible = true;
            pnlfiltros1.Visible = true;
            ddlEspecie.SelectedValue = "0";
            ddlEstado.SelectedValue = "0";
            ddlRaza.SelectedValue = "0";
            ddlSexo.SelectedValue = "0";
            ddlTratoAnimales.SelectedValue = "0";
            ddlTratoNinios.SelectedValue = "0";
            txtMascota.Text = "";
            ddlEdad.SelectedValue = "0";
            pnlBuscar.Visible = true;
            pnlBuscarOtro.Visible = true;
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
                        pnlResultados.Visible = true;
                        lstResultados.DataSource = mascotas;
                        lstResultados.DataTextField = "nombreMascota";
                        lstResultados.DataValueField = "idMascota";
                        lstResultados.DataBind();
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = false;
                        if (lstResultados.Items.Count == 1)
                        {
                            lstResultados.SelectedIndex = 0;
                            lstResultados_SelectedIndexChanged(null, null);
                        }
                }
                else
                {
                    lstResultados.Items.Clear();
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron mascotas";
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
                        pnltxtNombreDueñio.Visible = false;
                        pnlResultados.Visible = true;
                        lstResultados.DataSource = mascotas;
                        lstResultados.DataTextField = "nombreMascota";
                        lstResultados.DataValueField = "idMascota";
                        lstResultados.DataBind();
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = false;
                        if (lstResultados.Items.Count == 1)
                        {
                            lstResultados.SelectedIndex = 0;
                            lstResultados_SelectedIndexChanged(null, null);
                        }
                }
                else
                {
                    lstResultados.Items.Clear();
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron mascotas";
                    pnlAtento.Visible = false;
                    pnlCorrecto.Visible = false;
                }
            }
        }
        private void modificacion(bool p)
        {
            txtAlimentacionEspecial.Enabled = p;
            txtObservaciones.Enabled = p;
            txtAlimentacionEspecial.Enabled = p;
            txtFecha.Enabled = p;
            txtMascota.Enabled = p;
            txtCategoria.Enabled = p;
            txtCuidadoEspecial.Enabled = p;
            ddlCaracter.Enabled = p;
            ddlColor.Enabled = p;
            ddlEdad.Enabled = p;
            ddlEspecie.Enabled = p;
            ddlEstado.Enabled = p;
            ddlRaza.Enabled = p;
            ddlSexo.Enabled = p;
            ddlTratoAnimales.Enabled = p;
            ddlTratoNinios.Enabled = p;
            fuImagenMascota.Disabled = !p;
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
                Session["imagen"] = null; //Verificar para que estaba esta linea q fue comentada
                return imagen;
            }
            else
                return null;
        }
        public void BtnModificarClick(object sender, EventArgs e)
        {
            EMascota mascota = new EMascota();
            mascota.idMascota = (int)Session["idMascota"];
            pnlInfo.Visible = false;
                if(Page.IsValid){
                    if (Validaciones.verificarSoloLetras(txtMascota.Text))
                    {
                        mascota.alimentacionEspecial = txtAlimentacionEspecial.Text;
                        var fecha = DateTime.Today;
                        if (DateTime.TryParse(txtFecha.Text, out fecha))
                            mascota.fechaNacimiento = Convert.ToDateTime(txtFecha.Text);
                        else
                        {
                            mascota.fechaNacimiento = null;
                        }
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
                                    imgprvw.Width = 300;
                                    imgprvw.Height = 200;
                                    pnlCorrecto.Visible = true;
                                    lblCorrecto.Text = "Se modificó corretamente";
                                    pnlAtento.Visible = false;
                                    pnlInfo.Visible = false;
                                    if (rbPorDuenio.Checked)
                                    {
                                        pnltxtNombreDueñio.Visible = true;
                                        pnlfiltros.Visible = false;
                                        pnlfiltros1.Visible = false;
                                    }
                                    if (rbPorMascota.Checked)
                                    {
                                        pnltxtNombreDueñio.Visible = false;
                                        pnlfiltros.Visible = true;
                                        pnlfiltros1.Visible = true;
                                        ddlEspecie.SelectedValue = "0";
                                        ddlEstado.SelectedValue = "0";
                                        ddlRaza.SelectedValue = "0";
                                        ddlSexo.SelectedValue = "0";
                                        ddlTratoAnimales.SelectedValue = "0";
                                        ddlTratoNinios.SelectedValue = "0";
                                        txtMascota.Text = "";
                                        ddlEdad.SelectedValue = "0";
                                    }
                                    rbPorDuenio.Visible = true;
                                    rbPorMascota.Visible = true;
                                    pnlBuscarOtro.Visible = true;
                                    pnlDatos.Visible = false;
                                    pnlDatos1.Visible = false;
                                    pnlbotones.Visible = false;
                                    pnlBuscar.Visible = true;
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
                                pnlResultados.Visible = false;
                                pnlbotones.Visible = false;
                                txtMascota.Text = "";
                                Session["idMascota"] = 0;
                                txtNombreDueñio.Text = "";
                                if (rbPorDuenio.Checked)
                                {
                                    pnltxtNombreDueñio.Visible = true;
                                    pnlfiltros.Visible = false;
                                    pnlfiltros1.Visible = false;
                                }
                                if (rbPorMascota.Checked)
                                {
                                    pnltxtNombreDueñio.Visible = false;
                                    pnlfiltros.Visible = true;
                                    pnlfiltros1.Visible = true;
                                    ddlEspecie.SelectedValue = "0";
                                    ddlEstado.SelectedValue = "0";
                                    ddlRaza.SelectedValue = "0";
                                    ddlSexo.SelectedValue = "0";
                                    ddlTratoAnimales.SelectedValue = "0";
                                    ddlTratoNinios.SelectedValue = "0";
                                    txtMascota.Text = "";
                                    ddlEdad.SelectedValue = "0";
                                }
                                rbPorDuenio.Visible = true;
                                rbPorMascota.Visible = true;
                                pnlBuscarOtro.Visible = true;
                                pnlDatos1.Visible = false;
                                pnlDatos.Visible = false;
                                pnlBuscar.Visible = true;
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
                        pnlInfo.Visible = true;
                        lblInfo.Text = "Debe ingresar un nombre valido";
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
                        lblCorrecto.Text = "Se elimino correctamente";
                        if (rbPorDuenio.Checked)
                        {
                            pnltxtNombreDueñio.Visible = true;
                            pnlfiltros.Visible = false;
                            pnlfiltros1.Visible = false;
                        }
                        if (rbPorMascota.Checked)
                        {
                            pnltxtNombreDueñio.Visible = false;
                            pnlfiltros.Visible = true;
                            pnlfiltros1.Visible = true;
                            ddlEspecie.SelectedValue = "0";
                            ddlEstado.SelectedValue = "0";
                            ddlRaza.SelectedValue = "0";
                            ddlSexo.SelectedValue = "0";
                            ddlTratoAnimales.SelectedValue = "0";
                            ddlTratoNinios.SelectedValue = "0";
                            txtMascota.Text = "";
                            ddlEdad.SelectedValue = "0";
                        }
                        pnlDatos.Visible = false;
                        pnlDatos1.Visible = false;
                        pnlBuscar.Visible = true;
                        pnlBuscarOtro.Visible = true;
                    }
                    else
                    {
                        pnlCorrecto.Visible = false;
                        pnlInfo.Visible = false;
                        pnlAtento.Visible = true;
                        lblError.Text = "No se pudo eliminar";
                    }
                }
                rbPorDuenio.Visible = true;
                rbPorMascota.Visible = true;
                pnlBuscarOtro.Visible = true;
                pnlAtento.Visible = false;
                pnlbotones.Visible = false;
                pnlDatos.Visible = false;
                pnlDatos1.Visible = false;
                pnlInfo.Visible = false;
                pnlResultados.Visible = false;
                pnlbotones.Visible = false;
                txtMascota.Text = "";
                Session["idMascota"] = 0;
                txtNombreDueñio.Text = "";
            }
            else
            {
                pnlCorrecto.Visible = false;
                pnlInfo.Visible = true;
                pnlAtento.Visible = false;
                lblInfo.Text = "Debe seleccionar el estados de fallecido";
            }
        }
        protected void btnGenerarQR_Click(object sender, EventArgs e)
        {
            if (Session["idMascota"] != null)
            {
                Response.Redirect("~/GenerarCodigosQR.aspx");
            }
        }

        public void BtnBuscarOtroClick(object sender, EventArgs e)
        {
            modificacion(true);
            Session["buscarOtro"] = 1;
            limpiarControles();
            CargarCombos.cargarEspecies(ref ddlEspecie);
            CargarCombos.cargarComboRazas(ref ddlRaza);
        }
        private void limpiarControles()
        {
            if (rbPorDuenio.Checked)
            {
                pnltxtNombreDueñio.Visible = true;
                pnlfiltros.Visible = false;
                pnlfiltros1.Visible = false;
            }
            if (rbPorMascota.Checked)
            {
                pnltxtNombreDueñio.Visible = false;
                pnlfiltros.Visible = true;
                pnlfiltros1.Visible = true;
                ddlEspecie.SelectedValue = "0";
                ddlEstado.SelectedValue = "0";
                ddlRaza.SelectedValue = "0";
                ddlSexo.SelectedValue = "0";
                ddlTratoAnimales.SelectedValue = "0";
                ddlTratoNinios.SelectedValue = "0";
                txtMascota.Text = "";
                ddlEdad.SelectedValue = "0";
            }
            rbPorDuenio.Visible = true;
            rbPorMascota.Visible = true;
            pnlBuscarOtro.Visible = true;
            pnlBuscar.Visible = true;
            pnlDatos.Visible = false;
            pnlDatos1.Visible = false;
            pnlResultados.Visible = false;
            pnlbotones.Visible = false;
            txtMascota.Text = "";
            Session["idMascota"] = 0;
            txtNombreDueñio.Text = "";
        }
        protected void btnAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (LogicaBDRol.puedePublicarDifusion(Session["UsuarioLogueado"].ToString()))
                {
                    LogicaBDMascota.ponerEnAdopcion(Convert.ToInt32(Session["idMascota"].ToString()));
                    ddlEstado.SelectedValue = "4";
                    lblCorrecto.Text = "Mascota disponible para adopcion";
                    var tweet = new Herramientas.GestorTwitter();
                    byte[] imagen = (byte[])Session["imagen"];
                    EMascota mascota = LogicaBDMascota.BuscarMascotaPorIdMascota(Int32.Parse(Session["idMascota"].ToString()));
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
        protected void lstResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["imagen"] = null;
            EMascota mascota = new EMascota();
            ECaracterMascota caracter = new ECaracterMascota();
            ECategoriaRaza categoria = new ECategoriaRaza();
            ECuidado cuidado = new ECuidado();
            if (lstResultados.SelectedValue != "")
            {
                int idMascota = int.Parse(lstResultados.SelectedValue);
                mascota = LogicaBDMascota.BuscarMascotaPorIdMascota(idMascota);
                if (mascota != null)
                {
                    ddlEstado.SelectedValue = mascota.estado.idEstado.ToString();
                    txtAlimentacionEspecial.Text = mascota.alimentacionEspecial;
                    ddlCaracter.SelectedValue = mascota.caracter.idCaracter.ToString();
                    txtCategoria.Text = mascota.raza.CategoriaRaza.nombreCategoriaRaza;
                    txtCuidadoEspecial.Text = mascota.raza.cuidadoEspecial.descripcion;
                    txtFecha.Text = mascota.fechaNacimiento == null ? null : mascota.fechaNacimiento.Value.ToShortDateString().ToString();
                    txtMascota.Text = mascota.nombreMascota;
                    txtObservaciones.Text = mascota.observaciones;
                    if (mascota.tratoAnimal != null)
                    {
                        ddlTratoAnimales.SelectedValue = mascota.tratoAnimal == false ? "2" : "1";
                    }
                    if (mascota.tratoNiños != null)
                    {
                        ddlTratoNinios.SelectedValue = mascota.tratoNiños == false ? "2" : "1";
                    }
                    pnlBuscar.Visible = false;
                    pnlBuscarOtro.Visible = false;
                    rbPorDuenio.Visible = false;
                    rbPorMascota.Visible = false;
                    pnlDatos.Visible = true;
                    pnlDatos1.Visible = true;
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
                    if (mascota.imagen != null)
                    {
                        Session["imagen"] = mascota.imagen;
                        Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
                        imgprvw.Src = ResolveUrl("~/Handler1.ashx");
                        imgprvw.Width = 300;
                        imgprvw.Height = 200;
                    }
                    pnlfiltros.Visible = true;
                    pnlfiltros1.Visible = true;
                    pnltxtNombreDueñio.Visible = false;
                    pnlResultados.Visible = false;
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron mascota";
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                }
                pnltxtNombreDueñio.Visible = false;
                String mod = Request.QueryString["m"];
                if (mod == "1")
                {
                    modificacion(true);
                }
                else 
                {
                    modificacion(false);
                }
                chNoMostrar.Checked = mascota.noMostrar;
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe seleccionar una mascota";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }
        protected void cvEspecies_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEspecie);
        }
        protected void cvRazas_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlRaza);
        }
        protected void cvEdad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEdad);
        }
        protected void cvSexo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlSexo);
        }
        protected void cvEstado_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEstado);
        }
        protected void cvTratoAnimales_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTratoAnimales);
        }
        protected void cvTratoNinios_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlTratoNinios);
        }
        protected void cvColor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlColor);
        }
        protected void cvCaracter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlCaracter);
        }

        protected void cvMascota_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloLetras(txtMascota.Text);
        }
    }
}