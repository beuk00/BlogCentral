using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
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

        public SearchController(BlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string searchString)
        {
            //if (String.IsNullOrEmpty(searchString))
            //{
            //    searchString = "";
            //}
            //searchString = searchString.ToLower();
            //List<BlogPost> allBlogPosts = (List<BlogPost>)await _blogPostRepository.ListAll();
            //List<BlogPost> searchedBlogPosts = new List<BlogPost>();

            //foreach (var blogPost in allBlogPosts)
            //{
            //    string tepmTitle = blogPost.Title;
            //    blogPost.Title = blogPost.Title.ToLower();
            //    if (!String.IsNullOrEmpty(searchString) && blogPost.Title.Contains(searchString))
            //    {
            //        blogPost.Title = tepmTitle;
            //        searchedBlogPosts.Add(blogPost);
            //    }
            //}
            //foreach (var blogPost in allBlogPosts)
            //{
            //    string tepmAuthor = blogPost.Author.UserName;
            //    blogPost.Author.UserName = blogPost.Author.UserName.ToLower();
            //    if (!String.IsNullOrEmpty(searchString) && blogPost.Author.UserName.Contains(searchString))
            //    {
            //        blogPost.Author.UserName = tepmAuthor;
            //        searchedBlogPosts.Add(blogPost);
            //    }
            //}

            //var uniqueItems = searchedBlogPosts.Distinct().ToList();

           var uniqueItems = _blogPostRepository.SearchAsync(searchString);


            HomePageViewModel vm = new HomePageViewModel();
            vm.BlogPosts = uniqueItems;
            vm.SearchString = searchString;
            return View("~/Views/SearchResults/SearchIndex.cshtml", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Sort(HomePageViewModel model)
        {
            HttpContext.Response.Cookies.Append("count", "6");

            //string CurrentURL = Request.Url.AbsoluteUri;
           
           

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


    }
}
