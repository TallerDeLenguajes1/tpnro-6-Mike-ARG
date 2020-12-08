using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaMVC.Entidades;

namespace CadeteriaMVC.ViewModel
{
    public class ClienteViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public List<Pedido> ListaPedidos { get; set; }
    }
}
