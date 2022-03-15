using BlogCentralApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class AuthorController : Controller
    {
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            return View(model);
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            return View(model);
        }
    }
}
