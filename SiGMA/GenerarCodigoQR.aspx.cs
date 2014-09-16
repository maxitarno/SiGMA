using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramientas;
using Entidades;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using AccesoADatos;

namespace SiGMA
{
    public partial class GenerarCodigoQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["CamposQR"] = new List<string>();
                EMascota mascota = (EMascota)Session["Mascota"];
                mascota.duenio = LogicaBDDueño.buscarDueño(mascota.idMascota);
                habilitarCheckboxes();
            }
        }

        protected void chkNombreMascota_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("NombreMascota", chkNombreMascota.Checked);
        }
        private void mostrarCodigo()        
        { 
            EMascota mascota = (EMascota)Session["Mascota"];
            Bitmap qr = GenerarQR.generarQR(mascota, (List<string>)Session["CamposQR"]);
            string rutaGuardar = Server.MapPath("Imagenes/") + "qr" + mascota.idMascota.ToString() + ".jpg";
            qr.Save(rutaGuardar, ImageFormat.Jpeg);
            string rutaLeer = "Imagenes/" + "qr" + mascota.idMascota.ToString() + ".jpg";
            imgQR.ImageUrl = rutaLeer;
            ViewState["CodigoQR"] = "qr" + mascota.idMascota.ToString() + ".jpg"; ;
        }

        protected void chkColor_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("Color", chkColor.Checked);

        }
        private void actualizarCampos(string campo, bool chk)
        {
            List<string> campos = (List<string>)Session["CamposQR"];
            if (chk)
            {
                campos.Add(campo);
            }
            else
            {
                campos.Remove(campo);
            }
            if (campos.Count != 0)
            {
                mostrarCodigo();
                btnDescargar.Enabled = true;
            }
            else
            {
                imgQR.ImageUrl = null;
                btnDescargar.Enabled = false;
            }            
            Session["CamposQR"] = campos;
        }
        protected void chkRaza_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("Raza", chkRaza.Checked);
        }

        protected void chkSexo_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("Sexo", chkSexo.Checked);

        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition","attachment;filename=" + ViewState["CodigoQR"].ToString());
            Response.TransmitFile(Server.MapPath("/Imagenes/" + ViewState["CodigoQR"].ToString()));
            Response.End();
        }

        protected void chkTratoNiños_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("Niños", chkNiños.Checked);
        }

        protected void chkTratoAnimales_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("Animales", chkAnimales.Checked);

        }

        protected void chkNombreDueño_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("NombreDueño", chkNombreDueño.Checked);
        }

        protected void chkDireccion_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("Direccion", chkDireccion.Checked);
        }       

        protected void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("Email", chkEmail.Checked);
        }

        protected void chkTelefono_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCampos("Telefono", chkTelefonoCel.Checked);

        }
        private void habilitarCheckboxes()
        {
            EMascota mascota = (EMascota)Session["Mascota"];
            if (mascota.duenio.telefonoCelular == null)
            {
                chkTelefonoCel.Enabled = false;
            }
            if (mascota.duenio.domicilio == null)
            {
                chkDireccion.Enabled = false;                
            }
        }
    }
}