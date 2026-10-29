using Domain.ApiSecond;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;

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
    }
}
