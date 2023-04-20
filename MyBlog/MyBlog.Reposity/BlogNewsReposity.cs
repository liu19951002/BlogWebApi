using MyBlog.IReposity;
using MyBlog.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Reposity
{
    public class BlogNewsReposity:BaseReposity<BlogNews>,IBlogNewsReposity
    {
        public async override Task<List<BlogNews>> QuerydAsync()
        {
            return await base.Context.Queryable<BlogNews>()
                .Mapper(c=>c.TypeInfo,c=>c.TypeId,c=>c.TypeInfo.Id)
                .Mapper(c=>c.WriterInfo,c=>c.WriterId,c=>c.WriterInfo.Id)
                .ToListAsync();
        }
        public  async override Task<List<BlogNews>> QuerydAsync(Expression<Func<BlogNews, bool>> func)
        {
            return await base.Context.Queryable<BlogNews>()
                .Where(func)    
                .Mapper(c => c.TypeInfo, c => c.TypeId, c => c.TypeInfo.Id)
                .Mapper(c => c.WriterInfo, c => c.WriterId, c => c.WriterInfo.Id)
                .ToListAsync();
        }
        public  override async Task<List<BlogNews>> QuerydAsync(Expression<Func<BlogNews, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<BlogNews>()
               .Where(func)
               .Mapper(c => c.TypeInfo, c => c.TypeId, c => c.TypeInfo.Id)
               .Mapper(c => c.WriterInfo, c => c.WriterId, c => c.WriterInfo.Id)
               .ToPageListAsync(page,size,total);
        }

        public async override Task<List<BlogNews>> QuerydAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<BlogNews>()
                 .Mapper(c => c.TypeInfo, c => c.TypeId, c => c.TypeInfo.Id)
               .Mapper(c => c.WriterInfo, c => c.WriterId, c => c.WriterInfo.Id)
                .ToPageListAsync(page, size, total);
        }
    }
}
