using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly BlogPostRepository _blogPostRepository;

        public BlogDetailController(BlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(int id)
        {
            id = 1;
            DetailIndexViewModel vm = new DetailIndexViewModel();
       
            vm.blogPost = await _blogPostRepository.GetById(id);
          

            return View("Detail", vm);
        }
        [HttpGet]
        public async Task<ActionResult> LikeAsync(int id, DetailIndexViewModel vm)
        {


            vm.hasLiked = true;
            vm.blogPost = await _blogPostRepository.GetById(id);
            await _blogPostRepository.Like(id);

            return View("Detail", vm);
        }
        [HttpGet]
        public async Task<ActionResult> UnlikeAsync(int id, DetailIndexViewModel vm)
        {


            vm.hasLiked = false;
            vm.blogPost = await _blogPostRepository.GetById(id);
            await _blogPostRepository.Unlike(id);

            return View("Detail", vm);
        }
    }
}
