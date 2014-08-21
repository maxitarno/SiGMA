using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Text;
using AccesoADatos;
using Entidades;

namespace Herramientas
{
    public class CargarCombos
    {
        //carga de combo de tipo de documentos
        public static void cargarComboTipoDocumento(ref DropDownList ddl)
        {
            List<ETipoDeDocumento> tiposDoc = Datos.TiposDNI();
            foreach(ETipoDeDocumento item in tiposDoc)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(),item.idTipoDeDocumento.ToString()));
            }
        }
        //carga del combo de roles
        public static void cargarRoles(ref DropDownList ddl)
        {
            ddl.DataTextField = "nombreRol";
            ddl.DataValueField = "idRol";
            ddl.DataSource = LogicaBDRol.Roles();
            ddl.DataBind();
        }
        //carga de combo de Barrio
        public static void cargarComboBarrio(ref DropDownList ddl)
        {
            List<EBarrio> barrios = Datos.BuscarBarrios();
            foreach (EBarrio item in barrios)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idBarrio.ToString()));
            }
        }
        //carga de combo de Localidades
        public static void cargarComboLocalidades(ref DropDownList ddl)
        {
            List<ELocalidad> localidades = Datos.BuscarLocalidades();
            foreach (ELocalidad item in localidades)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idLocalidad.ToString()));
            }
        }
        public static void cargarComboEspecies(ref DropDownList ddl)
        {
            List<EEspecie> especies = Datos.BuscarEspecies();
            foreach (EEspecie item in especies)
            {
                ddl.Items.Add(new ListItem(item.nombreEspecie.ToString(), item.idEspecie.ToString()));
            }
        }

        public static void cargarComboRazas(ref DropDownList ddl, int idEspecie)
        {
            List<ERaza> razas = Datos.BuscarRazas(idEspecie);
            foreach (ERaza item in razas)
            {
                ddl.Items.Add(new ListItem(item.nombreRaza.ToString(), item.idRaza.ToString()));
            }
        }

        public static void cargarComboEdad(ref DropDownList ddl)
        {
            List<EEdad> edades = Datos.BuscarEdades();
            foreach (EEdad item in edades)
            {
                ddl.Items.Add(new ListItem(item.nombreEdad.ToString(), item.idEdad.ToString()));
            }
        }

        public static void cargarComboColor(ref DropDownList ddl)
        {
            List<EColor> edades = Datos.BuscarColores();
            foreach (EColor item in edades)
            {
                ddl.Items.Add(new ListItem(item.nombreColor.ToString(), item.idColor.ToString()));
            }
        }

        public static void cargarComboRazas(ref DropDownList ddl)
        {
            List<ERaza> razas = Datos.BuscarRazas();
            foreach (ERaza item in razas)
            {
                ddl.Items.Add(new ListItem(item.nombreRaza.ToString(), item.idRaza.ToString()));
            }
        }
    }
}
