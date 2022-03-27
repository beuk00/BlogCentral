using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogCentralLib.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
  
        public int? BlogpostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public string? AuthorId { get; set; }
        public Author Author { get; set; }

        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
