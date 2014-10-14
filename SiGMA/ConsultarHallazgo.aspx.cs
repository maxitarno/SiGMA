using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;
using Entidades;
using AccesoADatos;

namespace SiGMA
{
    public partial class ConsultarHallazgo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarLocalidades(ref ddlLocalidades);
                CargarCombos.cargarEspecies(ref ddlEspecie);                
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarSexo(ref ddlSexo);
                CargarCombos.cargarColor(ref ddlColor);
                CargarCombos.cargarEspecies(ref ddlFiltroEspecie);
                CargarCombos.cargarColor(ref ddlFiltroColor);
                CargarCombos.cargarSexo(ref ddlFiltroSexo);
                CargarCombos.cargarComboRazas(ref ddlRaza);
                String mod = Request.QueryString["m"];
                if (mod == "1")
                {
                    paraModificar(true);
                }
                else
                {
                    paraModificar(false);
                }
            }
        }

        private void paraModificar(bool b)
        {
            ddlLocalidades.Enabled = b;
            ddlCalles.Enabled = b;
            ddlBarrios.Enabled = b;
            txtNroCalle.Enabled = b;
            txtFecha.Enabled = b;
            txtMapa.Enabled = b;
            txtComentarios.Enabled = b;
            btnRegistrarHallazgo.Visible = b;
        }
        protected void rbYaPerdida_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbYaPerdida.Checked)
            //{
            //    mostrarPaneles("Perdida");
            //}
            //else
            //{
            //    mostrarPaneles("Nueva");
            //}
        }

        protected void rbNuevaMascota_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbNuevaMascota.Checked)
            //{
            //    mostrarPaneles("Nueva");
            //}
            //else
            //{
            //    mostrarPaneles("Perdida");
            //}
        }
        private void mostrarPaneles(string panel)
        {
            if (panel.Equals("Perdida"))
            {
                pnlFiltros.Visible = true;                
                pnlMascotaSeleccionada.Visible = false;
                pnlImagen.Visible = false;
                pnlHallazgoPerdidaMascota.Visible = false;                
                lstPerdidas.Visible = false;
                txtNombreMascota.Enabled = false;
                ddlEspecie.Enabled = false;
                ddlRaza.Enabled = false;
                ddlEdad.Enabled = false;
                ddlSexo.Enabled = false;
                ddlColor.Enabled = false;
                pnlImagen.Visible = true;
                CargarCombos.cargarComboRazas(ref ddlRaza);
                limpiarCampos();
            }
            else
            {
                pnlFiltros.Visible = false;
                pnlMascotaSeleccionada.Visible = true;
                pnlHallazgoPerdidaMascota.Visible = true;
                pnlImagen.Visible = true;
                txtNombreMascota.Enabled = true;
                ddlEspecie.Enabled = true;
                ddlRaza.Enabled = true;
                ddlEdad.Enabled = true;
                ddlSexo.Enabled = true;
                ddlColor.Enabled = true;
                pnlImagen.Visible = false;
                ddlRaza.Items.Clear();
                limpiarCampos();
                imgprvw.Src = "~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg";
            }
            pnlCorrecto.Visible = false;
            pnlAtento.Visible = false;
        }

        private void cargarTablaHalladas()
        {
            List<EHallazgo> lista = (List<EHallazgo>)Session["Hallazgos"];
            if(lista != null)
            {
                lstPerdidas.Items.Clear();
                foreach (var item in lista)
                {
                    ListItem li = new ListItem();
                    li.Text = item.mascota.nombreMascota;
                    li.Value = item.mascota.idMascota.ToString();
                    lstPerdidas.Items.Add(li);                    
                }                
            }
            lstPerdidas.Visible = true;
        }

        protected void lstPerdidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<EHallazgo> lista = (List<EHallazgo>)Session["Hallazgos"];
            EHallazgo hallazgoSelec = null;
            foreach (var item in lista)
            {
                if (item.mascota.idMascota == int.Parse(lstPerdidas.SelectedValue))
                {
                   hallazgoSelec = item;
                   break;
                }
            }            
            Session["Hallazgo"] = hallazgoSelec;
            txtNombreMascota.Text = hallazgoSelec.mascota.nombreMascota;
            ddlEspecie.SelectedValue = hallazgoSelec.mascota.especie.idEspecie.ToString();
            ddlRaza.SelectedValue = hallazgoSelec.mascota.raza.idRaza.ToString();
            ddlColor.SelectedValue = hallazgoSelec.mascota.color.idColor.ToString();
            ddlEdad.SelectedValue = hallazgoSelec.mascota.edad.idEdad.ToString();
            ddlSexo.SelectedValue = hallazgoSelec.mascota.sexo;
            ddlLocalidades.SelectedValue = hallazgoSelec.domicilio.barrio.localidad.idLocalidad.ToString();
            CargarCombos.cargarBarrio(ref ddlBarrios, (int)hallazgoSelec.domicilio.barrio.localidad.idLocalidad);
            CargarCombos.cargarCalles(ref ddlCalles, (int)hallazgoSelec.domicilio.barrio.localidad.idLocalidad);
            ddlCalles.SelectedValue = hallazgoSelec.domicilio.calle.idCalle.ToString();
            ddlBarrios.SelectedValue = hallazgoSelec.domicilio.barrio.idBarrio.ToString();
            txtFecha.Text = hallazgoSelec.fechaHallazgo.Date.ToShortDateString();
            txtNroCalle.Text = hallazgoSelec.domicilio.numeroCalle.ToString();
            txtComentarios.Text = hallazgoSelec.observaciones;
            pnlMascotaSeleccionada.Visible = true;
            pnlImagen.Visible = true;
            pnlHallazgoPerdidaMascota.Visible = true;            
            pnlImagen.Visible = true;
            Session["imagen"] = hallazgoSelec.mascota.imagen;
            Handler1.AddMethod(ImageHandler_ObtenerImagenMascota);
            imgprvw.Src = ResolveUrl("~/Handler1.ashx");
        }        

        protected void ddlLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCombos.cargarBarrio(ref ddlBarrios, int.Parse(ddlLocalidades.SelectedValue));
            CargarCombos.cargarCalles(ref ddlCalles, int.Parse(ddlLocalidades.SelectedValue));            
        }

        protected void cvCalleNumero_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSoloNumeros(txtNroCalle.Text);
        }

        protected void ddlFiltroEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCombos.cargarRazas(ref ddlFiltroRaza, int.Parse(ddlFiltroEspecie.SelectedValue));
            pnlAtento.Visible = false;
        }

        protected void btnFiltros_Click(object sender, EventArgs e)
        {
            EMascota mascot = new EMascota();
            mascot.estado = new EEstado();
            mascot.estado.nombreEstado = "Hallada";
            bool flag = false;
            if(!ddlFiltroEspecie.SelectedValue.Equals("0"))
            {
                flag = true;
                mascot.especie = new EEspecie();
                mascot.especie.idEspecie = int.Parse(ddlFiltroEspecie.SelectedValue);
                if (!ddlFiltroRaza.SelectedValue.Equals("0"))
                {
                    mascot.raza = new ERaza();
                    mascot.raza.idRaza = int.Parse(ddlFiltroRaza.SelectedValue);
                }
            }            
            if(!ddlFiltroSexo.SelectedValue.Equals("0"))
            {
                flag = true;
                mascot.sexo = ddlFiltroSexo.SelectedValue;
            }
            if (!ddlFiltroColor.SelectedValue.Equals("0"))
            {
                flag = true;
                mascot.color = new EColor();
                mascot.color.idColor = int.Parse(ddlFiltroColor.SelectedValue);
            }
            List<EMascota> mascotasFiltradas = null;
            if (flag)
            {
                mascotasFiltradas = LogicaBDMascota.buscarMascotasFiltros(mascot);
            }
            else
            {
                mascotasFiltradas = LogicaBDMascota.buscarMascotasPorEstado(mascot.estado.nombreEstado);
            }            
            if (mascotasFiltradas != null)
            {
                List<int> idsMascotas = new List<int>();
                foreach (var item in mascotasFiltradas)
                {
                    idsMascotas.Add(item.idMascota);
                }
                if (mascotasFiltradas.Count != 0)
                {
                    List<EHallazgo> listaHallazgos = LogicaBDHallazgo.buscarHallazgos(idsMascotas);
                    for (int i = 0; i < listaHallazgos.Count; i++)
                    {
                        foreach (var mascotaFor in mascotasFiltradas)
                        {
                            if (mascotaFor.idMascota == listaHallazgos.ElementAt(i).mascota.idMascota)
                            {
                                listaHallazgos.ElementAt(i).mascota = mascotaFor;
                                break;
                            }
                        }
                    }
                    Session["Hallazgos"] = listaHallazgos;
                    cargarTablaHalladas();
                    pnlAtento.Visible = false;
                }
                else
                {
                    lblError.Text = "No se encontraron mascotas con dichas caracteristicas";
                    pnlAtento.Visible = true;
                    lstPerdidas.Visible = false;
                    pnlMascotaSeleccionada.Visible = false;
                }
            }
            else
            {
                lblError.Text = "No se encontraron mascotas con dichas caracteristicas";
                pnlAtento.Visible = true;                
                lstPerdidas.Visible = false;
                pnlMascotaSeleccionada.Visible = false;
            }
            pnlCorrecto.Visible = false;
        }

        public byte[] ImageHandler_ObtenerImagenMascota(HttpContext context)
        {
            if (Session["imagen"] != null)
            {
                var imagen = (byte[])Session["imagen"];
                return imagen;
            }
            else
            {
                return null;
            }
        }

        protected void btnRegistrarHallazgo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EPerdida perdida = null;
                EMascota mascota = null;
                //if (rbYaPerdida.Checked)
                //{
                //    mascota = (EMascota)Session["MascotaPerdida"];
                //    perdida = LogicaBDPerdida.buscarPerdidaPorIdMascota(mascota);
                //}
                //else
                //{
                    mascota = new EMascota();
                    mascota.nombreMascota = txtNombreMascota.Text;
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = int.Parse(ddlEspecie.SelectedValue);
                    mascota.raza = new ERaza();
                    mascota.raza.idRaza = int.Parse(ddlRaza.SelectedValue);
                    mascota.sexo = ddlSexo.SelectedValue;
                    mascota.color = new EColor();
                    mascota.color.idColor = int.Parse(ddlColor.SelectedValue);
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = int.Parse(ddlEdad.SelectedValue);
                    mascota.estado = new EEstado();
                    //Hardcode!!!!
                    mascota.estado.idEstado = 2;                    
                //}
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
                hallazgo.domicilio.calle = new ECalle();
                hallazgo.domicilio.calle.nombre = ddlCalles.SelectedItem.Text;
                hallazgo.domicilio.numeroCalle = int.Parse(txtNroCalle.Text);
                hallazgo.usuario = new EUsuario() { user = Session["UsuarioLogueado"].ToString() };
                try
                {
                    LogicaBDHallazgo.registrarHallazgo(hallazgo);
                    pnlCorrecto.Visible = true;
                    lblCorrecto.Text = "Hallazgo registrado exisotamente";
                }
                catch (Exception)
                {
                    pnlAtento.Visible = true;
                    lblError.Text = "Error al registrar el hallazgo";
                }
            }
        }

        protected void ddlEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCombos.cargarRazas(ref ddlRaza, int.Parse(ddlEspecie.SelectedValue));
        }
        
        protected void cvEspecie_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlEspecie);
        }

        protected void cvRaza_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlRaza);
        }

        protected void cvSexo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlSexo);
        }

        protected void cvColor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validaciones.verificarSeleccionEnDdl(ref ddlColor);
        }

        private void limpiarCampos()
        {
            txtNombreMascota.Text = "";
            ddlEspecie.SelectedIndex = -1;
            ddlEdad.SelectedIndex = -1;
            ddlColor.SelectedIndex = -1;
            ddlSexo.SelectedIndex = -1;
            ddlBarrios.SelectedIndex = -1;
            ddlCalles.SelectedIndex = -1;
            ddlLocalidades.SelectedIndex = -1;
            txtFecha.Text = "";
            txtNroCalle.Text = "";
            txtComentarios.Text = "";
        }    
    }
}