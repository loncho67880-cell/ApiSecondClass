using ApiSecondClass.Middleware;
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
builder.Services.AddScoped<ICarritoRepository, CarritoRepository>();
builder.Services.AddScoped<ICarritoItemRepository, CarritoItemRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();

//DI Bussines
builder.Services.AddScoped<IClienteBussines, ClienteBussines>();
builder.Services.AddScoped<IProductoBussines, ProductoBussines>();
builder.Services.AddScoped<ICarritoBussines, CarritoBussines>();
builder.Services.AddScoped<ICarritoItemBussines, CarritoItemBussines>();
builder.Services.AddScoped<IPedidoBussines, PedidoBussines>();
builder.Services.AddScoped<IPedidoItemBussines, PedidoItemBussines>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseMiddleware<RequestLogginMiddleware>();
app.UseMiddleware<ManageExeptionsMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
