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
        //metodopara buscar los sexos
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
    }
}
