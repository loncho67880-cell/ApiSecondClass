using Domain.ApiSecond;

namespace Repository.ApiSecond.Intefaces
{
    public interface ICarritoItemRepository
    {
        List<CarritoItem> GetAll();

        bool InsertDapper(CarritoItem carritoItem);
        bool InsertEF(CarritoItem carritoItem);
    }
}
