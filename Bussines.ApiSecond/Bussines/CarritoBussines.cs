using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Repository.ApiSecond.Intefaces;

namespace Bussines.ApiSecond.Bussines
{
    public class CarritoBussines : ICarritoBussines
    {
        private readonly ICarritoRepository _carritorepository;
        private readonly ICarritoItemRepository _carritoitemrepository;
        private readonly IProductoRepository _productorepository;

        public CarritoBussines(ICarritoRepository carritorepository, ICarritoItemRepository carritoitemrepository,
                            IProductoRepository productoRepository)
        {
            _carritorepository = carritorepository;
            _carritoitemrepository = carritoitemrepository;
            _productorepository = productoRepository;
        }

        public List<Carrito> GetAll()
        {
            return _carritorepository.GetAll();
        }

        public bool Insert(CarritoInsertDto carrito)
        {
            int idCarrito = _carritorepository.InsertDapper(new Carrito()
            {
                IdCliente = carrito.IdCliente,
                Fecha = carrito.Fecha,
            });

            // Validar si el carrito se insertó correctamente CU 7645
            if (idCarrito <= 0)
                throw new Exception("No se creo el Carrito Correctamente");

            foreach (var item in carrito.CarritoItem) 
            {
                // Validar si el producto existe CU 7689
                var producto = _productorepository.GetById(item.IdProducto);
                if (producto == null)
                    throw new Exception("El producto no existe.");

                bool itemInserted = _carritoitemrepository.InsertDapper(new CarritoItem()
                {
                    IdCarrito = idCarrito,
                    IdProducto = item.IdProducto
                });

                // Validar si el item del carrito se insertó correctamente CU 7667
                if (!itemInserted)
                    throw new Exception("No se creo el Item del Carrito Correctamente");
            }

            return true; 
        }
    }
}
