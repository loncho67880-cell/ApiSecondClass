using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Repository.ApiSecond.Intefaces;

namespace Bussines.ApiSecond.Bussines
{
    public class PedidoBussines : IPedidoBussines
    {
        private readonly IPedidoRepository _pedidorepository;
        private readonly IPedidoItemRepository _pedidoitemrepository;

        public PedidoBussines(IPedidoRepository pedidorepository, IPedidoItemRepository pedidoitemrepository)
        {
            _pedidorepository = pedidorepository;
            _pedidoitemrepository = pedidoitemrepository;
        }

        public List<Pedido> GetAll()
        {
            return _pedidorepository.GetAll();
        }

        public Pedido? GetById(int id)
        {
            return _pedidorepository.GetById(id);
        }

        public bool Insert(PedidoInsertDto pedido)
        {
            int idPedido = _pedidorepository.InsertDapper(new Pedido()
            {
                IdCliente = pedido.IdCliente,
                Fecha = pedido.Fecha,
            });

            foreach (var item in pedido.PedidoItem)
            {
                _pedidoitemrepository.InsertDapper(new PedidoItem()
                {
                    IdPedido = idPedido,
                    IdProducto = item.IdProducto
                });
            }

            return true;
        }

        public bool Update(int id, PedidoUpdateDto pedido)
        {
            return _pedidorepository.Update(new Pedido()
            {
                Id = id,
                IdCliente = pedido.IdCliente,
                Fecha = pedido.Fecha
            });
        }

        public bool Delete(int id)
        {
            return _pedidorepository.Delete(id);
        }
    }
}
