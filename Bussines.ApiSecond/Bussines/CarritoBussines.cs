using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Repository.ApiSecond.Intefaces;

namespace Bussines.ApiSecond.Bussines
{
    public class CarritoBussines : ICarritoBussines
    {
        private readonly ICarritoRepository _carritorepository;

        public CarritoBussines(ICarritoRepository carritorepository)
        {
            _carritorepository = carritorepository;
        }

        public List<Carrito> GetAll()
        {
            return _carritorepository.GetAll();
        }
    }
}
