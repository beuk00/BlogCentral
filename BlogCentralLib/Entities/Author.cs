using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCentralLib.Entities
{
    public class Author : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public int? HouseNumber { get; set; }
        public string CityName { get; set; }
        public int ZipCode { get; set; }

        

    }
}
