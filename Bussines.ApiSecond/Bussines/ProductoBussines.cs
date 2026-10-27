using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Repository.ApiSecond.Data;

namespace Bussines.ApiSecond.Bussines
{
    public class ProductoBussines : IProductoBussines
    {
        public List<Producto> ProductosActivos()
        {
            ProductoRepository productoRepository = new ProductoRepository();
            return productoRepository.GetAll().Where(x=> x.Activo).ToList();
        }
    }
}
