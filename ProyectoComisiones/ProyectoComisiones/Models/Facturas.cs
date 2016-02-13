using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoComisiones.Models
{
    public class Facturas
    {

        public string NCP { get; set; }
        public string CLIENTE { get; set; }
        public string NFACTURA { get; set; }
        public string FEMISION { get; set; }
        public string FCANCEL { get; set; }
        public string VALORDEVENTA { get; set; }
        public string DEBEDOLAR { get; set; }
        public string HABERDOLAR { get; set; }
        public string DEBESOLES { get; set; }
        public string HABERSOLES { get; set; }
        public string ESTADO { get; set; }
        public string CONDICIONDEPAGO { get; set; }
        public string MONEDA { get; set; }


    }
}