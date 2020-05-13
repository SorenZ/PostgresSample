using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BlogController : ControllerBase
    {
        public BloggingContext _context { get; }
        public BlogController(BloggingContext context)
        {
            this._context = context;

        }

        [HttpPost]
        public async Task<IActionResult> Add(string url)
        {
            Blog entity = new Blog
            {
                Url = url,
                CreateDate = DateTime.Now
            };
            await _context.Blogs.AddAsync(entity);
            var result = await _context.SaveChangesAsync();

            return new JsonResult(entity);
        }
    }
}
