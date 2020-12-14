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
            string mensaje;
            if (ModelState.IsValid)
            {
                RepositorioCliente R = new RepositorioCliente();
                Cliente ClienteDTO = _mapper.Map<Cliente>(C);
                R.Alta(ClienteDTO);
                mensaje = "Se creo con exito el cliente";
            }
            else
            {
                mensaje = "Hubo un error, intente de nuevo";
            }

            return Content(mensaje);
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
            string mensaje;
            try
            {
                RepositorioCliente R = new RepositorioCliente();
                Cliente ClienteDTO = _mapper.Map<Cliente>(C);
                R.Baja(ClienteDTO.Id);
                mensaje = "Se elimino con exito el cliente";
            }
            catch (Exception)
            {
                mensaje = "Hubo un error, intente de nuevo";
            }
            return Content(mensaje);
        }
    }
}
