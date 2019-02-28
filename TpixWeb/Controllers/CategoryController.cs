using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpixWeb.Controllers
{
    public class CategoryController : Controller
    {
        [Route("c/{categoryName}")]
        public IActionResult Index(string categoryName)
        {



            return View();
        }
        //public string CategoryName()


    }
}
