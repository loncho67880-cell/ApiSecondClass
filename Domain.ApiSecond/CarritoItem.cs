using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ApiSecond
{
    public class CarritoItem
    {
        [Key]
        public int Id { get; set; }
        public int IdCarrito { get; set; }
        public int IdProducto { get; set; }

        [ForeignKey("IdCarrito")]
        public Carrito Carrito { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
