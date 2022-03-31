using BlogCentralLib.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogCentralApp.Models
{
    public class CreateEditCommentViewModel
    {
        public int CommentId { get; set; }
        public int BlogpostId { get; set; }
        public string AuthorId { get; set; }

        public DateTime CreationDate { get; set; }

        [Display(Name = "Add new comment")]
        [Required(ErrorMessage = "Please write your comment!")]
        public string Content { get; set; }
        public Author Author { get; set; }
       
    }
}
