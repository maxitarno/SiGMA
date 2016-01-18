﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;

namespace SiGMA
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DateTime.Today.Day == 1)
                LogicaBDPerdida.caducarPerdidas();
        }
    }
}