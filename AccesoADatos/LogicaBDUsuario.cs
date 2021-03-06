﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Entidades;
namespace AccesoADatos
{
    public class LogicaBDUsuario
    {
        public static Boolean guardarUsuario(EDuenio duenio, EUsuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    LogicaBDToken token = new LogicaBDToken();
                    var tokenNuevoUsuario = token.GenerarToken(4, 10);
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Usuarios userBD = new Usuarios();
                    userBD.user = usuario.user;
                    userBD.password = usuario.password;
                    userBD.estado = usuario.estado;
                    userBD.token = tokenNuevoUsuario;
                    mapaEntidades.AddToUsuarios(userBD);
                    mapaEntidades.SaveChanges();
                    ERol rolDuenio = LogicaBDRol.ObtenerRol("Dueño");
                    RolesXUsuario rolesXUserBD = new RolesXUsuario();
                    rolesXUserBD.idRol = rolDuenio.idRol;
                    rolesXUserBD.user = usuario.user;
                    mapaEntidades.AddToRolesXUsuario(rolesXUserBD);
                    mapaEntidades.SaveChanges();
                    Personas personBD = new Personas();
                    personBD.nombre = duenio.nombre;
                    personBD.apellido = duenio.apellido;
                    personBD.idTipoDocumento = duenio.tipoDocumento.idTipoDeDocumento;
                    personBD.nroDocumento = duenio.nroDocumento;
                    personBD.email = duenio.email;
                    personBD.user = duenio.usuario.user;
                    mapaEntidades.AddToPersonas(personBD);
                    mapaEntidades.SaveChanges();
                    Duenios duenioBD = new Duenios();
                    duenioBD.idPersona = personBD.idPersona;
                    mapaEntidades.AddToDuenios(duenioBD);
                    mapaEntidades.SaveChanges();
                    transaction.Complete();
                    return true;
                }
                catch (Exception exc)
                {

                    transaction.Dispose();
                    throw exc;
                }      
            }
        }
        //metodo para buscar el usuario por nombre
        public static List<EUsuario> BuscarUsuarios(string nombre)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> aux = from usuariosBuscados in mapaEntidades.Usuarios
                                       where (usuariosBuscados.user.Contains(nombre) && usuariosBuscados.estado == true)
                                       select usuariosBuscados;
            try
            {
                foreach (var usuarioBD in aux)
                {
                    EUsuario usuario = new EUsuario();
                    usuario.user = usuarioBD.user;
                    usuario.token = usuarioBD.token;
                    usuarios.Add(usuario);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            if (usuarios.Count == 0)
            {
                EUsuario usuario = new EUsuario();
                usuarios.Add(usuario);
            }
            return usuarios;
        }
        //fin del metodo
        //metodo para buscar el usuario por email
        public static List<EUsuario> BuscarUsuarioPorEmail(string email)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            LogicaBDToken token = new LogicaBDToken();
            var tokenPassword = token.GenerarToken(6, 12);
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> consulta = from personasBD in mapaEntidades.Personas
                                            from usuariosBD in mapaEntidades.Usuarios
                                            where (personasBD.email == email && usuariosBD.estado == true && usuariosBD.user == personasBD.user)
                                            select usuariosBD;
            try
            {
                foreach (var usuarioBD in consulta)
                {
                    usuarioBD.password = tokenPassword;
                    EUsuario usuario = new EUsuario();
                    usuario.user = usuarioBD.user;
                    usuario.password = tokenPassword;
                    usuarios.Add(usuario);
                }
                mapaEntidades.SaveChanges();
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return usuarios;
        }
        //fin del metodo
        //metodo para buscar usuarios por tipo y nº de documento
        public static List<EUsuario> BuscarUsuarios(int tipo, string dni)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> consulta = from personasBD in mapaEntidades.Personas
                                            from usuariosBD in mapaEntidades.Usuarios
                                            where (personasBD.user == usuariosBD.user && personasBD.nroDocumento == dni && personasBD.idTipoDocumento == tipo && usuariosBD.estado == true)
                                            select usuariosBD;
            try
            {
                foreach (var usuarioBD in consulta)
                {
                    EUsuario usuario = new EUsuario();
                    usuario.user = usuarioBD.user;
                    usuarios.Add(usuario);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return usuarios;
        }
        //fin metodo
        //metodo para buscar persona
        public static void BuscarUsuarios(string nombre, EUsuario user, EPersona persona, EBarrio barrio, ELocalidad localidad, ETipoDeDocumento tipoDoc, ECalle calle)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta1 = from usuariosBD in mapaEntidades.Usuarios join personasBD in mapaEntidades.Personas
                           on usuariosBD.user equals personasBD.user into group1
                           from G1 in group1.DefaultIfEmpty()
                           join barriosBD in mapaEntidades.Barrios on G1.idBarrio equals barriosBD.idBarrio into group2
                           from G2 in group2.DefaultIfEmpty()
                           join localidadesBD in mapaEntidades.Localidades on G2.idLocalidad equals localidadesBD.idLocalidad into group3
                           from G3 in group3.DefaultIfEmpty()
                           join calleBD in mapaEntidades.Calles on G1.idCalle equals calleBD.idCalle into group4
                           from G4 in group4.DefaultIfEmpty()
                           join TipoBD in mapaEntidades.TipoDocumentos on G1.idTipoDocumento equals TipoBD.idTipoDocumento into group5
                           from G5 in group5.DefaultIfEmpty()
                           where (G1.user == nombre && usuariosBD.estado == true)
                           select new 
                           {
                               user = usuariosBD,
                               persona = G1,
                               barrio = G2,
                               localidad = G3,
                               calle = G4,
                               tipo = G5,
                            };
            try
            {
                foreach (var usuario in consulta1)
                {
                    persona.apellido = usuario.persona.apellido;
                    persona.nombre = usuario.persona.nombre;
                    barrio.idBarrio = (usuario.barrio == null) ? 0 : usuario.barrio.idBarrio;
                    persona.email = usuario.persona.email;
                    persona.fechaNacimiento = usuario.persona.fechaNacimiento;
                    persona.nroDocumento = usuario.persona.nroDocumento;
                    tipoDoc.idTipoDeDocumento = usuario.persona.idTipoDocumento;
                    persona.telefonoFijo = usuario.persona.telefonoFijo;
                    persona.telefonoCelular = usuario.persona.telefonoCelular;
                    localidad.idLocalidad = (usuario.localidad == null) ? 0 : usuario.localidad.idLocalidad;
                    user.user = usuario.persona.user;
                    persona.idPersona = usuario.persona.idPersona;
                    persona.nroCalle = usuario.persona.nroCalle;
                    calle.idCalle = usuario.persona.idCalle;
                    calle.nombre = (usuario.persona.Calles == null) ? "" : usuario.persona.Calles.nombre;
                    if (usuario.localidad != null)
                        localidad.nombre = usuario.localidad.nombre;
                    else
                        localidad.nombre = "";
                    barrio.nombre = (usuario.barrio == null) ? "" : usuario.barrio.nombre;
                    tipoDoc.nombre = usuario.tipo.nombre;
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
        }
        //fin metodo
        //metodo para modificar un usuario
        public static bool ModificarUsuario(EPersona persona, EUsuario usuario)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                
                var personas = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user == usuario.user);
                var usuarios = mapaEntidades.Usuarios.Where(usuariobuscado => usuariobuscado.user == usuario.user);
                foreach (var registro in personas)
                {
                    registro.apellido = persona.apellido;
                    registro.idCalle = persona.domicilio.idCalle;
                    registro.email = persona.email;
                    registro.fechaNacimiento = persona.fechaNacimiento;
                    registro.idBarrio = persona.barrio.idBarrio;
                    registro.idTipoDocumento = persona.tipoDocumento.idTipoDeDocumento;
                    registro.nombre = persona.nombre;
                    registro.nroDocumento = persona.nroDocumento;
                    registro.telefonoCelular = persona.telefonoCelular;
                    registro.telefonoFijo = persona.telefonoFijo;
                    registro.nroCalle = persona.nroCalle;
                }
                b = true;
                mapaEntidades.SaveChanges();
            }
            catch (InvalidOperationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        public static bool ModificarContraseñaUsuario(EUsuario usuario)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var usuarios = mapaEntidades.Usuarios.Where(usuariobuscado => usuariobuscado.user == usuario.user);
                Usuarios userBD = usuarios.First();
                userBD.password = usuario.password;
                b = true;
                mapaEntidades.SaveChanges();
            }
            catch (InvalidOperationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        public static bool EliminarUsuario(string usuario)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            bool b = false;
            IQueryable<Usuarios> aux = from usuariosBD in mapaEntidades.Usuarios
                                       where (usuariosBD.user == usuario)
                                       select usuariosBD;
            if (aux.Count<Usuarios>() != 0)
            {
                try
                {
                    var usuarios = mapaEntidades.Usuarios.Where(usuarioBuscado => usuarioBuscado.user == usuario).Single();
                    foreach (var registro in aux)
                    {
                        registro.estado = false;
                    }
                    mapaEntidades.DetectChanges();
                    mapaEntidades.SaveChanges(System.Data.Objects.SaveOptions.DetectChangesBeforeSave);
                    b = true;
                }
                catch (System.Data.UpdateException exc)
                {
                    b = false;
                    throw exc;
                }
                catch (System.InvalidOperationException exc)
                {
                    b = false;
                    throw exc;
                }
            }
            else
            {
                b = false;
            }
            return b;
        }
       public static void BuscarUsuarios(string nombre, EUsuario user, EPersona persona, EBarrio barrio, ELocalidad localidad, ETipoDeDocumento tipoDoc, ECalle calle, EDuenio duenio)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta1 = from usuariosBD in mapaEntidades.Usuarios join personasBD in mapaEntidades.Personas
                           on usuariosBD.user equals personasBD.user into group1
                           from G1 in group1.DefaultIfEmpty()
                           join barriosBD in mapaEntidades.Barrios on G1.idBarrio equals barriosBD.idBarrio into group2
                           from G2 in group2.DefaultIfEmpty()
                           join localidadesBD in mapaEntidades.Localidades on G2.idLocalidad equals localidadesBD.idLocalidad into group3
                           from G3 in group3.DefaultIfEmpty()
                           join calleBD in mapaEntidades.Calles on G1.idCalle equals calleBD.idCalle into group4
                           from G4 in group4.DefaultIfEmpty()
                           join dueniosBD in mapaEntidades.Duenios on G1.idPersona equals dueniosBD.idPersona into group5
                           from G5 in group5.DefaultIfEmpty()
                           join tipoDocBD in mapaEntidades.TipoDocumentos on G1.idTipoDocumento equals tipoDocBD.idTipoDocumento into group6
                           from G6 in group6.DefaultIfEmpty()
                           where (G1.user == nombre && usuariosBD.estado == true)
                           select new 
                           {
                               user = usuariosBD,
                               persona = G1,
                               barrio = G2,
                               localidad = G3,
                               calle = G4,
                               duenio = G5,
                               tipoDoc = G6
                            };
            try
            {
                foreach (var usuario in consulta1)
                {
                    persona.apellido = usuario.persona.apellido;
                    persona.nombre = usuario.persona.nombre;
                    barrio.idBarrio = (usuario.barrio == null) ? 0 : usuario.barrio.idBarrio;
                    persona.email = usuario.persona.email;
                    persona.fechaNacimiento = usuario.persona.fechaNacimiento;
                    persona.nroDocumento = usuario.persona.nroDocumento;
                    tipoDoc.idTipoDeDocumento = usuario.persona.idTipoDocumento;
                    persona.telefonoFijo = usuario.persona.telefonoFijo;
                    persona.telefonoCelular = usuario.persona.telefonoCelular;
                    localidad.idLocalidad = (usuario.localidad == null) ? 0 : usuario.localidad.idLocalidad;
                    user.user = usuario.persona.user;
                    persona.idPersona = usuario.persona.idPersona;
                    persona.nroCalle = usuario.persona.nroCalle;
                    calle.idCalle = (usuario.persona.Calles == null) ? 0 : usuario.persona.Calles.idCalle;
                    calle.nombre = (usuario.persona.Calles == null) ? "" : usuario.persona.Calles.nombre;
                    localidad.nombre = (usuario.localidad == null) ? "" : usuario.localidad.nombre;
                    barrio.nombre = (usuario.barrio == null) ? "" : usuario.barrio.nombre;
                    duenio.idDuenio = usuario.duenio.idDuenio;
                    tipoDoc.nombre = usuario.tipoDoc.nombre;
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
        }
       public static List<EUsuario> BuscarUsuariosDuenio(string nombre)
       {
           List<EUsuario> usuarios = new List<EUsuario>();
           SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
           IQueryable<Usuarios> aux = from usuariosBuscados in mapaEntidades.Usuarios
                                      from personasBuscadas in mapaEntidades.Personas
                                      from DuenioBuscados in mapaEntidades.Duenios
                                      where (usuariosBuscados.user.Contains(nombre) && usuariosBuscados.estado == true && usuariosBuscados.user == personasBuscadas.user && personasBuscadas.idPersona == DuenioBuscados.idPersona)
                                      select usuariosBuscados;
           try
           {
               foreach (var usuarioBD in aux)
               {
                   EUsuario usuario = new EUsuario();
                   usuario.user = usuarioBD.user;
                   usuarios.Add(usuario);
               }
           }
           catch (System.Data.EntityCommandCompilationException exc)
           {
               throw exc;
           }
           return usuarios;
       }
       //fin del metodo
       //metodo para buscar usuarios por tipo y nº de documento
       public static List<EUsuario> BuscarUsuariosDuenio(int tipo, string dni)
       {
           List<EUsuario> usuarios = new List<EUsuario>();
           SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
           IQueryable<Usuarios> consulta = from personasBD in mapaEntidades.Personas
                                           from usuariosBD in mapaEntidades.Usuarios
                                           from DuenioBuscados in mapaEntidades.Duenios
                                           where (personasBD.idPersona == DuenioBuscados.idPersona && personasBD.user == usuariosBD.user && personasBD.nroDocumento == dni && personasBD.idTipoDocumento == tipo && usuariosBD.estado == true)
                                           select usuariosBD;
           try
           {
               foreach (var usuarioBD in consulta)
               {
                   EUsuario usuario = new EUsuario();
                   usuario.user = usuarioBD.user;
                   usuarios.Add(usuario);
               }
           }
           catch (System.Data.EntityCommandCompilationException exc)
           {
               throw exc;
           }
           return usuarios;
       }
        //fin metodo
        //metodo para Validacion de Usuario por Token
        public static void ValidarUsuario(string usuario)
        {
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var usuarios = mapaEntidades.Usuarios.Where(usuariobuscado => usuariobuscado.user == usuario);
                foreach (var registro in usuarios)
                {
                    registro.token = null;
                }
                mapaEntidades.SaveChanges();
            }
            catch (InvalidOperationException exc)
            {
                throw exc;
            }
        }

        public static bool verificarDomicilioRegistrado(string usuario)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Personas> consulta = from personasBD in mapaEntidades.Personas                                            
                                            where (personasBD.user == usuario && personasBD.idBarrio != null 
                                            && personasBD.idCalle != null && personasBD.nroCalle != null)
                                            select personasBD;
            try
            {
                if (consulta.Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }           
        }

        public static bool verificarContraseña(string usuario, string contra)
        {
            bool a = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var usuarios = mapaEntidades.Usuarios.Where(usuariobuscado => usuariobuscado.user == usuario);
                foreach (var registro in usuarios)
                {
                    if (registro.password == contra)
                        a = true;
                }
            }
            catch (InvalidOperationException exc)
            {
                return a;
            }
            return a;
        }

        public static EPersona buscarPersonaPorUsuario(string usuario, EPersona persona, EBarrio barrio, ECalle calle) 
        {
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var personas = from personasBD in mapaEntidades.Personas
                               //join barrioBD in mapaEntidades.Barrios on personasBD.idBarrio equals barrioBD.idBarrio
                               //join calleBD in mapaEntidades.Calles on personasBD.idCalle equals calleBD.idCalle
                               where (personasBD.user == usuario)
                                select new
                                {
                                    apellido = personasBD.apellido,
                                    nombre = personasBD.nombre,
                                    email = personasBD.email,
                                    fechaNacimiento = personasBD.fechaNacimiento,
                                    idPersona = personasBD.idPersona,
                                    telefonoCelular = personasBD.telefonoCelular,
                                    telefonoFijo = personasBD.telefonoFijo,
                                    nroDocumento = personasBD.nroDocumento,
                                    calle = personasBD.idCalle,
                                    nroCalle = personasBD.nroCalle,
                                    barrio = personasBD.idBarrio,
                                };

                    foreach (var registro in personas)
                        {
                            persona.email = registro.email;
                            persona.fechaNacimiento = registro.fechaNacimiento;
                            persona.idPersona = registro.idPersona;
                            persona.nroCalle = registro.nroCalle;
                            persona.nroDocumento = registro.nroDocumento;
                            persona.telefonoCelular = registro.telefonoCelular;
                            persona.telefonoFijo = registro.telefonoFijo;
                            persona.nombre = registro.nombre + ' ' + registro.apellido;
                            persona.email = registro.email;
                            persona.nroCalle = registro.nroCalle;
                            calle.idCalle = registro.calle;
                            barrio.idBarrio = registro.barrio;
                        }
                }
                catch (System.Data.EntityCommandCompilationException exc)
                {
                    throw exc;
                }
                return persona;
        }

        //metodo para buscar usuarios por nombre de persona
        public static EPersona BuscarUsuariosPorNombrePersona(string nombre)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            EPersona persona = new EPersona();
            try{
                var consulta = from personasBD in mapaEntidades.Personas
                                            from usuariosBD in mapaEntidades.Usuarios
                                            where (personasBD.user == usuariosBD.user && personasBD.nombre == nombre && usuariosBD.estado == true)
                                            select new
                                            {
                                                apellido = personasBD.apellido,
                                                nombre = personasBD.nombre,
                                                email = personasBD.email,
                                                fechaNacimiento = personasBD.fechaNacimiento,
                                                idPersona = personasBD.idPersona,
                                                telefonoCelular = personasBD.telefonoCelular,
                                                telefonoFijo = personasBD.telefonoFijo,
                                                nroDocumento = personasBD.nroDocumento,
                                                calle = personasBD.idCalle,
                                                nroCalle = personasBD.nroCalle,
                                                barrio = personasBD.idBarrio,
                                            };
                    foreach (var registro in consulta)
                        {
                            persona.barrio = new EBarrio();
                            persona.domicilio = new ECalle();
                            persona.email = registro.email;
                            persona.fechaNacimiento = registro.fechaNacimiento;
                            persona.idPersona = registro.idPersona;
                            persona.nroCalle = registro.nroCalle;
                            persona.nroDocumento = registro.nroDocumento;
                            persona.telefonoCelular = registro.telefonoCelular;
                            persona.telefonoFijo = registro.telefonoFijo;
                            persona.nombre = registro.nombre + ' ' + registro.apellido;
                            persona.email = registro.email;
                            persona.nroCalle = registro.nroCalle;
                            persona.domicilio.idCalle = registro.calle;
                            persona.barrio.idBarrio = registro.barrio;
                        }
                }
                catch (System.Data.EntityCommandCompilationException exc)
                {
                    throw exc;
                }
                return persona;
        }
        //fin metodo
    }
}