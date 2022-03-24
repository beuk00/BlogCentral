using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogCentralLib.Entities
{
    public class Author : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? StreetName { get; set; }
        public int? HouseNumber { get; set; }
        public string? CityName { get; set; }
        public int? ZipCode { get; set; }
        public string ImageUrl { get; set; }
       public IEnumerable<BlogPost> Posts { get; set; }
        public IEnumerable<Like> Likes { get; set; }

    }
}
