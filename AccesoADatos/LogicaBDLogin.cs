using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace AccesoADatos
{
    public class LogicaBDLogin
    {
        public static bool esUsuario(EUsuario logging)
        {
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();            
            if (mapaEntidades.Usuarios.Any(u => u.user == logging.user && u.password == logging.password))
            {

                return true;
            }
            else
            {
                return false;
            }
            //var query = from usuario in mapaEntidades.Usuarios
            //            where (usuario.user == logging.user && usuario.password == logging.password)
            //            select usuario.
            //pav2Entities dat = new pav2Entities();
            //var query = from c in dat.cliente
            //            where c.idCliente == idCli
            //            select c.idPersona;
            //return (int)query.First();
        }
        public static string obtenerRol(EUsuario logged)
        {
            SIGMAEntitiesContainer mapaEntidades = Conexion.crearSegunServidor();
            var query = from usuario in mapaEntidades.Usuarios
                        from rol in mapaEntidades.Roles
                        where (usuario.user == logged.user && usuario.password == logged.password &&
                        usuario.idRol == rol.idRol)
                        select rol.nombre;
            return  query.First();            
        }
    }
}
