using MyBlog.IReposity;
using MyBlog.IService;
using MyBlog.Reposity;
using MyBlog.Service;
using SqlSugar;
using SqlSugar.IOC;
using System.Runtime.CompilerServices;

namespace MyBlog.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //SqlSugarIOC
            builder.Services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = builder.Configuration["SqlConnectString"],
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true
            });
            //IOC注入
            builder.Services.AddCustomIOC();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        
    }
    /// <summary>
    /// 依赖注入拓展类
    /// </summary>
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IBlogNewsReposity, BlogNewsReposity>();
            services.AddScoped<IBlogNewsService, BlogNewsService>();
            services.AddScoped<ITypeInfoReposity, TypeInfoReposity>();
            services.AddScoped<ITypeInfoService, TypeInfoService>();
            services.AddScoped<IWriterInfoReposity, WriterInfoReposity>();
            services.AddScoped<IWriterInfoService, WriterInfoService>();
            return services;
        }
    }
}