using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IService;
using MyBlog.JWT.Utiliy._MD5;
using MyBlog.JWT.Utiliy.ApiResult;
using MyBlog.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MyBlog.JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoizeController : ControllerBase
    {
        private readonly IWriterInfoService _writerInfoService;

        public AuthoizeController(IWriterInfoService writerInfoService)
        {
            _writerInfoService= writerInfoService;
        }

        [HttpPost("Login")]
        public async Task<ApiResult> Login(string userName,string passWord)
        {
            string md5Enceypy32 = MD5Helper.MD5Encrypt32(passWord);
            var data = await _writerInfoService.FindAsync(c=>c.UserName == userName&&c.UserPwd==md5Enceypy32);
            if (data == null)
            {
                return ApiResultHelper.Error("登录失败");
            }
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,data.Name),
                new Claim("Id",data.Id.ToString()),
                new Claim("UserName",data.UserName)
            };
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSTA-SADHJVF-VF"));
            var token = new JwtSecurityToken(
                issuer: "http://localhost:6060",
                audience: "http://localhost:5000",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
                );    
            var jwtToken=new JwtSecurityTokenHandler().WriteToken(token);
            return ApiResultHelper.Success(jwtToken);   
        }
    }
}
