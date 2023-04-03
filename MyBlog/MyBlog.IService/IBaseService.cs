using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.IService
{
    public interface IBaseService<T> where T : class ,new()
    {
        Task<bool> CreateAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<bool> EditorAsync(T item);
        Task<T> FindAsync(int id);
        Task<List<T>> QuerydAsync();
        /// <summary>
        /// 自定义条件查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<List<T>> QuerydAsync(Expression<Func<T, bool>> func);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<T>> QuerydAsync(int page, int size, RefAsync<int> total);
        /// <summary>
        /// 自定义条件分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<T>> QuerydAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total);
    }
}
