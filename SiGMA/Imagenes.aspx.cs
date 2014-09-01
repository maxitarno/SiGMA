using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
namespace SiGMA
{
    public partial class Imagenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MemoryStream ms = new MemoryStream((byte[])Session["imagen"]);
                Bitmap imagen = (Bitmap)System.Drawing.Image.FromStream(ms);
                /*imagen.Save(ms, ImageFormat.Jpeg);
                Context.Response.ContentType = "image/jpeg";
                imagen.Save("C:\\Users\\NICOLAS\\Downloads"+(int)Session["idmascota"], ImageFormat.Jpeg);
                imgImage1.ImageUrl = "C:\\Users\\NICOLAS\\Downloads" + (int)Session["idmascota"];*/
            }
        }
        public void BtnOrigenClick(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarMascotas.aspx");
        }
    }
}