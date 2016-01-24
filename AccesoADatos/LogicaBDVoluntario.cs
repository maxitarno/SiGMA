using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDVoluntario
    {
        public static int? buscarIdVoluntarioPorUsuario(string usuario)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<int> consulta = from dueñosBD in mapaEntidades.Duenios
                                       join personasBD in mapaEntidades.Personas on dueñosBD.idPersona equals personasBD.idPersona
                                       join usuariosBD in mapaEntidades.Usuarios on personasBD.user equals usuariosBD.user
                                       join voluntariosBD in mapaEntidades.Voluntarios on personasBD.idPersona equals voluntariosBD.idPersona
                                       where (usuariosBD.user == usuario)
                                       select voluntariosBD.idVoluntario;

            if (consulta.Count() != 0)
            {
                return consulta.First();
            }
            else
            {
                return null;
            }
        }

        public static int buscarTipoVoluntario(string usuario)
        {
            int vol = 0;
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<string> consulta = from personasBD in mapaEntidades.Personas 
                                       join usuariosBD in mapaEntidades.Usuarios on personasBD.user equals usuariosBD.user
                                       join voluntariosBD in mapaEntidades.Voluntarios on personasBD.idPersona equals voluntariosBD.idPersona
                                          where (usuariosBD.user == usuario)
                                       select voluntariosBD.tipoVoluntario;
            if (consulta.Count() != 0)
            {
                if (consulta.First() == "Hogar")
                    vol= 1;
                if (consulta.First() == "Busqueda")
                    vol= 2;
                if (consulta.First() == "Ambos")
                    vol= 3;
            }
            else
            {
                vol = 0;
            }
            return vol;
        }

        public static string buscarEstadoVoluntario(string usuario) 
        {
            string vol = "";
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<int?> consulta = from personasBD in mapaEntidades.Personas
                                          join usuariosBD in mapaEntidades.Usuarios on personasBD.user equals usuariosBD.user
                                          join voluntariosBD in mapaEntidades.Voluntarios on personasBD.idPersona equals voluntariosBD.idPersona
                                          where (usuariosBD.user == usuario)
                                          select voluntariosBD.idEstado;
            if (consulta.Count() != 0)
            {
                if (consulta.First() == 32)
                    vol = "Activo" ;
                if (consulta.First() == 33)
                    vol = "Inactivo";
                if (consulta.First() == 34)
                    vol = "Pendiente";
                if (consulta.First() == 35)
                    vol = "Rechazado";
                if (consulta.First() == 36)
                    vol = "Solicitud Baja";
            }
            else
            {
                vol = "";
            }
            return vol;        
        }

        

        public static Boolean RegistrarPedidoVoluntariado(string usuario, string email, string nombre, int? tipoHogar, int? barrioHogar, int? cantMascMax, int? tipoMasc, int? calle, string nroCalle, string tieneNiños, int? barrioBusq, string disponibilidad)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    if (barrioBusq == null && disponibilidad == null)
                    {
                        if (tipoHogar != null && nroCalle != null)
                        {
                            Voluntarios voluntarioBD = new Voluntarios();
                            voluntarioBD.idPersona = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user == usuario).First().idPersona;
                            voluntarioBD.idEstado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Pendiente", ambito = "Voluntario" }).idEstado;
                            voluntarioBD.tipoVoluntario = "Hogar";
                            HogaresProvisorios HogarBD = new HogaresProvisorios();
                            HogarBD.tieneNiños = tieneNiños;
                            HogarBD.TipoHogar = Convert.ToInt32(tipoHogar);
                            HogarBD.idVoluntario = voluntarioBD.idVoluntario;
                            HogarBD.idEstado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Pendiente", ambito = "Hogar" }).idEstado;
                            HogarBD.AceptaEspecie = Convert.ToInt32(tipoMasc);
                            HogarBD.cantMascotas = Convert.ToInt32(cantMascMax);
                            HogarBD.disponibilidad = Convert.ToInt32(cantMascMax);
                            Personas personaBD = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user == usuario).First();
                            personaBD.idBarrio = Convert.ToInt32(barrioHogar);
                            personaBD.idCalle = Convert.ToInt32(calle);
                            personaBD.nroCalle = Convert.ToInt32(nroCalle);
                            mapaEntidades.AddToVoluntarios(voluntarioBD);
                            mapaEntidades.AddToHogaresProvisorios(HogarBD);
                            mapaEntidades.SaveChanges();
                            transaccion.Complete();
                        }
                    }
                    else if (tipoHogar == null && nroCalle == null)
                    {
                        if (barrioBusq != null && disponibilidad != null)
                        {
                            Voluntarios voluntarioBD = new Voluntarios();
                            voluntarioBD.idPersona = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user == usuario).First().idPersona;
                            voluntarioBD.idEstado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Pendiente", ambito = "Voluntario" }).idEstado;
                            voluntarioBD.tipoVoluntario = "Busqueda";
                            voluntarioBD.disponibilidadHoraria = disponibilidad;
                            Personas personaBD = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user == usuario).First();
                            personaBD.idBarrio = Convert.ToInt32(barrioBusq);
                            mapaEntidades.AddToVoluntarios(voluntarioBD);
                            mapaEntidades.SaveChanges();
                            transaccion.Complete();
                        }
                    }
                    else
                    {
                        Voluntarios voluntarioBD = new Voluntarios();
                        voluntarioBD.idPersona = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user == usuario).First().idPersona;
                        voluntarioBD.idEstado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Pendiente", ambito = "Voluntario" }).idEstado;
                        voluntarioBD.tipoVoluntario = "Ambos";
                        voluntarioBD.disponibilidadHoraria = disponibilidad;
                        HogaresProvisorios HogarBD = new HogaresProvisorios();
                        HogarBD.tieneNiños = tieneNiños;
                        HogarBD.TipoHogar = Convert.ToInt32(tipoHogar);
                        HogarBD.idVoluntario = voluntarioBD.idPersona;
                        HogarBD.idEstado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Pendiente", ambito = "Hogar" }).idEstado;
                        HogarBD.AceptaEspecie = Convert.ToInt32(tipoMasc);
                        HogarBD.cantMascotas = Convert.ToInt32(cantMascMax);
                        Personas personaBD = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user == usuario).First();
                        personaBD.idBarrio = Convert.ToInt32(barrioHogar);
                        personaBD.idCalle = Convert.ToInt32(calle);
                        personaBD.nroCalle = Convert.ToInt32(nroCalle);
                        mapaEntidades.AddToVoluntarios(voluntarioBD);
                        mapaEntidades.AddToHogaresProvisorios(HogarBD);
                        mapaEntidades.SaveChanges();
                        transaccion.Complete();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static List<EMascota> cargarDatosProvisorias(string usuario)
        {
            List<EMascota> mascotas = new List<EMascota>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from MascotasBD in mapaEntidades.Mascotas
                                            join OcupacionesBD in mapaEntidades.OcupacionesXHogaresProvisorios on MascotasBD.idMascota equals OcupacionesBD.idMascota
                                            join HogaresBD in mapaEntidades.HogaresProvisorios on OcupacionesBD.idHogarProvisorio equals HogaresBD.idHogarProvisorio
                                            join voluntariosBD in mapaEntidades.Voluntarios on HogaresBD.idVoluntario equals voluntariosBD.idVoluntario
                                            join personasBD in mapaEntidades.Personas on voluntariosBD.idPersona equals personasBD.idPersona
                                            join usuariosBD in mapaEntidades.Usuarios on personasBD.user equals usuariosBD.user
                                            where usuariosBD.user == usuario && OcupacionesBD.fechaSalida == null
                                            select new
                                           {
                                               nombre = MascotasBD.nombreMascota,
                                               idEspecie = MascotasBD.idEspecie,
                                               idRaza = MascotasBD.idRaza,
                                               id = MascotasBD.idMascota,
                                               sexo = MascotasBD.sexo,
                                           };
            foreach (var registro in consulta)
            {
                EMascota mascota = new EMascota();
                mascota.raza = new ERaza();
                mascota.raza.CategoriaRaza = new ECategoriaRaza();
                mascota.raza.idRaza = registro.idRaza;
                mascota.nombreMascota = registro.nombre;
                mascota.sexo = registro.sexo;
                mascota.idMascota = registro.id;
                mascota.especie = new EEspecie();
                mascota.especie.idEspecie = registro.idEspecie;
                mascotas.Add(mascota);
            }
            return mascotas;
        }

        public static bool dejarDeSerVoluntario(int idVoluntario)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                Voluntarios voluntarioBD = mapaEntidades.Voluntarios.Where(m => m.idVoluntario == idVoluntario).First();
                voluntarioBD.idEstado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Solicitud Baja", ambito = "Voluntario" }).idEstado;
                b = true;
                mapaEntidades.SaveChanges();
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }

        public static EVoluntario buscarVoluntarioPorId(int idVoluntario)
        {
            EVoluntario voluntario = new EVoluntario();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from voluntariosBD in mapaEntidades.Voluntarios
                           join personasBD in mapaEntidades.Personas on voluntariosBD.idPersona equals personasBD.idPersona
                           join barriosBD in mapaEntidades.Barrios on personasBD.idBarrio equals barriosBD.idBarrio into group1
                           from G1 in group1.DefaultIfEmpty(null)
                           join callesBD in mapaEntidades.Calles on personasBD.idCalle equals callesBD.idCalle into group2
                           from G2 in group2.DefaultIfEmpty(null)
                           where (voluntariosBD.idVoluntario == idVoluntario)
                           select new
                           {
                               voluntariosBD,
                               personasBD.nombre,
                               personasBD.apellido,
                               personasBD.nroCalle,
                               personasBD.telefonoCelular,
                               personasBD.telefonoFijo,
                               idBarrio = (G1 == null) ? 0 : G1.idBarrio,
                               nombreBarrio = (G1 == null) ? null : G1.nombre,
                               idCalle = (G2 == null) ? 0 : G2.idCalle,
                               nombreCalle = (G2 == null) ? null : G2.nombre
                           };
            try
            {
                foreach (var registro in consulta)
                {
                    voluntario.idEstado = registro.voluntariosBD.idEstado;
                    voluntario.idVoluntario = registro.voluntariosBD.idVoluntario;
                    voluntario.disponibilidadHoraria = registro.voluntariosBD.disponibilidadHoraria;
                    voluntario.tipoVoluntario = registro.voluntariosBD.tipoVoluntario;
                    voluntario.persona = new EPersona();
                    voluntario.persona.apellido = registro.apellido;
                    voluntario.persona.nombre = registro.nombre;
                    voluntario.persona.nroCalle = registro.nroCalle;
                    voluntario.persona.telefonoCelular = registro.telefonoCelular;
                    voluntario.persona.telefonoFijo = registro.telefonoFijo;
                    voluntario.persona.barrio = new EBarrio();
                    voluntario.persona.barrio.idBarrio = registro.idBarrio;
                    voluntario.persona.barrio.nombre = registro.nombreBarrio;
                    voluntario.persona.domicilio = new ECalle();
                    voluntario.persona.domicilio.idCalle = registro.idCalle;
                    voluntario.persona.domicilio.nombre = registro.nombreCalle;
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return voluntario;
        }

        public static void registrarSolicitudDevolucion(int idMascota)
        {
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                OcupacionesXHogaresProvisorios ocupacionBD = mapaEntidades.OcupacionesXHogaresProvisorios.Where(m => m.idMascota == idMascota && m.fechaSalida == null).First();
                ocupacionBD.solicitudDevolucion = true;
                mapaEntidades.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public static void cargarDatosBusqueda(string usuario, EPersona persona, EBarrio barrio, EVoluntario voluntario)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var hogares = from personasBD in mapaEntidades.Personas
                          join usuariosBD in mapaEntidades.Usuarios on personasBD.user equals usuariosBD.user
                          join voluntariosBD in mapaEntidades.Voluntarios on personasBD.idPersona equals voluntariosBD.idPersona
                          where (usuariosBD.user == usuario)
                          select new
                          {
                              apellido = personasBD.apellido,
                              nombre = personasBD.nombre,
                              email = personasBD.email,
                              barrio = personasBD.idBarrio,
                              disponibilidad = voluntariosBD.disponibilidadHoraria,
                          };
            foreach (var registro in hogares)
            {
                persona.nombre = registro.nombre + ' ' + registro.apellido;
                persona.email = registro.email;
                barrio.idBarrio = registro.barrio;
                voluntario.disponibilidadHoraria = registro.disponibilidad;
            }
        }

        public static List<EPerdida> cargarPerdidasBarrioVoluntario(string barrio)
        {
            List<EPerdida> perdidas = LogicaBDPerdida.BuscarPerdidas();
            var estadoAbierta = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Abierta", ambito = "Perdida" }).nombreEstado;
            var estadoModificada = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Modificada", ambito = "Perdida" }).nombreEstado;
            var estadoPublicada = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Publicada", ambito = "Perdida" }).nombreEstado;
            perdidas = perdidas.Where(p => p.barrio.nombre == barrio && (p.estado.nombreEstado == estadoAbierta || p.estado.nombreEstado == estadoModificada || p.estado.nombreEstado == estadoModificada)).ToList();
            return perdidas;
        }

        public static void actualizarDisponibilidadVoluntario(int idVoluntario, string disponibilidad)
        {
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                Voluntarios voluntarioBD = mapaEntidades.Voluntarios.Where(m => m.idVoluntario == idVoluntario).First();
                voluntarioBD.disponibilidadHoraria = disponibilidad;
                mapaEntidades.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        //Busca los voluntarios segun el estado
        public static List<EVoluntario> BuscarPedidosVoluntariado(EEstado estado)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            List<EVoluntario> voluntarios = new List<EVoluntario>();
            var pedidosVoluntariado = from VoluntariosBD in mapa.Voluntarios
                                      join PersonasBD in mapa.Personas on VoluntariosBD.idPersona equals PersonasBD.idPersona
                                      where (VoluntariosBD.idEstado == estado.idEstado)
                                      select new
                                      {
                                          nombre = PersonasBD.nombre,
                                          apellido = PersonasBD.apellido,
                                          idVoluntario = VoluntariosBD.idVoluntario,
                                          tipoVoluntario = VoluntariosBD.tipoVoluntario,
                                          disponibilidad = VoluntariosBD.disponibilidadHoraria
                                      };
            foreach (var registro in pedidosVoluntariado)
            {
                EVoluntario voluntario = new EVoluntario();
                voluntario.persona = new EPersona();
                voluntario.idVoluntario = registro.idVoluntario;
                voluntario.tipoVoluntario = (registro.tipoVoluntario == null) ? "Sin asignar" : registro.tipoVoluntario;
                voluntario.disponibilidadHoraria = (registro.disponibilidad == null) ? "Sin asignar" : registro.disponibilidad;
                voluntario.persona.nombre = registro.nombre;
                voluntario.persona.apellido = registro.apellido;
                voluntarios.Add(voluntario);
            }
            return voluntarios;
        }
        //fin

        //Actualiza los estados de los voluntarios
        public static void ActualizarEstadoVoluntario(int idVoluntario, int idEstado)
        {
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                Voluntarios voluntarioBD = mapaEntidades.Voluntarios.Where(m => m.idVoluntario == idVoluntario).First();
                voluntarioBD.idEstado = idEstado;
                mapaEntidades.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        //fin

        public static void darDeBajaVoluntario(EVoluntario paramVoluntario)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    var voluntario = mapa.Voluntarios.Where(m => m.idVoluntario == paramVoluntario.idVoluntario).First();
                    voluntario.idEstado = LogicaBDEstado.buscarEstado(new EEstado { ambito = "Voluntario", nombreEstado = "Inactivo"}).idEstado;
                    if (paramVoluntario.tipoVoluntario.Equals("Hogar"))
                    {
                        LogicaBDHogar.darDeBajaHogar(paramVoluntario);
                    }
                    mapa.SaveChanges();
                    transaccion.Complete();
                }
                catch (Exception)
                {
                    transaccion.Dispose();
                    throw;
                }
            }
        }


    }
}
