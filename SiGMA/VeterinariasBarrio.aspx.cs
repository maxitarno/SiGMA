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
    public partial class VeterinariasBarrio : System.Web.UI.Page
    {
        public EVeterinaria veterinaria;
        public List<EVeterinaria> veterinarias = new List<EVeterinaria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarBarrio(ref ddlBarrio, 1);
            }
            else
            {
                pnlAtento.Visible = false;
                pnlCorrecto.Visible = false;
            }
        }

        protected void ddlBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            veterinaria = new EVeterinaria();
            veterinaria.domicilio = new EDomicilio();
            veterinaria.domicilio.barrio = new EBarrio();
            veterinaria.domicilio.barrio.idBarrio = int.Parse(ddlBarrio.SelectedValue);
            veterinarias = LogicaBDVeterinaria.BuscarPorDomicilio1(veterinaria);
            string nombre = "";
            string telefono = "";
            string contacto = "";
            string direccion = "";
            string tipos = "";
            for (int i = 0; i < veterinarias.Count; i++)
            {
                nombre = nombre + veterinarias[i].nombre.ToString();
                telefono = telefono + veterinarias[i].telefono;
                contacto = contacto + veterinarias[i].contacto;
                direccion = direccion + (veterinarias[i].domicilio.barrio.localidad.nombre.ToLower().ToString() + " " + veterinarias[i].domicilio.calle.nombre.ToLower().ToString() + " " + veterinarias[i].domicilio.numeroCalle.ToString()).ToString();
                if (veterinarias[i].castraciones)
                    tipos += "-Castraciones";
                if (veterinarias[i].medicina)
                    tipos += "-Medicinas";
                //if (veterinarias[i].medicina && !veterinarias[i].castraciones)
                //    tipos += "Medicinas";
                if (veterinarias[i].petshop)
                    tipos += "-Petshop";
                //if (veterinarias[i].petshop && !veterinarias[i].medicina)
                //    tipos += "Petshop";
                if (veterinarias[i].peluqueria)
                    tipos += "-Peluqueria";
                //if (veterinarias[i].peluqueria && !veterinarias[i].petshop)
                //    tipos += "Peluqueria";
                if (veterinarias[i].castraciones == false && veterinarias[i].medicina == false && veterinarias[i].peluqueria == false && veterinarias[i].petshop == false)
                    tipos += "Sin asignar";
                if (i != (veterinarias.Count - 1))
                {
                    direccion += ",";
                    contacto += ",";
                    nombre += ",";
                    telefono += ",";
                    tipos += ",";
                }
            }
            hfdirecciones.Value = direccion;
            hfnombres.Value = nombre;
            hftelefonos.Value = telefono;
            hfcontactos.Value = contacto;
            hfTipos.Value = tipos;
        }
    }
}