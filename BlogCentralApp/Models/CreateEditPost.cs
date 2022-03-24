using BlogCentralLib.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogCentralApp.Models
{
    public class CreateEditPost
    {
        public int PostId { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string PostTitle { get; set; }
        [Display(Name = "Content")]

        //[AllowHTML]
        public string PostContent { get; set; }
        public string AuthorId { get; set; }

        public Author Author { get; set; }

    }
}
