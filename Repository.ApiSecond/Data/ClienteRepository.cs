using Domain.ApiSecond;
using Repository.ApiSecond.Intefaces;

namespace Repository.ApiSecond.Data
{
    public class ClienteRepository : IClienteRepository
    {
        public List<Cliente> ClientesActivos()
        {
            return new List<Cliente>()
            {
                new Cliente()
                {
                    Nombre = "Pedro perez",
                    FechaNacimiento = DateTime.Now.AddYears(-23),
                    Activo = true
                },
                new Cliente()
                {
                    Nombre = "Ana torres",
                    FechaNacimiento = DateTime.Now.AddYears(-35),
                    Activo = true
                },
                new Cliente()
                {
                    Nombre = "Carlos jaramillo",
                    FechaNacimiento = DateTime.Now.AddYears(-60),
                    Activo = true
                },
            };
        }
    }
}
