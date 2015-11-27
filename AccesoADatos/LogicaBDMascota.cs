using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDMascota
    {
        public static void registrarMascota(EMascota mascota)
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
                        if (mascota.fechaNacimiento != null)
                            bdMascota.fechaNacimiento = mascota.fechaNacimiento.Value.Date;
                        else
                            bdMascota.fechaNacimiento = null;
                    }
                    bdMascota.sexo = mascota.sexo;
                    bdMascota.noMostrar = false;
                    mapaEntidades.AddToMascotas(bdMascota);
                    mapaEntidades.SaveChanges();
                    if (mascota.imagen != null)
                    {
                        mascota.idMascota = mapaEntidades.Mascotas.OrderByDescending(m => m.idMascota).First().idMascota;
                        LogicaBDImagen.guardarImagen(mascota.imagen, mascota);
                    }
                    
                    transaction.Complete();                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
            }
        }

        public static void registrarMascota(EMascota mascota, ref SiGMAEntities mapaEntidades)
        {
            try
            {                
                Mascotas bdMascota = new Mascotas();
                bdMascota.idEstado = mascota.estado.idEstado;
                bdMascota.nombreMascota = mascota.nombreMascota;
                bdMascota.idEspecie = mascota.especie.idEspecie;
                bdMascota.idRaza = mascota.raza.idRaza;
                bdMascota.idColor = mascota.color.idColor;
                bdMascota.idEdad = mascota.edad.idEdad;                               
                bdMascota.sexo = mascota.sexo;
                bdMascota.noMostrar = false;//por defecto
                mapaEntidades.AddToMascotas(bdMascota);                              
            }
            catch (Exception exc)
            {                    
                throw exc;
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
                               from EdadesBD in mapaEntidades.Edades
                               from EspeciesBD in mapaEntidades.Especies
                               where (MascotasBD.idEspecie == EspeciesBD.idEspecie && MascotasBD.idRaza == RazaBD.idRaza && MascotasBD.idEdad == EdadesBD.idEdad
                               && CuidadoEspecialBD.idCuidadoEspecial == RazaBD.idCuidadoEspecial && RazaBD.idCategoriaRaza == CategoriaRazaBD.idCategoriaRazas 
                               && MascotasBD.idCaracter == CaracterBD.idCaracter && MascotasBD.idMascota == idMascota)
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
                                   imagen = MascotasBD.imagen,
                                   razaN = RazaBD.nombreRaza,
                                   edadN = EdadesBD.nombreEdad,
                                   nombreEspecie =EspeciesBD.nombreEspecie,
                                   noMostrar = MascotasBD.noMostrar//modifique
                               };
                foreach (var registro in consulta)
                {
                    mascota.especie = new EEspecie();
                    mascota.alimentacionEspecial = registro.alimentacion;
                    caracter.idCaracter = registro.caracter;
                    categoria.nombreCategoriaRaza = registro.categoria;
                    mascota.raza = new ERaza();
                    mascota.raza.idRaza = registro.raza;
                    if (registro.fecha != null)
                    {
                        mascota.fechaNacimiento = (DateTime)registro.fecha;
                    }
                    mascota.color = new EColor();
                    mascota.color.idColor = registro.color;
                    mascota.nombreMascota = registro.nombre;
                    mascota.observaciones = registro.observaciones;
                    mascota.sexo = registro.sexo;
                    mascota.tratoAnimal = registro.tratoA;
                    mascota.especie.nombreEspecie = registro.nombreEspecie;
                    mascota.tratoNiños = registro.tratoN;
                    cuidado.descripcion = registro.Cuidado;
                    mascota.idMascota = registro.id;
                    mascota.edad = new EEdad();
                    mascota.edad.idEdad = registro.edad;
                    mascota.especie.idEspecie = registro.especie;
                    mascota.estado = new EEstado();
                    mascota.estado.idEstado = registro.estado;
                    mascota.raza.nombreRaza = registro.razaN;
                    mascota.edad.nombreEdad = registro.edadN;
                    if (registro.imagen != null){
                        mascota.imagen = registro.imagen;
                    }
                    else
                    {
                        mascota.imagen = null;
                    }
                    mascota.noMostrar = (bool)registro.noMostrar;//modificado
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
                                            where (DueniosBD.idPersona == PersonasBD.idPersona && MascotasBD.idDuenio == DueniosBD.idDuenio && (PersonasBD.nombre.ToLower().Contains(duenio.ToLower()) || PersonasBD.apellido.ToLower().Contains(duenio.ToLower())) && MascotasBD.idEstado != 6)
                                            select MascotasBD;
            try
            {
                foreach (var registro in consulta)
                {
                    EMascota mascota = new EMascota();
                    mascota.nombreMascota = registro.nombreMascota;
                    mascota.idMascota = registro.idMascota;
                    mascota.noMostrar = (bool)registro.noMostrar;//modificado
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
                    mascota.noMostrar = (bool)registro.noMostrar;//modificado
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
                    registro.fechaNacimiento = mascota.fechaNacimiento;
                    registro.tratoAnimales = mascota.tratoAnimal;
                    registro.tratoNinios = mascota.tratoNiños;
                    registro.idCaracter = mascota.caracter.idCaracter;
                    registro.noMostrar = mascota.noMostrar;//modificar
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

        public static bool Eliminar(int idMascota)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            bool b = false;
            IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas
                                            where (MascotasBD.idMascota == idMascota)
                                            select MascotasBD;
            if (consulta.Count() != 0)
            {
                try
                {
                    var mascotas = mapaEntidades.Mascotas.Where(mascotasBuscadas => mascotasBuscadas.idMascota == idMascota).Single();
                    foreach (var registro in consulta)
                    {
                        registro.idEstado = 6;
                    }
                    mapaEntidades.SaveChanges();
                    b = true;
                }
                catch (System.Data.UpdateException exc)
                {
                    b = false;
                    throw exc;
                }
            }
            return b;
        }//no se usa

        //Metodo que busca una mascota realmente por idMascota, sin filtros fantasmas, y devuelve la mascota con todos sus datos
        //en su estructura
        public static EMascota BuscarMascotaPorIdMascota(int idMascota)
        {
            EMascota mascota = null;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               join EstadosBD in mapaEntidades.Estados on MascotasBD.idEstado equals EstadosBD.idEstado
                               join ColoresBD in mapaEntidades.Colores on MascotasBD.idColor equals ColoresBD.idColor
                               join edadesBD in mapaEntidades.Edades on MascotasBD.idEdad equals edadesBD.idEdad
                               join especiesBD in mapaEntidades.Especies on MascotasBD.idEspecie equals especiesBD.idEspecie
                               join RazaBD in mapaEntidades.Razas on MascotasBD.idRaza equals RazaBD.idRaza
                               join CategoriaRazaBD in mapaEntidades.CategoriaRazas on RazaBD.idCategoriaRaza equals CategoriaRazaBD.idCategoriaRazas
                               join CaracterBD in mapaEntidades.CaracteresMascota on MascotasBD.idCaracter equals CaracterBD.idCaracter into group3
                               from G3 in group3.DefaultIfEmpty()
                               join cuidadosBD in mapaEntidades.CuidadosEspeciales on RazaBD.idCuidadoEspecial equals cuidadosBD.idCuidadoEspecial into group2
                               from G2 in group2.DefaultIfEmpty(null)
                               where (MascotasBD.idMascota == idMascota)
                               select new
                               {
                                   nombre = MascotasBD.nombreMascota,
                                   fechaNacimiento = MascotasBD.fechaNacimiento,
                                   idEstado = MascotasBD.idEstado,
                                   estado = EstadosBD.nombreEstado,
                                   idEspecie = MascotasBD.idEspecie,
                                   especie = especiesBD.nombreEspecie,
                                   descripcionEdad = edadesBD.descripcion,
                                   idEdad = MascotasBD.idEdad,
                                   observacion = MascotasBD.observaciones,
                                   edad = edadesBD.nombreEdad,
                                   raza = RazaBD.nombreRaza,
                                   idRaza = MascotasBD.idRaza,
                                   idColor = MascotasBD.idColor,
                                   color = ColoresBD.nombreColor,
                                   tratoA = MascotasBD.tratoAnimales,
                                   tratoN = MascotasBD.tratoNinios,
                                   alimentacion = MascotasBD.alimentacionEspecial,
                                   sexo = MascotasBD.sexo,
                                   categoria = CategoriaRazaBD.nombreCategoriaRaza,
                                   idCategoria = CategoriaRazaBD.idCategoriaRazas,
                                   idCaracter = (G3 == null) ? 0 : G3.idCaracter,
                                   caracter = (G3 == null) ? null : G3.descripcion,
                                   idCuidado = (G2 == null) ? 0 : G2.idCuidadoEspecial,
                                   descripcionCuidados = (G2 == null) ? null : G2.descripcion,
                                   id = MascotasBD.idMascota,
                                   imagen = MascotasBD.imagen,
                                   noMostrar = MascotasBD.noMostrar,//modificado
                               };
                foreach (var registro in consulta)
                {
                    mascota = new EMascota();
                    mascota.caracter = new ECaracterMascota();
                    mascota.estado = new EEstado();
                    mascota.estado.nombreEstado = registro.estado;
                    mascota.estado.idEstado = registro.idEstado;
                    mascota.caracter.idCaracter = registro.idCaracter;
                    mascota.caracter.descripcion = registro.caracter;
                    mascota.raza = new ERaza();
                    mascota.raza.CategoriaRaza = new ECategoriaRaza();
                    mascota.raza.cuidadoEspecial = new ECuidado();
                    mascota.raza.cuidadoEspecial.idCuidado = registro.idCuidado;
                    mascota.raza.cuidadoEspecial.descripcion = registro.descripcionCuidados;
                    mascota.raza.CategoriaRaza.idCategoriaRaza = registro.idCategoria;
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
                    mascota.edad.descripcion = registro.descripcionEdad;
                    mascota.especie = new EEspecie();
                    mascota.especie.idEspecie = registro.idEspecie;
                    mascota.especie.nombreEspecie = registro.especie;
                    mascota.noMostrar = (bool)registro.noMostrar;//modificado
                    mascota.fechaNacimiento = registro.fechaNacimiento;
                    mascota.observaciones = registro.observacion;
                    mascota.alimentacionEspecial = registro.alimentacion;
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

        //Metodo que busca las mascotas que cumplen con los filtros requeridos        
        public static List<EMascota> buscarMascotasFiltros(EMascota mascota)
        {
            List<EMascota> listaMascotas = null;
            if (mascota.nombreMascota != null)
            {
                listaMascotas = buscarMascotasPorNombre(mascota.nombreMascota);
                if (listaMascotas != null)
                {
                    if (mascota.estado != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.estado.nombreEstado == mascota.estado.nombreEstado).ToList();
                    }
                    if (mascota.especie != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.especie.idEspecie == mascota.especie.idEspecie).ToList();
                    }
                    if (mascota.edad != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.edad.idEdad == mascota.edad.idEdad).ToList();
                    }
                    if (mascota.raza != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.raza.idRaza == mascota.raza.idRaza).ToList();
                    }
                    if (mascota.color != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.color.idColor == mascota.color.idColor).ToList();
                    }
                    if (mascota.tratoAnimal != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.tratoAnimal == mascota.tratoAnimal).ToList();
                    }
                    if (mascota.tratoNiños != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.tratoNiños == mascota.tratoNiños).ToList();
                    }
                    if (mascota.caracter != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.caracter.idCaracter == mascota.caracter.idCaracter).ToList();
                    }
                    if (mascota.fechaNacimiento != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                    }
                    if (mascota.sexo != null)
                    {
                        listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                    }
                }
            }
            else 
            {
                if (mascota.estado != null)
                {
                    listaMascotas = buscarMascotasPorEstado(mascota.estado.nombreEstado);
                    if (listaMascotas != null)
                    {
                        if (mascota.especie != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.especie.idEspecie == mascota.especie.idEspecie).ToList();
                        }
                        if (mascota.edad != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.edad.idEdad == mascota.edad.idEdad).ToList();
                        }
                        if (mascota.raza != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.raza.idRaza == mascota.raza.idRaza).ToList();
                        }
                        if (mascota.color != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.color.idColor == mascota.color.idColor).ToList();
                        }
                        if (mascota.tratoAnimal != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.tratoAnimal == mascota.tratoAnimal).ToList();
                        }
                        if (mascota.tratoNiños != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.tratoNiños == mascota.tratoNiños).ToList();
                        }
                        if (mascota.caracter != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.caracter.idCaracter == mascota.caracter.idCaracter).ToList();
                        }
                        if (mascota.fechaNacimiento != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                        }
                        if (mascota.sexo != null)
                        {
                            listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                        }
                    }
                }
                else
                {
                    if (mascota.raza != null)
                    {
                        listaMascotas = buscarMascotasPorRaza(mascota.raza.idRaza);
                        if (listaMascotas != null)
                        {
                            if (mascota.edad != null)
                            {
                                listaMascotas = listaMascotas.Where(m => m.edad.idEdad == mascota.edad.idEdad).ToList();
                            }
                            if (mascota.color != null)
                            {
                                listaMascotas = listaMascotas.Where(m => m.color.idColor == mascota.color.idColor).ToList();
                            }
                            if (mascota.tratoAnimal != null)
                            {
                                listaMascotas = listaMascotas.Where(m => m.tratoAnimal == mascota.tratoAnimal).ToList();
                            }
                            if (mascota.tratoNiños != null)
                            {
                                listaMascotas = listaMascotas.Where(m => m.tratoNiños == mascota.tratoNiños).ToList();
                            }
                            if (mascota.caracter != null)
                            {
                                listaMascotas = listaMascotas.Where(m => m.caracter.idCaracter == mascota.caracter.idCaracter).ToList();
                            }
                            if (mascota.fechaNacimiento != null)
                            {
                                listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                            }
                            if (mascota.sexo != null)
                            {
                                listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                            }
                        }
                    }
                    else
                    {
                        if (mascota.edad != null)
                        {
                            listaMascotas = buscarMascotasPorEdad(mascota.edad.idEdad);
                            if (listaMascotas != null)
                            {
                                if (mascota.raza != null)
                                {
                                    listaMascotas = listaMascotas.Where(m => m.raza.idRaza == mascota.raza.idRaza).ToList();
                                }
                                if (mascota.color != null)
                                {
                                    listaMascotas = listaMascotas.Where(m => m.color.idColor == mascota.color.idColor).ToList();
                                }
                                if (mascota.tratoAnimal != null)
                                {
                                    listaMascotas = listaMascotas.Where(m => m.tratoAnimal == mascota.tratoAnimal).ToList();
                                }
                                if (mascota.tratoNiños != null)
                                {
                                    listaMascotas = listaMascotas.Where(m => m.tratoNiños == mascota.tratoNiños).ToList();
                                }
                                if (mascota.caracter != null)
                                {
                                    listaMascotas = listaMascotas.Where(m => m.caracter.idCaracter == mascota.caracter.idCaracter).ToList();
                                }
                                if (mascota.fechaNacimiento != null)
                                {
                                    listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                                }
                                if (mascota.sexo != null)
                                {
                                    listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                                }
                            }
                        }
                        else
                        {
                            if (mascota.especie != null)
                            {
                                listaMascotas = buscarMascotasPorEspecie(mascota.especie.idEspecie);
                                if (listaMascotas != null)
                                {
                                    if (mascota.color != null)
                                    {
                                        listaMascotas = listaMascotas.Where(m => m.color.idColor == mascota.color.idColor).ToList();
                                    }
                                    if (mascota.tratoAnimal != null)
                                    {
                                        listaMascotas = listaMascotas.Where(m => m.tratoAnimal == mascota.tratoAnimal).ToList();
                                    }
                                    if (mascota.tratoNiños != null)
                                    {
                                        listaMascotas = listaMascotas.Where(m => m.tratoNiños == mascota.tratoNiños).ToList();
                                    }
                                    if (mascota.caracter != null)
                                    {
                                        listaMascotas = listaMascotas.Where(m => m.caracter.idCaracter == mascota.caracter.idCaracter).ToList();
                                    }
                                    if (mascota.fechaNacimiento != null)
                                    {
                                        listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                                    }
                                    if (mascota.sexo != null)
                                    {
                                        listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                                    }
                                }
                            }
                            else
                            {
                                if (mascota.color != null)
                                {
                                    listaMascotas = buscarMascotasPorColor(mascota.color.idColor);
                                    if (listaMascotas != null)
                                    {
                                        if (mascota.tratoAnimal != null)
                                        {
                                            listaMascotas = listaMascotas.Where(m => m.tratoAnimal == mascota.tratoAnimal).ToList();
                                        }
                                        if (mascota.tratoNiños != null)
                                        {
                                            listaMascotas = listaMascotas.Where(m => m.tratoNiños == mascota.tratoNiños).ToList();
                                        }
                                        if (mascota.caracter != null)
                                        {
                                            listaMascotas = listaMascotas.Where(m => m.caracter.idCaracter == mascota.caracter.idCaracter).ToList();
                                        }
                                        if (mascota.fechaNacimiento != null)
                                        {
                                            listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                                        }
                                        if (mascota.sexo != null)
                                        {
                                            listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                                        }
                                    }
                                }
                                else
                                {
                                    if (mascota.tratoAnimal != null)
                                    {
                                        listaMascotas = buscarMascotasPorTratoAnimal((bool)mascota.tratoAnimal);
                                        if (listaMascotas != null)
                                        {
                                            if (mascota.tratoNiños != null)
                                            {
                                                listaMascotas = listaMascotas.Where(m => m.tratoNiños == mascota.tratoNiños).ToList();
                                            }
                                            if (mascota.caracter != null)
                                            {
                                                listaMascotas = listaMascotas.Where(m => m.caracter.idCaracter == mascota.caracter.idCaracter).ToList();
                                            }
                                            if (mascota.fechaNacimiento != null)
                                            {
                                                listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                                            }
                                            if (mascota.sexo != null)
                                            {
                                                listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (mascota.tratoNiños != null)
                                        {
                                            listaMascotas = buscarMascotasPorTratoNiños((bool)mascota.tratoNiños);
                                            if (listaMascotas != null)
                                            {
                                                if (mascota.caracter != null)
                                                {
                                                    listaMascotas = listaMascotas.Where(m => m.caracter.idCaracter == mascota.caracter.idCaracter).ToList();
                                                }
                                                if (mascota.fechaNacimiento != null)
                                                {
                                                    listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                                                }
                                                if (mascota.sexo != null)
                                                {
                                                    listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (mascota.caracter != null)
                                            {
                                                listaMascotas = buscarMascotasPorCaracter(mascota.caracter.idCaracter);
                                                if (listaMascotas != null)
                                                {
                                                    if (mascota.fechaNacimiento != null)
                                                    {
                                                        listaMascotas = listaMascotas.Where(m => m.fechaNacimiento == mascota.fechaNacimiento).ToList();
                                                    }
                                                    if (mascota.sexo != null)
                                                    {
                                                        listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (mascota.fechaNacimiento != null)
                                                {
                                                    listaMascotas = buscarMascotasPorFecha(mascota.fechaNacimiento.Value);
                                                    if (listaMascotas != null)
                                                    {
                                                        if (mascota.sexo != null)
                                                        {
                                                            listaMascotas = listaMascotas.Where(m => m.sexo == mascota.sexo).ToList();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (mascota.sexo != null)
                                                    {
                                                        listaMascotas = buscarMascotasPorSexo(mascota.sexo);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return listaMascotas;
        }

        //Metodo que devuelve una lista de mascotas de las cuales su nombre EMPIEZA con el parametro nombre
        public static List<EMascota> buscarMascotasPorNombre(string nombre)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.nombreMascota.StartsWith(nombre));
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            return null;
        }
        
        //Metodo que devuelve una lista de mascotas a partir de una lista de id de mascotas
        public static List<EMascota> BuscarMascotasPorIdMascota(List<int> listaIdMascota)
        {
            List<EMascota> listaMascotas = new List<EMascota>();
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               join EstadosBD in mapaEntidades.Estados on MascotasBD.idEstado equals EstadosBD.idEstado
                                join ColoresBD in mapaEntidades.Colores on MascotasBD.idColor equals ColoresBD.idColor
                                join edadesBD in mapaEntidades.Edades on MascotasBD.idEdad equals edadesBD.idEdad
                                join especiesBD in mapaEntidades.Especies on MascotasBD.idEspecie equals especiesBD.idEspecie
                                join RazaBD in mapaEntidades.Razas on MascotasBD.idRaza equals RazaBD.idRaza
                                join CategoriaRazaBD in mapaEntidades.CategoriaRazas on RazaBD.idCategoriaRaza equals CategoriaRazaBD.idCategoriaRazas
                                join CaracterBD in mapaEntidades.CaracteresMascota on MascotasBD.idCaracter equals CaracterBD.idCaracter into group3
                                from G3 in group3.DefaultIfEmpty()
                                where (listaIdMascota.Contains(MascotasBD.idMascota))
                                select new
                                {
                                    nombre = MascotasBD.nombreMascota,
                                    idEstado = MascotasBD.idEstado,
                                    estado = EstadosBD.nombreEstado,
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
                                    idCategoria = CategoriaRazaBD.idCategoriaRazas,
                                    idCaracter = (G3 == null) ? 0 : G3.idCaracter,
                                    caracter = (G3 == null) ? null : G3.descripcion,
                                    id = MascotasBD.idMascota,
                                    imagen = MascotasBD.imagen,
                                    fecha =  MascotasBD.fechaNacimiento,
                                    noMostrar = MascotasBD.noMostrar,//modificado
                                };
                    foreach (var registro in consulta)
                    {
                        EMascota mascota = new EMascota();
                        mascota.caracter = new ECaracterMascota();
                        mascota.estado = new EEstado();
                        mascota.estado.nombreEstado = registro.estado;
                        mascota.estado.idEstado = registro.idEstado;
                        mascota.caracter.idCaracter = registro.idCaracter;
                        mascota.caracter.descripcion = registro.caracter;
                        mascota.raza = new ERaza();
                        mascota.raza.CategoriaRaza = new ECategoriaRaza();
                        mascota.raza.CategoriaRaza.idCategoriaRaza = registro.idCategoria;
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
                        mascota.fechaNacimiento = registro.fecha;
                        //mascota.fechaNacimiento = (registro.fecha == null) ? DateTime.Parse("24/12/2010") : DateTime.Parse(registro.fecha.ToString());
                        mascota.noMostrar = (bool)registro.noMostrar;//modificado
                        if (registro.imagen != null)
                        {
                            mascota.imagen = registro.imagen;
                        }
                        else
                        {
                            mascota.imagen = null;
                        }
                        listaMascotas.Add(mascota);
                    }                
                return listaMascotas;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
        //Metodo que busca las mascotas con un cierto estado. Estado es un string. Ej: "Perdida"
        public static List<EMascota> buscarMascotasPorEstado(string estado)
        {
            List<EMascota> listaMascotas = null;
            List<int> listaIdMascotas = null;
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from mascotasBD in mapaEntidades.Mascotas
                           join estadosBD in mapaEntidades.Estados on mascotasBD.idEstado equals estadosBD.idEstado
                           where (estadosBD.nombreEstado == estado)
                           select mascotasBD.idMascota;
            if (consulta.Count() != 0)
            {
                listaIdMascotas = new List<int>();
                foreach (var item in consulta)
                {
                    listaIdMascotas.Add(item);
                }
                listaMascotas = BuscarMascotasPorIdMascota(listaIdMascotas);
                return listaMascotas;
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas de una especie determinada
        public static List<EMascota> buscarMascotasPorEspecie(int especie)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.idEspecie == especie);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas con un trato animal determinado
        public static List<EMascota> buscarMascotasPorTratoAnimal(bool tratoAnimal)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.tratoAnimales == tratoAnimal);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas con un trato niños determinado
        public static List<EMascota> buscarMascotasPorTratoNiños(bool tratoNiños)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.tratoNinios == tratoNiños);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas de una edad determinada
        public static List<EMascota> buscarMascotasPorEdad(int edad)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.idEdad == edad);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas de una raza determinada
        public static List<EMascota> buscarMascotasPorRaza(int raza)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.idRaza == raza);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas de un color determinado
        public static List<EMascota> buscarMascotasPorColor(int color)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.idColor == color);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas de un color determinado
        public static List<EMascota> buscarMascotasPorCaracter(int caracter)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.idCaracter == caracter);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas de una fecha determinada
        public static List<EMascota> buscarMascotasPorFecha(DateTime fecha)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.fechaNacimiento == fecha);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }

        //Metodo que busca las mascotas de un sexo determinado
        public static List<EMascota> buscarMascotasPorSexo(string sexo)
        {
            List<int> listaIdMascotas = new List<int>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Mascotas.Where(m => m.sexo == sexo);
            foreach (var item in consulta)
            {
                listaIdMascotas.Add(item.idMascota);
            }
            if (listaIdMascotas.Count != 0)
            {
                return BuscarMascotasPorIdMascota(listaIdMascotas);
            }
            else
            {
                return null;
            }
        }
           
        public static int obtenerProximoIdMascota()
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var qonda = mapa.ExecuteStoreQuery<Decimal>("SELECT IDENT_CURRENT('Mascotas') + IDENT_INCR('Mascotas')");
            string asd = qonda.FirstOrDefault().ToString();
            return int.Parse(asd);
        }


        public static void modificarEstado(string estado, int idMascotaParam, ref SiGMAEntities mapa)
        {
            try
            {
                Mascotas bdMascota = mapa.Mascotas.Where(m => m.idMascota == idMascotaParam).First();
                bdMascota.idEstado = mapa.Estados.Where(es => es.ambito == "Mascota" && es.nombreEstado == estado).First().idEstado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ponerEnAdopcion(int idMascota) 
        {
            bool b = false;
            try
            {
                 SiGMAEntities mapa = Conexion.crearSegunServidor();
                 modificarEstado("En adopcion", idMascota, ref mapa);
                 mapa.SaveChanges();
                 b = true;
            }
            catch (Exception)
            {
                throw;
            }
            return b;
        }

        public static void asignarDueño(EMascota mascot, int idDueño, ref SiGMAEntities mapa)
        {
            try
            {
                Mascotas bdMascot = mapa.Mascotas.Where(m => m.idMascota == mascot.idMascota).First();
                bdMascot.idDuenio = idDueño;
            }
            catch (Exception)
            {

            }
        }

        public static List<EMascota> buscarMascotasPerdidas(string nombre){
            List<EMascota> listaMascotas = null;
            List<int> listaIdMascotas = null;
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            var consulta = from mascotasBD in mapaEntidades.Mascotas
                           join estadosBD in mapaEntidades.Estados on mascotasBD.idEstado equals estadosBD.idEstado
                           where (estadosBD.nombreEstado == "Perdida" && mascotasBD.nombreMascota.StartsWith(nombre))
                           select mascotasBD.idMascota;
            if (consulta.Count() != 0)
            {
                listaIdMascotas = new List<int>();
                foreach (var item in consulta)
                {
                    listaIdMascotas.Add(item);
                }
                listaMascotas = BuscarMascotasPorIdMascota(listaIdMascotas);
                return listaMascotas;
            }
            else
            {
                return null;
            }
        }

    }
}