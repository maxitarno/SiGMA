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
                           where (G1.user == nombre && usuariosBD.estado == true)
                           select new 
                           {
                               user = usuariosBD,
                               persona = G1,
                               barrio = G2,
                               localidad = G3,
                               calle = G4
                            };
            try
            {
                foreach (var usuario in consulta1)
                {
                    persona.apellido = usuario.persona.apellido;
                    persona.nombre = usuario.persona.nombre;
                    barrio.idBarrio = (usuario.barrio == null) ? 0 : usuario.barrio.idBarrio;
                    persona.domicilio.nombre = usuario.persona.domicilio;
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
       
    }
}