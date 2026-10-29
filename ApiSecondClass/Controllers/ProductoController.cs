using Bussines.ApiSecond.Bussines;
using Bussines.ApiSecond.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoBussines _productobussines;

        public ProductoController(IProductoBussines productobussines)
        {
            _productobussines = productobussines;
        }

        [HttpGet]
        public ActionResult GetProductosActivos()
        {
            return Ok(_productobussines.ProductosActivos());
        }
    }
}
