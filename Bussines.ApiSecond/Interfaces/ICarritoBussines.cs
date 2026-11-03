using Domain.ApiSecond;

namespace Bussines.ApiSecond.Interfaces
{
    public interface ICarritoBussines
    {
        List<Carrito> GetAll();
        bool Insert(Carrito carrito);
    }
}
