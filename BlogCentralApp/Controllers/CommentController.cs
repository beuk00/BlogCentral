using BlogCentralApp.Models;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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


        [Authorize]
        public async Task<IActionResult> CreateEditComment(int blogPostId, int commentId)
        {
            CreateEditCommentViewModel model = new CreateEditCommentViewModel();
            if (commentId != 0)
            {
                Comment comment = await _commentRepository.GetById(commentId);
                model.BlogpostId = (int)comment.BlogpostId;
                model.AuthorId = comment.AuthorId;
                model.Content = comment.Content;
                model.CommentId = comment.Id;
                model.CreationDate = comment.CreationDate;
                return View(model);
            }
            else
            {
                model.BlogpostId = blogPostId;

                return View(model);
            }
        }

        [Authorize]
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
                comment.CreationDate = model.CreationDate;

                if (model.CommentId == 0)
                {
                    comment.CreationDate = DateTime.Now;
                    await _commentRepository.Create(comment);
                    TempData["success"] = "Comment created!";
                }
                else
                {
                    await _commentRepository.Update(comment);
                    TempData["success"] = "Comment updated!";
                }
                return RedirectToAction("Index", "BlogDetail", new { id = comment.BlogpostId });

            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id, int blogPostId)
        {
            await _commentRepository.DeleteById(id);
            TempData["success"] = "Comment deleted!";
            return RedirectToAction("Index", "BlogDetail", new { id = blogPostId });
        }



    }
}
