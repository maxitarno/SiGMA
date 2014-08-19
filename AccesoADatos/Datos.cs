using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
namespace AccesoADatos
{
    public class Datos
    {
        //Mi metodo para buscar los tipos de documentos
        public static List<ETipoDeDocumento> TiposDNI()
        {
            List<ETipoDeDocumento> tiposDNI = new List<ETipoDeDocumento>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<TipoDocumentos> tiposDeDocumentos = from tipoDeDocumentos in mapaEntidades.TipoDocumentos
                                                           select tipoDeDocumentos;
            try
            {
                foreach (var tipoDocumento in tiposDeDocumentos)
                {
                    ETipoDeDocumento tipo = new ETipoDeDocumento();
                    tipo.nombre = tipoDocumento.nombre;
                    tipo.idTipoDeDocumento = tipoDocumento.idTipoDocumento;
                    tiposDNI.Add(tipo);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return tiposDNI;
        }
        //Metodo para buscar barrios y localidades
        public static List<EBarrio> BuscarBarrios()
        {
            List<EBarrio> barrios = new List<EBarrio>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Barrios> consulta = from BarriosDB in mapaEntidades.Barrios
                                           select BarriosDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EBarrio barrio = new EBarrio();
                    barrio.idBarrio = registro.idBarrio;
                    barrio.nombre = registro.nombre;
                    barrio.idLocalidad = (int)registro.idLocalidad;
                    barrios.Add(barrio);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return barrios;
        }
        //fin metodo
        //metodo para buscar una localidad
        public static List<ELocalidad> BuscarLocalidades()
        {
            List<ELocalidad> localidades = new List<ELocalidad>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Localidades> consulta = from LocalidadesDB in mapaEntidades.Localidades
                                               select LocalidadesDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ELocalidad localidad = new ELocalidad();
                    localidad.idLocalidad = registro.idLocalidad;
                    localidad.nombre = registro.nombre;
                    localidades.Add(localidad);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return localidades;
        }
        //metodo parabusar estados
        public static List<EEstados> BuscarEstados()
        {
            List<EEstados> estados = new List<EEstados>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Estados> consulta = from EstadosDB in mapaEntidades.Estados
                                           select EstadosDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EEstados estado = new EEstados();
                    estado.idEstado = registro.idEstado;
                    estado.nombreEstado = registro.nombreEstado;
                    estados.Add(estado);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return estados;
        }
        //fin metodo
        //metodo para buscar colores
        public static List<EColor> BuscarColores()
        {
            List<EColor> colores = new List<EColor>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Colores> consulta = from coloresDB in mapaEntidades.Colores
                                           select coloresDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EColor color = new EColor();
                    color.idColor = registro.idColor;
                    color.nombreColor = registro.nombreColor;
                    colores.Add(color);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return colores;
        }
        //fin metodo
        //metodo para buscar especies
        public static List<EEspecie> BuscarEspecies()
        {
            List<EEspecie> especies = new List<EEspecie>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Especies> consulta = from especiesDB in mapaEntidades.Especies
                                           select especiesDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EEspecie especie = new EEspecie();
                    especie.idEspecie = registro.idEspecie;
                    especie.nombreEspecie = registro.nombreEspecie;
                    especies.Add(especie);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return especies;
        }
        //fin metodo
        //metodo para buscar razas
        public static List<ERaza> BuscarRazas(int idRaza){
            List<ERaza> razas = new List<ERaza>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Razas> consulta = from razaDB in mapaEntidades.Razas
                                         where(razaDB.idEspecie == idRaza)
                                         select razaDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ERaza raza = new ERaza();
                    raza.idRaza = registro.idRaza;
                    raza.nombreRaza = registro.nombreRaza;
                    razas.Add(raza);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return razas;
        }
        //fin metodo
        //metodo para bucar las edades
        public static List<EEdad> BuscarEdades()
        {
            List<EEdad> edades = new List<EEdad>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Edades> consulta = from edadDB in mapaEntidades.Edades
                                          select edadDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EEdad edad = new EEdad();
                    edad.idEdad = registro.idEdad;
                    edad.nombreEdad = registro.nombreEdad;
                    edades.Add(edad);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return edades;
        }
        //fin metodo
        //metodo para buscar categorias
        public static List<ECategoriaRaza> BuscarCategoriasDeRazas()
        {
            List<ECategoriaRaza> categorias = new List<ECategoriaRaza>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<CategoriaRazas> consulta = from categoriazRazaDB in mapaEntidades.CategoriaRazas
                                                  select categoriazRazaDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ECategoriaRaza categoriaRaza = new ECategoriaRaza();
                    categoriaRaza.idCategoriaRaza = registro.idCategoriaRazas;
                    categoriaRaza.nombreCategoriaRaza = registro.nombreCategoriaRaza;
                    categorias.Add(categoriaRaza);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return categorias;
        }
        //fin metodo
    }
}
