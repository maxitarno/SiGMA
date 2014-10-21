using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Data;
namespace SiGMA
{
    public partial class Contrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            EMascota mascota = (EMascota)Session["Mascota"];
            EPersona persona = (EPersona)Session["Dueño"];
            ContratoWEb acuerdo = new ContratoWEb();
            DataSet ds = new DatosReportes();
            DataTable dt = ds.Tables["ContratoAdopcion"];
            DataRow row = dt.NewRow();
            row["numero de documento"] = persona.nroDocumento;
            row["nombre"] = persona.nombre;
            row["apellido"] = persona.apellido;
            row["barrio"] = persona.barrio.nombre;
            row["calle"] = persona.domicilio.nombre;
            row["numero de calle"] = (persona.nroCalle == null) ? 0 : persona.nroCalle;
            row["localidad"] = (persona.localidad == null) ? "" : persona.localidad.nombre;
            row["telefono fijo"] = (persona.telefonoFijo == null) ? "" : persona.telefonoFijo;
            row["telefono celular"] = (persona.telefonoCelular == null) ? "" : persona.telefonoCelular;
            row["email"] = (persona.email == null) ? "" : persona.email;
            row["idmascota"] = mascota.idMascota;
            row["nombre mascota"] = mascota.nombreMascota;
            row["especie"] = mascota.especie.nombreEspecie;
            row["raza"] = mascota.raza.nombreRaza;
            row["edad"] = mascota.edad.nombreEdad;
            row["sexo"] = mascota.sexo;
            row["id"] = int.Parse(Session["IdVoluntario"].ToString());
            row["na"] = int.Parse(Session["na"].ToString());
            dt.Rows.Add(row);
            acuerdo.SetDataSource(ds);
            CrContrato.ReportSource = acuerdo;                
            CrContrato.RefreshReport();   
        }
        public void BtnAceptarClick(object sender, EventArgs e)
        {
            Session["Si"] = "Si";
            if (Session["Modificar"].Equals("No"))
            {
                Response.Redirect("RegistrarAdopcion.aspx");
            }
            else
            {
                Response.Redirect("ConsultarAdopcion.aspx");
            }
        }
        public void BtnRechazarClick(object sender, EventArgs e)
        {
            Session["Si"] = "No";
            if (Session["Modificar"].Equals("No"))
            {
                Response.Redirect("RegistrarAdopcion.aspx");
            }
            else
            {
                Response.Redirect("ConsultarAdopcion.aspx");
            }
        }
    }
}