using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Entidades;

namespace AccesoADatos
{
    public class LogicaBDUsuario
    {
        public static bool guardarUsuario(EDuenio duenio, EUsuario usuario)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b;
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    Usuarios userBD = new Usuarios();
                    userBD.user = usuario.user;
                    userBD.password = usuario.password;
                    userBD.idRol = 1;
                    mapaEntidades.AddToUsuarios(userBD);
                    mapaEntidades.SaveChanges();
                    Personas personBD = new Personas();                    
                    personBD.nombre = duenio.nombre;
                    personBD.apellido = duenio.apellido;
                    personBD.idTipoDocumento = duenio.idTipoDocumento;
                    personBD.nroDocumento = duenio.nroDocumento;
                    personBD.email = duenio.email;
                    personBD.user = duenio.usuario.user;
                    mapaEntidades.AddToPersonas(personBD);
                    mapaEntidades.SaveChanges();
                    Duenios duenioBD = new Duenios();
                    duenioBD.idPersona = personBD.idPersona;
                    mapaEntidades.AddToDuenios(duenioBD);
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
        //Mi metodo para buscr los tipos dedocumentos
        public static List<ETipoDeDocumento> TiposDNI(){
            List<ETipoDeDocumento> tiposDNI = new List<ETipoDeDocumento>();
            SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
            IQueryable<TipoDocumentos> tiposDeDocumentos = from tipoDocumentos in mapaEntidades.TipoDocumentos
                                                             select tipoDocumentos;
            foreach(var tipoDocumento in tiposDeDocumentos){
                ETipoDeDocumento tipo = new ETipoDeDocumento();
                tipo.tipoDNI = tipoDocumento.nombre;
                tipo.idTipoDeDocumento = tipoDocumento.idTipoDocumento;
                tiposDNI.Add(tipo);
            }
            return tiposDNI;
        }
    }
}
