using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Repository.ApiSecond.Intefaces;

namespace Bussines.ApiSecond.Bussines
{
    public class ClienteBussines : IClienteBussines
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteBussines(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> ClientesActivos()
        {
            return _clienteRepository.ClientesActivos();
        }
    }
}
