using MyBlog.IReposity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Reposity
{
    public class BaseReposity<T> : IBaseReposity<T> where T : class ,new()
    {
        public Task<bool> CreateAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditorAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QuerydAsync(System.Linq.Expressions.Expression<Func<T, bool>> func)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QuerydAsync(int page, int size, RefAsync<int> total)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QuerydAsync(System.Linq.Expressions.Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
        {
            throw new NotImplementedException();
        }
    }
}
