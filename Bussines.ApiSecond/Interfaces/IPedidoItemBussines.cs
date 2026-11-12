using Domain.ApiSecond;
using Domain.ApiSecond.Dto;

namespace Bussines.ApiSecond.Interfaces
{
    public interface IPedidoItemBussines
    {
        List<PedidoItem> GetAll();
        PedidoItem? GetById(int id);
        bool Insert(PedidoItem pedidoItem);
        bool Update(int id, PedidoItemUpdateDto pedidoItem);
        bool Delete(int id);
    }
}
