using Dapper;
using Domain.ApiSecond;
using Microsoft.EntityFrameworkCore;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;

namespace Repository.ApiSecond.Data
{
    public class CarritoItemRepository : ICarritoItemRepository
    {
        private readonly CarritoDbContext _context;

        public CarritoItemRepository(CarritoDbContext context)
        {
            _context = context;
        }

        public List<CarritoItem> GetAll()
        {
            return _context.CarritoItem.ToList();
        }

        public bool InsertDapper(CarritoItem carritoItem)
        {
            var conection = _context.Database.GetDbConnection();

            var sql = $"INSERT INTO [dbo].[CarritoItem] ([IdCarrito],[IdProducto])  VALUES (@IdCarrito,@IdProducto)";

            var rowsAffested = conection.Execute(sql, new
            {
                IdCarrito = carritoItem.IdCarrito,
                IdProducto = carritoItem.IdProducto,
            });

            return rowsAffested > 0;
        }

        public bool InsertEF(CarritoItem carritoItem)
        {
            _context.CarritoItem.Add(carritoItem);
            _context.SaveChanges();

            return true;
        }
    }
}
