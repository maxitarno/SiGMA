using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDHogar
    {
        public static void registrarOcupacion(EOcupacionHogar ocupacion)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    actualizarDisponibilidad(ocupacion.hogar, "Asignacion");
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    OcupacionesXHogaresProvisorios nuevaOcupacion = new OcupacionesXHogaresProvisorios();
                    nuevaOcupacion.fechaIngreso = ocupacion.fechaIngreso;
                    nuevaOcupacion.idHogarProvisorio = ocupacion.hogar.idHogar;
                    nuevaOcupacion.idMascota = ocupacion.mascota.idMascota;
                    mapa.AddToOcupacionesXHogaresProvisorios(nuevaOcupacion);
                    var hogarBD = mapa.HogaresProvisorios.Where(o => o.idHogarProvisorio == ocupacion.hogar.idHogar);
                    if (hogarBD.Count() != 0)
                    {
                        hogarBD.First().disponibilidad = ocupacion.hogar.disponibilidad;
                        hogarBD.First().idEstado = ocupacion.hogar.estado.idEstado;
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

        /* Metodo para actualizar la disponibilidad de un hogar, dependiendo del string tipoTransaccion("Asignacion" o "Liberacion")
        si tipoTransaccion == "Asignacion", se restara 1 a la disponibilidad del hogar y cambiara de estado
        si tipoTransaccion == "Liberacion", se sumara 1 a la disponibilidad del hogar y cambiara de estado */
        private static void actualizarDisponibilidad(EHogarProvisorio hogar, string tipoTransaccion)
        {
            int nuevaDisponibilidad = 0;
            if (tipoTransaccion == "Asignacion")
            {
                nuevaDisponibilidad = hogar.disponibilidad - 1;
                if (nuevaDisponibilidad == 0)
                {
                    hogar.estado = LogicaBDEstado.buscarEstado(new EEstado { ambito = "Hogar", nombreEstado = "Ocupado" });
                }
                else
                {
                    hogar.estado = LogicaBDEstado.buscarEstado(new EEstado { ambito = "Hogar", nombreEstado = "Disponible Parcialmente" });
                }
            }
            else
            {
                if (tipoTransaccion == "Liberacion")
                {
                    nuevaDisponibilidad = hogar.disponibilidad + 1;
                    if (nuevaDisponibilidad == hogar.cantMascotas)
                    {
                        hogar.estado = LogicaBDEstado.buscarEstado(new EEstado { ambito = "Hogar", nombreEstado = "Disponible" });
                    }
                    else
                    {
                        hogar.estado = LogicaBDEstado.buscarEstado(new EEstado { ambito = "Hogar", nombreEstado = "Disponible Parcialmente" });
                    }
                }
            }
            hogar.disponibilidad = nuevaDisponibilidad;           
        }

        public static void LiberarHogar(int id, DateTime fecha, ref SiGMAEntities mapa)
        {
            try
            {
                var ocupacion = mapa.OcupacionesXHogaresProvisorios.Where
                    (o => o.idMascota == id && o.fechaSalida == null);
                if (ocupacion.Count() != 0)
                {
                    ocupacion.First().fechaSalida = fecha;
                }
            }
            catch (Exception)
            {

            }
        }

        public static List<EHogarProvisorio> buscarHogaresDisponibles(EHogarProvisorio hogarFiltros)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            List<EHogarProvisorio> lstHogares = new List<EHogarProvisorio>();
            var hogares = from hogaresBD in mapa.HogaresProvisorios
                          join voluntariosBD in mapa.Voluntarios on hogaresBD.idVoluntario equals voluntariosBD.idVoluntario
                          join personasBD in mapa.Personas on voluntariosBD.idPersona equals personasBD.idPersona
                          where (hogaresBD.idEstado == 27 || hogaresBD.idEstado == 29) && hogaresBD.tieneNiños == hogarFiltros.tieneNiños
                          && hogaresBD.AceptaEspecie == hogarFiltros.AceptaEspecie && hogaresBD.TipoHogar == hogarFiltros.tipoHogar
                          select new
                          {
                              hogaresBD,
                              personasBD.nombre,
                              personasBD.apellido
                          };
            foreach (var item in hogares)
            {
                EHogarProvisorio entHogar = new EHogarProvisorio();
                entHogar.idHogar = item.hogaresBD.idHogarProvisorio;
                entHogar.tieneNiños = item.hogaresBD.tieneNiños;
                entHogar.cantMascotas = item.hogaresBD.cantMascotas;
                entHogar.voluntario = new EVoluntario();
                entHogar.voluntario.idVoluntario = item.hogaresBD.idVoluntario;
                entHogar.voluntario.persona = new EPersona();
                entHogar.voluntario.persona.apellido = item.apellido;
                entHogar.voluntario.persona.nombre = item.nombre;
                entHogar.estado = new EEstado();
                entHogar.estado.idEstado = item.hogaresBD.idEstado;
                entHogar.AceptaEspecie = item.hogaresBD.AceptaEspecie;
                entHogar.tipoHogar = item.hogaresBD.TipoHogar;
                if (item.hogaresBD.disponibilidad == null)
                {
                    entHogar.disponibilidad = item.hogaresBD.cantMascotas;
                }
                else
                {
                    entHogar.disponibilidad = Convert.ToInt32(item.hogaresBD.disponibilidad);
                }
                lstHogares.Add(entHogar);
            }
            return lstHogares;
        }

        public static void actualizarHogarVoluntario(int idVoluntario, string usuario, string tipoHogar, string calle, string nro, string barrio, string cantMasc, string especie, string tieneNiños)
        {
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                HogaresProvisorios hogarBD = mapaEntidades.HogaresProvisorios.Where(m => m.idVoluntario == idVoluntario).First();
                Personas personasBD = mapaEntidades.Personas.Where(personaBuscada => personaBuscada.user == usuario).First();
                hogarBD.TipoHogar = Convert.ToInt32(tipoHogar);
                hogarBD.cantMascotas = Convert.ToInt32(cantMasc);
                hogarBD.AceptaEspecie = Convert.ToInt32(especie);
                hogarBD.tieneNiños = tieneNiños;
                personasBD.idBarrio = Convert.ToInt32(barrio);
                personasBD.idCalle = Convert.ToInt32(calle);
                personasBD.nroCalle = Convert.ToInt32(nro);
                mapaEntidades.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
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
    }
}
