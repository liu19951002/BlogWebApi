using MyBlog.IReposity;
using MyBlog.IService;
using MyBlog.Reposity;
using MyBlog.Service;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlSugar(new IocConfig()
{
    ConnectionString = builder.Configuration["SqlConnectString"],
    DbType = IocDbType.SqlServer,
    IsAutoCloseConnection = true
});

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


public static class IOCExtend
{
    public static IServiceCollection AddCustomIOC(this IServiceCollection services)
    {
        services.AddScoped<IWriterInfoReposity, WriterInfoReposity>();
        services.AddScoped<IWriterInfoService, WriterInfoService>();
        return services;
    }
}
