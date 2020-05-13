using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }

        public List<Post> Posts { get; set; }
    }
}