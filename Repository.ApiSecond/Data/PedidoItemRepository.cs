using Dapper;
using Domain.ApiSecond;
using Microsoft.EntityFrameworkCore;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;

namespace Repository.ApiSecond.Data
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly CarritoDbContext _context;

        public PedidoItemRepository(CarritoDbContext context)
        {
            _context = context;
        }

        public List<PedidoItem> GetAll()
        {
            return _context.PedidoItem.ToList();
        }

        public PedidoItem? GetById(int id)
        {
            return _context.PedidoItem.FirstOrDefault(x => x.Id == id);
        }

        public bool InsertDapper(PedidoItem pedidoItem)
        {
            var conection = _context.Database.GetDbConnection();

            var sql = $"INSERT INTO [dbo].[PedidoItem] ([IdPedido],[IdProducto]) VALUES (@IdPedido,@IdProducto)";

            var rowsAffested = conection.Execute(sql, new
            {
                IdPedido = pedidoItem.IdPedido,
                IdProducto = pedidoItem.IdProducto,
            });

            return rowsAffested > 0;
        }

        public bool InsertEF(PedidoItem pedidoItem)
        {
            _context.PedidoItem.Add(pedidoItem);
            _context.SaveChanges();

            return true;
        }

        public bool Update(PedidoItem pedidoItem)
        {
            var existing = _context.PedidoItem.FirstOrDefault(x => x.Id == pedidoItem.Id);
            if (existing == null)
            {
                return false;
            }

            existing.IdPedido = pedidoItem.IdPedido;
            existing.IdProducto = pedidoItem.IdProducto;
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var existing = _context.PedidoItem.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                return false;
            }

            _context.PedidoItem.Remove(existing);
            _context.SaveChanges();

            return true;
        }
    }
}
