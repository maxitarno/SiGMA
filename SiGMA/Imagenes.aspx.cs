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
                string formato = ImageFormat.Jpeg.ToString();
                string path = string.Format(@"C:\Users\NICOLAS\Desktop\SiGMA\trunk\SiGMA\imagenes\"+(int)Session["idMAscota"]+"."+formato.ToString());
                System.Drawing.Image imagen =System.Drawing.Image.FromStream(ms);
                imagen.Save(path, ImageFormat.Jpeg);
                imagen.Dispose();
                imgImage1.ImageUrl = path;
            }
        }
        public void BtnOrigenClick(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarMascotas.aspx");
        }
    }
}