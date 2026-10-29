using Domain.ApiSecond;
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
    }
}
