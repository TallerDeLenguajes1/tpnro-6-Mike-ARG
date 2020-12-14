using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaMVC.Entidades;

namespace CadeteriaMVC.ViewModel
{
    public class PedidoViewModel
    {
        public int ID { get; set; }
        public string Observacion { get; set; }
        public int Cliente { get; set; }
        public int Cadete { get; set; }
        public Estado Estado { get; set; }
        public TipoPedido TipoPedido { get; set; }
        public bool TieneCupon { get; set; }
        public double CostoPedido { get; set; }
    }
}
