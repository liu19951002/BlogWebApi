using SqlSugar;

namespace MyBlog.WebApi.Utiliy.ApiResult
{
    public class ApiResultHelper
    {
       public static ApiResult Success( dynamic data)
        {
            return new ApiResult {
                Code = 200,
                Data = data,
                Message = "Success",
                Total=0
            };
        }
        public static ApiResult Success(dynamic data,RefAsync<int> total)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Message = "Success",
                Total = total
            };
        }

        public static ApiResult Error(string msg)
        {
            return new ApiResult
            {
                Code = 500,
                Data = null,
                Message = msg,
                Total = 0
            };
        }
    }
}
