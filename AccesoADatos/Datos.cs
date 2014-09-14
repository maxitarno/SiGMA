﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;
namespace AccesoADatos
{
    public class Datos
    {
        //Mi metodo para buscar los tipos de documentos
        public static List<ETipoDeDocumento> TiposDNI()
        {
            List<ETipoDeDocumento> tiposDNI = new List<ETipoDeDocumento>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
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
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Barrios> consulta = from BarriosDB in mapaEntidades.Barrios
                                           select BarriosDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EBarrio barrio = new EBarrio();
                    barrio.idBarrio = registro.idBarrio;
                    barrio.nombre = registro.nombre;
                    barrio.localidad = new ELocalidad();
                    barrio.localidad.idLocalidad = (int)registro.idLocalidad;
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
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
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
        public static List<EEstado> BuscarEstados()
        {
            List<EEstado> estados = new List<EEstado>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Estados> consulta = from EstadosDB in mapaEntidades.Estados
                                           select EstadosDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EEstado estado = new EEstado();
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
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
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
            catch (System.Data.EntityException exc)
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
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
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
        public static List<ERaza> BuscarRazas(int idEspecie)
        {
            List<ERaza> razas = new List<ERaza>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Razas> consulta = from razaDB in mapaEntidades.Razas
                                         where (razaDB.idEspecie == idEspecie)
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
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Edades> consulta = from edadDB in mapaEntidades.Edades
                                          select edadDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EEdad edad = new EEdad();
                    edad.idEdad = registro.idEdad;
                    edad.nombreEdad = registro.nombreEdad;
                    edad.descripcion = registro.descripcion;
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
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
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
        public static List<ERaza> BuscarRazas()
        {
            List<ERaza> razas = new List<ERaza>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Razas> consulta = from razaDB in mapaEntidades.Razas
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

        public static List<ECaracterMascota> BuscarCaracteresMascota()
        {
            List<ECaracterMascota> caracterMascotas = new List<ECaracterMascota>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<CaracteresMascota> consulta = from caracteresDB in mapaEntidades.CaracteresMascota
                                                     select caracteresDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ECaracterMascota caracter = new ECaracterMascota();
                    caracter.idCaracter = registro.idCaracter;
                    caracter.descripcion = registro.descripcion;
                    caracterMascotas.Add(caracter);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return caracterMascotas;
        }
        //Metodo para buscar barrios y localidades
        public static List<EBarrio> BuscarBarrios(int idLocalidad)
        {
            List<EBarrio> barrios = new List<EBarrio>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Barrios> consulta = from BarriosDB in mapaEntidades.Barrios
                                           where (BarriosDB.idLocalidad == idLocalidad)
                                           select BarriosDB;
            try
            {
                foreach (var registro in consulta)
                {
                    EBarrio barrio = new EBarrio();
                    barrio.idBarrio = registro.idBarrio;
                    barrio.nombre = registro.nombre;
                    barrio.localidad = new ELocalidad();
                    barrio.localidad.idLocalidad = (int)registro.idLocalidad;
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
        public static List<ETipoDeDocumento> TiposDNI(string tipo)
        {
            List<ETipoDeDocumento> tiposDNI = new List<ETipoDeDocumento>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<TipoDocumentos> tiposDeDocumentos = from tipoDeDocumentos in mapaEntidades.TipoDocumentos
                                                           where (tipoDeDocumentos.nombre.Contains(tipo))
                                                           select tipoDeDocumentos;
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    foreach (var tipoDocumento in tiposDeDocumentos)
                    {
                        ETipoDeDocumento tipoD = new ETipoDeDocumento();
                        tipoD.nombre = tipoDocumento.nombre;
                        tipoD.idTipoDeDocumento = tipoDocumento.idTipoDocumento;
                        tiposDNI.Add(tipoD);
                    }
                }
                catch (System.Data.EntityCommandCompilationException exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
                return tiposDNI;
            }
        }
        public static Boolean guardarTipoDocumento(ETipoDeDocumento tipo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    TipoDocumentos tipoDB = new TipoDocumentos();
                    tipoDB.nombre = tipo.nombre;
                    mapaEntidades.AddToTipoDocumentos(tipoDB);
                    mapaEntidades.SaveChanges();
                    transaction.Complete();
                    return true;
                }
                catch (Exception exc)
                {

                    transaction.Dispose();
                    return false;
                    throw exc;
                }
            }
        }
        public static Boolean ModificarTipoDeDocumento(ETipoDeDocumento tipo)
        {
            bool b = false;
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    var tipoDocumento = mapaEntidades.TipoDocumentos.Where( tipoDB => tipoDB.idTipoDocumento == tipo.idTipoDeDocumento);
                    foreach (var registro in tipoDocumento)
                    {
                        registro.nombre = tipo.nombre;
                    }
                    b = true;
                    mapaEntidades.SaveChanges();
                }
                catch (Exception exc)
                {
                    throw exc;
                    b = false;
                }
                return b;
            }
        /*public static Boolean EliminarTiposDNI(ETipoDeDocumento tipo)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            bool b = false;
            IQueryable<TipoDocumentos> tiposDeDocumentos = from tipoDeDocumentos in mapaEntidades.TipoDocumentos
                                                           where (tipoDeDocumentos.idTipoDocumento == tipo.idTipoDeDocumento)
                                                           select tipoDeDocumentos;
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    TipoDocumentos tipoDB = new TipoDocumentos();
                    foreach (var registro in tiposDeDocumentos)
                    {
                        tipoDB.idTipoDocumento = registro.idTipoDocumento;
                        tipoDB.nombre = registro.nombre;
                    }
                    mapaEntidades.DeleteObject(tipoDB);
                    mapaEntidades.DetectChanges();
                    mapaEntidades.SaveChanges();
                    return true;
                }
                catch (System.Data.EntityCommandCompilationException exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
            }
        }*/
        public static List<ERaza> BuscarRazas(int idEspecie, string nombre)
        {
            List<ERaza> razas = new List<ERaza>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Razas> consulta = from razaDB in mapaEntidades.Razas
                                         where (razaDB.idEspecie == idEspecie && razaDB.nombreRaza.Contains(nombre))
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
        public static ERaza BuscarRaza(int id)
        {
            ERaza raza = new ERaza();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from razaDB in mapaEntidades.Razas
                           from categoriaRazaDB in mapaEntidades.CategoriaRazas
                           from cuidadoDB in mapaEntidades.CuidadosEspeciales
                           where (razaDB.idRaza == id && razaDB.idCuidadoEspecial == cuidadoDB.idCuidadoEspecial && razaDB.idCategoriaRaza == categoriaRazaDB.idCategoriaRazas)
                           select new
                           {
                               idRaza = razaDB.idRaza,
                               nombre = razaDB.nombreRaza,
                               categoria = razaDB.idCategoriaRaza,
                               cuidado = razaDB.idCuidadoEspecial,
                               peso = razaDB.PesoRaza,
                               idEspecie = razaDB.idEspecie
                           };
            try
            {
                foreach (var registro in consulta)
                {
                    raza.nombreRaza = registro.nombre;
                    raza.idCategoriaRaza = (int)registro.categoria;
                    raza.idcuidadoEspecial = (int)registro.cuidado;
                    raza.idRaza = registro.idRaza;
                    raza.pesoRaza = registro.peso;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return raza;
        }
        public static List<ECuidado> BuscarCuidado()
        {
            List<ECuidado> cuidados = new List<ECuidado>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<CuidadosEspeciales> consulta = from CuidadoDB in mapaEntidades.CuidadosEspeciales
                                                  select CuidadoDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ECuidado cuidado = new ECuidado();
                    cuidado.idCuidado = registro.idCuidadoEspecial;
                    cuidado.descripcion = registro.descripcion;
                    cuidados.Add(cuidado);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return cuidados;
        }
        public static List<ECalle> BuscarCalle()
        {
            List<ECalle> calles = new List<ECalle>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Calles> consulta = from callesDB in mapaEntidades.Calles
                                         select callesDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ECalle calle = new ECalle();
                    calle.nombre = registro.nombre;
                    calle.idLocalidad = (int)registro.idLocalidad;
                    calle.idCalle = registro.idCalle;
                    calles.Add(calle);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return calles;
        }
        public static List<ECalle> BuscarCalle(int localidad)
        {
            List<ECalle> calles = new List<ECalle>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Calles> consulta = from callesDB in mapaEntidades.Calles
                                          where(callesDB.idLocalidad == localidad)
                                          select callesDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ECalle calle = new ECalle();
                    calle.nombre = registro.nombre;
                    calle.idLocalidad = (int)registro.idLocalidad;
                    calle.idCalle = registro.idCalle;
                    calles.Add(calle);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return calles;
        }
    }
}
