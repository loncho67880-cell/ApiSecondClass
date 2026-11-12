using Domain.ApiSecond;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Repository.ApiSecond.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly CarritoDbContext _context;

        public PedidoRepository(CarritoDbContext context)
        {
            _context = context;
        }

        public List<Pedido> GetAll()
        {
            return _context.Pedido.ToList();
        }

        public Pedido? GetById(int id)
        {
            return _context.Pedido.FirstOrDefault(x => x.Id == id);
        }

        public int InsertDapper(Pedido pedido)
        {
            var conection = _context.Database.GetDbConnection();

            var sql = $"INSERT INTO [dbo].[Pedido] ([IdCliente],[Fecha]) VALUES (@IdCliente,@Fecha); " +
                $"SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var idPedido = conection.QuerySingle<int>(sql, new
            {
                IdCliente = pedido.IdCliente,
                Fecha = pedido.Fecha,
            });

            return idPedido;
        }

        public int InsertEF(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            _context.SaveChanges();

            return pedido.Id;
        }

        public bool Update(Pedido pedido)
        {
            var existing = _context.Pedido.FirstOrDefault(x => x.Id == pedido.Id);
            if (existing == null)
            {
                return false;
            }

            existing.IdCliente = pedido.IdCliente;
            existing.Fecha = pedido.Fecha;
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var existing = _context.Pedido.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                return false;
            }

            var items = _context.PedidoItem.Where(x => x.IdPedido == id).ToList();
            _context.PedidoItem.RemoveRange(items);
            _context.Pedido.Remove(existing);
            _context.SaveChanges();

            return true;
        }
    }
}
