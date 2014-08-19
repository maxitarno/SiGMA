﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using Entidades;
namespace SiGMA
{
    public partial class ConsultarMascotasaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<EEstados> estados = new List<EEstados>();
                estados = Datos.BuscarEstados();
                ddlEstado.DataSource = estados;
                ddlEstado.DataTextField = "nombreEstado";
                ddlEstado.DataValueField = "idEstado";
                ddlEstado.DataBind();
                List<EColor> colores = new List<EColor>();
                colores = Datos.BuscarColores();
                ddlColor.DataSource = colores;
                ddlColor.DataTextField = "nombreColor";
                ddlColor.DataValueField = "idColor";
                ddlColor.DataBind();
                List<EEspecie> especies = new List<EEspecie>();
                especies = Datos.BuscarEspecies();
                ddlEspecie.DataSource = especies;
                ddlEspecie.DataTextField = "nombreEspecie";
                ddlEspecie.DataValueField = "idEspecie";
                ddlEspecie.DataBind();
                List<EEdad> edades = new List<EEdad>();
                edades = Datos.BuscarEdades();
                ddlEdad.DataSource = edades;
                ddlEdad.DataTextField = "nombreEdad";
                ddlEdad.DataValueField = "idEdad";
                ddlEdad.DataBind();
                List<ECategoriaRaza> categoriasDeRaza = new List<ECategoriaRaza>();
                categoriasDeRaza = Datos.BuscarCategoriasDeRazas();
                ddlCategoria.DataSource = categoriasDeRaza;
                ddlCategoria.DataTextField = "idCategoriaRaza";
                ddlCategoria.DataValueField = "nombreCategoriaRaza";
                ddlCategoria.DataBind();
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
        }
    }
}