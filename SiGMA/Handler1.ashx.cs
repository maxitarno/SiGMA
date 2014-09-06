using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiGMA
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public delegate byte[] dOnObtenerImagen(HttpContext context);
        private static event dOnObtenerImagen ObtenerImagen;

        /// <summary>
        /// Agrega el handler al evento que se encarga de renderizar la imagen.
        /// </summary>
        /// <param name="metodo">Implementación del método que obtiene la imagen y la retorna como un array de bytes.</param>
        public static void AddMethod(dOnObtenerImagen metodo)
        {
            RemoveAllHandlers();
            ObtenerImagen += new dOnObtenerImagen(metodo);
        }

        public void ProcessRequest(HttpContext context)
        {
            byte[] imagen = null;

            if (ObtenerImagen != null)
            {
                imagen = ObtenerImagen(context);
            }

            context.Response.ContentType = "image/jpg";

            if (imagen != null && imagen.Length > 0)
            {
                context.Response.OutputStream.Write(imagen, 0, imagen.Length);
            }
            else
            {
                context.Response.WriteFile("~/App_Themes/TemaSigma/imagenes/sin_imagen_disponible.jpg");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private static void RemoveAllHandlers()
        {
            if (ObtenerImagen != null)
            {
                foreach (dOnObtenerImagen eh in ObtenerImagen.GetInvocationList())
                {
                    ObtenerImagen -= eh;
                }
            }
        }
    }
}