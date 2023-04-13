using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.WebApi.Utiliy.ApiResult;

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
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        {
            var data = await _iBogNewsService.QuerydAsync();
            if(data == null) { return ApiResultHelper.Error("读取失败"); }
            return ApiResultHelper.Success(data);
        }
        /// <summary>
        /// 添加文章标题和内容
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost("CreateBlogNew")]
        public async Task<ActionResult<ApiResult>> Create(string title,string content,int typeId)
        {
            if(title== null || content == null)
            {
                return ApiResultHelper.Error("读取失败");
            }
            BlogNews bolgNews = new BlogNews {
                BrowseCount = 0,
                Content = content,
                Title = title,
                Time = DateTime.Now,
                LikeCount = 0,
                TypeId = typeId,
                WriterId = 1
            };
            bool b=await _iBogNewsService.CreateAsync(bolgNews);
            if (b)
            {
                return ApiResultHelper.Success(bolgNews);
            }
            else
            {
                
                return ApiResultHelper.Error("添加失败");
            }
        }

        [HttpDelete("DeleteBlogNew")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b=await _iBogNewsService.DeleteAsync(id);
            if(!b) { return ApiResultHelper.Error("删除失败"); }
            return ApiResultHelper.Success(b);
        }
        [HttpPut("EditorBlogNew")]
        public async Task<ActionResult<ApiResult>> Editor(int id,string title,string content,int typeid)
        {
            var blogNews = await _iBogNewsService.FindAsync(id);
            if(blogNews==null) return ApiResultHelper.Error("需要修改的博客不存在");
            blogNews.Title=title;   
            blogNews.Content=content;
            blogNews.TypeId=typeid; 
            bool b=await _iBogNewsService.EditorAsync(blogNews);
            if (b)
            {
                return ApiResultHelper.Success(blogNews);
            }
            return ApiResultHelper.Error("修改失败");
        }
    }
}
