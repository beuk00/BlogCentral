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
       
        private static HomePageViewModel vm =new HomePageViewModel();
        private static string _authorId;
       
    
        public AuthorController(BlogPostRepository blogPostRepository, UserManager<IdentityUser> userManager)
        {
            _blogPostRepository = blogPostRepository;
            _userManager = userManager; 
        }
        public async Task<IActionResult> Index1(string id)
        {
            if (id!=null)
            {
            _authorId=id;

            }
           
            vm.Author = (Author)await _userManager.FindByIdAsync(_authorId);
            vm.BlogPosts = _blogPostRepository.GetAll().Where(a=>a.AuthorId== _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
            HttpContext.Response.Cookies.Append("count", "6");
            HttpContext.Response.Cookies.Append("lastSort", "Newest first");
            return View("IndexAuthor", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? sort, int count)
        {

            string sortalgo = RouteData.Values["sort"]?.ToString();
            string counter = RouteData.Values["count"]?.ToString();
            count = count + 10;

            vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);

            return View("IndexAuthor", vm);
        }

        

        public async Task<IActionResult> Next10(HomePageViewModel model)
        {
            int countShow;
            int range = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Count() - int.Parse(HttpContext.Request.Cookies["count"]);

            if (range <= 9 && range >= 1)
            {
                countShow = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Count();
            }
            else if (range <= 0)
            {
                return RedirectToAction("Last10");
            }
            else
            {
                range = 10;
                countShow = int.Parse(HttpContext.Request.Cookies["count"]) + 10;
            }

            HttpContext.Response.Cookies.Append("count", countShow.ToString());

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);

                    return View("IndexAuthor", vm);

                case "Most popular First":
                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    return View("IndexAuthor", vm);

                default:
                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    return View("IndexAuthor", vm);
            }

           
        }

                public async Task<IActionResult> Previous10(HomePageViewModel model)
                {
                    int range = int.Parse(HttpContext.Request.Cookies["count"]) - 10;

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
                        vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                                return View("IndexAuthor", vm);

                            case "Most popular First":
                        vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                                return View("IndexAuthor", vm);

                            default:
                        vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                                return View("IndexAuthor", vm);
                        }
                    }
                }

        public async Task<IActionResult> Last10(HomePageViewModel model)
        {
            HttpContext.Response.Cookies.Append("count", _blogPostRepository.GetAll().Count().ToString());

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Newest first":
                    //model = new HomePageViewModel();
                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().TakeLast(10);
                    //model.Author = _author;
                    return View("IndexAuthor", vm);

                case "Oldest first":

                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().TakeLast(10);
                    return View("IndexAuthor", vm);

                case "Most popular First":
                     
                    //model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.likes).ToList().TakeLast(10);
                    return View("IndexAuthor", vm);

                default:
                    return View("IndexAuthor");

            }
        }

        public async Task<IActionResult> First10(HomePageViewModel model)
        {
            HttpContext.Response.Cookies.Append("count", "10");

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Newest first":

                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(10);
                    return View("IndexAuthor", vm);

                case "Oldest first":

                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(10);
                    return View("IndexAuthor", vm);

                case "Most popular First":
                    model = new HomePageViewModel();
                    //model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.likes).ToList().Take(10);
                    return View("IndexAuthor", vm);

                default:
                    return View("IndexAuthor");

            };
        }


        [HttpPost]
        public async Task<IActionResult> Sort(HomePageViewModel model)
        {
            HttpContext.Response.Cookies.Append("count", "6");

            switch (model.Sort)
            {
                case "Oldest first":
                    HttpContext.Response.Cookies.Append("lastSort", "Oldest first");
                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(6);
                    return View("IndexAuthor", vm);

                case "Most popular First":
                    HttpContext.Response.Cookies.Append("lastSort", "Most popular First");
                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(6);
                    return View("IndexAuthor", vm);

                default:
                    HttpContext.Response.Cookies.Append("lastSort", "Newest first");
                    vm.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == _authorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
                    return View("IndexAuthor", vm);

            }

        }
        }
    }

