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
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();            
            if (mapaEntidades.Usuarios.Any(u => u.user == logging.user && u.password == logging.password))
            {

                return true;
            }
            else
            {
                return false;
            }            
        }        
    }
}
