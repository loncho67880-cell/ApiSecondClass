using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ApiSecond
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        public PedidoItem PedidoItem { get; set; }
    }
}
