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
    public class TypeInfoService: BaseService<TypeInfo>,ITypeInfoService
    {
        private readonly ITypeInfoReposity _iTypeInfoReposity;
        public TypeInfoService(ITypeInfoReposity iTypeInfoReposity)
        {
            base._IBaseReposity = iTypeInfoReposity;
            _iTypeInfoReposity = iTypeInfoReposity;
        }
    }
}
