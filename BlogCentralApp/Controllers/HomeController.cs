using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly BlogPostRepository _blogPostRepository;


        private readonly SignInManager<IdentityUser> _signManager;

        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(BlogPostRepository blogPostRepository, SignInManager<IdentityUser> signInManager,UserManager<IdentityUser>userManager)
        {
            _blogPostRepository = blogPostRepository;
            _signManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            HomePageViewModel vm = new HomePageViewModel();


            vm.StartOfSelection = true;
            vm.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
            HttpContext.Response.Cookies.Append("count", "6");
            HttpContext.Response.Cookies.Append("lastSort", "Newest first");
            if (_signManager.IsSignedIn(User)){
                vm.Author= (Author) await _userManager.GetUserAsync(User);
            }
            return View("index", vm);
        }



        public async Task<IActionResult> Detail(int id)
        {
            return RedirectToAction("IndexAsync", "BlogDetail", id);
        }

        public async Task<IActionResult> Next10(HomePageViewModel model)
        {
            model = new HomePageViewModel();
            int countShow;
            int range = _blogPostRepository.GetAll().Count() - int.Parse(HttpContext.Request.Cookies["count"]);
            model.StartOfSelection = false;

            if (range <= 9 )
            {
                countShow = _blogPostRepository.GetAll().Count();
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
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                        break;

                    case "Most popular First":
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                        break;

                    default:
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                        break;
            }
            if (_signManager.IsSignedIn(User))
            {
                model.Author = (Author)await _userManager.GetUserAsync(User);
            }

            return View("index", model);
        }

        public async Task<IActionResult> Previous10(HomePageViewModel model)
        {
            model = new HomePageViewModel();
            int range = int.Parse(HttpContext.Request.Cookies["count"]) - 10;
            model.EndOfSelection = false;

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
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        break;

                    case "Most popular First":
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        break;

                    default:
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        break;
                }
                if (_signManager.IsSignedIn(User))
                {
                    model.Author = (Author)await _userManager.GetUserAsync(User);
                }

                return View("index", model);
            }
        }

        public async Task<IActionResult> Last10(HomePageViewModel model)
        {

            model = new HomePageViewModel();
            HttpContext.Response.Cookies.Append("count", _blogPostRepository.GetAll().Count().ToString());
            model.EndOfSelection = true;
            model.StartOfSelection = false;

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().TakeLast(10);
                    break;

                case "Most popular First":
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().TakeLast(10);
                    break;

                default:
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().TakeLast(10);
                    break;
            }
            if (_signManager.IsSignedIn(User))
            {
                model.Author = (Author)await _userManager.GetUserAsync(User);
            }

            return View("index", model);
        }

        public async Task<IActionResult> First10(HomePageViewModel model)
        {

            model = new HomePageViewModel();
            HttpContext.Response.Cookies.Append("count", "10");
            model.EndOfSelection = false;
            model.StartOfSelection = true;

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(10);
                    break;

                case "Most popular First":
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(10);
                    break;

                default:
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(10);
                    break;
            }
            if (_signManager.IsSignedIn(User))
            {
                model.Author = (Author)await _userManager.GetUserAsync(User);
            }
            return View("index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Sort(HomePageViewModel model)
        {
            model = new HomePageViewModel();
            HttpContext.Response.Cookies.Append("count", "6");

            model.EndOfSelection = false;
            model.StartOfSelection = true;

            switch (model.Sort)
            {
                case "Oldest first":
                    HttpContext.Response.Cookies.Append("lastSort", "Oldest first");
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(6);
                    break;

                case "Most popular First":
                    HttpContext.Response.Cookies.Append("lastSort", "Most popular First");
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(6);
                    break;

                default:
                    HttpContext.Response.Cookies.Append("lastSort", "Newest first");
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
                    break;
            }
            if (_signManager.IsSignedIn(User))
            {
                model.Author = (Author)await _userManager.GetUserAsync(User);
            }

            return View("index", model);
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

    }
}
