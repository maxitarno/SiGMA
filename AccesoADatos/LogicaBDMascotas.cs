using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
namespace AccesoADatos
{
    public class LogicaBDMascotas
    {
        public static bool BuscarMascotaPorDuenio(EPersona persona, EMascota mascota, ECategoriaRaza categoria, ECaracterMascota caracter, ECuidado cuidado, int idMascota)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               from DueniosBD in mapaEntidades.Duenios
                               from PersonasBD in mapaEntidades.Personas
                               from RazaBD in mapaEntidades.Razas
                               from CategoriaRazaBD in mapaEntidades.CategoriaRazas
                               from CaracterBD in mapaEntidades.CaracteresMascota
                               from CuidadoEspecialBD in mapaEntidades.CuidadosEspeciales
                               where (DueniosBD.idPersona == PersonasBD.idPersona && DueniosBD.idDuenio == MascotasBD.idDuenio && MascotasBD.idRaza == RazaBD.idRaza && CuidadoEspecialBD.idCuidadoEspecial == RazaBD.idCuidadoEspecial && RazaBD.idCategoriaRaza == CategoriaRazaBD.idCategoriaRazas && MascotasBD.idCaracter == CaracterBD.idCaracter && MascotasBD.idMascota == idMascota)
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
                                   observaiones = MascotasBD.observaciones,
                                   alimentacion = MascotasBD.alimentacionEspecial,
                                   fecha = MascotasBD.fechaNacimiento,
                                   sexo = MascotasBD.sexo,
                                   Duenio = PersonasBD.nombre,
                                   categoria = CategoriaRazaBD.nombreCategoriaRaza,
                                   caracter = CaracterBD.descripcion,
                                   Cuidado = CuidadoEspecialBD.descripcion,
                                   id = MascotasBD.idMascota
                               };
                foreach (var registro in consulta)
                {
                    mascota.alimetaionEspeial = registro.alimentacion;
                    caracter.descripcion = registro.caracter;
                    categoria.nombreCategoriaRaza = registro.categoria;
                    persona.nombre = registro.Duenio;
                    mascota.idRaza = registro.raza;
                    mascota.fechaNcimiento = (DateTime)registro.fecha;
                    mascota.idColor = registro.color;
                    mascota.nombreMascota = registro.nombre;
                    mascota.observaciones = registro.observaiones;
                    mascota.sexo = registro.sexo;
                    mascota.tratoAnimal = registro.tratoA;
                    mascota.tratoNiños = registro.tratoN;
                    cuidado.descripcion = registro.Cuidado;
                    mascota.idMascota = registro.id;
                    mascota.idEdad = registro.edad;
                    mascota.idEspecie = registro.especie;
                    mascota.idEstado = registro.estado;
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
                                                where(DueniosBD.idPersona == PersonasBD.idPersona && MascotasBD.idDuenio == DueniosBD.idDuenio && PersonasBD.nombre.Contains(duenio))
                                                select MascotasBD;
            try{
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
        public static bool ModificarMascota(EMascota mascota){
            bool b = false;
            try{
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                var consulta = mapaEntidades.Mascotas.Where( mascotasBuscadas => mascotasBuscadas.idMascota == mascota.idMascota);
                foreach(var registro in consulta){
                    registro.alimentacionEspecial = registro.alimentacionEspecial.Replace(registro.alimentacionEspecial, mascota.alimetaionEspeial);
                    registro.idCaracter = mascota.idcaracter;
                    registro.idEdad = mascota.idEdad;
                    registro.idEspecie = mascota.idEspecie;
                    registro.idEstado = mascota.idEstado;
                    registro.idRaza = mascota.idMascota;
                    registro.nombreMascota = registro.nombreMascota.Replace(registro.nombreMascota, mascota.nombreMascota);
                    registro.observaciones = registro.observaciones.Replace(registro.observaciones, mascota.observaciones);
                    registro.idColor = mascota.idColor;
                    registro.sexo = registro.sexo.Replace(registro.sexo, mascota.sexo);
                    registro.tratoAnimales = registro.tratoAnimales.Replace(registro.tratoAnimales, mascota.sexo);
                    registro.tratoNinios = registro.tratoNinios.Replace(registro.tratoNinios, mascota.tratoNiños);
                }
                b = true;
                mapaEntidades.SaveChanges();
            }
            catch(InvalidOperationException exc){
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
                                            from DueniosBD in mapaEntidades.Duenios
                                            from PersonasBD in mapaEntidades.Personas
                                            where (DueniosBD.idPersona == PersonasBD.idPersona && MascotasBD.idDuenio == DueniosBD.idDuenio && MascotasBD.nombreMascota.Contains(nombre))
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
    }
}
