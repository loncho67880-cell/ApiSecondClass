using Domain.ApiSecond;
using Domain.ApiSecond.Dto;

namespace Bussines.ApiSecond.Interfaces
{
    public interface ICarritoBussines
    {
        List<Carrito> GetAll();
        bool Insert(CarritoInsertDto carrito);
    }
}
