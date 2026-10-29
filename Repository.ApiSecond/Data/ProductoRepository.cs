using Domain.ApiSecond;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;

namespace Repository.ApiSecond.Data
{
    public class ProductoRepository : IProductoRepository
    {
        public readonly CarritoDbContext _context;

        public ProductoRepository(CarritoDbContext context)
        {
            _context = context;
        }

        public List<Producto> GetAll()
        {
            var listaProductos = _context.Producto.ToList();
            return listaProductos;
        }
    }
}
