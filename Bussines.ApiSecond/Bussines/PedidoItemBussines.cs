using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Repository.ApiSecond.Intefaces;

namespace Bussines.ApiSecond.Bussines
{
    public class PedidoItemBussines : IPedidoItemBussines
    {
        private readonly IPedidoItemRepository _pedidoitemrepositry;

        public PedidoItemBussines(IPedidoItemRepository pedidoitemrepositry)
        {
            _pedidoitemrepositry = pedidoitemrepositry;
        }

        public List<PedidoItem> GetAll()
        {
            return _pedidoitemrepositry.GetAll();
        }

        public PedidoItem? GetById(int id)
        {
            return _pedidoitemrepositry.GetById(id);
        }

        public bool Insert(PedidoItem pedidoItem)
        {
            return _pedidoitemrepositry.InsertEF(pedidoItem);
        }

        public bool Update(int id, PedidoItemUpdateDto pedidoItem)
        {
            return _pedidoitemrepositry.Update(new PedidoItem()
            {
                Id = id,
                IdPedido = pedidoItem.IdPedido,
                IdProducto = pedidoItem.IdProducto
            });
        }

        public bool Delete(int id)
        {
            return _pedidoitemrepositry.Delete(id);
        }
    }
}
