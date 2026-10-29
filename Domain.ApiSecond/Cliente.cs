using System.ComponentModel.DataAnnotations;

namespace Domain.ApiSecond
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Activo { get; set; }
    }
}
