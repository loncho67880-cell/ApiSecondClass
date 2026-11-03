using Bussines.ApiSecond.Interfaces;
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
    }
}
