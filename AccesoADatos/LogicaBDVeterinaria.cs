﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;
namespace AccesoADatos
{
    public class LogicaBDVeterinaria
    {
        public static Boolean RegistrarVeterinaria(EVeterinaria veterinaria)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    Veterinarias veterinariaBD = new Veterinarias();
                    veterinariaBD.nombre = veterinaria.nombre;
                    veterinariaBD.peluqueria = veterinaria.peluqueria;
                    veterinariaBD.petShop = veterinaria.petshop;
                    veterinariaBD.medicina = veterinaria.medicina;
                    veterinariaBD.castraciones = veterinaria.castraciones;
                    veterinariaBD.web = veterinaria.contacto;
                    veterinariaBD.idBarrio = veterinaria.domicilio.barrio.idBarrio;
                    veterinariaBD.idCalle = veterinaria.domicilio.calle.idCalle;
                    veterinariaBD.nroCalle = veterinaria.domicilio.numeroCalle;
                    veterinariaBD.telefono = veterinaria.telefono;
                    mapa.AddToVeterinarias(veterinariaBD);
                    mapa.SaveChanges();
                    transaccion.Complete();
                    return true;
                }
                catch (Exception)
                {
                    transaccion.Dispose();
                    return false;
                }
            }
        }
        public static List<EVeterinaria> BuscarPorNombre(string nombre)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            try
            {
                List<EVeterinaria> veterinarias = new List<EVeterinaria>();
                var consulta = from VeterinariaBD in mapa.Veterinarias
                                                    where(VeterinariaBD.nombre.StartsWith(nombre))
                                                    select VeterinariaBD;
                foreach(var registro in consulta){
                    EVeterinaria veterinaria = new EVeterinaria();
                    veterinaria.id = registro.idVeterinaria;
                    veterinaria.nombre = registro.nombre;
                }
                return veterinarias;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public static List<EVeterinaria> BuscarPorDomicilio(EVeterinaria veterinaria)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            try
            {
                List<EVeterinaria> veterinarias = new List<EVeterinaria>();
                var consulta = from VeterinariaBD in mapa.Veterinarias
                                                    where(VeterinariaBD.idBarrio == veterinaria.domicilio.barrio.idBarrio ||  VeterinariaBD.idCalle == veterinaria.domicilio.calle.idCalle)
                                                    select VeterinariaBD;
                foreach(var registro in consulta){
                    veterinaria = new EVeterinaria();
                    veterinaria.id = registro.idVeterinaria;
                    veterinaria.nombre = registro.nombre;
                }
                return veterinarias;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public static void Buscar(EVeterinaria veterinaria)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            try
            {
                var consulta = from VeterinariaBD in mapa.Veterinarias
                               join BarrioBD in mapa.Barrios on VeterinariaBD.idBarrio equals BarrioBD.idBarrio into group1
                               from G1 in group1.DefaultIfEmpty()
                               join LocalidadBD in mapa.Localidades on G1.idLocalidad equals LocalidadBD.idLocalidad into group2
                               from G2 in group2.DefaultIfEmpty()
                               where (VeterinariaBD.idVeterinaria == veterinaria.id)
                               select new
                               {
                                   veterinaria = VeterinariaBD,
                                   localidad = G2,
                                   barrio = G1,
                               };
                foreach(var registro in consulta){
                    veterinaria = new EVeterinaria();
                    veterinaria.id = registro.veterinaria.idVeterinaria;
                    veterinaria.nombre = registro.veterinaria.nombre;
                    veterinaria.castraciones = (registro.veterinaria.castraciones == null) ? false : (bool)registro.veterinaria.castraciones;
                    veterinaria.contacto = registro.veterinaria.web;
                    veterinaria.domicilio.barrio = new EBarrio();
                    veterinaria.domicilio.barrio.idBarrio = registro.barrio.idBarrio;
                    veterinaria.domicilio.barrio.localidad = new ELocalidad();
                    veterinaria.domicilio.barrio.localidad.idLocalidad = registro.localidad.idLocalidad;
                    veterinaria.domicilio.calle = new ECalle();
                    veterinaria.domicilio.calle.idCalle = registro.veterinaria.idCalle;
                    veterinaria.id = registro.veterinaria.idVeterinaria;
                    veterinaria.medicina = (registro.veterinaria.medicina == null) ? false : (bool)registro.veterinaria.medicina;
                    veterinaria.peluqueria = (registro.veterinaria.peluqueria == null) ? false : (bool)registro.veterinaria.peluqueria;
                    veterinaria.petshop = (registro.veterinaria.petShop == null) ? false : (bool)registro.veterinaria.petShop;
                    veterinaria.telefono = (registro.veterinaria.telefono == null) ? "" : registro.veterinaria.telefono;   
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    
    }
}
