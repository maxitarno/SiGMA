using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Entidades;
using System.Drawing;


namespace Herramientas
{
    public class GenerarQR
    {
        public static Bitmap generarQR(EMascota mascota, List<string> campos)
        {
            QRCodeEncoder codificador = new QRCodeEncoder();            
            string datosQR = null; ;
            foreach (string cadena in campos)
            {
                switch (cadena)
                {
                    case "NombreMascota":
                        datosQR += " Nombre: " + mascota.nombreMascota;
                        break;
                    case "Raza":                    
                        datosQR += " Raza: " + mascota.raza.nombreRaza;
                        break;
                    case "Sexo":
                        datosQR += " Sexo: " + mascota.sexo;
                        break;
                    case "Color":
                        datosQR += " Color: " + mascota.color.nombreColor;
                        break;
                    case "Niños":
                        if (mascota.tratoNiños == true)
                        {
                            datosQR += " Trato con niños: Si";
                        }
                        else
                        {
                            datosQR += " Trato con niños: No";
                        }
                        break;
                    case "Animales":
                        if (mascota.tratoAnimal == true)
                        {
                            datosQR += " Trato con animales: Si";
                        }
                        else
                        {
                            datosQR += " Trato con animales: No";
                        }
                        break;
                    case "NombreDueño":
                        datosQR += " Nombre del dueño: " + mascota.duenio.nombre + " " + mascota.duenio.apellido;
                        break;
                    case "Direccion":
                        datosQR += " Direccion: " + mascota.duenio.domicilio.nombre.ToLower() + " " + 
                            mascota.duenio.nroCalle + " B° " + mascota.duenio.barrio.nombre.ToLower();
                        break;
                    case "Email":
                        datosQR += " Email: " + mascota.duenio.email;
                        break;
                    case "TelefonoCel":
                        datosQR += " Celular: " + mascota.duenio.telefonoCelular;
                        break;
                }                
            }
            Bitmap retorno = codificador.Encode(datosQR);
            return retorno;
        }
    }
}
