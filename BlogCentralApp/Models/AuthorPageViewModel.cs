using BlogCentralLib.Entities;
using System.Collections.Generic;

namespace BlogCentralApp.Models
{
    public class AuthorPageViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }

        public Author Author { get; set; }
    }
}
