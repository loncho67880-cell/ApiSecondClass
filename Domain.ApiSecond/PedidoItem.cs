using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ApiSecond
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
