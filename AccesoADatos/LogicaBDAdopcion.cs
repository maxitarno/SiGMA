using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;
namespace AccesoADatos
{
    public class LogicaBDAdopcion
    {
        public static Boolean RegistrarAdopcion(EAdopcion adopcion)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Adopciones adopcionBD = new Adopciones();
                    adopcionBD.idDuenio = adopcion.duenio.idDuenio;
                    adopcionBD.idVoluntario = adopcion.idVoluntario;
                    adopcionBD.fechaAdopcion = adopcion.fecha;
                    adopcionBD.idMascota = adopcion.mascota.idMascota;
                    adopcionBD.observaciones = adopcion.observaciones;
                    adopcionBD.idEstado = mapaEntidades.Estados.Where(es => es.ambito == "Adopcion" && es.nombreEstado == "Abierta").First().idEstado;
                    LogicaBDMascota.modificarEstado("Adoptada", adopcion.mascota.idMascota, ref mapaEntidades);
                    LogicaBDMascota.asignarDueño(adopcion.mascota, adopcion.duenio.idDuenio, ref mapaEntidades);
                    mapaEntidades.AddToAdopciones(adopcionBD);
                    mapaEntidades.SaveChanges();
                    transaccion.Complete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static int obtenerProximoIdAdopcion()
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var qonda = mapa.ExecuteStoreQuery<Decimal>("SELECT IDENT_CURRENT('Adopciones') + IDENT_INCR('Adopciones')");
            string asd = qonda.FirstOrDefault().ToString();
            return int.Parse(asd);
        }
        public static List<EAdopcion> BuscarAdopcion(int tipo, string numero)
        {
            try
            {
                SiGMAEntities mapa = Conexion.crearSegunServidor();
                List<EAdopcion> adopciones = new List<EAdopcion>();
                var consulta = from EstadosBD in mapa.Estados
                               join AdopcionesBD in mapa.Adopciones on EstadosBD.idEstado equals AdopcionesBD.idEstado into group1
                               from G1 in group1.DefaultIfEmpty()
                               join DuenioBD in mapa.Duenios on G1.idDuenio equals DuenioBD.idDuenio into group2
                               from G2 in group2.DefaultIfEmpty()
                               join PersonaBD in mapa.Personas on G2.idPersona equals PersonaBD.idPersona into group3
                               from G3 in group3.DefaultIfEmpty()
                               join TipoBD in mapa.TipoDocumentos on G3.idTipoDocumento equals TipoBD.idTipoDocumento into group4
                               from G4 in group4.DefaultIfEmpty()
                               where (G4.idTipoDocumento == tipo && G3.nroDocumento.Contains(numero) && G1.Estados.ambito == "Adopcion" && (G1.Estados.nombreEstado == "Modifcada" || G1.Estados.nombreEstado == "Abierta"))
                               select new
                               {
                                   est = EstadosBD,
                                   ado = G1,
                                   duenio = G2,
                                   persona = G3,
                                   Tipo = G4,
                               };
                foreach (var registro in consulta)
                {
                    EAdopcion adopcion = new EAdopcion();
                    adopcion.idAdopcion = registro.ado.idAdopcion;
                    adopciones.Add(adopcion);
                }
                return adopciones;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public static List<EAdopcion> BuscarAdopcion(int numeroDeAdopcion)
        {
            try
            {
                SiGMAEntities mapa = Conexion.crearSegunServidor();
                List<EAdopcion> adopciones = new List<EAdopcion>();
                IQueryable<Adopciones> consulta = from AdopcionesBD in mapa.Adopciones
                                                  join EstadosBD in mapa.Estados on AdopcionesBD.idEstado equals EstadosBD.idEstado
                                                  where (AdopcionesBD.idAdopcion == numeroDeAdopcion && EstadosBD.ambito == "Adopcion" && (EstadosBD.nombreEstado == "Abierta" || EstadosBD.nombreEstado == "Modificada"))
                                                  select AdopcionesBD;
                foreach (var registro in consulta)
                {
                    EAdopcion adopcion = new EAdopcion();
                    adopcion.idAdopcion = registro.idAdopcion;
                    adopciones.Add(adopcion);
                }
                return adopciones;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public static void BuscarAdopcion(EAdopcion adopcion, EPersona persona)
        {
            try
            {
                SiGMAEntities mapa = Conexion.crearSegunServidor();
                IQueryable<Adopciones> consulta = from AdopcioneBD in mapa.Adopciones
                                                  where (AdopcioneBD.idAdopcion == adopcion.idAdopcion)
                                                  select AdopcioneBD;
                foreach (var registro in consulta)
                {
                    adopcion.duenio = new EDuenio();
                    adopcion.duenio.idDuenio = registro.idDuenio;
                    adopcion.estado = new EEstado();
                    adopcion.estado.idEstado = registro.idEstado;
                    adopcion.fecha = registro.fechaAdopcion;
                    adopcion.idVoluntario = registro.idVoluntario;
                    adopcion.mascota = new EMascota();
                    adopcion.mascota.idMascota = registro.idMascota;
                }
                adopcion.mascota.raza = new ERaza();
                adopcion.mascota.estado = new EEstado();
                adopcion.mascota.especie = new EEspecie();
                adopcion.mascota.edad = new EEdad();
                adopcion.mascota.raza.CategoriaRaza = new ECategoriaRaza();
                adopcion.mascota.caracter = new ECaracterMascota();
                adopcion.mascota.cuidadoEspecial = new ECuidado();
                adopcion.mascota = LogicaBDMascota.BuscarMascotaPorIdMascota(adopcion.mascota.idMascota);
                IQueryable<Personas> usuarios = from PersonasBD in mapa.Personas
                                                from DueniosBD in mapa.Duenios
                                                where (DueniosBD.idPersona == PersonasBD.idPersona && DueniosBD.idDuenio == adopcion.duenio.idDuenio)
                                                select PersonasBD;
                foreach (var usuario in usuarios)
                {
                    persona.usuario = new EUsuario();
                    persona.usuario.user = usuario.user;
                }
                persona.tipoDocumento = new ETipoDeDocumento();
                persona.barrio = new EBarrio();
                persona.domicilio = new ECalle();
                persona.localidad = new ELocalidad();
                LogicaBDUsuario.BuscarUsuarios(persona.usuario.user, persona.usuario, persona, persona.barrio, persona.localidad, persona.tipoDocumento, persona.domicilio);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public static Boolean ModificarAdopcion(EAdopcion adopcion, EPersona persona){
            try
            {
                SiGMAEntities mapa = Conexion.crearSegunServidor();
                Mascotas mascota = mapa.Mascotas.Where(m => m.idMascota == adopcion.mascota.idMascota).First();
                mascota.nombreMascota = adopcion.mascota.nombreMascota;
                Adopciones a = mapa.Adopciones.Where(adopcionBD => adopcionBD.idAdopcion == adopcion.idAdopcion).First();
                a.idVoluntario = adopcion.idVoluntario;
                a.fechaAdopcion = adopcion.fecha;
                Personas personas = mapa.Personas.Where(personaBD => personaBD.idPersona == persona.idPersona).First();
                personas.idBarrio = persona.barrio.idBarrio;
                personas.Barrios.idLocalidad = persona.localidad.idLocalidad;
                mapa.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
