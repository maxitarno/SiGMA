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
    public partial class VeterinariasBarrio : System.Web.UI.Page
    {
        public EVeterinaria veterinaria;
        public List<EVeterinaria> veterinarias = new List<EVeterinaria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos.cargarBarrio(ref ddlBarrio);
            }
        }

        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefaultDueño.aspx");
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
            string pagina = "";
            for (int i = 0; i < veterinarias.Count; i++)
            {
                nombre = nombre + veterinarias[i].nombre.ToString();
                telefono = telefono + veterinarias[i].telefono;
                contacto = contacto + veterinarias[i].contacto;
                direccion = direccion + (veterinarias[i].domicilio.barrio.localidad.nombre.ToLower().ToString() + " " + veterinarias[i].domicilio.calle.nombre.ToLower().ToString() + " " + veterinarias[i].domicilio.numeroCalle.ToString()).ToString();
                if (i != (veterinarias.Count - 1))
                {
                    direccion += ",";
                    contacto += ",";
                    nombre += ",";
                    telefono += ",";
                }
            }
            //pagina = "mapaVeterinarias.htm?direccion=" + direccion + "&nombre=" + nombre + "&telefono=" + telefono + "&contacto=" + contacto;
            hfdirecciones.Value = direccion;
            hfnombres.Value = nombre;
            hftelefonos.Value = telefono;
            hfcontactos.Value = contacto;
            //Response.Write("<script>window.open('" + pagina + "','popup','width=800,height=500')</script>");
            //Response.Write("<script>BootstrapDialog.show({ message: $('<div></div>').load('www.google.com')});</script>");
        }
    }
}