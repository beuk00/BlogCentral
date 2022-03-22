using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BlogPostRepository _blogPostRepository;
        private readonly UserManager<IdentityUser> _userManager;

        
    
        public AuthorController(BlogPostRepository blogPostRepository, UserManager<IdentityUser> userManager)
        {
            _blogPostRepository = blogPostRepository;
            _userManager = userManager; 
        }
        public async Task<IActionResult> Index1(string id)
        {
            HomePageViewModel vm = new HomePageViewModel();
            
            if (id!=null)
            {
               vm.AuthorId = id;
               HttpContext.Response.Cookies.Append("id", id);

            }

            vm.StartOfSelection = true;
            vm.Author = (Author)await _userManager.FindByIdAsync(vm.AuthorId);
            vm.BlogPosts = _blogPostRepository.GetAll().Where(a=>a.AuthorId== vm.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
            HttpContext.Response.Cookies.Append("count", "6");
            HttpContext.Response.Cookies.Append("lastSort", "Newest first");
            return View("IndexAuthor", vm);
        }

        public async Task<IActionResult> Next10(HomePageViewModel model)
        {
            model = new HomePageViewModel();
            model.AuthorId = HttpContext.Request.Cookies["id"];
            model.Author = (Author)await _userManager.FindByIdAsync(model.AuthorId);
            int countShow;
            int range = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Count() - int.Parse(HttpContext.Request.Cookies["count"]);
            model.StartOfSelection = false;

            if (range <= 9 )
            {
                countShow = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Count();
                model.EndOfSelection = true;
            }
            else
            {
                range = 10;
                countShow = int.Parse(HttpContext.Request.Cookies["count"]) + 10;
                model.EndOfSelection = false;
            }

            HttpContext.Response.Cookies.Append("count", countShow.ToString());

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    break;

                case "Most popular First":
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    break;

                default:
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    break;
            }

            return View("IndexAuthor", model);
        }

                public async Task<IActionResult> Previous10(HomePageViewModel model)
                {
                    model = new HomePageViewModel();
                    int range = int.Parse(HttpContext.Request.Cookies["count"]) - 10;
                    model.EndOfSelection = false;
                    model.AuthorId = HttpContext.Request.Cookies["id"];
                    model.Author = (Author)await _userManager.FindByIdAsync(model.AuthorId);

            if (range <= 11)
                    {
                        return RedirectToAction("First10");
                    }
                    else
                    {
                        HttpContext.Response.Cookies.Append("count", range.ToString());

                        switch (HttpContext.Request.Cookies["lastSort"])
                        {
                            case "Oldest first":
                            model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                            break;

                            case "Most popular First":
                            model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                            break;

                            default:
                            model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                            break;
                        }
                        
                    return View("IndexAuthor", model);
                    }
                }

        public async Task<IActionResult> Last10(HomePageViewModel model)
        {
            model = new HomePageViewModel();
            HttpContext.Response.Cookies.Append("count", _blogPostRepository.GetAll().Count().ToString());
            model.EndOfSelection = true;
            model.StartOfSelection = false;
            model.AuthorId = HttpContext.Request.Cookies["id"];
            model.Author = (Author)await _userManager.FindByIdAsync(model.AuthorId);

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().TakeLast(10);
                    break;

                case "Most popular First":
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().TakeLast(10);
                    break;

                default:
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().TakeLast(10);
                    break;

            }
            return View("IndexAuthor", model);
        }

        public async Task<IActionResult> First10(HomePageViewModel model)
        {
            model = new HomePageViewModel();
            HttpContext.Response.Cookies.Append("count", "10");
            model.EndOfSelection = false;
            model.StartOfSelection = true;
            model.AuthorId = HttpContext.Request.Cookies["id"];
            model.Author = (Author)await _userManager.FindByIdAsync(model.AuthorId);

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(10);
                    break;

                case "Most popular First":
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(10);
                    break;

                default:
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(10);
                    break;

            }

            return View("IndexAuthor", model);
        }


        [HttpPost]
        public async Task<IActionResult> Sort(HomePageViewModel model)
        {
            
            HttpContext.Response.Cookies.Append("count", "6");
            string AuthorId = HttpContext.Request.Cookies["id"];

            switch (model.Sort)
            {
                case "Oldest first":
                    model = new HomePageViewModel();
                    HttpContext.Response.Cookies.Append("lastSort", "Oldest first");
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == AuthorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(6);
                    break;

                case "Most popular First":
                    model = new HomePageViewModel();
                    HttpContext.Response.Cookies.Append("lastSort", "Most popular First");
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(6);
                    break;

                default:
                    model = new HomePageViewModel();
                    HttpContext.Response.Cookies.Append("lastSort", "Newest first");
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
                    break;
            }

            model.EndOfSelection = false;
            model.StartOfSelection = true;
            model.Author = (Author)await _userManager.FindByIdAsync(AuthorId);

            return View("IndexAuthor", model);
        }
    }
}

