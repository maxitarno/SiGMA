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
                }
                //if (cadena.Equals("NombreMascota"))
                //{
                //    datosQR += mascota.nombreMascota;
                //}
            }
            Bitmap retorno = codificador.Encode(datosQR);
            return retorno;
        }
    }
}
