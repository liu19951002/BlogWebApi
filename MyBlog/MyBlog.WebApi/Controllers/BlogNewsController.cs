using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;

namespace MyBlog.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBogNewsService;
        public BlogNewsController(IBlogNewsService iBlogNewsService) { 
            _iBogNewsService= iBlogNewsService;
        }

        [HttpGet("GetBlogNews")]
        public async Task<ActionResult> GetBlogNews()
        {
            var data = await _iBogNewsService.QuerydAsync();
            return Ok(data);
        }
    }
}
