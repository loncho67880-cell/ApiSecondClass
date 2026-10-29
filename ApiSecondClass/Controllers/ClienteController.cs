using Bussines.ApiSecond.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBussines _clienteBussines;

        public ClienteController(IClienteBussines clienteBussines)
        {
            _clienteBussines = clienteBussines;
        }

        [HttpGet]
        public ActionResult GetClientesActivos() 
        {
            return Ok(_clienteBussines.ClientesActivos());
        }
    }
}
