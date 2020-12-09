using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaMVC.Entidades;

namespace CadeteriaMVC.ViewModel
{
    public class CadeteViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public List<Pedido> ListaPedidos { get; set; }
        public Cadete.Vehiculo TipoVehiculo { get; set; }
        public double Jornal { get; set; }

        /*public int CantidadEntregados()
        {
            int pedidosEntregados = 0;

            foreach (Pedido pedido in ListaPedidos)
            {
                if (pedido.Estado1 == Pedido.Estado.Entregado)
                {
                    pedidosEntregados++;
                }
            }
            return pedidosEntregados;
        }

        public double CalcularJornal()
        {
            return CantidadEntregados() * 100;
        }*/

    }
}
