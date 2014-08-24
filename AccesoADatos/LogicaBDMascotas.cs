using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
namespace AccesoADatos
{
    public class LogicaBDMascotas
    {
        public static bool BuscarMascotaPorDuenio(EPersona persona, EMascota mascota, ECategoriaRaza categoria, ECaracterMascota caracter, ECuidado cuidado)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                List<EMascota> mascotas = new List<EMascota>();
                var consulta = from MascotasBD in mapaEntidades.Mascotas
                               from DueniosBD in mapaEntidades.Duenios
                               from PersonasBD in mapaEntidades.Personas
                               from RazaBD in mapaEntidades.Razas
                               from CategoriaRazaBD in mapaEntidades.CategoriaRazas
                               from CaracterBD in mapaEntidades.CaracteresMascota
                               from CuidadoEspecialBD in mapaEntidades.CuidadosEspeciales
                               where (CuidadoEspecialBD.idCuidadoEspecial == RazaBD.idCuidadoEspecial && DueniosBD.idPersona == PersonasBD.idPersona && DueniosBD.idDuenio == MascotasBD.idMascota && MascotasBD.idRaza == RazaBD.idRaza && RazaBD.idCategoriaRaza == CategoriaRazaBD.idCategoriaRazas && MascotasBD.idCaracter == CaracterBD.idCaracter && MascotasBD.nombreMascota.Contains(mascota.nombreMascota))
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
                                   Cuidado = CuidadoEspecialBD.descripcion
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
                    b = true;
                }
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
    }
}
