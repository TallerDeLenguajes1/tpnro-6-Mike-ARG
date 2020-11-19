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
    public class CadetesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        private List<CadeteriaMVC.Entidades.Cadete> ListaCadetes;
        public CadetesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
            ListaCadetes = new List<CadeteriaMVC.Entidades.Cadete>();
        }

        public IActionResult Index()
        {
            RepositorioCadete R = new RepositorioCadete();
            ListaCadetes = R.GetAll();
            return View(ListaCadetes);
        }

		public IActionResult AltaCadete()
		{
			return View(new CadeteriaMVC.Entidades.Cadete());
		}

		[HttpPost]
		public IActionResult CrearCadete(CadeteriaMVC.Entidades.Cadete C)
		{
			string mensaje;
			if (ModelState.IsValid)
			{
				RepositorioCadete R = new RepositorioCadete();
				R.Alta(C);
				mensaje = "Se creo con exito el cadete";
			}
			else
			{
				mensaje = "Hubo un error, intente de nuevo";
			}

			return Content(mensaje);
		}

		public IActionResult UpdateCadete(int id)
		{
			RepositorioCadete R = new RepositorioCadete();
			CadeteriaMVC.Entidades.Cadete C = R.Buscar(id);
			if (C != null)
			{
				return View(C);
			}
			else
			{
				return Content("No se encontró ningun cadete con ese id");
			}
		}

		[HttpPost]
		public IActionResult ModificarCadete(CadeteriaMVC.Entidades.Cadete C)
		{
			string mensaje;
			if (ModelState.IsValid)
			{
				RepositorioCadete R = new RepositorioCadete();
				R.Update(C);
				mensaje = "Se modificó con exito el cadete";
			}
			else
			{
				mensaje = "Hubo un error, intente de nuevo";
			}

			return Content(mensaje);
		}

		public IActionResult BajaCadete(int id)
		{
			RepositorioCadete R = new RepositorioCadete();
			CadeteriaMVC.Entidades.Cadete C = R.Buscar(id);
			if (C != null)
			{
				return View(C);
			}
			else
			{
				return Content("No se encontró ningun cadete con ese id");
			}
		}

		[HttpPost]
		public IActionResult EliminarCadete(CadeteriaMVC.Entidades.Cadete C)
		{
			string mensaje;
			try
			{
				RepositorioCadete R = new RepositorioCadete();
				R.Baja(C.id);
				mensaje = "Se elimino con exito el cadete";
			}
			catch (Exception)
			{
				mensaje = "Hubo un error, intente de nuevo";
			}

			return Content(mensaje);
		}

		public IActionResult MostrarPedidos(int id)
		{
			CadeteriaMVC.Entidades.Cadete C = new RepositorioCadete().Buscar(id);
			List<CadeteriaMVC.Entidades.Pedido> ListaPedidos = new RepositorioCadete().GetPedidos(C);
			ViewBag.Nombre = C.nombre;

			return View(ListaPedidos);
		}
	}
}
