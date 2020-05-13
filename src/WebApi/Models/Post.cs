using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int[] Visitors {get;set;}

        [Column(TypeName = "jsonb")]
        public Company Companies {get;set;}
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Company
    {
        public string Title { get; set; }
        public Company[] Children { get; set; }
    }

}