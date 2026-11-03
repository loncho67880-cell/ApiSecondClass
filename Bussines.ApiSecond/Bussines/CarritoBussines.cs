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


        public CarritoBussines(ICarritoRepository carritorepository, ICarritoItemRepository carritoitemrepository)
        {
            _carritorepository = carritorepository;
            _carritoitemrepository = carritoitemrepository;
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

            foreach (var item in carrito.CarritoItem) 
            {
                _carritoitemrepository.InsertDapper(new CarritoItem()
                {
                    IdCarrito = idCarrito,
                    IdProducto = item.IdProducto
                });
            }

            return true; 
        }
    }
}
