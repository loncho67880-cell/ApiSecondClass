using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Repository.ApiSecond.Intefaces;

namespace Bussines.ApiSecond.Bussines
{
    public class CarritoItemBussines : ICarritoItemBussines
    {
        private readonly ICarritoItemRepository _carritoitemrepositry;

        public CarritoItemBussines(ICarritoItemRepository carritoitemrepositry)
        {
            _carritoitemrepositry = carritoitemrepositry;
        }

        public List<CarritoItem> GetAll()
        {
            return _carritoitemrepositry.GetAll();
        }
    }
}
