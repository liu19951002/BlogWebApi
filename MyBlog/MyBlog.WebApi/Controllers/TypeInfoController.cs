using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.WebApi.Utiliy.ApiResult;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeInfoController : ControllerBase
    {
        private readonly ITypeInfoService _typeInfoService;
        public TypeInfoController(ITypeInfoService typeInfoService)
        {
            _typeInfoService= typeInfoService;
        }
        [HttpGet("GetTypes")]
        public async Task<ActionResult<ApiResult>> Get() {
            var data=await _typeInfoService.QuerydAsync();
            if(data.Count==0) { return ApiResultHelper.Error("没有数据"); }
            return ApiResultHelper.Success(data);
        }
        [HttpPost("CreateType")]
        public async Task<ActionResult<ApiResult>> Create( string name)
        {
            if (string.IsNullOrEmpty(name)) { return ApiResultHelper.Error("类型名不能为空"); }
            TypeInfo typeInfo=new TypeInfo { Name = name };
            bool b = await _typeInfoService.CreateAsync(typeInfo);
            if(b) { return ApiResultHelper.Success(typeInfo); }
            return ApiResultHelper.Error("添加失败");   
        }
        [HttpDelete("DeleteType")]
        public async Task<ActionResult<ApiResult>> Delete(int typeId)
        {
            bool b = await _typeInfoService.DeleteAsync(typeId);
            if (b) { return ApiResultHelper.Success(b); }
            return ApiResultHelper.Error("删除失败");
        }
        [HttpPost("EditorType")]
        public async Task<ActionResult<ApiResult>> Editor(int typeId,string name)
        {
            var type= await _typeInfoService.FindAsync(typeId); 
            if (type == null) { return ApiResultHelper.Error("查找内容不存在"); }
            type.Name = name;      
            bool b = await _typeInfoService.EditorAsync(type);
            if (b) { return ApiResultHelper.Success(type); }
            return ApiResultHelper.Error("修改失败");
        }
    }
}
