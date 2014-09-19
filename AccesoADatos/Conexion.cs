using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AccesoADatos
{
    public class Conexion
    {
        public static SiGMAEntities crearSegunServidor()
        {
            string nombrePC = System.Environment.MachineName;
            string cadenaConexion="";
            if(nombrePC.Equals("GON-PC"))
            {
                cadenaConexion = "metadata=res://*/DER.csdl|res://*/DER.ssdl|res://*/DER.msl;provider=System.Data.SqlClient;provider connection string=\"data source=GON-PC;initial catalog=SiGMA;integrated security=True;multipleactiveresultsets=True;App=EntityFramework\"";
            }        
            else if(nombrePC.Equals("ULTRA-MAX"))
            {
                cadenaConexion="metadata=res://*/DER.csdl|res://*/DER.ssdl|res://*/DER.msl;provider=System.Data.SqlClient;provider connection string=\"Data Source=(local);Initial Catalog=SiGMA;Integrated Security=True\"";
            }
            else if(nombrePC.Equals("EUROCASE"))
            {
                cadenaConexion = "metadata=res://*/DER.csdl|res://*/DER.ssdl|res://*/DER.msl;provider=System.Data.SqlClient;provider connection string= \"Data Source=EUROCASE\\SQLEXPRESS;Initial catalog=SIGMA;Integrated Security=True;MultipleActiveResultSets=True\"";
            }
            else if (nombrePC.Equals("FERRERO"))
            {
                cadenaConexion = "metadata=res://*/DER.csdl|res://*/DER.ssdl|res://*/DER.msl;provider=System.Data.SqlClient;provider connection string=\"Data Source=(local);Initial Catalog=SiGMA;Integrated Security=True\"";
            }
             return new SiGMAEntities(cadenaConexion);
        }
    }
}
