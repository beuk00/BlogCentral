using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BlogCentralApp.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }

        public Author Author { get; set; }

        public string Sort { get; set; }

        public bool EndOfSelection { get; set; }

        public bool StartOfSelection { get; set; }


        public IEnumerable<SelectListItem> SortSelections = new List<SelectListItem>() 
        { 
            new SelectListItem { Text= "Newest first", Value="Newest first" },
            new SelectListItem { Text= "Oldest first", Value="Oldest first" },
            new SelectListItem { Text= "Most popular First", Value="Most popular First" },
        };
    }
}
