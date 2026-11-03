using Domain.ApiSecond;

namespace Repository.ApiSecond.Intefaces
{
    public interface ICarritoRepository
    {
        List<Carrito> GetAll();
        int InsertDapper(Carrito carrito);
        int InsertEF(Carrito carrito);
    }
}
