using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaMVC.Models;
using System.Data.SQLite;

namespace CadeteriaMVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        private List<CadeteriaMVC.Entidades.Cliente> ListaClientes;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
            ListaClientes = new List<CadeteriaMVC.Entidades.Cliente>();
        }

        public IActionResult Index()
        {
            RepositorioCliente R = new RepositorioCliente();
            ListaClientes = R.GetAll();
            return View(ListaClientes);
        }

        public IActionResult AltaCliente()
        {
            return View(new CadeteriaMVC.Entidades.Cliente("","",1234));
        }

        [HttpPost]
        public IActionResult CrearCliente(CadeteriaMVC.Entidades.Cliente C)
        {
            string mensaje;
            if (ModelState.IsValid)
            {
                RepositorioCliente R = new RepositorioCliente();
                R.Alta(C);
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
            RepositorioCliente R = new RepositorioCliente();
            CadeteriaMVC.Entidades.Cliente C = R.Buscar(id);
            if (C != null)
            {

                return View(C);
            }
            else
            {
                return Content("No se encontró ningun usuario con ese id");
            }
        }

        [HttpPost]
        public IActionResult ModificarCliente(CadeteriaMVC.Entidades.Cliente C)
        {
            string mensaje;
            if (ModelState.IsValid)
            {
                RepositorioCliente R = new RepositorioCliente();
                R.Update(C);
                mensaje = "Se modificó con exito el cliente";
            }
            else
            {
                mensaje = "Hubo un error, intente de nuevo";
            }

            return Content(mensaje);
        }

        public IActionResult BajaCliente(int id)
        {
            RepositorioCliente R = new RepositorioCliente();
            CadeteriaMVC.Entidades.Cliente C = R.Buscar(id);
            if (C != null)
            {
                return View(C);
            }
            else
            {
                return Content("No se encontró ningun usuario con ese id");
            }
        }

        [HttpPost]
        public IActionResult EliminarCliente(CadeteriaMVC.Entidades.Cliente C)
        {
            string mensaje;
            try
            {
                RepositorioCliente R = new RepositorioCliente();
                R.Baja(C.id);
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
