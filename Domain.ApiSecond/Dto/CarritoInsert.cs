namespace Domain.ApiSecond.Dto
{
    public class CarritoInsertDto
    {
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<CarritoItemInsertDto> CarritoItem { get; set; } = new List<CarritoItemInsertDto>();
    }
}
