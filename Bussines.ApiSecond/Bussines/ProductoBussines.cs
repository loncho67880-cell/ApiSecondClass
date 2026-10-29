using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Repository.ApiSecond.Intefaces;

namespace Bussines.ApiSecond.Bussines
{
    public class ProductoBussines : IProductoBussines
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoBussines(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<Producto> ProductosActivos()
        {
            return _productoRepository.GetAll().Where(x=> x.Activo).ToList();
        }
    }
}
