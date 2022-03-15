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
            
            DetailIndexViewModel vm = new DetailIndexViewModel();
            vm.blogPost = await _blogPostRepository.GetById(id);

            return View("Detail", vm);
        }
    }
}
