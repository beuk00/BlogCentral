using BlogCentralApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class BlogDetailController : Controller
    {
        public IActionResult Index()
        {
            DetailIndexViewModel vm = new DetailIndexViewModel();

            return View(vm);
        }
    }
}
