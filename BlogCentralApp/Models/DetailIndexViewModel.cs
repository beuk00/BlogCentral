using BlogCentralLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogCentralApp.Models
{
    public class DetailIndexViewModel
    {
        public BlogPost blogPost;
        public Author Author { get; set; }
        public int Views { get; set; }
        public int Visitors { get; set; }

        public bool hasLiked;
    }
}
