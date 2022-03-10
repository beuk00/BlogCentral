using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlogCentralLib.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public string AuthorId { get; set; }
        [JsonIgnore]
        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}
