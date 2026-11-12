using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoItemController : ControllerBase
    {
        private readonly IPedidoItemBussines _pedidoItemBussines;

        public PedidoItemController(IPedidoItemBussines pedidoItemBussines)
        {
            _pedidoItemBussines = pedidoItemBussines;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_pedidoItemBussines.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var pedidoItem = _pedidoItemBussines.GetById(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return Ok(pedidoItem);
        }

        [HttpPost]
        public ActionResult Insert([FromBody] PedidoItemInsertDto pedidoItemInsertDto)
        {
            return Ok(_pedidoItemBussines.Insert(new PedidoItem()
            {
                IdPedido = pedidoItemInsertDto.IdPedido,
                IdProducto = pedidoItemInsertDto.IdProducto
            }));
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] PedidoItemUpdateDto pedidoItem)
        {
            var updated = _pedidoItemBussines.Update(id, pedidoItem);
            if (!updated)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _pedidoItemBussines.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok(deleted);
        }
    }
}
