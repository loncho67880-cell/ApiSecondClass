using Domain.ApiSecond;
using Repository.ApiSecond.Intefaces;

namespace Repository.ApiSecond.Data
{
    public class ProductoRepository : IProductoRepository
    {
        public List<Producto> GetAll()
        {
            return new List<Producto>()
            {
                new Producto()
                {
                    NombreProducto = "Camiseta",
                    Cantidad = 30,
                    Activo = true
                },
                new Producto()
                {
                    NombreProducto = "Pantalon",
                    Cantidad = 50,
                    Activo = true
                },
                new Producto()
                {
                    NombreProducto = "Blusa",
                    Cantidad = 24,
                    Activo = true
                },
                new Producto()
                {
                    NombreProducto = "Chaqueta",
                    Cantidad = 40,
                    Activo = true
                },
                new Producto()
                {
                    NombreProducto = "Tenis",
                    Cantidad = 58,
                    Activo = true
                },
            };
        }
    }
}
