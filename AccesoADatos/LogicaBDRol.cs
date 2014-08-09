using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDRol
    {
        public static bool guardarPermisoRol(List<EPermisoRol> ListadoPermisos)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b = true;
                try
                {
                    SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
                    foreach (var item in ListadoPermisos)
                    {
                        PermisosXRoles perRolesBD = new PermisosXRoles();
                        perRolesBD.idPermiso = item.idPermiso;
                        perRolesBD.idRol = item.idRol;
                        perRolesBD.pantalla = item.pantalla;
                        mapaEntidades.AddToPermisosXRoles(perRolesBD);
                        mapaEntidades.SaveChanges();
                    }
                    transaction.Complete();
                    b = true;
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    b = false;
                    throw exc;
                }
                return b;
            }
        }

        public static bool guardarRol(ERol rol)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b = true;
                try
                {
                    SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
                    Roles rolBD = new Roles();
                    rolBD.nombre = rol.nombreRol;
                    rolBD.descripcion = rol.descripcionRol;
                    mapaEntidades.AddToRoles(rolBD);
                    mapaEntidades.SaveChanges();
                    transaction.Complete();
                    b = true;
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    b = false;
                    throw exc;
                }
                return b;
            }
        }
    }
}

