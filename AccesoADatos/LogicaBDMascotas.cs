﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;
namespace AccesoADatos
{
    public class LogicaBDMascotas
    {
        public static void registrarMascota(EMascota mascota, byte[] imagen)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Mascotas bdMascota = new Mascotas();
                    bdMascota.idEstado = mascota.estado.idEstado;
                    bdMascota.nombreMascota = mascota.nombreMascota;
                    bdMascota.idEspecie = mascota.especie.idEspecie;
                    bdMascota.idRaza = mascota.raza.idRaza;                   
                    bdMascota.idEdad = mascota.edad.idEdad;
                    bdMascota.idColor = mascota.color.idColor;
                    bdMascota.idDuenio = mascota.duenio.idDuenio;
                    if (mascota.caracter.idCaracter != 0)
                    {
                        bdMascota.idCaracter = mascota.caracter.idCaracter;
                    }
                    if (!mascota.tratoAnimal.Equals("0"))
                    {
                        bdMascota.tratoAnimales = mascota.tratoAnimal;
                    }
                    if (!mascota.tratoNiños.Equals("0"))
                    {
                        bdMascota.tratoNinios = mascota.tratoNiños;
                    }
                    if (!mascota.observaciones.Equals(""))
                    {
                        bdMascota.observaciones = mascota.observaciones;
                    }
                    if (!mascota.alimentacionEspecial.Equals(""))
                    {
                        bdMascota.alimentacionEspecial = mascota.alimentacionEspecial;
                    }
                    if (!mascota.fechaNacimiento.Equals(new DateTime()))
                    {
                        bdMascota.fechaNacimiento = mascota.fechaNacimiento.Date;
                    }
                    bdMascota.sexo = mascota.sexo;
                    mapaEntidades.AddToMascotas(bdMascota);
                    mapaEntidades.SaveChanges();
                    if (imagen != null)
                    {
                        mascota.idMascota = mapaEntidades.Mascotas.OrderByDescending(m => m.idMascota).First().idMascota;
                        LogicaBDImagen.guardarImagen(imagen, mascota);
                    }
                    transaction.Complete();
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
            }
        }
        
        public static bool BuscarMascota(EMascota mascota, ECategoriaRaza categoria, ECaracterMascota caracter, ECuidado cuidado, int idMascota)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               from RazaBD in mapaEntidades.Razas
                               from CategoriaRazaBD in mapaEntidades.CategoriaRazas
                               from CaracterBD in mapaEntidades.CaracteresMascota
                               from CuidadoEspecialBD in mapaEntidades.CuidadosEspeciales
                               where (MascotasBD.idRaza == RazaBD.idRaza 
                               && CuidadoEspecialBD.idCuidadoEspecial == RazaBD.idCuidadoEspecial && RazaBD.idCategoriaRaza == CategoriaRazaBD.idCategoriaRazas 
                               && MascotasBD.idCaracter == CaracterBD.idCaracter && MascotasBD.idMascota == idMascota)
                               select new
                               {
                                   nombre = MascotasBD.nombreMascota,
                                   estado = MascotasBD.idEstado,
                                   especie = MascotasBD.idEspecie,
                                   edad = MascotasBD.idEdad,
                                   raza = MascotasBD.idRaza,
                                   color = MascotasBD.idColor,
                                   tratoA = MascotasBD.tratoAnimales,
                                   tratoN = MascotasBD.tratoNinios,
                                   observaciones = MascotasBD.observaciones,
                                   alimentacion = MascotasBD.alimentacionEspecial,
                                   fecha = MascotasBD.fechaNacimiento,
                                   sexo = MascotasBD.sexo,
                                   categoria = CategoriaRazaBD.nombreCategoriaRaza,
                                   caracter = CaracterBD.idCaracter,
                                   Cuidado = CuidadoEspecialBD.descripcion,
                                   id = MascotasBD.idMascota,
                                   imagen = MascotasBD.imagen
                               };
                foreach (var registro in consulta)
                {
                    mascota.alimentacionEspecial = registro.alimentacion;
                    caracter.idCaracter = registro.caracter;
                    categoria.nombreCategoriaRaza = registro.categoria;
                    mascota.raza = new ERaza();
                    mascota.raza.idRaza = registro.raza;
                    if (registro.fecha != null)
                    {
                        mascota.fechaNacimiento = (DateTime)registro.fecha;
                    }
                    mascota.color = new EColor();
                    mascota.color.idColor = registro.color;
                    mascota.nombreMascota = registro.nombre;
                    mascota.observaciones = registro.observaciones;
                    mascota.sexo = registro.sexo;
                    mascota.tratoAnimal = registro.tratoA;
                    mascota.tratoNiños = registro.tratoN;
                    cuidado.descripcion = registro.Cuidado;
                    mascota.idMascota = registro.id;
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = registro.edad;
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = registro.especie;
                    mascota.estado = new EEstado();
                    mascota.estado.idEstado = registro.estado;
                    if (registro.imagen != null){
                        mascota.imagen = registro.imagen;
                    }
                    else
                    {
                        mascota.imagen = null;
                    }
                }
                b = true;
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        public static List<EMascota> BuscarMascotaPorduenio(string duenio)
        {
            List<EMascota> mascotas = new List<EMascota>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas
                                            from DueniosBD in mapaEntidades.Duenios
                                            from PersonasBD in mapaEntidades.Personas
                                            where (DueniosBD.idPersona == PersonasBD.idPersona && MascotasBD.idDuenio == DueniosBD.idDuenio && PersonasBD.nombre.Contains(duenio))
                                            select MascotasBD;
            try
            {
                foreach (var registro in consulta)
                {
                    EMascota mascota = new EMascota();
                    mascota.nombreMascota = registro.nombreMascota;
                    mascota.idMascota = registro.idMascota;
                    mascotas.Add(mascota);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return mascotas;
        }

        public static List<EMascota> BuscarMascotaPorIdDueño(int idDueño)
        {
            List<EMascota> mascotas = new List<EMascota>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas
                                            from DueniosBD in mapaEntidades.Duenios
                                            from PersonasBD in mapaEntidades.Personas
                                            where (DueniosBD.idPersona == PersonasBD.idPersona && MascotasBD.idDuenio == DueniosBD.idDuenio && DueniosBD.idDuenio == idDueño)
                                            select MascotasBD;
            try
            {
                foreach (var registro in consulta)
                {
                    EMascota mascota = new EMascota();
                    mascota.nombreMascota = registro.nombreMascota;
                    mascota.idMascota = registro.idMascota;
                    mascotas.Add(mascota);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return mascotas;
        }

        public static bool ModificarMascota(EMascota mascota, byte[] imagen )
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = mapaEntidades.Mascotas.Where(mascotasBuscadas => mascotasBuscadas.idMascota == mascota.idMascota);
                foreach (var registro in consulta)
                {
                    registro.alimentacionEspecial = registro.alimentacionEspecial;
                    registro.idCaracter = mascota.caracter.idCaracter;
                    registro.idEdad = mascota.edad.idEdad;
                    registro.idEspecie = mascota.especie.idEspecie;
                    registro.idEstado = mascota.estado.idEstado;
                    registro.idRaza = mascota.raza.idRaza;
                    registro.nombreMascota = mascota.nombreMascota;
                    registro.observaciones = mascota.observaciones;
                    registro.idColor = mascota.color.idColor;
                    registro.sexo = mascota.sexo;
                    registro.tratoAnimales = mascota.tratoAnimal;
                    registro.tratoNinios = mascota.tratoNiños;
                    registro.idCaracter = mascota.caracter.idCaracter;
                }
                if (imagen != null)
                {
                    LogicaBDImagen.guardarImagen(imagen, mascota);
                    b = true;
                    mapaEntidades.SaveChanges();
                }
                else
                {
                    LogicaBDImagen.guardarImagen(null, mascota);
                    b = true;
                    mapaEntidades.SaveChanges();
                }
            }
            catch (InvalidOperationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        public static List<EMascota> BuscarMascotaPorMascota(string nombre)
        {
            List<EMascota> mascotas = new List<EMascota>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas                                            
                                            where (MascotasBD.nombreMascota.Contains(nombre))
                                            select MascotasBD;
            try
            {
                foreach (var registro in consulta)
                {
                    EMascota mascota = new EMascota();
                    mascota.nombreMascota = registro.nombreMascota;
                    mascota.idMascota = registro.idMascota;
                    mascotas.Add(mascota);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return mascotas;
        }
        public static bool Eliminar(int idMascota)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            bool b = false;
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas
                                            where ( MascotasBD.idMascota == idMascota)
                                            select MascotasBD;
            if(consulta.Count() != 0)
            {
                try
                {
                    var mascotas = mapaEntidades.Mascotas.Where( mascotasBuscadas => mascotasBuscadas.idMascota == idMascota).Single();
                    mapaEntidades.DeleteObject(mascotas);
                    mapaEntidades.DetectChanges();
                    mapaEntidades.SaveChanges();
                    b = true;
                }
                catch(System.Data.UpdateException exc){
                    b = false;
                    throw exc;
                }
            }
            return b;
        }
    }
}