using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogCentralApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentRepository _commentRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentController(CommentRepository commentRepository, UserManager<IdentityUser> userManager)
        {
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        //[HttpGet("{id}/{id2}")]
        public async Task<IActionResult> CreateEditComment(int blogPostId, int commentId)
        {
                CreateEditCommentViewModel model = new CreateEditCommentViewModel();
            if (commentId != 0)
            {
                Comment comment = await _commentRepository.GetById(commentId);
                model.BlogpostId = comment.BlogpostId;
                model.AuthorId = comment.AuthorId;
                model.Content = comment.Content;
                model.CommentId = comment.Id;
                return View(model);
            }
            else
            {
                model.BlogpostId = blogPostId;
                model.CommentId = commentId;
            return View(model);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEditComment(CreateEditCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser _user = await _userManager.GetUserAsync(HttpContext.User);
                Comment comment = new Comment();
                comment.AuthorId = _user.Id;
                comment.BlogpostId = model.BlogpostId;
                comment.Content = model.Content;
                comment.Id = model.CommentId;

                if (model.CommentId == 0)
                {                  
                    await _commentRepository.Create(comment);
                }
                else
                {
                    await _commentRepository.Update(comment);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComment()
        {
            return View();
        }



    }
}
