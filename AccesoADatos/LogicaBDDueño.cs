using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace AccesoADatos
{
    public class LogicaBDDueño
    {
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
        public static EDuenio buscarDueño(int idMascota)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from dueñosBD in mapaEntidades.Duenios
                           join personasBD in mapaEntidades.Personas on dueñosBD.idPersona equals personasBD.idPersona
                           join barriosBD in mapaEntidades.Barrios on personasBD.idBarrio equals barriosBD.idBarrio
                           into tempPersonaBarrio
                           from subBarriosBD in tempPersonaBarrio.DefaultIfEmpty()
                           join callesBD in mapaEntidades.Calles on personasBD.idCalle equals callesBD.idCalle into tempPersonaCalle
                           from subCallesBD in tempPersonaCalle.DefaultIfEmpty()
                           join mascotasBD in mapaEntidades.Mascotas on dueñosBD.idDuenio equals mascotasBD.idDuenio                           
                           where (mascotasBD.idMascota == idMascota)
                           select new
                           {    
                               personasBD,
                               idBarrio = subBarriosBD != null ? subBarriosBD.idBarrio : -1,
                               nombreBarrio = subBarriosBD != null ? subBarriosBD.nombre : string.Empty,
                               idCalle = subCallesBD != null ? subCallesBD.idCalle : -1,
                               nombreCalle = subCallesBD != null ? subCallesBD.nombre : string.Empty                              
                           };
            EDuenio dueño = null;

            if (consulta.Count() != 0)
            {
                dueño = new EDuenio();
                dueño.domicilio = new EDomicilio();
                dueño.apellido = consulta.Select(a => a.personasBD.apellido).First();
                dueño.nombre = consulta.Select(a => a.personasBD.nombre).First();
                dueño.domicilio.numeroCalle = consulta.Select(a => a.personasBD.nroCalle).First();
                if (consulta.Select(a => a.idBarrio).First() != -1)
                {
                    dueño.domicilio.barrio = new EBarrio();
                    dueño.domicilio.barrio.idBarrio = consulta.Select(a => a.idBarrio).First();
                    dueño.domicilio.barrio.nombre = consulta.Select(a => a.nombreBarrio).First();
                }
                if (consulta.Select(a => a.idCalle).First() != -1)
                {
                    dueño.domicilio.calle = new ECalle();
                    dueño.domicilio.calle.idCalle = consulta.Select(a => a.idCalle).First();
                    dueño.domicilio.calle.nombre = consulta.Select(a => a.nombreCalle).First();
                }
                dueño.email = consulta.Select(a => a.personasBD.email).First();
                if (consulta.Select(a => a.personasBD.telefonoCelular).First() != null)
                {
                    dueño.telefonoCelular = consulta.Select(a => a.personasBD.telefonoCelular).First(); 
                }
                //Agregar los demas campos!
            }
            return dueño;
        }
    }
}
