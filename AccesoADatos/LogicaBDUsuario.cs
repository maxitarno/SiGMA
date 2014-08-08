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
        public static bool guardarUsuario(EDuenio duenio, EUsuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b;
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Usuarios userBD = new Usuarios();
                    userBD.user = usuario.user;
                    userBD.password = usuario.password;
                    userBD.idRol = 1;
                    mapaEntidades.AddToUsuarios(userBD);
                    mapaEntidades.SaveChanges();
                    Personas personBD = new Personas();                    
                    personBD.nombre = duenio.nombre;
                    personBD.apellido = duenio.apellido;
                    personBD.idTipoDocumento = duenio.idTipoDocumento;
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
                    b = true;
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    b = false;
                    throw exc;
                }
                return b;
            }
        }
        //Mi metodo para buscar los tipos dedocumentos
        public static List<ETipoDeDocumento> TiposDNI(){
            List<ETipoDeDocumento> tiposDNI = new List<ETipoDeDocumento>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<TipoDocumentos> tiposDeDocumentos = from tipoDocumentos in mapaEntidades.TipoDocumentos
                                                             select tipoDocumentos;
            foreach(var tipoDocumento in tiposDeDocumentos){
                ETipoDeDocumento tipo = new ETipoDeDocumento();
                tipo.tipoDNI = tipoDocumento.nombre;
                tipo.idTipoDeDocumento = tipoDocumento.idTipoDocumento;
                tiposDNI.Add(tipo);
            }
            return tiposDNI;
        }
        //fin del metodo
        //metodo para buscar el usuario por usuarios
        public static List<EUsuario> BuscarUsuarios(string nombre)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> aux = from usuariosBuscados in mapaEntidades.Usuarios
                                       where (usuariosBuscados.user.Contains(nombre)) 
                                       select usuariosBuscados;
            foreach (var usuarioBD in aux)
            {
                EUsuario usuario = new EUsuario();
                usuario.user = usuarioBD.user;
                usuarios.Add(usuario);
            }
            return usuarios;
        }
        //fin del metodo
        //metodo para busca usuarios por tipo y nº de documento
        public static List<EUsuario> BuscarUsuarios(int tipo, string dni)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> consulta = from personasBD in mapaEntidades.Personas
                                                from usuariosBD in mapaEntidades.Usuarios
                                                where ( personasBD.user == usuariosBD.user && personasBD.nroDocumento == dni && personasBD.idTipoDocumento == tipo )
                                                select usuariosBD;
            foreach (var usuarioBD in consulta)
            {
                EUsuario usuario = new EUsuario();
                usuario.user = usuarioBD.user;
                usuarios.Add(usuario);
            }
            return usuarios;
        }
        //fin metodo
        public static void BuscarUsuarios(string nombre, EUsuario user, EPersona persona){
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from personasBD in mapaEntidades.Personas
                           from usuariosBD in mapaEntidades.Usuarios
                           from rolesBD in mapaEntidades.Roles   
                           where (personasBD.user == usuariosBD.user && rolesBD.idRol == usuariosBD.idRol && personasBD.user == nombre)
                           select new{
                           apellido = personasBD.apellido,
                           nombre = personasBD.nombre,
                           tipoDNI = personasBD.idTipoDocumento,
                           dNI = personasBD.nroDocumento,
                           domicilio = personasBD.domicilio,
                           tEF = personasBD.telefonoFijo,
                           tEC = personasBD.telefonoCelular,
                           mail = personasBD.email,
                           usuario = usuariosBD.user,
                           rol = rolesBD.idRol,
                           };
            foreach (var usuario in consulta)
            {
                persona.apellido = usuario.apellido;
                persona.nombre = usuario.nombre;
                persona.idTipoDocumento = (int)usuario.tipoDNI;
                persona.nroDocumento = usuario.dNI;
                persona.domicilio = usuario.domicilio;
                persona.telefonoFijo = usuario.tEF;
                persona.telefonoCelular = usuario.tEC;
                persona.email = usuario.mail;
                user.user = usuario.usuario;
                user.idRol = usuario.rol;
            }
        }
        //Metodo para busar roles
        public static List<ERoles> Roles()
        {
            List<ERoles> roles = new List<ERoles>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Roles> consulta = from rolesDB in mapaEntidades.Roles
                                         select rolesDB;
            foreach (var registro in consulta)
            {
                ERoles rol = new ERoles();
                rol.idRol = registro.idRol;
                rol.nombre = registro.nombre;
                rol.descripcion = registro.descripcion;
                roles.Add(rol);
            }
            return roles;
        }
        //fin metodo
    }
}
