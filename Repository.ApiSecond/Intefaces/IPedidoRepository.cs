using Domain.ApiSecond;

namespace Repository.ApiSecond.Intefaces
{
    public interface IPedidoRepository
    {
        List<Pedido> GetAll();
        Pedido? GetById(int id);
        int InsertDapper(Pedido pedido);
        int InsertEF(Pedido pedido);
        bool Update(Pedido pedido);
        bool Delete(int id);
    }
}
