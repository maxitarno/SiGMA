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
        public static void cargarSexo(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", "0"));
            ddl.Items.Add(new ListItem("Hembra", "Hembra"));
            ddl.Items.Add(new ListItem("Macho", "Macho"));
        }

        public static void cargarTratos(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", "0"));
            ddl.Items.Add(new ListItem("Si", "Si"));
            ddl.Items.Add(new ListItem("No", "No"));
        }
        //carga de combo de tipo de documentos
        public static void cargarTipoDocumento(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("-- Seleccione una opción --", "0"));
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
        public static void cargarBarrio(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("-- Seleccione una opción --", "0"));
            List<EBarrio> barrios = Datos.BuscarBarrios();
            foreach (EBarrio item in barrios)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idBarrio.ToString()));
            }            
        }
        //carga de combo de Localidades
        public static void cargarLocalidades(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("-- Seleccione una opción --", "0"));
            List<ELocalidad> localidades = Datos.BuscarLocalidades();
            foreach (ELocalidad item in localidades)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idLocalidad.ToString()));
            }            
        }
        public static void cargarEspecies(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("-- Seleccione una opción --", "0"));
            List<EEspecie> especies = Datos.BuscarEspecies();
            foreach (EEspecie item in especies)
            {
                ddl.Items.Add(new ListItem(item.nombreEspecie.ToString(), item.idEspecie.ToString()));
            }            
        }

        public static void cargarRazas(ref DropDownList ddl, int idEspecie)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("-- Seleccione una opción --", "0"));
            List<ERaza> razas = Datos.BuscarRazas(idEspecie);
            foreach (ERaza item in razas)
            {
                ddl.Items.Add(new ListItem(item.nombreRaza.ToString(), item.idRaza.ToString()));
            }            
        }

        public static void cargarEdad(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("-- Seleccione una opción --", "0"));
            List<EEdad> edades = Datos.BuscarEdades();
            foreach (EEdad item in edades)
            {
                ddl.Items.Add(new ListItem(item.nombreEdad.ToString() + " - " + item.descripcion.ToString(), item.idEdad.ToString()));
            }            
        }

        public static void cargarColor(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("-- Seleccione una opción --", "0"));
            List<EColor> colores = Datos.BuscarColores();
            foreach (EColor item in colores)
            {
                ddl.Items.Add(new ListItem(item.nombreColor.ToString(), item.idColor.ToString()));
            }            
        }        

        public static void cargarCaracteresMascota(ref DropDownList ddl)
        {
            List<ECaracterMascota> caracterMascotas = Datos.BuscarCaracteresMascota();
            ddl.Items.Add(new ListItem("-- Seleccione una opción --", "0"));
            foreach (ECaracterMascota item in caracterMascotas)
            {
                ddl.Items.Add(new ListItem(item.descripcion.ToString(), item.idCaracter.ToString()));
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
        public static void cargarEstado(ref DropDownList ddl)
        {
<<<<<<< .mine
            ddl.Items.Add(new ListItem("-- Seleccione una opción--", "0"));
            List<EEstados> estados = Datos.BuscarEstados();
            foreach (EEstados item in estados)
=======
            ddl.Items.Add(new ListItem("-- Seleccione una opción--", "0"));
            List<EEstado> estados = Datos.BuscarEstados();
            foreach (EEstado item in estados)
>>>>>>> .r127
            {
                ddl.Items.Add(new ListItem(item.nombreEstado.ToString(), item.idEstado.ToString()));
            }
        }
        public static void cargarBarrio(ref DropDownList ddl, int idLocalidad)
        {
            List<EBarrio> barrios = Datos.BuscarBarrios(idLocalidad);
            foreach (EBarrio item in barrios)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idBarrio.ToString()));
            }
        }
    }
}
