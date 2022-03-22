using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
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



        public HomeController(BlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomePageViewModel vm = new HomePageViewModel();

            vm.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
            HttpContext.Response.Cookies.Append("count", "6");
            HttpContext.Response.Cookies.Append("lastSort", "Newest first");
            return View("index", vm);
        }



        public async Task<IActionResult> Detail(int id)
        {
            return RedirectToAction("IndexAsync", "BlogDetail", id);
        }

        //public async Task<IActionResult> GoToAuthorHomePage(string id)
        //{
        //    return View("AuthorPage",id);
        //}

        public async Task<IActionResult> Next10(HomePageViewModel model)
        {
            int countShow;
            int range = _blogPostRepository.GetAll().Count() - int.Parse(HttpContext.Request.Cookies["count"]);

            if (range <= 9 && range >= 1)
            {
                countShow = _blogPostRepository.GetAll().Count();
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
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);

                    return View("index", model);

                case "Most popular First":
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    return View("index", model);

                default:
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    return View("index", model);
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
                        model = new HomePageViewModel();
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        return View("index", model);

                    case "Most popular First":
                        model = new HomePageViewModel();
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        return View("index", model);

                    default:
                        model = new HomePageViewModel();
                        model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        return View("index", model);
                }
            }

        }

        public async Task<IActionResult> Last10(HomePageViewModel model)
        {

            HttpContext.Response.Cookies.Append("count", _blogPostRepository.GetAll().Count().ToString());

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().TakeLast(10);
                    return View("index", model);

                case "Most popular First":
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().TakeLast(10);
                    return View("index", model);

                default:
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().TakeLast(10);
                    return View("index", model);

            }
        }

        public async Task<IActionResult> First10(HomePageViewModel model)
        {

            HttpContext.Response.Cookies.Append("count", "10");

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(10);
                    return View("index", model);

                case "Most popular First":
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(10);
                    return View("index", model);

                default:
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(10);
                    return View("index", model);

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
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(6);
                    return View("index", model);

                case "Most popular First":
                    HttpContext.Response.Cookies.Append("lastSort", "Most popular First");
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(6);
                    return View("index", model);

                default:
                    HttpContext.Response.Cookies.Append("lastSort", "Newest first");
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);
                    return View("index", model);

            }
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
