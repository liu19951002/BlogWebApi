using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("NoAuthorize")]
        public string NoAuthrize()
        {
            return "this is no authrize";
        }

        [Authorize]
        [HttpGet ("isAuthorize")]
        public string Authrize()
        {
            return "this is  authrize";
        }
    }
}
