using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
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
        private readonly AuthorRepository _authorRepository;
        private string lastSort;

        public HomeController(BlogPostRepository blogPostRepository, AuthorRepository authorRepository)
        {
            _blogPostRepository = blogPostRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IActionResult> Index()
        {
            HomePageViewModel vm = new HomePageViewModel();
            
            vm.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);

            return View("index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? sort, int count)
        {
            HomePageViewModel vm = new HomePageViewModel();

            string sortalgo = RouteData.Values["sort"]?.ToString();
            string counter = RouteData.Values["count"]?.ToString();
            count = count + 10;

            vm.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList().Take(6);

            return View("index", vm);
        }

            public async Task<IActionResult> GoToAuthorHomePage(string id)
        {
            return View("AuthorPage");
        }

        public async Task<IActionResult> Next10(HomePageViewModel model)
        {

            return View("index");
        }

        public async Task<IActionResult> Previous10(HomePageViewModel model)
        {
            return View("index");
        }

        public async Task<IActionResult> Last10(HomePageViewModel model)
        {
            switch (model.lastSort)
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
            switch (model.lastSort)
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
            switch (model.Sort)
            {
                case "Oldest first":
                    model.lastSort = "Oldest first";
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList().Take(6);
                    return View("index", model);

                case "Most popular First":
                    model.lastSort = "Most popular First";
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Likes).ToList().Take(6);
                    return View("index", model);

                default:
                    model.lastSort = "Newest first";
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
