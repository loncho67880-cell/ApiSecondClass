using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoItemController : ControllerBase
    {
        private readonly ICarritoItemBussines _carritoItemBussines;

        public CarritoItemController(ICarritoItemBussines carritoItemBussines)
        {
            _carritoItemBussines = carritoItemBussines;
        }

        [HttpGet]
        public ActionResult GetAll() {
            return Ok(_carritoItemBussines.GetAll());
        }

        [HttpPost]
        public ActionResult Insert([FromBody] CarritoItemInsertDto carritoItemInsertDto)
        {
            return Ok(_carritoItemBussines.Insert(new CarritoItem()
            {
                IdCarrito = carritoItemInsertDto.IdCarrito,
                IdProducto = carritoItemInsertDto.IdProducto
            }));
        }
    }
}
