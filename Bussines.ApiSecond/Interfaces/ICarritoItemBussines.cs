using Domain.ApiSecond;

namespace Bussines.ApiSecond.Interfaces
{
    public interface ICarritoItemBussines
    {
        List<CarritoItem> GetAll();
        bool Insert(CarritoItem carritoItem);
    }
}
