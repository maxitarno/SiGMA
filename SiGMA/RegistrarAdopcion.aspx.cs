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
    public partial class RegistrarAdopcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    if (!LogicaBDRol.verificarPermisoVisualizacion(Session["UsuarioLogueado"].ToString(), "RegistrarMascota.aspx"))
                        Response.Redirect("PermisosInsuficientes.aspx");
                    if (!LogicaBDRol.verificarPermisosGrabacion(Session["UsuarioLogueado"].ToString(), "RegistrarMascota.aspx"))
                    {
                        btnRegistrar.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarCombos.cargarTipoDocumento(ref ddlTipo);
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
                CargarCombos.cargarComboRazas(ref ddlRaza);
                CargarCombos.cargarEdad(ref ddlEdad);
                CargarCombos.cargarEspecies(ref ddlEspecies);
                CargarCombos.cargarSexo(ref ddlSexo);
                pnlBuscarDuenio.Visible = true;
                if (Session["Si"] != null)
                {
                    if (Session["Si"].ToString().Equals("Si"))
                    {
                        btnRegistrar.Text = "Registrar adopción";
                        EPersona persona = (EPersona)Session["Dueño"];
                        EMascota mascota = (EMascota)Session["Mascota"];
                        txtNombreD.Text = persona.nombre;
                        txtDNI.Text = persona.nroDocumento;
                        //txtLocalidad.Text = persona.localidad.nombre;
                        txtBarrio.Text = persona.barrio.nombre;
                        txtCalle.Text = persona.domicilio.nombre;
                        txtNro.Text = persona.nroCalle.ToString();
                        txtNombreM.Text = mascota.nombreMascota;
                        txtRaza.Text = mascota.raza.nombreRaza;
                        txtSexo.Text = mascota.sexo;
                        txtEdad.Text = mascota.edad.nombreEdad;
                        txtNombreM.Text = mascota.nombreMascota;
                        pnlDuenio.Visible = true;
                        pnlMascota.Visible = true;
                        pnlRegistrar.Visible = true;
                        txtDNI.Text = "";
                        txtNombreM.Text = mascota.nombreMascota;
                        txtTipoDeDocumento.Text = persona.nroDocumento;
                        txtNº.Text = persona.tipoDocumento.nombre;
                        txtEspecie.Text = mascota.especie.nombreEspecie;
                    }
                }
                if (rbPorDNI.Checked)
                {
                    if (Session["Si"] != null)
                    {
                        if (Session["Si"].ToString().Equals("No"))
                        {
                            pnlDocumento.Visible = true;
                            btnRegistrar.Text = "Generar Contrato";
                        }
                    }
                    else
                    {
                        pnlDocumento.Visible = true;
                        btnRegistrar.Text = "Generar contrato";
                    }
                    pnlNombre.Visible = false;
                    pnlInfo.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlBuscarMascota.Visible = false;
                    pnlAtento.Visible = false;
                    pnlResultadosDuenio.Visible = false;
                    pnlResultadosMascotas.Visible = false;
                }
                if (rbPorNombre.Checked)
                {
                    if (Session["Si"] != null)
                    {
                        if (Session["Si"].ToString().Equals("No"))
                        {
                            pnlNombre.Visible = true;
                            btnRegistrar.Text = "Generar Contrato";
                        }
                    }
                    else
                    {
                        pnlNombre.Visible = true;
                        btnRegistrar.Text = "Generar Contrato";
                    }
                    pnlDocumento.Visible = false;
                    pnlInfo.Visible = false;
                    pnlCorrecto.Visible = false;
                    pnlBuscarMascota.Visible = false;
                    pnlAtento.Visible = false;
                    pnlResultadosDuenio.Visible = false;
                    pnlResultadosMascotas.Visible = false;
                }
            }
            else
            {
                pnlInfo.Visible = false;
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }
        public void rbPorTipo(object sender, EventArgs e)
        {
            btnRegistrar.Text = "Generar Contrato";
            pnlNombre.Visible = false;
            pnlMascota.Visible = false;
            pnlBuscarMascota.Visible = false;
            pnlDocumento.Visible = true;
            pnlResultadosDuenio.Visible = false;
            pnlResultadosMascotas.Visible = false;
            pnlDuenio.Visible = false;
            pnlMascota.Visible = false;
            pnlRegistrar.Visible = false;
        }
        public void rbPorName(object sender, EventArgs e)
        {
            btnRegistrar.Text = "Generar Contrato";
            pnlNombre.Visible = true;
            pnlMascota.Visible = false;
            pnlBuscarMascota.Visible = false;
            pnlDocumento.Visible = false;
            pnlResultadosDuenio.Visible = false;
            pnlResultadosMascotas.Visible = false;
            pnlDuenio.Visible = false;
            pnlMascota.Visible = false;
            pnlRegistrar.Visible = false;
        }
        public void btnBuscarDuenioClick(object sender, EventArgs e)
        {
            lstResultadosDuenios.Items.Clear();
            if (rbPorNombre.Checked)
            {
                List<EUsuario> usuarios = new List<EUsuario>();
                usuarios = LogicaBDUsuario.BuscarUsuariosDuenio(txtNombreDuenio.Text);
                if (usuarios.Count != 0)
                {
                    lstResultadosDuenios.DataSource = usuarios;
                    lstResultadosDuenios.DataTextField = "user";
                    lstResultadosDuenios.DataValueField = "user";
                    lstResultadosDuenios.DataBind();
                    pnlResultadosDuenio.Visible = true;
                    if (usuarios.Count == 1)
                    {
                        lstResultadosDuenios.SelectedIndex = 0;
                        lstResultadosDuenios_SelectedIndexChanged(null, null);
                    }
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblInfo.Text = "No se encontraron dueños";
                }
            }
            else if (rbPorDNI.Checked)
            {
                if (ddlTipo.SelectedValue.Equals("0"))
                {
                    pnlCorrecto.Visible = false;
                    pnlInfo.Visible = true;
                    pnlAtento.Visible = false;
                    lblInfo.Text = "Debe seleccionar un tipo de documento";
                }
                else
                {
                    List<EUsuario> usuarios = new List<EUsuario>();
                    usuarios = LogicaBDUsuario.BuscarUsuariosDuenio(int.Parse(ddlTipo.SelectedValue), txtDNI.Text);
                    if (usuarios.Count != 0)
                    {
                        lstResultadosDuenios.DataSource = usuarios;
                        lstResultadosDuenios.DataTextField = "user";
                        lstResultadosDuenios.DataValueField = "user";
                        lstResultadosDuenios.DataBind();
                        pnlResultadosDuenio.Visible = true;
                        if (usuarios.Count == 1)
                        {
                            lstResultadosDuenios.SelectedIndex = 0;
                            lstResultadosDuenios_SelectedIndexChanged(null, null);
                        }
                    }
                    else
                    {
                        pnlInfo.Visible = true;
                        lblInfo.Text = "No se encontraron dueños";
                    }
                }
            }
        }
        public void btnBuscarMascotaClick(object sender, EventArgs e)
        {
            EMascota mascota = new EMascota();
            if (!ddlEdad.SelectedValue.Equals("0"))
            {
                mascota.edad = new EEdad();
                mascota.edad.nombreEdad = ddlEdad.SelectedItem.Text;
                mascota.edad.idEdad = int.Parse(ddlEdad.SelectedValue);
            }
            if (!ddlEspecies.SelectedValue.Equals("0"))
            {
                mascota.especie = new EEspecie();
                mascota.especie.idEspecie = int.Parse(ddlEspecies.SelectedValue);
                mascota.especie.nombreEspecie = ddlEspecies.SelectedItem.Text;
            }
            if (!ddlRaza.SelectedValue.Equals("0"))
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
            mascota.estado = new EEstado();
            mascota.estado.nombreEstado = "En adopcion";
            mascota.estado.idEstado = 4;
            mascota.nombreMascota = txtNombreMascota.Text;
            List<EMascota> mascotas = LogicaBDMascota.buscarMascotasFiltros(mascota);
            if(mascotas.Count != 0){
                lstResultadosMascotas.DataSource = mascotas;
                lstResultadosMascotas.DataTextField = "nombreMascota";
                lstResultadosMascotas.DataValueField = "idMascota";
                lstResultadosMascotas.DataBind();
                pnlResultadosMascotas.Visible = true;
                if (mascotas.Count == 1)
                {
                    lstResultadosMascotas.SelectedIndex = 0;
                    lstResultadosMascotas_SelectedIndexChanged(null, null);
                }
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "No se encontraron mascotas";
            }
        }
        public void btnRegistrarClick(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (Session["Si"] != null && Session["Si"].ToString().Equals("Si"))
                {
                    EAdopcion adopcion = new EAdopcion();
                    adopcion.mascota = new EMascota();
                    adopcion.duenio = new EDuenio();
                    adopcion.idVoluntario = (Session["IdVoluntario"].ToString().Equals("")) ? 0 : int.Parse(Session["IdVoluntario"].ToString());
                    adopcion.mascota.idMascota = int.Parse(Session["IdMascota"].ToString());
                    adopcion.fecha = DateTime.Now;
                    adopcion.duenio.idDuenio = int.Parse(Session["Duenio"].ToString());
                    adopcion.mascota.nombreMascota = txtNombreM.Text;
                    if (LogicaBDAdopcion.RegistrarAdopcion(adopcion))
                    {
                        lblCorrecto.Text = "Adopcion registrada exitosamente";
                        pnlCorrecto.Visible = true;
                        lblCorrecto.Focus();
                        Session["Si"] = null;
                        pnlDocumento.Visible = true;
                        pnlBuscarDuenio.Visible = true;
                        pnlDuenio.Visible = false;
                        pnlMascota.Visible = false;
                        pnlRegistrar.Visible = false;
                    }
                    else
                    {
                        lblError.Text = "No se pudo registrar";
                        pnlAtento.Visible = true;
                    }
                }
                else
                {
                    if (Validaciones.verificarSoloLetras(txtNombreM.Text))
                    {
                        EMascota mascota = (EMascota)Session["Mascota"];
                        mascota.nombreMascota = txtNombreM.Text;
                        Session["Mascota"] = mascota;
                        Session["na"] = LogicaBDAdopcion.obtenerProximoIdAdopcion();
                        Session["Modificar"] = "No";
                        Response.Redirect("Contrato.aspx");
                    }
                    else
                    {
                        pnlInfo.Visible = true;
                        lblInfo.Text = "Debe ingresar un nombre valido";
                    }
                }
            }
        }
        public void ddlRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ERaza> razas = new List<ERaza>();
            int aux = int.Parse(ddlEspecies.SelectedValue);
            CargarCombos.cargarRazas(ref ddlRaza, aux);
        }
        //public void BtnRegresarClick(object sender, EventArgs e)
        //{
        //    Session["Si"] = null;
        //    Response.Redirect("Adopciones.aspx");
        //}
        protected void lstResultadosDuenios_SelectedIndexChanged(object sender, EventArgs e)
        {
            EDuenio duenio = new EDuenio();
            EPersona persona = new EPersona();
            EBarrio barrio = new EBarrio();
            ELocalidad localidad = new ELocalidad();
            ETipoDeDocumento tipodoc = new ETipoDeDocumento();
            persona.tipoDocumento = tipodoc;
            EUsuario usuario = new EUsuario();
            ECalle calle = new ECalle();
            if (lstResultadosDuenios.SelectedValue != "")
            {
                LogicaBDUsuario.BuscarUsuarios(lstResultadosDuenios.SelectedValue, usuario, persona, barrio, localidad, tipodoc, calle, duenio);
                if (calle.nombre != "" && barrio.nombre != "" && localidad.nombre != "")
                {
                    txtNombreD.Text = persona.nombre;
                    persona.tipoDocumento.nombre = tipodoc.nombre;
                    txtDNI.Text = persona.nroDocumento;
                    //txtLocalidad.Text = localidad.nombre;
                    txtBarrio.Text = barrio.nombre;
                    txtCalle.Text = calle.nombre;
                    txtNro.Text = persona.nroCalle.ToString();
                    pnlDuenio.Visible = true;
                    ddlTipo.SelectedValue = tipodoc.idTipoDeDocumento.ToString();
                    txtTipoDeDocumento.Text = ddlTipo.SelectedItem.Text;
                    txtNombreDuenio.Text = lstResultadosDuenios.SelectedValue;
                    pnlResultadosDuenio.Visible = false;
                    pnlBuscarDuenio.Visible = false;
                    txtNº.Text = persona.nroDocumento;
                    pnlBuscarMascota.Visible = true;
                    Session["Duenio"] = duenio.idDuenio;
                    persona.barrio = barrio;
                    persona.domicilio = calle;
                    persona.localidad = localidad;
                    Session["Dueño"] = persona;
                    txtNombreD.Focus();
                }
                else
                {
                    pnlInfo.Visible = true;
                    lblInfo.Text = "Debe seleccionar un dueño con domicilio o registrar un nuevo dueño";
                    pnlCorrecto.Visible = false;
                    pnlAtento.Visible = false;
                }
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe seleccionar un Dueño";
                pnlCorrecto.Visible = false;
                pnlAtento.Visible = false;
            }
        }
        protected void lstResultadosMascotas_SelectedIndexChanged(object sender, EventArgs e) 
        {
            EMascota mascota = new EMascota();
            ECaracterMascota caracter = new ECaracterMascota();
            ECategoriaRaza categoria = new ECategoriaRaza();
            ECuidado cuidado = new ECuidado();
            if (lstResultadosMascotas.SelectedValue != "")
            {
                LogicaBDMascota.BuscarMascota(mascota, categoria, caracter, cuidado, int.Parse(lstResultadosMascotas.SelectedValue));
                txtNombreMascota.Text = mascota.nombreMascota;
                txtRaza.Text = mascota.raza.nombreRaza;
                txtSexo.Text = mascota.sexo;
                txtEdad.Text = mascota.edad.nombreEdad;
                txtNombreM.Text = mascota.nombreMascota;
                pnlMascota.Visible = true;
                pnlRegistrar.Visible = true;
                Session["IdMascota"] = mascota.idMascota;
                Session["Mascota"] = mascota;
                pnlResultadosMascotas.Visible = false;
                pnlBuscarMascota.Visible = false;
                txtEspecie.Text = mascota.especie.nombreEspecie;
                txtNombreM.Enabled = true;
                btnRegistrar.Focus();
            }
            else
            {
                pnlInfo.Visible = true;
                lblInfo.Text = "Debe seleccionar una mascota";
            }
        }
    }
}