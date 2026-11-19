using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Authorize]
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
            var carritoItems = _carritoItemBussines.GetAll();
            if(carritoItems == null || !carritoItems.Any())
            {
                return NotFound("No se encontraron items en el carrito.");
            }

            return Ok(_carritoItemBussines.GetAll());
        }

        [HttpPost]
        public ActionResult Insert([FromBody] CarritoItemInsertDto carritoItemInsertDto)
        {
            return Created("uri", _carritoItemBussines.Insert(new CarritoItem()
            {
                IdCarrito = carritoItemInsertDto.IdCarrito,
                IdProducto = carritoItemInsertDto.IdProducto
            }));
        }
    }
}
