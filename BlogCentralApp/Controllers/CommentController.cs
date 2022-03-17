using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class CommentController : Controller
    {
        public async Task<IActionResult> AddComment()
        {
            return View();
        }
    }
}
