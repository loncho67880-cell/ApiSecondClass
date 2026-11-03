using Domain.ApiSecond;

namespace Repository.ApiSecond.Intefaces
{
    public interface ICarritoRepository
    {
        List<Carrito> GetAll();
        bool InsertDapper(Carrito carrito);
        bool InsertEF(Carrito carrito);
    }
}
