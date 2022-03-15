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
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly BlogPostRepository _blogPostRepository;
        private readonly AuthorRepository _authorRepository;
        public HomeController(BlogPostRepository blogPostRepository, AuthorRepository authorRepository)
        {
            _blogPostRepository = blogPostRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IActionResult> Index()
        {
            HomePageViewModel vm = new HomePageViewModel();
            //vm.BlogPosts = _blogPostRepository.GetAll().OrderBy(x => x.Date).ToList();
            vm.BlogPosts = (IEnumerable<BlogCentralLib.Entities.BlogPost>)_blogPostRepository.GetAll().Include(b => b.Author).ToList();
            //vm.BlogPosts = await _blogPostRepository.ListAll();
            //vm.Author = _authorRepository.GetById()
            return View("index", vm);
        }

        public async Task<IActionResult> GoToAuthorHomePage(string id)
        {
            return View("AuthorPage");
        }

        public async Task<IActionResult> Next10()
        {
            return View("index");
        }

        public async Task<IActionResult> Previous10()
        {
            return View("index");
        }

        public async Task<IActionResult> Last10()
        {
            return View("index");
        }

        public async Task<IActionResult> First10()
        {
            return View("index");
        }


        [HttpPost]
       public async Task<IActionResult> Sort(HomePageViewModel model)
        {
            switch (model.Sort)
            {
                case "Newest first":
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderByDescending(x => x.Date).ToList();
                    return View("index", model);
               
                case "Oldest first":
                    model = new HomePageViewModel();
                    model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.Date).ToList();
                    return View("index", model);

                case "Most popular First":
                    model = new HomePageViewModel();
                    //model.BlogPosts = _blogPostRepository.GetAll().Include(b => b.Author).ToList().OrderBy(x => x.likes).ToList();
                    return View("index", model);

                default:
                    return View("index");
                    
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
