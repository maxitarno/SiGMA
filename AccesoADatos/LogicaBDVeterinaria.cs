using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;
namespace AccesoADatos
{
    public class LogicaBDVeterinaria
    {
        public static Boolean RegistrarVeterinaria(EVeterinaria veterinaria)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    Veterinarias veterinariaBD = new Veterinarias();
                    veterinariaBD.nombre = veterinaria.nombre;
                    veterinariaBD.peluqueria = veterinaria.peluqueria;
                    veterinariaBD.petShop = veterinaria.petshop;
                    veterinariaBD.medicina = veterinaria.medicina;
                    veterinariaBD.castraciones = veterinaria.castraciones;
                    veterinariaBD.web = veterinaria.contacto;
                    veterinariaBD.idBarrio = veterinaria.domicilio.barrio.idBarrio;
                    veterinariaBD.idCalle = veterinaria.domicilio.calle.idCalle;
                    veterinariaBD.nroCalle = veterinaria.domicilio.numeroCalle;
                    veterinariaBD.telefono = veterinaria.telefono;
                    mapa.AddToVeterinarias(veterinariaBD);
                    mapa.SaveChanges();
                    transaccion.Complete();
                    return true;
                }
                catch (Exception)
                {
                    transaccion.Dispose();
                    return false;
                }
            }
        }
    }
}
