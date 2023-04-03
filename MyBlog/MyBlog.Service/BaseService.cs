using MyBlog.IReposity;
using MyBlog.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        //从子类的构造函数中传入
        protected IBaseReposity<T> _IBaseReposity;

        public async Task<bool> CreateAsync(T item)
        {
            return await _IBaseReposity.CreateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _IBaseReposity.DeleteAsync(id); 
        }

        public async Task<bool> EditorAsync(T item)
        {
            return await _IBaseReposity.EditorAsync(item);  
        }

        public async Task<T> FindAsync(int id)
        {
            return await _IBaseReposity.FindAsync(id);  
        }

        public async Task<List<T>> QuerydAsync()
        {
            return await _IBaseReposity.QuerydAsync();   
        }

        public async Task<List<T>> QuerydAsync(Expression<Func<T, bool>> func)
        {
            return await _IBaseReposity.QuerydAsync(func);
        }

        public async Task<List<T>> QuerydAsync(int page, int size, RefAsync<int> total)
        {
            return await _IBaseReposity.QuerydAsync(page, size, total);
        }

        public async Task<List<T>> QuerydAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _IBaseReposity.QuerydAsync(func, page, size, total);
        }
    }
}
