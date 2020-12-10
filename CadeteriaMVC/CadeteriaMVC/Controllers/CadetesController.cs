using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaMVC.Models;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaMVC.ViewModel;
using CadeteriaMVC.Entidades;

namespace CadeteriaMVC.Controllers
{
	public class CadetesController : Controller
	{
		private readonly ILogger<ClientesController> _logger;
		private readonly IMapper _mapper;
		private List<CadeteriaMVC.Entidades.Cadete> ListaCadetes;

		public CadetesController(ILogger<ClientesController> logger, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
			ListaCadetes = new List<CadeteriaMVC.Entidades.Cadete>();
		}

		public IActionResult Index()
		{
			RepositorioCadete R = new RepositorioCadete();
			ListaCadetes = R.GetAll();
			List<CadeteViewModel> ListCadeteVM = _mapper.Map<List<CadeteViewModel>>(ListaCadetes);

			return View(ListCadeteVM);
		}

		public IActionResult AltaCadete()
		{
			return View(new CadeteriaMVC.Entidades.Cadete());
		}

		[HttpPost]
		public IActionResult CrearCadete(CadeteriaMVC.ViewModel.CadeteViewModel C)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Cadete CadeteDTO = _mapper.Map<Cadete>(C);
					RepositorioCadete R = new RepositorioCadete();
					R.Alta(CadeteDTO);
				}
				return Redirect("/Cadetes/Index");
			}
			catch (Exception ex)
			{
				return Content(ex.Message);
			}
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
		public IActionResult ModificarCadete(CadeteriaMVC.ViewModel.CadeteViewModel C)
		{
			if (ModelState.IsValid)
			{
				RepositorioCadete R = new RepositorioCadete();
				Cadete CadeteDTO = _mapper.Map<Cadete>(C);
				R.Update(CadeteDTO);
			}
			return Redirect("/Cadetes/Index");
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
		public IActionResult EliminarCadete(CadeteriaMVC.ViewModel.CadeteViewModel C)
		{
			try
			{
				RepositorioCadete R = new RepositorioCadete();
				Cadete CadeteDTO = _mapper.Map<Cadete>(C);
				R.Baja(CadeteDTO.Id);
				return Redirect("/Cadetes/Index");
			}
			catch (Exception)
			{
				return Redirect("/Cadetes/Index");
			}
		}

		public IActionResult MostrarPedidos(int id)
		{
			CadeteriaMVC.Entidades.Cadete C = new RepositorioCadete().Buscar(id);
			List<CadeteriaMVC.Entidades.Pedido> ListaPedidos = new RepositorioCadete().GetPedidos(C);
			ViewBag.Nombre = C.Nombre;

			return View(ListaPedidos);
		}
	}
}
