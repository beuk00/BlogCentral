using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public BlogDetailController(BlogPostRepository blogPostRepository, UserManager<IdentityUser> userManager)
        {
            _blogPostRepository = blogPostRepository;
            _userManager = userManager;
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
        [HttpGet]
        public async Task<ActionResult> PostDetail(int id)
        {
            DetailIndexViewModel vm=new DetailIndexViewModel();
            vm.blogPost = await _blogPostRepository.GetById(id);
           

            return View("Detail", vm);
        }

        [HttpGet]
        public async Task<ActionResult> CreateEditBlogpost(int? id)
         {
            if (id!=null)
            {
                var postFromDb =await  _blogPostRepository.GetById(id);
                CreateEditPost vm = new CreateEditPost()
                {
                    PostId = (int)id,
                    PostContent = postFromDb.Content,
                    PostTitle= postFromDb.Title,
                };
                return View("CreateEditPost",vm);
            }

           

            return View("CreateEditPost");
        }

       [HttpPost]
        public async Task<ActionResult> CreateEditBlogpost(CreateEditPost model)
        {
            if (ModelState.IsValid)
            {
                

                if (model.PostId==0)
                {
                    var _user = await _userManager.GetUserAsync(HttpContext.User);
                    BlogPost post = new BlogPost()
                    {
                       

                       AuthorId = _user.Id,
                        Content = model.PostContent,
                        Title = model.PostTitle,
                        Date = DateTime.Now,
                        Likes=0,
                    };
                   
                    await _blogPostRepository.Create(post);
                }
                else
                {
                   var postFromDb= await _blogPostRepository.GetById(model.PostId);
                    postFromDb.Content = model.PostContent; 
                    postFromDb.Title = model.PostTitle;
                    await _blogPostRepository.Update(postFromDb);
                }

                // to change later to Athor PageHome
                return RedirectToAction("Index","Home");

            }

           

            return View("CreateEditPost",model);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _blogPostRepository.DeleteById(id);
            return RedirectToAction("Index", "Home");
        }

    }
}
