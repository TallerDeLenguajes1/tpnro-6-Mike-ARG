using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaMVC.Models;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaMVC.Entidades;
using CadeteriaMVC.ViewModel;

namespace CadeteriaMVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IMapper _mapper;
        private List<CadeteriaMVC.Entidades.Cliente> ListaClientes;

        public ClientesController(ILogger<ClientesController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            ListaClientes = new List<CadeteriaMVC.Entidades.Cliente>();
        }

        public IActionResult Index()
        {
            RepositorioCliente R = new RepositorioCliente();
            ListaClientes = R.GetAll();
            List<ClienteViewModel> ListaClienteVM = _mapper.Map<List<ClienteViewModel>>(ListaClientes);
            return View(ListaClienteVM);
        }

        public IActionResult AltaCliente()
        {
            return View(new CadeteriaMVC.ViewModel.ClienteViewModel());
        }

        [HttpPost]
        public IActionResult CrearCliente(CadeteriaMVC.ViewModel.ClienteViewModel C)
        {
            if (ModelState.IsValid)
            {
                RepositorioCliente R = new RepositorioCliente();
                Cliente ClienteDTO = _mapper.Map<Cliente>(C);
                R.Alta(ClienteDTO);
            }
            return Redirect("/Clientes/Index");
        }

        public IActionResult UpdateCliente(int id)
        {
            //return View(new CadeteriaMVC.ViewModel.ClienteViewModel { ID = id });

            RepositorioCliente R = new RepositorioCliente();
            CadeteriaMVC.Entidades.Cliente C = R.Buscar(id);
            ClienteViewModel CVM = _mapper.Map<ClienteViewModel>(C);
            if (C != null)
            {
                return View(CVM);
            }
            else
            {
                return Content("No se encontró ningun cadete con ese id");
            }
        }
        public IActionResult ModificarCliente(CadeteriaMVC.ViewModel.ClienteViewModel C)
        {
            RepositorioCliente R = new RepositorioCliente();
            Cliente ClienteDTO = _mapper.Map<Cliente>(C);
            R.Update(ClienteDTO);

            return Redirect("/Clientes/Index");
        }

        public IActionResult BajaCliente(int id)
        {
            RepositorioCliente R = new RepositorioCliente();
            CadeteriaMVC.Entidades.Cliente C = R.Buscar(id);
            ClienteViewModel CVM = _mapper.Map<ClienteViewModel>(C);
            if (C != null)
            {
                return View(CVM);
            }
            else
            {
                return Content("No se encontró ningun usuario con ese id");
            }
        }

        [HttpPost]
        public IActionResult EliminarCliente(CadeteriaMVC.ViewModel.ClienteViewModel C)
        {
            try
            {
                RepositorioCliente R = new RepositorioCliente();
                Cliente ClienteDTO = _mapper.Map<Cliente>(C);
                R.Baja(ClienteDTO.Id);
            }
            catch (Exception ex)
            {
                Content(ex.ToString());
            }
            return Redirect("/Clientes/Index");
        }
        public IActionResult MostrarPedidos(int id)
        {
            Cliente C = new RepositorioCliente().Buscar(id);
            List<CadeteriaMVC.Entidades.Pedido> ListaPedidos = new RepositorioCliente().PedidosCliente(C.Id);
            List<PedidoViewModel> ListaVM = _mapper.Map<List<PedidoViewModel>>(ListaPedidos);
            ViewBag.Nombre = C.Nombre;

            return View(ListaVM);
        }
        public IActionResult Inicio(int id)
        {
            RepositorioCliente R = new RepositorioCliente();
            Cliente cli = R.Buscar(id);
            ClienteViewModel cliVM = _mapper.Map<ClienteViewModel>(cli);

            return View(cliVM);
        }
    }
}
