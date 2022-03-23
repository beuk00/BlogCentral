using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCentralLib.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int  BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public string AuthorId { get; set; }
        public Author Author { get; set; }  


    }
}
