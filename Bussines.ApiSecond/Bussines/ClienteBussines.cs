using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Repository.ApiSecond.Data;

namespace Bussines.ApiSecond.Bussines
{
    public class ClienteBussines : IClienteBussines
    {
        public List<Cliente> ClientesActivos()
        {
            ClienteRepository repository = new ClienteRepository();

            return repository.ClientesActivos();
        }
    }
}
