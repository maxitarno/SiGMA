﻿using System;
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
                    LogicaBDMascota.modificarEstado("Adoptada", adopcion.mascota.idMascota,ref mapaEntidades);                   
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
    }
}
