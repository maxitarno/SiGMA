using System;
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
                    SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
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
        //Mi metodo para buscar los tipos de documentos
        public static List<ETipoDeDocumento> TiposDNI(){
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
        //fin del metodo
        //metodo para buscar el usuario por usuarios
        public static List<EUsuario> BuscarUsuarios(string nombre)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> aux = from usuariosBuscados in mapaEntidades.Usuarios
                                       where (usuariosBuscados.user.Contains(nombre)) 
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
        //metodo para busca usuarios por tipo y nº de documento
        public static List<EUsuario> BuscarUsuarios(int tipo, string dni)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> consulta = from personasBD in mapaEntidades.Personas
                                                from usuariosBD in mapaEntidades.Usuarios
                                                where ( personasBD.user == usuariosBD.user && personasBD.nroDocumento == dni && personasBD.idTipoDocumento == tipo )
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
        public static void BuscarUsuarios(string nombre, EUsuario user, EPersona persona){
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
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
            try
            {
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
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
        }
        //Metodo para busar roles
        public static List<ERol> Roles()
        {
            List<ERol> roles = new List<ERol>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Roles> consulta = from rolesDB in mapaEntidades.Roles
                                         select rolesDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ERol rol = new ERol();
                    rol.idRol = registro.idRol;
                    rol.nombreRol = registro.nombre;
                    rol.descripcionRol = registro.descripcion;
                    roles.Add(rol);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return roles;
        }
        //fin metodo
        //Metodo para buscar barrios y localidades
        public static List<EBarrio> BuscarBarrios(int idLocalidad)
        {
            List<EBarrio> barrios = new List<EBarrio>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
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
    }
}
