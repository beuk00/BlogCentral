using System.ComponentModel.DataAnnotations;

namespace BlogCentralApp.Models
{
    public class AddCommentViewModel
    {
        [Required]
        public int BlogpostId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
