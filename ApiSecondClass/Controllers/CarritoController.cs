using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoBussines _carritoBussines;

        public CarritoController(ICarritoBussines carritoBussines)
        {
            _carritoBussines = carritoBussines;
        }

        [HttpGet]
        public ActionResult GetCarritos()
        {
            return Ok(_carritoBussines.GetAll());
        }

        [HttpPost]
        public ActionResult Insert([FromBody] CarritoInsertDto carrito)
        {
            return Ok(_carritoBussines.Insert(new Carrito()
            {
                IdCliente = carrito.IdCliente,
                Fecha = carrito.Fecha
            }));
        }
    }
}
