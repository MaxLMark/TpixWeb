using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpixWeb.Models;
using TpixWeb.Models.ViewModels;

namespace TpixWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new IndexViewModel();
            vm.Categories = GetCategories();

            return View(vm);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Title = "Sport"

                },
                 new Category()
                {
                     Id = 2,
                    Title = "Väder"
                },
                  new Category()
                {
                      Id = 3,
                    Title = "Hästar"
                },
                   new Category()
                {
                       Id = 4,
                    Title = "Mat"
                },
                    new Category()
                {
                        Id = 5,
                    Title = "Memes"
                },
                     new Category()
                {
                         Id = 6,
                    Title = "Gaming"
                },
                      new Category()
                {
                          Id = 7,
                    Title = "Trolololol"
                }
            };

            return categories;
        }

    }
}
