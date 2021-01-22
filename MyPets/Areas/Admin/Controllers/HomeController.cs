using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPets.Domain;

namespace MyPets.Areas.Admin.Controllers
{
    [Area("Admin")]//пометить область Admin чтобы правило вступило в силу 
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;//для доступа к доменной модели/объектам

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.ServiceItems.GetServiceItems());//вывод списка всех услуг
        }
    }
}
