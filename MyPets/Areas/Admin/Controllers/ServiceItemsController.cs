using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPets.Domain;
using MyPets.Domain.Entities;
using MyPets.Service;

namespace MyPets.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller   //для редактир услуг на сайте
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;//для сохр картинок

        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)//ищем услугу в бд и если есть то редакт если нет создаем
        {
            var entity = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemById(id);
            return View(entity);
        }

        [HttpPost]                                    //подгружаем картинки
        public IActionResult Edit(ServiceItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;                  //помещ картинку в корень
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.ServiceItems.SaveServiceItem(model);//сохран услугу
                //и перенаправляем пользователя на главную страницу админки
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)//удаляем услугу из базы данных
        {
            dataManager.ServiceItems.DeleteServiceItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
