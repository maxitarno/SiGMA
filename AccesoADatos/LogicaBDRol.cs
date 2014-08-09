using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    class LogicaBDRol
    {
        public static bool guardarRol(ERol rol, EPermiso permiso, string pantalla)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b;
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Roles rolBD = new Roles();
                    rolBD.nombre = rol.nombreRol;
                    rolBD.descripcion = rol.descripcionRol;
                    mapaEntidades.AddToRoles(rolBD);
                    mapaEntidades.SaveChanges();
                    Permisos permisoBD = new Permisos();
                    permisoBD.idPermiso = permiso.idPermiso;
                    permisoBD.tipoPermiso = permiso.tipoPermiso;
                    mapaEntidades.AddToPermisos(permisoBD);
                    mapaEntidades.SaveChanges();
                    PermisosRoles perRolesBD = new PermisosRoles();
                    perRolesBD.idPermiso = permiso.idPermiso;
                    perRolesBD.idRol = rol.idRol;
                    perRolesBD.pantalla = pantalla;                    
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
