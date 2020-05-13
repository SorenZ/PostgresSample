using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext (DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    
    }
}