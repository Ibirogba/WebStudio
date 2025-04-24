using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebStudio.Application_core.Database_Context;
using WebStudio.Application_core.Interface;
using WebStudio.Application_core.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
