using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;
namespace AccesoADatos
{
    public class LogicaBDMascotas
    {
        public static void registrarMascota(EMascota mascota, byte[] imagen)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Mascotas bdMascota = new Mascotas();
                    bdMascota.idEstado = mascota.estado.idEstado;
                    bdMascota.nombreMascota = mascota.nombreMascota;
                    bdMascota.idEspecie = mascota.especie.idEspecie;
                    bdMascota.idRaza = mascota.raza.idRaza;                   
                    bdMascota.idEdad = mascota.edad.idEdad;
                    bdMascota.idColor = mascota.color.idColor;
                    bdMascota.idDuenio = mascota.duenio.idDuenio;
                    if (mascota.caracter.idCaracter != 0)
                    {
                        bdMascota.idCaracter = mascota.caracter.idCaracter;
                    }
                    if (!mascota.tratoAnimal.Equals("0"))
                    {
                        bdMascota.tratoAnimales = mascota.tratoAnimal;
                    }
                    if (!mascota.tratoNiños.Equals("0"))
                    {
                        bdMascota.tratoNinios = mascota.tratoNiños;
                    }
                    if (!mascota.observaciones.Equals(""))
                    {
                        bdMascota.observaciones = mascota.observaciones;
                    }
                    if (!mascota.alimentacionEspecial.Equals(""))
                    {
                        bdMascota.alimentacionEspecial = mascota.alimentacionEspecial;
                    }
                    if (!mascota.fechaNacimiento.Equals(new DateTime()))
                    {
                        bdMascota.fechaNacimiento = mascota.fechaNacimiento.Date;
                    }
                    bdMascota.sexo = mascota.sexo;
                    mapaEntidades.AddToMascotas(bdMascota);
                    mapaEntidades.SaveChanges();
                    if (imagen != null)
                    {
                        mascota.idMascota = mapaEntidades.Mascotas.OrderByDescending(m => m.idMascota).First().idMascota;
                        LogicaBDImagen.guardarImagen(imagen, mascota);
                    }
                    transaction.Complete();
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
            }
        }
        
        public static bool BuscarMascota(EMascota mascota, ECategoriaRaza categoria, ECaracterMascota caracter, ECuidado cuidado, int idMascota)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               from RazaBD in mapaEntidades.Razas
                               from CategoriaRazaBD in mapaEntidades.CategoriaRazas
                               from CaracterBD in mapaEntidades.CaracteresMascota
                               from CuidadoEspecialBD in mapaEntidades.CuidadosEspeciales
                               where (MascotasBD.idRaza == RazaBD.idRaza 
                               && CuidadoEspecialBD.idCuidadoEspecial == RazaBD.idCuidadoEspecial && RazaBD.idCategoriaRaza == CategoriaRazaBD.idCategoriaRazas 
                               && MascotasBD.idCaracter == CaracterBD.idCaracter && MascotasBD.idMascota == idMascota && MascotasBD.idEstado != 6)
                               select new
                               {
                                   nombre = MascotasBD.nombreMascota,
                                   estado = MascotasBD.idEstado,
                                   especie = MascotasBD.idEspecie,
                                   edad = MascotasBD.idEdad,
                                   raza = MascotasBD.idRaza,
                                   color = MascotasBD.idColor,
                                   tratoA = MascotasBD.tratoAnimales,
                                   tratoN = MascotasBD.tratoNinios,
                                   observaciones = MascotasBD.observaciones,
                                   alimentacion = MascotasBD.alimentacionEspecial,
                                   fecha = MascotasBD.fechaNacimiento,
                                   sexo = MascotasBD.sexo,
                                   categoria = CategoriaRazaBD.nombreCategoriaRaza,
                                   caracter = CaracterBD.idCaracter,
                                   Cuidado = CuidadoEspecialBD.descripcion,
                                   id = MascotasBD.idMascota,
                                   imagen = MascotasBD.imagen
                               };
                foreach (var registro in consulta)
                {
                    mascota.alimentacionEspecial = registro.alimentacion;
                    caracter.idCaracter = registro.caracter;
                    categoria.nombreCategoriaRaza = registro.categoria;
                    mascota.raza = new ERaza();
                    mascota.raza.idRaza = registro.raza;
                    if (registro.fecha != null)
                    {
                        mascota.fechaNacimiento = (DateTime)registro.fecha;
                    }
                    else
                    {
                        mascota.fechaNacimiento = DateTime.Now;
                    }
                    mascota.color = new EColor();
                    mascota.color.idColor = registro.color;
                    mascota.nombreMascota = registro.nombre;
                    mascota.observaciones = registro.observaciones;
                    mascota.sexo = registro.sexo;
                    mascota.tratoAnimal = registro.tratoA;
                    mascota.tratoNiños = registro.tratoN;
                    cuidado.descripcion = registro.Cuidado;
                    mascota.idMascota = registro.id;
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = registro.edad;
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = registro.especie;
                    mascota.estado = new EEstado();
                    mascota.estado.idEstado = registro.estado;
                    if (registro.imagen != null){
                        mascota.imagen = registro.imagen;
                    }
                    else
                    {
                        mascota.imagen = null;
                    }
                }
                b = true;
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        public static List<EMascota> BuscarMascotaPorduenio(string duenio)
        {
            List<EMascota> mascotas = new List<EMascota>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas
                                            from DueniosBD in mapaEntidades.Duenios
                                            from PersonasBD in mapaEntidades.Personas
                                            where (DueniosBD.idPersona == PersonasBD.idPersona && MascotasBD.idDuenio == DueniosBD.idDuenio && PersonasBD.nombre.Contains(duenio) && MascotasBD.idEstado != 6)
                                            select MascotasBD;
            try
            {
                foreach (var registro in consulta)
                {
                    EMascota mascota = new EMascota();
                    mascota.nombreMascota = registro.nombreMascota;
                    mascota.idMascota = registro.idMascota;
                    mascotas.Add(mascota);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return mascotas;
        }

        public static List<EMascota> BuscarMascotaPorIdDueño(int idDueño)
        {
            List<EMascota> mascotas = new List<EMascota>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas
                                            from DueniosBD in mapaEntidades.Duenios
                                            from PersonasBD in mapaEntidades.Personas
                                            where (DueniosBD.idPersona == PersonasBD.idPersona && MascotasBD.idDuenio == DueniosBD.idDuenio && DueniosBD.idDuenio == idDueño && MascotasBD.idEstado != 6)
                                            select MascotasBD;
            try
            {
                foreach (var registro in consulta)
                {
                    EMascota mascota = new EMascota();
                    mascota.nombreMascota = registro.nombreMascota;
                    mascota.idMascota = registro.idMascota;
                    mascotas.Add(mascota);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return mascotas;
        }

        public static bool ModificarMascota(EMascota mascota, byte[] imagen )
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = mapaEntidades.Mascotas.Where(mascotasBuscadas => mascotasBuscadas.idMascota == mascota.idMascota);
                foreach (var registro in consulta)
                {
                    registro.alimentacionEspecial = registro.alimentacionEspecial;
                    registro.idCaracter = mascota.caracter.idCaracter;
                    registro.idEdad = mascota.edad.idEdad;
                    registro.idEspecie = mascota.especie.idEspecie;
                    registro.idEstado = mascota.estado.idEstado;
                    registro.idRaza = mascota.raza.idRaza;
                    registro.nombreMascota = mascota.nombreMascota;
                    registro.observaciones = mascota.observaciones;
                    registro.idColor = mascota.color.idColor;
                    registro.sexo = mascota.sexo;
                    registro.tratoAnimales = mascota.tratoAnimal;
                    registro.tratoNinios = mascota.tratoNiños;
                    registro.idCaracter = mascota.caracter.idCaracter;
                }
                if (imagen != null)
                {
                    LogicaBDImagen.guardarImagen(imagen, mascota);
                    b = true;
                    mapaEntidades.SaveChanges();
                }
                else
                {
                    LogicaBDImagen.guardarImagen(null, mascota);
                    b = true;
                    mapaEntidades.SaveChanges();
                }
            }
            catch (InvalidOperationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        public static List<EMascota> BuscarMascotaPorMascota(string nombre)
        {
            List<EMascota> mascotas = new List<EMascota>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas                                            
                                            where (MascotasBD.nombreMascota.Contains(nombre) && MascotasBD.idEstado != 6)
                                            select MascotasBD;
            try
            {
                foreach (var registro in consulta)
                {
                    EMascota mascota = new EMascota();
                    mascota.nombreMascota = registro.nombreMascota;
                    mascota.idMascota = registro.idMascota;
                    mascotas.Add(mascota);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return mascotas;
        }
        public static bool BuscarMascotaPorIdMascota(int idMascota, EMascota mascota) 
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
                    if (registro.imagen != null)
                    {
                        mascota.imagen = registro.imagen;
                    }
                    else
                    {
                        mascota.imagen = null;
                    }
                }
                b = true;
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        //Metodo que busca una mascota realmente por idMascota, sin filtros fantasmas, y devuelve la mascota con todos sus datos
        //en su estructura
        public static EMascota BuscarMascotaPorIdMascota(int idMascota)
        {
            EMascota mascota = new EMascota();
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               join ColoresBD in mapaEntidades.Colores on MascotasBD.idColor equals ColoresBD.idColor
                               join edadesBD in mapaEntidades.Edades on MascotasBD.idEdad equals edadesBD.idEdad
                               join especiesBD in mapaEntidades.Especies on MascotasBD.idEspecie equals especiesBD.idEspecie                               
                               join RazaBD in mapaEntidades.Razas on MascotasBD.idRaza equals RazaBD.idRaza
                               join CategoriaRazaBD in mapaEntidades.CategoriaRazas on RazaBD.idCategoriaRaza equals CategoriaRazaBD.idCategoriaRazas
                               join CaracterBD in mapaEntidades.CaracteresMascota on MascotasBD.idCaracter equals CaracterBD.idCaracter into group3
                               from G3 in group3.DefaultIfEmpty()                               
                               where (MascotasBD.idMascota == idMascota)
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
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = registro.idEdad;
                    mascota.edad.nombreEdad = registro.edad;
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = registro.idEspecie;
                    mascota.especie.nombreEspecie = registro.especie;                    
                    if (registro.imagen != null)
                    {
                        mascota.imagen = registro.imagen;
                    }
                    else
                    {
                        mascota.imagen = null;
                    }
                }
                return mascota;
            }
            catch (Exception exc)
            {
                return null;
            }            
        }
        public static bool Eliminar(int idMascota)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            bool b = false;
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas
                                            where ( MascotasBD.idMascota == idMascota)
                                            select MascotasBD;
            if(consulta.Count() != 0)
            {
                try
                {
                    var mascotas = mapaEntidades.Mascotas.Where( mascotasBuscadas => mascotasBuscadas.idMascota == idMascota).Single();
                    foreach (var registro in consulta)
                    {
                        registro.idEstado = 6;
                    }
                    mapaEntidades.SaveChanges();
                    b = true;
                }
                catch(System.Data.UpdateException exc){
                    b = false;
                    throw exc;
                }
            }
            return b;
        }

        public static bool registrarPerdida(EPerdida perdida)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                Perdidas bdPerdida = new Perdidas();
                bdPerdida.idMascota = perdida.mascota.idMascota;
                bdPerdida.idBarrioPerdida = perdida.barrio.idBarrio;
                bdPerdida.idUsuario = perdida.usuario.user;
                bdPerdida.FechaHoraPerdida = perdida.fecha;
                bdPerdida.observaciones = perdida.comentarios;
                bdPerdida.mapaPerdida = perdida.mapaPerdida;
                mapaEntidades.AddToPerdidas(bdPerdida);
                mapaEntidades.SaveChanges();
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
}