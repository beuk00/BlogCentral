using BlogCentralApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogCentralApp.Controllers
{
    public class TinyMCEController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TinyTest model)
        {
            return View();
        }


    }
}
