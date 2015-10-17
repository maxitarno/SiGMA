using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Entidades;

namespace AccesoADatos
{
    public class LogicaBDImagen
    {
        public static void guardarImagen(byte[] imagen, EMascota mascota)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    IQueryable<Mascotas> consulta = from MascotasBD in mapaEntidades.Mascotas
                                                    where (MascotasBD.idMascota == mascota.idMascota)
                                                    select MascotasBD;
                    if (consulta.Count() != 0)
                    {
                        Mascotas bdMascota = consulta.First();
                        if(imagen != null)
                            bdMascota.imagen = imagen;
                        mapaEntidades.SaveChanges();
                        transaction.Complete();
                    }
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
            }
        }       
    }
}
