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
        //metodo para ABMC de Permisos segun el Rol seleccionado .
        public static bool guardarPermisoRol(ERol Rol)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b = true;
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    var idRol = Rol.idRol;
                    var list = mapaEntidades.PermisosXRoles.Where(m => m.idRol == idRol);
                    foreach (PermisosXRoles per in list)
                        mapaEntidades.PermisosXRoles.DeleteObject(per);
                    mapaEntidades.SaveChanges();
                    foreach (var item in Rol.listaPermisos)
                    {
                        PermisosXRoles perRolesBD = new PermisosXRoles();
                        perRolesBD.idPermiso = item.idPermiso;
                        perRolesBD.idRol = idRol;
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
        //Metodo para buscar roles
        public static List<ERol> Roles()
        {
            List<ERol> roles = new List<ERol>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
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
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
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
        //metodo para eliminar rol por usuario
        public static bool eliminarRolAsignadoUsuario(int rol, string usuario) 
        {
            bool b = true;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                RolesXUsuario rolBD = new RolesXUsuario();
                if (rol != 0)
                {
                    rolBD = (from r in mapaEntidades.RolesXUsuario
                             where (r.idRol == rol && r.user == usuario)
                             select r).First();
                    mapaEntidades.DeleteObject(rolBD);
                    mapaEntidades.SaveChanges(System.Data.Objects.SaveOptions.DetectChangesBeforeSave);
                    b = true;
                }
            }
            catch (Exception exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }    
        //fin metodo
        //metodo para guardar rol por usuario
        public static bool guardarRolAsignadoUsuario(int rol, string usuario) 
        {
            bool b = true;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                RolesXUsuario rolBD = new RolesXUsuario();
                rolBD.idRol = rol;
                rolBD.user = usuario;
                mapaEntidades.AddToRolesXUsuario(rolBD);
                mapaEntidades.SaveChanges();
                b = true;
            }
            catch (Exception exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }
        //fin metodo
        //metodo para cargar permisos segun rol seleccionado
        public static List<EPermiso> cargarPermisosRol(int idRol)
        {
            List<EPermiso> perRol = new List<EPermiso>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<PermisosXRoles> ListaPermisos = from permisos in mapaEntidades.PermisosXRoles
                                                       where (permisos.idRol == idRol)
                                                       select permisos;
            try
            {                
                foreach (var permisos in ListaPermisos)
                {
                    EPermiso per = new EPermiso();
                    per.idPermiso = permisos.idPermiso;
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
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
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
        //Obtener rol por nombre
        public static ERol ObtenerRol(string nombre)
        {
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Roles> roles = from permisos in mapaEntidades.Roles
                                      where (permisos.nombre == nombre)
                                      select permisos;            
            if (roles.Count() != 0)
            {
                ERol retorno = new ERol();                
                retorno.idRol = roles.First().idRol;
                retorno.nombreRol = roles.First().nombre;
                return retorno;
            }
            else return null;
        }
        //Roles segun usuario
        public static List<ERol> cargarRolesSergunUsuario(string usuarioNombre)
        {
         List<ERol> roles = new List<ERol>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Roles> consulta = from rolesDB in mapaEntidades.Roles
                                         from rolesUsuariosBD in mapaEntidades.RolesXUsuario
                                         from usuarioBD in mapaEntidades.Usuarios
                                         where (usuarioBD.user == usuarioNombre && rolesUsuariosBD.idRol == rolesDB.idRol && rolesUsuariosBD.user == usuarioBD.user)
                                         select rolesDB;
            try
            {
                foreach (var registro in consulta)
                {
                    ERol rol = new ERol();
                    rol.idRol = registro.idRol;
                    rol.nombreRol = registro.nombre;
                    rol.descripcionRol = registro.descripcion;
                    rol.listaPermisos = cargarPermisosRol(registro.idRol);
                    roles.Add(rol);
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            return roles;
        }

        //para control de ingreso y eleccion de Default
        public static Int32 verRolesSegunUsuario(string usuarioNombre)
        {
         int admin = 0;
         int dueño = 0;
         List<ERol> roles = new List<ERol>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Roles> consulta = from rolesDB in mapaEntidades.Roles
                                         from rolesUsuariosBD in mapaEntidades.RolesXUsuario
                                         from usuarioBD in mapaEntidades.Usuarios
                                         where (usuarioBD.user == usuarioNombre && rolesUsuariosBD.idRol == rolesDB.idRol && rolesUsuariosBD.user == usuarioBD.user)
                                         select rolesDB;
            try
            {
                foreach (var registro in consulta)
                {
                    if (registro.idRol == 1)
                        admin++;
                    if (registro.idRol == 2)
                        dueño++;
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            if (admin != 0 && dueño != 0)
                return 3;
            if (admin != 0)
                return 1;
            if (dueño != 0)
                return 2;
            else return 0;
        }

        //Eliminar rol por IdRol
        public static bool eliminarRol(ERol rol)
        {
            bool b = true;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                Roles rolBD = new Roles();
                if (rol.idRol != 0)
                {
                    rolBD = (from r in mapaEntidades.Roles
                                where (r.idRol == rol.idRol)
                                select r).First();
                    mapaEntidades.DeleteObject(rolBD);
                    mapaEntidades.SaveChanges(System.Data.Objects.SaveOptions.DetectChangesBeforeSave);
                        b = true;
                }
            }
            catch (Exception exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }

        public static Boolean verificarPermisoVisualizacion(String nombreUsuario, String pantalla)
        {
            EUsuario usuarioLogueado = new EUsuario();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> consulta = from UsuarioBD in mapaEntidades.Usuarios
                                            where (UsuarioBD.user == nombreUsuario)
                                            select UsuarioBD;
            try
            {
                foreach (var registro in consulta)
                {
                    usuarioLogueado.user = registro.user;
                    usuarioLogueado.password = registro.password;
                    usuarioLogueado.rolesUsuario = LogicaBDRol.cargarRolesSergunUsuario(registro.user);

                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            Boolean ingreso = false;
            if (usuarioLogueado != null)
            {
                List<ERol> roles = usuarioLogueado.rolesUsuario;
                foreach (var rol in roles)
                {
                    List<EPermiso> permisos = rol.listaPermisos;
                    foreach (var permiso in permisos)
                    {
                        if (permiso.pantalla == pantalla && permiso.idPermiso == 1)
                        {
                            ingreso = true;
                            break;
                        }
                    }
                }
                return ingreso;
            }
            else { return false; }
        }

        public static bool verificarPermisosGrabacion(string nombreUsuario, string pantalla)
        {
            EUsuario usuarioLogueado = new EUsuario();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> consulta = from UsuarioBD in mapaEntidades.Usuarios
                                            where (UsuarioBD.user == nombreUsuario)
                                            select UsuarioBD;
            try
            {
                foreach (var registro in consulta)
                {
                    usuarioLogueado.user = registro.user;
                    usuarioLogueado.password = registro.password;
                    usuarioLogueado.rolesUsuario = LogicaBDRol.cargarRolesSergunUsuario(registro.user);
                    
                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            Boolean ingreso = false;
            if (usuarioLogueado != null)
            {
                List<ERol> roles = usuarioLogueado.rolesUsuario;
                foreach (var rol in roles)
                {
                    List<EPermiso> permisos = rol.listaPermisos;
                    foreach (var permiso in permisos)
                    {
                        if (permiso.pantalla == pantalla && permiso.idPermiso == 2)
                        {
                            ingreso = true;
                            break;
                        }
                    }
                }
                return ingreso;
            }
            else { return false; } 
        }

        public static bool verificarPermisosEliminacion(string nombreUsuario, string pantalla)
        {
            EUsuario usuarioLogueado = new EUsuario();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> consulta = from UsuarioBD in mapaEntidades.Usuarios
                                            where (UsuarioBD.user == nombreUsuario)
                                            select UsuarioBD;
            try
            {
                foreach (var registro in consulta)
                {
                    usuarioLogueado.user = registro.user;
                    usuarioLogueado.password = registro.password;
                    usuarioLogueado.rolesUsuario = LogicaBDRol.cargarRolesSergunUsuario(registro.user);

                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            Boolean ingreso = false;
            if (usuarioLogueado != null)
            {
                List<ERol> roles = usuarioLogueado.rolesUsuario;
                foreach (var rol in roles)
                {
                    List<EPermiso> permisos = rol.listaPermisos;
                    foreach (var permiso in permisos)
                    {
                        if (permiso.pantalla == pantalla && permiso.idPermiso == 3)
                        {
                            ingreso = true;
                            break;
                        }
                    }
                }
                return ingreso;
            }
            else { return false; } 
        }

        public static bool verificarSoloDueño(string nombreUsuario) 
        {
            EUsuario usuarioLogueado = new EUsuario();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<Usuarios> consulta = from UsuarioBD in mapaEntidades.Usuarios
                                            where (UsuarioBD.user == nombreUsuario)
                                            select UsuarioBD;
            try
            {
                foreach (var registro in consulta)
                {
                    usuarioLogueado.user = registro.user;
                    usuarioLogueado.password = registro.password;
                    usuarioLogueado.rolesUsuario = LogicaBDRol.cargarRolesSergunUsuario(registro.user);

                }
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                throw exc;
            }
            Boolean ingreso = true;
            if (usuarioLogueado != null)
            {
                List<ERol> roles = usuarioLogueado.rolesUsuario;
                foreach (var rol in roles)
                {
                    if (rol.nombreRol != "Dueño")
                        ingreso = false;
                }
                return ingreso;
            }
            else { return false; }
        }
    }
}


