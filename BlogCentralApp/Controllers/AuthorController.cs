using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BlogPostRepository _blogPostRepository;
        private readonly UserManager<IdentityUser> _userManager;
       
        private readonly AuthorRepository _authorRepository;
        public AuthorController(BlogPostRepository blogPostRepository, UserManager<IdentityUser> userManager, AuthorRepository authorRepository)

        {
            _blogPostRepository = blogPostRepository;
            _userManager = userManager; 
           
            _authorRepository = authorRepository;
        }

       
        [HttpGet]
        public async Task<IActionResult> Index1(string id)
        {
           

            await _authorRepository.AddView(id);


            HomePageViewModel vm = new HomePageViewModel();

            if (id!=null)
            {
               vm.AuthorId = id;
               HttpContext.Response.Cookies.Append("id", id);

            }

            int countShow = _blogPostRepository.GetAll().Where(a => a.AuthorId == vm.AuthorId).Count();

            if (countShow <= 6)
            {
                HttpContext.Response.Cookies.Append("count", countShow.ToString());
                vm.EndOfSelection = true;
            }
            else
            {
                HttpContext.Response.Cookies.Append("count", "6");
                vm.EndOfSelection = false;
            }

            vm.StartOfSelection = true;
          vm.SignedInAuthor =(Author)await _userManager.GetUserAsync(User);
            // var user  = await _userManager.GetUserAsync(HttpContext.User);

            vm.Author = (Author)await _userManager.FindByIdAsync(vm.AuthorId);
            vm.BlogPosts = _blogPostRepository.GetAll().Where(a=>a.AuthorId== vm.AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
            
            HttpContext.Response.Cookies.Append("lastSort", "Newest first");
           

            return View("IndexAuthor", vm);
        }

        public async Task<IActionResult> Next10(HomePageViewModel model)
        {
            model = new HomePageViewModel();
            model.AuthorId = HttpContext.Request.Cookies["id"];
            model.Author = (Author)await _userManager.FindByIdAsync(model.AuthorId);
            model.SignedInAuthor = (Author)await _userManager.GetUserAsync(User);
            model.StartOfSelection = false;

            int countShow;
            int range = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Count() - int.Parse(HttpContext.Request.Cookies["count"]);

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
                    model.EndOfSelection = false;
                    model.AuthorId = HttpContext.Request.Cookies["id"];
                    model.Author = (Author)await _userManager.FindByIdAsync(model.AuthorId);
                    model.SignedInAuthor = (Author)await _userManager.GetUserAsync(User);

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

            int countShow = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Count();

            HttpContext.Response.Cookies.Append("count", countShow.ToString());

            if (countShow <= 10)
            {
                model.StartOfSelection = true;
            }
            else
            {
                model.StartOfSelection = false;
            }

            model.EndOfSelection = true;
            model.AuthorId = HttpContext.Request.Cookies["id"];
            model.Author = (Author)await _userManager.FindByIdAsync(model.AuthorId);
            model.SignedInAuthor = (Author)await _userManager.GetUserAsync(User);

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
            int countShow = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Count();

            model = new HomePageViewModel();
            model.StartOfSelection = true;
            model.AuthorId = HttpContext.Request.Cookies["id"];
            model.Author = (Author)await _userManager.FindByIdAsync(model.AuthorId);
            model.SignedInAuthor = (Author)await _userManager.GetUserAsync(User);
            if (countShow <= 10)
            {
                HttpContext.Response.Cookies.Append("count", countShow.ToString());
                model.EndOfSelection = true;
            }
            else
            {
                HttpContext.Response.Cookies.Append("count", "10");
                model.EndOfSelection = false;
            }

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

            
            string AuthorId = HttpContext.Request.Cookies["id"];
            int countShow = _blogPostRepository.GetAll().Where(a => a.AuthorId == model.AuthorId).Count();

            switch (model.Sort)
            {
                case "Oldest first":
                    HttpContext.Response.Cookies.Append("lastSort", "Oldest first");
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == AuthorId).Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(6);
                    break;

                case "Most popular First":
                    HttpContext.Response.Cookies.Append("lastSort", "Most popular First");
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(6);
                    break;

                default:
                    HttpContext.Response.Cookies.Append("lastSort", "Newest first");
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Where(a => a.AuthorId == AuthorId).Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
                    break;
            }

            if (countShow <= 6)
            {
                HttpContext.Response.Cookies.Append("count", countShow.ToString());
                model.EndOfSelection = true;
            }
            else
            {
                HttpContext.Response.Cookies.Append("count", "6");
                model.EndOfSelection = false;
            }
            
            model.StartOfSelection = true;
            model.Author = (Author)await _userManager.FindByIdAsync(AuthorId);
            model.SignedInAuthor = (Author)await _userManager.GetUserAsync(User);


            return View("IndexAuthor", model);
        }
    }
}

