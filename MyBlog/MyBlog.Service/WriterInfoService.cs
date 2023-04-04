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
    public class WriterInfoService:BaseService<WriterInfo>,IWriterInfoService
    {
        private readonly IWriterInfoReposity _iWriterInfoReposity;
        public WriterInfoService(IWriterInfoReposity iWriterInfoReposity)
        {
            base._IBaseReposity = iWriterInfoReposity;  
            _iWriterInfoReposity=iWriterInfoReposity;   
        }
    }
}
