using Domain.ApiSecond;
using Domain.ApiSecond.Dto;

namespace Bussines.ApiSecond.Interfaces
{
    public interface IPedidoBussines
    {
        List<Pedido> GetAll();
        Pedido? GetById(int id);
        bool Insert(PedidoInsertDto pedido);
        bool Update(int id, PedidoUpdateDto pedido);
        bool Delete(int id);
    }
}
