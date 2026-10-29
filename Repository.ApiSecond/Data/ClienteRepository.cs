using Domain.ApiSecond;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;

namespace Repository.ApiSecond.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CarritoDbContext _context;
        
        public ClienteRepository(CarritoDbContext context)
        {
            _context = context;
        }

        public List<Cliente> ClientesActivos()
        {
            var listaClientes = _context.Cliente.ToList();
            return listaClientes;
        }
    }
}
