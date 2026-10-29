using System.ComponentModel.DataAnnotations;

namespace Domain.ApiSecond
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public bool Activo { get; set; }
    }
}
