using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDPerdida
    {
        public static bool registrarPerdida(EPerdida perdida)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b = false;
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Perdidas bdPerdida = new Perdidas();
                    bdPerdida.idMascota = perdida.mascota.idMascota;
                    bdPerdida.idBarrioPerdida = perdida.domicilio.barrio.idBarrio;
                    var calle = ""+perdida.domicilio.calle.nombre +" "+ perdida.domicilio.numeroCalle;
                    var localBarrio = ", " + perdida.domicilio.barrio.nombre + ", " + perdida.domicilio.barrio.localidad.nombre;
                    bdPerdida.ubicacionPerdida = calle + localBarrio;
                    bdPerdida.idLocalidadPerdida = perdida.domicilio.barrio.localidad.idLocalidad;
                    bdPerdida.idCallePerdida = perdida.domicilio.calle.idCalle;
                    bdPerdida.nroCallePerdida = perdida.domicilio.numeroCalle.ToString();
                    bdPerdida.idUsuario = perdida.usuario.user;
                    bdPerdida.FechaHoraPerdida = perdida.fecha;
                    bdPerdida.observaciones = perdida.comentarios;
                    //bdPerdida.mapaPerdida = perdida.mapaPerdida;
                    LogicaBDMascota.modificarEstado("Perdida", perdida.mascota.idMascota, ref mapaEntidades);  
                    bdPerdida.idEstado = mapaEntidades.Estados.Where(es => es.ambito == "Perdida" && es.nombreEstado == "Abierta").First().idEstado;
                    mapaEntidades.AddToPerdidas(bdPerdida);
                    mapaEntidades.SaveChanges();
                    transaction.Complete();
                    b = true;
                }
                catch (System.Data.EntityCommandCompilationException exc)
                {
                    b = false;
                    throw exc;
                }
                return b;
            }
        }

        public static bool modificarPerdida(EPerdida perdida)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b = false;
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    var bdPerdida = mapaEntidades.Perdidas.Where(p => p.idPerdida == perdida.idPerdida);
                    foreach (var perd in bdPerdida)
                    {
                        var calle = "" + perdida.domicilio.calle.nombre + " " + perdida.domicilio.numeroCalle;
                        var localBarrio = ", " + perdida.domicilio.barrio.nombre + ", " + perdida.domicilio.barrio.localidad.nombre;
                        perd.ubicacionPerdida = calle + localBarrio;
                        perd.idLocalidadPerdida = perdida.domicilio.barrio.localidad.idLocalidad;
                        perd.idBarrioPerdida = perdida.domicilio.barrio.idBarrio;
                        perd.idCallePerdida = perdida.domicilio.calle.idCalle;
                        perd.nroCallePerdida = perdida.domicilio.numeroCalle.ToString();
                        perd.idUsuario = perdida.usuario.user;
                        perd.FechaHoraPerdida = perdida.fecha;
                        perd.observaciones = perdida.comentarios;
                        break;
                    }
                    //bdPerdida.mapaPerdida = perdida.mapaPerdida;
                    mapaEntidades.SaveChanges();
                    transaction.Complete();
                    b = true;
                }
                catch (System.Data.EntityCommandCompilationException exc)
                {
                    b = false;
                    throw exc;
                }
                return b;
            }
        }

        public static EPerdida buscarPerdidaPorIdMascota(EMascota mascota)
        {
            try
            {
                SiGMAEntities mapa = Conexion.crearSegunServidor();
                var bdPerdida = mapa.Perdidas.Where(p => p.idMascota == mascota.idMascota).OrderByDescending(p => p.idPerdida);
                EPerdida perdida = new EPerdida();
                foreach (var perd in bdPerdida)
                {                    
                    perdida.idPerdida = perd.idPerdida;
                    perdida.fecha = (DateTime)perd.FechaHoraPerdida;
                    perdida.mascota = mascota;
                    return perdida;
                    //Agregar domicilio!
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void modificarEstado(string estado, int idPerdidaParam, ref SiGMAEntities mapa)
        {       try
                {
                    Perdidas bdPerdida = mapa.Perdidas.Where(p => p.idPerdida == idPerdidaParam).First();
                    bdPerdida.idEstado = mapa.Estados.Where(es => es.ambito == "Perdida" && es.nombreEstado == estado).First().idEstado;                                      
                }
                catch (Exception)
                {                    
                    throw;
                }            
        }

        public static bool BuscarMascotaARegistrarPerdida(int idMascota, EMascota mascota, EDuenio duenio)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               join ColoresBD in mapaEntidades.Colores on MascotasBD.idColor equals ColoresBD.idColor
                               join edadesBD in mapaEntidades.Edades on MascotasBD.idEdad equals edadesBD.idEdad
                               join especiesBD in mapaEntidades.Especies on MascotasBD.idEspecie equals especiesBD.idEspecie
                               join DuenioBD in mapaEntidades.Duenios on MascotasBD.idDuenio equals DuenioBD.idDuenio into group1
                               from G1 in group1.DefaultIfEmpty()
                               join PersonaBD in mapaEntidades.Personas on G1.idPersona equals PersonaBD.idPersona into group2
                               from G2 in group2.DefaultIfEmpty()
                               join RazaBD in mapaEntidades.Razas on MascotasBD.idRaza equals RazaBD.idRaza
                               join CategoriaRazaBD in mapaEntidades.CategoriaRazas on RazaBD.idCategoriaRaza equals CategoriaRazaBD.idCategoriaRazas
                               join CaracterBD in mapaEntidades.CaracteresMascota on MascotasBD.idCaracter equals CaracterBD.idCaracter into group3
                               from G3 in group3.DefaultIfEmpty()
                               join BarrioBD in mapaEntidades.Barrios on G2.idBarrio equals BarrioBD.idBarrio into group4
                               from G4 in group4.DefaultIfEmpty()
                               join LocalidadBD in mapaEntidades.Localidades on G4.idLocalidad equals LocalidadBD.idLocalidad into group5
                               from G5 in group5.DefaultIfEmpty()
                               join calleBD in mapaEntidades.Calles on G2.idCalle equals calleBD.idCalle into group6
                               from G6 in group6.DefaultIfEmpty()
                               where ((MascotasBD.idEstado == 1 || MascotasBD.idEstado == 4 || MascotasBD.idEstado == 5) && MascotasBD.idMascota == idMascota)
                               select new
                               {
                                   nombre = MascotasBD.nombreMascota,
                                   estado = MascotasBD.idEstado,
                                   idEspecie = MascotasBD.idEspecie,
                                   especie = especiesBD.nombreEspecie,
                                   idEdad = MascotasBD.idEdad,
                                   edad = edadesBD.nombreEdad,
                                   raza = RazaBD.nombreRaza,
                                   idRaza = MascotasBD.idRaza,
                                   idColor = MascotasBD.idColor,
                                   color = ColoresBD.nombreColor,
                                   tratoA = MascotasBD.tratoAnimales,
                                   tratoN = MascotasBD.tratoNinios,
                                   sexo = MascotasBD.sexo,
                                   categoria = CategoriaRazaBD.nombreCategoriaRaza,
                                   idCaracter = G3.idCaracter,
                                   caracter = G3.descripcion,
                                   id = MascotasBD.idMascota,
                                   imagen = MascotasBD.imagen,
                                   dueñoNombre = (G2 == null) ? null : G2.nombre,
                                   dueñoApellido = (G2 == null) ? null : G2.apellido,
                                   domicilio = (G2 == null) ? null : G2.domicilio,
                                   idBarrio = (G4 == null) ? 0 : G4.idBarrio,
                                   barrio = (G4 == null) ? null : G4.nombre,
                                   localidad = (G5 == null) ? null : G5.nombre,
                                   idLcalidad = (G5 == null) ? 0 : G5.idLocalidad,
                                   calle = (G6 == null) ? 0 : G6.idCalle,
                                   nroCalle = (G2.nroCalle == null) ? 0 : G2.nroCalle
                               };
                foreach (var registro in consulta)
                {
                    mascota.caracter = new ECaracterMascota();
                    mascota.caracter.idCaracter = registro.idCaracter;
                    mascota.caracter.descripcion = registro.caracter;
                    mascota.raza = new ERaza();
                    mascota.raza.CategoriaRaza = new ECategoriaRaza();
                    mascota.raza.CategoriaRaza.nombreCategoriaRaza = registro.categoria;
                    mascota.raza.idRaza = registro.idRaza;
                    mascota.raza.nombreRaza = registro.raza;
                    mascota.color = new EColor();
                    mascota.color.idColor = registro.idColor;
                    mascota.color.nombreColor = registro.color;
                    mascota.nombreMascota = registro.nombre;
                    mascota.sexo = registro.sexo;
                    mascota.tratoAnimal = registro.tratoA;
                    mascota.tratoNiños = registro.tratoN;
                    mascota.idMascota = registro.id;
                    mascota.estado = new EEstado();
                    mascota.estado.idEstado = registro.estado;
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = registro.idEdad;
                    mascota.edad.nombreEdad = registro.edad;
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = registro.idEspecie;
                    mascota.especie.nombreEspecie = registro.especie;
                    duenio.apellido = registro.dueñoApellido;
                    duenio.nombre = registro.dueñoNombre;
                    duenio.barrio = new EBarrio();
                    duenio.barrio.idBarrio = registro.idBarrio;
                    duenio.barrio.nombre = registro.barrio;
                    duenio.barrio.localidad = new ELocalidad();
                    duenio.barrio.localidad.nombre = registro.localidad;
                    duenio.barrio.localidad.idLocalidad = registro.idLcalidad;
                    duenio.domicilio = new ECalle();
                    duenio.domicilio.idCalle = registro.calle;
                    duenio.nroCalle = registro.nroCalle;
                    if (registro.imagen != null)
                    {
                        mascota.imagen = registro.imagen;
                    }
                    else
                    {
                        mascota.imagen = null;
                    }
                }
                if (mascota.estado != null)
                    b = true;
                else
                    b = false;
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }

        public static bool BuscarMascotaAConsultarPerdida(int idMascota, EMascota mascota, EPerdida perdida)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               join PerdidasBD in mapaEntidades.Perdidas on MascotasBD.idMascota equals PerdidasBD.idMascota into group0
                               from G0 in group0.DefaultIfEmpty()
                               join ColoresBD in mapaEntidades.Colores on MascotasBD.idColor equals ColoresBD.idColor
                               join edadesBD in mapaEntidades.Edades on MascotasBD.idEdad equals edadesBD.idEdad
                               join especiesBD in mapaEntidades.Especies on MascotasBD.idEspecie equals especiesBD.idEspecie
                               join DuenioBD in mapaEntidades.Duenios on MascotasBD.idDuenio equals DuenioBD.idDuenio into group1
                               from G1 in group1.DefaultIfEmpty()
                               join PersonaBD in mapaEntidades.Personas on G1.idPersona equals PersonaBD.idPersona into group2
                               from G2 in group2.DefaultIfEmpty()
                               join RazaBD in mapaEntidades.Razas on MascotasBD.idRaza equals RazaBD.idRaza
                               join CategoriaRazaBD in mapaEntidades.CategoriaRazas on RazaBD.idCategoriaRaza equals CategoriaRazaBD.idCategoriaRazas
                               join CaracterBD in mapaEntidades.CaracteresMascota on MascotasBD.idCaracter equals CaracterBD.idCaracter into group3
                               from G3 in group3.DefaultIfEmpty()
                               join BarrioBD in mapaEntidades.Barrios on G2.idBarrio equals BarrioBD.idBarrio into group4
                               from G4 in group4.DefaultIfEmpty()
                               join LocalidadBD in mapaEntidades.Localidades on G4.idLocalidad equals LocalidadBD.idLocalidad into group5
                               from G5 in group5.DefaultIfEmpty()
                               join calleBD in mapaEntidades.Calles on G2.idCalle equals calleBD.idCalle into group6
                               from G6 in group6.DefaultIfEmpty()
                               where ((MascotasBD.idEstado == 3) && MascotasBD.idMascota == idMascota)
                               select new
                               {
                                   nombre = MascotasBD.nombreMascota,
                                   estado = MascotasBD.idEstado,
                                   idEspecie = MascotasBD.idEspecie,
                                   especie = especiesBD.nombreEspecie,
                                   idEdad = MascotasBD.idEdad,
                                   edad = edadesBD.nombreEdad,
                                   raza = RazaBD.nombreRaza,
                                   idRaza = MascotasBD.idRaza,
                                   idCuidado = (RazaBD.idCuidadoEspecial == null) ? 0 : (int)RazaBD.idCuidadoEspecial,//agregado
                                   idColor = MascotasBD.idColor,
                                   color = ColoresBD.nombreColor,
                                   tratoA = MascotasBD.tratoAnimales,
                                   tratoN = MascotasBD.tratoNinios,
                                   sexo = MascotasBD.sexo,
                                   categoria = CategoriaRazaBD.nombreCategoriaRaza,
                                   idCaracter = G3.idCaracter,
                                   caracter = G3.descripcion,
                                   id = MascotasBD.idMascota,
                                   imagen = MascotasBD.imagen,
                                   dueñoNombre = (G2 == null) ? null : G2.nombre,
                                   dueñoApellido = (G2 == null) ? null : G2.apellido,
                                   domicilio = (G2 == null) ? null : G2.domicilio,
                                   idBarrio = (G4 == null) ? 0 : G4.idBarrio,
                                   barrio = (G4 == null) ? null : G4.nombre,
                                   localidad = (G5 == null) ? null : G5.nombre,
                                   calle = (G6 == null) ? 0 : G6.idCalle,
                                   nroCalle = (G2.nroCalle == null) ? 0 : G2.nroCalle,
                                   idPerdida = (G0.idPerdida == null) ? 0 : G0.idPerdida,
                                   idLocalidadPerdidad = (G0.idLocalidadPerdida == null) ? 0 : G0.idLocalidadPerdida,
                                   fechaPerdida = (G0.FechaHoraPerdida == null) ? null : G0.FechaHoraPerdida,
                                   idBarrioPerdida = (G0.idBarrioPerdida == null) ? 0 : G0.idBarrioPerdida,
                                   idCallePerdida = (G0.idCallePerdida == null) ? 0 : G0.idCallePerdida,
                                   nroCallePerdida = (G0.nroCallePerdida == null) ? null : G0.nroCallePerdida,
                                   comentarios = G0.observaciones
                               };
                foreach (var registro in consulta)
                {
                    perdida.domicilio = new EDomicilio();
                    perdida.domicilio.barrio = new EBarrio();
                    perdida.domicilio.barrio.localidad = new ELocalidad();
                    perdida.domicilio.calle = new ECalle();
                    perdida.domicilio.barrio.idBarrio = registro.idBarrioPerdida;
                    perdida.domicilio.barrio.localidad.idLocalidad = registro.idLocalidadPerdidad;
                    perdida.domicilio.calle.idCalle = registro.idCallePerdida;
                    perdida.domicilio.numeroCalle = Convert.ToInt32(registro.nroCallePerdida);
                    perdida.idPerdida = registro.idPerdida;
                    perdida.fecha = Convert.ToDateTime(registro.fechaPerdida);
                    perdida.comentarios = registro.comentarios;
                    mascota.caracter = new ECaracterMascota();
                    mascota.caracter.idCaracter = registro.idCaracter;
                    mascota.caracter.descripcion = registro.caracter;
                    mascota.raza = new ERaza();
                    mascota.raza.CategoriaRaza = new ECategoriaRaza();
                    mascota.raza.CategoriaRaza.nombreCategoriaRaza = registro.categoria;
                    mascota.raza.idRaza = registro.idRaza;
                    mascota.raza.nombreRaza = registro.raza;
                    mascota.color = new EColor();
                    mascota.color.idColor = registro.idColor;
                    mascota.color.nombreColor = registro.color;
                    mascota.nombreMascota = registro.nombre;
                    mascota.sexo = registro.sexo;
                    mascota.tratoAnimal = registro.tratoA;
                    mascota.tratoNiños = registro.tratoN;
                    mascota.idMascota = registro.id;
                    mascota.estado = new EEstado();
                    mascota.estado.idEstado = registro.estado;
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = registro.idEdad;
                    mascota.edad.nombreEdad = registro.edad;
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = registro.idEspecie;
                    mascota.especie.nombreEspecie = registro.especie;
                    mascota.duenio = new EDuenio();
                    mascota.duenio.apellido = registro.dueñoApellido;
                    mascota.duenio.nombre = registro.dueñoNombre;
                    mascota.duenio.barrio = new EBarrio();
                    mascota.duenio.barrio.idBarrio = registro.idBarrio;
                    mascota.duenio.barrio.nombre = registro.barrio;
                    mascota.duenio.barrio.localidad = new ELocalidad();
                    mascota.duenio.barrio.localidad.nombre = registro.localidad;
                    mascota.duenio.domicilio = new ECalle();
                    mascota.duenio.domicilio.idCalle = registro.calle;
                    mascota.duenio.nroCalle = registro.nroCalle;
                    mascota.raza.cuidadoEspecial = new ECuidado();
                    mascota.raza.cuidadoEspecial.idCuidado = registro.idCuidado;//agregado
                    if (registro.imagen != null)
                    {
                        mascota.imagen = registro.imagen;
                    }
                    else
                    {
                        mascota.imagen = null;
                    }
                }
                if (mascota.estado != null)
                    b = true;
                else
                    b = false;
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        public static List<EPerdida> BuscarPerdidas()
        {
            List<EPerdida> aux = new List<EPerdida>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from PerdidasBD in mapa.Perdidas
                           join EstadosBD in mapa.Estados on PerdidasBD.idEstado equals EstadosBD.idEstado into group1
                           from G0 in group1.DefaultIfEmpty()
                           join UsuarioBD in mapa.Usuarios on PerdidasBD.idUsuario equals UsuarioBD.user into group2
                           from G1 in group2.DefaultIfEmpty()
                           join MascotaBD in mapa.Mascotas on PerdidasBD.idMascota equals MascotaBD.idMascota into group3
                           from G2 in group3.DefaultIfEmpty()
                           join BarrioBD in mapa.Barrios on PerdidasBD.idBarrioPerdida equals BarrioBD.idBarrio into group4
                           from G3 in group4.DefaultIfEmpty()
                           join LocalidadesBD in mapa.Localidades on PerdidasBD.idLocalidadPerdida equals LocalidadesBD.idLocalidad into group5
                           from G4 in group5.DefaultIfEmpty()
                           join CalleBD in mapa.Calles on PerdidasBD.idCallePerdida equals CalleBD.idCalle into group6
                           from G5 in group6.DefaultIfEmpty()
                           select new
                           {
                               Barrio = G3,
                               Mascota = G2,
                               Usuario = G1,
                               perdida = PerdidasBD,
                               estado = G0,
                               localidad = G4,
                               calle =  G5,
                           };
            foreach (var registro in consulta)
            {
                EPerdida perdida = new EPerdida();
                perdida.barrio = new EBarrio();
                perdida.barrio.nombre = registro.Barrio.nombre;
                perdida.barrio.localidad = new ELocalidad();
                perdida.barrio.localidad.nombre = (registro.perdida.idLocalidadPerdida == null) ? "" : registro.localidad.nombre;
                perdida.estado = new EEstado();
                perdida.usuario = new EUsuario();
                perdida.usuario.user = registro.Usuario.user;
                perdida.estado.nombreEstado = registro.estado.nombreEstado;
                perdida.idPerdida = registro.perdida.idPerdida;
                perdida.mascota = new EMascota();
                perdida.mascota.nombreMascota = registro.Mascota.nombreMascota;
                perdida.mascota.idMascota = registro.Mascota.idMascota;
                perdida.fecha = (DateTime)registro.perdida.FechaHoraPerdida;
                perdida.domicilio = new EDomicilio();
                perdida.domicilio.calle = new ECalle();
                perdida.domicilio.calle.nombre = (registro.perdida.idCallePerdida == null) ? "" : registro.calle.nombre;
                perdida.domicilio.numeroCalle = (registro.perdida.nroCallePerdida == null) ? 0 : int.Parse(registro.perdida.nroCallePerdida);
                perdida.ubicacion = registro.perdida.ubicacionPerdida;
                perdida.comentarios = registro.perdida.observaciones;
                aux.Add(perdida);
            }
            return aux;
        }
        public static List<EPerdida> BuscarPerdidasPorOpciones(EPerdida perdida){
            List<EPerdida> perdidas = LogicaBDPerdida.BuscarPerdidas();
            if(!perdida.fecha.Equals("01/01/2013")){
                if(perdida.estado != null){
                    if(perdida.barrio != null){
                        perdidas = perdidas.Where(p => p.barrio.nombre == perdida.barrio.nombre && (p.fecha >= perdida.fecha) && p.estado.nombreEstado == perdida.estado.nombreEstado).ToList();
                    }
                    else{
                        perdidas = perdidas.Where(p => (p.fecha >= perdida.fecha) && p.estado.nombreEstado == perdida.estado.nombreEstado).ToList();
                    }
                }
                else{
                    if (perdida.barrio != null)
                    {
                        perdidas = perdidas.Where(p => p.barrio.nombre == perdida.barrio.nombre && (p.fecha >= perdida.fecha)).ToList();
                    }
                    else{
                            perdidas = perdidas.Where(p => (p.fecha >= perdida.fecha)).ToList();
                    }
                }
            }
            else if (perdida.barrio != null)
            {
                if (perdida.estado != null)
                {
                    perdidas = perdidas.Where(p => p.barrio.nombre == perdida.barrio.nombre && p.estado.nombreEstado == perdida.estado.nombreEstado).ToList();
                }
                else
                {
                    perdidas = perdidas.Where(p => p.barrio.nombre == perdida.barrio.nombre).ToList();
                }
            }
            else
            {
                perdidas = perdidas.Where(p => p.estado.nombreEstado == perdida.estado.nombreEstado).ToList();
            }
            return perdidas;
        }
    }
}
