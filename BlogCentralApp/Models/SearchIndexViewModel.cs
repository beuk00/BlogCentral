using BlogCentralLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Models
{
    public class SearchIndexViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }

    }
}
