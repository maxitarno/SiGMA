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
        //metodo para buscar persona
        public static void BuscarUsuarios(string nombre, EUsuario user, EPersona persona, EBarrio barrio, ELocalidad localidad){
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from personasBD in mapaEntidades.Personas
                           from usuariosBD in mapaEntidades.Usuarios
                           from rolesBD in mapaEntidades.Roles
                           from BarriosBD in mapaEntidades.Barrios
                           from LocalidadesBD in mapaEntidades.Localidades
                           where (personasBD.user == usuariosBD.user && rolesBD.idRol == usuariosBD.idRol && personasBD.idBarrio == BarriosBD.idBarrio && LocalidadesBD.idLocalidad == BarriosBD.idLocalidad && personasBD.user == nombre)
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
                               barrio = persona.idBarrio,
                               localidad = LocalidadesBD.idLocalidad,
                               idPersona = personasBD.idPersona
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
                    barrio.idBarrio = usuario.barrio;
                    localidad.idLocalidad = usuario.localidad;
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
        }
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
        //fin metodo
        //metodo para modificar un usuario
        public static bool ModificarUsuario(EPersona persona, EUsuario usuario)
        {
            bool b = true;
            try
            {
                SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
                var personas = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user.StartsWith(usuario.user));
                var usuarios = mapaEntidades.Usuarios.Where(usuariobuscado => usuariobuscado.user.StartsWith(usuario.user));
                foreach (var registro in personas)
                {
                    registro.apellido = registro.apellido.Replace(registro.apellido, persona.apellido);
                    registro.domicilio = registro.domicilio.Replace(registro.domicilio, persona.domicilio);
                    registro.email = registro.email.Replace(registro.email, persona.email);
                    registro.fechaNacimiento = persona.fechaNacimiento;
                    registro.idBarrio = persona.idBarrio;
                    registro.idTipoDocumento = persona.idTipoDocumento;
                    registro.nombre = registro.nombre.Replace(registro.nombre, persona.nombre);
                    registro.nroDocumento = registro.nroDocumento.Replace(registro.nroDocumento, persona.nroDocumento);
                    registro.telefonoCelular = registro.telefonoCelular.Replace(registro.telefonoCelular, persona.telefonoCelular);
                    registro.telefonoFijo = registro.telefonoFijo.Replace(registro.telefonoFijo, persona.telefonoFijo);
                }
                foreach (var registro in usuarios)
                {
                    registro.idRol = usuario.idRol;
                }
                mapaEntidades.SaveChanges();
            }
            catch (InvalidOperationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
    }
}
