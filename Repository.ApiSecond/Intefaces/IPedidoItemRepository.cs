using Domain.ApiSecond;

namespace Repository.ApiSecond.Intefaces
{
    public interface IPedidoItemRepository
    {
        List<PedidoItem> GetAll();
        PedidoItem? GetById(int id);
        bool InsertDapper(PedidoItem pedidoItem);
        bool InsertEF(PedidoItem pedidoItem);
        bool Update(PedidoItem pedidoItem);
        bool Delete(int id);
    }
}
