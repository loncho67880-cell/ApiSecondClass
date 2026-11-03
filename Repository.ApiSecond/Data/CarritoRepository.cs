using Domain.ApiSecond;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Repository.ApiSecond.Data
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly CarritoDbContext _context;

        public CarritoRepository(CarritoDbContext context)
        {
            _context = context;
        }

        public List<Carrito> GetAll()
        {
            return _context.Carrito.ToList();
        }

        public bool InsertDapper(Carrito carrito)
        {
            var conection = _context.Database.GetDbConnection();

            var sql = $"INSERT INTO [dbo].[Carrito] ([IdCliente],[Fecha]) VALUES (@IdCliente,@Fecha)";

            var rowsAffested = conection.Execute(sql, new
            {
                IdCliente = carrito.IdCliente,
                Fecha = carrito.Fecha,
            });

            return rowsAffested > 0;
        }

        public bool InsertEF(Carrito carrito)
        {
            _context.Carrito.Add(carrito);
            _context.SaveChanges();

            return true;
        }
    }
}
