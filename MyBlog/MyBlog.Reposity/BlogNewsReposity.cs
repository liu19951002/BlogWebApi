using MyBlog.IReposity;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Reposity
{
    public class BlogNewsReposity:BaseReposity<BlogNews>,INewsReposity
    {
    }
}
