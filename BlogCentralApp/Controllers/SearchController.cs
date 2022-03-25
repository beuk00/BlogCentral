using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class SearchController : Controller
    {

        private readonly BlogPostRepository _blogPostRepository;
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly UserManager<IdentityUser> _userManager;

        public SearchController(BlogPostRepository blogPostRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _blogPostRepository = blogPostRepository;
            _signManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string searchString)
        {
            var uniqueItems = _blogPostRepository.SearchAsync(searchString);

            HomePageViewModel vm = new HomePageViewModel();
            vm.BlogPosts = uniqueItems;
            vm.SearchString = searchString;
            vm.EndOfSelection = true;
            vm.StartOfSelection = true;
            if (_signManager.IsSignedIn(User))
            {
                vm.Author = (Author)await _userManager.GetUserAsync(User);
            }
            return RedirectToAction("First10", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Sort(HomePageViewModel model)
        {
            HttpContext.Response.Cookies.Append("count", "6");

            switch (model.Sort)
            {
                case "Oldest first":
                    HttpContext.Response.Cookies.Append("lastSort", "Oldest first");
                    var uniqueItems1 = _blogPostRepository.SearchAsync(model.SearchString).OrderBy(x => x.Date).ToList().Take(6);
                    HomePageViewModel vm1 = new HomePageViewModel();
                    vm1.BlogPosts = uniqueItems1;
                    vm1.SearchString = model.SearchString;

                    return View("~/Views/SearchResults/SearchIndex.cshtml", vm1);

                case "Most popular First":
                    HttpContext.Response.Cookies.Append("lastSort", "Most popular First");
                    var uniqueItems2 = _blogPostRepository.SearchAsync(model.SearchString).OrderByDescending(x => x.Likes).ToList().Take(6);
                    HomePageViewModel vm2 = new HomePageViewModel();
                    vm2.BlogPosts = uniqueItems2;
                    vm2.SearchString = model.SearchString;

                    return View("~/Views/SearchResults/SearchIndex.cshtml", vm2);

                default:
                    HttpContext.Response.Cookies.Append("lastSort", "Newest first");
                    var uniqueItems3 = _blogPostRepository.SearchAsync(model.SearchString).OrderByDescending(x => x.Date).ToList().Take(6);
                    HomePageViewModel vm3 = new HomePageViewModel();
                    vm3.BlogPosts = uniqueItems3;
                    vm3.SearchString = model.SearchString;
                    return View("~/Views/SearchResults/SearchIndex.cshtml", vm3);

            }
        }
        public async Task<IActionResult> Last10(HomePageViewModel model)
        {
            string searchSring = model.SearchString;
            model = new HomePageViewModel();
            model.EndOfSelection = true;
            model.SearchString = searchSring;
           
            IEnumerable<BlogPost> uniqueItems = new List<BlogPost>();

            int countShow = _blogPostRepository.SearchAsync(model.SearchString).Count();

            HttpContext.Response.Cookies.Append("count", countShow.ToString());

            if (countShow <= 10)
            {
                model.StartOfSelection = true;
            }
            else
            {
                model.StartOfSelection = false;
            }
            HomePageViewModel vm = new HomePageViewModel();
            vm.StartOfSelection = model.StartOfSelection;
            vm.EndOfSelection = model.EndOfSelection;

            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    HttpContext.Response.Cookies.Append("lastSort", "Oldest first");
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).OrderBy(x => x.Date).ToList().TakeLast(10);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;
                case "Most popular First":
                    HttpContext.Response.Cookies.Append("lastSort", "Most popular First");
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).OrderByDescending(x => x.Likes).ToList().TakeLast(10);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;
                    

                default:
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).OrderByDescending(x => x.Date).ToList().TakeLast(10);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;
            }
            if (_signManager.IsSignedIn(User))
            {
                vm.Author = (Author)await _userManager.GetUserAsync(User);
            }

            return View("~/Views/SearchResults/SearchIndex.cshtml", vm);
        }

        public async Task<IActionResult> First10(HomePageViewModel model)
        {

            string searchSring = model.SearchString;
            model = new HomePageViewModel();
            model.StartOfSelection = true;
            model.SearchString = searchSring;
            
            HomePageViewModel vm = new HomePageViewModel();
            

            IEnumerable<BlogPost> uniqueItems = new List<BlogPost>();

            int countShow = _blogPostRepository.SearchAsync(model.SearchString).Count();

            HttpContext.Response.Cookies.Append("count", "10");

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
            vm.EndOfSelection = vm.EndOfSelection;
            vm.StartOfSelection = model.StartOfSelection;
            switch (HttpContext.Request.Cookies["lastSort"])
            {
                case "Oldest first":
                    HttpContext.Response.Cookies.Append("lastSort", "Oldest first");
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).OrderBy(x => x.Date).ToList().Take(10);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;

                case "Most popular First":
                    HttpContext.Response.Cookies.Append("lastSort", "Most popular First");
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).OrderByDescending(x => x.Likes).ToList().Take(10);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;

                default:
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).OrderByDescending(x => x.Date).ToList().Take(10);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;
            }
            if (_signManager.IsSignedIn(User))
            {
                vm.Author = (Author)await _userManager.GetUserAsync(User);
            }
            return View("~/Views/SearchResults/SearchIndex.cshtml", vm);
        }
        public async Task<IActionResult> Previous10(HomePageViewModel model)
        {
            string searchSring = model.SearchString;
            model = new HomePageViewModel();
            
            model.SearchString = searchSring;
            model.EndOfSelection = false;
            HomePageViewModel vm = new HomePageViewModel();
            vm.StartOfSelection = model.StartOfSelection;
            vm.EndOfSelection = model.EndOfSelection;
            IEnumerable<BlogPost> uniqueItems = new List<BlogPost>();

            int range = int.Parse(HttpContext.Request.Cookies["count"]) - 10;

            if (range <= 11)
            {
                return RedirectToAction("First10", model);
            }
            else
            {
                HttpContext.Response.Cookies.Append("count", range.ToString());

                switch (HttpContext.Request.Cookies["lastSort"])
                {
                    case "Oldest first":
                        uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        vm.BlogPosts = uniqueItems;
                        vm.SearchString = model.SearchString;
                        break;

                    case "Most popular First":
                        uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        vm.BlogPosts = uniqueItems;
                        vm.SearchString = model.SearchString;
                        break;

                    default:
                        uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]) - 20, 10);
                        vm.BlogPosts = uniqueItems;
                        vm.SearchString = model.SearchString;
                        break;
                }
                if (_signManager.IsSignedIn(User))
                {
                    vm.Author = (Author)await _userManager.GetUserAsync(User);
                }

                return View("~/Views/SearchResults/SearchIndex.cshtml", model);
            }

        }
        public async Task<IActionResult> Next10(HomePageViewModel model)
        {
            string searchSring = model.SearchString;
            model = new HomePageViewModel();
            model.StartOfSelection = false;
            model.SearchString = searchSring;
            
            HomePageViewModel vm = new HomePageViewModel();
            
            IEnumerable<BlogPost> uniqueItems = new List<BlogPost>();

            int countShow;
            int range = _blogPostRepository.SearchAsync(model.SearchString).Count() - int.Parse(HttpContext.Request.Cookies["count"]);

            if (range <= 9)
            {
                countShow = _blogPostRepository.SearchAsync(model.SearchString).Count();
                model.EndOfSelection = true;
            }
            else
            {

                range = 10;
                countShow = int.Parse(HttpContext.Request.Cookies["count"]) + 10;
                model.EndOfSelection = false;
            }
            vm.StartOfSelection = model.StartOfSelection;
            vm.EndOfSelection = model.EndOfSelection;

            HttpContext.Response.Cookies.Append("count", countShow.ToString());

            switch (HttpContext.Request.Cookies["lastSort"])
            {

                case "Oldest first":
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).ToList().OrderBy(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;

                case "Most popular First":
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).ToList().OrderByDescending(x => x.Likes).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;

                default:
                    uniqueItems = _blogPostRepository.SearchAsync(model.SearchString).ToList().OrderByDescending(x => x.Date).ToList().GetRange(int.Parse(HttpContext.Request.Cookies["count"]), range);
                    vm.BlogPosts = uniqueItems;
                    vm.SearchString = model.SearchString;
                    break;
            }
            if (_signManager.IsSignedIn(User))
            {
                vm.Author = (Author)await _userManager.GetUserAsync(User);
            }

            return View("~/Views/SearchResults/SearchIndex.cshtml", vm);
        }
    }
}
