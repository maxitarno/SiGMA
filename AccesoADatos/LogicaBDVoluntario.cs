using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

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
                                          join OcupacionesBD in mapaEntidades.OcupacionesXHogaresProvisorios on hogaresBD.idHogarProvisorio equals OcupacionesBD.idHogarProvisorio
                                          where (usuariosBD.user == usuario)
                                        select new
                                        {
                                            nombre = personasBD.apellido + ' ' + personasBD.nombre,
                                            email = personasBD.email,
                                            telefonoCelular = personasBD.telefonoCelular,
                                            telefonoFijo = personasBD.telefonoFijo,
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
                persona.nombre = registro.nombre;
                persona.email = registro.email;
                persona.telefonoCelular = registro.telefonoCelular;
                persona.telefonoFijo = registro.telefonoCelular;
                persona.nroCalle = registro.nroCalle;
                calle.idCalle = registro.calle;
                barrio.idBarrio = registro.barrio;
            }
        }
    }
}
