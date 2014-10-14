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
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            ddl.Items.Add(new ListItem("Hembra", "Hembra"));
            ddl.Items.Add(new ListItem("Macho", "Macho"));
        }

        public static void cargarTratos(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            ddl.Items.Add(new ListItem("Si", "true"));
            ddl.Items.Add(new ListItem("No", "false"));
        }
        //carga de combo de tipo de documentos
        public static void cargarTipoDocumento(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
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
            ddl.Items.Insert(0, "SIN ASIGNAR");
            ddl.DataBind();            
        }
        //Borrar este metodo
        public static void cargarBarrio(ref DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            List<EBarrio> barrios = Datos.BuscarBarrios();
            foreach (EBarrio item in barrios)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idBarrio.ToString()));
            }
        }
        public static void cargarBarrio(ref DropDownList ddl, int idLocalidad)
        {
            ddl.Items.Clear();            
            List<EBarrio> barrios = Datos.BuscarBarrios(idLocalidad);
            foreach (EBarrio item in barrios)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idBarrio.ToString()));
            }
        }
        //carga de combo de Localidades
        public static void cargarLocalidades(ref DropDownList ddl)
        {            
            List<ELocalidad> localidades = Datos.BuscarLocalidades();
            foreach (ELocalidad item in localidades)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idLocalidad.ToString()));
            }            
        }
        public static void cargarEspecies(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            List<EEspecie> especies = Datos.BuscarEspecies();
            foreach (EEspecie item in especies)
            {
                ddl.Items.Add(new ListItem(item.nombreEspecie.ToString(), item.idEspecie.ToString()));
            }            
        }

        public static void cargarRazas(ref DropDownList ddl, int idEspecie)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            List<ERaza> razas = Datos.BuscarRazas(idEspecie);
            foreach (ERaza item in razas)
            {
                ddl.Items.Add(new ListItem(item.nombreRaza.ToString(), item.idRaza.ToString()));
            }            
        }

        public static void cargarEdad(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            List<EEdad> edades = Datos.BuscarEdades();
            foreach (EEdad item in edades)
            {
                ddl.Items.Add(new ListItem(item.nombreEdad.ToString() + " - " + item.descripcion.ToString(), item.idEdad.ToString()));
            }            
        }

        public static void cargarColor(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            List<EColor> colores = Datos.BuscarColores();
            foreach (EColor item in colores)
            {
                ddl.Items.Add(new ListItem(item.nombreColor.ToString(), item.idColor.ToString()));
            }            
        }        

        public static void cargarCaracteresMascota(ref DropDownList ddl)
        {
            List<ECaracterMascota> caracterMascotas = Datos.BuscarCaracteresMascota();
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            foreach (ECaracterMascota item in caracterMascotas)
            {
                ddl.Items.Add(new ListItem(item.descripcion.ToString(), item.idCaracter.ToString()));
            }
            
        }

        public static void cargarComboRazas(ref DropDownList ddl)
        {
            List<ERaza> razas = Datos.BuscarRazas();
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            foreach (ERaza item in razas)
            {
                ddl.Items.Add(new ListItem(item.nombreRaza.ToString(), item.idRaza.ToString()));
            }
        }
        public static void cargarEstado(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            List<EEstado> estados = Datos.BuscarEstados();
            foreach (EEstado item in estados)
            {
                ddl.Items.Add(new ListItem(item.nombreEstado.ToString(), item.idEstado.ToString()));
            }
        }        
        public static void cargarTipoDocumentoLista(ref ListBox ddl, string tipoDocumento)
        {
            List<ETipoDeDocumento> tiposDocumentos = Datos.TiposDNI(tipoDocumento);
            foreach (ETipoDeDocumento item in tiposDocumentos)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idTipoDeDocumento.ToString()));
            }
        }
        public static void cargarRazaLista(ref ListBox ddl, string raza, int idEspecie)
        {
            List<ERaza> razas = Datos.BuscarRazas(idEspecie, raza);
            foreach (ERaza item in razas)
            {
                ddl.Items.Add(new ListItem(item.nombreRaza.ToString(), item.idRaza.ToString()));
            }
        }
        public static void cargarCategorias(ref DropDownList ddl)
        {
            List<ECategoriaRaza> categorias = Datos.BuscarCategoriasDeRazas();
            ddl.Items.Add(new ListItem("SIN ASIGNAR", "0"));
            foreach (ECategoriaRaza item in categorias)
            {
                ddl.Items.Add(new ListItem(item.nombreCategoriaRaza.ToString(), item.idCategoriaRaza.ToString()));
            }
        }
        public static void cargarCuidados(ref DropDownList ddl)
        {
            List<ECuidado> categorias = Datos.BuscarCuidado();
            foreach (ECuidado item in categorias)
            {
                ddl.Items.Add(new ListItem(item.descripcion.ToString(), item.idCuidado.ToString()));
            }
        }
        public static void cargarCalles(ref DropDownList ddl)
        {
            ddl.Items.Clear();
            List<ECalle> calles = Datos.BuscarCalle();
            foreach (ECalle item in calles)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idCalle.ToString()));
            }
        }
        public static void cargarCalles(ref DropDownList ddl, int localidad)
        {
            ddl.Items.Clear();
            List<ECalle> calles = Datos.BuscarCalle(localidad);
            foreach (ECalle item in calles)
            {
                ddl.Items.Add(new ListItem(item.nombre.ToString(), item.idCalle.ToString()));
            }
        }
    }
}
