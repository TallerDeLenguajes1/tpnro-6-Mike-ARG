using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaMVC.Entidades;
using CadeteriaMVC.Models;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaMVC.ViewModel;

namespace CadeteriaMVC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IMapper _mapper;
        private List<Pedido> ListaPedidos;

        public PedidosController (ILogger<PedidosController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            ListaPedidos = new List<Pedido>();
        }
        
        public IActionResult Index()
        {
            RepositorioPedido R = new RepositorioPedido();
            ListaPedidos = R.GetAll();
            List<PedidoViewModel> ListaPedidoVM = _mapper.Map<List<PedidoViewModel>>(ListaPedidos);

            return View(ListaPedidoVM);
        }

        public IActionResult IndexCadete()
        {
            RepositorioPedido R = new RepositorioPedido();
            ListaPedidos = R.GetAll();
            List<PedidoViewModel> ListaPedidoVM = _mapper.Map<List<PedidoViewModel>>(ListaPedidos);

            return View(ListaPedidoVM);
        }

        public IActionResult AltaPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public IActionResult CrearPedido(PedidoViewModel P)
        {

            if (ModelState.IsValid)
            {
                RepositorioPedido R = new RepositorioPedido();
                Pedido PedidoDTO = _mapper.Map<Pedido>(P);
                R.Alta(PedidoDTO);
            } 
            return Redirect("Index");
        }
        public IActionResult UpdatePedido(int id)
        {
            return View(new Pedido { Id = id });
        }

        [HttpPost]
        public IActionResult ModificarPedido(PedidoViewModel P)
        {
            RepositorioPedido R = new RepositorioPedido();
            Pedido PedidoDTO = _mapper.Map<Pedido>(P);
            PedidoDTO.Cliente = P.Cliente;
            PedidoDTO.Cadete = P.Cadete;
            R.Update(PedidoDTO);

            return Redirect("Index");
        }

        public IActionResult UpdateEstado(int id)
        {
            return View(new Pedido { Id = id });
        }

        [HttpPost]
        public IActionResult ModificarEstado(PedidoViewModel P)
        {
            RepositorioPedido R = new RepositorioPedido();
            Pedido PedidoDTO = _mapper.Map<Pedido>(P);
            R.UpdatePedido(PedidoDTO);

            return Redirect("IndexCadete");
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

        public IActionResult EliminarPedido(PedidoViewModel P)
        {
            try
            {
                RepositorioPedido R = new RepositorioPedido();
                Pedido PedidoDTO = _mapper.Map<Pedido>(P);
                R.Baja(PedidoDTO.Id);
            }
            catch (Exception ex)
            {
                Content(ex.Message);
            }
            return Redirect("Index");
        }


    }
}
