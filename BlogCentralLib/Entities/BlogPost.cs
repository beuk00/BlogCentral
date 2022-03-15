using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogCentralLib.Entities
{
    public class BlogPost
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public string AuthorId { get; set; }
        public IdentityUser Author { get; set; }
    }
}
