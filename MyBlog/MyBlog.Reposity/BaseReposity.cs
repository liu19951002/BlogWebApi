using MyBlog.IReposity;
using MyBlog.Model;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Reposity
{
    public class BaseReposity<T> :SimpleClient<T>, IBaseReposity<T> where T : class ,new()
    {
        public BaseReposity(ISqlSugarClient context=null):base(context)
        {
            base.Context= DbScoped.Sugar;
            //创建数据库
            //base.Context.DbMaintenance.CreateDatabase();
            ////创建表
            //base.Context.CodeFirst.InitTables(
            //    typeof(BlogNews),
            //    typeof(TypeInfo),
            //    typeof(WriterInfo)
            //    );
        }
        public async Task<bool> CreateAsync(T item)
        {
            return await base.InsertAsync(item);   
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public async Task<bool> EditorAsync(T item)
        {
            return await base.UpdateAsync(item);
        }

        public virtual async Task<T> FindAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> func)
        {
            return await base.GetSingleAsync(func);
        }

        public virtual async Task<List<T>> QuerydAsync(System.Linq.Expressions.Expression<Func<T, bool>> func)
        {
            return await base.GetListAsync(func);
        }

        public virtual async Task<List<T>> QuerydAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<T>().ToPageListAsync(page, size, total);
        }

        public  virtual async Task<List<T>> QuerydAsync(System.Linq.Expressions.Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<T>().Where(func).ToPageListAsync(page, size, total);
        }

        public virtual async Task<List<T>> QuerydAsync()
        {
            return await base.GetListAsync();
        }
    }
}
