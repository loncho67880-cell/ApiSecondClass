using Bussines.ApiSecond.Bussines;
using Bussines.ApiSecond.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.ApiSecond.Data;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarritoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//DI Repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

//DI Bussines
builder.Services.AddScoped<IClienteBussines, ClienteBussines>();
builder.Services.AddScoped<IProductoBussines, ProductoBussines>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
