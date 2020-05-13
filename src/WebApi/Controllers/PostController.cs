using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : ControllerBase
    {
        public BloggingContext _context { get; }
        public PostController(BloggingContext context)
        {
            this._context = context;

        }

        [HttpPost]
        public async Task<IActionResult> Add(PostDto dto)
        {
            var entity = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                Visitors = dto.Visitors,
                BlogId = dto.BlogId
            };

            await _context.Posts.AddAsync(entity);
            var result = await _context.SaveChangesAsync();

            return new JsonResult(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetByVisitor(int visitorId)
        {
            var result = await _context.Posts
                .Where(q => q.Visitors.Contains(visitorId))
                .Select(s => new 
                {
                    s.PostId,
                    s.Title
                })
                .ToListAsync();

            return new JsonResult(result);
        }
    }

    public class PostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int[] Visitors {get;set;}

        public int BlogId { get; set; }
    }
}