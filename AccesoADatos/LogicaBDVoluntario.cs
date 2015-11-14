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

        public static void cargarDatosHogarProvisorio(string usuario, EPersona persona, EHogarProvisorio hogar, ECalle calle, EBarrio barrio)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var hogares = from personasBD in mapaEntidades.Personas
                                          join usuariosBD in mapaEntidades.Usuarios on personasBD.user equals usuariosBD.user
                                          join voluntariosBD in mapaEntidades.Voluntarios on personasBD.idPersona equals voluntariosBD.idPersona
                                          join hogaresBD in mapaEntidades.HogaresProvisorios on voluntariosBD.idVoluntario equals hogaresBD.idVoluntario
                                          where (usuariosBD.user == usuario)
                                        select new
                                        {
                                            apellido = personasBD.apellido,
                                            nombre = personasBD.nombre,
                                            email = personasBD.email,
                                            tipoHogar = hogaresBD.TipoHogar,
                                            calle = personasBD.idCalle,
                                            nroCalle = personasBD.nroCalle,
                                            barrio = personasBD.idBarrio,
                                            cantidadMax = hogaresBD.cantMascotas,
                                            tipoMascota = hogaresBD.AceptaEspecie,
                                            tieneNiños = hogaresBD.tieneNiños,
                                        };
            foreach (var registro in hogares)
            {
                hogar.tipoHogar = registro.tipoHogar;
                hogar.cantMascotas = registro.cantidadMax;
                hogar.AceptaEspecie = registro.tipoMascota;
                hogar.tieneNiños = registro.tieneNiños;
                persona.nombre = registro.nombre + ' ' + registro.apellido;
                persona.email = registro.email;
                persona.nroCalle = registro.nroCalle;
                calle.idCalle = registro.calle;
                barrio.idBarrio = registro.barrio;
            }
        }

        public static Boolean RegistrarPedidoVoluntariado(string usuario, string email, string nombre, int tipoHogar, int barrioHogar, int cantMascMax, int tipoMasc, int calle, string nroCalle, int barrioBusq, string disponibilidad )
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    //SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    //Adopciones adopcionBD = new Adopciones();
                    //adopcionBD.idDuenio = adopcion.duenio.idDuenio;
                    //adopcionBD.idVoluntario = adopcion.idVoluntario;
                    //adopcionBD.fechaAdopcion = adopcion.fecha;
                    //adopcionBD.idMascota = adopcion.mascota.idMascota;
                    //adopcionBD.observaciones = adopcion.observaciones;
                    //adopcionBD.idEstado = mapaEntidades.Estados.Where(es => es.ambito == "Adopcion" && es.nombreEstado == "Abierta").First().idEstado;
                    //LogicaBDMascota.modificarEstado("Adoptada", adopcion.mascota.idMascota, ref mapaEntidades);
                    //LogicaBDMascota.asignarDueño(adopcion.mascota, adopcion.duenio.idDuenio, ref mapaEntidades);
                    //Mascotas bdMascota = mapaEntidades.Mascotas.Where(m => m.idMascota == adopcion.mascota.idMascota).First();
                    //bdMascota.nombreMascota = adopcion.mascota.nombreMascota;
                    //mapaEntidades.AddToAdopciones(adopcionBD);
                    //mapaEntidades.SaveChanges();
                    //transaccion.Complete();
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
                                            where (usuariosBD.user == usuario)
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
            IQueryable<Voluntarios> consulta = from voluntariosBD in mapaEntidades.Voluntarios
                                   where (voluntariosBD.idVoluntario == idVoluntario)
                                   select voluntariosBD;
            try
            {
                foreach (var registro in consulta)
                {
                    voluntario.idEstado = registro.idEstado;
                    voluntario.idVoluntario = registro.idVoluntario;
                    voluntario.disponibilidadHoraria = registro.disponibilidadHoraria;
                    voluntario.tipoVoluntario = registro.tipoVoluntario;
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
                Mascotas mascotaBD = mapaEntidades.Mascotas.Where(m => m.idMascota == idMascota).First();
                mascotaBD.idEstado = LogicaBDEstado.buscarEstado(new EEstado { nombreEstado = "Solicitud Devolucion", ambito = "Mascota" }).idEstado;
                mapaEntidades.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public static void cargarDatosBusqueda(string usuario, EPersona persona, EBarrio barrio)
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
                          };
            foreach (var registro in hogares)
            {
                persona.nombre = registro.nombre + ' ' + registro.apellido;
                persona.email = registro.email;
                barrio.idBarrio = registro.barrio;
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
    }
}
