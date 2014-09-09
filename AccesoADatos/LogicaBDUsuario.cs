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
        public static Boolean guardarUsuario(EDuenio duenio, EUsuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {               
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Usuarios userBD = new Usuarios();
                    userBD.user = usuario.user;
                    userBD.password = usuario.password;                  
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
        //metodo para buscar el usuario por usuarios
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
        public static void BuscarUsuarios(string nombre, EUsuario user, EPersona persona, EBarrio barrio, ELocalidad localidad)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from personasBD in mapaEntidades.Personas
                           from usuariosBD in mapaEntidades.Usuarios
                           from rolesBD in mapaEntidades.Roles
                           from BarriosBD in mapaEntidades.Barrios
                           from LocalidadesBD in mapaEntidades.Localidades
                           where (personasBD.user == usuariosBD.user  && personasBD.idBarrio == BarriosBD.idBarrio && LocalidadesBD.idLocalidad == BarriosBD.idLocalidad && usuariosBD.user == nombre && usuariosBD.estado == true)
                           select new
                           {
                               apellido = personasBD.apellido,
                               nombre = personasBD.nombre,
                               tipoDNI = personasBD.idTipoDocumento,
                               dNI = personasBD.nroDocumento,
                               domicilio = personasBD.domicilio,
                               tEF = personasBD.telefonoFijo,
                               tEC = personasBD.telefonoCelular,
                               mail = personasBD.email,
                               usuario = usuariosBD.user,
                               barrio = personasBD.idBarrio,
                               localidad = LocalidadesBD.idLocalidad,
                               idPersona = personasBD.idPersona,
                               fecha = personasBD.fechaNacimiento
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
                    barrio.idBarrio = (int)usuario.barrio;
                    localidad.idLocalidad = usuario.localidad;
                    if (usuario.fecha != null)
                    {
                        persona.fechaNacimiento = DateTime.Parse(usuario.fecha.ToString());
                    }
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
                    registro.domicilio = persona.domicilio;
                    registro.email = persona.email;
                    registro.fechaNacimiento = persona.fechaNacimiento;
                    registro.idBarrio = persona.idBarrio;
                    registro.idTipoDocumento = persona.idTipoDocumento;
                    registro.nombre = persona.nombre;
                    registro.nroDocumento = persona.nroDocumento;
                    registro.telefonoCelular = persona.telefonoCelular;
                    registro.telefonoFijo = persona.telefonoFijo;
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
        public static int? buscarIdDueñoPorUsuario(string usuario)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();            
            IQueryable<int> consulta = from dueñosBD in mapaEntidades.Duenios
                                       join personasBD in mapaEntidades.Personas on dueñosBD.idPersona equals personasBD.idPersona
                                       join usuariosBD in mapaEntidades.Usuarios on personasBD.user equals usuariosBD.user
                                       where (usuariosBD.user == usuario)                                       
                                       select dueñosBD.idDuenio;
            
            if (consulta.Count() != 0)
            {
                return consulta.First();
            }
            else
            {
                return null;
            }
        }
    }
}