using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCentralLib.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Author Author { get; set; }
        public string AuthorId { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}
