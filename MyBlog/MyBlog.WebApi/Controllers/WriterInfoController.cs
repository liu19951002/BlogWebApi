using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.Model.DTO;
using MyBlog.Service;
using MyBlog.WebApi.Utiliy._MD5;
using MyBlog.WebApi.Utiliy.ApiResult;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WriterInfoController : ControllerBase
    {
        private readonly IWriterInfoService _writerInfoService;
        public WriterInfoController(IWriterInfoService writerInfoService) { 
            _writerInfoService= writerInfoService;
        }

        [HttpGet("GetWriters")]
        public async Task<ActionResult<ApiResult>> Get()
        {
            var data = await _writerInfoService.QuerydAsync();
            if (data.Count == 0) { return ApiResultHelper.Error("没有数据"); }
            return ApiResultHelper.Success(data);
        }

        [HttpPost("CreateWriter")]
        public async Task<ActionResult<ApiResult>> Create(string name,string username,string pwd)
        {
            if (string.IsNullOrEmpty(name)) { return ApiResultHelper.Error("类型名不能为空"); }
            WriterInfo writerInfo = new WriterInfo {
                Name = name,
                UserName = username,
                //加密密码
                UserPwd = MD5Helper.MD5Encrypt32(pwd)
            };
            //判断数据库中是否已经存在账号
            var oldWriter = await _writerInfoService.FindAsync(c => c.UserName == username);
            if (oldWriter != null) { return ApiResultHelper.Error("添加失败"); }
            bool b = await _writerInfoService.CreateAsync(writerInfo);
            if (b) { return ApiResultHelper.Success(writerInfo); }
            return ApiResultHelper.Error("添加失败");
        }

        [HttpPost("EditorWriterName")]
        public async Task<ActionResult<ApiResult>> Editor(string name)
        {
            int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
            var writer = await _writerInfoService.FindAsync(id);
            writer.Name = name;
            bool result =await _writerInfoService.EditorAsync(writer);
            //未写完的部分
            if (result) { return ApiResultHelper.Success(writer); }
            return ApiResultHelper.Error("失败");
        }
        [AllowAnonymous]
        [HttpGet("GetWriter")]
        public async Task<ActionResult<ApiResult>> GetWriter([FromServices] IMapper imapper, int id)
        {
            var writer = await _writerInfoService.FindAsync(id);
            var writerDTO = imapper.Map<WriterInfoDTO>(writer);
            if (writerDTO == null) { return ApiResultHelper.Error("没有数据"); }
            return ApiResultHelper.Success(writerDTO);
        }
    }
}
