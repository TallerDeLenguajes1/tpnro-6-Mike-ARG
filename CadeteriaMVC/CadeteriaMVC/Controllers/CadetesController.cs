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
            RepositorioCliente R = new RepositorioCliente();
            ListaCadetes = R.GetAll();
            return View(ListaCadetes);
        }
    }
}
