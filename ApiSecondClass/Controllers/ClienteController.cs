using Bussines.ApiSecond;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetClientesActivos() 
        {
            ClienteBussines clienteBussines = new ClienteBussines();
            var clientes = clienteBussines.ClientesActivos();

            return Ok(clientes);
        }
    }
}
