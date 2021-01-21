using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyPets.Areas.Admin.Controllers
{
    [Area("Admin")]//пометить область Admin чтобы правило вступило в силу 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
