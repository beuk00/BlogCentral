using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCentralLib.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog Blog { get; set; }
    }
}
