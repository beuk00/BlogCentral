using BlogCentralLib.Entities;
using System.Collections.Generic;

namespace BlogCentralApp.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}
