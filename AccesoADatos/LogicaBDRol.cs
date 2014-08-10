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
                    var rol = ListadoPermisos[1].idRol;
                    var list = mapaEntidades.PermisosXRoles.Where(m => m.idRol == rol);
                    foreach (PermisosXRoles per in list)
                        mapaEntidades.PermisosXRoles.DeleteObject(per);
                        mapaEntidades.SaveChanges(); 
                    foreach (var item in ListadoPermisos)
                    {
                        PermisosXRoles perRolesBD = new PermisosXRoles();
                        perRolesBD.idPermiso = item.idPermiso;
                        perRolesBD.idRol = item.idRol;
                        perRolesBD.pantalla = item.pantalla;
                        mapaEntidades.AddToPermisosXRoles(perRolesBD);
                    }
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

        public static List<EPermisoRol> cargarPermisosRol(int idRol)
        {
            List<EPermisoRol> perRol = new List<EPermisoRol>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<PermisosXRoles> ListaPermisos = from permisos in mapaEntidades.PermisosXRoles
                                                       where (permisos.idRol == idRol)
                                                       select permisos;
            try
            {
                foreach (var permisos in ListaPermisos)
                {
                    EPermisoRol per = new EPermisoRol();
                    per.idPermiso = permisos.idPermiso;
                    per.idRol = permisos.idRol;
                    per.pantalla = permisos.pantalla;
                    perRol.Add(per);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return perRol;
        }
    }
}

