using MyBlog.IReposity;
using MyBlog.IService;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class BlogNewsService:BaseService<BlogNews>,IBlogNewsService
    {
        private readonly IBlogNewsReposity _iBlogNewsReposity;
        public BlogNewsService(IBlogNewsReposity iNewsReposity)
        {
            base._IBaseReposity = iNewsReposity;
            _iBlogNewsReposity = iNewsReposity;
        }
    }
}
