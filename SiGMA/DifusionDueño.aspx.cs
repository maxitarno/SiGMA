using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using AccesoADatos;

namespace SiGMA
{
    public partial class DifusionDueño : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                listarPedidosDifusion();
            }
            else 
            {
                pnlInfo.Visible = false;
            }
        }

        private void listarPedidosDifusion()
        {
            List<EPedidoDifusion> listPedidos = LogicaBDPedidoDifusion.buscarPedidosDifusion(new EUsuario { user = Session["UsuarioLogueado"].ToString() });
            grvPedidos.DataSource = listPedidos;
            grvPedidos.DataBind();
            if (listPedidos.Count == 0)
            {
                pnlInfo.Visible = true;
                SetFocus(lblInfo);
                pnlPedidos.Visible = false;
            }
            else 
            {
                pnlPedidos.Visible = true;
            }
        }

        protected void grvPedidos_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection objDireccion;
            if (ViewState["Direccion"] == null)
            {
                objDireccion = e.SortDirection;
            }
            else
            {
                objDireccion = (SortDirection)ViewState["Direccion"];
            }
            List<EPedidoDifusion> listPedidos = LogicaBDPedidoDifusion.buscarPedidosDifusion(new EUsuario { user = Session["UsuarioLogueado"].ToString() });
            switch (e.SortExpression)
            {
                case "tipo":
                    if (objDireccion == SortDirection.Ascending)
                    {
                        grvPedidos.DataSource = listPedidos.OrderBy(l => l.tipo).ToList<EPedidoDifusion>();
                        objDireccion = SortDirection.Descending;
                    }
                    else
                    {
                        grvPedidos.DataSource = listPedidos.OrderByDescending(l => l.tipo).ToList<EPedidoDifusion>();
                        objDireccion = SortDirection.Ascending;
                    }
                    break;
                case "fecha":
                    if (objDireccion == SortDirection.Ascending)
                    {
                        grvPedidos.DataSource = listPedidos.OrderBy(l => l.fecha).ToList<EPedidoDifusion>();
                        objDireccion = SortDirection.Descending;
                    }
                    else
                    {
                        grvPedidos.DataSource = listPedidos.OrderByDescending(l => l.fecha).ToList<EPedidoDifusion>();
                        objDireccion = SortDirection.Ascending;
                    }
                    break;
                case "estado.nombreEstado":
                    if (objDireccion == SortDirection.Ascending)
                    {
                        grvPedidos.DataSource = listPedidos.OrderBy(l => l.estado.nombreEstado).ToList<EPedidoDifusion>();
                        objDireccion = SortDirection.Descending;
                    }
                    else
                    {
                        grvPedidos.DataSource = listPedidos.OrderByDescending(l => l.estado.nombreEstado).ToList<EPedidoDifusion>();
                        objDireccion = SortDirection.Ascending;
                    }
                    break;
                case "motivoRechazo":
                    return;
            }
            grvPedidos.DataBind();
            ViewState["Direccion"] = objDireccion;
        }

        protected void btnRegCampaña_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarCampaña.aspx");
        }
    }
}