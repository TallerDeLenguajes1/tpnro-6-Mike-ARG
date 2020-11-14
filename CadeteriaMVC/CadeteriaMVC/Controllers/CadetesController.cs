using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaMVC.Controllers
{
    public class CadetesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
