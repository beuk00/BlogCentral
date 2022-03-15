 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogCentralLib.Entities
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string AuthorId { get; set; } 
        public Author Author { get; set; }
        public int Likes { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
