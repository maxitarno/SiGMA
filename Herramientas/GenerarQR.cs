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
                        datosQR += " Trato con niños: " + mascota.tratoNiños;
                        break;
                    case "Animales":
                        datosQR += " Trato con animales: " + mascota.tratoAnimal;
                        break;
                    case "NombreDueño":
                        datosQR += " Nombre del dueño: " + mascota.duenio.nombre;
                        break;
                    case "Direccion":
                        datosQR += " Direccion: " + mascota.duenio.domicilio + " B°: " +mascota.duenio.barrio.nombre;
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
