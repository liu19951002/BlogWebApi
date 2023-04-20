using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyBlog.IReposity;
using MyBlog.IService;
using MyBlog.Reposity;
using MyBlog.Service;
using MyBlog.WebApi.Utiliy.AutoMapper;
using SqlSugar;
using SqlSugar.IOC;
using System.Runtime.CompilerServices;
using System.Text;

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
            //swagger ʹ�ü�Ȩ���
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyBlog.WebApi", Version = "v1" });

                #region Swaggerʹ�ü�Ȩ���
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                         new OpenApiSecurityScheme
                         {
                            Reference=new OpenApiReference
                                {
                                     Type=ReferenceType.SecurityScheme,
                                        Id="Bearer"
                                }
                           },
                        new string[] {}
                         }
                    });
                #endregion
            });
          
           
            
            //SqlSugarIOC
            builder.Services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = builder.Configuration["SqlConnectString"],
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true
            });
            //IOCע��
            builder.Services.AddCustomIOC();
            //JWT��Ȩ
            builder.Services.AddCustomJwt();

            builder.Services.AddAutoMapper(typeof(CustomAutoMapperProfile));
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //JWT��Ȩ
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        
    }
    /// <summary>
    /// ����ע����չ��
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

        public static IServiceCollection AddCustomJwt(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSTA-SADHJVF-VF")),
                        ValidateIssuer = true,
                        ValidIssuer = "http://localhost:6060",
                        ValidateAudience = true,
                        ValidAudience = "http://localhost:5000",
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(60)
                    };
                }
                );
            return services;
        }
    }
}