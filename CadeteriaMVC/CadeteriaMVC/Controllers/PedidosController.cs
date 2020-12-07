using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaMVC.Entidades;
using CadeteriaMVC.Models;
using System.Data.SQLite;

namespace CadeteriaMVC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ILogger<PedidosController> _logger;
        private List<Pedido> ListaPedidos;

        public PedidosController (ILogger<PedidosController> logger)
        {
            _logger = logger;
            ListaPedidos = new List<Pedido>();
        }
        
        public IActionResult Index()
        {
            RepositorioPedido R = new RepositorioPedido();
            ListaPedidos = R.GetAll();

            return View(ListaPedidos);
        }

        public IActionResult AltaPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public IActionResult CrearPedido(Pedido P)
        {
            string mensaje;

            if (ModelState.IsValid)
            {
                RepositorioPedido R = new RepositorioPedido();
                R.Alta(P);
                mensaje = "Se creó con éxito el pedido.";
            } else
            {
                mensaje = "Error. No fue posible crear el pedido.";
            }

            return Content(mensaje);
        }

        public IActionResult UpdatePedido(int id)
        {
            return View(new Pedido { Id = id });
        }

        public IActionResult ModificarPedido(Pedido P)
        {
            RepositorioPedido R = new RepositorioPedido();
            R.Update(P);

            return Redirect("/Pedidos/Index");
        }

        public IActionResult BajaPedido(int id)
        {
            RepositorioPedido R = new RepositorioPedido();
            Pedido P = R.Buscar(id);

            if (P != null)
            {
                return View(P);
            } else
            {
                return Content("No se hallaron pedidos con esa ID.");
            }
        }

        [HttpPost]

        public IActionResult EliminarPedido(Pedido P)
        {
            string mensaje;
            try
            {
                RepositorioPedido R = new RepositorioPedido();
                R.Baja(P.Id);
                mensaje = "Se eliminó con éxito el pedido.";
            }
            catch (Exception)
            {
                mensaje = "No fue posible eliminar el pedido.";
            }

            return Content(mensaje);
        }


    }
}
