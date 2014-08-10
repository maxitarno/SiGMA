﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDRol
    {
        //metodo para ABMC de Permisos segun el Rol seleccionado
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
        //fin metodo
        //Metodo para busar roles
        public static List<ERol> Roles()
        {
            List<ERol> roles = new List<ERol>();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Roles> consulta = from rolesDB in mapaEntidades.Roles
                                         select rolesDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ERol rol = new ERol();
                    rol.idRol = registro.idRol;
                    rol.nombreRol = registro.nombre;
                    rol.descripcionRol = registro.descripcion;
                    roles.Add(rol);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return roles;
        }
        //fin metodo
        //metodo para guardar roles
        public static bool guardarRol(ERol rol)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b = true;
                try
                {
                    SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
                    Roles rolBD = new Roles();
                    if (rol.idRol != 0)
                    {
                        rolBD = (from r in mapaEntidades.Roles
                                  where (r.idRol == rol.idRol)
                                   select r).First();
                    }
                    rolBD.nombre = rol.nombreRol;
                    rolBD.descripcion = rol.descripcionRol;
                    if (rol.idRol == 0)
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
        //fin metodo
        //metodo para cargar permisos segun rol seleccionado
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

        public static ERol cargarRol(int idRol) 
        {
            ERol rol = new ERol();
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Roles> roles = from permisos in mapaEntidades.Roles
                                           where (permisos.idRol == idRol)
                                                       select permisos;
            foreach (var item in roles)
            {
                rol.idRol = item.idRol;
                rol.nombreRol = item.nombre;
                rol.descripcionRol = item.descripcion;
            }
            return rol;
        }
    }
}

