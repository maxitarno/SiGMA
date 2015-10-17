using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ECampaña
    {
        public int idCampaña { get; set; }
        public ETipoCampaña tipoCampaña { get; set; }
        public DateTime fecha { get; set; }
        public string lugar { get; set; }
        public DateTime hora { get; set; }
        public byte[] imagen { get; set; }
    }
}
