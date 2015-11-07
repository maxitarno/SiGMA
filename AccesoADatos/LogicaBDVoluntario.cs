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
    }
}
