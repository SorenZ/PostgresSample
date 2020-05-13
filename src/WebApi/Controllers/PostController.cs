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

        [HttpPost]
        public async Task<IActionResult> UpdateCompany(CompanyDto dto)
        {
            var entity = _context.Posts.First(q => q.PostId == dto.PostId);

            entity.Companies = dto.Companies;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Posts
                .ToListAsync();

            return new JsonResult(result);
        }

         [HttpGet]
        public async Task<IActionResult> GetByCompany(string title)
        {
            var result = await _context.Posts
                .Where(q => q.Companies.Title.Contains(title))
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

    public class CompanyDto
    {
        public int PostId { get; set; }
        public Company Companies {get;set;}

    }
}