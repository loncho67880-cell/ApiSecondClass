namespace Domain.ApiSecond.Dto
{
    public class PedidoInsertDto
    {
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<PedidoItemInsertDto> PedidoItem { get; set; } = new List<PedidoItemInsertDto>();
    }
}
