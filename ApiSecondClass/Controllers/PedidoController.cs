using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoBussines _pedidoBussines;

        public PedidoController(IPedidoBussines pedidoBussines)
        {
            _pedidoBussines = pedidoBussines;
        }

        [HttpGet]
        public ActionResult GetPedidos()
        {
            return Ok(_pedidoBussines.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var pedido = _pedidoBussines.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPost]
        public ActionResult Insert([FromBody] PedidoInsertDto pedido)
        {
            return Ok(_pedidoBussines.Insert(pedido));
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] PedidoUpdateDto pedido)
        {
            var updated = _pedidoBussines.Update(id, pedido);
            if (!updated)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _pedidoBussines.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok(deleted);
        }
    }
}
