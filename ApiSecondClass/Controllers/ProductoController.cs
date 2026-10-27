using Bussines.ApiSecond.Bussines;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetProductosActivos()
        {
            ProductoBussines productoBussines = new ProductoBussines();

            return Ok(productoBussines.ProductosActivos());
        }
    }
}
