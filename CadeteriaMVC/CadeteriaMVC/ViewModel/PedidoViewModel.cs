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
        public Cliente Cliente { get; set; }
        public Pedido.Estado Estado { get; set; }
        public Pedido.TipoPedido TipoPedido { get; set; }
        public bool TieneCupon { get; set; }
        public double CostoPedido { get; set; }
    }
}
